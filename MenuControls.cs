using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TheLiberator
{
    class MenuControls : ImageBase
    {
        public MenuControls(Bitmap element) : base(element)
        {
            this.Element = element;
        }
        public Bitmap Element { get; set;}
    }
}
