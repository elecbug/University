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

            RefreshList();

            this.TodoList.DisplayMember = "Id";
            this.DetailList.DisplayMember = "Id";

            this.DetailList.SelectedIndexChanged += DetailListSelectedIndexChanged;
        }

        private void DetailListSelectedIndexChanged(object? sender, EventArgs e)
        {
            using (TododbContext db = new TododbContext())
            {

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