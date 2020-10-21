using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFEmployers.Commands;
using WPFEmployers.Models;
using WPFEmployers.Views;

namespace WPFEmployers.ViewModels
{
    class EmployerViewModel : INotifyPropertyChanged
    {
        private EmployerClass employer;
        private EmployerClass tempEmployer;
        private ObservableCollection<EmployerClass> employers;
        private ObservableCollection<EmployerUnit> units;
        public EmployerClass Employer
        {
            get { return employer; }
            set { employer = value; OnPropertyChanged("Employer"); }
        }
        public EmployerClass TempEmployer
        {
            get { return tempEmployer; }
            set { tempEmployer = value; OnPropertyChanged("TempEmployer"); }
        }
        public ObservableCollection<EmployerClass> Employers
        {
            get { return employers; }
            set { employers = value; OnPropertyChanged("Employers"); }
        }
        public ObservableCollection<EmployerUnit> Units
        {
            get { return units; }
            set { units = value; OnPropertyChanged("Units"); }
        }

        private ICommand commandAdd;
        private ICommand commandUpdate;
        private ICommand commandSelectedEmployer;
        private ICommand commandUpdateEmployer;
        private ICommand commandCancelEmployer;
        public ICommand CommandAdd { get { if (commandAdd == null) { commandAdd = new EmployerAddCommand(AddEmployer, Executable); } return commandAdd; } }
        public ICommand CommandUpdate { get { if (commandUpdate == null) { commandUpdate = new EmployerAddCommand(UpdateEmployer, Executable); } return commandUpdate; } }
        public ICommand CommandSelectedEmployer { get { if (commandSelectedEmployer == null) { commandSelectedEmployer = new EmployerSelectedCommand(SetSelectedEmployer, Executable); } return commandSelectedEmployer; } }
        public ICommand CommandUpdateEmployer { get { if (commandUpdateEmployer == null) commandUpdateEmployer = new EmployerUpdateCommand(UpdateEmployer, Executable); return commandUpdateEmployer; } }
        public ICommand CommandCancelEmployer { get { if (commandCancelEmployer == null) commandCancelEmployer = new EmployerUpdateCommand(CancelEmployer, Executable); return commandUpdateEmployer; } }


        public EmployerViewModel()
        {
            if (employers == null) employers = GetEmployers();
            if (units == null) units = GetUnits();
        }

        public EmployerViewModel(EmployerClass parameter)
        {
            if (employers == null) employers = GetEmployers();
            if (units == null) units = GetUnits();
            if (parameter != null) employers.Add(parameter);
        }

        private ObservableCollection<EmployerClass> GetEmployers()
        {
            ObservableCollection<EmployerClass> OC = new ObservableCollection<EmployerClass>();
            var entities = new EmployerBaseEntities();
            var employerList = entities.EmployersTable.ToList();
            foreach (EmployersTable ET in employerList)
            {
                OC.Add(new EmployerClass()
                {
                    Id = ET.Сотрудник_ID,
                    Surname = ET.Фамилия,
                    Name = ET.Имя,
                    Patronymic = ET.Отчество,
                    Born = ET.Дата_рождения,
                    Gender = (EmployerGender)Enum.Parse(typeof(EmployerGender), ET.Пол),
                    Unit = new EmployerUnit() { Name = ET.Подразделение }
                });
            }
            return OC;
        }

        private ObservableCollection<EmployerUnit> GetUnits()
        {
            List<string> unitsNames = new List<string>();
            ObservableCollection<EmployerUnit> OC = new ObservableCollection<EmployerUnit>();
            var entities = new EmployerBaseEntities();
            var unitList = entities.UnitsTable.ToList();

            foreach (UnitsTable UT in unitList)
            {
                EmployerUnit EU = new EmployerUnit() { Name = UT.Название };
                unitsNames.Add(UT.Название);

                if (UT.Руководитель != null)
                    EU.Head = (EmployerClass)employers.Where(x => x.Id == UT.Руководитель);
                OC.Add(EU);

                foreach (EmployerClass EC in employers)
                    if (EC.Unit.Name == UT.Название) EC.Unit = EU;
            }
            return OC;
        }

        private void SetTempEmployer()
        {

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
            employer.Surname = tempEmployer.Surname;
            employer.Name = tempEmployer.Name;
            employer.Patronymic = tempEmployer.Patronymic;
            employer.Born = tempEmployer.Born;
            employer.Gender = tempEmployer.Gender;
            employer.Unit = tempEmployer.Unit;
        }

        private void CancelEmployer(object parameter)
        {
            tempEmployer = null;
        }


        private void SetSelectedEmployer(object parameter)
        {
            if (parameter != null)
            {
                Employer = (EmployerClass)parameter;
                TempEmployer = new EmployerClass();
                TempEmployer.Surname = Employer.Surname;
                TempEmployer.Name = Employer.Name;
                TempEmployer.Patronymic = Employer.Patronymic;
                TempEmployer.Born = Employer.Born;
                TempEmployer.Gender = Employer.Gender;
                TempEmployer.Unit = Employer.Unit;
            }
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
