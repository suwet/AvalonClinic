using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avalon.Clinic.ViewModels.RoleVM 
{
	public partial class RolesViewModel : ReactiveViewModelBase 
    {
		private Int32  _id;  
    
		private String  _role_name;  
    
		private String  _active;  
    
		private String  _remark;  

		////////////////////////////
		public Int32  id  
 		{
		   get=> _id;
		   set => this.RaiseAndSetIfChanged(ref _id,value);
		} 
    
		public String  role_name  
 		{
		   get=> _role_name;
		   set => this.RaiseAndSetIfChanged(ref _role_name,value);
		} 
    
		public String  active  
 		{
		   get=> _active;
		   set => this.RaiseAndSetIfChanged(ref _active,value);
		} 
    
		public String  remark  
 		{
		   get=> _remark;
		   set => this.RaiseAndSetIfChanged(ref _remark,value);
		} 

	}
}
