namespace ITnetwork_Pixel_Art_Improved
{
    partial class NewProjectForm
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
            labelWidth = new Label();
            labelHeight = new Label();
            numericUpDownWidth = new NumericUpDown();
            groupBoxImageSize = new GroupBox();
            numericUpDownHeight = new NumericUpDown();
            buttonCreate = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).BeginInit();
            groupBoxImageSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).BeginInit();
            SuspendLayout();
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(84, 23);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(52, 20);
            labelWidth.TabIndex = 0;
            labelWidth.Text = "Width:";
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(79, 76);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(57, 20);
            labelHeight.TabIndex = 1;
            labelHeight.Text = "Height:";
            // 
            // numericUpDownWidth
            // 
            numericUpDownWidth.Location = new Point(35, 46);
            numericUpDownWidth.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            numericUpDownWidth.Name = "numericUpDownWidth";
            numericUpDownWidth.Size = new Size(150, 27);
            numericUpDownWidth.TabIndex = 2;
            // 
            // groupBoxImageSize
            // 
            groupBoxImageSize.Controls.Add(numericUpDownHeight);
            groupBoxImageSize.Controls.Add(labelWidth);
            groupBoxImageSize.Controls.Add(labelHeight);
            groupBoxImageSize.Controls.Add(numericUpDownWidth);
            groupBoxImageSize.Location = new Point(12, 21);
            groupBoxImageSize.Name = "groupBoxImageSize";
            groupBoxImageSize.Size = new Size(233, 156);
            groupBoxImageSize.TabIndex = 3;
            groupBoxImageSize.TabStop = false;
            // 
            // numericUpDownHeight
            // 
            numericUpDownHeight.Location = new Point(35, 99);
            numericUpDownHeight.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            numericUpDownHeight.Name = "numericUpDownHeight";
            numericUpDownHeight.Size = new Size(150, 27);
            numericUpDownHeight.TabIndex = 3;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(22, 202);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(94, 29);
            buttonCreate.TabIndex = 4;
            buttonCreate.Text = "CREATE";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.IndianRed;
            buttonCancel.FlatAppearance.BorderColor = Color.IndianRed;
            buttonCancel.FlatAppearance.BorderSize = 2;
            buttonCancel.Location = new Point(141, 202);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "CANCEL";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // NewProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 253);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCreate);
            Controls.Add(groupBoxImageSize);
            Name = "NewProjectForm";
            Text = "New Project";
            ((System.ComponentModel.ISupportInitialize)numericUpDownWidth).EndInit();
            groupBoxImageSize.ResumeLayout(false);
            groupBoxImageSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHeight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelWidth;
        private Label labelHeight;
        private NumericUpDown numericUpDownWidth;
        private GroupBox groupBoxImageSize;
        private NumericUpDown numericUpDownHeight;
        private Button buttonCreate;
        private Button buttonCancel;
    }
}