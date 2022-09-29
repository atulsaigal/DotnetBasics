using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class MedicineReg
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        public string? MedicineName { get; set; }

        [Required]
        public string? MedicineManufacturer { get; set; }

        [Required]
        public int MedicinePrice { get; set; }

        [Required]
        public string? MedicineExpiryDate { get; set; }

        [Required]
        public int ?MedicineStock { get; set; }


    }
}
