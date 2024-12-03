using ExamM.middledb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamM
{
    public partial class OrderForm : Form
    {
        public Middle? Item { get; private set; }

        public OrderForm(Middle? item)
        {
            InitializeComponent();
            this.Item = item;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Value = DateTime.Now;

            if (item != null)
            {
                this.dateTimePicker1.Value = item.Date;
                this.richTextBox1.Text = item.Price.ToString();
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Item == null)
                {
                    this.Item = new Middle()
                    {
                        Date = this.dateTimePicker1.Value,
                        Price = int.Parse(this.richTextBox1.Text),
                        State = 0,
                    };
                }
                else
                {
                    this.Item.Price = int.Parse(this.richTextBox1.Text);
                }

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("다시 입력해주세요.");
            }
        }
    }
}
