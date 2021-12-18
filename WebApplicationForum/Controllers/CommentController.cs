using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationForum.Data;

namespace WebApplicationForum.Controllers
{
    public class CommentController : Controller
    {
		CommentData commentData = new CommentData();
		// GET: Comment
		public ActionResult List()
		{
			string postId = Request.Form.Get("postid");
			return Json(commentData.getList(postId), JsonRequestBehavior.AllowGet);

		}

		[HttpPost]
		public string Create()
		{
			string text = Request.Form.Get("replytext");
			string postId = Request.Form.Get("postid");
			string userId = Request.Form.Get("userid");
			if (!commentData.createComment(text, postId, userId))
			{
				return "Error create comment";
			}
			return "success";
		}
	}
}