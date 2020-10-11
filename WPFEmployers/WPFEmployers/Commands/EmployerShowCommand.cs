using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPFEmployers.Commands
{
    class EmployerShowCommand : ICommand
    {
        Action<object> act;
        Func<bool> func;

        public EmployerShowCommand(Action<object> a, Func<bool> f)
        {
            act = a;
            func = f;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}