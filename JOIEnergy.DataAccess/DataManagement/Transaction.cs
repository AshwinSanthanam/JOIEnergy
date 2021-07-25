using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using JOIEnergy.Base.TransientEntities.cs;
using JOIEnergy.Base.Validators;
using System;

namespace JOIEnergy.DataAccess.DataManagement
{
    public class Transaction : AbstractTransaction
    {
        private readonly DbContext _dbContext;

        public Transaction(DbContext dbContext, AbstractMeterReadingValidator meterReadingValidator) : base(meterReadingValidator)
        {
            _dbContext = dbContext;
        }

        protected override MeterReading RawInsertMeterReading(TransientMeterReading transientMeterReading)
        {
            MeterReading meterReading = new MeterReading
            {
                ElectricityReadings = transientMeterReading.ElectricityReadings,
                Id = Guid.NewGuid().ToString()
            };
            _dbContext.MeterAssociatedReadings.Add(meterReading.Id, meterReading);
            return meterReading;
        }

        protected override PricePlan RawInsertPricePlan(TransientPricePlan transientPricePlan)
        {
            PricePlan pricePlan = new PricePlan
            {
                Id = Guid.NewGuid().ToString(),
                EnergySupplier = transientPricePlan.EnergySupplier,
                PeakTimeMultiplier = transientPricePlan.PeakTimeMultiplier,
                UnitRate = transientPricePlan.UnitRate
            };
            _dbContext.PricePlans.Add(pricePlan.Id, pricePlan);
            return pricePlan;
        }

        protected override MeterReading RawUpdateMeterReading(string meterReadingId, TransientMeterReading transientMeterReading)
        {
            MeterReading meterReadingToUpdate = _dbContext.MeterAssociatedReadings[meterReadingId];
            meterReadingToUpdate.ElectricityReadings = transientMeterReading.ElectricityReadings;
            return meterReadingToUpdate;
        }
    }
}
