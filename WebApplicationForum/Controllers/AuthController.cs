using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationForum.Data;

namespace WebApplicationForum.Controllers
{
    public class AuthController : Controller
    {
        UserData dao = new UserData();
        // GET: Auth
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public string Login()
        {
            string user = Request.Form.Get("taikhoan");
            string pass = Request.Form.Get("matkhau");
            if (user == "" || pass == "")
            {
                TempData["err"] = "vui lòng nhập đủ các trường dữ liệu";
                return "vui lòng nhập đủ các trường dữ liệu";
            }
            string result = dao.login(user, pass);
            if (result == "")
            {
                TempData["err"] = "tài khoản mật khẩu sai";
                return "tài khoản mật khẩu sai";
            }
            Session.Add("username", user);
            return result;
        }


        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public string Signup()
        {
            string user = Request.Form.Get("taikhoan").Trim();
            string pass = Request.Form.Get("matkhau").Trim();
            string repass = Request.Form.Get("rematkhau").Trim();
            if (user == "" || pass == "" || repass == "")
            {
                TempData["err"] = "vui lòng nhập đủ các trường dữ liệu";
                return "vui lòng nhập đủ các trường dữ liệu";
            }
            if (pass != repass)
            {
                TempData["err"] = "mật khẩu nhập lại không khớp";
                return "mật khẩu nhập lại không khớp";
            }
            if (!dao.checkunique(user))
            {
                TempData["err"] = "tài khoản đã tồn tại";
                return "tài khoản đã tồn tại";
            }
            if (!dao.signup(user, pass))
            {
                TempData["err"] = "đăng ký thất bại";
                return "đăng ký thất bại";
            }
            return "OK";
        }
    }
}