using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinInteligente.Model.BaseTypes
{
    public abstract class BaseViewModel : ObservableObject
    {
        private string title;
        protected INavigation navigation;

        public BaseViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public BaseViewModel()
        {

        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
    }
}
