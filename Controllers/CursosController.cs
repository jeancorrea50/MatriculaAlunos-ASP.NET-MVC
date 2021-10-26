using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatriculaFaculdade.Data;
using MatriculaFaculdade.Models;

namespace MatriculaFaculdade.Controllers
{
    public class CursosController : Controller
    {
        private readonly MatriculaDbContext _context;

        public CursosController(MatriculaDbContext context)
        {
            _context = context;
        }

         [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cursos.ToListAsync());
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCurso,NomeCurso")] CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoModel);
        }



        private bool CursosExiste(int id)
        {
            return _context.Cursos.Any(x => x.IdCurso == id);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Curso não informada.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Curso não encontrada.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Curso excluída com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir a Curso.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Curso não encontrada.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
