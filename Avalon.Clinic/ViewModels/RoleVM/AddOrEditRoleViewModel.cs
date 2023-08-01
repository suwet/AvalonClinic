using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;
using System.Windows.Input;
using Avalon.Clinic.Services;
using Avalon.Models;

namespace Avalon.Clinic.ViewModels.RoleVM {
    public partial class RolesViewModel : ReactiveViewModelBase 
    {
        private RoleService roleService = new RoleService();
        public RolesViewModel() {
            var canexecute = this.WhenAnyValue(x => x.role_name,
           (a) => (!string.IsNullOrEmpty(a)));
            SaveAddNew = ReactiveCommand.Create<Window>(async (window) => {
                // Do Save and Close
                var row_effect = await roleService.AddAsync(this);
                window.Close(row_effect);
            }, canexecute, RxApp.TaskpoolScheduler);

            SaveEdit = ReactiveCommand.Create<Window>(async (window) => {
                // Do Save and Close
                var row_effect = await roleService.UpdateAsync(this);

                window.Close(row_effect);
            }, canexecute, RxApp.TaskpoolScheduler);

            Cancel = ReactiveCommand.Create<Window>((window) => {
                window.Close();
            });
        }
        public ReactiveCommand<Window, Unit> SaveAddNew { get; }

        // Command for edit item
        public ReactiveCommand<Window, Unit> SaveEdit { get; }

        // Common
        ICommand Cancel { get; }
    }
}
