using CarWebApi.Common.Enums;

namespace CarWebApi.Common.Models
{
    public class CarModel
    {
        public int? CarId { get; set; }
        
        public string? CarName { get; set; }

        public string? Carmodel { get; set; }
        public string? CarManufacture { get; set; }

        public CarColor? CarColor { get; set; }

        public string? CarLaunchDate { get; set; }

    }
}