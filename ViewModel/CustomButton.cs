using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SwissKnife
{
    class CustomButtonExtention: Button
    {
        public static readonly DependencyProperty GeometryDataProperty =
                               DependencyProperty.RegisterAttached("GeometryData", typeof(Geometry), typeof(CustomButtonExtention));

        public Geometry GeometryData
        {
            get { return (Geometry)GetValue(GeometryDataProperty); }
            set { SetValue(GeometryDataProperty, value); }
        }
    }
}
