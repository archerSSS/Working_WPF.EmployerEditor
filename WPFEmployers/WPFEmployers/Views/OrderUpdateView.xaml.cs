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
    /// Логика взаимодействия для OrderUpdateView.xaml
    /// </summary>
    public partial class OrderUpdateView : Window
    {
        public OrderUpdateView()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsCombo.SelectedItem != null && EmployersCombo.SelectedItem != null)
            {
                OrderListView OLV = new OrderListView();
                OLV.DataContext = DataContext;
                OLV.Show();
                Close();
            }
            else MessageBox.Show("Введена не вся информация");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            OrderListView OLV = new OrderListView();
            OLV.DataContext = DataContext;
            OLV.Show();
            Close();
        }
    }
}
