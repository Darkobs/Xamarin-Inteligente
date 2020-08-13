using System;
using System.Collections.Generic;
using System.Text;
using XamarinInteligente.Model.BaseTypes;

namespace XamarinInteligente.Model.Entities
{
    public class ProductOrder : ObservableObject
    {
        private double price;

        public double Price
        {
            get => price;

            set => SetProperty(ref price, value); // name = value;
        }

        private Product product;

        public Product Product
        {
            get => product;

            set => SetProperty(ref product, value); // name = value;
        }

        private int quantity;

        public int Quantity
        {
            get => quantity;

            set => SetProperty(ref quantity, value); // name = value;
        }

        private double total;

        public double Total
        {
            get => total;

            set => SetProperty(ref total, value); // name = value;
        }
    }
}
