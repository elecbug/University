using P1023.db1023;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1023
{
    public partial class Menu : Form
    {
        public Table2? Item { get; private set; } = null;

        public Menu(Table2? item)
        {
            InitializeComponent();

            this.numericUpDown.Minimum = 1;

            this.Item = item;

            using (Db1023Context db = new Db1023Context())
            {
                foreach (var dateItem in db.Table1s.ToList())
                {
                    this.comboBox.Items.Add(dateItem.Date);
                }
            }

            if (this.Item != null)
            {
                this.dateTimePicker.Value = this.Item.Date;
                this.comboBox.SelectedItem = this.Item.Fkdate;
                this.menuTextBox.Text = this.Item.Menu;
                this.numericUpDown.Value = this.Item.Num;
            }
        }

        private void OkClick(object sender, EventArgs e)
        {
            try
            {
                this.Item = new Table2()
                {
                    Date = this.dateTimePicker.Value,
                    Fkdate = (DateTime)this.comboBox.SelectedItem,
                    Menu = this.menuTextBox.Text,
                    Num = (int)this.numericUpDown.Value,
                };

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Retry");
            }
        }
    }
}
