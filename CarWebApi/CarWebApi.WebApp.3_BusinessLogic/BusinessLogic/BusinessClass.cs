using CarWebApi.Common.Models;
using CarWebApi.WebApp._3_BusinessLogic.BusinessInterface;
using CarWebApi.WebApp._4_DataAccess.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._3_BusinessLogic.BusinessLogic
{
    public class BusinessClass : CarBusinessInterface
    {
        private CarRepositoryInterface _carRespositoryInterface;

        public BusinessClass(CarRepositoryInterface _carRespositoryInterface)
        {
          this._carRespositoryInterface = _carRespositoryInterface;
        }

        public async Task<bool> CarSaveAsync(CarModel car)
        {
            return await this._carRespositoryInterface.CarSaveAsync(car);
        }

        public async Task<List<CarModel>> CarSearchAsync(CarSearchingParameters carSearchingParameters)
        {
            return await this._carRespositoryInterface.CarSearchAsync(carSearchingParameters);
        }


        public async Task<bool> DeleteCarAsync(int id)
        {
            return await _carRespositoryInterface.DeleteCarAsync(id);
        }

        public async Task<bool> UpdateCarAsync(CarModel car, int id)
        {
            return await this._carRespositoryInterface.UpdateCarAsync(car,id);

        }
    }
}
