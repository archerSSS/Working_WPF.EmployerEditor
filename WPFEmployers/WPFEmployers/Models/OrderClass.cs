using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace WPFEmployers.Models
{
    class OrderClass : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private EmployerClass employer;

        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public EmployerClass Employer { get { return employer; } set { employer = value; OnPropertyChanged("Employer"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}