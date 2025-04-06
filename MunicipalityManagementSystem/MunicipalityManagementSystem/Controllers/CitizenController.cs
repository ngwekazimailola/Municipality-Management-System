using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Controllers
{
    public class CitizenController : Controller
    {
        private readonly MunicipalityManagementSystemDbContext _context;

        public CitizenController(MunicipalityManagementSystemDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var citizens = _context.Citizens.ToList();
            return View(citizens);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                citizen.RegistrationDate = DateTime.Now;

                _context.Citizens.Add(citizen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citizen);
        }

        public IActionResult Edit(int id)
        {
            var citizen = _context.Citizens.Find(id);
            if (citizen == null) return NotFound();
            return View(citizen);
        }

        public IActionResult Delete(int id)
        {
            var citizen = _context.Citizens.Find(id);
            if (citizen == null) return NotFound();
            return View(citizen);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var citizen = _context.Citizens.Find(id);
            if (citizen == null) return NotFound();

            _context.Citizens.Remove(citizen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var citizen = _context.Citizens.Find(id);
            if (citizen == null) return NotFound();
            return View(citizen);
        }
    }
}