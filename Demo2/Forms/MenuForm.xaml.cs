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

namespace Demo2.Forms
{
    /// <summary>
    /// Логика взаимодействия для MenuForm.xaml
    /// </summary>
    public partial class MenuForm : Window
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btServis_Click(object sender, RoutedEventArgs e)
        {
            Forms.ServisForm servis = new ServisForm();
            servis.Show();
            this.Close();
        }

        private void btUslugi_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
