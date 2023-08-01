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

namespace Avalon.Clinic.ViewModels.M_monthVM
{
	public  class ListM_monthViewModel : ReactiveViewModelBase
	{
		public ListM_monthViewModel()
		{
		}
		public ListM_monthViewModel(IEnumerable<M_monthViewModel> list )
		{
			M_monthViewModels = new ObservableCollection<M_monthViewModel>(list.ToList());
		}
		public ObservableCollection<M_monthViewModel> M_monthViewModels {get;set;}
	}
}
