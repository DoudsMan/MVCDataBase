using Microsoft.AspNetCore.Mvc.Rendering;
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
    }
}
