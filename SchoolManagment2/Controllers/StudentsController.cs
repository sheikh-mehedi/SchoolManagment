using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagment2.DB;
using SchoolManagment2.Models;
using SchoolManagment2.ViewModels;

namespace SchoolManagment2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DataContext _context;
        public StudentsController(DataContext context)
        {
            _context = context;
        }
       

        public async Task<IActionResult> Index()
        {

            var result = (from student in _context.Students
                           join teacher in _context.Teachers on student.T_Id equals teacher.T_Id
                           join book in _context.Books on student.B_Id equals book.B_Id
                           join clas in _context.Classes on student.C_Id equals clas.C_Id
                          select new StudentTeacherVM
                          {
                               S_Id= student.S_Id,
                               S_Name= student.S_Name,
                               T_Id= teacher.T_Id,
                               T_Name= teacher.T_Name,
                               B_Id= book.B_Id,
                               B_Name= book.B_Name,
                               C_Id = clas.C_Id,
                               C_Name= clas.C_Name
                            


                          }).ToList();
            return View(result);

        }
        public IActionResult Create()
        {
            TakeData();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student sdt)
        {
            _context. Students.Add(sdt);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
      

        //GET:Student/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            TakeData();

            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var teacher = await _context.Students.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index", "Students");

        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var result = await _context.Students
                .FirstOrDefaultAsync(m => m.S_Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var result = await _context.Students
                .FirstOrDefaultAsync(m => m.S_Id == id);
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
            if (_context.Students == null)
            {
                return Problem("Entity set 'DataContext.Students'  is null.");
            }
            var result = await _context.Students.FindAsync(id);
            if (result != null)
            {
                _context.Students.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public void TakeData()
        {
            var teachers1 = _context.Teachers.FromSqlRaw("Select * From Teachers")
                .Select(x => new Teacher
                {
                    T_Id = x.T_Id,
                    T_Name = x.T_Name
                }).ToList();
            ViewBag.teacher = teachers1;


            var books1 = _context.Books.FromSqlRaw("Select * From Books")
               .Select(x => new Book
               {
                   B_Id = x.B_Id,
                   B_Name = x.B_Name
               }).ToList();
            ViewBag.book = books1;
        }
    public JsonResult GetClassByBook(int bookId)
        {
            var students = _context.Classes
                .Where(x => x.B_Id == bookId)
                .ToList();
            return Json(students);  
        }

    }
}
