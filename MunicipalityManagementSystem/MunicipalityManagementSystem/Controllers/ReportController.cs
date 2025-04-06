using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly MunicipalityManagementSystemDbContext _context;

        public ReportController(MunicipalityManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reports = await _context.Reports
                .Include(r => r.Citizen)
                .ToListAsync();
            return View(reports);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var report = await _context.Reports
                .Include(r => r.Citizen)
                .FirstOrDefaultAsync(r => r.ReportID == id);

            if (report == null) return NotFound();

            return View(report);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Reports.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var report = await _context.Reports
            .Include(r => r.Citizen)
            .FirstOrDefaultAsync(r => r.ReportID == id);

            if (report == null) return NotFound();
            return View(report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Report report)
        {
            if (id != report.ReportID) return BadRequest();

            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var report = await _context.Reports
            .Include(r => r.Citizen)
            .FirstOrDefaultAsync(r => r.ReportID == id);

            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null) return NotFound();

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
