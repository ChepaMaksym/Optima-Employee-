using System.Windows.Input;

namespace Optima_Employee_
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object> _Exceute {get;set;}
        private Predicate<object> _CanExecute { get;set;}
        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
        {
            _Exceute = executeMethod;
            _CanExecute = canExecuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Exceute(parameter);
        }
    }
}
