using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class Homeposter : UserControl
    {
        public Homeposter()
        {
            InitializeComponent();
        }
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Image Courseimage
        {

            get { return Hphoto.Image; }
            set { Hphoto.Image = value; }
        }
        public string Coursename
        {
            get { return Hcoursename.Text; }
            set { Hcoursename.Text = value; }
        }
        public string Coursedescreption
        {
            get { return Hcoursedescreption.Text; }
            set { Hcoursedescreption.Text = value; }
        }
        public string Author
        {
            get { return HAuthor_name.Text; }
            set { HAuthor_name.Text = value; }
        }
        public string update_date
        {
            get { return HLast_update.Text; }
            set { HLast_update.Text= value; }
        }
        public string language_Course
        {
            get { return Hlang.Text; }
            set { Hlang.Text = value; }
        }

        public string price_course
        {
            get { return  HPrice.Text; }
            set { HPrice.Text = value; }
        }

        private void Homeposter_Load(object sender, EventArgs e)
        {

        }

       
    }
}
