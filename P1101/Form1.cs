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

        private void RefreshList()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
            this.listBox4.Items.Clear();

            using (HospitalDbContext db = new HospitalDbContext())
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
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox2.Items.Clear();

            using (HospitalDbContext db = new HospitalDbContext())
            {
                var list = db.DoctorPatients
                    .Where(x => x.DoctorId == (this.listBox1.SelectedItem as Doctor)!.Id)
                    .Select(x => x.Patient)
                    .ToList();
                
                foreach (var item in list)
                {
                    this.listBox2.Items.Add(item);
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox4.Items.Clear();

            using (HospitalDbContext db = new HospitalDbContext())
            {
                var list = db.DoctorPatients
                    .Where(x => x.PatientId == (this.listBox3.SelectedItem as Patient)!.Id)
                    .Select(x => x.Doctor)
                    .ToList();

                foreach (var item in list)
                {
                    this.listBox4.Items.Add(item);
                }
            }
        } 
    }
}