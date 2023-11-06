namespace P1106
{
    partial class CreateForm
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
            NameLBox = new ListBox();
            label1 = new Label();
            ProductLBox = new ListBox();
            label2 = new Label();
            DetailLBox = new ListBox();
            label3 = new Label();
            label4 = new Label();
            QuantityTBox = new TextBox();
            AddBtn = new Button();
            DeleteBtn = new Button();
            AllDeleteBtn = new Button();
            SuspendLayout();
            // 
            // NameLBox
            // 
            NameLBox.FormattingEnabled = true;
            NameLBox.ItemHeight = 20;
            NameLBox.Location = new Point(12, 32);
            NameLBox.Name = "NameLBox";
            NameLBox.Size = new Size(150, 364);
            NameLBox.TabIndex = 0;
            NameLBox.SelectedIndexChanged += NameLBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 1;
            label1.Text = "회원목록";
            // 
            // ProductLBox
            // 
            ProductLBox.FormattingEnabled = true;
            ProductLBox.ItemHeight = 20;
            ProductLBox.Location = new Point(168, 32);
            ProductLBox.Name = "ProductLBox";
            ProductLBox.Size = new Size(150, 364);
            ProductLBox.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 9);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "제품";
            // 
            // DetailLBox
            // 
            DetailLBox.FormattingEnabled = true;
            DetailLBox.ItemHeight = 20;
            DetailLBox.Location = new Point(324, 132);
            DetailLBox.Name = "DetailLBox";
            DetailLBox.Size = new Size(150, 264);
            DetailLBox.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(324, 109);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 1;
            label3.Text = "주문상세";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(324, 9);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 1;
            label4.Text = "수량";
            // 
            // QuantityTBox
            // 
            QuantityTBox.Location = new Point(324, 32);
            QuantityTBox.Name = "QuantityTBox";
            QuantityTBox.Size = new Size(150, 27);
            QuantityTBox.TabIndex = 2;
            // 
            // AddBtn
            // 
            AddBtn.Location = new Point(480, 32);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(94, 29);
            AddBtn.TabIndex = 3;
            AddBtn.Text = "담기";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(480, 132);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(94, 29);
            DeleteBtn.TabIndex = 3;
            DeleteBtn.Text = "선택 제거";
            DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // AllDeleteBtn
            // 
            AllDeleteBtn.Location = new Point(480, 167);
            AllDeleteBtn.Name = "AllDeleteBtn";
            AllDeleteBtn.Size = new Size(94, 29);
            AllDeleteBtn.TabIndex = 3;
            AllDeleteBtn.Text = "전체 제거";
            AllDeleteBtn.UseVisualStyleBackColor = true;
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 450);
            Controls.Add(AllDeleteBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(AddBtn);
            Controls.Add(QuantityTBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(DetailLBox);
            Controls.Add(ProductLBox);
            Controls.Add(label1);
            Controls.Add(NameLBox);
            Name = "CreateForm";
            Text = "CreateForm";
            Load += CreateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox NameLBox;
        private Label label1;
        private ListBox ProductLBox;
        private Label label2;
        private ListBox DetailLBox;
        private Label label3;
        private Label label4;
        private TextBox QuantityTBox;
        private Button AddBtn;
        private Button DeleteBtn;
        private Button AllDeleteBtn;
    }
}