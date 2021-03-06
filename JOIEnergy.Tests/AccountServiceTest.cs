using System;
using System.Collections.Generic;
using JOIEnergy.Base.Entities;
using JOIEnergy.Base.Enums;
using JOIEnergy.DataAccess.DataManagement;
using JOIEnergy.Services;
using Xunit;

namespace JOIEnergy.Tests
{
    public class AccountServiceTest
    {
        private const Supplier PRICE_PLAN_ID = Supplier.PowerForEveryone;
        private const String SMART_METER_ID = "smart-meter-id";

        private AccountService accountService;

        public AccountServiceTest()
        {
            var dbContext = new DbContext(false);
            dbContext.MeterReadingPricePlanAccounts.Add(SMART_METER_ID, new MeterReadingPricePlanAccount 
            {
                MeterReadingId = SMART_METER_ID,
                Supplier = PRICE_PLAN_ID
            });
            var repository = new InMemoryRepository(dbContext);
            accountService = new AccountService(repository);
        }

        [Fact]
        public void GivenTheSmartMeterIdReturnsThePricePlanId()
        {
            var result = accountService.GetPricePlanIdForSmartMeterId("smart-meter-id");
            Assert.Equal(Supplier.PowerForEveryone, result);
        }

        [Fact]
        public void GivenAnUnknownSmartMeterIdReturnsANullSupplier()
        {
            var result = accountService.GetPricePlanIdForSmartMeterId("bob-carolgees");
            Assert.Equal(Supplier.NullSupplier, result);
        }
    }
}
