using Microsoft.AspNetCore.Mvc;
using Robbochinni.Driver.Business.Operations;
using Robbochinni.Driver.Mag.Edition;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Statics;

namespace Robbochinni.Driver.API.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripManager _tripManager;

        public TripController(TripManager tripManager)
        {
            _tripManager = tripManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRequest request)
        { 
            var result = await _tripManager.Add(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{state}")]
        public async Task<IActionResult> Get(int state)
        {
            var result = await _tripManager.GetAll(state);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("byuser/{state}/Id/{Id}")]
        public async Task<IActionResult> GetByUser(int state, Guid Id)
        {
            var result = await _tripManager.GetByClient(state, Id, false);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("bydriver/{state}/Id/{Id}")]
        public async Task<IActionResult> GetByDriver(int state, Guid Id)
        {
            var result = await _tripManager.GetByClient(state, Id, true);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("confrimed/{Id}")]
        public async Task<IActionResult> UpdateToConfirmed(ConfirmTrip confirm, Guid Id)
        {
            var result = await _tripManager.EditTo(new EditToConfirmed(confirm.Driver), Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("arrived/{Id}")]
        public async Task<IActionResult> UpdateToArrived(ArriveTrip arrive, Guid Id)
        {
            var result = await _tripManager.EditTo(new EditToArrived(arrive.Code!.EncryptSHA256()), Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("cancelled/{Id}")]
        public async Task<IActionResult> UpdateToCancelled(Guid Id)
        {
            var result = await _tripManager.EditTo(new EditToCancelled(), Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("finished/{Id}")]
        public async Task<IActionResult> UpdateToFinished(Guid Id)
        {
            var result = await _tripManager.EditTo(new EditToFinished(), Id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
