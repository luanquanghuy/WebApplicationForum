using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationForum.Models
{
	public class Post
	{
		public int postId { get; set; }
		public string title { get; set; }
		public string body { get; set; }
		public int userId { get; set; }
		public string username { get; set; }
		public string createTime { get; set; }

		public Post(int postId, string title, string body, int userId, string username, string createTime)
		{
			this.postId = postId;
			this.title = title;
			this.body = body;
			this.userId = userId;
			this.username = username;
			this.createTime = createTime;
		}
	}
}