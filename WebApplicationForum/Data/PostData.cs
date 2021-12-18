using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationForum.Models;

namespace WebApplicationForum.Data
{
	public class PostData
	{
		public List<Post> getList()
		{
			string sql = "SELECT postId, title, body, [Post].userId, [User].username, createTime FROM Post LEFT JOIN [User] ON [User].userId = Post.userId";
			List<Post> listPosts = new List<Post>();
			try
			{
				DataTable dt = new DataTable();
				SqlConnection con = DBConnection.getConnection();
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				con.Open();
				da.Fill(dt);
				con.Close();
				Post ns;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					int ID = Convert.ToInt32(dt.Rows[i]["postId"].ToString());
					String title = dt.Rows[i]["title"].ToString();
					String body = dt.Rows[i]["body"].ToString();
					int userId = Convert.ToInt32(dt.Rows[i]["userId"].ToString());
					String createTime = dt.Rows[i]["createTime"].ToString();
					String username = dt.Rows[i]["username"].ToString().Trim();
					ns = new Post(ID, title, body, userId, username, createTime);
					listPosts.Add(ns);
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error list Post: " + ex.Message);
			}
			return listPosts;
		}

		public bool createPost(string title, string body, string userId)
		{
			string sql = $"INSERT INTO Post(title, body, userId) values (N'{title}', N'{body}', {userId})";
			try
			{
				SqlConnection con = DBConnection.getConnection();
				SqlCommand cmd = new SqlCommand(sql, con);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
				return true;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error createPost: " + ex.Message);
				return false;
			}
		}
	}
}