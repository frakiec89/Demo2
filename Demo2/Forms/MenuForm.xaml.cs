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
            this.Title = "Привет гость";
        }

        public virtual void btServis_Click(object sender, RoutedEventArgs e)
        {
            Forms.ServisForm servis = new ServisForm();
            servis.Show();
            this.Close();
        }

        private void btUslugi_Click(object sender, RoutedEventArgs e)
        {
            Forms.ClientServiceForm servis = new ClientServiceForm();
            servis.Show();
            this.Close();
        }


        private void btUser_Click(object sender, RoutedEventArgs e)
        {
            Forms.ClienrForm clienrForm = new ClienrForm();
            clienrForm.Show();
            this.Close();
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            
        }

        private void btSetUslugi_Click(object sender, RoutedEventArgs e)
        {
            Forms.addClientServisForm form = new addClientServisForm();
            form.ShowDialog();

        }
    }

    public class  MenuAdmin: MenuForm
    {
        
        public MenuAdmin ()
        {
            this.Title = "Привет  админ";
        }

        public override void btServis_Click(object sender, RoutedEventArgs e)
        {
            Forms.ServisForm servis = new AdminServisForm();
            servis.Show();
            this.Close();
        }
    }
}
