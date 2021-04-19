using MAD.XamarinForms.NullableControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NullableCheckBox), typeof(NullableCheckboxRenderer))]
namespace MAD.XamarinForms.NullableControls
{
    public class NullableCheckboxRenderer : ViewRenderer<NullableCheckBox, CheckBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NullableCheckBox> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement is null
                && this.Control is null)
            {
                var nativeCheckbox = new CheckBox
                {
                    IsThreeState = true,
                    IsChecked = this.Element.IsChecked
                };

                nativeCheckbox.Click += this.OnControlIsCheckedChanged;

                this.SetNativeControl(nativeCheckbox);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(NullableCheckBox.IsChecked):
                    this.OnElementIsCheckedChanged();
                    break;
            }
        }

        private void OnControlIsCheckedChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Element.IsChecked = this.Control.IsChecked;
        }

        private void OnElementIsCheckedChanged()
        {
            this.Control.IsChecked = this.Element.IsChecked;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing
                && this.Control != null)
            {
                this.Control.Click -= this.OnControlIsCheckedChanged;
            }

            base.Dispose(disposing);
        }
    }
}
