using System.Collections.Generic;
using JOIEnergy.Base.DataManagement;
using JOIEnergy.Base.Entities;
using JOIEnergy.Base.Enums;

namespace JOIEnergy.Services
{
    public class AccountService : Dictionary<string, Supplier>, IAccountService
    {
        private readonly IRepository _repository;

        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        public Supplier GetPricePlanIdForSmartMeterId(string smartMeterId) {
            MeterReadingPricePlanAccount meterReadingPricePlanAccount = _repository.GetMeterReadingPricePlanAccount(smartMeterId);
            return meterReadingPricePlanAccount?.Supplier ?? Supplier.NullSupplier;
        }
    }
}
