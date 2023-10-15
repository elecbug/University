using Microsoft.EntityFrameworkCore;
using HW01.univDB;
using System.Diagnostics;
using System.Windows.Forms;

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
                }
            }
        }

        private void SubjectToolBoxTextChanged(object sender, EventArgs e)
        {
            SubForm form = new SubForm();

            string grade = "N";
            int ms = 0, fs = 0;

            if (form.ShowDialog() == DialogResult.OK)
            {
                grade = form.Grade;
                ms = form.MiddleScore;
                fs = form.FinalScore;

                try
                {
                    using (UnivDbContext db = new UnivDbContext())
                    {
                        Class item = new Class()
                        {
                            SubjectId = (this.subjectComboBox.SelectedItem as Subject)!.Id,
                            StudentId = (this.nameListBox.SelectedItem as Student)!.Id,
                            Grade = grade,
                            MidScore = ms,
                            FinalScore = fs,
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

        private void SubjectComboBoxClick(object sender, EventArgs e)
        {
            using (UnivDbContext db = new UnivDbContext())
            {
                this.subjectComboBox.Items.Clear();

                var list = db.Subjects.ToList();

                foreach (Subject item in list)
                {
                    if (db.Classes
                        .Where(x => x.StudentId == (this.nameListBox.SelectedItem as Student)!.Id
                        && x.SubjectId == item.Id).ToList().Count > 0)
                    {
                        continue;
                    }

                    this.subjectComboBox.Items.Add(item);
                }
            }
        }

        private void SubjectListBoxMouseClick(object sender, EventArgs e)
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();

            menuStrip.Items.Add("Edit").Click += (s, e)=>
            {
                try
                {
                    using (UnivDbContext db = new UnivDbContext())
                    {
                        var list = db.Classes.Include(p => p.Subject)
                            .Where(p => p.StudentId == (this.nameListBox.SelectedItem as Student)!.Id
                                && p.SubjectId == (this.subjectListBox.SelectedItem as Subject)!.Id).ToList();

                        SubForm form = new SubForm()
                        {
                            Grade = list[0].Grade!,
                            MiddleScore = (int)list[0].MidScore!,
                            FinalScore = (int)list[0].FinalScore!
                        };

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            list[0].Grade = form.Grade;
                            list[0].MidScore = form.MiddleScore;
                            list[0].FinalScore = form.FinalScore;

                            db.SaveChanges();

                            SubjectListRefresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            };
            menuStrip.Items.Add("Delete").Click += (s, e) =>
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
            };

            menuStrip.Show(Control.MousePosition);
        }
    }
}