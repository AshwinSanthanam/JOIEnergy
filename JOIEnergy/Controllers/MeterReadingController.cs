using JOIEnergy.Base.Entities;
using JOIEnergy.Base.Validators;
using JOIEnergy.Services;
using Microsoft.AspNetCore.Mvc;

namespace JOIEnergy.Controllers
{
    [Route("readings")]
    public class MeterReadingController : Controller
    {
        private readonly IMeterReadingService _meterReadingService;

        public MeterReadingController(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        [HttpPost]
        public ObjectResult CreateMeterReading([FromBody]MeterReading meterReadings)
        {
            try
            {
                var insertedMeterReading = _meterReadingService.StoreReadings(meterReadings.Id, meterReadings.ElectricityReadings);
                return new OkObjectResult(insertedMeterReading);
            }
            catch (DataIntegrityException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{meterReadingId}")]
        public ObjectResult GetMeterReading(string meterReadingId) {
            return new OkObjectResult(_meterReadingService.GetReadings(meterReadingId));
        }
    }
}
