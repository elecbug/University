using Microsoft.EntityFrameworkCore;
using P1206.carDB;

namespace P1206
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox1.DisplayMember = "ModelName";
            this.listBox2.DisplayMember = "Name";

            FormRefresh();
        }

        public void FormRefresh()
        {
            using (var db = new CarDbContext())
            {
                var list = new List<RentalViewer>();

                foreach (var item in db.Rentals
                                        .Include(p => p.Car)
                                        .Include(p => p.Car.Maker)
                                        .Include(p => p.Customer))
                {
                    list.Add(new RentalViewer()
                    {
                        RentalId = item.Id,
                        CarModel = item.Car.ModelName,
                        CarColor = item.Car.Color,
                        CustomerName = item.Customer.Name,
                        RentalDate = item.RentalDate,
                        ReturnDate = item.ReturnDate,
                        MakerName = item.Car.Maker.Name,
                    });
                }

                this.dataGridView1.DataSource = list;

                this.listBox1.Items.Clear();
                foreach (var item in db.Cars)
                {
                    this.listBox1.Items.Add(item);
                }

                this.listBox2.Items.Clear();
                foreach (var item in db.Customers)
                {
                    this.listBox2.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null
                && this.listBox2.SelectedItem != null)
            {
                using (var db = new CarDbContext())
                {
                    Rental rental = new Rental()
                    {
                        CarId = (this.listBox1.SelectedItem as Car)!.Id,
                        CustomerId = (this.listBox2.SelectedItem as Customer)!.Id,
                        Id = 0,
                        RentalDate = DateTime.Now,
                        ReturnDate = null,
                    };

                    db.Rentals.Add(rental);
                    db.SaveChanges();

                    FormRefresh();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                using (var db = new CarDbContext())
                {
                    var list = this.dataGridView1.SelectedRows;

                    foreach (var item in list)
                    {
                        var p = ((item as DataGridViewRow)!.DataBoundItem as RentalViewer)!;
                    }
                }
            }
        }
    }
}