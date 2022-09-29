using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Models
{
    public class PrescriptionData
    {



        [ForeignKey("PatientRegisteration")]
        public int PatientId { get; set; }

        [Required]
        public string? MedicineName { get; set; }
        [Required]
        public int? Quantity { get; set; }
    }
}
