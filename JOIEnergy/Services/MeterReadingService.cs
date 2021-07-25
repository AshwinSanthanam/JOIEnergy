using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using JOIEnergy.Base.TransientEntities.cs;

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

        public MeterReading StoreReadings(string smartMeterId, IEnumerable<ElectricityReading> electricityReadings) {
            MeterReading meterReading = _repository.GetMeterReading(smartMeterId);
            if (meterReading == null) 
            {
                return _repository.InsertMeterReading(new TransientMeterReading
                {
                    ElectricityReadings = electricityReadings
                });
            }
            else
            {
                return _repository.UpdateMeterReading(smartMeterId, new TransientMeterReading
                {
                    ElectricityReadings = meterReading.ElectricityReadings.Concat(electricityReadings)
                });
            }
        }

    }
}
