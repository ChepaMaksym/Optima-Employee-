using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Optima_Employee_
{
    public partial class EditViewModel : ObservableObject
    {
        int id;
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

        public ICommand EditEmployeeCommand { get; set; }

        public EditViewModel(Employee employee)
        {
            id = employee.Id;
            Name = employee.Name;
            Address = employee.Address;
            BirthDate = employee.DateOfBirth;
            Phone = employee.Phone;
            Position = employee.Position;
            Status = employee.Status;
            Salary = employee.Salary;
            HiringDate = employee.HiringDate;
            DismissalDate = employee.DismissalDate;
            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEditEmployee);
        }

        private bool CanEditEmployee(object obj)
        {
            return true;
        }

        private void EditEmployee(object obj)
        {
            var result = MessageBox.Show("Сохранить?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var employeeToEdit = ShellViewModel.Employees.FirstOrDefault(emp => emp.Id == id);
                if (employeeToEdit != null)
                {
                    var employee = new Employee
                    {
                        Id = id,
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
                    int index = ShellViewModel.Employees.IndexOf(employeeToEdit);
                    ShellViewModel.Employees[index] = employee;
                }
            }

        }
    }
}
    
