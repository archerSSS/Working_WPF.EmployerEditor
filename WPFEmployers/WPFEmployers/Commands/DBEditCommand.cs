using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFEmployers.Commands
{
    class DBEditCommand : ICommand
    {
        private Action<object> act;
        private Func<bool> func;

        public DBEditCommand(Action<object> a, Func<bool> f)
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
