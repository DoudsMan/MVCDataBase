using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseAPI.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
        }

        [Key]
        [Column("patientID")]
        [StringLength(7)]
        public string PatientId { get; set; }
        [Required]
        [Column("doctorID")]
        [StringLength(7)]
        public string DoctorId { get; set; }
        [Required]
        [Column("patient_name")]
        [StringLength(20)]
        public string PatientName { get; set; }
        [Column("room_number")]
        [StringLength(4)]
        public string RoomNumber { get; set; }
        [Column("age", TypeName = "numeric(3, 0)")]
        public decimal Age { get; set; }
        [Column("condition")]
        [StringLength(50)]
        public string Condition { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty("Patient")]
        public virtual Doctor Doctor { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
