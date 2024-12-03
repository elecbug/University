using P1106.orderDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1106
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();

            this.NameLBox.DisplayMember = "Name";
            this.ProductLBox.DisplayMember = "Name";
            this.DetailLBox.Format += (s, e) =>
            {
                Viewer? view = e.ListItem as Viewer;

                e.Value = view!.ProductName + " " + view!.Quantity + "개";
            };
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            using (OrderDbContext db = new OrderDbContext())
            {
                this.NameLBox.Items.Clear();

                foreach (var item in db.Members)
                    this.NameLBox.Items.Add(item);

                this.ProductLBox.Items.Clear();

                foreach (var item in db.Products)
                    this.ProductLBox.Items.Add(item);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            using (OrderDbContext db = new OrderDbContext())
            {
                PorderDetail detail = new PorderDetail()
                {
                    ProductId = (this.ProductLBox.SelectedItem as Product)!.Id,
                    Quantity = int.Parse(this.QuantityTBox.Text),
                };
                Porder order = new Porder()
                {
                    MemberId = (this.NameLBox.SelectedItem as Member)!.Id,
                    Created = DateTime.Now,
                    PorderDetails =
                    {
                        detail,
                    }
                };

                db.Porders.Add(order);

                db.SaveChanges();

                NameLBox_SelectedIndexChanged(sender, e);
            }
        }

        private void NameLBox_SelectedIndexChanged(object sender, EventArgs e)
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
                           where (this.NameLBox.SelectedItem as Member)!.Id == l.Id
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (DetailLBox.SelectedItem != null)
            {
                Viewer item = (DetailLBox.SelectedItem as Viewer)!;

                using (OrderDbContext db = new OrderDbContext())
                {
                    var q = from i in db.PorderDetails
                            where i.Id == item.OrderDetailId
                            select i;

                    db.PorderDetails.Remove(q.First());

                    var p = from i in db.Porders
                            where i.Id == item.OrderId
                            select i;

                    db.Porders.Remove(p.First());

                    db.SaveChanges();

                    NameLBox_SelectedIndexChanged(sender, e);
                }
            }
        }

        private void AllDeleteBtn_Click(object sender, EventArgs e)
        {
            while (DetailLBox.Items.Count > 0)
            {
                DetailLBox.SelectedIndex = 0;
                DeleteBtn_Click(sender, e);
            }
        }
    }

    class Viewer
    {
        public int OrderId { get; set; } = 0;
        public int OrderDetailId { get; set; } = 0;
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; } = 0;
    }
}
