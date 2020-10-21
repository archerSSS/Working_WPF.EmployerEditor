using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEmployers.Models;

namespace WPFEmployers.ViewModels
{
    class UnitView : INotifyPropertyChanged
    {
        private ObservableCollection<EmployerUnit> units;
        public ObservableCollection<EmployerUnit> Units
        {
            get { if (units == null) GetUnits(); return units; }
            set { units = value; OnPropertyChanged("Units"); }
        }

        private void GetUnits()
        {
            //ObservableCollection<EmployerUnit> OC = new ObservableCollection<EmployerUnit>();
            var entities = new EmployerBaseEntities();
            var unitList = entities.UnitsTable.ToList();
            foreach (UnitsTable UT in unitList)
            {
                
            }

            //return OC;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string pn)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(pn));
        }
    }
}
