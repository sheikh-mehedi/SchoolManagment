using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagment2.DB;
using SchoolManagment2.Models;
using SchoolManagment2.ViewModels;

namespace SchoolManagment2.Controllers
{
    public class ClassesController : Controller
    {
        private readonly DataContext _context;
        public ClassesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var result = (from clas in _context.Classes
                          join bok in _context.Books
                          on clas.B_Id equals bok.B_Id
                          select new BookClassVM
                          {
                             C_Id = clas.C_Id,
                              C_Name = clas.C_Name,
                              B_Id = bok.B_Id,
                              B_Name = bok.B_Name
                          }).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            TakeData();
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Class cls)
        {
            _context.Add(cls);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
           

            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }
            var data = await _context.Classes.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Class cls)
        {
            _context.Update(cls);
            _context.SaveChanges();
            return RedirectToAction("Index", "Classes");

        }

        public async Task<IActionResult>Details(int? id)
        {
            if(id == null || _context.Classes == null)
            {
                return NotFound();
            }
            var result = await _context.Classes
                .FirstOrDefaultAsync(m => m.C_Id == id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public async Task<IActionResult>Delete(int? id)
        {
            if(id == null || _context.Classes == null)
            {
                return NotFound();
            }
            var data = await _context.Classes
                 .FirstOrDefaultAsync(m => m.C_Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'DataContext.Classes'  is null.");
            }
            var result = await _context.Classes.FindAsync(id);
            if (result != null)
            {
                _context.Classes.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public void TakeData()
        {
            var data = _context.Books.FromSqlRaw("Select * From Books")
                .Select(x => new Book
                {
                    B_Id= x.B_Id,
                    B_Name= x.B_Name
                }).ToList();
            ViewBag.book = data;

        }
    }
}
