using P1204.scoreDB;

namespace P1204
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            label1.Text = "학생 수";
            label2.Text = "국어점수 총점";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm(new Pair[]
            {
                new Pair("Name", new TextBox()),
                new Pair("Kor", new TextBox()),
                new Pair("Eng", new TextBox()),
                new Pair("Math", new TextBox()),
            });

            form.ShowDialog();

            using (ScoreDbContext db = new ScoreDbContext())
            {
                db.Add(new Student()
                {
                    Number = new Random().Next(),
                    Name = form.Pairs[0].Control.Text,
                    Korean = int.Parse(form.Pairs[1].Control.Text),
                    English = int.Parse(form.Pairs[2].Control.Text),
                    Math = int.Parse(form.Pairs[3].Control.Text),
                });

                db.SaveChanges();

                label1.Text = "총학생수: " + db.Students.Count() + "명";
                label2.Text = "국어점수 평균: " + db.Students.Average((s) => s.Korean) + "점";
                label3.Text = "수학점수 평균: " + db.Students.Average((s) => s.English) + "점";
                label4.Text = "영어점수 평균: " + db.Students.Average((s) => s.Math) + "점";

                label5.Text = "최고점수 학생: " + db.Students
                    .OrderByDescending(s => s.Korean  + s.English + s.Math).First().Name;
            }
        }
    }
}