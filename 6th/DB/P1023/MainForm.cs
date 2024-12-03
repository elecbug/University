using P1023.db1023;

namespace P1023
{
    public partial class MainForm : Form
    {
        public Table1? Table1Item = null;
        public Table2? Table2Item = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            this.before.DisplayMember = "Date";
            this.doing.DisplayMember = "Date";
            this.after.DisplayMember = "Date";
            this.menu.DisplayMember = "Date";

            ListRefresh();
        }

        private void ListRefresh()
        {
            this.before.Items.Clear();
            this.doing.Items.Clear();
            this.after.Items.Clear();
            this.menu.Items.Clear();

            using (Db1023Context db = new Db1023Context())
            {
                var list1 = db.Table1s.Where(x => x.State == 0).ToList();
                foreach (var item in list1) this.before.Items.Add(item);

                var list2 = db.Table1s.Where(x => x.State == 1).ToList();
                foreach (var item in list2) this.doing.Items.Add(item);

                var list3 = db.Table1s.Where(x => x.State == 2).ToList();
                foreach (var item in list3) this.after.Items.Add(item);

                var list4 = db.Table2s.ToList();
                foreach (var item in list4) this.menu.Items.Add(item);
            }
        }

        private void B2D(object sender, EventArgs e)
        {
            if (this.before.SelectedItem != null)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    Table1? item = db.Table1s
                        .Where(x => x.Date == (this.before.SelectedItem as Table1)!.Date).ToList()[0];

                    item!.State = 1;

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }
        private void D2B(object sender, EventArgs e)
        {
            if (this.doing.SelectedItem != null)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    Table1? item = db.Table1s
                        .Where(x => x.Date == (this.doing.SelectedItem as Table1)!.Date).ToList()[0];

                    item!.State = 0;

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }
        private void D2A(object sender, EventArgs e)
        {
            if (this.doing.SelectedItem != null)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    Table1? item = db.Table1s
                        .Where(x => x.Date == (this.doing.SelectedItem as Table1)!.Date).ToList()[0];

                    item!.State = 2;

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }
        private void A2D(object sender, EventArgs e)
        {
            if (this.after.SelectedItem != null)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    Table1? item = db.Table1s
                        .Where(x => x.Date == (this.after.SelectedItem as Table1)!.Date).ToList()[0];

                    item!.State = 1;

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }

        private void InsertOrder(object sender, EventArgs e)
        {
            Order order = new Order(null);
            order.ShowDialog();

            if (order.DialogResult == DialogResult.OK)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    db.Table1s.Add(order.Item!);

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }
        private void EditOrder(object sender, EventArgs e)
        {
            if (this.Table1Item == null)
            {
                return;
            }

            Order order = new Order(this.Table1Item);
            order.ShowDialog();

            if (order.DialogResult == DialogResult.OK)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    db.Table1s.Remove(db.Table1s
                        .Where(x => x.Date == this.Table1Item!.Date).ToList()[0]);
                    db.Table1s.Add(order.Item!);

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }
        private void DeleteOrder(object sender, EventArgs e)
        {
            if (this.Table1Item == null)
            {
                return;
            }

            if (MessageBox.Show("Delete?") == DialogResult.OK)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    db.Table1s.Remove(db.Table1s
                        .Where(x => x.Date == this.Table1Item!.Date).ToList()[0]);

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }

        private void InsertMenu(object sender, EventArgs e)
        {
            Menu menu = new Menu(null);
            menu.ShowDialog();

            if (menu.DialogResult == DialogResult.OK)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    db.Table2s.Add(menu.Item!);

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }

        private void EditMenu(object sender, EventArgs e)
        {
            if (this.Table2Item == null)
            {
                return;
            }

            Menu menu = new Menu(this.Table2Item);
            menu.ShowDialog();

            if (menu.DialogResult == DialogResult.OK)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    db.Table2s.Remove(db.Table2s
                        .Where(x => x.Date == this.Table2Item!.Date).ToList()[0]);
                    db.Table2s.Add(menu.Item!);

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }

        private void DeleteMenu(object sender, EventArgs e)
        {
            if (this.Table2Item == null)
            {
                return;
            }

            if (MessageBox.Show("Delete?") == DialogResult.OK)
            {
                using (Db1023Context db = new Db1023Context())
                {
                    db.Table2s.Remove(db.Table2s
                        .Where(x => x.Date == this.Table2Item!.Date).ToList()[0]);

                    db.SaveChanges();
                }

                ListRefresh();
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Table1Item = (sender as ListBox)!.SelectedItem as Table1;
        }

        private void MenuSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Table2Item = (sender as ListBox)!.SelectedItem as Table2;
        }
    }
}