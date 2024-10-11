using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital.Controllers
{
    public class Booking : Controller
    {
        ApplicationDbContext dbcontext = new ApplicationDbContext();
        public IActionResult Index()
        {
            var doctor = dbcontext.Doctors.ToList();
            return View(model: doctor);
        }
        public IActionResult DoctorBooking(int Doctorid)
        {
            if (Doctorid != null)
            {
                var DoctorBooking = dbcontext.Doctors.Find(Doctorid);
                return View(model: DoctorBooking);
            }
            else
            {
                return RedirectToAction(nameof(NotFoundPage));
            }
        }

        public IActionResult Savenew(string patientName, string appointmentDate, string appointmentTime, string drname)
        {
            if (DateTime.TryParse(appointmentDate, out DateTime date) && TimeSpan.TryParse(appointmentTime, out TimeSpan time))
            {
                Patient appointment = new Patient
                {
                    PatientName = patientName,    
                    AppointmentDate = date,       
                    AppointmentTime = time,        
                    DoctorName = drname         
                };
                dbcontext.patients.Add(appointment);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult History()
        {
           var appointment= dbcontext.patients.ToList();
            return View(model:appointment);
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
