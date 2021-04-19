using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MAD.XamarinForms.NullableControls.TestApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            this.IsChecked = null;
        }

        private bool? isChecked;
        public bool? IsChecked
        {
            get => this.isChecked;
            set
            {
                this.isChecked = value;
                this.OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
