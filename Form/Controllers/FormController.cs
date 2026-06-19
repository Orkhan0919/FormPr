using Microsoft.AspNetCore.Mvc;
using Form.Models;
using Form.Data;

namespace Form.Controllers
{
    public class FormController : Controller
    {
        private readonly AppDbContext _context;

        public FormController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Form/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Form/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Form.Models.Data data)
        {
            if (ModelState.IsValid)
            {
                _context.Datas.Add(data);
                _context.SaveChanges();
                TempData["Success"] = "Məlumat uğurla əlavə edildi!";
                return RedirectToAction(nameof(Create)); // Yenidən form səhifəsinə qayıt
            }
            return View(data);
        }
    }
}