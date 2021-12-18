using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationForum.Data;

namespace WebApplicationForum.Controllers
{
    public class PostController : Controller
    {
		PostData postData = new PostData();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
		{

            return Json(postData.getList(), JsonRequestBehavior.AllowGet);

        }

		[HttpPost]
		public string Create()
		{
			string title = Request.Form.Get("title");
			string body = Request.Form.Get("body");
			string userId = Request.Form.Get("userid");
			if (!postData.createPost(title, body, userId))
			{
				return "Error create post";
			}
			return "success";
		}
	}
}