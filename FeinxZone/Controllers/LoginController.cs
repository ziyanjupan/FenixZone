using FeinxZone.Helper;
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


    }
}