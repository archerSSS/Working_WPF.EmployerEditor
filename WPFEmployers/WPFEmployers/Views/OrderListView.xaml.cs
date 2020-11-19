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
    /// Логика взаимодействия для OrderListView.xaml
    /// </summary>
    public partial class OrderListView : Window
    {
        public OrderListView()
        {
            InitializeComponent();
        }

        public void SetViewModel()
        {
            DataContext = new EmployerViewModel();
        }

        private void OrderAddView_Click(object sender, RoutedEventArgs e)
        {
            OrderAddView OAV = new OrderAddView();
            OAV.DataContext = DataContext;
            OAV.Show();
            Close();
        }

        private void OrderUpdateView_Click(object sender, RoutedEventArgs e)
        {
            if (OrderShowList.SelectedItem != null)
            {
                OrderUpdateView OPV = new OrderUpdateView();
                OPV.DataContext = DataContext;
                OPV.Show();
                Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainView MV = new MainView();
            MV.DataContext = DataContext;
            MV.Show();
            Close();
        }
    }
}
