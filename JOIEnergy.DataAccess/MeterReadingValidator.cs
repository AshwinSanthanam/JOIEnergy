using JOIEnergy.Base.TransientEntities.cs;
using JOIEnergy.Base.Validators;
using System.Linq;

namespace JOIEnergy.DataAccess
{
    public class MeterReadingValidator : AbstractMeterReadingValidator
    {
        protected override bool ValidateAtleastOneElectricityReading(TransientMeterReading transientMeterReading, string exclusionId)
        {
            return transientMeterReading.ElectricityReadings.Any();
        }
    }
}
