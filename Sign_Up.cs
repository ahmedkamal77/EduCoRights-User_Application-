using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace LoginPage
{
    public partial class Sign_Up : Form
    {
        DatabaseConnection signup_db;
        private int UserID;

        public MySqlCommand cmd;
        public MySqlConnection conn;
        GetDeviceInfo signup;
        #region min_max

        public Sign_Up()
        {
            InitializeComponent();
            signup_db = DatabaseConnection.GetInstance();  
            UserID = Convert.ToInt16(signup_db.execute_scalar_query("SELECT MAX(User_ID)+1 as ABC FROM users;"));
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Enter & Leave  for each textbox
        private void txtFullname_Enter(object sender, EventArgs e)
        {
            if (txtFullname.Text == "Full Name")
            {
                txtFullname.Text = "";
                txtFullname.ForeColor = Color.LightGray;

            }
        }

        private void txtFullname_Leave(object sender, EventArgs e)
        {
            if (txtFullname.Text == "")
            {
                txtFullname.Text = "Full Name";
                txtFullname.ForeColor = Color.DimGray;

            }
        }

        private void txtPhoneNo_Enter(object sender, EventArgs e)
        {

            if (txtPhoneNo.Text == "Phone Number")
            {
                txtPhoneNo.Text = "";
                txtPhoneNo.ForeColor = Color.LightGray;
            }
        }

        private void txtPhoneNo_Leave(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text == "")
            {
                txtPhoneNo.Text = "Phone Number";
                txtPhoneNo.ForeColor = Color.DimGray;

            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email Address")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;

            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email Address";
                txtEmail.ForeColor = Color.DimGray;

            }
        }


        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "User Name")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;

            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "User Name";
                txtUser.ForeColor = Color.DimGray;

            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Password";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;

            }
        }
        private void Conf_Pass_Leave(object sender, EventArgs e)
        {
            if (Conf_Pass.Text == "")
            {
                Conf_Pass.Text = "Confirm Password";
                Conf_Pass.ForeColor = Color.DimGray;
                Conf_Pass.UseSystemPasswordChar = false;
            }
        }

        private void Conf_Pass_Enter(object sender, EventArgs e)
        {

            if (Conf_Pass.Text == "Confirm Password")
            {
                Conf_Pass.Text = "";
                Conf_Pass.ForeColor = Color.LightGreen;
                Conf_Pass.UseSystemPasswordChar = true;
            }
        }
        #endregion

        #region handel movement of screen

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd
            , int wmsg, int wparam, int lparam);

        private void Sign_Up_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void lblclear_Click(object sender, EventArgs e)
        {
            txtFullname.Clear();
            txtFullname.Text = "Full Name";
            txtPhoneNo.Clear();
            txtPhoneNo.Text = "Phone Number";
            txtEmail.Clear();
            txtEmail.Text = "Email Address";
            txtUser.Clear();
            txtUser.Text = "User Name";
            txtPass.Clear();
            txtPass.Text = "Password";
            Conf_Pass.Clear();
            Conf_Pass.Text = "Confirm Password";
            txtPass.UseSystemPasswordChar = false;
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {

            if (IsValidEmail(txtEmail.Text) && IsValidPhone(txtPhoneNo.Text) && IsValidUser(txtUser.Text) && IsValidDevice() && IsValidPassword(txtPass.Text) && IsConfirmedPassword()) 
            {
               
               

                //Sign Up information insertion 
                signup_db.execute_normal_query("INSERT INTO users (User_ID, Full_Name, User_Name, Email, Password, Phone_Number, Device_Information) VALUES('" + UserID + "', '" + txtFullname.Text + "', '" + txtUser.Text + "', '" + txtEmail.Text + "', '" + txtPass.Text + "', '" + txtPhoneNo.Text + "', '" + signup.DeviceInfo() + "');");
                new Sign_In().Show();
                this.Hide();
            }

            else
            {
                if (IsValidPhone(txtPhoneNo.Text))
                    txtValidPhoneNumber.Text = "";
                else if (!IsValidPhone(txtPhoneNo.Text))
                    txtValidPhoneNumber.Text = "Invalid Phone Number";

                if (IsValidEmail(txtEmail.Text))
                    txtValidEmail.Text = "";
                else if (!IsValidEmail(txtEmail.Text))
                    txtValidEmail.Text = "Invalid Email address";

                if (IsValidUser(txtUser.Text))
                    txtValidUserName.Text = "";
                else if (!IsValidUser(txtUser.Text))
                    txtValidUserName.Text = "UserName already used";

                if (!IsValidDevice())
                    MessageBox.Show("This device is already registered");

                if (IsValidPassword(txtPass.Text))
                    txtValidPassword.Text = "";
                else
                    txtValidPassword.Text = "At least 7 characters (1 upper, 1 lower, 1 number, 1 special)";
                if (IsConfirmedPassword())
                    confirmpassvalidation.Text = "";
                else
                    confirmpassvalidation.Text = "Not matched password";

            }
        }

        //Check E-Mail validation 
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }



        //Check Phone Number validation
        bool IsValidPhone(string phone)
        {
            if (phone.Length == 11) return true; 
            else return false; 
        }

        //Check User Name validation
        bool IsValidUser(string Uname)
        {
            string t = "";
            t = signup_db.execute_scalar_query("SELECT User_Name FROM users WHERE User_Name = '" + Uname + "';"); ;
            if (t == "") return true; 
            else return false; 
        }

        bool IsValidDevice()
        {
            //string t = "";
            string query = "SELECT * FROM `users` WHERE 1;";
            signup = new GetDeviceInfo();
            conn = new MySqlConnection(@"Server=MYSQL5047.site4now.net; Database=db_a82e8b_a3go;Uid=a82e8b_a3go;Pwd=vAxMvxqtTXAw8Vq; SslMode=None");
            bool f = true;
            string df = signup.DeviceInfo().ToString();
            try
            {
                conn.Open();
                if (this.conn != null)
                {
                    cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        if(reader[6].ToString() == df)
                        {
                            f = false;
                            break;
                        }
                        
                    }

                }
                else
                {
                    MessageBox.Show(" Error while connection !! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            return f;
        }
        //confirmpass
        bool IsConfirmedPassword()
        {
            if (IsValidPassword(txtPass.Text))
            {
                if (txtPass.Text == Conf_Pass.Text)
                    return true;
                else
                    return false;
            }
            else return false;
        }


        //Password Validation
        private static int Minimum_Length = 7;
        private static int Upper_Case_length = 1;
        private static int Lower_Case_length = 1;
        private static int NonAlpha_length = 1;
        //private static int Numeric_length = 1;

        private static int UpperCaseCount(string Password)
        {
            return Regex.Matches(Password, "[A-Z]").Count;
        }

        private static int LowerCaseCount(string Password)
        {
            return Regex.Matches(Password, "[a-z]").Count;
        }
        private static int NumericCount(string Password)
        {
            return Regex.Matches(Password, "[0-9]").Count;
        }
        private static int NonAlphaCount(string Password)
        {
            return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
        }

        public static bool IsValidPassword(string Password)
        {
            if (Password.Length < Minimum_Length)
                return false;
            if (UpperCaseCount(Password) < Upper_Case_length)
                return false;
            if (LowerCaseCount(Password) < Lower_Case_length)
                return false;
            if (NumericCount(Password) < 1)
                return false;
            if (NonAlphaCount(Password) < NonAlpha_length)
                return false;
            return true;
        }

        private void Signuplink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Sign_In().Show();
            this.Hide();
        }

        public Sign_In Sign_In
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
