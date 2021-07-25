using System.Collections.Generic;

namespace JOIEnergy.Base.Entities
{
    public class MeterReading
    {
        public string Id { get; set; }
        public List<ElectricityReading> ElectricityReadings { get; set; }
    }
}
