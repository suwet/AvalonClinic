using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avalon.Clinic.ViewModels.M_dayVM
{
	public  class M_dayViewModel : ReactiveViewModelBase
	{
				private Int32  _id;  
    
		private Int32  _daynumber;  

		////////////////////////////
				public Int32  Id  
 		{
		   get=> _id;
		   set => this.RaiseAndSetIfChanged(ref _id,value);
		} 
    
		public Int32  DayNumber  
 		{
		   get=> _daynumber;
		   set => this.RaiseAndSetIfChanged(ref _daynumber,value);
		} 

	}
}
