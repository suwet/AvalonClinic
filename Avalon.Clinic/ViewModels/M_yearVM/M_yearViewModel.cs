using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;

namespace Avalon.Clinic.ViewModels.M_yearVM {
    public class M_yearViewModel : ReactiveViewModelBase {
        private Int32 _id;

        private Int32 _yearnumberth;

        private Int32 _yearnumberen;

        ////////////////////////////
        public Int32 Id {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        public Int32 YearNumberTH {
            get => _yearnumberth;
            set => this.RaiseAndSetIfChanged(ref _yearnumberth, value);
        }

        public Int32 YearNumberEN {
            get => _yearnumberen;
            set => this.RaiseAndSetIfChanged(ref _yearnumberen, value);
        }

    }
}
