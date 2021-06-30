using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAD.XamarinForms.NullableControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NullableDatePicker : ContentView
    {
        public static BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime?), typeof(NullableDatePicker), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty FormatProperty = BindableProperty.Create(nameof(Format), typeof(string), typeof(NullableDatePicker), "D");
        public static BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(NullableDatePicker), Color.FromHex("#666666"));
        private readonly NullableDatePickerViewModel viewModel;

        public NullableDatePicker()
        {
            InitializeComponent();

            this.viewModel = new NullableDatePickerViewModel();
            this.Content.BindingContext = this.viewModel;
        }

        public DateTime? Date
        {
            get => this.GetValue(DateProperty) as DateTime?;
            set => this.SetValue(DateProperty, value);
        }

        public string Format
        {
            get => this.GetValue(FormatProperty) as string;
            set => this.SetValue(FormatProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)this.GetValue(BorderColorProperty);
            set => this.SetValue(BorderColorProperty, value);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            this.HiddenDatePicker.Focus();
        }

        private void HiddenDatePicker_Unfocused(object sender, FocusEventArgs e)
        {
            this.Date = this.HiddenDatePicker.Date;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(this.Date))
            {
                if (this.Date.HasValue)
                {
                    this.viewModel.DateDisplay = this.Date.Value.ToString("d");
                }
                else
                {
                    this.viewModel.DateDisplay = "select a date";
                }
            }
        }
    }
}