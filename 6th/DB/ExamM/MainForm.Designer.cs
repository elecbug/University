namespace ExamM
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
            listBox0 = new ListBox();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            listBox3 = new ListBox();
            listBox4 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            toList3Button = new Button();
            button3 = new Button();
            toList4Button = new Button();
            insert = new Button();
            edit = new Button();
            delete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            totalLabel = new Label();
            SuspendLayout();
            // 
            // listBox0
            // 
            listBox0.FormattingEnabled = true;
            listBox0.ItemHeight = 20;
            listBox0.Location = new Point(12, 36);
            listBox0.Name = "listBox0";
            listBox0.Size = new Size(138, 424);
            listBox0.TabIndex = 0;
            listBox0.SelectedIndexChanged += ListSelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(188, 36);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(138, 424);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += ListSelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 20;
            listBox2.Location = new Point(363, 38);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(138, 424);
            listBox2.TabIndex = 0;
            listBox2.SelectedIndexChanged += ListSelectedIndexChanged;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 20;
            listBox3.Location = new Point(673, 38);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(138, 424);
            listBox3.TabIndex = 0;
            listBox3.SelectedIndexChanged += ListSelectedIndexChanged;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 20;
            listBox4.Location = new Point(817, 36);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(138, 424);
            listBox4.TabIndex = 0;
            listBox4.SelectedIndexChanged += ListSelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(156, 79);
            button1.Name = "button1";
            button1.Size = new Size(26, 117);
            button1.TabIndex = 1;
            button1.Text = ">";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Upgrade;
            // 
            // button2
            // 
            button2.Location = new Point(332, 79);
            button2.Name = "button2";
            button2.Size = new Size(26, 117);
            button2.TabIndex = 1;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Upgrade;
            // 
            // button4
            // 
            button4.Location = new Point(332, 202);
            button4.Name = "button4";
            button4.Size = new Size(26, 117);
            button4.TabIndex = 1;
            button4.Text = "<";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Upgrade;
            // 
            // toList3Button
            // 
            toList3Button.Location = new Point(507, 79);
            toList3Button.Name = "toList3Button";
            toList3Button.Size = new Size(96, 117);
            toList3Button.TabIndex = 1;
            toList3Button.Text = "구매확정";
            toList3Button.UseVisualStyleBackColor = true;
            toList3Button.Click += State3;
            // 
            // button3
            // 
            button3.Location = new Point(156, 202);
            button3.Name = "button3";
            button3.Size = new Size(26, 117);
            button3.TabIndex = 1;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Upgrade;
            // 
            // toList4Button
            // 
            toList4Button.Location = new Point(507, 202);
            toList4Button.Name = "toList4Button";
            toList4Button.Size = new Size(96, 117);
            toList4Button.TabIndex = 1;
            toList4Button.Text = "환불";
            toList4Button.UseVisualStyleBackColor = true;
            toList4Button.Click += State4;
            // 
            // insert
            // 
            insert.Location = new Point(12, 466);
            insert.Name = "insert";
            insert.Size = new Size(94, 29);
            insert.TabIndex = 2;
            insert.Text = "주문추가";
            insert.UseVisualStyleBackColor = true;
            insert.Click += insert_Click;
            // 
            // edit
            // 
            edit.Location = new Point(112, 466);
            edit.Name = "edit";
            edit.Size = new Size(94, 29);
            edit.TabIndex = 2;
            edit.Text = "주문수정";
            edit.UseVisualStyleBackColor = true;
            edit.Click += edit_Click;
            // 
            // delete
            // 
            delete.Location = new Point(212, 466);
            delete.Name = "delete";
            delete.Size = new Size(94, 29);
            delete.TabIndex = 2;
            delete.Text = "주문삭제";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 3;
            label1.Text = "주문확인";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 9);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 3;
            label2.Text = "배송중";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(363, 9);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 3;
            label3.Text = "배송완료";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(673, 9);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 3;
            label4.Text = "구매확정목록";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(817, 9);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 3;
            label5.Text = "환불";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(673, 470);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(137, 20);
            totalLabel.TabIndex = 4;
            totalLabel.Text = "총 구매 확정 금액: ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 508);
            Controls.Add(totalLabel);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(delete);
            Controls.Add(edit);
            Controls.Add(insert);
            Controls.Add(toList3Button);
            Controls.Add(toList4Button);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox4);
            Controls.Add(listBox3);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(listBox0);
            Name = "MainForm";
            Text = "Form";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox0;
        private ListBox listBox1;
        private ListBox listBox2;
        private ListBox listBox3;
        private ListBox listBox4;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button toList3Button;
        private Button button3;
        private Button toList4Button;
        private Button insert;
        private Button edit;
        private Button delete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label totalLabel;
    }
}