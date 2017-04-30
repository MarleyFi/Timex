namespace Timex
{
    partial class FrmAffen
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
            this.pictureBoxFarbhintergrund = new System.Windows.Forms.PictureBox();
            this.timerFarbhintergrund = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxAffe = new System.Windows.Forms.PictureBox();
            this.timerAffe = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxFarbblock = new System.Windows.Forms.PictureBox();
            this.timerFarbblock = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxFarbblock2 = new System.Windows.Forms.PictureBox();
            this.timerCubeMoving = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbhintergrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbblock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbblock2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFarbhintergrund
            // 
            this.pictureBoxFarbhintergrund.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxFarbhintergrund.Location = new System.Drawing.Point(84, 117);
            this.pictureBoxFarbhintergrund.Name = "pictureBoxFarbhintergrund";
            this.pictureBoxFarbhintergrund.Size = new System.Drawing.Size(504, 416);
            this.pictureBoxFarbhintergrund.TabIndex = 0;
            this.pictureBoxFarbhintergrund.TabStop = false;
            // 
            // timerFarbhintergrund
            // 
            this.timerFarbhintergrund.Enabled = true;
            this.timerFarbhintergrund.Interval = 1000;
            this.timerFarbhintergrund.Tick += new System.EventHandler(this.timerFarbhintergrund_Tick);
            // 
            // pictureBoxAffe
            // 
            this.pictureBoxAffe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBoxAffe.Location = new System.Drawing.Point(216, 220);
            this.pictureBoxAffe.Name = "pictureBoxAffe";
            this.pictureBoxAffe.Size = new System.Drawing.Size(238, 192);
            this.pictureBoxAffe.TabIndex = 1;
            this.pictureBoxAffe.TabStop = false;
            // 
            // timerAffe
            // 
            this.timerAffe.Enabled = true;
            this.timerAffe.Interval = 1000;
            this.timerAffe.Tick += new System.EventHandler(this.timerAffe_Tick);
            // 
            // pictureBoxFarbblock
            // 
            this.pictureBoxFarbblock.Image = global::Timex.Properties.Resources.Lila;
            this.pictureBoxFarbblock.Location = new System.Drawing.Point(84, 61);
            this.pictureBoxFarbblock.Name = "pictureBoxFarbblock";
            this.pictureBoxFarbblock.Size = new System.Drawing.Size(84, 50);
            this.pictureBoxFarbblock.TabIndex = 2;
            this.pictureBoxFarbblock.TabStop = false;
            // 
            // timerFarbblock
            // 
            this.timerFarbblock.Enabled = true;
            this.timerFarbblock.Interval = 1000;
            this.timerFarbblock.Tick += new System.EventHandler(this.timerFarbblock_Tick);
            // 
            // pictureBoxFarbblock2
            // 
            this.pictureBoxFarbblock2.Image = global::Timex.Properties.Resources.Lila;
            this.pictureBoxFarbblock2.Location = new System.Drawing.Point(594, 117);
            this.pictureBoxFarbblock2.Name = "pictureBoxFarbblock2";
            this.pictureBoxFarbblock2.Size = new System.Drawing.Size(50, 64);
            this.pictureBoxFarbblock2.TabIndex = 4;
            this.pictureBoxFarbblock2.TabStop = false;
            // 
            // timerCubeMoving
            // 
            this.timerCubeMoving.Enabled = true;
            this.timerCubeMoving.Interval = 2;
            this.timerCubeMoving.Tick += new System.EventHandler(this.timerCubeMoving_Tick_1);
            // 
            // FrmAffen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(684, 647);
            this.Controls.Add(this.pictureBoxFarbblock2);
            this.Controls.Add(this.pictureBoxFarbblock);
            this.Controls.Add(this.pictureBoxAffe);
            this.Controls.Add(this.pictureBoxFarbhintergrund);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(850, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAffen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmAffen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbhintergrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbblock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFarbblock2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFarbhintergrund;
        private System.Windows.Forms.Timer timerFarbhintergrund;
        private System.Windows.Forms.PictureBox pictureBoxAffe;
        private System.Windows.Forms.Timer timerAffe;
        private System.Windows.Forms.PictureBox pictureBoxFarbblock;
        private System.Windows.Forms.Timer timerFarbblock;
        private System.Windows.Forms.PictureBox pictureBoxFarbblock2;
        private System.Windows.Forms.Timer timerCubeMoving;
    }
}