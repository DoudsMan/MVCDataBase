using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using databaseAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments
        public ActionResult Index()
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var appointments = new databaseAPI.Controllers.AppointmentsController(dbcontext).GetAppointment();

            return View(appointments.Result.Value);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int id)
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var appointments = new databaseAPI.Controllers.AppointmentsController(dbcontext).GetAppointment(id);
            appointments.Wait();
            return View(appointments.Result.Value);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            var dbContext = new databaseAPI.Model.DBcsc484Context();
            var createViewModel = new databaseAPI.Model.AppointmentsViewModel();
            var DoctorViewModel = new databaseAPI.Controllers.DoctorsController(dbContext).GetDoctor();
            DoctorViewModel.Wait();
            var patients = new databaseAPI.Controllers.PatientsController(dbContext).GetPatient();
            patients.Wait();
            createViewModel.DoctorViewModel = new SelectList(DoctorViewModel.Result.Value, "DoctorId", "DoctorName");
            createViewModel.PatientViewModel = new SelectList(patients.Result.Value, "PatientId", "PatientName");


            return View(createViewModel);
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var context = new databaseAPI.Model.Appointment();

            // get values from the form
            context.AppointmentDate = Convert.ToString(collection["AppointmentViewModel.AppointmentDate"]);
            context.AppointmentId = Convert.ToInt32(collection["AppointmentViewModel.AppointmentId"]);
            context.AppointmentNotes = Convert.ToString(collection["AppointmentViewModel.AppointmentNotes"]);
            context.AppointmentTime = Convert.ToString(collection["AppointmentViewModel.AppointmentTime"]);
            context.DoctorId = Convert.ToString(collection["AppointmentViewModel.DoctorId"]);
            context.RoomNumber = Convert.ToString(collection["AppointmentViewModel.RoomNumber"]);
            context.PatientId = Convert.ToString(collection["AppointmentViewModel.PatientId"]);


            try
            {
                // TODO: Add insert logic here
                var dbcontext = new databaseAPI.Model.DBcsc484Context();
                var appointments = new databaseAPI.Controllers.AppointmentsController(dbcontext).PostAppointment(context);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int id)
        {
            var dbContext = new databaseAPI.Model.DBcsc484Context();
            var createViewModel = new databaseAPI.Model.AppointmentsViewModel();
            var DoctorViewModel = new databaseAPI.Controllers.DoctorsController(dbContext).GetDoctor();
            DoctorViewModel.Wait();
            var patients = new databaseAPI.Controllers.PatientsController(dbContext).GetPatient();
            patients.Wait();
            createViewModel.DoctorViewModel = new SelectList(DoctorViewModel.Result.Value, "DoctorId", "DoctorName");
            createViewModel.PatientViewModel = new SelectList(patients.Result.Value, "PatientId", "PatientName");


            return View(createViewModel);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var context = new databaseAPI.Model.Appointment();

            // get values from the form
            context.AppointmentDate = Convert.ToString(collection["AppointmentViewModel.AppointmentDate"]);
            context.AppointmentId = id;
            context.AppointmentNotes = Convert.ToString(collection["AppointmentViewModel.AppointmentNotes"]);
            context.AppointmentTime = Convert.ToString(collection["AppointmentViewModel.AppointmentTime"]);
            context.DoctorId = Convert.ToString(collection["AppointmentViewModel.DoctorId"]);
            context.RoomNumber = Convert.ToString(collection["AppointmentViewModel.RoomNumber"]);
            context.PatientId = Convert.ToString(collection["AppointmentViewModel.PatientId"]);


            try
            {
                // TODO: Add update logic here
                var dbcontext = new databaseAPI.Model.DBcsc484Context();
                var appointments = new databaseAPI.Controllers.AppointmentsController(dbcontext).PutAppointment(id,context);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int id)
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var appointment = new databaseAPI.Controllers.AppointmentsController(dbcontext).GetAppointment(id);
            appointment.Wait();

            var appointmentvm = new AppointmentsViewModel();
            //assign all appointments to vm
            appointmentvm.AppointmentViewModel = appointment.Result.Value;
            //get doctor with matching appointment doctor id
            var doctor = new databaseAPI.Controllers.DoctorsController(dbcontext).GetDoctor().Result.Value.Where(x=>x.DoctorId == appointment.Result.Value.DoctorId);
            //get patient with matching appointment patient id
            var patient = new databaseAPI.Controllers.PatientsController(dbcontext).GetPatient().Result.Value.Where(x => x.PatientId == appointment.Result.Value.PatientId);


            //assign doctor/patient to vm so their attributes can be accessed
            appointmentvm.deleteDoctor = doctor.FirstOrDefault();
            appointmentvm.deletePatient = patient.FirstOrDefault();

            return View(appointmentvm);

        }

        // POST: Appointments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dbContext = new databaseAPI.Model.DBcsc484Context();
                var patientController = new databaseAPI.Controllers.AppointmentsController(dbContext).DeleteAppointment(id);
                patientController.Wait();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}