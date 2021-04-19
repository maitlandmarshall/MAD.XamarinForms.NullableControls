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

                nativeCheckbox.Click += this.NativeCheckbox_CheckedStateChanged;

                this.SetNativeControl(nativeCheckbox);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(NullableCheckBox.IsChecked):
                    this.OnIsCheckedChanged();
                    break;
            }
        }

        private void NativeCheckbox_CheckedStateChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Element.IsChecked = this.Control.IsChecked;
        }

        private void OnIsCheckedChanged()
        {
            this.Control.IsChecked = this.Element.IsChecked;
        }
    }
}
