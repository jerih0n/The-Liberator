namespace TheLiberator
{
    partial class mainPlaygroud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainPlaygroud));
            this.timeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timeGameLoop
            // 
            this.timeGameLoop.Tick += new System.EventHandler(this.timeGameLoop_Tick);
            // 
            // mainPlaygroud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheLiberator.Properties.Resources.BackgroindImg;
            this.ClientSize = new System.Drawing.Size(1076, 499);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1092, 537);
            this.MinimumSize = new System.Drawing.Size(1092, 537);
            this.Name = "mainPlaygroud";
            this.Text = "The Liberator";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainPlaygroud_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPlaygroud_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timeGameLoop;
    }
}

