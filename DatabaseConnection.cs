using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LoginPage
{
    public class DatabaseConnection
    {
        public MySqlConnection conn;   //connection variable
        public string connString;      //string connection
        public MySqlCommand cmd;
        private string Course_Description;
        private int Course_ID;
        private string Course_Link;
        private byte[] Course_Image;
        private string Course_Name;
        private string Home_Course_Description;
        private string Course_auther;
        private string Course_date;
        private string Course_lang;
        private string Course_price;
        string U_courses;
        Sign_In S;
       
        public string Course_Description1 { get => Course_Description; set => Course_Description = value; }
        
        public int Course_ID1 { get => Course_ID; set => Course_ID = value; }
        public string Course_Link1 { get => Course_Link; set => Course_Link = value; }
        public byte[] Course_Image1 { get => Course_Image; set => Course_Image = value; }
        public string Course_Name1 { get => Course_Name; set => Course_Name = value; }
        public string Home_Course_Description1 { get => Home_Course_Description; set => Home_Course_Description = value; }
        public string Course_auther1 { get => Course_auther; set => Course_auther = value; }
        public string Course_date1 { get => Course_date; set => Course_date = value; }
        public string Course_lang1 { get => Course_lang; set => Course_lang = value; }
        public string Course_price1 { get => Course_price; set => Course_price = value; }

        //Singleton
        private static DatabaseConnection instance = null;
        private static object lockobj = new object();
        private DatabaseConnection(){ connect_to_database();  }

        public static DatabaseConnection GetInstance() {
            lock (lockobj)
            {
                if (instance == null)
                    instance = new DatabaseConnection();
                return instance;
            }
        }

        private void connect_to_database()
        {
            connString = @"Server=MYSQL5047.site4now.net; Database=db_a82e8b_a3go;Uid=a82e8b_a3go;Pwd=vAxMvxqtTXAw8Vq; SslMode=None";
            try
            {
                conn = new MySqlConnection(connString);
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string execute_scalar_query(string query)
        {
            
                string result = string.Empty;
                while (conn.State == ConnectionState.Open) ;
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                result = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
                return result;
        }

        public void execute_normal_query(string query)
        {
            while (conn.State == ConnectionState.Open) ;
            try
            {
                    conn.Open();
                    if (this.conn != null)
                    {
                        cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Your Information isn't added");
                    }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        //My_Courses
        public void retrieve_course_information(FlowLayoutPanel poster_container)
        {
            S = new Sign_In();
            U_courses = execute_scalar_query("SELECT Course_ID FROM users WHERE Device_Information = '" + S.deviceinfo + "';");
            List<int> U_Courses_ID = new List<int>();
            U_Courses_ID = extract_courses_ID(U_courses);


            //string query = "SELECT * FROM `courses` WHERE `Course_ID` = '" + ID + "' ;";

            string query = "SELECT * FROM `courses` WHERE 1;";
            //while (conn.State == ConnectionState.Open) ;
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

                        if (U_Courses_ID.BinarySearch(Convert.ToInt32(reader[0])) >= 0)
                        {
                            Course_Description = reader[6].ToString();
                            Course_Name = reader[2].ToString();
                            Course_ID = Convert.ToInt32(reader[0]);
                            Course_Image = ((byte[])reader[11]);
                            Course_Link = reader[1].ToString();
                            Poster post = new Poster();
                            post.Id = Course_ID;
                            post.Coursename = Course_Name;
                            post.Coursedescreption = Course_Description;
                            post.CourseLink = Course_Link;
                            MemoryStream stream = new MemoryStream(Course_Image);
                            post.Courseimage = Image.FromStream(stream);

                            poster_container.Controls.Add(post);
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
        }

        public List<int> extract_courses_ID(string IDs)
        {
            string temp = "";
            List<int> ID = new List<int>();
            for(int i = 0; i<IDs.Length; i++)
            {
                if (IDs[i] == ',')
                {
                    ID.Add(Convert.ToInt32(temp));
                    temp = "";
                }
                else if(i == (IDs.Length - 1))
                {
                    temp += IDs[i];
                    ID.Add(Convert.ToInt32(temp));
                    temp = "";
                }
                else
                    temp += IDs[i];
            }
            ID.Sort();
            return ID;
        }


        //Home
        public void retrieve_Home_information(FlowLayoutPanel Homeposter_container)
        {
            string query = "SELECT * FROM `courses` WHERE 1;";
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
                        
                        Course_ID = Convert.ToInt32(reader[0]);
                        Course_Image = ((byte[])reader[11]);
                        Course_Name = reader[2].ToString();
                        Home_Course_Description= reader[12].ToString();
                        Course_auther= reader[5].ToString();
                        Course_date= reader[7].ToString();
                        Course_lang= reader[4].ToString();
                        Course_price= reader[13].ToString();

                        Homeposter Hpost = new Homeposter();
                       
                        Hpost.Id = Course_ID;
                        MemoryStream stream = new MemoryStream(Course_Image);
                        Hpost.Courseimage = Image.FromStream(stream);
                        Hpost.Coursename = Course_Name;
                        Hpost.Coursedescreption =Home_Course_Description;
                        Hpost.Author = Course_auther;
                        Hpost.update_date = Course_date;
                        Hpost.language_Course = Course_lang;
                        Hpost.price_course = Course_price;
                       
                        Homeposter_container.Controls.Add(Hpost);
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
        }


    }
}


