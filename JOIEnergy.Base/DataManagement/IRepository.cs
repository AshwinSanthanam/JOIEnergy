using JOIEnergy.Base.Entities;
using System.Collections.Generic;

namespace JOIEnergy.Base.DataManagement
{
    public interface IRepository
    {
        MeterReading GetMeterReading(string meterId);

        IEnumerable<PricePlan> PricePlans { get; }

        MeterReadingPricePlanAccount GetMeterReadingPricePlanAccount(string meterReadingId);
    }
}
