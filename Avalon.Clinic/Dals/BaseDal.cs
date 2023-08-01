using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Avalon.Clinic.Dals
{
	public  class BaseDal
	{
		public string ConnectionString
		{
			get
			{
                //return ConfigurationManager.ConnectionStrings["Test"].ToString();
                return Program.configuration.GetConnectionString("Test");
			}
		}
	}
}
