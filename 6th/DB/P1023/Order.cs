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
    public partial class Order : Form
    {
        public Table1? Item { get; private set; }

        public Order(Table1? item)
        {
            InitializeComponent();

            this.Item = item;

            if (this.Item != null)
            {
                this.dateTimePicker.Value = this.Item.Date;
                this.phoneTextBox.Text = this.Item.Phone;
                this.typeComboBox.SelectedIndex = this.Item.Type;
                this.stateComboBox.SelectedIndex = this.Item.State;
            }
        }

        private void OkClick(object sender, EventArgs e)
        {
            try
            {
                this.Item = new Table1()
                {
                    Date = this.dateTimePicker.Value,
                    Phone = this.phoneTextBox.Text,
                    Type = this.typeComboBox.SelectedIndex,
                    State = this.stateComboBox.SelectedIndex,
                };

                if (this.Item.Type == -1 || this.Item.State == -1)
                    throw new Exception();

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Retry");
            }
        }

        private void TextBoxPreviewKeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
        }
    }
}
