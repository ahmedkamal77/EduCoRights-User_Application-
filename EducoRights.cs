using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LoginPage
{
    
    public partial class EducoRights : Form
    {
       
        public event EventHandler <string> ProcessCompleted;

        const uint WDA_MONITOR = 1;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        public EducoRights()
        {
            InitializeComponent();
            draw_posters();
            radPdfViewer1.RadContextMenu.DropDownOpening += RadContextMenu_DropDownOpening;   
        }
        void RadContextMenu_DropDownOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        #region Mediaplayer

        double time;
        private string path_URL = "";
        public void set_path(string value)
        {   
            path_URL = value; 
            if(media.Visible == false)
            {
                media.Visible = true;
                video_Nav.Visible = true;
                radPdfViewer1.Visible = false;
                radPdfViewerNavigator1.Visible = false;
                this.media.URL = path_URL;
                this.media.Ctlcontrols.play();
                File.Delete(path_URL);
            }
        }
        
        private void playToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.play();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.pause();
            time = this.media.Ctlcontrols.currentPosition;
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.currentPosition = time;
            this.media.Ctlcontrols.play();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.stop();
        }

        private void previosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.previous();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.next();
        }

        private void fastForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.fastForward();
        }

        private void fastReverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.media.Ctlcontrols.fastReverse();
        }

#endregion

        #region Poster

        private void draw_posters()
        {
            DatabaseConnection db_conn = DatabaseConnection.GetInstance();
            db_conn.retrieve_Home_information(appHome1);
            db_conn.retrieve_course_information(appCourses1);
            
        }
       
        public void creat_item(string item_name)
        {
            this.listBox1.Items.Add(item_name);
            listBox1.Visible = true;
            course.Visible = true;
            hiddenlist.Visible = true;
            Listcontaner.Visible = true;
            pdfcontaner.Visible = true;
            appHome1.Visible = false;
            appCourses1.Visible = false;
            label1.Visible = false;   
        }

        public void Clear_list_item()
        {
            listBox1.Items.Clear();
            radPdfViewer1.Visible = false;
            radPdfViewerNavigator1.Visible = false;
            media.Visible = false;
            video_Nav.Visible = false;
        }

        public void view_doc(Stream Streampost)
        {
            if (radPdfViewer1.Visible == false)
            {  
                radPdfViewer1.Visible = true;
                radPdfViewerNavigator1.Visible = true;
                this.media.Ctlcontrols.stop();
                media.Visible = false;
                video_Nav.Visible = false;
            }

            radPdfViewer1.LoadDocument(Streampost);
        }
        
        private void hiddenlist_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == true)
            { listBox1.Visible = false;
            Listcontaner.Visible = false; }
            else
            { 
               listBox1.Visible = true;
               Listcontaner.Visible = true;
            }
            
        }

        private void appHome1_Load(object sender, EventArgs e)
        {

        }


        #endregion

        #region function of form min_max

        private void EducoRights_Load(object sender, EventArgs e)
        {
            SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
            listBox1.Visible = false;
            listBox1.Height = 21;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            if(Properties.Settings.Default.teme != "" )
            {
                changeTheme(Properties.Settings.Default.teme);
                if( Properties.Settings.Default.teme == "Light")
                {   
                    dark.Visible = true;
                    Light.Visible = false;
                }
                else
                {
                    Light.Visible = true;
                    dark.Visible = false;         
                }

            }
            else
            {
                changeTheme("Light");
                dark.Visible = true;
                Light.Visible = false;
            }
        }
               
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelcontent.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(32, 47, 66));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        #endregion

        #region  btn Close,minimize,maximize,normal

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int lx, ly;
        int sw, sh;

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximize.Visible = false;
            btnNormal.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }


        private void btnNormal_Click(object sender, EventArgs e)
        {
            btnMaximize.Visible = true;
            btnNormal.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        #endregion

        #region Light_Dark
        private void dark_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.teme = "Dark";
            Properties.Settings.Default.Save();
            changeTheme(Properties.Settings.Default.teme);
            Light.Visible = true;
            dark.Visible = false;
        }
        private void Light_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.teme = "Light";
            Properties.Settings.Default.Save();
            changeTheme(Properties.Settings.Default.teme);
            dark.Visible = true;
            Light.Visible = false;
        }
       
        private void changeTheme(string teme)
        {

            Light_Dark.themeChanger(teme);
            
            panelHeader.BackColor = Light_Dark.panelheader;
            panelcontent.BackColor = Light_Dark.mainform;
            panelslider.BackColor = Light_Dark.mainform;
            iconimage.BackColor = Light_Dark.panelbtn;
            btnMycourses.Textcolor = Light_Dark.ffontco;
            btnHome.Textcolor  = Light_Dark.ffontco;
            label1.ForeColor = Light_Dark.ffontco;
            listBox1.BackColor = Light_Dark.Label;
            listBox1.ForeColor = Light_Dark.Listboxfont;
            video_Nav.BackColor = Light_Dark.Label;
            video_Nav.ForeColor = Light_Dark.Listboxfont;
            radPdfViewer1.ThemeName = Light_Dark.mode2;

            radPdfViewerNavigator1.ThemeName = Light_Dark.mode2;
            foreach (Poster item in appCourses1.Controls)
            {
                 item.BackColor = Light_Dark.postcolor;
                 item.progressthemename = Light_Dark.mode;
            }
            foreach (Homeposter item in  appHome1.Controls)
            {
                item.BackColor = Light_Dark.postcolor;
                
            }

            if (f)
            { 
                Lable.BackColor = Light_Dark.Label;
            }
            else
            {
                Lable.BackColor = Color.Transparent;
            }

        }
        #endregion
        #region Process

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartProcess();
        }

        public void StartProcess()
        {
                OnProcessCompleted(Convert.ToString(listBox1.SelectedItem)); 
        }

        protected virtual void OnProcessCompleted(string SELECTED_ITEM)
        {
            ProcessCompleted?.Invoke(this, SELECTED_ITEM);
        }

        #endregion

        #region switch
    
        public void change_width (bool flag)
        {
            f = flag;
            if (flag)
            {
                if (iconimage.Width >= 210)
                {
                    logoAnimator.Hide(logopic);
                    iconimage.Visible = false;
                    iconimage.Width = 75;
                    panelAnimator.ShowSync(iconimage);
                }
               
            }

        }


        private void btnSwitch_Click_1(object sender, EventArgs e)
        {
            if (iconimage.Width == 75)
            {
                iconimage.Visible = false;
                iconimage.Width = 240;
                panelAnimator.ShowSync(iconimage);
                logoAnimator.ShowSync(logopic);
            }
            else
            {
                logoAnimator.Hide(logopic);
                iconimage.Visible = false;
                iconimage.Width = 75;
                panelAnimator.ShowSync(iconimage);
            }

        }

       
        bool f = false;
        private void btnMycourses_Click_1(object sender, EventArgs e)
        {
            label1.Text = "My Courses";
            btnMycourses.IsTab = true;
            appCourses1.Visible = false;
            hiddenlist.Visible = false;
            course.Visible = false;
            f = false;
            appCourses1.BringToFront();
            bunifuTransition1.ShowSync(appCourses1);
            this.media.Ctlcontrols.stop();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Home";
            appHome1.Visible = false;
            hiddenlist.Visible = false;
            course.Visible = false;
            f = false;
            appHome1.BringToFront();
            bunifuTransition1.ShowSync(appHome1);
            this.media.Ctlcontrols.stop();

        }
       
        
        #endregion


    }
}
