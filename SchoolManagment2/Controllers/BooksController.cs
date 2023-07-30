using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagment2.DB;
using SchoolManagment2.Models;

namespace SchoolManagment2.Controllers
{
    public class BooksController : Controller
    {
        private readonly DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Index()
        {
            var data = _context.Books.ToList();
            return View(data);  
        }
        public IActionResult Create() 
        {
          return View();
        }
        [HttpPost]
        public async Task <IActionResult>Create(Book bks)
        {
            _context.Add(bks);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Edit(int? id)
        {
            if(id == null || _context.Books == null)
            {
                return NotFound();
            }
            var result = await _context.Books.FindAsync(id);
            if(result == null) 
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult>Edit(Book bks)
        {
            _context.Update(bks);
            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public async Task<IActionResult>Details(int?id)
        {
            if( id == null || _context.Books == null) 
            {
                return NotFound();
            }
            var result = await _context.Books
                .FirstOrDefaultAsync(m => m.B_Id == id);
            if(result == null) 
            {
                return NotFound();
            }
            return View(result);
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var data = await _context.Books
                .FirstOrDefaultAsync(x => x.B_Id == id);
            if(data == null) 
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'DataContext.Books'  is null.");
            }
            var result = await _context.Books.FindAsync(id);
            if (result != null)
            {
                _context.Books.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
