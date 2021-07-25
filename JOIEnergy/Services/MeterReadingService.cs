using System.Collections.Generic;
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

        public List<ElectricityReading> GetReadings(string smartMeterId) {
            MeterReading meterReading = _repository.GetMeterReading(smartMeterId);
            return meterReading?.ElectricityReadings ?? new List<ElectricityReading>();
        }

        public void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings) {
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
                meterReading.ElectricityReadings.AddRange(electricityReadings);
                _repository.UpdateMeterReading(new MeterReading
                {
                    ElectricityReadings = meterReading.ElectricityReadings,
                    Id = smartMeterId
                });
            }
        }

    }
}
