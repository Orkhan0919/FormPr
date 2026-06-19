using Microsoft.AspNetCore.Mvc;
using Form.Data;
using Form.Models; // ModelData sinifinin olduğu namespace

namespace Form.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            // Sənin yaratdığın Form.Models.User klasından yeni bir obyekt qururuq
            var newUser = new User
            {
                Username = Username,
                Password = Password
            };

            // AppDbContext-dəki "Users" cədvəlinə bu obyekti əlavə edirik
            _context.Users.Add(newUser);

            // Dəyişiklikləri SQL Server-ə göndərib yadda saxlayırıq
            _context.SaveChanges();

            // Uğurlu qeydiyyatdan sonra istədiyin səhifəyə yönləndiririk
            return RedirectToAction("Create", "Form");
        }
    }
}