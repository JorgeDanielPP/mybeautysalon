using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBeautySalon.Application.Services;
using MyBeautySalon.Domain;
using MyBeautySalon.Models;
using MyBeautySalon.Persistence;

namespace MyBeautySalon.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppointmentsServices _appointmentservices;
        public AppointmentsController(AppointmentsServices appointmentsServices)
        {
            _appointmentservices = appointmentsServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var appointmentdb = _appointmentservices.GetAll();
            return View(appointmentdb);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           var succeded = _appointmentservices.Create(model);
            if (succeded)
                return RedirectToAction(nameof(Index));
            else
                ViewBag.Error = "Error Saving";
                return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int cid)
        {
            // var appointmentdb =  _context.Appointments.FirstOrDefault(x => x.Id == id);
            // var appointmentdb = _context.Appointments.Find(cid);
            var appointmentdb = _appointmentservices.Get(cid);
            return View(appointmentdb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // _context.Appointments.Update(model);
            // _context.SaveChanges();
            // return RedirectToAction(nameof(Index));
            var succeded = _appointmentservices.Modified(model);
            if (succeded)
                return RedirectToAction(nameof(Index));
            else
                ViewBag.Error = "Error Saving";
                return View(model);


        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var appointmentdb = _appointmentservices.Get(id);
            return View(appointmentdb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AppointmentModel model)
        {
            //   _context.Appointments.Remove(model);
            //   _context.SaveChanges();
            //   return RedirectToAction(nameof(Index));
            var succeded = _appointmentservices.Remove(model);
            if (succeded)
                return RedirectToAction(nameof(Index));
            else
                ViewBag.Error = "Error Saving";
            return View(model);

        }
    }
}
