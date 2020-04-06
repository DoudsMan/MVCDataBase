using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult Index()
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var patients = new databaseAPI.Controllers.PatientsController(dbcontext).GetPatient();
            patients.Wait();

            return View(patients.Result.Value);
        }

        // GET: Patients/Details/5
        public ActionResult Details(string id)
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var patient = new databaseAPI.Controllers.PatientsController(dbcontext).GetPatient(id);
            patient.Wait();

            return View(patient.Result.Value);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            var dbContext = new databaseAPI.Model.DBcsc484Context();
            var createView = new databaseAPI.Model.PatientView();
            var doctors = new databaseAPI.Controllers.DoctorsController(dbContext).GetDoctor();
            doctors.Wait();
            createView.Doctors = new SelectList(doctors.Result.Value, "DoctorId", "DoctorName");
            createView.Patient = new databaseAPI.Model.Patient();

            return View(createView);
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            //create new patient model
            var newPatient = new databaseAPI.Model.Patient();

            //assign values from form
            newPatient.PatientId = Convert.ToString(collection["Patient.PatientID"]);
            newPatient.DoctorId = Convert.ToString(collection["Patient.DoctorID"]);
            newPatient.PatientName = Convert.ToString(collection["Patient.PatientName"]);
            newPatient.RoomNumber = Convert.ToString(collection["Patient.RoomNumber"]);
            newPatient.Age = Convert.ToInt32(collection["Patient.Age"]);
            newPatient.Condition = Convert.ToString(collection["Patient.Condition"]);


            try
            {
                var dbContext = new databaseAPI.Model.DBcsc484Context();
                var patientController = new databaseAPI.Controllers.PatientsController(dbContext).PostPatient(newPatient);
                patientController.Wait();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(string id)
        {
            var dbContext = new databaseAPI.Model.DBcsc484Context();
            var createView = new databaseAPI.Model.PatientView();
            var doctors = new databaseAPI.Controllers.DoctorsController(dbContext).GetDoctor();
            doctors.Wait();
            createView.Doctors = new SelectList(doctors.Result.Value, "DoctorId", "DoctorName");

            return View(createView);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            //create new patient model
            var newPatient = new databaseAPI.Model.Patient();

            //assign values from form
            newPatient.PatientId = id;
            newPatient.DoctorId = Convert.ToString(collection["Patient.DoctorID"]);
            newPatient.PatientName = Convert.ToString(collection["Patient.PatientName"]);
            newPatient.RoomNumber = Convert.ToString(collection["Patient.RoomNumber"]);
            newPatient.Age = Convert.ToInt32(collection["Patient.Age"]);
            newPatient.Condition = Convert.ToString(collection["Patient.Condition"]);


            try
            {
                var dbContext = new databaseAPI.Model.DBcsc484Context();
                var patientController = new databaseAPI.Controllers.PatientsController(dbContext).PutPatient(id, newPatient);
                patientController.Wait();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(string id)
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var patient = new databaseAPI.Controllers.PatientsController(dbcontext).GetPatient(id);
            patient.Wait();

            return View(patient.Result.Value);
        }

        // POST: Patients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {


            try
            {
                var dbContext = new databaseAPI.Model.DBcsc484Context();
                var patientController = new databaseAPI.Controllers.PatientsController(dbContext).DeletePatient(id);
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