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

namespace WPFEmployers.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployersView.xaml
    /// </summary>
    public partial class EmployersView : Window
    {
        public EmployersView()
        {
            InitializeComponent();
        }

        private void EmployerAddView_Click(object sender, RoutedEventArgs e)
        {
            //EmployerListView ELV = new EmployerListView();
            //ELV.Show();
            EmployerAddView EAV = new EmployerAddView();
            
            EAV.Show();
            Close();
        }

        private void EmployerUpdateView_Click(object sender, RoutedEventArgs e)
        {
            //EmployerListView ELV = new EmployerListView();
            //ELV.Show();
            EmployerAddView EAV = new EmployerAddView();
            EAV.Show();
            Close();
        }
    }
}
