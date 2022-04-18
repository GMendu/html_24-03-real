#nullable disable
using html_24_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace html_24_03.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly DBContext _context;

        public ProfessoresController(DBContext context)
        {
            _context = context;
        }

        // GET: Professores
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.BancoProfessores.Include(p => p.ProfessoresCurso);
            return View(await dBContext.ToListAsync());
        }
        public async Task<IActionResult> Home()
        {
            var dBContext = _context.BancoProfessores.Include(p => p.ProfessoresCurso);
            return View(await dBContext.ToListAsync());
        }

        // GET: Professores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professores = await _context.BancoProfessores
                .Include(p => p.ProfessoresCurso)
                .FirstOrDefaultAsync(m => m.ProfessoresId == id);
            if (professores == null)
            {
                return NotFound();
            }

            return View(professores);
        }

        // GET: Professores/Create
        public IActionResult Create()
        {
            ViewData["ProfessoresCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId");
            return View();
        }

        // POST: Professores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessoresId,ProfessoresNome,ProfessoresCursoId")] Professores professores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessoresCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId", professores.ProfessoresCursoId);
            return View(professores);
        }

        // GET: Professores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professores = await _context.BancoProfessores.FindAsync(id);
            if (professores == null)
            {
                return NotFound();
            }
            ViewData["ProfessoresCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId", professores.ProfessoresCursoId);
            return View(professores);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessoresId,ProfessoresNome,ProfessoresCursoId")] Professores professores)
        {
            if (id != professores.ProfessoresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessoresExists(professores.ProfessoresId))
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
            ViewData["ProfessoresCursoId"] = new SelectList(_context.BancoCursos, "cursosId", "cursosId", professores.ProfessoresCursoId);
            return View(professores);
        }

        // GET: Professores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professores = await _context.BancoProfessores
                .Include(p => p.ProfessoresCurso)
                .FirstOrDefaultAsync(m => m.ProfessoresId == id);
            if (professores == null)
            {
                return NotFound();
            }

            return View(professores);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professores = await _context.BancoProfessores.FindAsync(id);
            _context.BancoProfessores.Remove(professores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessoresExists(int id)
        {
            return _context.BancoProfessores.Any(e => e.ProfessoresId == id);
        }
    }
}
