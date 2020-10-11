using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPFEmployers.Commands
{
    class EmployerUpdateCommand : ICommand
    {
        private Action<object> act;
        private Func<bool> func;

        public EmployerUpdateCommand(Action<object> a, Func<bool> f)
        {
            act = a;
            func = f;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (func != null)
                return func();
            return true;
        }

        public void Execute(object parameter)
        {
            act(parameter);
        }
    }
}