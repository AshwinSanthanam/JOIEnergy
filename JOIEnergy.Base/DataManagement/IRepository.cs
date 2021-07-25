using JOIEnergy.Base.Entities;
using System.Collections.Generic;

namespace JOIEnergy.Base.DataManagement
{
    public interface IRepository
    {
        MeterReadings GetMeterReading(string meterId);

        IEnumerable<PricePlan> PricePlans { get; }
    }
}
