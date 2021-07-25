using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using JOIEnergy.Base.TransientEntities.cs;
using System;
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
            if (string.IsNullOrEmpty(meterId))
            {
                return null;
            }
            _meterAssociatedReadings.TryGetValue(meterId, out MeterReading meterReading);
            return meterReading;
        }

        public MeterReading InsertMeterReading(TransientMeterReading transientMeterReading)
        {
            MeterReading meterReading = new MeterReading
            {
                ElectricityReadings = transientMeterReading.ElectricityReadings,
                Id = Guid.NewGuid().ToString()
            };
            _meterAssociatedReadings.Add(meterReading.Id, meterReading);
            return meterReading;
        }

        public MeterReading UpdateMeterReading(string meterReadingId, TransientMeterReading transientMeterReading)
        {
            MeterReading meterReadingToUpdate = _meterAssociatedReadings[meterReadingId];
            meterReadingToUpdate.ElectricityReadings = transientMeterReading.ElectricityReadings;
            return meterReadingToUpdate;
        }
    }
}
