using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
        private EmployerClass employerUpdate;
        private EmployerUnit unit;
        private EmployerUnit unitUpdate;
        private OrderClass order;
        private ObservableCollection<EmployerClass> employers;
        private ObservableCollection<EmployerUnit> units;
        private EmployerBaseEntities context;

        public EmployerClass Employer
        {
            get { return employer; }
            set { employer = value; OnPropertyChanged("Employer"); }
        }
        public EmployerClass EmployerUpdate
        {
            get { return employerUpdate; }
            set { employerUpdate = value; OnPropertyChanged("EmployerUpdate"); }
        }
        public EmployerUnit Unit
        {
            get { return unit; }
            set { unit = value; OnPropertyChanged("Unit"); }
        }
        public EmployerUnit UnitUpdate
        {
            get { return unitUpdate; }
            set { unitUpdate = value; OnPropertyChanged("UnitUpdate"); }
        }
        public OrderClass Order
        {
            get { return order; }
            set { order = value; OnPropertyChanged("Order"); }
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

        private ICommand commandAddEmployer;
        private ICommand commandUpdateEmployer;
        private ICommand commandAddUnit;
        private ICommand commandUpdateUnit;
        private ICommand commandAddOrder;
        private ICommand commandUpdateOrder;
        private ICommand commandCancelEmployer;
        private ICommand commandCancelUnit;
        private ICommand commandCancelOrder;
        public ICommand CommandAddEmployer { get { if (commandAddEmployer == null) { commandAddEmployer = new DBEditCommand(AddEmployer, Executable); } return commandAddEmployer; } }
        public ICommand CommandUpdateEmployer { get { if (commandUpdateEmployer == null) { commandUpdateEmployer = new DBEditCommand(UpdateEmployer, Executable); } return commandUpdateEmployer; } }
        public ICommand CommandAddUnit { get { if (commandAddUnit == null) { commandAddUnit = new DBEditCommand(AddUnit, Executable); } return commandAddUnit; } }
        public ICommand CommandUpdateUnit { get { if (commandUpdateUnit == null) { commandUpdateUnit = new DBEditCommand(UpdateUnit, Executable); } return commandUpdateUnit; } }
        public ICommand CommandAddOrder { get { if (commandAddOrder == null) { commandAddOrder = new DBEditCommand(AddOrder, Executable); } return commandAddOrder; } }
        public ICommand CommandUpdateOrder { get { if (commandUpdateOrder == null) { commandUpdateOrder = new DBEditCommand(UpdateOrder, Executable); } return commandUpdateOrder; } }
        public ICommand CommandCancelEmployer { get { if (commandCancelEmployer == null) { commandCancelEmployer = new DBEditCommand(CancelEmployer, Executable); } return commandCancelEmployer; } }
        public ICommand CommandCancelUnit { get { if (commandCancelUnit == null) { commandCancelUnit = new DBEditCommand(CancelUnit, Executable); } return commandCancelUnit; } }
        public ICommand CommandCancelOrder { get { if (commandCancelOrder == null) { commandCancelOrder = new DBEditCommand(CancelOrder, Executable); } return commandCancelOrder; } }

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
            context = new EmployerBaseEntities();
            var employerList = context.EmployersTable.ToList();
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
            var unitList = context.UnitsTable.ToList();

            foreach (UnitsTable UT in unitList)
            {
                EmployerUnit EU = new EmployerUnit() { Name = UT.Название };
                unitsNames.Add(UT.Название);

                if (UT.Руководитель != null)
                    EU.Head = (EmployerClass)employers.Single(x => x.Id == UT.Руководитель);
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
            if (Employer.Surname != "" 
                && Employer.Name != "" 
                && Employer.Patronymic != "" 
                && Employer.Born != null)
            {
                EmployersTable ET = new EmployersTable();
                ET.Фамилия = Employer.Surname;
                ET.Имя = Employer.Name;
                ET.Отчество = Employer.Patronymic;
                ET.Дата_рождения = Employer.Born;
                ET.Пол = Employer.Gender.ToString();
                ET.Подразделение = Employer.Unit.ToString();

                //Employer = EmployerUpdate;
                
                Employers.Add(Employer);
                Employer = null;

                context.EmployersTable.Add(ET);
                context.SaveChanges();
            }
        }

        private void AddUnit(object parameter)
        {

        }

        private void AddOrder(object parameter)
        {

        }

        private void UpdateEmployer(object parameter)
        {
            EmployersTable ET = context.EmployersTable.Single(e => e.Сотрудник_ID == Employer.Id);
            ET.Фамилия = Employer.Surname;
            ET.Имя = Employer.Name;
            ET.Отчество = Employer.Patronymic;
            ET.Дата_рождения = Employer.Born;
            ET.Пол = Employer.Gender.ToString();
            ET.Подразделение = Employer.Unit.ToString();

            EmployerClass EC = Employers.Single(e => e.Id == Employer.Id);
            EC.Surname = Employer.Surname;
            EC.Name = Employer.Name;
            EC.Patronymic = Employer.Patronymic;
            EC.Born = Employer.Born;
            EC.Gender = Employer.Gender;
            EC.Unit = Employer.Unit;
            Employer = null;
            //Employers.Add(Employer);

            //context.EmployersTable.Add(ET);
            //context.EmployersTable.Add((EmployerTable)employer);

            context.SaveChanges();
        }

        private void UpdateUnit(object parameter)
        {

        }

        private void UpdateOrder(object parameter)
        {

        }

        private void CancelEmployer(object parameter)
        {
            Employer = null;
        }

        private void CancelUnit(object parameter)
        {
            Unit = null;
        }

        private void CancelOrder(object parameter)
        {
            Order = null;
        }

        private void SetSelectedEmployer(object parameter)
        {
            if (parameter != null)
            {
                EmployerClass EC = (EmployerClass)parameter;
                Employer.Id = EC.Id;
                Employer.Surname = EC.Surname;
                Employer.Name = EC.Name;
                Employer.Patronymic = EC.Patronymic;
                Employer.Born = EC.Born;
                Employer.Gender = EC.Gender;
                Employer.Unit = EC.Unit;
            }
        }

        private void SetSelectedUnit(object parameter)
        {
            if (parameter != null)
            {
                EmployerUnit EU = (EmployerUnit)parameter;
                Unit.Name = Unit.Name;
                unit.Head = Unit.Head;
            }
        }

        private void SetNewEmployer()
        {
            //TempEmployer = new EmployerClass();
            //TempEmployer.Born = DateTime.Now;
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
