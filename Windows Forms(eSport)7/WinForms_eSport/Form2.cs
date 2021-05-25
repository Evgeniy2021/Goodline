using System.Windows.Forms;

namespace WinForms_eSport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
           // Form1 newForm = new Form1();
           // newForm.Show();

            this.Close();
            //Application.ExitThread();

        }
    }
}
