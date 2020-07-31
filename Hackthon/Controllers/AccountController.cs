using HackthAccountViewModelson.ViewModels;
using Hackthon.Extensions;
using Hackthon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackthon.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Funcao> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly HackthonDbContext _context;


        public AccountController(HackthonDbContext context, UserManager<Usuario> userManager, RoleManager<Funcao> roleManager, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AppController.Index), "App");
                    return RedirectToLocal(returnUrl);
                }
              
                else
                {
                    ModelState.AddModelError(string.Empty, "Inválido login!.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpGet]
        public IActionResult Register(string returnUrl = null, int? tipo=null)
        {
            List<SelectListItem> montaEnum;
            if (tipo != null) {
                var user = new Usuario
                {
                    TipoCadastro = (Models.Enums.TipoUsuario)tipo
                };

                montaEnum = this.MontarSelectListParaEnum(user.TipoCadastro);
            }
            else
            {
                montaEnum = this.MontarSelectListParaEnum(new Usuario().TipoCadastro);

            }
            ViewData["TipoCadastro"] = montaEnum;

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            model.UserName = model.Email;
            ModelState.Clear();
            TryValidateModel(model);
            if (ModelState.IsValid)
            {

                var result = await _userManager.CreateAsync(model, model.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(model);

                    //por ser guid, desabilitei

                    //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);
                    
                    TempData["Confirm"] = "<script>$(document).ready(function () {MostraConfirm('Sucesso', 'Gravado com sucesso.');})</script>";
                    return RedirectToAction("Login", "Account");
                }
                AddErrors(result);
            }

            ViewData["TipoCadastro"] = this.MontarSelectListParaEnum(new Usuario().TipoCadastro);

            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }
        [NonAction]
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(AppController.Index), "Index");
            }
        }
        [NonAction]
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
