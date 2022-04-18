#nullable disable
using html_24_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace html_24_03.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly DBContext _context;

        public NoticiasController(DBContext context)
        {
            _context = context;
        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {

            return View(await _context.BancoNoticia.ToListAsync());
        }
        public async Task<IActionResult> Home()
        {
            return View(await _context.BancoNoticia.ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.BancoNoticia
                .FirstOrDefaultAsync(m => m.noticiaId == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }
        public async Task<IActionResult> VerMais(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.BancoNoticia
                .FirstOrDefaultAsync(m => m.noticiaId == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("noticiaId,noticiaImg,noticiaTitulo,noticiaTexto,noticiaDescr")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.BancoNoticia.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }
            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("noticiaId,noticiaImg,noticiaTitulo,noticiaTexto,noticiaDescr")] Noticia noticia)
        {
            if (id != noticia.noticiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaExists(noticia.noticiaId))
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
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.BancoNoticia
                .FirstOrDefaultAsync(m => m.noticiaId == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noticia = await _context.BancoNoticia.FindAsync(id);
            _context.BancoNoticia.Remove(noticia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaExists(int id)
        {
            return _context.BancoNoticia.Any(e => e.noticiaId == id);
        }
    }
}
