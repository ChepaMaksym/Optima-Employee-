using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Optima_Employee_.ViewModels
{
    public partial class FindViewModel : ObservableObject
    {
        [ObservableProperty]
        string _name;

        public ICommand FindEmployeeCommand { get; set; }
        public ICommand ResetEmployeeCommand { get; set; }

        public FindViewModel()
        {
            FindEmployeeCommand = new RelayCommand(FindEmployee, CanFindEmployee);
            ResetEmployeeCommand = new RelayCommand(ResetEmployee, CanResetEmployee);
        }

        private bool CanResetEmployee(object obj)
        {
            return true;
        }

        private void ResetEmployee(object obj)
        {
            var result = MessageBox.Show("Відновити список?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ShellViewModel.ShowEmployees = ShellViewModel.Employees;
            }
        }

        private bool CanFindEmployee(object obj)
        {
            return true;
        }

        private void FindEmployee(object obj)
        {
            var result = MessageBox.Show("Найти?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var filteredEmployees = ShellViewModel.Employees
                    .Where(employee => employee.Name.StartsWith(Name.ToString(), StringComparison.OrdinalIgnoreCase))
                    .ToList();

                var observableFilteredEmployees = new System.Collections.ObjectModel.ObservableCollection<Employee>(filteredEmployees);

                ShellViewModel.ShowEmployees = observableFilteredEmployees;
            }
        }
    }
}
