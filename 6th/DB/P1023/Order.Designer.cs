namespace P1023
{
    partial class Order
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
            phoneTextBox = new RichTextBox();
            typeComboBox = new ComboBox();
            stateComboBox = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(12, 12);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(250, 27);
            dateTimePicker.TabIndex = 0;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(12, 45);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(250, 31);
            phoneTextBox.TabIndex = 1;
            phoneTextBox.Text = "";
            phoneTextBox.KeyPress += TextBoxPreviewKeyDown;
            // 
            // typeComboBox
            // 
            typeComboBox.AutoCompleteCustomSource.AddRange(new string[] { "포장", "배달" });
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Items.AddRange(new object[] { "포장", "배달" });
            typeComboBox.Location = new Point(12, 82);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(250, 28);
            typeComboBox.TabIndex = 2;
            typeComboBox.Text = "주문타입";
            // 
            // stateComboBox
            // 
            stateComboBox.AutoCompleteCustomSource.AddRange(new string[] { "주문확인", "조리중", "조리완료" });
            stateComboBox.FormattingEnabled = true;
            stateComboBox.Items.AddRange(new object[] { "주문확인", "조리중", "조리완료" });
            stateComboBox.Location = new Point(12, 116);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(250, 28);
            stateComboBox.TabIndex = 2;
            stateComboBox.Text = "주문상태";
            // 
            // button1
            // 
            button1.Location = new Point(12, 150);
            button1.Name = "button1";
            button1.Size = new Size(250, 29);
            button1.TabIndex = 3;
            button1.Text = "완료";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OkClick;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 197);
            Controls.Add(button1);
            Controls.Add(stateComboBox);
            Controls.Add(typeComboBox);
            Controls.Add(phoneTextBox);
            Controls.Add(dateTimePicker);
            Name = "Order";
            Text = "Order";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker;
        private RichTextBox phoneTextBox;
        private ComboBox typeComboBox;
        private ComboBox stateComboBox;
        private Button button1;
    }
}