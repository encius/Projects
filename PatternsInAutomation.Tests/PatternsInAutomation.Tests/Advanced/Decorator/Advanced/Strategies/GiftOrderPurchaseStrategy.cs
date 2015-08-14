﻿using System;
using PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Data;
using PatternsInAutomation.Tests.Advanced.Decorator.Enums;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Services;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Strategies
{
    public class GiftOrderPurchaseStrategy : IOrderPurchaseStrategy
    {
        public GiftOrderPurchaseStrategy()
        {
            this.GiftWrappingPriceCalculationService = new GiftWrappingPriceCalculationService();
        }

        public GiftWrappingPriceCalculationService GiftWrappingPriceCalculationService { get; set; }

        public void ValidateOrderSummary(string itemsPrice, ClientPurchaseInfo clientPurchaseInfo)
        {
            decimal giftWrapPrice = this.GiftWrappingPriceCalculationService.Calculate(clientPurchaseInfo.GiftWrapping);

            PlaceOrderPage.Instance.Validate().GiftWrapPrice(giftWrapPrice.ToString());
        }

        public void ValidateClientPurchaseInfo(ClientPurchaseInfo clientPurchaseInfo)
        {
            if (clientPurchaseInfo.GiftWrapping.Equals(GiftWrappingStyles.None))
            {
                throw new ArgumentException("The gift wrapping style cannot be set to None if the GiftOrderPurchaseStrategy should be executed.");
            }
        }
    }
}
