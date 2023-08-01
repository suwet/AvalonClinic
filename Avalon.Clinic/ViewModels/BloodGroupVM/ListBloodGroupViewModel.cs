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

namespace Avalon.Clinic.ViewModels.BloodGroupVM
{
	public  class ListBloodGroupViewModel : ReactiveViewModelBase {
		public ListBloodGroupViewModel()
		{
		}
		public ListBloodGroupViewModel(IEnumerable<BloodGroupViewModel> list )
		{
			BloodGroupViewModels = new ObservableCollection<BloodGroupViewModel>(list.ToList());
		}
		public ObservableCollection<BloodGroupViewModel> BloodGroupViewModels {get;set;}
	}
}
