namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; } // Primary Key
        public string PatientName { get; set; } // Patient's Name
        public DateTime AppointmentDate { get; set; } // Appointment Date
        public TimeSpan AppointmentTime { get; set; } // Appointment Time
        public string DoctorName { get; set; }
    }
}
