using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avalon.Clinic.Models
{
	public  class Roles : ModelBase
	{
		public Int32  id  {get;set;}
    
		public String  role_name  {get;set;}
    
		public String  active  {get;set;}
    
		public String  remark  {get;set;}

	}
}
