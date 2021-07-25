using JOIEnergy.Base.Entities;
using JOIEnergy.Base.TransientEntities.cs;

namespace JOIEnergy.Base.DataManagement
{
    public interface IRepository
    {
        MeterReading GetMeterReading(string meterId);

        MeterReading InsertMeterReading(TransientMeterReading transientMeterReading);

        MeterReading UpdateMeterReading(string meterReadingId, TransientMeterReading transientMeterReading);
    }
}
