using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPFEmployers.Commands;
using WPFEmployers.Models;
using WPFEmployers.Properties;

namespace WPFEmployers.ViewModels
{
    class EmployerView : INotifyPropertyChanged
    {
        private EmployerClass employer;
        public EmployerClass Employer { get { return employer; } set { employer = value;  } }

        private ObservableCollection<EmployerClass> employers;
        public ObservableCollection<EmployerClass> Employers 
        { 
            get { if (employers == null) employers = GetEmployers(); return employers; } 
            set { employers = value; OnPropertyChanged("Employers"); } 
        }


        private ICommand commandAdd;
        public ICommand CommandAdd { get { if (commandAdd == null) { commandAdd = new EmployerAddCommand(AddEmployer, Executable); } return commandAdd; } }
        private ICommand commandUpdate;
        public ICommand CommandUpdate { get { if (commandUpdate == null) { commandUpdate = new EmployerAddCommand(UpdateEmployer, Executable); } return commandUpdate; } }

        private ObservableCollection<EmployerClass> GetEmployers()
        {
            var entities = new EmployerBaseEntities();
            var employerList = entities.EmployersTable.ToList();
            ObservableCollection<EmployerClass> OC = new ObservableCollection<EmployerClass>();
            foreach (EmployersTable ET in employerList)
            {
                OC.Add(new EmployerClass() { 
                    Surname = ET.Фамилия, 
                    Name = ET.Имя, 
                    Patronymic = ET.Отчество,
                    Born = ET.Дата_рождения,
                    Gender = (EmployerGender)Enum.Parse(typeof(EmployerGender), ET.Пол),
                    Unit = new EmployerUnit() { Name = ET.Подразделение } });
            }
            return OC;
        }

        private void AddEmployer(object parameter)
        {
            var entities = new EmployerBaseEntities();
            var employerList = entities.EmployersTable.ToList();
            /*using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnection))
            {
                IDbCommand command = new SqlCommand("USE EmployerBase SELECT * FROM dbo.EmployersTable");
                command.Connection = connection;
                connection.Open();

                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                }
            }*/
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