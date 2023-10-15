namespace HW01
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
            text = new TextBox();
            search = new Button();
            nameListBox = new ListBox();
            subjectListBox = new ListBox();
            subjectComboBox = new ComboBox();
            SuspendLayout();
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
            // nameListBox
            // 
            nameListBox.FormattingEnabled = true;
            nameListBox.ItemHeight = 20;
            nameListBox.Location = new Point(12, 45);
            nameListBox.Name = "nameListBox";
            nameListBox.Size = new Size(256, 384);
            nameListBox.TabIndex = 3;
            nameListBox.SelectedIndexChanged += NameSelectedIndexChanged;
            // 
            // subjectListBox
            // 
            subjectListBox.FormattingEnabled = true;
            subjectListBox.ItemHeight = 20;
            subjectListBox.Location = new Point(274, 45);
            subjectListBox.Name = "subjectListBox";
            subjectListBox.Size = new Size(256, 384);
            subjectListBox.TabIndex = 3;
            subjectListBox.SelectedValueChanged += SubjectListBoxMouseClick;
            // 
            // subjectComboBox
            // 
            subjectComboBox.Location = new Point(274, 12);
            subjectComboBox.Name = "subjectComboBox";
            subjectComboBox.Size = new Size(256, 28);
            subjectComboBox.TabIndex = 4;
            subjectComboBox.Text = "Will add subject";
            subjectComboBox.SelectedIndexChanged += SubjectToolBoxTextChanged;
            subjectComboBox.Click += SubjectComboBoxClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(subjectComboBox);
            Controls.Add(subjectListBox);
            Controls.Add(nameListBox);
            Controls.Add(search);
            Controls.Add(text);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox text;
        private Button search;
        private ListBox nameListBox;
        private ListBox subjectListBox;
        private ComboBox subjectComboBox;
    }
}