using System;
using System.Collections.Generic;
using System.Text;
using XamarinInteligente.Model.BaseTypes;

namespace XamarinInteligente.Model.Entities
{
    public enum PromotionType
    {
        PercentageDiscount,
        QuantityDiscount,
        None
    }

    class Promotion : ObservableObject
    {
        private double amount;

        public double Amount
        {
            get => amount;

            set => SetProperty(ref amount, value); // name = value;
        }

        private DateTime expirationDate;

        public DateTime ExpirationDate
        {
            get => expirationDate;

            set => SetProperty(ref expirationDate, value); // name = value;
        }

        private PromotionType promotionType;

        public PromotionType PromotionType
        {
            get => promotionType;

            set => SetProperty(ref promotionType, value); // name = value;
        }

        public double CalculateTotal(PromotionType promotionType, double discountAmount, ProductOrder productOrder)
        {
            return productOrder.Price * productOrder.Quantity;
        }
    }
}
