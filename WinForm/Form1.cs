namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Do not enter the name.");
            }
            else
            {
                MessageBox.Show($"Hello, {textBox1.Text}!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                (checkBox1.Checked ? "Metaverse," : "") +
                (checkBox2.Checked ? "AI," : "") +
                (checkBox3.Checked ? "BigData," : "") +
                "Select now");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = "";
            if (radioButton1.Checked) { result += radioButton1.Text; }
            if (radioButton2.Checked) { result += radioButton2.Text; }
            if (radioButton3.Checked) { result += radioButton3.Text; }
            if (radioButton4.Checked) { result += radioButton4.Text; }
            if (radioButton5.Checked) { result += radioButton5.Text; }

            MessageBox.Show(result);
        }
    }
}