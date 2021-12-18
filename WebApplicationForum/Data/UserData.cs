using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationForum.Data
{
	public class UserData
	{
		public bool signup(string username, string password)
		{
			string sql = $"INSERT INTO [User] VALUES ('{username}', '{password}')";
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
				Console.WriteLine("error signup: " + ex.Message);
				return false;
			}
		}

		public bool checkunique(String username)
		{
			Console.WriteLine("user: " + username);
			try
			{
				string sql1 = "SELECT * FROM [User] WHERE username = '" + username + "'";
				SqlConnection con = DBConnection.getConnection();
				con.Open();
				SqlDataAdapter da = new SqlDataAdapter(sql1, con);
				DataSet ds = new DataSet();
				da.Fill(ds);
				if (ds.Tables["Table"].Rows.Count != 0) return false;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error check unique: " + ex.Message);
				return false;
			}
			return true;
		}

		public string login(string username, string password)
		{
			string sql = $"SELECT * FROM [User] WHERE username = '{username}' AND password = '{password}'";
			try
			{
				SqlConnection con = DBConnection.getConnection();
				SqlCommand cmd = new SqlCommand(sql, con);
				con.Open();
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				DataSet ds = new DataSet();
				da.Fill(ds);
				con.Close();
				if (ds.Tables["Table"].Rows.Count == 0) return "";
				DataTable dt = new DataTable();
				da.Fill(dt);
				string ID = dt.Rows[0]["userId"].ToString();
				return ID;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error login: " + ex.Message);
				return "";
			}
		}
	}
}