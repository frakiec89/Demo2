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
    /// Логика взаимодействия для ImageForms.xaml
    /// </summary>
    public partial class ImageForms : Window
    {
        public BL.ImageView Image;


        public ImageForms()
        {
            InitializeComponent();

            var image = new  BL.ImageControllercs();

            lbServis.ItemsSource = image.ImageViews;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var b = sender as  Image;
            Image = b.DataContext as BL.ImageView;
            this.DialogResult = true;
            this.Close();
        }
    }
}
