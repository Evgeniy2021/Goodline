using System.Windows.Forms;

namespace WinForms_eSport
{
    public partial class Form2 : Form
    {
        private bool opt = false;
        public Form2()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            opt = true;
            Form1 newForm = new Form1(opt);
            newForm.Show();
            this.Hide();
        }
        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            Form1 newForm = new Form1(opt);
            newForm.Show();
            this.Hide();
        }
    }
}
