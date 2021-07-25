using System;
using System.Collections.Generic;
using JOIEnergy.Services;
using Xunit;
using JOIEnergy.Base.Entities;
using JOIEnergy.DataAccess.DataManagement;
using System.Linq;
using JOIEnergy.DataAccess;

namespace JOIEnergy.Tests
{
    public class MeterReadingServiceTest
    {
        private readonly string _meterReadingId;
        private readonly MeterReadingService _meterReadingService;

        public MeterReadingServiceTest()
        {
            var dbContext = new DbContext(seed: false);
            var repository = new InMemoryRepository(dbContext);
            var meterReadingValidator = new MeterReadingValidator();
            var transaction = new Transaction(dbContext, meterReadingValidator);
            _meterReadingService = new MeterReadingService(repository, transaction);

            MeterReading meterReading = _meterReadingService.StoreReadings(null, new List<ElectricityReading>() {
                new ElectricityReading() { Time = DateTime.Now.AddMinutes(-30), Reading = 35m },
                new ElectricityReading() { Time = DateTime.Now.AddMinutes(-15), Reading = 30m }
            });

            _meterReadingId = meterReading.Id;
        }

        [Fact]
        public void GivenMeterIdThatDoesNotExistShouldReturnNull() {
            Assert.Empty(_meterReadingService.GetReadings("unknown-id"));
        }

        [Fact]
        public void GivenMeterReadingThatExistsShouldReturnMeterReadings()
        {
            _meterReadingService.StoreReadings(_meterReadingId, new List<ElectricityReading>() {
                new ElectricityReading() { Time = DateTime.Now, Reading = 25m }
            });

            var electricityReadings = _meterReadingService.GetReadings(_meterReadingId);

            Assert.Equal(3, electricityReadings.Count());
        }

    }
}
