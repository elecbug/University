using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace P1115
{
    public partial class Form2 : Form
    {
        public Contact Contact { get; set; }

        public Form2(Contact? contact = null)
        {
            Contact = contact;
            InitializeComponent();

            if (contact != null)
            {
                this.textBox1.Text = contact.FirstName;
                this.textBox2.Text = contact.LastName;
                this.textBox4.Text = contact.Phone;
                this.textBox3.Text = contact.Email;
                this.dateTimePicker1.Value = contact.DateOfBirth;
                this.textBox5.Text = contact.State;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Save?", "", MessageBoxButtons.YesNoCancel);
            
            if (result == DialogResult.Yes)
            {
                Contact = new Contact()
                {
                    FirstName = this.textBox1.Text,
                    LastName = this.textBox2.Text,
                    Phone = this.textBox4.Text,
                    Email = this.textBox3.Text,
                    DateOfBirth = this.dateTimePicker1.Value,
                    State = this.textBox5.Text,
                };

                this.DialogResult = DialogResult.Yes;
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
