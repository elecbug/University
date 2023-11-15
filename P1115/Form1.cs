namespace P1115
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.listBox1.Format += (s, e) =>
            {
                e.Value = (e.ListItem as Contact)!.FirstName + "\t(" + (e.ListItem as Contact)!.Phone + ")";
            };
            this.listBox2.Format += (s, e) =>
            {
                e.Value = (e.ListItem as CallLog)!.When + "\t(" + (e.ListItem as CallLog)!.Duration + ")";
            };

            List<Contact> list = Contact.SampleList();

            foreach (var item in list)
            {
                this.listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox2.Items.Clear();
            Contact select = this.listBox1.SelectedItem as Contact;

            List<CallLog> list = CallLog.SampleList().Where(x=>x.Number == select.Phone).ToList();

            foreach (var item in list)
            {
                this.listBox2.Items.Add(item);
            }
        }
    }
}