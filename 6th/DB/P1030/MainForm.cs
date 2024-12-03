using P1030.todoDB;

namespace P1030
{
    public partial class MainForm : Form
    {
        public ListBox TodoList { get; private set; }
        public ListBox DetailList { get; private set; }
        public DateTimePicker TimePicker { get; private set; }
        public RichTextBox NameBox { get; private set; }
        public RichTextBox DescripBox { get; private set; }
        public Button Add { get; private set; }
        public RadioButton IsDone { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            this.ClientSize = new Size(900, 500);

            this.TimePicker = new DateTimePicker() 
            {
                Parent = this,
                Visible = true,
                Location = new Point(600, 0),
                Size = new Size(300, 50),
            };

            this.NameBox = new RichTextBox()
            {
                Parent = this,
                Visible = true,
                Location = new Point(600, 50),
                Size = new Size(300, 50),
            };

            this.DescripBox = new RichTextBox()
            {
                Parent = this,
                Visible = true,
                Location = new Point(600, 100),
                Size = new Size(300, 300),
            };

            this.TodoList = new ListBox()
            {
                Parent = this,
                Visible = true,
                Location = new Point(0, 0),
                Size = new Size(300, 500),
            };

            this.DetailList = new ListBox()
            {
                Parent = this,
                Visible = true,
                Location = new Point(300, 0),
                Size = new Size(300, 500),
            };

            this.Add = new Button()
            {
                Parent = this,
                Visible = true,
                Location = new Point(600, 450),
                Size = new Size(300, 50),
                Text = "Add",
            };

            this.IsDone = new RadioButton()
            {
                Parent = this,
                Visible = true,
                Location = new Point(600, 400),
                Size = new Size(300, 50),
                Text = "Is done",
            };

            this.TodoList.Format += (s, e) =>
            {
                e.Value = (e.ListItem as Todo)!.Id.ToString("yyyy-MM-dd") 
                    + " " + (e.ListItem as Todo)!.Name;
            };
            this.DetailList.Format += (s, e) =>
            {
                e.Value = (e.ListItem as TodoDetail)!.Id.ToString("HH:mm:ss");
            };

            this.DetailList.SelectedIndexChanged += DetailListSelectedIndexChanged;
            this.Add.Click += AddClick;

            RefreshList();
        }

        private void AddClick(object? sender, EventArgs e)
        {
            using (TododbContext db = new TododbContext())
            {
                var date = this.TimePicker.Value;

                if (db.Todos.Where(p=>p.Id == date).ToList().Count > 0)
                {
                    var item = new TodoDetail()
                    {
                        Id = date,
                        TodoId = date,
                        Descrip = this.DescripBox.Text,
                        IsDone = this.IsDone.Checked,
                    };

                    db.TodoDetails.Add(item);
                    db.SaveChanges();
                    RefreshList();
                }
                else
                {
                    var todo = new Todo()
                    {
                        Id = date,
                        Name = this.NameBox.Text,
                    };
                    var item = new TodoDetail()
                    {
                        Id = date,
                        TodoId = date,
                        Descrip = this.DescripBox.Text,
                        IsDone = this.IsDone.Checked,
                    };

                    db.Todos.Add(todo);
                    db.TodoDetails.Add(item);
                    db.SaveChanges();
                    RefreshList();

                }
            }
        }

        private void DetailListSelectedIndexChanged(object? sender, EventArgs e)
        {
            using (TododbContext db = new TododbContext())
            {
                this.TimePicker.Value = (this.DetailList.SelectedItem as TodoDetail)!.Id;
                this.NameBox.Text = db.Todos
                    .Where(x => x.Id == (this.DetailList.SelectedItem as TodoDetail)!.TodoId)
                    .ToList()[0].Name;
                this.DescripBox.Text = (this.DetailList.SelectedItem as TodoDetail)!.Descrip;
                this.IsDone.Checked = (this.DetailList.SelectedItem as TodoDetail)!.IsDone;
            }
        }

        private void RefreshList()
        {
            this.TodoList.Items.Clear();
            this.DetailList.Items.Clear();

            using (TododbContext db = new TododbContext())
            {
                foreach (var item in db.Todos)
                {
                    this.TodoList.Items.Add(item);
                }

                foreach (var item in db.TodoDetails)
                {
                    this.DetailList.Items.Add(item);
                }
            }
        }
    }
}