using CarWebApi.Common.Models;
using CarWebApi.WebApp._2_Services.ServicesInterface;
using CarWebApi.WebApp._3_BusinessLogic.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._2_Services.ServiceLogic
{
    public class ServiceClass : CarServicesInterface
    {
        private CarBusinessInterface _carBusinessInterface;

        public ServiceClass(CarBusinessInterface _carBusinessInterface)
        {
            this._carBusinessInterface = _carBusinessInterface;
        }

        public async Task<bool> CarSaveAsync(CarModel car)
        {
            return await this._carBusinessInterface.CarSaveAsync(car);
        }

        public async Task<List<CarModel>> CarSearchAsync(CarSearchingParameters carSearchingParameters)
        {
            return await this._carBusinessInterface.CarSearchAsync(carSearchingParameters); 

        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            return await this._carBusinessInterface.DeleteCarAsync(id);
        }

        public async Task<bool> UpdateCarAsync(CarModel car, int id)
        {
            return await this._carBusinessInterface.UpdateCarAsync(car,id);

        }
    }
}
