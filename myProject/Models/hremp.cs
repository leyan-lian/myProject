using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.Models
{
    public class hremp
    {
        public string uuid { get; set; }
        public string name_emp { get; set; }
        public string phone_emp { get; set; }
        public string idcard_emp { get; set; }
        public string org_emp { get; set; }
        public string login_name { get; set; }
        public string login_pwd { get; set; }
        public string role { get; set; }
        public int inactive { get; set; }
    }
}