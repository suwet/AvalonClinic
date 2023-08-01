using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avalon.Clinic.ViewModels.UsersVM
{
	public partial class UsersViewModel : ReactiveViewModelBase
	{
       		private Int32  _id;  
    
		private String  _username;  
    
		private String  _password;  
    
		private String  _password_sha;  
    
		private String  _password_hash;  
    
		private String  _firstname;  
    
		private String  _lastname;  
    
		private String  _email;  
    
		private String  _active;  
    
		private DateTime  _created_date;  
    
		private DateTime  _modifield_date;  
    
		private String  _remark;  
    
		private Int32  _isadmin;  
    
		private Int32  _isaccount;  

		////////////////////////////
				public Int32  id  
 		{
		   get=> _id;
		   set => this.RaiseAndSetIfChanged(ref _id,value);
		} 
    
		public String  username  
 		{
		   get=> _username;
		   set => this.RaiseAndSetIfChanged(ref _username,value);
		} 
    
		public String  password  
 		{
		   get=> _password;
		   set => this.RaiseAndSetIfChanged(ref _password,value);
		} 
    
		public String  password_sha  
 		{
		   get=> _password_sha;
		   set => this.RaiseAndSetIfChanged(ref _password_sha,value);
		} 
    
		public String  password_hash  
 		{
		   get=> _password_hash;
		   set => this.RaiseAndSetIfChanged(ref _password_hash,value);
		} 
    
		public String  firstname  
 		{
		   get=> _firstname;
		   set => this.RaiseAndSetIfChanged(ref _firstname,value);
		} 
    
		public String  lastname  
 		{
		   get=> _lastname;
		   set => this.RaiseAndSetIfChanged(ref _lastname,value);
		} 
    
		public String  email  
 		{
		   get=> _email;
		   set => this.RaiseAndSetIfChanged(ref _email,value);
		} 
    
		public String  active  
 		{
		   get=> _active;
		   set => this.RaiseAndSetIfChanged(ref _active,value);
		} 
    
		public DateTime  created_date  
 		{
		   get=> _created_date;
		   set => this.RaiseAndSetIfChanged(ref _created_date,value);
		} 
    
		public DateTime  modifield_date  
 		{
		   get=> _modifield_date;
		   set => this.RaiseAndSetIfChanged(ref _modifield_date,value);
		} 
    
		public String  remark  
 		{
		   get=> _remark;
		   set => this.RaiseAndSetIfChanged(ref _remark,value);
		} 
    
		public Int32  isadmin  
 		{
		   get=> _isadmin;
		   set => this.RaiseAndSetIfChanged(ref _isadmin,value);
		} 
    
		public Int32  isaccount  
 		{
		   get=> _isaccount;
		   set => this.RaiseAndSetIfChanged(ref _isaccount,value);
		} 
	}
}
