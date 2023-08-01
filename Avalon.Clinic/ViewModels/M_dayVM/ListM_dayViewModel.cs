using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Avalon.Clinic.ViewModels.M_dayVM
{
	public  class ListM_dayViewModel : ReactiveViewModelBase
	{
		public ListM_dayViewModel()
		{
		}
		public ListM_dayViewModel(IEnumerable<M_dayViewModel> list )
		{
			M_dayViewModels = new ObservableCollection<M_dayViewModel>(list.ToList());
		}
		public ObservableCollection<M_dayViewModel> M_dayViewModels {get;set;}
	}
}
