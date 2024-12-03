using P0927.quizDB;
using System.Diagnostics;
using System.Windows.Forms;

namespace P0927
{
    public partial class MainForm : Form
    {
        public static readonly string[] Columns = { "Number", "Name", "Korean", "Math", "English" };

        private ListView list;
        private Button insert;
        private Button delete;
        private Button edit;

        public MainForm()
        {
            InitializeComponent();

            this.list = new ListView()
            {
                Parent = this,
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 30),
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false,
            };

            foreach (var column in Columns)
            {
                this.list.Columns.Add(column);
            }

            LoadAllData();

            this.insert = new Button()
            {
                Parent = this,
                Location = new Point(0, this.ClientSize.Height - 30),
                Size = new Size(this.ClientSize.Width / 3, 30),
                Text = "INSERT",
            };
            this.edit = new Button()
            {
                Parent = this,
                Location = new Point(this.ClientSize.Width / 3, this.ClientSize.Height - 30),
                Size = new Size(this.ClientSize.Width / 3, 30),
                Text = "EDIT",
            };
            this.delete = new Button()
            {
                Parent = this,
                Location = new Point(this.ClientSize.Width * 2 / 3, this.ClientSize.Height - 30),
                Size = new Size(this.ClientSize.Width / 3, 30),
                Text = "DELETE",
            };

            this.insert.Click += (s, e) =>
            {
                ControlForm form = new ControlForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Quiz1Context context = new Quiz1Context())
                        {
                            Student student = form.Student;

                            ListViewItem item = new ListViewItem(student.Number.ToString());
                            item.SubItems.Add(student.Name);
                            item.SubItems.Add(student.Korean.ToString());
                            item.SubItems.Add(student.Math.ToString());
                            item.SubItems.Add(student.English.ToString());

                            this.list.Items.Add(item);
                            context.Students.Add(student);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            };
            this.edit.Click += (s, e) =>
            {
                ControlForm form = new ControlForm();
                Student student;

                using (Quiz1Context context = new Quiz1Context())
                {
                    student = context.Students
                               .First(p => p.Number.ToString()
                                   == this.list.SelectedItems[0].Text);

                    for (int i = 0; i < Columns.Length; i++)
                    {
                        form.Texts[i].Text = this.list.SelectedItems[0].SubItems[i].Text;
                    }
                }

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Quiz1Context context = new Quiz1Context())
                        {
                            this.list.Items.RemoveAt(this.list.SelectedIndices[0]);
                            context.Students.Remove(student);
                            context.SaveChanges();

                            student = form.Student;

                            ListViewItem item = new ListViewItem(student.Number.ToString());
                            item.SubItems.Add(student.Name);
                            item.SubItems.Add(student.Korean.ToString());
                            item.SubItems.Add(student.Math.ToString());
                            item.SubItems.Add(student.English.ToString());

                            this.list.Items.Add(item);
                            context.Students.Add(student);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            };
            this.delete.Click += (s, e) =>
            {
                using (Quiz1Context context = new Quiz1Context())
                {
                    Student student = context.Students
                        .First(p => p.Number.ToString()
                            == this.list.SelectedItems[0].Text);

                    context.Students.Remove(student);
                    context.SaveChanges();

                    LoadAllData();
                }
            };

            this.list.DoubleClick += (s, e) =>
            {
                MessageBox.Show($"{this.list.SelectedItems[0].SubItems[1].Text} " +
                    $"학생의 평균은 {(int.Parse(this.list.SelectedItems[0].SubItems[2].Text) + int.Parse(this.list.SelectedItems[0].SubItems[3].Text) + int.Parse(this.list.SelectedItems[0].SubItems[4].Text)) / 3}점입니다.");
            };
        }

        private void LoadAllData()
        {
            this.list.Items.Clear();

            using (Quiz1Context context = new Quiz1Context())
            {
                var items = context.Students.ToList();

                for (int i = 0; i < items.Count; i++)
                {
                    ListViewItem item = new ListViewItem(items[i].Number.ToString());
                    item.SubItems.Add(items[i].Name);
                    item.SubItems.Add(items[i].Korean.ToString());
                    item.SubItems.Add(items[i].Math.ToString());
                    item.SubItems.Add(items[i].English.ToString());

                    this.list.Items.Add(item);

                }
            }
        }
    }
}