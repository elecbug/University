using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public DateTime Date { get; set; } = DateTime.Now;

        private void OkButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.MiddleScore = int.Parse(this.textBox1.Text);
                this.FinalScore = int.Parse(this.textBox2.Text);
                this.Grade = this.comboBox.SelectedText;
                this.Date = this.dateTimePicker.Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                MessageBox.Show("Check to text format!");
                return;
            }
        }

        private void SubFormLoad(object sender, EventArgs e)
        {
            this.textBox1.Text = this.MiddleScore.ToString();
            this.textBox2.Text = this.FinalScore.ToString();
            this.comboBox.SelectedIndex = this.comboBox.FindString(this.Grade);
            this.dateTimePicker.Value = this.Date;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            int ms, fs;

            if (!int.TryParse(this.textBox1.Text, out ms)
                || !int.TryParse(this.textBox2.Text, out fs))
            {
                return;
            }

            switch((ms + fs) / 2 / 10)
            {
                case 9: this.comboBox.SelectedIndex = 0; break;
                case 8: this.comboBox.SelectedIndex = 1; break;
                case 7: this.comboBox.SelectedIndex = 2; break;
                case 6: this.comboBox.SelectedIndex = 3; break;
                default: this.comboBox.SelectedIndex = 4; break;
            }
        }
    }
}
