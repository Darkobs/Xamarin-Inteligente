using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinInteligente.Controls
{
    class DynamicVisibilityToolbarItem : ToolbarItem
    {
        public static BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible),typeof(bool),typeof(DynamicVisibilityToolbarItem),false, BindingMode.OneWay, 
            HandleValidateValueDelegate, OnIsVisibleChanged);

        public bool IsVisible 
        {
            get => (bool)GetValue(IsVisibleProperty);
            set => SetValue(IsVisibleProperty, value); 
        }

        protected override void OnParentSet()
        {
            if (this.Parent != null)
                OnIsVisibleChanged(this, !IsVisible, IsVisible);
        }

        private static void OnIsVisibleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var item = bindable as DynamicVisibilityToolbarItem;

            if (oldValue != newValue && item.Parent != null)
            {
                var items = ((ContentPage)item.Parent).ToolbarItems;

                if((bool)newValue && !items.Contains(item))
                {
                    items.Add(item);
                }
                else if(!(bool)newValue && items.Contains(item))
                {
                    items.Remove(item);
                }
            }
        }

        private static bool HandleValidateValueDelegate(BindableObject bindable, object newValue)
        {
            return newValue is bool;
        }


        public DynamicVisibilityToolbarItem()
        {

        }
    }
}
