using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;

namespace JOIEnergy.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        private readonly IRepository _repository;

        public MeterReadingService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ElectricityReading> GetReadings(string smartMeterId) {
            MeterReading meterReading = _repository.GetMeterReading(smartMeterId);
            return meterReading?.ElectricityReadings ?? Enumerable.Empty<ElectricityReading>();
        }

        public void StoreReadings(string smartMeterId, IEnumerable<ElectricityReading> electricityReadings) {
            MeterReading meterReading = _repository.GetMeterReading(smartMeterId);
            if (meterReading == null) 
            {
                _repository.InsertMeterReading(new MeterReading
                {
                    ElectricityReadings = electricityReadings,
                    Id = smartMeterId
                });
            }
            else
            {
                _repository.UpdateMeterReading(new MeterReading
                {
                    ElectricityReadings = meterReading.ElectricityReadings.Concat(electricityReadings),
                    Id = smartMeterId
                });
            }
        }

    }
}
