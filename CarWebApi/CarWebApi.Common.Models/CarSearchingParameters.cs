using CarWebApi.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.Common.Models
{
    public class CarSearchingParameters
    {
        public string? CarName { get; set; }

        public string? Carmodel { get; set; }
        public string? CarManufacture { get; set; }

        public CarColor? CarColor { get; set; }

        public string? CarLaunchDate { get; set; }

    }
}
