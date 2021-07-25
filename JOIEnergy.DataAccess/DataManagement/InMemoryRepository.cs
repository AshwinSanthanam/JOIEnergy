using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using System.Collections.Generic;

namespace JOIEnergy.DataAccess.DataManagement
{
    public class InMemoryRepository : IRepository
    {
        private readonly List<PricePlan> _pricePlans;
        private Dictionary<string, MeterReading> _meterAssociatedReadings;

        public InMemoryRepository()
        {
            _pricePlans = new List<PricePlan>();
            _meterAssociatedReadings = new Dictionary<string, MeterReading>();
        }

        public MeterReading GetMeterReading(string meterId)
        {
            _meterAssociatedReadings.TryGetValue(meterId, out MeterReading meterReading);
            return meterReading;
        }

        public MeterReading InsertMeterReading(MeterReading meterReading)
        {
            _meterAssociatedReadings.Add(meterReading.Id, meterReading);
            return meterReading;
        }

        public MeterReading UpdateMeterReading(MeterReading meterReading)
        {
            MeterReading meterReadingToUpdate = _meterAssociatedReadings[meterReading.Id];
            meterReadingToUpdate.ElectricityReadings = meterReading.ElectricityReadings;
            return meterReadingToUpdate;
        }
    }
}
