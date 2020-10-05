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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        DB.Client newClient;

        public AddClient()
        {
            InitializeComponent();

            DB.DETLT2020Entities entities = new DB.DETLT2020Entities();

            newClient = new DB.Client();
            mainGrid.DataContext = newClient;
            cbGender.ItemsSource = entities.Genders.ToList();

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {


            newClient = mainGrid.DataContext as DB.Client;

            var gender = cbGender.SelectedItem as DB.Gender;

            newClient.GenderCode = gender.Code;

            newClient.RegistrationDate = dt2.DisplayDate;

            newClient.Birthday = dt.SelectedDate;


            try
            {
                DB.DETLT2020Entities entities = new DB.DETLT2020Entities();
                entities.Clients.Add(newClient);

                entities.SaveChanges();

                MessageBox.Show("сохранение прошло  успешно");

                DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
