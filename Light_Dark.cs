using System.Drawing;

namespace LoginPage
{
   public static class Light_Dark
    {
        public static Color panelheader;
        public static Color panelbtn;
        public static Color mainform;
        public static Color postcolor;
        public static Color ffontco;
        public static Color actcolor;
        public static Color hovcolor;
        public static Color Label;
        public static Color Listboxfont;
        public static string mode;
        public static string mode2;



        //Dark
        private static readonly Color panelheaderD = Color.FromArgb(25, 35, 50);
        private static readonly Color panelbtnD = Color.FromArgb(25, 35, 50);
        private static readonly Color mainformD = Color.FromArgb(32, 47, 66);
        private static readonly Color postcolorD = Color.FromArgb(41, 41, 41);
        private static readonly Color ffontcoD = Color.White;
        private static readonly Color actcolorD = Color.FromArgb(10, 10, 10);
        private static readonly Color hovcolorD = Color.FromArgb(10, 10, 10);
        private static readonly Color LableD = Color.FromArgb(47, 47, 47);
        private static readonly Color listboxfontD= Color.FromArgb(16, 110, 190);
        private static readonly string modeD  = "FluentDark";
        private static readonly string mode2D = "Office2019Dark";

        //Light
        private static readonly Color panelheaderL = Color.FromArgb(25, 35, 50);
        private static readonly Color panelbtnL = Color.FromArgb(200, 200, 200);
        private static readonly Color mainformL = Color.FromArgb(230, 230, 230);
        private static readonly Color postcolorL = Color.White;
        private static readonly Color ffontcoL = Color.FromArgb(36,36,36);
        private static readonly Color actcolorL = Color.FromArgb(10, 10, 10);
        private static readonly Color hovcolorL = Color.FromArgb(10, 10, 10);
        private static readonly Color LableL = Color.FromArgb(230, 230,230);
        private static readonly Color listboxfontL = Color.Black;
        private static readonly string modeL = "ControlDefault";
        private static readonly string mode2L = "Office2019Light";


        public static void themeChanger (string teme)
        {

            if(teme == "Dark")
            {
                panelheader = panelheaderD;
                panelbtn = panelbtnD;
                mainform = mainformD;
                postcolor = postcolorD;
                ffontco = ffontcoD;
                actcolor = actcolorD;
                hovcolor = hovcolorD;
                mode = modeD;
                mode2 = mode2D;
                Label = LableD;
                Listboxfont = listboxfontD;
            }

            if (teme == "Light")
            {
                panelheader = panelheaderL;
                panelbtn = panelbtnL;
                mainform = mainformL;
                postcolor = postcolorL;
                ffontco = ffontcoL;
                actcolor = actcolorL;
                hovcolor = hovcolorL;
                mode = modeL;
                mode2 = mode2L;
                Label = LableL;
                Listboxfont = listboxfontL;
            }

        }






    }

}
