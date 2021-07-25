﻿using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using JOIEnergy.Base.Enums;
using JOIEnergy.Base.TransientEntities.cs;
using JOIEnergy.Base.Validators;
using System;
using System.Collections.Generic;

namespace JOIEnergy.DataAccess.DataManagement
{
    public class InMemoryRepository : IRepository
    {
        private readonly Dictionary<string, PricePlan> _pricePlans;
        private Dictionary<string, MeterReading> _meterAssociatedReadings;

        private readonly AbstractMeterReadingValidator _meterReadingValidator;

        public InMemoryRepository(AbstractMeterReadingValidator meterReadingValidator, bool seed = true)
        {
            _pricePlans = new Dictionary<string, PricePlan>();
            _meterAssociatedReadings = new Dictionary<string, MeterReading>();

            if (seed)
            {
                SeedPricePlans();
            }
            _meterReadingValidator = meterReadingValidator;
        }

        public IEnumerable<PricePlan> PricePlans => _pricePlans.Values;

        public MeterReading GetMeterReading(string meterId)
        {
            if (string.IsNullOrEmpty(meterId))
            {
                return null;
            }
            _meterAssociatedReadings.TryGetValue(meterId, out MeterReading meterReading);
            return meterReading;
        }

        public MeterReading InsertMeterReading(TransientMeterReading transientMeterReading)
        {
            _meterReadingValidator.Validate(transientMeterReading, string.Empty);
            MeterReading meterReading = new MeterReading
            {
                ElectricityReadings = transientMeterReading.ElectricityReadings,
                Id = Guid.NewGuid().ToString()
            };
            _meterAssociatedReadings.Add(meterReading.Id, meterReading);
            return meterReading;
        }

        public PricePlan InsertPricePlan(TransientPricePlan transientPricePlan)
        {
            PricePlan pricePlan = new PricePlan
            {
                Id = Guid.NewGuid().ToString(),
                EnergySupplier = transientPricePlan.EnergySupplier,
                PeakTimeMultiplier = transientPricePlan.PeakTimeMultiplier,
                UnitRate = transientPricePlan.UnitRate
            };
            _pricePlans.Add(pricePlan.Id, pricePlan);
            return pricePlan;
        }

        public MeterReading UpdateMeterReading(string meterReadingId, TransientMeterReading transientMeterReading)
        {
            MeterReading meterReadingToUpdate = _meterAssociatedReadings[meterReadingId];
            meterReadingToUpdate.ElectricityReadings = transientMeterReading.ElectricityReadings;
            return meterReadingToUpdate;
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

            pricePlans.ForEach(x => _pricePlans.Add(x.Id, x));
        }
    }
}
