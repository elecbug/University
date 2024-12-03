namespace HW01
{
    partial class SubForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            okButton = new Button();
            label4 = new Label();
            dateTimePicker = new DateTimePicker();
            comboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 0;
            label1.Text = "Middle Score";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 42);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 0;
            label2.Text = "Final Score";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 75);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 0;
            label3.Text = "Grade";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(129, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += TextBoxTextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(129, 39);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += TextBoxTextChanged;
            // 
            // okButton
            // 
            okButton.Location = new Point(12, 156);
            okButton.Name = "okButton";
            okButton.Size = new Size(242, 29);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OkButtonClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 113);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 0;
            label4.Text = "Date";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(59, 113);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(195, 27);
            dateTimePicker.TabIndex = 3;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            comboBox.Location = new Point(129, 72);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(125, 28);
            comboBox.TabIndex = 4;
            // 
            // SubForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(270, 197);
            Controls.Add(comboBox);
            Controls.Add(dateTimePicker);
            Controls.Add(okButton);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SubForm";
            Text = "SubForm";
            Load += SubFormLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button okButton;
        private Label label4;
        private DateTimePicker dateTimePicker;
        private ComboBox comboBox;
    }
}