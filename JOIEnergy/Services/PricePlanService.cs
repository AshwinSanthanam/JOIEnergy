using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;

namespace JOIEnergy.Services
{
    public class PricePlanService : IPricePlanService
    {
        private readonly IMeterReadingService _meterReadingService;
        private readonly IRepository _repository;

        public PricePlanService(IRepository repository, IMeterReadingService meterReadingService)
        {
            _repository = repository;
            _meterReadingService = meterReadingService;
        }

        public Dictionary<string, decimal> GetConsumptionCostOfElectricityReadingsForEachPricePlan(string smartMeterId)
        {
            IEnumerable<ElectricityReading> electricityReadings = _meterReadingService.GetReadings(smartMeterId);

            if (!electricityReadings.Any())
            {
                return new Dictionary<string, decimal>();
            }
            return _repository.PricePlans.ToDictionary(plan => plan.EnergySupplier.ToString(), plan => CalculateCost(electricityReadings, plan));
        }

        private decimal CalculateAverageReading(IEnumerable<ElectricityReading> electricityReadings)
        {
            var newSummedReadings = electricityReadings.Select(readings => readings.Reading).Aggregate((reading, accumulator) => reading + accumulator);

            return newSummedReadings / electricityReadings.Count();
        }

        private decimal CalculateTimeElapsed(IEnumerable<ElectricityReading> electricityReadings)
        {
            var first = electricityReadings.Min(reading => reading.Time);
            var last = electricityReadings.Max(reading => reading.Time);

            return (decimal)(last - first).TotalHours;
        }

        private decimal CalculateCost(IEnumerable<ElectricityReading> electricityReadings, PricePlan pricePlan)
        {
            var average = CalculateAverageReading(electricityReadings);
            var timeElapsed = CalculateTimeElapsed(electricityReadings);
            var averagedCost = average/timeElapsed;
            return averagedCost * pricePlan.UnitRate;
        }
    }
}
