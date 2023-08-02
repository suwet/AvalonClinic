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
	public  class UserInRole : ModelBase
	{
				public Int32  id  {get;set;}
    
		public Int32  user_id  {get;set;}
    
		public Int32  role_id  {get;set;}
    
		public String  active  {get;set;}
    
		public DateTime  create_date  {get;set;}
    
		public DateTime  modifiel_date  {get;set;}
    
		public String  remark  {get;set;}

	}
}