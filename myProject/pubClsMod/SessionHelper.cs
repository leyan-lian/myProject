using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myProject.pubClsMod
{
    public class SessionHelper
    {
    }
    public static class objectex
    {
        /// <summary>
        /// 判断是否为Null或者空
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj == null)
                return true;
            else
            {
                string objStr = obj.ToString();
                return string.IsNullOrEmpty(objStr);
            }
        }
    }
}