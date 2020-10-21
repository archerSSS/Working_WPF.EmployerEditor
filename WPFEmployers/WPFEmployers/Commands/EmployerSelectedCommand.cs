using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFEmployers.Commands
{
    class EmployerSelectedCommand : ICommand
    {
        Action<object> act;
        Func<bool> func;
        public event EventHandler CanExecuteChanged;

        public EmployerSelectedCommand(Action<object> a, Func<bool> f)
        {
            act = a;
            func = f;
        }

        public bool CanExecute(object parameter)
        {
            if (func != null)
            {
                return func();
            }
            return true;
        }

        public void Execute(object parameter)
        {
            act(parameter);
        }
    }
}
