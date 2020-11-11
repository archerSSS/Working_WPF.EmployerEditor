using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFEmployers.ViewModels;

namespace WPFEmployers.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void EmployersView_Click(object sender, RoutedEventArgs e)
        {
            EmployersView EV = new EmployersView();
            EV.SetViewModel();
            EV.Show();
            Close();
        }
        private void UnitsView_Click(object sender, RoutedEventArgs e)
        {
            UnitListView ULV = new UnitListView();
            ULV.SetViewModel();
            ULV.Show();
            Close();
        }
        private void OrdersView_Click(object sender, RoutedEventArgs e)
        {
            OrderListView OLV = new OrderListView();
            OLV.SetViewModel();
            OLV.Show();
            Close();
        }
    }
}
