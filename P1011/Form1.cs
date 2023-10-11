using P0925.univDB;
using System.Diagnostics;

namespace P1011
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                        var list2 = db.Classes.Where(p=>p.StudentId == student.Id).ToList();
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
    }
}