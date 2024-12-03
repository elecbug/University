using P1127.todoDB;

namespace P1127
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            listBox1.Format += ListBox1_Format;
            listBox2.Format += ListBox2_Format;
        }

        private void ListBox1_Format(object? sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem as Todo;
            e.Value = item.Id.ToString("yyyy-MM-dd") + " " + item.PersonName;
        }

        private void ListBox2_Format(object? sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem as TodoDetail;
            e.Value = item.TodoId.ToString("yyyy-MM-dd") + " " + item.TodoPersonName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            using (TodoDbContext db = new TodoDbContext())
            {
                var list = db.Todos.ToList();

                foreach (var item in list)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (TodoDbContext db = new TodoDbContext())
                {
                    db.Todos.Add(form.Todo);
                    db.SaveChanges();

                    Form1_Load(sender, e);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var item = listBox1.SelectedItem as Todo;

            using (TodoDbContext db = new TodoDbContext())
            {
                var list = (from i in db.TodoDetails
                            where i.TodoId == item.Id && i.TodoPersonName == item.PersonName
                            select i).ToList();
            
                foreach (var i in list)
                {
                    listBox2.Items.Add(i);
                }
            }
        }
    }
}