using P1204.scoreDB;

namespace P1204
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            label1.Text = "�л� ��";
            label2.Text = "�������� ����";
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

                label1.Text = "���л���: " + db.Students.Count() + "��";
                label2.Text = "�������� ���: " + db.Students.Average((s) => s.Korean) + "��";
                label3.Text = "�������� ���: " + db.Students.Average((s) => s.English) + "��";
                label4.Text = "�������� ���: " + db.Students.Average((s) => s.Math) + "��";

                label5.Text = "�ְ����� �л�: " + db.Students
                    .OrderByDescending(s => s.Korean  + s.English + s.Math).First().Name;
            }
        }
    }
}