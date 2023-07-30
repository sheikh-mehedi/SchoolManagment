using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagment2.DB;
using SchoolManagment2.Models;
using SchoolManagment2.ViewModels;

namespace SchoolManagment2.Controllers
{
    public class TeachersController : Controller
    {
        private readonly DataContext _context;
        public TeachersController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>Index()
        {
            var result = (from teacher in _context.Teachers
                          join clas in _context.Classes
                          on teacher.C_Id equals clas.C_Id
                          select new TeacherClassVM
                          {
                              T_Id = teacher.T_Id,
                              T_Name = teacher.T_Name,
                              C_Id = clas.C_Id,
                              C_Name = clas.C_Name
                          }).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            TakeData();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Teacher tcr)
        {
            _context.Add(tcr);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //GET:Teacher/Edit
        public async Task<IActionResult>Edit(int? id)
        {
            TakeData();

            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            _context.Update(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index", "Teachers");

        }

        // GET: Teacher/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var result = await _context.Teachers
                .FirstOrDefaultAsync(m => m.T_Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teachers == null)
            {
                return NotFound();
            }

            var result = await _context.Teachers
                .FirstOrDefaultAsync(m => m.T_Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }


        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teachers == null)
            {
                return Problem("Entity set 'DataContext.Teachers'  is null.");
            }
            var result = await _context.Teachers.FindAsync(id);
            if (result != null)
            {
                _context.Teachers.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public void TakeData()
        {
            var result = _context.Classes.FromSqlRaw("Select * From Classes")
                .Select(x => new Class
                {
                    C_Id = x.C_Id,
                    C_Name = x.C_Name
                }).ToList();

            ViewBag.clas = result;

        }
    }
}
