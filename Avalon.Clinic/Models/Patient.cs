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
	public  class Patient : ModelBase
	{
				public Int32  Id  {get;set;}
    
		public String  IDCard  {get;set;}
    
		public String  FirstName  {get;set;}
    
		public String  LastName  {get;set;}
    
		public String?  Email  {get;set;}
    
		public String?  Address  {get;set;}
    
		public DateTime?  BirthDate  {get;set;}
    
		public String?  MobliePhone  {get;set;}
    
		public Int32?  Age  {get;set;}
    
		public String?  Sex  {get;set;}
    
		public Int32?  BloodGroupId  {get;set;}
    
		public String?  ChronicDisease  {get;set;}
    
		public String?  Ocipation  {get;set;}
    
		public String?  Nationality  {get;set;}
    
		public DateTime?  CreatedDate  {get;set;}
    
		public DateTime?  ModifieldDate  {get;set;}
    
		public String?  Remark  {get;set;}
    
		public String?  Active  {get;set;}

        // extra property
        public string? BloodGroupName { get;set;}

    }
}
