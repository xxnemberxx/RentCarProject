using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Settings
    {
        public static string Root = Environment.CurrentDirectory + "\\wwwroot";
        public static string ImgFolder = "\\Images\\";
        public static string ImgPath = Root + ImgFolder;
    }
}
