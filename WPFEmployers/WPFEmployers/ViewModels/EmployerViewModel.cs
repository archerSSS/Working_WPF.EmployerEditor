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
        private EmployerUnit unit;
        private EmployerOrder order;
        private ProductClass product;
        private ObservableCollection<EmployerClass> employers;
        private ObservableCollection<EmployerUnit> units;
        private ObservableCollection<EmployerOrder> orders;
        private ObservableCollection<ProductClass> products;

        private EmployerBase context;

        public EmployerClass Employer
        {
            get { return employer; }
            set { employer = value; OnPropertyChanged("Employer"); }
        }
        public EmployerUnit Unit
        {
            get { return unit; }
            set { unit = value; OnPropertyChanged("Unit"); }
        }
        public EmployerOrder Order
        {
            get { return order; }
            set { order = value; OnPropertyChanged("Order"); }
        }
        public ProductClass Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); }
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
        public ObservableCollection<EmployerOrder> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged("Orders"); }
        }
        public ObservableCollection<ProductClass> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged("Products"); }
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
        private ICommand commandSelectEmployer;
        private ICommand commandNewEmployer;
        private ICommand commandSelectUnit;
        private ICommand commandNewUnit;
        private ICommand commandSelectOrder;
        private ICommand commandNewOrder;

        public ICommand CommandAddEmployer { get { if (commandAddEmployer == null) { commandAddEmployer = new DBEditCommand(AddEmployer, Executable); } return commandAddEmployer; } }
        public ICommand CommandUpdateEmployer { get { if (commandUpdateEmployer == null) { commandUpdateEmployer = new DBEditCommand(UpdateEmployer, Executable); } return commandUpdateEmployer; } }
        public ICommand CommandAddUnit { get { if (commandAddUnit == null) { commandAddUnit = new DBEditCommand(AddUnit, Executable); } return commandAddUnit; } }
        public ICommand CommandUpdateUnit { get { if (commandUpdateUnit == null) { commandUpdateUnit = new DBEditCommand(UpdateUnit, Executable); } return commandUpdateUnit; } }
        public ICommand CommandAddOrder { get { if (commandAddOrder == null) { commandAddOrder = new DBEditCommand(AddOrder, Executable); } return commandAddOrder; } }
        public ICommand CommandUpdateOrder { get { if (commandUpdateOrder == null) { commandUpdateOrder = new DBEditCommand(UpdateOrder, Executable); } return commandUpdateOrder; } }
        public ICommand CommandCancelEmployer { get { if (commandCancelEmployer == null) { commandCancelEmployer = new DBEditCommand(CancelEmployer, Executable); } return commandCancelEmployer; } }
        public ICommand CommandCancelUnit { get { if (commandCancelUnit == null) { commandCancelUnit = new DBEditCommand(CancelUnit, Executable); } return commandCancelUnit; } }
        public ICommand CommandCancelOrder { get { if (commandCancelOrder == null) { commandCancelOrder = new DBEditCommand(CancelOrder, Executable); } return commandCancelOrder; } }
        public ICommand CommandSelectEmployer { get { if (commandSelectEmployer == null) { commandSelectEmployer = new DBEditCommand(SetSelectedEmployer, Executable); } return commandSelectEmployer; } }
        public ICommand CommandNewEmployer { get { if (commandNewEmployer == null) { commandNewEmployer = new DBEditCommand(SetNewEmployer, Executable); } return commandNewEmployer; } }
        public ICommand CommandSelectUnit { get { if (commandSelectUnit == null) { commandSelectUnit = new DBEditCommand(SetSelectedUnit, Executable); } return commandSelectUnit; } }
        public ICommand CommandNewUnit { get { if (commandNewUnit == null) { commandNewUnit = new DBEditCommand(SetNewUnit, Executable); } return commandNewUnit; } }
        public ICommand CommandSelectOrder { get { if (commandSelectOrder == null) { commandSelectOrder = new DBEditCommand(SetSelectedOrder, Executable); } return commandSelectOrder; } }
        public ICommand CommandNewOrder { get { if (commandNewOrder == null) { commandNewOrder = new DBEditCommand(SetNewOrder, Executable); } return commandNewOrder; } }

        public EmployerViewModel()
        {
            if (employers == null) employers = GetEmployersContext();
            if (units == null) units = GetUnitsContext();
            if (orders == null) orders = GetOrdersContext();
            if (products == null) products = GetProductsContext();
        }

        public EmployerViewModel(EmployerClass parameter)
        {
            if (employers == null) employers = GetEmployersContext();
            if (units == null) units = GetUnitsContext();
            if (parameter != null) employers.Add(parameter);
        }

        private ObservableCollection<EmployerClass> GetEmployersContext()
        {
            ObservableCollection<EmployerClass> OC = new ObservableCollection<EmployerClass>();
            context = new EmployerBase();

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

        private ObservableCollection<EmployerUnit> GetUnitsContext()
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

        private ObservableCollection<EmployerOrder> GetOrdersContext()
        {
            ObservableCollection<EmployerOrder> OC = new ObservableCollection<EmployerOrder>();
            var orderList = context.OrdersTable.ToList();
            foreach (OrdersTable OT in orderList)
            {
                EmployerOrder EO = new EmployerOrder() 
                { 
                    Id = OT.Номер, 
                    Name = OT.Название_товара,
                    Employer = Employers.Single(e => e.Id == OT.Сотрудник_ID)
                };
                OC.Add(EO);
            }
            return OC;
        }

        private ObservableCollection<ProductClass> GetProductsContext()
        {
            ObservableCollection<ProductClass> OC = new ObservableCollection<ProductClass>();
            var productList = context.ProductsTable;
            foreach (ProductsTable PT in productList)
            {
                ProductClass PC = new ProductClass();
                PC.Id = PT.Товар_ID;
                PC.Name = PT.Название_товара;
                OC.Add(PC);
            }
            return OC;
        }

        private void AddEmployer(object parameter)
        {
            if (Employer != null
                && Employer.Surname != null 
                && Employer.Name != null 
                && Employer.Patronymic != null)
            {
                EmployersTable ET = new EmployersTable();
                ET.Фамилия = Employer.Surname;
                ET.Имя = Employer.Name;
                ET.Отчество = Employer.Patronymic;
                ET.Дата_рождения = Employer.Born;
                ET.Пол = Employer.Gender.ToString();
                if (Employer.Unit != null) ET.Подразделение = Employer.Unit.ToString();

                context.EmployersTable.Add(ET);
                context.SaveChanges();

                Employer.Id = ET.Сотрудник_ID;
                Employers.Add(Employer);
                Employer = null;
            }
        }

        private void AddUnit(object parameter)
        {
            if (Unit != null
                && Unit.Name != null
                && Unit.Head != null)
            {
                UnitsTable UT = new UnitsTable();
                UT.Название = Unit.Name;
                if (Unit.Head != null) UT.Руководитель = Unit.Head.Id;

                Units.Add(Unit);
                Unit = null;

                context.UnitsTable.Add(UT);
                context.SaveChanges();
            }
        }

        private void AddOrder(object parameter)
        {
            if (Order != null 
                && Order.Name != null 
                && Order.Employer != null)
            {
                OrdersTable OT = new OrdersTable();
                OT.Название_товара = Order.Name;
                OT.Сотрудник_ID = Order.Employer.Id;

                context.OrdersTable.Add(OT);
                context.SaveChanges();

                Order.Id = OT.Номер;
                Orders.Add(Order);
                Order = null;
            }
        }

        private void UpdateEmployer(object parameter)
        {
            if (Employer != null
                && Employer.Surname != ""
                && Employer.Name != ""
                && Employer.Patronymic != ""
                && Employer.Born != null)
            {
                EmployersTable ET = context.EmployersTable.Single(e => e.Сотрудник_ID == Employer.Id);
                ET.Фамилия = Employer.Surname;
                ET.Имя = Employer.Name;
                ET.Отчество = Employer.Patronymic;
                ET.Дата_рождения = Employer.Born;
                ET.Пол = Employer.Gender.ToString();
                if (Employer.Unit != null) ET.Подразделение = Employer.Unit.ToString();

                EmployerClass EC = Employers.Single(e => e.Id == Employer.Id);
                EC.Surname = Employer.Surname;
                EC.Name = Employer.Name;
                EC.Patronymic = Employer.Patronymic;
                EC.Born = Employer.Born;
                EC.Gender = Employer.Gender;
                EC.Unit = Employer.Unit;
                Employer = null;

                context.SaveChanges();
            }
        }

        private void UpdateUnit(object parameter)
        {
            if (Unit != null
                && Unit.Name != null
                && Unit.Head != null)
            {
                UnitsTable UT = context.UnitsTable.Single(u => u.Название == Unit.Name);
                EmployerUnit EU = Units.Single(u => u.Name == Unit.Name);
                UT.Название = Unit.Name;
                UT.Руководитель = Unit.Head.Id;
                EU.Name = Unit.Name;
                EU.Head = Unit.Head;
                Unit = null;

                context.SaveChanges();
            }
        }

        private void UpdateOrder(object parameter)
        {
            if (Order != null
                && Order.Name != null
                && Order.Employer != null)
            {
                OrdersTable OT = context.OrdersTable.Single(o => o.Номер == Order.Id);
                EmployerOrder EO = Orders.Single(o => o.Id == Order.Id);
                OT.Название_товара = Product.Name;
                OT.Сотрудник_ID = Order.Employer.Id;
                EO.Name = Product.Name;
                EO.Employer = Order.Employer;
                Order = null;
                Product = null;

                context.SaveChanges();
            }
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
            Product = null;
        }

        private void SetNewEmployer(object parameter)
        {
            Employer = new EmployerClass();
            Employer.Born = DateTime.Now;
        }

        private void SetNewUnit(object parameter)
        {
            Unit = new EmployerUnit();
        }

        private void SetNewOrder(object parameter)
        {
            Order = new EmployerOrder();
        }

        private void SetSelectedEmployer(object parameter)
        {
            if (parameter != null)
            {
                EmployerClass EC = (EmployerClass)parameter;
                Employer = new EmployerClass();
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
                Unit = new EmployerUnit();
                Unit.Name = EU.Name;
                Unit.Head = EU.Head;
            }
        }

        private void SetSelectedOrder(object parameter)
        {
            if (parameter != null)
            {
                EmployerOrder EO = (EmployerOrder)parameter;
                Order = new EmployerOrder();
                Product = Products.Single(p => p.Name == EO.Name);
                Order.Id = EO.Id;
                Order.Name = EO.Name;
                Order.Employer = EO.Employer;
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
