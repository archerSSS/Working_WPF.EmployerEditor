﻿using System;
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
    /// Логика взаимодействия для EmployerAddView.xaml
    /// </summary>
    public partial class EmployerAddView : Window
    {
        public EmployerAddView()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (TextSurname.Text != "" 
                && TextName.Text != ""
                && TextPatronymic.Text != "")
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
