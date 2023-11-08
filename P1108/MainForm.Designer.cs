namespace P1108
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
            MemberLBox = new ListBox();
            BookLBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            StartDate = new DateTimePicker();
            EndDate = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            TotalLbl = new Label();
            SelectBtn = new Button();
            DeselectBtn = new Button();
            label5 = new Label();
            SelectLBox = new ListBox();
            SuspendLayout();
            // 
            // MemberLBox
            // 
            MemberLBox.FormattingEnabled = true;
            MemberLBox.ItemHeight = 20;
            MemberLBox.Location = new Point(12, 54);
            MemberLBox.Name = "MemberLBox";
            MemberLBox.Size = new Size(118, 384);
            MemberLBox.TabIndex = 0;
            MemberLBox.SelectedIndexChanged += LBox_SelectedIndexChanged;
            // 
            // BookLBox
            // 
            BookLBox.FormattingEnabled = true;
            BookLBox.ItemHeight = 20;
            BookLBox.Location = new Point(136, 54);
            BookLBox.Name = "BookLBox";
            BookLBox.Size = new Size(118, 384);
            BookLBox.TabIndex = 0;
            BookLBox.SelectedIndexChanged += LBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "회원";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 31);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 1;
            label2.Text = "대여 가능 도서";
            // 
            // StartDate
            // 
            StartDate.Location = new Point(538, 54);
            StartDate.Name = "StartDate";
            StartDate.Size = new Size(250, 27);
            StartDate.TabIndex = 2;
            // 
            // EndDate
            // 
            EndDate.Location = new Point(538, 87);
            EndDate.Name = "EndDate";
            EndDate.Size = new Size(250, 27);
            EndDate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(493, 59);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 1;
            label3.Text = "대여";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(493, 92);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 1;
            label4.Text = "반납";
            // 
            // TotalLbl
            // 
            TotalLbl.AutoSize = true;
            TotalLbl.Location = new Point(493, 155);
            TotalLbl.Name = "TotalLbl";
            TotalLbl.Size = new Size(92, 20);
            TotalLbl.TabIndex = 3;
            TotalLbl.Text = "대여료 총합:";
            // 
            // SelectBtn
            // 
            SelectBtn.Location = new Point(493, 178);
            SelectBtn.Name = "SelectBtn";
            SelectBtn.Size = new Size(295, 29);
            SelectBtn.TabIndex = 4;
            SelectBtn.Text = "대여";
            SelectBtn.UseVisualStyleBackColor = true;
            SelectBtn.Click += SelectBtn_Click;
            // 
            // DeselectBtn
            // 
            DeselectBtn.Location = new Point(493, 213);
            DeselectBtn.Name = "DeselectBtn";
            DeselectBtn.Size = new Size(295, 29);
            DeselectBtn.TabIndex = 4;
            DeselectBtn.Text = "반납";
            DeselectBtn.UseVisualStyleBackColor = true;
            DeselectBtn.Click += DeselectBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(260, 31);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 1;
            label5.Text = "대여 중 도서";
            // 
            // SelectLBox
            // 
            SelectLBox.FormattingEnabled = true;
            SelectLBox.ItemHeight = 20;
            SelectLBox.Location = new Point(260, 54);
            SelectLBox.Name = "SelectLBox";
            SelectLBox.Size = new Size(118, 384);
            SelectLBox.TabIndex = 0;
            SelectLBox.SelectedIndexChanged += LBox_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeselectBtn);
            Controls.Add(SelectBtn);
            Controls.Add(TotalLbl);
            Controls.Add(EndDate);
            Controls.Add(StartDate);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(SelectLBox);
            Controls.Add(label1);
            Controls.Add(BookLBox);
            Controls.Add(MemberLBox);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox MemberLBox;
        private ListBox BookLBox;
        private Label label1;
        private Label label2;
        private DateTimePicker StartDate;
        private DateTimePicker EndDate;
        private Label label3;
        private Label label4;
        private Label TotalLbl;
        private Button SelectBtn;
        private Button DeselectBtn;
        private Label label5;
        private ListBox SelectLBox;
    }
}