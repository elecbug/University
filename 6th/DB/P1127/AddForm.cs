using P1127.todoDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1127
{
    public partial class AddForm : Form
    {
        public Todo Todo { get; set; }

        public AddForm()
        {
            InitializeComponent();

            this.FormClosing += AddForm_FormClosing;
        }

        private void AddForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Save?", "", MessageBoxButtons.OK) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;

                this.Todo = new Todo()
                {
                    Id = dateTimePicker1.Value,
                    PersonName = textBox1.Text,
                };
            }
        }
    }
}
