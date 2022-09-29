using CarWebApi.Common.Models;
using CarWebApi.WebApp._2_Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.WebApp._1_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/SearchCar")]

    public class CarController : Controller
    {
        private CarServicesInterface _carServiceInterface;

        public CarController (CarServicesInterface _carServiceInterface)
        {
            this._carServiceInterface = _carServiceInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CarModel>))]

        public async Task<IActionResult> Get(CarSearchingParameters carSearchingParameters)
        {
            var car = await this._carServiceInterface.CarSearchAsync(carSearchingParameters);
            if (car == null || !car.Any())
            {
                return NotFound();
            }
            return Json(car);
        }

        [HttpPost]
        [ProducesResponseType(200, Type=typeof(List<CarModel>))]

        public async Task<IActionResult> Post([FromBody] CarModel car)
        {
            if(await _carServiceInterface.CarSaveAsync(car))
            {
                return Ok();
            }
            else
            {
                return BadRequest("unable to insert");
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(List<CarModel>))]
        public async Task<IActionResult> UpdateBook([FromBody] CarModel car, [FromRoute] int id)
        {
            if (await _carServiceInterface.UpdateCarAsync(car, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Wrong Input");
            }
        }



        [HttpDelete("delete/{id}")]
        [ProducesResponseType(200, Type = typeof(List<CarModel>))]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _carServiceInterface.DeleteCarAsync(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to Delete Data");
            }

        }






    }
}
