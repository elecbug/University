namespace P1115
{
    public partial class Form1 : Form
    {
        List<Contact> list;

        public Form1()
        {
            InitializeComponent();

            this.contactListBox.Format += (s, e) =>
            {
                e.Value = (e.ListItem as Contact)!.FirstName + " " + (e.ListItem as Contact)!.LastName + "\t(" + (e.ListItem as Contact)!.Phone + ")";
            };
            this.callLogListBox.Format += (s, e) =>
            {
                e.Value = (e.ListItem as CallLog)!.When + "\t(" + (e.ListItem as CallLog)!.Duration + ")";
            };

            list = Contact.SampleList();

            foreach (var item in list)
            {
                this.contactListBox.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.callLogListBox.Items.Clear();
            Contact? select = this.contactListBox.SelectedItem as Contact;

            if (select != null)
            {
                List<CallLog> list = CallLog.SampleList().Where(x => x.Number == select!.Phone).ToList();

                foreach (var item in list)
                {
                    this.callLogListBox.Items.Add(item);
                }
            }
        }

        private void add_button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(null);

            if (form.ShowDialog() == DialogResult.Yes)
            {
                list.Add(form.Contact);
            }

            this.contactListBox.Items.Clear();

            foreach (var item in list)
                this.contactListBox.Items.Add(item);
        }

        private void delete_button2_Click(object sender, EventArgs e)
        {
            if (this.contactListBox.SelectedItem != null)
            {
                this.contactListBox.Items.Remove(this.contactListBox.SelectedItem);
            }
        }

        private void edit_button3_Click(object sender, EventArgs e)
        {
            if (this.contactListBox.SelectedItem != null)
            {
                list.Remove(this.contactListBox.SelectedItem as Contact);

                Form2 form = new Form2(this.contactListBox.SelectedItem as Contact);

                if (form.ShowDialog() == DialogResult.Yes)
                {
                    list.Add(form.Contact);
                }

                this.contactListBox.Items.Clear();

                foreach (var item in list)
                    this.contactListBox.Items.Add(item);
            }
        }

        private void search_button4_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;

            var sublist = this.list
                .Where(x => x.FirstName.ToLower().Contains(text.ToLower()) 
                || x.LastName.ToLower().Contains(text.ToLower())
                || x.Phone.ToString().ToLower().Contains(text.ToLower())).ToList();

            this.contactListBox.Items.Clear();

            foreach (var item in sublist)
                this.contactListBox.Items.Add(item);
        }
    }
}