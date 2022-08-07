using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Runtime.InteropServices;
using System.IO;

namespace LoginPage
{
    public partial class Sign_In : Telerik.WinControls.UI.RadForm
    {
        public string deviceinfo;
        private string Username = "";
        private string RU = "", RP = "";  //Remember Username and Password 
        DatabaseConnection signin_db;
        GetDeviceInfo dInfo;


        public Sign_In()
        {
            InitializeComponent();
            signin_db = DatabaseConnection.GetInstance();
            dInfo = new GetDeviceInfo();
            deviceinfo = dInfo.DeviceInfo();
            Check_remember();
        }
       

        private void textuser_Enter(object sender, EventArgs e)
        {

            if (textuser.Text == "Username")
            {
                textuser.Text = "";
                textuser.ForeColor = Color.LightGray;
            }
        }

        private void textuser_Leave(object sender, EventArgs e)
        {
            if (textuser.Text == "")
            {
                textuser.Text = "Username";
                textuser.ForeColor = Color.DimGray;
            }
        }


        private void textpassword_Enter(object sender, EventArgs e)
        {
            if (textpassword.Text != "")
            {
                if(textpassword.Text == "Password")
                    textpassword.Text = "";

                textpassword.ForeColor = Color.LightGray;
                textpassword.UseSystemPasswordChar = true;
            }
        }

        private void textpassword_Leave(object sender, EventArgs e)
        {
            if (textpassword.Text == "")
            {

                textpassword.Text = "Password";
                textpassword.ForeColor = Color.DimGray;
                textpassword.UseSystemPasswordChar = false;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd
            , int wmsg, int wparam, int lparam);

        private void RadForm1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Username = textuser.Text;
            string password = textpassword.Text;
            string db_deviceinfo = signin_db.execute_scalar_query("SELECT Device_Information FROM users WHERE User_Name = '" + Username + "' AND Password = '" + password + "';");

            if (IsUserExsisted(textuser.Text) && IsPasswordCorrect(textpassword.Text) && db_deviceinfo == deviceinfo)
            {
                txtExistedUser.Text = "";
                txtCorrectPassword.Text = "";
                textuser.Text = Username;

                new RadForm1().Show(); //Welcome Page
                this.Hide();
            }

            else
            {
                if (IsUserExsisted(textuser.Text))
                    txtExistedUser.Text = "";
                else if (!IsUserExsisted(textuser.Text))
                    txtExistedUser.Text = "Invalid Username";

                if (IsPasswordCorrect(textpassword.Text))
                    txtCorrectPassword.Text = "";
                else if (!IsPasswordCorrect(textpassword.Text))
                    txtCorrectPassword.Text = "Incorrect Password";

                if (IsUserExsisted(textuser.Text) && IsPasswordCorrect(textpassword.Text))
                    if (db_deviceinfo != deviceinfo)
                        MessageBox.Show("Different Device");
            }

        }


        //Check User exsitance
        bool IsUserExsisted(string username)
        {
          
            if (signin_db.execute_scalar_query("SELECT User_Name FROM users WHERE User_Name = '" + username + "';") == username) return true;
            else return false;
        }

        //Check Password correction
        bool IsPasswordCorrect(string password)
        {
            if (signin_db.execute_scalar_query("SELECT Password FROM users WHERE Password = '" + password + "';") == password) return true;
            else return false;
        }

        private void Signuplink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Sign_Up().Show();
            this.Hide();
        }

       

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            if (textpassword.Text != "Password" && textpassword.UseSystemPasswordChar == true)
            {
                textpassword.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (textpassword.Text != "Password" && textpassword.UseSystemPasswordChar == false)
            {
                textpassword.UseSystemPasswordChar = true;
            }
        }

        int rem = 0;
        private void Check_remember()
        {

            //if (IsUserExsisted(get_Username()))
            if(signin_db.execute_scalar_query("SELECT `Remmber_Me_Flag` FROM `users` WHERE `Device_Information`= '" + deviceinfo + "';") != "")
            {
                rem = Convert.ToInt32(signin_db.execute_scalar_query("SELECT `Remmber_Me_Flag` FROM `users` WHERE `Device_Information`= '" + deviceinfo + "';"));
                if (rem == 1)
                {
                    RP = signin_db.execute_scalar_query("SELECT `Password` FROM `users` WHERE `Device_Information`= '" + deviceinfo + "';");
                    textpassword.Text = RP;
                    RU = signin_db.execute_scalar_query("SELECT `User_Name` FROM `users` WHERE `Device_Information`= '" + deviceinfo + "';");
                    textuser.Text = RU;
                    btnRem.Checked = true;
                }
            }
        }

        private void btnRem_CheckedChanged(object sender, EventArgs e)
        {

            if (IsUserExsisted(textuser.Text))
            {
                if (btnRem.Checked)
                {
                    signin_db.execute_normal_query("UPDATE `users` SET `Remmber_Me_Flag` = '1' WHERE `Device_Information`= '" + deviceinfo + "';");
                    textpassword.UseSystemPasswordChar = true;
                }
                else
                    signin_db.execute_normal_query("UPDATE `users` SET `Remmber_Me_Flag` = '0' WHERE `Device_Information`= '" + deviceinfo + "';");
            }
        }

        public string get_Username() { return Username; }

        public Sign_Up Sign_Up
        {
            get => default;
            set
            {
            }
        }

        public RadForm1 Welcome
        {
            get => default;
            set
            {
            }
        }

        public GetDeviceInfo GetDeviceInfo
        {
            get => default;
            set
            {
            }
        }

       
        public DatabaseConnection DatabaseConnection
        {
            get => default;
            set
            {
            }
        }
    }
}
