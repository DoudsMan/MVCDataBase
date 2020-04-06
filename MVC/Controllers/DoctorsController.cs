using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class DoctorsController : Controller
    {
        // GET: Doctors
        public ActionResult Index()
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var doctors = new databaseAPI.Controllers.DoctorsController(dbcontext).GetDoctor();
            doctors.Wait();

            return View(doctors.Result.Value);
        }

        // GET: Doctors/Details/5
        public ActionResult Details(string id)
        {
            var dbcontext = new databaseAPI.Model.DBcsc484Context();
            var doctor = new databaseAPI.Controllers.DoctorsController(dbcontext).GetDoctor(id);
            doctor.Wait();

            return View(doctor.Result.Value);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {

            //create new doctor model
            var newDoctor = new databaseAPI.Model.Doctor();

            //assign values from form
            newDoctor.DoctorId = Convert.ToString(collection["DoctorId"]);
            newDoctor.DoctorName = Convert.ToString(collection["DoctorName"]);
            newDoctor.Specialty = Convert.ToString(collection["Specialty"]);
            newDoctor.Department = Convert.ToString(collection["Department"]);

            try
            {
                var dbContext = new databaseAPI.Model.DBcsc484Context();
                var patientController = new databaseAPI.Controllers.DoctorsController(dbContext).PostDoctor(newDoctor);
                patientController.Wait();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {

            //create new doctor model
            var newDoctor = new databaseAPI.Model.Doctor();

            //assign values from form
            newDoctor.DoctorId = id;
            newDoctor.DoctorName = Convert.ToString(collection["DoctorName"]);
            newDoctor.Specialty = Convert.ToString(collection["Specialty"]);
            newDoctor.Department = Convert.ToString(collection["Department"]);

            try
            {
                var dbContext = new databaseAPI.Model.DBcsc484Context();
                var doctorController = new databaseAPI.Controllers.DoctorsController(dbContext).PutDoctor(id, newDoctor);
                doctorController.Wait();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(string id)
        {
            var dbContext = new databaseAPI.Model.DBcsc484Context();
            var doctor = new databaseAPI.Controllers.DoctorsController(dbContext).GetDoctor(id);
            doctor.Wait();

            return View(doctor.Result.Value);
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var dbContext = new databaseAPI.Model.DBcsc484Context();
                var doctorController = new databaseAPI.Controllers.DoctorsController(dbContext).DeleteDoctor(id);
                doctorController.Wait();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}