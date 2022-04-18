#nullable disable
using html_24_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace html_24_03.Controllers
{
    public class CursosController : Controller
    {
        private readonly DBContext _context;

        public CursosController(DBContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            return View(await _context.BancoCursos.ToListAsync());
        }

        public async Task<IActionResult> Home()
        {
            return View(await _context.BancoCursos.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.BancoCursos
                .FirstOrDefaultAsync(m => m.cursosId == id);
            if (cursos == null)
            {
                return NotFound();
            }

            return View(cursos);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cursosId,cursoNome")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursos);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.BancoCursos.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cursosId,cursoNome")] Cursos cursos)
        {
            if (id != cursos.cursosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursosExists(cursos.cursosId))
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
            return View(cursos);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursos = await _context.BancoCursos
                .FirstOrDefaultAsync(m => m.cursosId == id);
            if (cursos == null)
            {
                return NotFound();
            }

            return View(cursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursos = await _context.BancoCursos.FindAsync(id);
            _context.BancoCursos.Remove(cursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursosExists(int id)
        {
            return _context.BancoCursos.Any(e => e.cursosId == id);
        }
    }
}
