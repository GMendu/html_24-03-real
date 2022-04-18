#nullable disable
using html_24_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace html_24_03.Controllers
{
    public class AlunoesController : Controller
    {
        private readonly DBContext _context;

        public AlunoesController(DBContext context)
        {
            _context = context;
        }

        // GET: Alunoes
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.BancoAluno.Include(a => a.alunoCurso);
            return View(await dBContext.ToListAsync());
        }

        public async Task<IActionResult> Home()
        {
            var dBContext = _context.BancoAluno.Include(a => a.alunoCurso);
            return View(await dBContext.ToListAsync());
        }
        // GET: Alunoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.BancoAluno
                .Include(a => a.alunoCurso)
                .FirstOrDefaultAsync(m => m.alunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunoes/Create
        public IActionResult Create()
        {
            ViewData["alunoCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId");
            return View();
        }

        // POST: Alunoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("alunoId,alunoNome,alunoCursoId")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId", aluno.alunoCursoId);
            return View(aluno);
        }

        // GET: Alunoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.BancoAluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["alunoCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId", aluno.alunoCursoId);
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("alunoId,alunoNome,alunoCursoId")] Aluno aluno)
        {
            if (id != aluno.alunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.alunoId))
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
            ViewData["alunoCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId", aluno.alunoCursoId);
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.BancoAluno
                .Include(a => a.alunoCurso)
                .FirstOrDefaultAsync(m => m.alunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.BancoAluno.FindAsync(id);
            _context.BancoAluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.BancoAluno.Any(e => e.alunoId == id);
        }
    }
}
