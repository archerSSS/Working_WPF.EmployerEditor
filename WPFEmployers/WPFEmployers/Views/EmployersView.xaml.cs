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
    /// Логика взаимодействия для EmployersView.xaml
    /// </summary>
    public partial class EmployersView : Window
    {
        public EmployersView()
        {
            InitializeComponent();
        }

        public void SetViewModel()
        {
            DataContext = new EmployerViewModel();
        }

        private void EmployerAddView_Click(object sender, RoutedEventArgs e)
        {
            EmployerAddView EAV = new EmployerAddView();
            EAV.DataContext = DataContext;
            EAV.Show();
            Close();
        }

        private void EmployerUpdateView_Click(object sender, RoutedEventArgs e)
        {
            if (EmployerShowList.SelectedItem != null)
            {
                EmployerUpdateView EUV = new EmployerUpdateView();
                EUV.DataContext = DataContext;
                EUV.Show();
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
