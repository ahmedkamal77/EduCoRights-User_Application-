using System;
using System.Threading;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        Sign_In S;
        DatabaseConnection dc;
        public RadForm1()
        {
            InitializeComponent();
            dc = DatabaseConnection.GetInstance();
            S = new Sign_In();
            label3.Text = dc.execute_scalar_query("SELECT User_Name FROM users WHERE Device_Information = '" +S.deviceinfo+"';");
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
                new EducoRights().Show();
            }
        } 
    }
}
