using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using System.Collections.Generic;

namespace JOIEnergy.DataAccess.DataManagement
{
    public class InMemoryRepository : IRepository
    {
        private readonly List<PricePlan> _pricePlans;
        private Dictionary<string, MeterReadings> _meterAssociatedReadings;

        public InMemoryRepository()
        {
            _pricePlans = new List<PricePlan>();
            _meterAssociatedReadings = new Dictionary<string, MeterReadings>();
        }

        public MeterReadings GetMeterReading(string meterId)
        {
            _meterAssociatedReadings.TryGetValue(meterId, out MeterReadings meterReading);
            return meterReading;
        }

        public MeterReadings InsertMeterReading(MeterReadings meterReading)
        {
            _meterAssociatedReadings.Add(meterReading.SmartMeterId, meterReading);
            return meterReading;
        }

        public MeterReadings UpdateMeterReading(MeterReadings meterReading)
        {
            MeterReadings meterReadingToUpdate = _meterAssociatedReadings[meterReading.SmartMeterId];
            meterReadingToUpdate.ElectricityReadings = meterReading.ElectricityReadings;
            return meterReadingToUpdate;
        }
    }
}
