using Demo2.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tbPass.Password = "admin";
            tbPass.PasswordChar = '*';
            tbLog.Text = "admin";

           
           
        }

        private void btInAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (tbPass.Password == "admin" && tbLog.Text == "admin")
            {
                Forms.MenuForm menuForm = new Forms.MenuAdmin();
                menuForm.Show();
                this.Close();
            }
        }

        private void btIn_Click(object sender, RoutedEventArgs e)
        {
            Forms.MenuForm menuForm = new Forms.MenuForm();
            menuForm.Show();
            this.Close();

        }

    }
    
}
