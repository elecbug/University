using HW01.univDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01
{
    public partial class AddForm : Form
    {
        private List<Label> labels = new List<Label>();
        private string[] texts = { "Name", "ID", "Age", "Address", "Gender", "Dept", "Grade" };
        public List<TextBox> TextList { get; private set; } = new List<TextBox>();

        public AddForm()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                this.labels.Add(new Label()
                {
                    Parent = this,
                    Location = new Point(5, 5 + (i * 40)),
                    Size = new Size(100, 40),
                    TextAlign = ContentAlignment.TopRight,
                    Text = this.texts[i],
                });
                this.TextList.Add(new TextBox()
                {
                    Parent = this,
                    Location = new Point(105, 5 + (i * 40)),
                    Size = new Size(250, 40),
                });
            }
        }

        public Student Student { get; private set; } = new Student();

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                this.Student = new Student()
                {
                    Name = this.TextList[0].Text,
                    Id = int.Parse(this.TextList[1].Text),
                    Age = int.Parse(this.TextList[2].Text),
                    Address = this.TextList[3].Text,
                    Gender = this.TextList[4].Text,
                    Dept = this.TextList[5].Text,
                    Grade = int.Parse(this.TextList[6].Text),
                };
            }
            catch (Exception ex)
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
