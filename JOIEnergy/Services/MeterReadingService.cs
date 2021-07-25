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
            MeterReadings meterReading = _repository.GetMeterReading(smartMeterId);
            return meterReading?.ElectricityReadings ?? new List<ElectricityReading>();
        }

        public void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings) {
            MeterReadings meterReading = _repository.GetMeterReading(smartMeterId);
            if (meterReading == null) 
            {
                _repository.InsertMeterReading(new MeterReadings
                {
                    ElectricityReadings = electricityReadings,
                    SmartMeterId = smartMeterId
                });
            }
            else
            {
                meterReading.ElectricityReadings.AddRange(electricityReadings);
                _repository.UpdateMeterReading(new MeterReadings
                {
                    ElectricityReadings = meterReading.ElectricityReadings,
                    SmartMeterId = smartMeterId
                });
            }
        }

    }
}
