using JOIEnergy.Base.Enums;

namespace JOIEnergy.Base.Entities
{
    public class MeterReadingPricePlanAccount
    {
        public string MeterReadingId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
