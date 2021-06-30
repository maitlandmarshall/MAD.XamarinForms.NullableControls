using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MAD.XamarinForms.NullableControls.TestApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            this.viewModel = new MainPageViewModel();
            this.Content.BindingContext = this.viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.viewModel.Date = null;
            this.viewModel.IsChecked = null;
        }
    }
}
