namespace CustomAddForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomAddForm form = new CustomAddForm(new Pair[]
            {
                new Pair("Name", new TextBox()),
                new Pair("Address", new TextBox()),
                new Pair("Birthday", new DateTimePicker()),
                new Pair("ID", new TextBox()),
                new Pair("Ok", new CheckBox()),
            });

            form.ShowDialog();

            string name = form.Pairs.Where(x => x.LabelText == "Name").First().Control.Text;

            MessageBox.Show(name);
        }
    }
}