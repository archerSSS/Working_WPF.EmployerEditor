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
    /// Логика взаимодействия для EmployerUpdateView.xaml
    /// </summary>
    public partial class EmployerUpdateView : Window
    {
        public EmployerUpdateView()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (TextSurname.Text != ""
                && TextName.Text != ""
                && TextPatronymic.Text != ""
                && CalendarBorn.SelectedDate != null
                && ((DateTime)CalendarBorn.SelectedDate).Year > 1899
                && ComboUnit.SelectedItem != null)
            {
                EmployersView EV = new EmployersView();
                EV.DataContext = DataContext;
                EV.Show();
                Close();
            }
            else MessageBox.Show("Неполноценная информация, либо введена неверно.");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            EmployersView EV = new EmployersView();
            EV.DataContext = DataContext;
            EV.Show();
            Close();
        }
    }
}
