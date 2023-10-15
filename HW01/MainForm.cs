using Microsoft.EntityFrameworkCore;
using HW01.univDB;
using System.Diagnostics;

namespace HW01
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.subjectListBox.DisplayMember = "Name";
            this.nameListBox.DisplayMember = "Name";
            this.subjectComboBox.DisplayMember = "Name";
        }

        private void SearchClick(object sender, EventArgs e)
        {
            using (UnivDbContext db = new UnivDbContext())
            {
                var students = db.Students.Where(p => p.Name.Contains(this.text.Text)).ToList();

                this.nameListBox.Items.Clear();

                foreach (var student in students)
                {
                    this.nameListBox.Items.Add(student);
                }
            }
        }

        private void NameSelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectListRefresh();
        }

        private void SubjectListRefresh()
        {
            using (UnivDbContext db = new UnivDbContext())
            {
                this.subjectListBox.Items.Clear();

                Student student = (this.nameListBox.SelectedItem as Student)!;
                var list = db.Classes.Include(p => p.Subject).Where(p => p.StudentId == student.Id).ToList();

                foreach (Class item in list)
                {
                    this.subjectListBox.Items.Add(item.Subject);
                    // var subject = db.Subjects.Where(p => p.Id == item.SubjectId).First();
                    // this.subject.Items.Add(subject.Name);
                }
            }
        }

        private void SubjectToolBoxTextChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to add this subject?", "Check", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                try
                {
                    using (UnivDbContext db = new UnivDbContext())
                    {
                        Class item = new Class()
                        {
                            SubjectId = (this.subjectComboBox.SelectedItem as Subject)!.Id,
                            StudentId = (this.nameListBox.SelectedItem as Student)!.Id,
                            Grade = "N",
                            MidScore = 0,
                            FinalScore = 0,
                            Joined = DateTime.Now,
                        };

                        db.Classes.Add(item);
                        db.SaveChanges();
                    }

                    SubjectListRefresh();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void SubjectToolBoxClick(object sender, EventArgs e)
        {
            using (UnivDbContext db = new UnivDbContext())
            {
                this.subjectComboBox.Items.Clear();

                var list = db.Subjects.ToList();

                foreach (Subject item in list)
                {
                    this.subjectComboBox.Items.Add(item);
                    // var subject = db.Subjects.Where(p => p.Id == item.SubjectId).First();
                    // this.subject.Items.Add(subject.Name);
                }
            }
        }

        private void SubjectListBoxMouseClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to delete this subject?", "Check", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                try
                {
                    using (UnivDbContext db = new UnivDbContext())
                    {
                        Class item = db.Classes.Where(x => x.SubjectId == (this.subjectListBox.SelectedItem as Subject)!.Id
                            && x.StudentId == (this.nameListBox.SelectedItem as Student)!.Id).ToList()[0];
                        db.Classes.Remove(item);

                        db.SaveChanges();

                        SubjectListRefresh();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}