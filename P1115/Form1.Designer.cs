namespace P1115
{
    partial class Form1
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
            contactListBox = new ListBox();
            callLogListBox = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            AllCallLogList = new ListBox();
            SuspendLayout();
            // 
            // contactListBox
            // 
            contactListBox.FormattingEnabled = true;
            contactListBox.ItemHeight = 20;
            contactListBox.Location = new Point(12, 12);
            contactListBox.Name = "contactListBox";
            contactListBox.Size = new Size(278, 424);
            contactListBox.TabIndex = 0;
            contactListBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // callLogListBox
            // 
            callLogListBox.FormattingEnabled = true;
            callLogListBox.ItemHeight = 20;
            callLogListBox.Location = new Point(296, 12);
            callLogListBox.Name = "callLogListBox";
            callLogListBox.Size = new Size(287, 424);
            callLogListBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(589, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += add_button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(589, 47);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += delete_button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(589, 82);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += edit_button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(589, 117);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // button4
            // 
            button4.Location = new Point(720, 115);
            button4.Name = "button4";
            button4.Size = new Size(32, 29);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += search_button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(589, 150);
            button5.Name = "button5";
            button5.Size = new Size(199, 29);
            button5.TabIndex = 5;
            button5.Text = "View all Call log";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // AllCallLogList
            // 
            AllCallLogList.FormattingEnabled = true;
            AllCallLogList.ItemHeight = 20;
            AllCallLogList.Location = new Point(589, 185);
            AllCallLogList.Name = "AllCallLogList";
            AllCallLogList.Size = new Size(411, 244);
            AllCallLogList.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 450);
            Controls.Add(AllCallLogList);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(callLogListBox);
            Controls.Add(contactListBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox contactListBox;
        private ListBox callLogListBox;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Button button4;
        private Button button5;
        private ListBox AllCallLogList;
    }
}