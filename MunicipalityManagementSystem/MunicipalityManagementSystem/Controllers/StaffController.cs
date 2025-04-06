using Microsoft.AspNetCore.Mvc;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly MunicipalityManagementSystemDbContext _context;

        public StaffController(MunicipalityManagementSystemDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var staff = _context.Staff.ToList();
            return View(staff);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staff.Add(staff);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public IActionResult Edit(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Staff staff)
        {
            if (id != staff.StaffID) return BadRequest();

            _context.Staff.Update(staff);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null) return NotFound();

            _context.Staff.Remove(staff);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null) return NotFound();
            return View(staff);
        }
    }
}
