using Microsoft.EntityFrameworkCore;
using P0920.univDB;
using System.Diagnostics;

namespace P0920
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPopup_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                label1.Text = form2.textBox1.Text;
                listBox1.Items.Add(label1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Name";

            using (UnivDbContext context = new UnivDbContext())
            {
                var items = context.Students.ToList();

                foreach (var item in items)
                {
                    this.listBox1.Items.Add(item);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem as Student;
            this.textBox1.Text = item.Age.ToString();

            Debug.WriteLine(item.Name + " " + item.Dept);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem as Student;

            using (UnivDbContext context = new UnivDbContext())
            {
                var stu = context.Students.First(p => p.Id == item.Id);
                stu.Age = int.Parse(textBox1.Text);

                /// stu and item are not bindied now.
                item.Age = int.Parse(textBox1.Text);
                context.SaveChanges();
            }
        }
    }
}