using JOIEnergy.Base.Entities;
using System.Collections.Generic;

namespace JOIEnergy.Base.TransientEntities.cs
{
    public class TransientMeterReading
    {
        public IEnumerable<ElectricityReading> ElectricityReadings { get; set; }
    }
}
