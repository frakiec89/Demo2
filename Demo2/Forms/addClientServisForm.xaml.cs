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
    /// Логика взаимодействия для addClientServisForm.xaml
    /// </summary>
    public partial class addClientServisForm : Window
    {
        public addClientServisForm()
        {
            InitializeComponent();

            DB.DETLT2020Entities entities = new DB.DETLT2020Entities();

            cbClient.ItemsSource = entities.Clients.ToList();
            cbServis.ItemsSource = entities.Services.ToList();


            dtMaim.Value =  DateTime.Now;
                    }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var cl =   cbClient.SelectedItem as DB.Client;
            var servis = cbServis.SelectedItem as DB.Service;
            DateTime date = dtMaim.Value.GetValueOrDefault();


            DB.DETLT2020Entities entities = new DB.DETLT2020Entities();

            var s = new DB.ClientService();

            s.ServiceID = servis.ID;
            s.ClientID = cl.ID;

            s.StartTime = date;

            s.Comment = "lyalya";


            entities.ClientServices.Add(s);

            entities.SaveChanges();

            MessageBox.Show("Запись  сохранне  в бд");
        }
    }
}
