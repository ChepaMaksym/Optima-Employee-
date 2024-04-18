using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Optima_Employee_
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            ShellViewModel shell = new();
            this.DataContext = shell;
            ShowEmployees.ItemsSource = ShellViewModel.ShowEmployees;
        }
    }
    public class DismissalDateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Brushes.LightGray;
            }
            else
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
