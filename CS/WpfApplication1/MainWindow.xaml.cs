using System;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication1 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Style style = (Style)this.FindResource("DateHeaderStyle");
            schedulerControl1.DayView.DateHeaderStyle = style;
            schedulerControl1.WorkWeekView.DateHeaderStyle = style;
        }
    }

    public class DateTimeToShortDateStringConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                              object parameter, System.Globalization.CultureInfo culture) {
            if (value == null)
                return null;
            DateTime dateTimeValue = (DateTime)value;

            string param = parameter != null ? parameter.ToString() : string.Empty;
            if (param == string.Empty)
                param = "MM/dd";

            return dateTimeValue.ToString(param);
        }
        public object ConvertBack(object value, Type targetType, 
                                  object parameter, System.Globalization.CultureInfo culture) {
            return null;
        }
    }
}
