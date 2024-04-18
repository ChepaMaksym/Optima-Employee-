using System.Windows;

namespace Optima_Employee_
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateView : Window
    {
        public CreateView()
        {
            InitializeComponent();
            CreateViewModel create = new();
            this.DataContext = create;
        }
    }
}
