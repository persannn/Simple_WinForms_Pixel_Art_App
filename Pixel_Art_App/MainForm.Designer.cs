
namespace ITnetwork_Pixel_Art_Improved
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            colorDialog = new ColorDialog();
            pictureBoxCanvas = new PictureBox();
            toolTipColors = new ToolTip(components);
            saveFileDialog = new SaveFileDialog();
            labelX = new Label();
            labelXValue = new Label();
            labelY = new Label();
            labelYValue = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSeparator2 = new ToolStripSeparator();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            paletteToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            gridCheckBoxStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            zoomLabel = new ToolStripStatusLabel();
            zoomValueLabel = new ToolStripStatusLabel();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCanvas).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            pictureBoxCanvas.Dock = DockStyle.Fill;
            pictureBoxCanvas.Location = new Point(0, 28);
            pictureBoxCanvas.Margin = new Padding(5);
            pictureBoxCanvas.MaximumSize = new Size(20000, 20000);
            pictureBoxCanvas.MinimumSize = new Size(100, 100);
            pictureBoxCanvas.Name = "pictureBoxCanvas";
            pictureBoxCanvas.Size = new Size(1030, 549);
            pictureBoxCanvas.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxCanvas.TabIndex = 5;
            pictureBoxCanvas.TabStop = false;
            pictureBoxCanvas.SizeChanged += pictureBoxCanvas_SizeChanged;
            pictureBoxCanvas.Paint += pictureBoxCanvas_Paint;
            pictureBoxCanvas.MouseClick += pictureBoxCanvas_MouseClick;
            pictureBoxCanvas.MouseDown += pictureBoxCanvas_MouseDown;
            pictureBoxCanvas.MouseMove += pictureBoxCanvas_MouseMove;
            pictureBoxCanvas.MouseUp += pictureBoxCanvas_MouseUp;
            pictureBoxCanvas.Validated += pictureBoxCanvas_Validated;
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Bitmap Image (*.bmp)|*.bmp|JPEG Image (*.jpg)|*.jpg|PNG Image (*.png)|*.png";
            // 
            // labelX
            // 
            labelX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelX.AutoSize = true;
            labelX.Location = new Point(48, 554);
            labelX.Name = "labelX";
            labelX.Size = new Size(21, 20);
            labelX.TabIndex = 11;
            labelX.Text = "X:";
            // 
            // labelXValue
            // 
            labelXValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelXValue.AutoSize = true;
            labelXValue.Location = new Point(75, 554);
            labelXValue.Name = "labelXValue";
            labelXValue.Size = new Size(0, 20);
            labelXValue.TabIndex = 12;
            // 
            // labelY
            // 
            labelY.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelY.AutoSize = true;
            labelY.Location = new Point(138, 554);
            labelY.Name = "labelY";
            labelY.Size = new Size(20, 20);
            labelY.TabIndex = 13;
            labelY.Text = "Y:";
            // 
            // labelYValue
            // 
            labelYValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelYValue.AutoSize = true;
            labelYValue.Location = new Point(164, 554);
            labelYValue.Name = "labelYValue";
            labelYValue.Size = new Size(0, 20);
            labelYValue.TabIndex = 14;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1030, 28);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveAsToolStripMenuItem, toolStripSeparator1, toolStripSeparator2 });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(181, 26);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += New;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(181, 26);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += Open;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(178, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Image = (Image)resources.GetObject("saveAsToolStripMenuItem.Image");
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(181, 26);
            saveAsToolStripMenuItem.Text = "Save &As";
            saveAsToolStripMenuItem.Click += SaveFileAs;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(178, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(178, 6);
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { paletteToolStripMenuItem, clearToolStripMenuItem, gridCheckBoxStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // paletteToolStripMenuItem
            // 
            paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
            paletteToolStripMenuItem.Size = new Size(159, 26);
            paletteToolStripMenuItem.Text = "Palette";
            paletteToolStripMenuItem.Click += paletteToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(159, 26);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += Clear;
            // 
            // gridCheckBoxStripMenuItem
            // 
            gridCheckBoxStripMenuItem.CheckOnClick = true;
            gridCheckBoxStripMenuItem.Name = "gridCheckBoxStripMenuItem";
            gridCheckBoxStripMenuItem.Size = new Size(159, 26);
            gridCheckBoxStripMenuItem.Text = "Show grid";
            gridCheckBoxStripMenuItem.CheckedChanged += CheckBoxMatrixChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, zoomLabel, zoomValueLabel });
            statusStrip1.Location = new Point(0, 551);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1030, 26);
            statusStrip1.TabIndex = 16;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(49, 20);
            toolStripStatusLabel1.Text = "Status";
            // 
            // zoomLabel
            // 
            zoomLabel.Name = "zoomLabel";
            zoomLabel.Size = new Size(56, 20);
            zoomLabel.Text = "Zoom: ";
            // 
            // zoomValueLabel
            // 
            zoomValueLabel.Name = "zoomValueLabel";
            zoomValueLabel.Size = new Size(0, 20);
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(161, 26);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(161, 26);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 577);
            Controls.Add(statusStrip1);
            Controls.Add(labelYValue);
            Controls.Add(labelY);
            Controls.Add(labelXValue);
            Controls.Add(labelX);
            Controls.Add(pictureBoxCanvas);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Pixel Art App";
            SizeChanged += MainForm_SizeChanged;
            MouseWheel += MouseWheeelScrolled;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCanvas).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColorDialog colorDialog;
        private PictureBox pictureBoxCanvas;
        private ToolTip toolTipColors;
        private SaveFileDialog saveFileDialog;
        private Label labelX;
        private Label labelXValue;
        private Label labelY;
        private Label labelYValue;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem paletteToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem gridCheckBoxStripMenuItem;
        private ToolStripStatusLabel zoomLabel;
        private ToolStripStatusLabel zoomValueLabel;
    }
}
