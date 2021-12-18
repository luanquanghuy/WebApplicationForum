using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationForum.Models;

namespace WebApplicationForum.Data
{
	public class CommentData
	{
		public List<Comment> getList(string postId)
		{
			string sql = $"SELECT commentId, text, postId, Comment.userId, [User].username, createTime FROM Comment LEFT JOIN [User] ON [User].userId = Comment.userId WHERE postId = {postId}";
			List<Comment> listPosts = new List<Comment>();
			try
			{
				DataTable dt = new DataTable();
				SqlConnection con = DBConnection.getConnection();
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				con.Open();
				da.Fill(dt);
				con.Close();
				Comment ns;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					int commentId = Convert.ToInt32(dt.Rows[i]["commentId"].ToString());
					String text = dt.Rows[i]["text"].ToString();
					int myPostID = Convert.ToInt32(dt.Rows[i]["userId"].ToString());
					int userId = Convert.ToInt32(dt.Rows[i]["userId"].ToString());
					String username = dt.Rows[i]["username"].ToString().Trim();
					String createTime = dt.Rows[i]["createTime"].ToString();
					ns = new Comment(commentId, text, myPostID, userId, username, createTime);
					listPosts.Add(ns);
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error list Commnents: " + ex.Message);
			}
			return listPosts;
		}

		public bool createComment(string text, string postId, string userId)
		{
			string sql = $"INSERT INTO Comment(text, postId, userId) values (N'{text}', {postId}, {userId})";
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