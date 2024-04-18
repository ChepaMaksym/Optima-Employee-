using Caliburn.Micro;
using Optima_Employee_.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;

namespace Optima_Employee_
{
    public partial class ShellViewModel : ObservableObject
    {

        public static ObservableCollection<Employee> Employees { get; set; }
        public static ObservableCollection<Employee> ShowEmployees { get; set; }

        public RelayCommand CreateWindowCommand { get; }
        public RelayCommand DeleteEmployeesCommand { get; }
        public RelayCommand EditWindowCommand { get; }
        public RelayCommand FireEmployeeCommand { get; }
        public RelayCommand ImportEmployeeCommand { get; }
        public RelayCommand ExportEmployeeCommand { get; }
        public RelayCommand FindEmployeeCommand { get; }


        [ObservableProperty]
        Employee selectedEmployee;


        public ShellViewModel()
        {
            DataSeed data = new DataSeed();
            Employees = new BindableCollection<Employee>(data.GenerateTestData());
            ShowEmployees = Employees;
            CreateWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            DeleteEmployeesCommand = new RelayCommand(DeleteEmployees, CanDeleteEmployees);
            EditWindowCommand = new RelayCommand(EditEmployees, CanEditEmployees);
            FireEmployeeCommand = new RelayCommand(FireEmployee, CanFireEmployee);
            ImportEmployeeCommand = new RelayCommand(ImportEmployee, CanImportEmployee);
            ExportEmployeeCommand = new RelayCommand(ExportEmployee, CanExportEmployee);
            FindEmployeeCommand = new RelayCommand(FindEmployee, CanFindEmployee);
        }

        private bool CanFindEmployee(object obj)
        {
            return true;
        }

        private void FindEmployee(object obj)
        {
            var result = MessageBox.Show("Найти работника?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var shell = obj as ShellView;
                FindView find = new FindView();
                find.Owner = shell;
                find.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                find.Show();
            }
        }

        private bool CanExportEmployee(object obj)
        {
            return true;
        }

        private bool CanImportEmployee(object obj)
        {
            return true;
        }

        private void ExportEmployee(object obj)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            bool? success = saveFileDialog.ShowDialog();


            if (success == true)
            {
                string jsonFilePath = saveFileDialog.FileName;
                try
                {
                    List<Employee> employees = new List<Employee>(Employees);
                    string jsonContent = JsonConvert.SerializeObject(employees, Formatting.Indented);

                    File.WriteAllText(jsonFilePath, jsonContent);
                }
                catch { }
            }
        }

        private void ImportEmployee(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            bool? success = openFileDialog.ShowDialog();

            if (success == true)
            {
                string jsonFilePath = openFileDialog.FileName;

                try
                {
                    string jsonContent = File.ReadAllText(jsonFilePath);
                    List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(jsonContent);
                    var observableEmployees = new ObservableCollection<Employee>(employees);
                    ShowEmployees = observableEmployees;
                }
                catch { }
            }
        }

        private bool CanFireEmployee(object obj)
        {
            return true;
        }

        private void FireEmployee(object obj)
        {
            if (selectedEmployee != null)
            {
                var result = MessageBox.Show($"Уволить работника id:{selectedEmployee.Id}?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var employeeToEdit = ShowEmployees.FirstOrDefault(emp => emp.Id == selectedEmployee.Id);
                    if (employeeToEdit != null)
                    {
                        employeeToEdit.DismissalDate = DateTime.Now;
                    }
                }
            }
        }

        private bool CanEditEmployees(object obj)
        {
            return true;
        }

        private void EditEmployees(object obj)
        {
            if (selectedEmployee != null)
            {
                var result = MessageBox.Show($"Изменить работника id:{selectedEmployee.Id}?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var shell = obj as ShellView;
                    EditView create = new EditView(selectedEmployee);
                    create.Owner = shell;
                    create.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    create.Show();
                }
            }
        }

        private bool CanDeleteEmployees(object obj)
        {
            return true;
        }

        private void DeleteEmployees(object obj)
        {
            var result = MessageBox.Show("Удалить всех?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ShowEmployees.Clear();
                Employees.Clear();
            }
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var result = MessageBox.Show("Добавить нового работника?", "Подтверждение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var shell = obj as ShellView;
                CreateView create = new CreateView();
                create.Owner = shell;
                create.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                create.Show();
            }
        }
    }
}
