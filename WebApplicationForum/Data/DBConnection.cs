using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationForum.Data
{
	public class DBConnection
	{
		static string strCon = @"Data Source=PC-0\SQLEXPRESS;Initial Catalog=MyForum;Integrated Security=True";
		public static SqlConnection getConnection()
		{
			return new SqlConnection(strCon);
		}
	}
}