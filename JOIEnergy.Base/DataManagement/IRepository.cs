using JOIEnergy.Base.Entities;

namespace JOIEnergy.Base.DataManagement
{
    public interface IRepository
    {
        MeterReadings GetMeterReading(string meterId);

        MeterReadings InsertMeterReading(MeterReadings meterReading);

        MeterReadings UpdateMeterReading(MeterReadings meterReading);
    }
}
