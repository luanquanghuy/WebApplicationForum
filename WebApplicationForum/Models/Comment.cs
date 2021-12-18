using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationForum.Models
{
	public class Comment
	{
		public int commentId { get; set; }
		public string text { get; set; }
		public int postId { get; set; }
		public int userId {get; set;}
		public string username { get; set; }
		public string createTime { get; set; }

		public Comment(int commentId, string text, int postId, int userId, string username, string createTime)
		{
			this.commentId = commentId;
			this.text = text;
			this.postId = postId;
			this.userId = userId;
			this.username = username;
			this.createTime = createTime;
		}
	}
}