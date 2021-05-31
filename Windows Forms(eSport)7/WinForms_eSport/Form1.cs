using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms_eSport
{
    public partial class Form1 : Form
    {
        public Presenter presenter;
        private bool IsAdmin;
        public Form1(bool optUserAdmin)
        {
            IsAdmin = optUserAdmin;
            InitializeComponent();
            Model model = new Model();
            presenter = new Presenter(this, model);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage1"];

        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage2"];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage3"];
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage4"];
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage5"];
        }
        public void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage6"];
        }
        public void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage7"];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Label lb1 = new Label();
            lb1.Text = "Все участники турнира";
            lb1.Width = 250;
            lb1.Location = new Point(380, 10);
            lb1.Font = new Font("Tahoma", 14, FontStyle.Italic);
            lb1.ForeColor = Color.Navy;
            tabControl1.TabPages[0].Controls.Add(lb1);
            Label lb2 = new Label();
            lb2.Text =  "Все ";
            lb2.Width = 250;
            lb2.Location = new Point(150, 20);
            lb2.Font = new Font("Tahoma", 14, FontStyle.Italic);
            lb2.ForeColor = Color.Green;
            tabControl1.TabPages[0].Controls.Add(lb2);
            if (IsAdmin)
            {
                Button button6 = new Button();
                button6.Text = "Добавить команду";
                button6.Width = 145;
                button6.Height = 77;
                button6.Location = new Point(0, 492);
                button6.Font = new Font("Tahoma", 12, FontStyle.Bold);
                button6.ForeColor = Color.Indigo;
                button6.BackColor = Color.AliceBlue;
                button6.TabIndex = 5;
                Controls.Add(button6);
                button6.Click += new EventHandler(button6_Click);
                Button button7 = new Button();
                button7.Text = "Удалить команду";
                button7.Width = 145;
                button7.Height = 77;
                button7.Location = new Point(0, 574);
                button7.Font = new Font("Tahoma", 12, FontStyle.Bold);
                button7.ForeColor = Color.Indigo;
                button7.BackColor = Color.AliceBlue;
                button7.TabIndex = 6;
                Controls.Add(button7);
                button7.Click += new EventHandler(button7_Click);
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
