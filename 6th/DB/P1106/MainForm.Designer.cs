namespace P1106
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
            CreateBtn = new Button();
            ListLBox = new ListBox();
            DetailLBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            TotalLbl = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // CreateBtn
            // 
            CreateBtn.Location = new Point(12, 12);
            CreateBtn.Name = "CreateBtn";
            CreateBtn.Size = new Size(94, 29);
            CreateBtn.TabIndex = 0;
            CreateBtn.Text = "주문생성";
            CreateBtn.UseVisualStyleBackColor = true;
            CreateBtn.Click += CreateBtn_Click;
            // 
            // ListLBox
            // 
            ListLBox.FormattingEnabled = true;
            ListLBox.ItemHeight = 20;
            ListLBox.Location = new Point(12, 74);
            ListLBox.Name = "ListLBox";
            ListLBox.Size = new Size(191, 364);
            ListLBox.TabIndex = 1;
            // 
            // DetailLBox
            // 
            DetailLBox.FormattingEnabled = true;
            DetailLBox.ItemHeight = 20;
            DetailLBox.Location = new Point(209, 74);
            DetailLBox.Name = "DetailLBox";
            DetailLBox.Size = new Size(191, 224);
            DetailLBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 51);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 2;
            label1.Text = "주문목록";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 51);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 2;
            label2.Text = "주문상세";
            // 
            // TotalLbl
            // 
            TotalLbl.Location = new Point(209, 412);
            TotalLbl.Name = "TotalLbl";
            TotalLbl.Size = new Size(191, 26);
            TotalLbl.TabIndex = 3;
            TotalLbl.Text = "원";
            TotalLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(209, 301);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 4;
            label3.Text = "주문합계";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(TotalLbl);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DetailLBox);
            Controls.Add(ListLBox);
            Controls.Add(CreateBtn);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateBtn;
        private ListBox ListLBox;
        private ListBox DetailLBox;
        private Label label1;
        private Label label2;
        private Label TotalLbl;
        private Label label3;
    }
}