using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinInteligente.Model.Helpers;

namespace XamarinInteligente.Behaviors
{
    class EntryValidationBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly(nameof(IsValid), typeof(bool), typeof(EntryValidationBehavior),false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        static readonly BindableProperty ValidationTypeProperty =
            BindableProperty.Create(nameof(ValidationType), typeof(ValidationType), typeof(EntryValidationBehavior), ValidationType.None);

        public ValidationType ValidationType
        {
            get { return (ValidationType)base.GetValue(ValidationTypeProperty); }
            set { base.SetValue(ValidationTypeProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.BindingContextChanged += Bindable_BindingContextChanged;

            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            BindingContext = null;
            bindable.TextChanged -= Bindable_TextChanged;
            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            var entry = sender as Entry;
            BindingContext = entry.BindingContext;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            IsValid = ValidationHelpers.ValidateString(ValidationType, entry.Text);
            entry.TextColor = IsValid ? Color.Black : Color.Red;
        }

        public EntryValidationBehavior()
        {

        }
    }
}
