using CarWebApi.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._4_DataAccess.Entity
{
    public class CarEntity
    {
        public int? CarId { get; set; }

        public string? CarName { get; set; }

        public string? Carmodel { get; set; }
        public string? CarManufacture { get; set; }

        public short? CarColor { get; set; }

        public string? CarLaunchDate { get; set; }

    }
}
