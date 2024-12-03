using Microsoft.EntityFrameworkCore;
using P1101.hospital;

namespace P1101
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.listBox1.DisplayMember = "Name";
            this.listBox2.DisplayMember = "Name";
            this.listBox3.DisplayMember = "Name";
            this.listBox4.DisplayMember = "Name";

            RefreshList();
        }

        private void RefreshList(bool isAll = true)
        {
            if (isAll)
            {
                this.listBox1.Items.Clear();
                this.listBox3.Items.Clear();
            }
            this.listBox2.Items.Clear();
            this.listBox4.Items.Clear();

            using (HospitalDbContext db = new HospitalDbContext())
            {
                if (isAll)
                {
                    foreach (var item in db.Doctors)
                    {
                        this.listBox1.Items.Add(item);
                    }

                    foreach (var item in db.Patients)
                    {
                        this.listBox3.Items.Add(item);
                    }
                }

                if (this.listBox1.SelectedItem != null)
                {
                    var list1 = db.DoctorPatients
                        .Where(x => x.DoctorId == (this.listBox1.SelectedItem as Doctor)!.Id)
                        .Select(x => x.Patient)
                        .ToList();

                    foreach (var item in list1)
                    {
                        this.listBox2.Items.Add(item);
                    }
                }

                if (this.listBox3.SelectedItem != null)
                {
                    var list2 = db.DoctorPatients
                        .Where(x => x.PatientId == (this.listBox3.SelectedItem as Patient)!.Id)
                        .Select(x => x.Doctor)
                        .ToList();

                    foreach (var item in list2)
                    {
                        this.listBox4.Items.Add(item);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList(false);
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList(false);
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            using (HospitalDbContext db = new HospitalDbContext())
            {
                db.Remove(db.DoctorPatients
                    .Where(x => x.DoctorId == (this.listBox1.SelectedItem as Doctor)!.Id 
                    && x.PatientId == (this.listBox2.SelectedItem as Patient)!.Id).ToList()[0]);

                db.SaveChanges();
            }

            RefreshList(false);
        }
    }
}