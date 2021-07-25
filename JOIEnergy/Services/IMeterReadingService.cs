using System.Collections.Generic;
using JOIEnergy.Base.Entities;

namespace JOIEnergy.Services
{
    public interface IMeterReadingService
    {
        IEnumerable<ElectricityReading> GetReadings(string smartMeterId);
        void StoreReadings(string smartMeterId, IEnumerable<ElectricityReading> electricityReadings);
    }
}