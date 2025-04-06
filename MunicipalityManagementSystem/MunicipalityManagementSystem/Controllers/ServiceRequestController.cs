using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityManagementSystem.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly MunicipalityManagementSystemDbContext _context;

        public ServiceRequestController(MunicipalityManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var serviceRequests = await _context.ServiceRequests
                .Include(sr => sr.Citizen)
                .ToListAsync();
            return View(serviceRequests);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequests
                .Include(sr => sr.Citizen)
                .FirstOrDefaultAsync(sr => sr.RequestID == id);

            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceRequest request)
        {
            if (ModelState.IsValid)
            {
                _context.ServiceRequests.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        public async Task<IActionResult> UpdateStatus(int id)
        {
            var request = await _context.ServiceRequests.FindAsync(id);
            if (request == null) return NotFound();
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var request = await _context.ServiceRequests.FindAsync(id);
            if (request == null) return NotFound();

            request.Status = status;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.ServiceRequests
                .Include(r => r.Citizen)
                .FirstOrDefaultAsync(r => r.RequestID == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.ServiceRequests
            .Include(r => r.Citizen)
            .FirstOrDefaultAsync(r => r.RequestID == id);
            if (request == null) return NotFound();

            _context.ServiceRequests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
