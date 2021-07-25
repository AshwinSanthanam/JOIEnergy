using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using System;
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

        public MeterReadings InsertMeterReading(MeterReadings meterReadings)
        {
            _meterAssociatedReadings.Add(meterReadings.SmartMeterId, meterReadings);
            return meterReadings;
        }

        public IEnumerable<PricePlan> PricePlans => throw new NotImplementedException();

        public MeterReadings GetMeterReading(string meterId)
        {
            _meterAssociatedReadings.TryGetValue(meterId, out MeterReadings meterReadings);
            return meterReadings;
        }
    }
}
