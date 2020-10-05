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
        protected BL.ServisController servisController;

        public ServisForm()
        {
            InitializeComponent();
            try
            {
                servisController = new BL.ServisController();
                btAddServis.Visibility = Visibility.Hidden;
                this.Title = "Гость";
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
        protected virtual void Refresh ()
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

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           var s = servisController.ServisViews.Where(t => t.Title.ToUpper().StartsWith(tbSearch.Text.ToUpper())).ToList();
            var sDop = servisController.ServisViews.Where(t => t.Title.ToUpper().Contains(tbSearch.Text.ToUpper())).ToList();
            s.AddRange(sDop);
            s.Distinct();
;            lbServis.ItemsSource = s;

        }

        private void btUp_Click(object sender, RoutedEventArgs e)
        {
            var s = servisController.ServisViews.OrderBy(x => x.Title);
            lbServis.ItemsSource = s;
        }

        private void btDn_Click(object sender, RoutedEventArgs e)
        {
            var s = servisController.ServisViews.OrderByDescending(x => x.Title);
            lbServis.ItemsSource = s;
        }

        private void btDnCost_Click(object sender, RoutedEventArgs e)
        {
            var s = servisController.ServisViews.OrderBy(x => x.CostSort);
            lbServis.ItemsSource = s;
        }

        private void btUpCost_Click(object sender, RoutedEventArgs e)
        {
            var s = servisController.ServisViews.OrderByDescending(x => x.CostSort);
            lbServis.ItemsSource = s;
        }

        private void btUpDiscount_Click(object sender, RoutedEventArgs e)
        {
            var s = servisController.ServisViews.OrderByDescending(x => x.DiscountSort);
            lbServis.ItemsSource = s;
        }
    }

    public class  AdminServisForm : ServisForm
    {
        public AdminServisForm ()
        {
            Fisable();
        }


        private void Fisable()
        {
            foreach (var item in servisController.ServisViews)
            {
                item.btDell = "Visible";
                item.btChange = "Visible";
            }

            btAddServis.Visibility = Visibility.Visible;
            this.Title = "Админ";
        }

        protected override void Refresh()
        {
            base.Refresh();
            foreach (var item in servisController.ServisViews)
            {
                item.btDell = "Visible";
                item.btChange = "Visible";
            }
        }
    }
}
