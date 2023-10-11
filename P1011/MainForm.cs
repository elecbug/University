using P0925.univDB;
using System.Diagnostics;

namespace P1011
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.name.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UnivDbContext db = new UnivDbContext())
            {
                var list = db.Students.Where(p => p.Name.Contains("ÀÌ")).ToList();

                foreach (Student student in list)
                {
                    if (student.Name == "ÀÌ½Â¿±")
                    {
                        var list2 = db.Classes.Where(p => p.StudentId == student.Id).ToList();
                        Debug.WriteLine(list2.Count);

                        foreach (Class subject in list2)
                        {
                            var subject1 = db.Subjects.Where(p => p.Id == subject.SubjectId).First();
                            Debug.WriteLine(subject1.Name);
                        }
                    }
                }
            }
        }

        private void SearchClick(object sender, EventArgs e)
        {
            using (UnivDbContext db = new UnivDbContext())
            {
                var students = db.Students.Where(p => p.Name.Contains(this.text.Text)).ToList();

                this.name.Items.Clear();

                foreach (var student in students)
                {
                    this.name.Items.Add(student);
                }
            }
        }

        private void NameSelectedIndexChanged(object sender, EventArgs e)
        {
            using (UnivDbContext db = new UnivDbContext())
            {
                this.subject.Items.Clear();

                Student student = (this.name.SelectedItem as Student)!;
                var list = db.Classes.Where(p => p.StudentId == student.Id).ToList();

                foreach (Class item in list)
                {
                    // this.subject.Items.Add(item.Subject.Name);
                    var subject = db.Subjects.Where(p => p.Id == item.SubjectId).First();
                    this.subject.Items.Add(subject.Name);
                }
            }
        }
    }
}