using AltoHttp;
using HtmlAgilityPack;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Import;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LoginPage
{
    public partial class Poster : UserControl
    {
        private int id = 0;
        private string description = " Description of course";
        private string courselink = string.Empty;
        HttpDownloader httpDownloader;
        string file_name = "";
        string temp3;
        EducoRights t;
        EducoRights j;
        dec_file decryption;
        DatabaseConnection db;

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        public Poster()
        {
            InitializeComponent();
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Coursename
        {
            get { return coursename.Text; }
            set { coursename.Text = value; }

        }

        public string Coursedescreption
        {
            get { return coursedescreption.Text; }
            set { coursedescreption.Text = value; }
        }

        public Image Courseimage
        {

            get { return photo.Image; }
            set { photo.Image = value; }
        }
        public string CourseLink
        {

            get { return courselink; }
            set { courselink = value; }
        }
        public string progressthemename
        {

            get { return progressBar.ThemeName; }
            set { progressBar.ThemeName = value; }
        }

        public static Poster ActiveForm { get; internal set; }

        private void Poster_Load(object sender, EventArgs e)
        {
            //Check if the course is exsited in the device or not
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + Coursename))
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + Coursename + ".zip"))
                    File.Delete(Directory.GetCurrentDirectory() + "\\" + Coursename + ".zip");
                btndownload.Visible = false;
                progressBar.Visible = false;
                
            }
        }

        private void btndownload_Click(object sender, EventArgs e)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(courselink);
            var tags = document.DocumentNode.SelectNodes("//div[@class='download_link']//a[@class='input popsok']").First().Attributes["href"].Value;

            if (!(File.Exists(Directory.GetCurrentDirectory() + "\\" + Coursename + ".zip")))
            {
                httpDownloader = new HttpDownloader(tags, Directory.GetCurrentDirectory() + "\\" + Coursename + ".zip"); 
                httpDownloader.DownloadCompleted += HttpDownloader_DownloadCompleted;
                httpDownloader.ProgressChanged += HttpDownloader_ProgressChanged;
                httpDownloader.Start();
            }
            else
                File.Delete(Directory.GetCurrentDirectory() + "\\" + file_name); //To delete ZIP file after extraction

        }

        private void HttpDownloader_ProgressChanged(object sender, AltoHttp.ProgressChangedEventArgs e)
        {
            progressBar.Value1 = (int)e.Progress;
        }

        private void HttpDownloader_DownloadCompleted(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                progressBar.Text = "100 %";
                if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + Coursename)) 
                    Directory.Delete(Directory.GetCurrentDirectory() + "\\" + Coursename);
                else
                    System.IO.Compression.ZipFile.ExtractToDirectory(Directory.GetCurrentDirectory() + "\\" + Coursename + ".zip", Directory.GetCurrentDirectory() + "\\" + Coursename);

                btndownload.Visible = false;
                progressBar.Visible = false;
            });
        }
     
        private void startcourse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            t = new EducoRights();
            t = (EducoRights)EducoRights.ActiveForm;
            t.change_width(true);
            t.Clear_list_item();
            t.ProcessCompleted += t_ProcessCompleted; // register with an event
            //  t.StartProcess();
            string root = Directory.GetCurrentDirectory() + "\\" + Coursename;
            // Get a list of all subdirectories  
            var files = from file in
            Directory.EnumerateFiles(root)
                        select file;
            foreach (var file in files)
            {
                temp3 = string.Empty;
                int i = file.Length - 1;
                while (file[i] != '\\')
                {
                    temp3 = file[i] + temp3;
                    i--;
                }
                t.creat_item(temp3);
            } 
        }
        public void t_ProcessCompleted(object sender, string SELECTED_ITEM)
        {
            string ext = string.Empty;
            var stream=new MemoryStream();
            

            j = new EducoRights();
            j = (EducoRights)EducoRights.ActiveForm;
            //Write what you want to do after selecting an item from Listbox1
            var I = new Poster();
            byte[] SelectedFile = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\" + Coursename + "\\" + SELECTED_ITEM);
            I.decryption = dec_file.GetInstance();
            I.db = DatabaseConnection.GetInstance();
            string TDES = I.db.execute_scalar_query("SELECT `TripleDES_Password` FROM `courses` WHERE `Course_Name` = '" + Coursename + "' ;");
            string AES = I.db.execute_scalar_query("SELECT `AES_Password` FROM `courses` WHERE `Course_Name` = '" + Coursename + "' ;");
            SelectedFile = I.decryption.decrypt_TDES(TDES, SelectedFile);
            SelectedFile = I.decryption.decrypt_AES(AES, SelectedFile);
            stream = new MemoryStream(SelectedFile);

            ext = Path.GetExtension(Directory.GetCurrentDirectory() + "\\" + Coursename + "\\" + SELECTED_ITEM);
            if (ext == ".pdf")
            {

                PdfFormatProvider provider = new PdfFormatProvider();
                provider.ImportSettings = PdfImportSettings.ReadOnDemand;
                RadFixedDocument doc = provider.Import(stream);
                j.view_doc(stream);
            }

            else if (ext == ".mp4")
            {
                File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\" + Coursename + SELECTED_ITEM, SelectedFile);
                j.set_path(Directory.GetCurrentDirectory() + "\\" + Coursename + SELECTED_ITEM);
            }



        }

       
    }
}
