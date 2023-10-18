namespace P1018
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
            groupBox1 = new GroupBox();
            before = new ListBox();
            groupBox2 = new GroupBox();
            after = new ListBox();
            dateTimePicker = new DateTimePicker();
            textBox = new TextBox();
            clear = new CheckBox();
            add = new Button();
            edit = new Button();
            remove = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(before);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "할 일";
            // 
            // before
            // 
            before.FormattingEnabled = true;
            before.ItemHeight = 20;
            before.Location = new Point(6, 26);
            before.Name = "before";
            before.Size = new Size(244, 384);
            before.TabIndex = 0;
            before.SelectedIndexChanged += SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(after);
            groupBox2.Location = new Point(268, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 426);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "한 일";
            // 
            // after
            // 
            after.FormattingEnabled = true;
            after.ItemHeight = 20;
            after.Location = new Point(6, 26);
            after.Name = "after";
            after.Size = new Size(238, 384);
            after.TabIndex = 0;
            after.SelectedIndexChanged += SelectedIndexChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(524, 26);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(246, 27);
            dateTimePicker.TabIndex = 1;
            // 
            // textBox
            // 
            textBox.Location = new Point(524, 59);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.Size = new Size(246, 255);
            textBox.TabIndex = 2;
            // 
            // clear
            // 
            clear.AutoSize = true;
            clear.Location = new Point(524, 320);
            clear.Name = "clear";
            clear.Size = new Size(61, 24);
            clear.TabIndex = 3;
            clear.Text = "완료";
            clear.UseVisualStyleBackColor = true;
            clear.CheckedChanged += clear_CheckedChanged;
            // 
            // add
            // 
            add.Location = new Point(524, 393);
            add.Name = "add";
            add.Size = new Size(76, 29);
            add.TabIndex = 4;
            add.Text = "추가";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // edit
            // 
            edit.Location = new Point(606, 393);
            edit.Name = "edit";
            edit.Size = new Size(82, 29);
            edit.TabIndex = 4;
            edit.Text = "수정";
            edit.UseVisualStyleBackColor = true;
            edit.Click += edit_Click;
            // 
            // remove
            // 
            remove.Location = new Point(694, 393);
            remove.Name = "remove";
            remove.Size = new Size(76, 29);
            remove.TabIndex = 4;
            remove.Text = "삭제";
            remove.UseVisualStyleBackColor = true;
            remove.Click += remove_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 450);
            Controls.Add(remove);
            Controls.Add(edit);
            Controls.Add(add);
            Controls.Add(clear);
            Controls.Add(textBox);
            Controls.Add(dateTimePicker);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox before;
        private GroupBox groupBox2;
        private ListBox after;
        private DateTimePicker dateTimePicker;
        private TextBox textBox;
        private CheckBox clear;
        private Button add;
        private Button edit;
        private Button remove;
    }
}