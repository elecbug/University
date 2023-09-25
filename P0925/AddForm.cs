using P0925.univDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P0925
{
    public partial class AddForm : Form
    {
        private List<TextBox> text_list = new List<TextBox>();

        public AddForm()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                this.text_list.Add(new TextBox()
                {
                    Parent = this,
                    Location = new Point(5, 5 + (i * 30)),
                    Size = new Size(250, 50),
                });
            }
        }

        public Student Student { get; private set; }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                this.Student = new Student()
                {
                    Name = this.text_list[0].Text,
                    Id = int.Parse(this.text_list[1].Text),
                    Age = int.Parse(this.text_list[2].Text),
                    Address = this.text_list[3].Text,
                    Gender = this.text_list[4].Text,
                    Dept = this.text_list[5].Text,
                    Grade = int.Parse(this.text_list[6].Text),
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show("Student data unvalid");
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
