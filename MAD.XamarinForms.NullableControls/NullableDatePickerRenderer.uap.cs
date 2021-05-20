using MAD.XamarinForms.NullableControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NullableDatePicker), typeof(NullableDatePickerRenderer))]
namespace MAD.XamarinForms.NullableControls
{
    public class NullableDatePickerRenderer : ViewRenderer<NullableDatePicker, CalendarDatePicker>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NullableDatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement is null
                && this.Control is null)
            {
                var nativeDatePicker = new CalendarDatePicker
                {
                    Date = this.Element.Date
                };

                nativeDatePicker.DateChanged += this.NativeDatePicker_DateChanged;

                this.SetNativeControl(nativeDatePicker);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(NullableDatePicker.Date):
                    this.OnElementDateChanged();
                    break;
            }
        }

        private void OnElementDateChanged()
        {
            this.Control.Date = this.Element.Date;
        }

        private void NativeDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            this.Element.Date = this.Control.Date?.DateTime;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing 
                && this.Control != null)
            {
                this.Control.DateChanged -= this.NativeDatePicker_DateChanged;
            }

            base.Dispose(disposing);
        }
    }
}
