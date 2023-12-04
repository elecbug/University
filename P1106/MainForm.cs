using P1106.orderDB;

namespace P1106
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ListRefresh();
            this.ListLBox.Click += NameLBox_SelectedIndexChanged;

            this.ListLBox.DisplayMember = "Name";
            this.DetailLBox.Format += (s, e) =>
            {
                Viewer? view = e.ListItem as Viewer;

                e.Value = view!.ProductName + " " + view!.Quantity + "°³";
            };


        }

        private void NameLBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            this.DetailLBox.Items.Clear();

            using (OrderDbContext db = new OrderDbContext())
            {
                var list = from i in db.PorderDetails
                           join j in db.Porders
                           on i.OrderId equals j.Id
                           join k in db.Products
                           on i.ProductId equals k.Id
                           join l in db.Members
                           on j.MemberId equals l.Id
                           where (this.ListLBox.SelectedItem as Member)!.Id == l.Id
                           select new Viewer
                           {
                               OrderId = j.Id,
                               OrderDetailId = i.Id,
                               ProductName = k.Name,
                               Quantity = i.Quantity,
                           };

                //db.Porders.Where(x => x.MemberId == (this.NameLBox.SelectedItem as Member)!.Id);

                foreach (var item in list)
                {
                    this.DetailLBox.Items.Add(item);
                }
            }
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            CreateForm form = new CreateForm();
            form.ShowDialog();

            ListRefresh();

        }

        private void ListRefresh()
        {
            using (OrderDbContext db = new OrderDbContext())
            {
                this.ListLBox.Items.Clear();

                foreach (var item in db.Members)
                    this.ListLBox.Items.Add(item);
            }


            int total = 0;

            using (OrderDbContext db = new OrderDbContext())
            {
                var q = from p1 in db.PorderDetails
                        join p2 in db.Products
                        on p1.ProductId equals p2.Id
                        select p1.Quantity * p2.Price;

                var list = q.ToList();

                foreach (var item in list)
                {
                    total += item;
                }
            }
            this.TotalLbl.Text = total + " ¿ø";
        }
    }
}