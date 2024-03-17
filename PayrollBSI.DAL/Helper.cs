using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PayrollBSI.DAL
{
	public class Helper
	{
		public static string GetConnectionString()
		{
			if (System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"] == null)
			{
                var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return MyConfig.GetConnectionString("MyDbConnectionString")?.ToString() ?? string.Empty;

            }
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
			return connString;
		}
	}
}
