using P1004.todo;
using System.Diagnostics;
using System.Windows.Forms;

namespace P1004
{
    public partial class MainForm : Form
    {
        public static readonly string[] Columns = { "Name", "Description"};

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
                            Todo todo = form.ToDo;

                            ListViewItem item = new ListViewItem(todo.Name);
                            item.SubItems.Add(todo.Description);

                            this.list.Items.Add(item);
                            context.Todos.Add(todo);
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
                Todo todo;

                using (Quiz1Context context = new Quiz1Context())
                {
                    todo = context.Todos
                               .First(p => p.Name
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
                            context.Todos.Remove(todo);
                            context.SaveChanges();

                            todo = form.ToDo;

                            ListViewItem item = new ListViewItem(todo.Name);
                            item.SubItems.Add(todo.Description);

                            this.list.Items.Add(item);
                            context.Todos.Add(todo);
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
                    Todo todo = context.Todos
                        .First(p => p.Name
                            == this.list.SelectedItems[0].Text);

                    context.Todos.Remove(todo);
                    context.SaveChanges();

                    LoadAllData();
                }
            };
        }

        private void LoadAllData()
        {
            this.list.Items.Clear();

            using (Quiz1Context context = new Quiz1Context())
            {
                var items = context.Todos.ToList();

                for (int i = 0; i < items.Count; i++)
                {
                    ListViewItem item = new ListViewItem(items[i].Name);
                    item.SubItems.Add(items[i].Description);

                    this.list.Items.Add(item);

                }
            }
        }
    }
}