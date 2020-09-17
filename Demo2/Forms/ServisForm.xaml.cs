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
    /// Логика взаимодействия для ServisForm.xaml
    /// </summary>
    public partial class ServisForm : Window
    {
        private BL.ServisController servisController;

        public ServisForm()
        {
            InitializeComponent();
            try
            {
                servisController = new BL.ServisController();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            lbServis.ItemsSource = servisController.ServisViews;

        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            Forms.MenuForm menu = new MenuForm();
            menu.Show();
            this.Close();
        }

        private void tcDel_Click(object sender, RoutedEventArgs e)
        {
            var bt = e.OriginalSource as Button;
            var serv = bt.DataContext as BL.ModelView.ServisView;
            
            var controller = new  BL.ServisController(serv);

            if ( MessageBox.Show("Вы действиетльно хотите удалить  объект" , Title="Сообщение" , MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    controller.Dellete();
                    MessageBox.Show("Удаление  прошло  успешно");
                    Refresh();
                }
                catch ( Exception ex)
                {
                    MessageBox.Show( ex.Message , "Error");
                }
            }
        }

        private void tcChange_Click(object sender, RoutedEventArgs e)
        {
            var bt = e.OriginalSource as Button;

            var serv = bt.DataContext as BL.ModelView.ServisView;

            Forms.AddEndCangeServis cange = new AddEndCangeServis(serv);
            cange.ShowDialog();
            Refresh();
        }
    
        private void btAddServis_Click(object sender, RoutedEventArgs e)
        {
            Forms.AddEndCangeServis add = new AddEndCangeServis();
            add.ShowDialog();

            if(add.DialogResult==true)
            Refresh();
        }


        private void Refresh ()
        {
            try
            {
                servisController = new BL.ServisController();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            lbServis.ItemsSource = null;
            lbServis.ItemsSource = servisController.ServisViews;
        }
    }
}
