using JOIEnergy.Base.Entities;
using JOIEnergy.Base.Enums;
using System;
using System.Collections.Generic;

namespace JOIEnergy.DataAccess.DataManagement
{
    public class DbContext
    {
        public Dictionary<string, MeterReading> MeterAssociatedReadings { get; }
        public Dictionary<string, PricePlan> PricePlans { get; }

        public DbContext(bool seed = true)
        {
            MeterAssociatedReadings = new Dictionary<string, MeterReading>();
            PricePlans = new Dictionary<string, PricePlan>();

            if (seed)
            {
                SeedPricePlans();
            }
        }

        private void SeedPricePlans()
        {
            var pricePlans = new List<PricePlan> {
                new PricePlan {
                    Id = Guid.NewGuid().ToString(),
                    EnergySupplier = Supplier.DrEvilsDarkEnergy,
                    UnitRate = 10m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan {
                    Id = Guid.NewGuid().ToString(),
                    EnergySupplier = Supplier.TheGreenEco,
                    UnitRate = 2m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                },
                new PricePlan {
                    Id = Guid.NewGuid().ToString(),
                    EnergySupplier = Supplier.PowerForEveryone,
                    UnitRate = 1m,
                    PeakTimeMultiplier = new List<PeakTimeMultiplier>()
                }
            };

            pricePlans.ForEach(x => PricePlans.Add(x.Id, x));
        }
    }
}
