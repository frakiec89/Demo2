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
    /// Логика взаимодействия для ClientServiceForm.xaml
    /// </summary>
    public partial class ClientServiceForm : Window
    {
        public ClientServiceForm()
        {
            InitializeComponent();
            DB.DETLT2020Entities entities = new DB.DETLT2020Entities();

            mainGrid.ItemsSource = entities.ClientServices.ToList();

        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            Forms.MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}
