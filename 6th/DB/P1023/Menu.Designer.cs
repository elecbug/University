namespace P1023
{
    partial class Menu
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
            dateTimePicker = new DateTimePicker();
            menuTextBox = new RichTextBox();
            numericUpDown = new NumericUpDown();
            button1 = new Button();
            comboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(12, 12);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(250, 27);
            dateTimePicker.TabIndex = 0;
            // 
            // menuTextBox
            // 
            menuTextBox.Location = new Point(12, 82);
            menuTextBox.Name = "menuTextBox";
            menuTextBox.Size = new Size(250, 34);
            menuTextBox.TabIndex = 2;
            menuTextBox.Text = "";
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(12, 122);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(250, 27);
            numericUpDown.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(12, 155);
            button1.Name = "button1";
            button1.Size = new Size(250, 29);
            button1.TabIndex = 4;
            button1.Text = "완료";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OkClick;
            // 
            // comboBox1
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(12, 45);
            comboBox.Name = "comboBox1";
            comboBox.Size = new Size(250, 28);
            comboBox.TabIndex = 5;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 199);
            Controls.Add(comboBox);
            Controls.Add(button1);
            Controls.Add(numericUpDown);
            Controls.Add(menuTextBox);
            Controls.Add(dateTimePicker);
            Name = "Menu";
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker;
        private RichTextBox menuTextBox;
        private NumericUpDown numericUpDown;
        private Button button1;
        private ComboBox comboBox;
    }
}