using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinInteligente.Model.BaseTypes
{
    public abstract class BaseViewModel : ObservableObject
    {
        private string title;

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
