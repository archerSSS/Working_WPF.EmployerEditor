using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;

namespace WPFEmployers.Models
{
    class OrderView : INotifyPropertyChanged
    {
        private OrderClass order;
        public OrderClass Order { get { return order; } set { order = value; OnPropertyChanged("Order"); } }

        private ObservableCollection<OrderClass> orders;
        public ObservableCollection<OrderClass> Orders { get { return orders; } set { orders = value; OnPropertyChanged("Orders"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}