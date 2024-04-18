using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Optima_Employee_
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class EditView : Window
    {
        public EditView(Employee employee)
        {
            InitializeComponent();
            EditViewModel edit = new(employee);
            this.DataContext = edit;
        }
    }
}
