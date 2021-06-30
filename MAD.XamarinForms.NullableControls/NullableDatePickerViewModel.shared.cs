using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MAD.XamarinForms.NullableControls
{
    internal class NullableDatePickerViewModel : INotifyPropertyChanged
    {
        private string dateDisplay = "select a date";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string DateDisplay
        {
            get => this.dateDisplay;
            set
            {
                this.dateDisplay = value;
                this.OnPropertyChanged();
            }
        }
    }
}
