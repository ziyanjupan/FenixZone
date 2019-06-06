using FeinxZone.Helper;
using FeinxZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeinxZone.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCheckCode()
        {
            string str;
            var memoryStream = ImageHelper.GenerateCheckCode(out str);
            base.Session["checkCode"] = str;
            return base.File(memoryStream.ToArray(), "image/png");
        }


        [HttpPost]
        public JsonResult CheckCode(string checkCode)
        {
            JsonResult jsonResult;
            try
            {
                string item = base.Session["checkCode"] as string;
                bool lower = item.ToLower() == checkCode.ToLower();
                jsonResult = Json(new { success = lower });
            }
            catch (Exception)
            {
                jsonResult = Json(new { success = false, msg = "未知错误" });
            }
            return jsonResult;
        }

        public ActionResult Login(User user)
        {
            JsonResult jsonResult;
            if (user.Name.Equals("zhangsan") && user.Password.Equals("123"))
            {
                jsonResult = Json(new { success = true });
            }
            else
            {
                jsonResult = Json(new { success = false, msg = "账号或密码错误" });
            }
            return jsonResult;
        }


    }
}