using ExamM.middledb;
using System.Windows.Forms;

namespace ExamM
{
    public partial class MainForm : Form
    {
        private Middle? SelectedItem { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.listBox0.DisplayMember = "Price";
            this.listBox1.DisplayMember = "Price";
            this.listBox2.DisplayMember = "Price";
            this.listBox3.DisplayMember = "Price";
            this.listBox4.DisplayMember = "Price";

            RefreshList();
        }

        private void RefreshList()
        {
            this.listBox0.Items.Clear();
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
            this.listBox4.Items.Clear();

            using (MiddleContext db = new MiddleContext())
            {
                var list = db.Middles.ToList();
                int total = 0;

                foreach (var item in list)
                {
                    switch (item.State)
                    {
                        case 0:
                            this.listBox0.Items.Add(item);
                            break;
                        case 1:
                            this.listBox1.Items.Add(item);
                            break;
                        case 2:
                            this.listBox2.Items.Add(item);
                            break;
                        case 3:
                            this.listBox3.Items.Add(item);
                            total += item.Price;
                            break;
                        case 4:
                            this.listBox4.Items.Add(item);
                            break;
                        default:
                            throw new Exception();
                    }
                }

                this.totalLabel.Text = "총 구매 확정 금액: " + total;
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            OrderForm form = new OrderForm(null);

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (MiddleContext db = new MiddleContext())
                {
                    db.Middles.Add(form.Item!);

                    db.SaveChanges();

                    RefreshList();
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
            {
                return;
            }
            if (!(this.SelectedItem.State == 0))
            {
                return;
            }

            OrderForm form = new OrderForm(this.SelectedItem);

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (MiddleContext db = new MiddleContext())
                {
                    var item = db.Middles.Where(x => x.Date == form.Item!.Date).ToList()[0];
                    item.Price = form.Item!.Price;

                    db.SaveChanges();

                    RefreshList();
                }
            }
        }

        private void ListSelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedItem = ((sender as ListBox)!.SelectedItem as Middle)!;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
            {
                return;
            }
            if (!(this.SelectedItem.State == 0))
            {
                return;
            }

            if (MessageBox.Show("Delete?", "hmm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (MiddleContext db = new MiddleContext())
                {
                    var item = db.Middles.Where(x => x.Date == this.SelectedItem!.Date).ToList()[0];
                    db.Middles.Remove(item);

                    db.SaveChanges();

                    RefreshList();
                }
            }
        }

        private void Upgrade(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
            {
                return;
            }
            if (this.SelectedItem.State == 3 || this.SelectedItem.State == 4)
            {
                return;
            }

            using (MiddleContext db = new MiddleContext())
            {
                var item = db.Middles.Where(x => x.Date == this.SelectedItem!.Date).ToList()[0];

                if (item.State == 0)
                {
                    if (sender == this.button1)
                    {
                        item.State = 1;
                    }
                }
                else if (item.State == 1)
                {
                    if (sender == this.button2)
                    {
                        item.State = 2;
                    }
                    else if (sender == this.button3)
                    {
                        item.State = 0;
                    }
                }
                else if (item.State == 2)
                {
                    if (sender == this.button4)
                    {
                        item.State = 1;
                    }
                }

                db.SaveChanges();
                RefreshList();
            }
        }

        private void State3(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
            {
                return;
            }
            if (!(this.SelectedItem.State == 2))
            {
                return;
            }

            using (MiddleContext db = new MiddleContext())
            {
                var item = db.Middles.Where(x => x.Date == this.SelectedItem!.Date).ToList()[0];

                item.State = 3;

                db.SaveChanges();
                RefreshList();
            }
        }

        private void State4(object sender, EventArgs e)
        {
            if (this.SelectedItem == null)
            {
                return;
            }
            if (!(this.SelectedItem.State == 2))
            {
                return;
            }

            using (MiddleContext db = new MiddleContext())
            {
                var item = db.Middles.Where(x => x.Date == this.SelectedItem!.Date).ToList()[0];

                item.State = 4;

                db.SaveChanges();
                RefreshList();
            }
        }
    }
}