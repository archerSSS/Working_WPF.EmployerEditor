using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFEmployers.Commands;
using WPFEmployers.Models;

namespace WPFEmployers.ViewModels
{
    class EmployerView : INotifyPropertyChanged
    {
        private EmployerClass employer;
        public EmployerClass Employer { get { return employer; } set { employer = value;  } }

        private ObservableCollection<EmployerClass> employers;
        public ObservableCollection<EmployerClass> Employers { get { return employers; } set { employers = value; OnPropertyChanged("Employers"); } }

        private ICommand commandAdd;
        public ICommand CommandAdd { get { if (commandAdd == null) { commandAdd = new EmployerAddCommand(AddEmployer, Executable); } return commandAdd; } }
        private ICommand commandUpdate;
        public ICommand CommandUpdate { get { if (commandUpdate == null) { commandUpdate = new EmployerAddCommand(UpdateEmployer, Executable); } return commandUpdate; } }

        private void AddEmployer(object parameter)
        {

        }

        private void UpdateEmployer(object parameter)
        {

        }

        private bool Executable()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}