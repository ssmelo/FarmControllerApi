using FarmController.Application.InputObjects;
using FarmController.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FarmController.Api.Controllers
{
    [Route("api/[controller]")]
    public class MilkController : ControllerBase
    {
        private readonly IMilkService _milkService;

        public MilkController(IMilkService milkService)
        {
            _milkService = milkService;
        }

        [HttpPost("temperature-set-point")]
        public async Task<IActionResult> SetTemperatureSetPoint([FromBody] SetMilkTemperatureInputObject inputObject)
        {
            await _milkService.SetTemperatureSetPoint(inputObject);
            return Ok();
        }
    }
}
