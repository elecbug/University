namespace P0925
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
            list_box = new ListBox();
            add_button = new Button();
            edit_button = new Button();
            remove_button = new Button();
            SuspendLayout();
            // 
            // list_box
            // 
            list_box.FormattingEnabled = true;
            list_box.ItemHeight = 20;
            list_box.Location = new Point(12, 12);
            list_box.Name = "list_box";
            list_box.Size = new Size(490, 424);
            list_box.TabIndex = 0;
            list_box.SelectedIndexChanged += ListBoxSelectedIndexChanged;
            // 
            // add_button
            // 
            add_button.Location = new Point(508, 12);
            add_button.Name = "add_button";
            add_button.Size = new Size(94, 29);
            add_button.TabIndex = 1;
            add_button.Text = "Add";
            add_button.UseVisualStyleBackColor = true;
            add_button.Click += AddClick;
            // 
            // edit_button
            // 
            edit_button.Location = new Point(608, 12);
            edit_button.Name = "edit_button";
            edit_button.Size = new Size(94, 29);
            edit_button.TabIndex = 2;
            edit_button.Text = "Edit";
            edit_button.UseVisualStyleBackColor = true;
            edit_button.Click += EditClick;
            // 
            // button1
            // 
            remove_button.Location = new Point(708, 12);
            remove_button.Name = "button1";
            remove_button.Size = new Size(94, 29);
            remove_button.TabIndex = 3;
            remove_button.Text = "Remove";
            remove_button.UseVisualStyleBackColor = true;
            remove_button.Click += RemoveClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 450);
            Controls.Add(remove_button);
            Controls.Add(edit_button);
            Controls.Add(add_button);
            Controls.Add(list_box);
            Name = "MainForm";
            Text = "Form1";
            Load += MainFormLoad;
            ResumeLayout(false);
        }

        #endregion

        private ListBox list_box;
        private Button add_button;
        private Button edit_button;
        private Button remove_button;
    }
}