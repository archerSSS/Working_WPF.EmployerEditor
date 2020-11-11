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
    /// Логика взаимодействия для UnitAddView.xaml
    /// </summary>
    public partial class UnitAddView : Window
    {
        public UnitAddView()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TextName.Text != "" && ComboEmployers.SelectedItem != null)
            {
                UnitListView ULV = new UnitListView();
                ULV.DataContext = DataContext;
                ULV.Show();
                Close();
            }
            else MessageBox.Show("Введена не вся информация");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            UnitListView ULV = new UnitListView();
            ULV.DataContext = DataContext;
            ULV.Show();
            Close();
        }
    }
}
