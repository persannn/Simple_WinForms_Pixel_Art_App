namespace ITnetwork_Pixel_Art_Improved
{
    partial class PaletteForm
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
            groupBoxPalette = new GroupBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBoxBrushColor = new PictureBox();
            groupBoxPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrushColor).BeginInit();
            SuspendLayout();
            // 
            // groupBoxPalette
            // 
            groupBoxPalette.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBoxPalette.Controls.Add(pictureBox7);
            groupBoxPalette.Controls.Add(pictureBox6);
            groupBoxPalette.Controls.Add(pictureBox5);
            groupBoxPalette.Controls.Add(pictureBox4);
            groupBoxPalette.Controls.Add(pictureBox3);
            groupBoxPalette.Controls.Add(pictureBox2);
            groupBoxPalette.Controls.Add(pictureBox1);
            groupBoxPalette.Controls.Add(pictureBoxBrushColor);
            groupBoxPalette.Location = new Point(27, 12);
            groupBoxPalette.Name = "groupBoxPalette";
            groupBoxPalette.Size = new Size(162, 116);
            groupBoxPalette.TabIndex = 5;
            groupBoxPalette.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Red;
            pictureBox7.Location = new Point(114, 66);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(24, 24);
            pictureBox7.TabIndex = 8;
            pictureBox7.TabStop = false;
            pictureBox7.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.FromArgb(255, 128, 255);
            pictureBox6.Location = new Point(114, 36);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(24, 24);
            pictureBox6.TabIndex = 7;
            pictureBox6.TabStop = false;
            pictureBox6.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Lime;
            pictureBox5.Location = new Point(84, 66);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(24, 24);
            pictureBox5.TabIndex = 6;
            pictureBox5.TabStop = false;
            pictureBox5.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Blue;
            pictureBox4.Location = new Point(84, 36);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(24, 24);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            pictureBox4.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Yellow;
            pictureBox3.Location = new Point(54, 66);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            pictureBox3.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(128, 64, 0);
            pictureBox2.Location = new Point(54, 36);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(24, 66);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // pictureBoxBrushColor
            // 
            pictureBoxBrushColor.BackColor = Color.Black;
            pictureBoxBrushColor.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxBrushColor.Location = new Point(24, 36);
            pictureBoxBrushColor.Name = "pictureBoxBrushColor";
            pictureBoxBrushColor.Size = new Size(24, 24);
            pictureBoxBrushColor.TabIndex = 0;
            pictureBoxBrushColor.TabStop = false;
            pictureBoxBrushColor.MouseClick += palettePictureBoxBrushColor_MouseClick;
            // 
            // PaletteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 140);
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = true;
            Controls.Add(groupBoxPalette);
            Name = "PaletteForm";
            Text = "Palette";
            TopMost = true;
            groupBoxPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrushColor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxPalette;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBoxBrushColor;
    }
}