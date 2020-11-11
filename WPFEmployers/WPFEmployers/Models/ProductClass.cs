using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEmployers.Models
{
    public class ProductClass : INotifyPropertyChanged
    {
        private int id;
        private string name;

        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); }  }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string pn)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pn));
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
