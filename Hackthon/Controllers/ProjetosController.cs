using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hackthon;
using Hackthon.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Hackthon.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly HackthonDbContext _context;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public ProjetosController(HackthonDbContext context, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: Projetos
        public async Task<IActionResult> Index()
        {
            var hackthonDbContext = _context.Projeto.Include(p => p.Usuario);
            return View(await hackthonDbContext.ToListAsync());
        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetos/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Users, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaId,Titulo,Descricao,DataCadastro")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                var userId = _context.Users.FirstOrDefault().Id;
                projeto.EmpresaId = userId;
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Users, "Id", "Nome", projeto.EmpresaId);
            return View(projeto);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Users, "Id", "Nome", projeto.EmpresaId);
            return View(projeto);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjetoId,EmpresaId,Titulo,Descricao,DataCadastro")] Projeto projeto)
        {
            if (id != projeto.ProjetoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.ProjetoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Users, "Id", "Nome", projeto.EmpresaId);
            return View(projeto);
        }

        // GET: Projetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.ProjetoId == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projeto = await _context.Projeto.FindAsync(id);
            _context.Projeto.Remove(projeto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(int id)
        {
            return _context.Projeto.Any(e => e.ProjetoId == id);
        }
    }
}
