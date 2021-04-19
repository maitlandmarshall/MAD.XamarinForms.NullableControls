using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAD.XamarinForms.NullableControls
{
    public class NullableCheckBox : View
    {
        public static BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool?), typeof(NullableCheckBox), null, defaultBindingMode: BindingMode.TwoWay);

        public bool? IsChecked
        {
            get => this.GetValue(IsCheckedProperty) as bool?;
            set => this.SetValue(IsCheckedProperty, value);
        }
    }
}
