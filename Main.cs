
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheLiberator.Properties;
using System.Media;
using System.Runtime.InteropServices;
namespace TheLiberator
{
   
    public partial class mainPlaygroud : Form
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        //private SoundPlayer _backgroundMusic = new SoundPlayer(Resources.Vivaldi___Spring);
        private FinalPicture _finalPicture;
        private int _firedBullet = 1;
        private string _levelMode;
        private int bullets = 100;
        private bool _DrawNewTarget = false;
        private int _hitCounter = 0;
        private bool hit = false;
        private int _gameFrame = 0;
        private int _levelValue;//Easy game level
        //_levelLavue determinate the speed of the game.( the time interval between two TargetUpdate() methods invocations)
        
        private bool _drawExplosion = false;
        private bool _isGameStarted = false;
        private int _mouseX;
        private int _mouseY;
        private Target _target;
        private MenuControls _start;
        private MenuControls _stop;
        private MenuControls _reset;
        private MenuControls _exit;
        private Explosion _explosion = new Explosion();
        
        private int _firedBullets = 0;
        public mainPlaygroud()
        {
            PlayBackgroundMusic();
            this._levelValue = 8;
            
            
            
            InitializeComponent();
            this._exit = new MenuControls(Resources.Exit_black) { Left = 900, Top = 280 };
            Bitmap cursorImg = new Bitmap(Resources.GunIcon);
            this.Cursor = CustomCursor.CreateCursor(cursorImg, cursorImg.Width / 2, cursorImg.Width / 2);

            this._reset = new MenuControls(Resources.Reset_black) {Left = 900, Top = 200};
            this._start = new MenuControls(Resources.Start_Black) { Left = 900, Top = 40 };
            this._stop = new MenuControls(Resources.Stop_black) { Left = 900,Top = 120};
            
            this._target = new Target() {Left = GetLeftPossition(),Top = GetTopPossition() };
            
        }

    
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            

            _start.DrawImage(dc);
            if(this._isGameStarted)
            {
                if (this.bullets == 0)
                {
                    this.timeGameLoop.Stop();
                    PrintFinalScore(dc);
                    
                }
                else
                {
                    PrintCurrentScore(dc);
                    
                    this._target.DrawImage(dc);
                    if (this._drawExplosion)
                    {
                        this._explosion.DrawImage(dc);
                    }
                    if (this._drawExplosion)
                    {
                        this._target.Dispose();
                        this._target = new Target() { Left = GetLeftPossition(), Top = GetTopPossition() };
                        this._drawExplosion = false;
                    }

                }

            }           
            _stop.DrawImage(dc);
            _reset.DrawImage(dc);
            _exit.DrawImage(dc);
            base.OnPaint(e);
        }
        private void timeGameLoop_Tick(object sender, EventArgs e)
        {
            
            if (this._gameFrame >=this._levelValue)
            {
                
                TargetUpdate();
                this._gameFrame = 0;
            }
            this._gameFrame++;
            this.Refresh();
        }
        private void mainPlaygroud_MouseMove(object sender, MouseEventArgs e)
        {
           
            this._mouseX = e.X;
            this._mouseY = e.Y;
            //Changing Start if selected
            if(_mouseX >= 900 && _mouseX <= 860 + 114 && _mouseY >= 40 && _mouseY <= 40 + 56)
            {
                this._start = new MenuControls(Resources.Start_red) {Left = 900,Top = 40};
                
            }
            else
            {
                this._start = new MenuControls(Resources.Start_Black) { Left = 900,Top = 40};
               
            }

            //Changing Stop if selected

            if (_mouseX >= 900 && _mouseX <= 860 + 114 && _mouseY >= 120 && _mouseY <= 120 + 56)
            {
                this._stop = new MenuControls(Resources.Stop_red) {Left = 900,Top = 120};
                
            }
            else
            {
                this._stop = new MenuControls(Resources.Stop_black) {Left = 900,Top = 120 };
                
            }

            //Changing Reset if selected
            if (_mouseX >= 900 && _mouseX <= 860 + 114 && _mouseY >= 200 && _mouseY <= 200 + 56)
            {
                this._reset = new MenuControls(Resources.Reset_red) {Left = 900,Top = 200};
                
            }
            else
            {
                this._reset = new MenuControls(Resources.Reset_black) {Left = 900,Top = 200};
            }

            //Changing Exit if Selected

            if (_mouseX >= 900 && _mouseX <= 860 + 114 && _mouseY >= 280 && _mouseY <= 280 + 56)
            {
                this._exit = new MenuControls(Resources.Exit_red) {Left = 900,Top = 280};
                
            }
            else
            {
                this._exit = new MenuControls(Resources.Exit_black) {Left = 900,Top = 280};
            }

            this.Refresh();
            
        }
        
        private void mainPlaygroud_MouseClick(object sender, MouseEventArgs e)
        {
            
            //If The Game is not Started yet 
            
            //If Player clics Start
            if (this._mouseX >= 900 && this._mouseX <= 900 + 114 && this._mouseY >= 40 && this._mouseY <= 40 + 56)
            {
                MenuSound();
                this.timeGameLoop.Start();
                this._isGameStarted = true;
                
            }
            //If Player Clics Stop
            else if (this._mouseX >= 900 && this._mouseX <= 900 + 114 && this._mouseY >= 120 && this._mouseY <= 120 + 56)
            {
                MenuSound();
                
                this.timeGameLoop.Stop();
                this.bullets = 100;
                this._hitCounter = 0;
                this._isGameStarted = false;
                
            }
            //If Player Clics Reset
            else if (this._mouseX >= 900 && this._mouseX <= 900 + 114 && this._mouseY >= 200 && this._mouseY <= 200 + 56)
            {

                MenuSound();
                this.bullets = 100;
                this._hitCounter = 0;
                this._levelValue = 8;
                this._levelMode = "OMG SUCH A NOOB";
                
                this._isGameStarted = true;
                
            }
            //If Player Clics Exit
            else if (this._mouseX >= 900 && this._mouseX <= 900 + 114 && this._mouseY >= 280 && this._mouseY <= 280 + 56)
            {
                MenuSound();
                this.Close();
            }
            else
            {
                if(this.bullets  >0)
                {
                    this.hit = this._target.Hit2(this._mouseX, this._mouseY);
                    if (hit)
                    {
                        this._drawExplosion = true;
                        this._explosion.Left = this._target.Left;
                        this._explosion.Top = this._target.Top;
                        this._hitCounter++;

                    }
                    this.bullets--;
                    this._firedBullet++;
                    this._levelMode = GameLevel(this._hitCounter);
                    ChangeGameDifficult(this._levelMode);
                    FireGun();
                    this._firedBullets++;
                }

            }
            
            
        this.Refresh();
       

        }

        
        private  int GetLeftPossition()
        {
            Random rnd = new Random();
            return rnd.Next(20, 780) + 43;
        }
        private int GetTopPossition()
        {
            Random rnd = new Random();
            return rnd.Next(100, 380) + 42;
        }

        private void FireGun()
        {
            SoundPlayer shot = new SoundPlayer(Resources.Sniper_fire);
            
            shot.Play();
        }

        private void TargetUpdate()
        {
            Random rnd = new Random();
            this._target.Update(rnd.Next(10, this.Width - 250), rnd.Next(10, this.Height - 140));
        }

        private void MenuSound()
        {
            SoundPlayer sound = new SoundPlayer(Resources.pump_shotgun_sound);
            sound.Play();
        }
        
        private string GameLevel(int number)
        {
            string returnString = string.Empty;
            if(number < 7)
            {
                returnString = "OMG SUCH A NOOB";

            }
            else if(number >= 7 && number < 20)
            {
                returnString = "NOOB";
            }
            else if(number >= 20 && number < 30)
            {
                returnString = "NOOB++";
            }
            else if(number >= 30 && number < 40)
            {
                returnString = "Avarage";
            }
            else if( number >= 40 && number < 50)
            {
                returnString = "Rebel";
            }
            else if(number >=50 && number < 60)
            {
                returnString = "Killer";
            }
            else if(number >=60 && number < 70)
            {
                returnString = "Berserker!";
            }
            else if(number >= 70 && number < 80)
            {
                returnString = "The Liberator!";
            }
            else if (number >= 80 && number < 90)
            {
                returnString = "Jedi Master";
            }
            else if(number >=90)
            {
                returnString = "The Chosen One!!!";
            }
            return returnString;

        }
        
        private void ChangeGameDifficult(string level)
        {
            if(level == "OMG SUCH A NOOB")
            {
                this._levelValue = 8;
            }
            else if(level == "NOOB")
            {
                this._levelValue = 7;
            }
            else if (level == "NOOB++")
            {
                this._levelValue = 6;
            }
            else if (level == "Avarage")
            {
                this._levelValue = 5;
            }
            else if (level == "Rebel")
            {
                this._levelValue = 5;
            }
            else if (level == "Killer")
            {
                this._levelValue = 5;
            }
            else if (level == "Berserker!")
            {
                this._levelValue = 4;
            }
            else if (level == "The Liberator!")
            {
                this._levelValue = 3;
            }
            else if (level == "Jedi Master")
            {
                this._levelValue = 2;
            }
            else if (level == "The Chosen One!!!")
            {
                this._levelValue = 2;
            }
            
        }

        private void PrintCurrentScore(Graphics dc)
        {
           
            
            TextFormatFlags flad = TextFormatFlags.Left;
            Font font = new Font("Stencil", 12, FontStyle.Italic);
            string text = String.Format("Bullets : " + this.bullets + "\n" + "Kills : " + this._hitCounter  +   "\n"+ "Level = " + this._levelMode);
            TextRenderer.DrawText(dc,text,font,new Rectangle(5,5,700,100),Color.Crimson,SystemColors.ControlText,flad);
        }

        private void PrintFinalScore(Graphics dc)
        {
            
            TextFormatFlags flad = TextFormatFlags.HorizontalCenter| TextFormatFlags.HorizontalCenter;
            Font font = new Font("Stencil", 20, FontStyle.Italic);
            string text = String.Format("Kills : " + this._hitCounter + "\n" +  "Level = " + this._levelMode);
            TextRenderer.DrawText(dc, text, font, new Rectangle(200, 30, 700, 150),Color.Red, flad);
            this._finalPicture = new FinalPicture(SelecFinalPicture(this._levelMode)) { Left = 400, Top = 200 };
            this._finalPicture.DrawImage(dc);
        }

        
        private void PlayBackgroundMusic()
        {
            mciSendString(@"open ..\..\Resources\backMusicBlade.wav type waveaudio alias applause", null, 0, IntPtr.Zero);
            mciSendString(@"play applause", null, 0, IntPtr.Zero);
        }
        
        private Bitmap SelecFinalPicture(string finalLevel)
        {
            if(finalLevel == "OMG SUCH A NOOB")
            {
                return Resources.OMGNOOB;
            }
            else if(finalLevel == "NOOB")
            {
                return Resources.Noob;
            }
            else if(finalLevel == "NOOB++")
            {
                return Resources.noobpp;
            }
            else if (finalLevel == "Avarage")
            {
                return Resources.average;
            }
            else if (finalLevel == "Rebel")
            {
                return Resources.Rebel;
            }
            else if (finalLevel == "Killer")
            {
                return Resources.Killer;
            }
            else if (finalLevel == "Berserker!")
            {
                return Resources.Berserker;
            }
            else if (finalLevel == "The Liberator!")
            {
                return Resources.TheLiberator;
            }
            else if (finalLevel == "Jedi Master")
            {
                return Resources.JediMaster;
            }
            else
            {
                return Resources.TheChosenOne;
            }
        }
    }
}
