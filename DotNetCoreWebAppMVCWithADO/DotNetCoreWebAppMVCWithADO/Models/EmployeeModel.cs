using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebAppMVCWithADO.Models
{
    public class EmployeeModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string City { get; set; }
    }
}
