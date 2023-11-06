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
                using (OrderDbContext db = new OrderDbContext())
                {
                    e.Value = db.Products.Where(x => x.Id == (e.ListItem as PorderDetail)!.ProductId)
                        .First().Name + (e.ListItem as PorderDetail)!.Quantity.ToString() + "개";
                }
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

                this.DetailLBox.Items.Add(detail);
            }
        }

        private void NameLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DetailLBox.Items.Clear();

            using (OrderDbContext db = new OrderDbContext())
            {
                var list = db.Porders.Where(x => x.MemberId == (this.NameLBox.SelectedItem as Member)!.Id);

                foreach (var item in list)
                {
                    var sublist = db.PorderDetails.Where(x => x.OrderId == item.Id).ToList();
                    foreach (var sub in sublist)
                    {
                        this.DetailLBox.Items.Add(sub);
                    }
                }
            }
        }
    }
}
