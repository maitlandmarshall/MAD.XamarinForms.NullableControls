using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAD.XamarinForms.NullableControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NullableCheckBox : ContentView
    {
        public static BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool?), typeof(NullableCheckBox), defaultBindingMode: BindingMode.TwoWay);

        public NullableCheckBox()
        {
            InitializeComponent();
        }

        public bool? IsChecked
        {
            get => this.GetValue(IsCheckedProperty) as bool?;
            set => this.SetValue(IsCheckedProperty, value);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (this.IsChecked is null)
            {
                this.IsChecked = true;
            }
            else if (this.IsChecked == true)
            {
                this.IsChecked = false;
            }
            else if (this.IsChecked == false)
            {
                this.IsChecked = null;
            }
        }
    }
}