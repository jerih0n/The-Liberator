using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TheLiberator.Properties;
namespace TheLiberator
{
    class Target : ImageBase
    {
        private Rectangle _target = new Rectangle();
        public Target() : base(GetImage())
        {
            _target.X = base.Left;
            _target.Y = base.Top;
            _target.Width = 20;
            _target.Height = 20;
        }

        public void Update(int x, int y)
        {
            Left = x;
            Top = y;
            this._target.X = Left +11;
            this._target.Y = Top + 3;
        }
        private static Bitmap GetImage()
        {
            Random rnd = new Random();
            
            int randomNumber = rnd.Next(1, 9);
            if(randomNumber == 1)
            {
                return Resources.robot1;
            }
            if (randomNumber == 2)
            {
                return Resources.robot2;
            }
            if (randomNumber == 3)
            {
                return Resources.robot3;
            }
            if (randomNumber == 4)
            {
                return Resources.robot4;
            }
            if (randomNumber == 5)
            {
                return Resources.robot5;
            }
            if (randomNumber == 6)
            {
                return Resources.robot6;
            }
            if (randomNumber == 7)
            {
                return Resources.robot7;
            }
            if (randomNumber == 8)
            {
                return Resources.robot8;
            }
            else
            {
                return Resources.robot5;
            }
        }
        public bool Hit(int x, int y)
        {
            Rectangle rec = new Rectangle(x,y,1,1);
            if(_target.Contains(rec))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool Hit2(int mouseX, int mouseY)
        {
            if(mouseX >= this.Left && mouseX <= this.Left + 100 && mouseY >= this.Top && mouseY <= this.Top + 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
