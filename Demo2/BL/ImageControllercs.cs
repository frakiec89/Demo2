using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo2.BL
{
    public class ImageControllercs
    {
        public  List<ImageView> ImageViews { get; set; }

        public ImageControllercs(  )
        {
            DB.DETLT2020Entities entities = new DB.DETLT2020Entities();
            var imag = entities.Services.Select(x => x.MainImagePath).Distinct();

            ImageViews = new List<ImageView>();

            foreach (  var  s  in imag)
            {
                ImageViews.Add(new ImageView(s));
            }
        }

       


    }
}
