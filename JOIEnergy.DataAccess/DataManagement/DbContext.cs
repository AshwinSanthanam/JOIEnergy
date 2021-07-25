using JOIEnergy.Base.Entities;
using JOIEnergy.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JOIEnergy.DataAccess.DataManagement
{
    public class DbContext
    {
        public Dictionary<string, MeterReading> MeterReadings { get; }
        public Dictionary<string, PricePlan> PricePlans { get; }

        public DbContext(bool seed = true)
        {
            MeterReadings = new Dictionary<string, MeterReading>();
            PricePlans = new Dictionary<string, PricePlan>();

            if (seed)
            {
                SeedPricePlans();

                SeedMeterReading();
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

        private void SeedMeterReading()
        {
            Dictionary<string, Supplier> smartMeterToPricePlanAccounts = GetSmartMeterToPricePlanAccounts();
            var smartMeterIds = smartMeterToPricePlanAccounts.Select(mtpp => mtpp.Key);

            foreach (var smartMeterId in smartMeterIds)
            {
                MeterReadings.Add(smartMeterId, new MeterReading 
                {
                    Id = smartMeterId,
                    ElectricityReadings = GenerateElectricityReading(20)
                });
            }
        }

        private Dictionary<string, Supplier> GetSmartMeterToPricePlanAccounts()
        {
            return new Dictionary<string, Supplier> 
            {
                {"smart-meter-0", Supplier.DrEvilsDarkEnergy},
                {"smart-meter-1", Supplier.TheGreenEco},
                {"smart-meter-2", Supplier.DrEvilsDarkEnergy},
                {"smart-meter-3", Supplier.PowerForEveryone},
                {"smart-meter-4", Supplier.TheGreenEco},
            };
        }

        public List<ElectricityReading> GenerateElectricityReading(int number)
        {
            var readings = new List<ElectricityReading>();
            var random = new Random();
            for (int i = 0; i < number; i++)
            {
                var reading = (decimal)random.NextDouble();
                var electricityReading = new ElectricityReading
                {
                    Reading = reading,
                    Time = DateTime.Now.AddSeconds(-i * 10)
                };
                readings.Add(electricityReading);
            }
            readings.Sort((reading1, reading2) => reading1.Time.CompareTo(reading2.Time));
            return readings;
        }
    }
}
