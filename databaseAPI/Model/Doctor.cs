using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseAPI.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointment = new HashSet<Appointment>();
            Patient = new HashSet<Patient>();
        }

        [Key]
        [Column("doctorID")]
        [StringLength(7)]
        public string DoctorId { get; set; }
        [Required]
        [Column("doctor_name")]
        [StringLength(20)]
        public string DoctorName { get; set; }
        [Column("specialty")]
        [StringLength(50)]
        public string Specialty { get; set; }
        [Column("department")]
        [StringLength(15)]
        public string Department { get; set; }

        [InverseProperty("Doctor")]
        public virtual ICollection<Appointment> Appointment { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
