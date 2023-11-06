namespace P1106
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            CreateForm form = new CreateForm();

            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}