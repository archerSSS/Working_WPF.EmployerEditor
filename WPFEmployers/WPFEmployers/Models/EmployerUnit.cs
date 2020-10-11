using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace WPFEmployers.Models
{
    class EmployerUnit : INotifyPropertyChanged
    {
        private string name;
        private EmployerClass head;

        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public EmployerClass Head { get { return head; } set { head = value; OnPropertyChanged("Head"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}