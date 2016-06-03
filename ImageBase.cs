using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TheLiberator
{
    class ImageBase : IDisposable
    {
        
        private Bitmap _bitmap;
        public ImageBase(Bitmap _resource)
        {
            this._bitmap = new Bitmap(_resource);
        }
        public void Dispose()
        {
            this._bitmap.Dispose();
        }
        public void DrawImage(Graphics gph)
        {
            gph.DrawImage( this._bitmap, this.Left, this.Top);
        }

        public int Left { get; set; }
        public int Top { get; set; }

        
    }
}
