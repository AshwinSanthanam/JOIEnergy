using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using System.Collections.Generic;

namespace JOIEnergy.DataAccess.DataManagement
{
    public class InMemoryRepository : IRepository
    {
        private readonly DbContext _dbContext;

        public InMemoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PricePlan> PricePlans => _dbContext.PricePlans.Values;

        public MeterReading GetMeterReading(string meterId)
        {
            if (string.IsNullOrEmpty(meterId))
            {
                return null;
            }
            _dbContext.MeterAssociatedReadings.TryGetValue(meterId, out MeterReading meterReading);
            return meterReading;
        }
    }
}
