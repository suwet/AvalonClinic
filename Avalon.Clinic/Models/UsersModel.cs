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
	public  class UsersModel : ModelBase
	{ 
      	public Int32  id  {get;set;}
    
		public String  username  {get;set;}
    
		public String  password  {get;set;}
    
		public String?  password_sha  {get;set;}
    
		public String?  password_hash  {get;set;}
    
		public String  firstname  {get;set;}
    
		public String?  lastname  {get;set;}
    
		public String?  email  {get;set;}
    
		public String?  active  {get;set;}
    
		public DateTime?  created_date  {get;set;}
    
		public DateTime?  modifield_date  {get;set;}
    
		public String?  remark  {get;set;}
    
		public Int32  isadmin  {get;set;}
    
		public Int32  isaccount  {get;set;}

	}
}
