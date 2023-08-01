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
	public  class M_month : ModelBase
	{
				public Int32  Id  {get;set;}
    
		public Int32  MonthNumber  {get;set;}
    
		public String?  MonthNameTH  {get;set;}
    
		public String?  MonthNameEN  {get;set;}

	}
}