using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalon.Clinic.Models;
using Avalon.Clinic.Services;
using Avalon.Clinic.Services.BloodGroups;
using Avalon.Clinic.Services.Patients;
using Avalonia.Controls;
using ReactiveUI;

namespace Avalon.Clinic.ViewModels.PatientVM {
    public partial class PatientViewModel : ReactiveViewModelBase
    {
        private PatientService _patientService = new PatientService();
        private MYearService _yearService = new MYearService();
        private MmonthService _monthService = new MmonthService();
        private MdayService _dayService = new MdayService();
        private BloodGroupService _bloodGroupService = new BloodGroupService();
        public PatientViewModel() 
        {
            Years = _yearService.GetAll();
            Months = _monthService.GetAll();
            Days = _dayService.GetAll();
            BloodGroups = _bloodGroupService.GetAll();
            var canexecute = this.WhenAnyValue(x=>x.IDCard,y=>y.FirstName,z=>z.LastName,(a,b,c)=> (!string.IsNullOrEmpty(a)) && (!string.IsNullOrEmpty(b)) && (!string.IsNullOrEmpty(c)));
            SaveAddNew = ReactiveCommand.Create<Window>(async (window) => {
                // Do Save and Close
                var row_effect = await _patientService.Add(this);
                
                window.Close(row_effect);
            }, canexecute,RxApp.TaskpoolScheduler);

            SaveEdit = ReactiveCommand.Create<Window>(async (window) => {
                // Do Save and Close
                var row_effect = await _patientService.Update(this);

                window.Close(row_effect);
            }, canexecute, RxApp.TaskpoolScheduler);

            Cancel = ReactiveCommand.Create<Window>((window) => {
                window.Close();
            });
        }

        // Command for add new item
        public ReactiveCommand<Window,Unit> SaveAddNew { get;}

        // Command for edit item
        public ReactiveCommand<Window, Unit> SaveEdit { get; }

        // Common
        ICommand Cancel { get; }

    }
}
