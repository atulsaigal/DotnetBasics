﻿using CarWebApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._3_BusinessLogic.BusinessInterface
{
    public interface CarBusinessInterface
    {
        Task<List<CarModel>> CarSearchAsync(CarSearchingParameters carSearchingParameters);
        Task<bool> CarSaveAsync(CarModel car);
        Task<bool> UpdateCarAsync(CarModel car, int id);

        Task<bool> DeleteCarAsync(int id);
        
    }
}
