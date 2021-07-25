using JOIEnergy.Base.Entities;

namespace JOIEnergy.Base.DataManagement
{
    public interface IRepository
    {
        MeterReading GetMeterReading(string meterId);

        MeterReading InsertMeterReading(MeterReading meterReading);

        MeterReading UpdateMeterReading(MeterReading meterReading);
    }
}
