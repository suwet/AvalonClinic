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

namespace Avalon.Clinic.ViewModels.M_yearVM
{
	public  class ListM_yearViewModel : ViewModelBase
	{
		public ListM_yearViewModel()
		{
		}
		public ListM_yearViewModel(IEnumerable<M_yearViewModel> list )
		{
			M_yearViewModels = new ObservableCollection<M_yearViewModel>(list.ToList());
		}
		public ObservableCollection<M_yearViewModel> M_yearViewModels {get;set;}
	}
}
