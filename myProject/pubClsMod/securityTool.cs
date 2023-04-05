using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.pubClsMod
{
    public class securityTool
    {
        public static string MD5Encrypt(string strText)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5").ToLower();
        }
    }
}