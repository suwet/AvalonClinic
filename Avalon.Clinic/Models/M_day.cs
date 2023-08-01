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
	public  class M_day : ModelBase
	{
				public Int32  Id  {get;set;}
    
		public Int32  DayNumber  {get;set;}

	}
}