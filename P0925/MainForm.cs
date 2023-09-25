using P0925.univDB;
using System.Diagnostics;
using System.Windows.Forms;

namespace P0925
{
    public partial class MainForm : Form
    {
        private List<TextBox> text_list = new List<TextBox>();

        public MainForm()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                this.text_list.Add(new TextBox()
                {
                    Parent = this,
                    Location = new Point(this.add_button.Location.X, this.add_button.Location.Y + 60 + (i * 30)),
                    Size = new Size(250, 50),
                });
            }
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            this.list_box.Items.Clear();
            this.list_box.DisplayMember = "Name";

            using (UnivDbContext context = new UnivDbContext())
            {
                var items = context.Students.ToList();

                foreach (var item in items)
                {
                    this.list_box.Items.Add(item);
                }
            }
        }

        private void AddClick(object sender, EventArgs e)
        {
            AddForm form = new AddForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (UnivDbContext context = new UnivDbContext())
                    {
                        Student student = form.Student;
                        this.list_box.Items.Add(student);
                        context.Students.Add(student);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void ListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.list_box.SelectedItem as Student;

            if (item == null)
            {
                MessageBox.Show("Please select list's member.");

                return;
            }

            using (UnivDbContext context = new UnivDbContext())
            {
                Student student = context.Students
                    .First(p => p.Id == item.Id);

                this.text_list[0].Text = student.Name.ToString();
                this.text_list[1].Text = student.Id.ToString();
                this.text_list[2].Text = student.Age.ToString();
                this.text_list[3].Text = student.Address != null ? student.Address.ToString() : "";
                this.text_list[4].Text = student.Gender.ToString();
                this.text_list[5].Text = student.Dept.ToString();
                this.text_list[6].Text = student.Grade.ToString();
            }
        }

        private void EditClick(object sender, EventArgs e)
        {
            var item = this.list_box.SelectedItem as Student;

            if (item == null)
            {
                MessageBox.Show("Please select list's member.");

                return;
            }

            using (UnivDbContext context = new UnivDbContext())
            {
                var student = context.Students.First(p => p.Id == item.Id);

                student.Name = this.text_list[0].Text;
                student.Id = int.Parse(this.text_list[1].Text);
                student.Age = int.Parse(this.text_list[2].Text);
                student.Address = this.text_list[3].Text;
                student.Gender = this.text_list[4].Text;
                student.Dept = this.text_list[5].Text;
                student.Grade = int.Parse(this.text_list[6].Text);

                item = student;
                context.SaveChanges();

                MainFormLoad(this, new EventArgs());
            }
        }

        private void RemoveClick(object sender, EventArgs e)
        {
            var item = this.list_box.SelectedItem as Student;

            if (item == null)
            {
                MessageBox.Show("Please select list's member.");

                return;
            }

            using (UnivDbContext context = new UnivDbContext())
            {
                Student student = context.Students
                    .First(p => p.Id == item.Id);

                context.Students.Remove(student);
                context.SaveChanges();


                MainFormLoad(this, new EventArgs());
            }
        }
    }
}