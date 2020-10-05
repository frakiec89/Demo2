using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для ClienrForm.xaml
    /// </summary>
    public partial class ClienrForm : Window
    {
        DB.DETLT2020Entities entities;
        List<DB.Client> clients;

        public ClienrForm()
        {
            InitializeComponent();
            Refresh();
            mainGrid.RowEditEnding += MainGrid_RowEditEnding;
        }


        private void Refresh()
        {
            entities = new DB.DETLT2020Entities();
            clients = new List<DB.Client>(entities.Clients.ToList());
            mainGrid.ItemsSource = clients;
        }

        private void MainGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
                var s = e.Row;
                var c = s.Item as DB.Client;
                entities.Clients.AddOrUpdate(c);
                entities.SaveChanges();
                Refresh();
           
        }

        private void MainGrid_DragEnter(object sender, DragEventArgs e)
        {
            var ss = e.OriginalSource as DataGridRow;

            var c = ss.DataContext as DB.Client;

            entities.Clients.AddOrUpdate(c);
            entities.SaveChanges();
            MessageBox.Show("Гуд  Саве");
        }


       
        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            Forms.MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            Forms.AddClient addClient = new AddClient();
            if ( addClient.ShowDialog() == true)
            {
                Refresh();
            }

        }
    }
}
