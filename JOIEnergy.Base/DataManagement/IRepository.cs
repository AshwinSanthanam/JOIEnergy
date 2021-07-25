using JOIEnergy.Base.Entities;
using JOIEnergy.Base.TransientEntities.cs;
using System.Collections.Generic;

namespace JOIEnergy.Base.DataManagement
{
    public interface IRepository
    {
        MeterReading GetMeterReading(string meterId);

        MeterReading InsertMeterReading(TransientMeterReading transientMeterReading);

        MeterReading UpdateMeterReading(string meterReadingId, TransientMeterReading transientMeterReading);

        IEnumerable<PricePlan> PricePlans { get; }

        PricePlan InsertPricePlan(TransientPricePlan transientPricePlan);
    }
}
