using JOIEnergy.Base.TransientEntities.cs;

namespace JOIEnergy.Base.Validators
{
    public abstract class AbstractMeterReadingValidator : BaseValidator<TransientMeterReading, AbstractMeterReadingValidator>
    {
        protected abstract bool ValidateAtleastOneElectricityReading(TransientMeterReading transientMeterReading, string exclusionId);
    }
}
