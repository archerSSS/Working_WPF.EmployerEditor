using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using WPFEmployers.ViewModels;

namespace WPFEmployers.Models
{
    class EmployerClass : INotifyPropertyChanged
    {
        private int id;
        private string surname;
        private string name;
        private string patronymic;
        private DateTime born;
        private EmployerGender gender;
        private EmployerUnit unit;

        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Surname { get { return surname; } set { surname = value; OnPropertyChanged("Surname"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Patronymic { get { return patronymic; } set { patronymic = value; OnPropertyChanged("Patronymic"); } }
        public DateTime Born { get { return born; } set { born = value; OnPropertyChanged("Born"); } }
        public EmployerGender Gender { get { return gender; } set { gender = value; OnPropertyChanged("Gender"); } }
        public EmployerUnit Unit { get { return unit; } set { unit = value; OnPropertyChanged("Unit"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return surname + " " + name + " " + patronymic;
        }
    }
}