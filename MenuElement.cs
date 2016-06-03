using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TheLiberator.Resources
{
    class MenuElement : ImageBase
    {
        //For every Menu Element
        public MenuElement(Bitmap map) : base(map)
        {
            this.MenuElementPic = map;
        }
        public Bitmap MenuElementPic { get; set; }
    }
}
