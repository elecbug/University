using P1122.univDB;

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

            e.Value = item.Name + " (" + item.StudentId + ") Grade: " + item.Grade;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UnivDbContext db =  new UnivDbContext())
            {
                var q = from s in db.Students
                        join c in db.Classes
                        on s.Id equals c.StudentId
                        select new Viewr()
                        {
                            Name = s.Name,
                            StudentId = c.StudentId,
                            SubjectId = c.SubjectId,
                            MidScore = c.MidScore,
                            FinalScore = c.FinalScore,
                            Grade = c.Grade,
                            Joined = c.Joined,
                        };

                foreach (var c in q)
                {
                    listBox1.Items.Add(c);
                }
            }
        }
    }

    class Viewr : Class
    {
        public string Name { get; set; }
    }
}