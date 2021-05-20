using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MAD.XamarinForms.NullableControls
{
    public class NullableDatePicker : View
    {
        public static BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime?), typeof(NullableDatePicker), null, defaultBindingMode: BindingMode.TwoWay);

        public DateTime? Date
        {
            get => this.GetValue(DateProperty) as DateTime?;
            set => this.SetValue(DateProperty, value);
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (widthConstraint == double.PositiveInfinity)
                widthConstraint = 0;

            if (heightConstraint == double.PositiveInfinity)
                heightConstraint = 0;

            var sizeRequest = base.OnMeasure(widthConstraint, heightConstraint);
            return sizeRequest;
        }
    }
}
