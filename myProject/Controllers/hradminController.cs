using myProject.Models;
using myProject.pubClsMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace myProject.Controllers
{
    public class hradminController : Controller
    {
        // GET: hradmin
        public ActionResult Index()
        {
            var userInfo = Session["UserInfo"];
            ViewBag.is_login = !userInfo.IsNullOrEmpty() ? 1 : 0;
            return View();
        }
        public ActionResult Login(string name, string pwd)
        {
            Dictionary<string, object> _result = new Dictionary<string, object>();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pwd))
            {
                #region#非正常登陆
                _result.Add("status", false);
                _result.Add("message", "账号和密码都没填怎么登陆!");
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));
                #endregion
            }
            string _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var md5password = pubClsMod.securityTool.MD5Encrypt(pwd);

            using (var db=new myProjectContext())
            {
                try
                {
                    if (name.ToUpper() == "ADMIN")
                    {
                        #region#Admin登陆
                        var vesult = db.hradmin.AsNoTracking().FirstOrDefault(w => w.login_name == name && w.login_pwd == md5password);
                        if (vesult == null)
                        {
                            _result.Add("status", false);
                            _result.Add("message", "用户名或密码错误!");
                            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));
                        }
                        else
                        {
                            //为了营造和下面的非admin统一结构
                            hremp e = new hremp();
                            e.uuid = vesult.login_name;
                            e.login_name = vesult.login_name;
                            e.login_pwd = md5password;
                            e.name_emp = "系统管理员";

                            _result.Add("status", true);
                            _result.Add("message", "欢迎登陆!");

                            Session["UserInfo"] = e.ToJson();
                            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));
                        }
                        #endregion
                    }
                    else
                    {
                        #region#非Admin登陆
                        var vesult = db.hremp.AsNoTracking().FirstOrDefault(w => w.login_name == name);
                        if (vesult == null)
                        {
                            _result.Add("status", false);
                            _result.Add("message", "用户不存在!");
                            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));
                        }
                        if (vesult.login_pwd != md5password)
                        {
                            _result.Add("status", false);
                            _result.Add("message", "密码错误!");
                            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));
                        }
                        if (vesult.inactive == 1)
                        {
                            _result.Add("status", false);
                            _result.Add("message", "用户已被禁止登陆系统!");
                            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));
                        }
                        _result.Add("status", true);
                        _result.Add("message", "欢迎登陆!");

                        Session["UserInfo"] = vesult.ToJson();
                        return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));

                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    _result.Add("status", false);
                    _result.Add("message", ex.Message);
                    return Content(Newtonsoft.Json.JsonConvert.SerializeObject(_result));
                }
                finally
                {
                    db.Dispose();
                }
            }
        }
    }
}