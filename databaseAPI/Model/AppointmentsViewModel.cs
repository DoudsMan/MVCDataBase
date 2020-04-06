using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace databaseAPI.Model
{
    public class AppointmentsViewModel
    {
        public SelectList DoctorViewModel { get; set; }
        public SelectList PatientViewModel { get; set; }
        public Appointment AppointmentViewModel { get; set; }
        public Doctor deleteDoctor { get; set; }
        public Patient deletePatient { get; set; }
    }
}
