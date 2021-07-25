using JOIEnergy.Base.Entities;
using JOIEnergy.Base.Enums;
using System.Collections.Generic;

namespace JOIEnergy.Base.TransientEntities.cs
{
    public class TransientPricePlan
    {
        public Supplier EnergySupplier { get; set; }
        public decimal UnitRate { get; set; }
        public IList<PeakTimeMultiplier> PeakTimeMultiplier { get; set; }
    }
}
