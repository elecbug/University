using P1122.univDB;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace P1122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Format += ListBox1_Format;
        }

        private void ListBox1_Format(object? sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem as Viewr;

            e.Value = item.Name + " (" + item.StudentId + ") \t"+ item.Subject ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UnivDbContext db =  new UnivDbContext())
            {
                /*
                var q = from s in db.Students
                        join c in db.Classes
                        on s.Id equals c.StudentId
                        join sb in db.Subjects
                        on c.SubjectId equals sb.Id
                        select new Viewr()
                        {
                            Name = s.Name,
                            StudentId = c.StudentId,
                            SubjectId = c.SubjectId,
                            MidScore = c.MidScore,
                            FinalScore = c.FinalScore,
                            Grade = c.Grade,
                            Joined = c.Joined,
                            Subject = sb.Name,
                        };

                foreach (var c in q)
                {
                    listBox1.Items.Add(c);
                }

                Debug.WriteLine(q.Count());
                */

                var q = db.Classes.Include(x => x.Student)
                    .Include(x => x.Subject).ToList();

                foreach (var item in q)
                {
                    listBox1.Items.Add(new Viewr
                    {
                        Name = item.Student.Name,
                        StudentId = item.Student.Id,
                        Subject = item.Subject.Name,
                        SubjectId = item.SubjectId,
                    });
                }
            }
        }
    }

    class Viewr : Class
    {
        public string Name { get; set; }
        public string Subject { get; set; }
    }
}