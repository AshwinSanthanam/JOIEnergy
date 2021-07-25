using JOIEnergy.Base.Entities;

namespace JOIEnergy.Base.DataManagement
{
    public interface IRepository
    {
        MeterReadings GetMeterReading(string meterId);
    }
}
