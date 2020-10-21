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
    /// Логика взаимодействия для EditView.xaml
    /// </summary>
    public partial class EditView : Window
    {
        public EditView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployerViewModel EVM = ((EmployerViewModel)DataContext);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployerListView ELV = new EmployerListView(false);
            ELV.DataContext = DataContext;
            ELV.Show();
            Close();
        }
    }
}
