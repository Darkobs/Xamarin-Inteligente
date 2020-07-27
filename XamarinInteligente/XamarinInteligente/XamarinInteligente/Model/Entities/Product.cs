using System;
using System.Collections.Generic;
using System.Text;
using XamarinInteligente.Model.BaseTypes;

namespace XamarinInteligente.Model.Entities
{
    class Product : ObservableObject
    {
        private string name;

        public string Name
        {
            get => name;

            set => SetProperty(ref name, value); // name = value;
        }

        private double price;

        public double Price
        {
            get => price;

            set => SetProperty(ref price, value); // name = value;
        }
        
        private Promotion promotion;

        public Promotion Promotion
        {
            get => promotion;

            set => SetProperty(ref promotion, value); // name = value;
        }
    }
}
