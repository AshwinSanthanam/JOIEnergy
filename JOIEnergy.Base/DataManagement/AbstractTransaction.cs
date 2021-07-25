using JOIEnergy.Base.Entities;
using JOIEnergy.Base.TransientEntities.cs;
using JOIEnergy.Base.Validators;

namespace JOIEnergy.Base.DataManagement
{
    public abstract class AbstractTransaction
    {
        private readonly AbstractMeterReadingValidator _meterReadingValidator;

        protected AbstractTransaction(AbstractMeterReadingValidator meterReadingValidator)
        {
            _meterReadingValidator = meterReadingValidator;
        }

        public MeterReading InsertMeterReading(TransientMeterReading transientMeterReading)
        {
            _meterReadingValidator.Validate(transientMeterReading, string.Empty);
            return RawInsertMeterReading(transientMeterReading);
        }

        public MeterReading UpdateMeterReading(string meterReadingId, TransientMeterReading transientMeterReading)
        {
            _meterReadingValidator.Validate(transientMeterReading, meterReadingId);
            return RawUpdateMeterReading(meterReadingId, transientMeterReading);
        }

        public PricePlan InsertPricePlan(TransientPricePlan transientPricePlan)
        {
            return RawInsertPricePlan(transientPricePlan);
        }

        protected abstract MeterReading RawInsertMeterReading(TransientMeterReading transientMeterReading);

        protected abstract MeterReading RawUpdateMeterReading(string meterReadingId, TransientMeterReading transientMeterReading);

        protected abstract PricePlan RawInsertPricePlan(TransientPricePlan transientPricePlan);
    }
}
