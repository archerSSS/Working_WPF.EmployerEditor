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
    /// Логика взаимодействия для UnitListView.xaml
    /// </summary>
    public partial class UnitListView : Window
    {
        public UnitListView()
        {
            InitializeComponent();
            DataContext = new EmployerViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            /*AddUnitView AUV = new AddUnitView();
            AUV.DataContext = DataContext;
            AUV.Show();
            Close();*/
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            /*EditUnitView EUV = new EditUnitView();
            EUV.DataContext = DataContext;
            EUV.Show();
            Close();*/
        }
    }
}
