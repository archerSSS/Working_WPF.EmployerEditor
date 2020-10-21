using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFEmployers.Models;
using WPFEmployers.ViewModels;

namespace WPFEmployers.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployerListView.xaml
    /// </summary>
    public partial class EmployerListView : Window
    {
        public EmployerListView()
        {
            InitializeComponent();
            DataContext = new EmployerViewModel();
        }

        public EmployerListView(bool b)
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EmployerShowList.SelectedItem != null)
            {
                EditView EV = new EditView();
                EV.DataContext = DataContext;
                EV.Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
