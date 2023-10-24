namespace P1023
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
            before = new ListBox();
            doing = new ListBox();
            after = new ListBox();
            menu = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            SuspendLayout();
            // 
            // before
            // 
            before.FormattingEnabled = true;
            before.ItemHeight = 20;
            before.Location = new Point(12, 32);
            before.Name = "before";
            before.Size = new Size(154, 344);
            before.TabIndex = 0;
            before.SelectedIndexChanged += SelectedIndexChanged;
            // 
            // doing
            // 
            doing.FormattingEnabled = true;
            doing.ItemHeight = 20;
            doing.Location = new Point(218, 32);
            doing.Name = "doing";
            doing.Size = new Size(154, 344);
            doing.TabIndex = 0;
            doing.SelectedIndexChanged += SelectedIndexChanged;
            // 
            // after
            // 
            after.FormattingEnabled = true;
            after.ItemHeight = 20;
            after.Location = new Point(424, 32);
            after.Name = "after";
            after.Size = new Size(154, 344);
            after.TabIndex = 0;
            after.SelectedIndexChanged += SelectedIndexChanged;
            // 
            // menu
            // 
            menu.FormattingEnabled = true;
            menu.ItemHeight = 20;
            menu.Location = new Point(695, 32);
            menu.Name = "menu";
            menu.Size = new Size(154, 344);
            menu.TabIndex = 0;
            menu.SelectedIndexChanged += MenuSelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 1;
            label1.Text = "주문확인";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(218, 9);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "조리중";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(424, 9);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 1;
            label3.Text = "조리완료";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(695, 9);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 1;
            label4.Text = "메뉴목록";
            // 
            // button1
            // 
            button1.Location = new Point(12, 382);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "주문추가";
            button1.UseVisualStyleBackColor = true;
            button1.Click += InsertOrder;
            // 
            // button2
            // 
            button2.Location = new Point(112, 382);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "주문수정";
            button2.UseVisualStyleBackColor = true;
            button2.Click += EditOrder;
            // 
            // button3
            // 
            button3.Location = new Point(212, 382);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "주문삭제";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DeleteOrder;
            // 
            // button4
            // 
            button4.Location = new Point(855, 32);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 2;
            button4.Text = "메뉴추가";
            button4.UseVisualStyleBackColor = true;
            button4.Click += InsertMenu;
            // 
            // button5
            // 
            button5.Location = new Point(856, 67);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 2;
            button5.Text = "메뉴수정";
            button5.UseVisualStyleBackColor = true;
            button5.Click += EditMenu;
            // 
            // button6
            // 
            button6.Location = new Point(856, 102);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 2;
            button6.Text = "메뉴삭제";
            button6.UseVisualStyleBackColor = true;
            button6.Click += DeleteMenu;
            // 
            // button7
            // 
            button7.Location = new Point(172, 122);
            button7.Name = "button7";
            button7.Size = new Size(40, 79);
            button7.TabIndex = 3;
            button7.Text = ">";
            button7.UseVisualStyleBackColor = true;
            button7.Click += B2D;
            // 
            // button8
            // 
            button8.Location = new Point(172, 207);
            button8.Name = "button8";
            button8.Size = new Size(40, 79);
            button8.TabIndex = 3;
            button8.Text = "<";
            button8.UseVisualStyleBackColor = true;
            button8.Click += D2B;
            // 
            // button9
            // 
            button9.Location = new Point(378, 122);
            button9.Name = "button9";
            button9.Size = new Size(40, 79);
            button9.TabIndex = 3;
            button9.Text = ">";
            button9.UseVisualStyleBackColor = true;
            button9.Click += D2A;
            // 
            // button10
            // 
            button10.Location = new Point(378, 207);
            button10.Name = "button10";
            button10.Size = new Size(40, 79);
            button10.TabIndex = 3;
            button10.Text = "<";
            button10.UseVisualStyleBackColor = true;
            button10.Click += A2D;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 428);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menu);
            Controls.Add(after);
            Controls.Add(doing);
            Controls.Add(before);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainFormLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox before;
        private ListBox doing;
        private ListBox after;
        private ListBox menu;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
    }
}