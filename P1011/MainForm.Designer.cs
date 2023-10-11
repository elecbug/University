namespace P1011
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
            button1 = new Button();
            text = new TextBox();
            search = new Button();
            name = new ListBox();
            subject = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(685, 12);
            button1.Name = "button1";
            button1.Size = new Size(103, 30);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // text
            // 
            text.Location = new Point(12, 12);
            text.Name = "text";
            text.Size = new Size(125, 27);
            text.TabIndex = 1;
            // 
            // search
            // 
            search.Location = new Point(143, 12);
            search.Name = "search";
            search.Size = new Size(125, 27);
            search.TabIndex = 2;
            search.Text = "Search";
            search.UseVisualStyleBackColor = true;
            search.Click += SearchClick;
            // 
            // name
            // 
            name.FormattingEnabled = true;
            name.ItemHeight = 20;
            name.Location = new Point(12, 45);
            name.Name = "name";
            name.Size = new Size(256, 384);
            name.TabIndex = 3;
            name.SelectedIndexChanged += NameSelectedIndexChanged;
            // 
            // subject
            // 
            subject.FormattingEnabled = true;
            subject.ItemHeight = 20;
            subject.Location = new Point(274, 45);
            subject.Name = "subject";
            subject.Size = new Size(256, 384);
            subject.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(subject);
            Controls.Add(name);
            Controls.Add(search);
            Controls.Add(text);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox text;
        private Button search;
        private ListBox name;
        private ListBox subject;
    }
}