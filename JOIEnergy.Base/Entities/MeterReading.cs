using System.Collections.Generic;

namespace JOIEnergy.Base.Entities
{
    public class MeterReading
    {
        public string Id { get; set; }
        public IEnumerable<ElectricityReading> ElectricityReadings { get; set; }
    }
}
