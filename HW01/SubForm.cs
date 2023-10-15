using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01
{
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();
        }

        public string Grade { get; set; } = "";
        public int MiddleScore { get; set; }
        public int FinalScore { get; set; }

        private void OkButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.MiddleScore = int.Parse(this.textBox1.Text);
                this.FinalScore = int.Parse(this.textBox2.Text);
                this.Grade = this.textBox3.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check to text format!");
                return;
            }
        }

        private void SubFormLoad(object sender, EventArgs e)
        {

            this.textBox1.Text = this.MiddleScore.ToString();
            this.textBox2.Text = this.FinalScore.ToString();
            this.textBox3.Text = this.Grade.ToString();
        }
    }
}
