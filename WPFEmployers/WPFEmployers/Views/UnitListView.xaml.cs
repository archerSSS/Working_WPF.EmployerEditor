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
        }

        public void SetViewModel()
        {
            DataContext = new EmployerViewModel();
        }

        private void UnitAddView_Click(object sender, RoutedEventArgs e)
        {
            UnitAddView UAV = new UnitAddView();
            UAV.DataContext = DataContext;
            UAV.Show();
            Close();
        }

        private void UnitUpdateView_Click(object sender, RoutedEventArgs e)
        {
            if (UnitShowList.SelectedItem != null)
            {
                UnitUpdateView UUV = new UnitUpdateView();
                UUV.DataContext = DataContext;
                UUV.Show();
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
