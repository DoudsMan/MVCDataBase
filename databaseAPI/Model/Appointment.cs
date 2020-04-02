using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databaseAPI.Model
{
    public partial class Appointment
    {
        [Key]
        [Column("appointmentID")]
        public int AppointmentId { get; set; }
        [Required]
        [Column("room_number")]
        [StringLength(4)]
        public string RoomNumber { get; set; }
        [Required]
        [Column("appointment_date")]
        [StringLength(20)]
        public string AppointmentDate { get; set; }
        [Required]
        [Column("appointment_time")]
        [StringLength(20)]
        public string AppointmentTime { get; set; }
        [Column("appointment_notes")]
        [StringLength(200)]
        public string AppointmentNotes { get; set; }
        [Required]
        [Column("doctorID")]
        [StringLength(7)]
        public string DoctorId { get; set; }
        [Required]
        [Column("patientID")]
        [StringLength(7)]
        public string PatientId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty("Appointment")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Appointment")]
        public virtual Patient Patient { get; set; }
    }
}
