using JOIEnergy.Base.Entities;
using JOIEnergy.Base.TransientEntities.cs;
using JOIEnergy.Base.Validators.Attributes;

namespace JOIEnergy.Base.Validators
{
    [Validator(nameof(MeterReading))]
    public abstract class AbstractMeterReadingValidator : BaseValidator<TransientMeterReading, AbstractMeterReadingValidator>
    {
        [Validation(nameof(MeterReading), "Meter Reading must have atleast one Electricity Reading.")]
        protected abstract bool ValidateAtleastOneElectricityReading(TransientMeterReading transientMeterReading, string exclusionId);
    }
}
