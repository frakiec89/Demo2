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
    /// Логика взаимодействия для AddEndCangeServis.xaml
    /// </summary>
    public partial class AddEndCangeServis : Window
    {
        private DB.Service service = new DB.Service();

        
        public AddEndCangeServis()
        {
            InitializeComponent();
            service.MainImagePath = @"pack://application:,,,/images\No.jpg.bmp";
            mainGrid.DataContext = service;
        }

        public  AddEndCangeServis ( BL.ModelView.ServisView view)
        {
            InitializeComponent();
           
            try
            {
                var cn = new BL.ServisController(view);
                service = cn.Service;
                mainGrid.DataContext = service;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void tbSave_Click(object sender, RoutedEventArgs e)
        {
            service = mainGrid.DataContext as DB.Service;
            if (service != null )
            {
                try
                {
                    var s = new BL.ServisController(service);
                    s.AddServis();
                    MessageBox.Show("Сохранение  прошло  успешно ");
                    this.DialogResult = true;
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message , "Error");
                }
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Forms.ImageForms forms = new ImageForms();
            forms.ShowDialog();
            
            if (  forms.DialogResult == true )
            {
                service.MainImagePath = forms.Image.MainImagePath;
                mainGrid.DataContext = null;
                mainGrid.DataContext = service;
            }
        }
    }
}
