using CarWebApi.Common.Enums;
using CarWebApi.Common.Models;
using CarWebApi.WebApp._4_DataAccess.Entity;
using CarWebApi.WebApp._4_DataAccess.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._4_DataAccess.Repository
{
    public class CarRepository:BaseRepository,CarRepositoryInterface
    {
        public CarRepository(Context _context) : base(_context) { }

        public async Task<bool> CarSaveAsync(CarModel car)
        {
            var CarObj = _context.CarDBset.Find(car.CarId);
            if (CarObj == null)
            {
                CarObj = new CarEntity();
                _context.Add(CarObj);
            }
            CarObj.CarColor = (short)car.CarColor;
            CarObj.CarName = car.CarName;
            CarObj.Carmodel = car.Carmodel;
            CarObj.CarManufacture = car.CarManufacture;
            CarObj.CarLaunchDate = car.CarLaunchDate;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<CarModel>> CarSearchAsync(CarSearchingParameters carSearchingParameters)
        {
            IQueryable<CarEntity>? CarQuery=(IQueryable<CarEntity>)_context.CarDBset.AsQueryable();

            return await CarQuery.Select(m => new CarModel
            {
                CarId=m.CarId,
                CarName=m.CarName,
                Carmodel=m.Carmodel,
                CarManufacture=m.CarManufacture,
                CarColor=(CarColor?)(short)m.CarColor,
                CarLaunchDate=m.CarLaunchDate

            }).ToListAsync();
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            CarEntity ObjCar = new CarEntity() { CarId = id };
            _context.Remove(ObjCar);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCarAsync(CarModel car, int id)
        {
            var carObj = new CarEntity()
            {
                CarId = id,
                CarColor = (short?)car.CarColor,
                CarName = car.CarName,
                Carmodel = car.Carmodel,
                CarManufacture = car.CarManufacture,
                CarLaunchDate = car.CarLaunchDate
            };
            _context.Update(carObj);
            return await _context.SaveChangesAsync() > 0;
        }



    }
}
