using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Optima_Employee_
{
    public partial class CreateViewModel : ObservableObject
    {
        [ObservableProperty]
        string _name;
        [ObservableProperty]
        private string _address;
        [ObservableProperty]
        private DateTime? _birthDate;
        [ObservableProperty]
        private string _phone;
        [ObservableProperty]
        private string _position;
        [ObservableProperty]
        private string _status;
        [ObservableProperty]
        private decimal _salary;
        [ObservableProperty]
        private DateTime? _hiringDate;
        [ObservableProperty]
        private DateTime? _dismissalDate;

        public ICommand CreateEmployeeCommand { get; set; }

        public CreateViewModel()
        {
            CreateEmployeeCommand = new RelayCommand(CreateEmployee, CanCreateEmployee);
        }

        private bool CanCreateEmployee(object obj)
        {
            return true;
        }

        private void CreateEmployee(object obj)
        {
            var result = MessageBox.Show("Сохранить?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var employee = new Employee
                {
                    Id = ShellViewModel.Employees.Any() ? ShellViewModel.Employees.Max(x => x.Id) + 1 : 1,
                    Name = Name,
                    Address = Address,
                    DateOfBirth = BirthDate,
                    Phone = Phone,
                    Position = Position,
                    Status = Status,
                    Salary = Salary,
                    HiringDate = HiringDate,
                    DismissalDate = DismissalDate
                };
                ShellViewModel.Employees.Add(employee);
            }
        }

    }
}
