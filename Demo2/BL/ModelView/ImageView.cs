using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.BL
{
    public class ImageView
    {
        public string MainImagePath { get; set; }
        
        public ImageView ( string path)
        {
            MainImagePath = path;
        }
    }
}
