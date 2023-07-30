using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagment2.DB;
using SchoolManagment2.Models;

namespace SchoolManagment2.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;
       public UsersController (DataContext context)
        {
            _context = context;
        }
        public async Task <ActionResult> Index()
        {
         var data = _context.Users.ToList();
            return View(data);
        }
        public async Task<IActionResult>Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult>Create(User user)
        {
            _context.Add(user);
            _context.SaveChangesAsync();
            return RedirectToAction (nameof(Index));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(User usr)
        {
            var existUser = await _context.Users
                .Where(x => x.U_Name == usr.U_Name && x.U_Password == usr.U_Password)
                .FirstOrDefaultAsync();
            if (existUser != null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.error = "User Not Found In Database";
            return View();
        } 
        public IActionResult Mehedi()
        {
            return View();
        }
        public JsonResult GetClassByuser(string mehediId)
        {
            return Json(mehediId);
        }
    }
}
