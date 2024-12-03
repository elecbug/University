using P1018.todoDB;

namespace P1018
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.before.DisplayMember = "Dateid";
            this.after.DisplayMember = "Dateid";
        }

        private void Refreshing()
        {
            this.before.Items.Clear();
            this.after.Items.Clear();

            using (TododbContext db = new TododbContext())
            {
                var todos = db.Todos.ToList();
                todos.Sort((x, y) => x.Dateid > y.Dateid ? 1 : -1);

                foreach (var todo in todos)
                {
                    if (todo.Checked == 0)
                    {
                        this.before.Items.Add(todo);
                    }
                    else
                    {
                        this.after.Items.Add(todo);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Refreshing();
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            using (TododbContext db = new TododbContext())
            {
                this.isEdited = true;

                var item = (sender as ListBox)!.SelectedItem as Todo;

                if (item != null)
                {
                    this.dateTimePicker.Value = item!.Dateid;
                    this.textBox.Text = item!.Descryp;
                    this.clear.Checked = item!.Checked == 1 ? true : false;
                }

                this.isEdited = false;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            using (TododbContext db = new TododbContext())
            {
                var item = new Todo
                {
                    Dateid = this.dateTimePicker.Value,
                    Descryp = this.textBox.Text,
                    Checked = this.clear.Checked == true ? 1 : 0,
                };

                db.Add(item);

                db.SaveChanges();
                Refreshing();
            }
        }

        bool isEdited = false;
        private void edit_Click(object sender, EventArgs e)
        {
            using (TododbContext db = new TododbContext())
            {
                this.isEdited = true;

                Todo? todo = db.Todos.Where(x => x.Dateid == this.dateTimePicker.Value).ToList()[0];
                todo.Descryp = this.textBox.Text;
                todo.Checked = this.clear.Checked ? 1 : 0;

                db.SaveChanges();
                Refreshing();

                this.isEdited = false;
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            using (TododbContext db = new TododbContext())
            {
                Todo? todo = db.Todos.Where(x => x.Dateid == this.dateTimePicker.Value).ToList()[0];
                db.Remove(todo);

                db.SaveChanges();
                Refreshing();
            }
        }

        private void clear_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.isEdited)
            {
                using (TododbContext db = new TododbContext())
                {
                    Todo? todo = db.Todos.Where(x => x.Dateid == this.dateTimePicker.Value).ToList()[0];
                    todo.Descryp = this.textBox.Text;
                    todo.Checked = this.clear.Checked ? 1 : 0;

                    db.SaveChanges();
                    Refreshing();
                }
            }
        }
    }
}