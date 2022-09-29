using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class LoginUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? EmailId { get; set; }

        [Required]
        public string? Password { get; set; }


    }
}
