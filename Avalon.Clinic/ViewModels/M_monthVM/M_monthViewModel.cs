using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avalon.Clinic.ViewModels.M_monthVM
{
	public  class M_monthViewModel : ReactiveViewModelBase
	{
				private Int32  _id;  
    
		private Int32  _monthnumber;  
    
		private String  _monthnameth;  
    
		private String  _monthnameen;  

		////////////////////////////
				public Int32  Id  
 		{
		   get=> _id;
		   set => this.RaiseAndSetIfChanged(ref _id,value);
		} 
    
		public Int32  MonthNumber  
 		{
		   get=> _monthnumber;
		   set => this.RaiseAndSetIfChanged(ref _monthnumber,value);
		} 
    
		public String  MonthNameTH  
 		{
		   get=> _monthnameth;
		   set => this.RaiseAndSetIfChanged(ref _monthnameth,value);
		} 
    
		public String  MonthNameEN  
 		{
		   get=> _monthnameen;
		   set => this.RaiseAndSetIfChanged(ref _monthnameen,value);
		} 

	}
}
