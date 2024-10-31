using Microsoft.AspNetCore.Mvc;
using Robbochinni.Driver.Business.Operations;
using Robbochinni.Driver.Mag.Edition;
using Robbochinni.Driver.Mag.Input;

namespace Robbochinni.Driver.API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarManager _carManager;
        public CarController(CarManager carManager)
        {
            _carManager = carManager;
        }

        [HttpPost]
        //[EnableCors("allowAll")]
        public async Task<IActionResult> Add(AddNewCar addCar)
        {
            var result = await _carManager.Add(addCar);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("newride/{Id}")]
        public async Task<IActionResult> UpdateCarLocation(EditCarLocAndType updateCar, Guid Id)
        {
            var result = await _carManager.SetLocation(updateCar, Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carManager.GetAll();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("nearest/{longt}/{lat}")]
        public async Task<IActionResult> GetNearest(decimal lat, decimal longt)
        {
            var result = await _carManager.GetNearest(new Mag.Input.CarByLocation(lat, longt));
            return StatusCode(result.StatusCode, result);
        }
    }
}
