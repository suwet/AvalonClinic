using System;

namespace Avalon.Clinic.Models
{
    public class RegisterPatientModel
    {
        public int Id { get; set; }
        public string? IDCard { get; set; }
        public string?  Sex { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BloodGroupId { get; set; }
        public string? CongenitalDisease { get; set; } // โรคประจำตัว
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? MobliePhone { get; set; }
        public string? Nationality { get; set; }
        public string? Ocipation { get; set; }
        public string? Email { get; set; }
        public string? ChronicDisease { get; set; } // กลุ่มโรคเรื้อรัง
        public int Age { get; set; }
        public string? Remark { get; set; }
    }
}
