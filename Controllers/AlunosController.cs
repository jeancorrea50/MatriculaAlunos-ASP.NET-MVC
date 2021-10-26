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
    public class AlunosController : Controller
    {
        private readonly MatriculaDbContext _context;

        public AlunosController(MatriculaDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            // .Include(x => x.Categoria) => Ordena a lista passada para index por ordem alfabetica
            // AsNoTracking()  => não precisa ser rastreado ( não precisa verificar se foi alterado ou recuperado) cada compilação o metdo sera executado
            return View(await _context.Alunos.OrderBy(x => x.NomeCompleto).Include(x => x.Curso).AsNoTracking().ToListAsync());

        }

       
        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            var cursos = _context.Cursos.OrderBy(x => x.NomeCurso).AsNoTracking().ToList();
            var cursosSelectList = new SelectList(cursos,
                nameof(CursoModel.IdCurso), nameof(CursoModel.NomeCurso));
            ViewBag.Cursos = cursosSelectList;



            if (id.HasValue)
            {
                var aluno = await _context.Alunos.FindAsync(id);
                if (aluno == null)
                {
                    return NotFound();
                }
                return View(aluno);
            }
            return View(new AlunoModel());
        }


        [HttpPost]
        public async Task<IActionResult> Create(int? id, [FromForm] AlunoModel aluno)
        {

            if (ModelState.IsValid)
            {

               
                if (id.HasValue)
                {
                    if (AlunoExiste(id.Value))
                    {
                        _context.Alunos.Update(aluno);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Aluno alterado com sucesso.");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao alterar Aluno.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Aluno não encontrado.", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Alunos.Add(aluno);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Aluno cadastrado com sucesso.");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar Aluno.", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(aluno);
            }
        }

        private bool AlunoExiste(int id)
        {
            return _context.Alunos.Any(x => x.IdAluno == id);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Aluno não informado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Aluno não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                if (await _context.SaveChangesAsync() > 0)
                    TempData["mensagem"] = MensagemModel.Serializar("Aluno excluído com sucesso.");
                else
                    TempData["mensagem"] = MensagemModel.Serializar("Não foi possível excluir o Aluno.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Aluno não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
