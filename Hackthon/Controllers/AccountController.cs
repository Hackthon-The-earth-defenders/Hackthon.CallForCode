using HackthAccountViewModelson.ViewModels;
using Hackthon.Extensions;
using Hackthon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackthon.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Funcao> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly HackthonDbContext _context;


        public AccountController(HackthonDbContext context, UserManager<Usuario> userManager, RoleManager<Funcao> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["TipoCadastro"] = this.MontarSelectListParaEnum(new Usuario().TipoCadastro);
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

                    await _signInManager.SignInAsync(model, isPersistent: false);
                    TempData["Confirm"] = "<script>$(document).ready(function () {MostraConfirm('Sucesso', 'Gravado com sucesso.');})</script>";
                    return RedirectToAction("Index", "Home");
                    //return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            ViewData["TipoCadastro"] = this.MontarSelectListParaEnum(new Usuario().TipoCadastro);

            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
