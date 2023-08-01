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
using System.Windows.Input;
using System.Reactive;
using Avalon.Clinic.Dialogs.Users;
using Avalon.Clinic.Services;
using Avalonia.Controls;
using Material.Dialog;
using Avalonia.Threading;
using Avalon.Models;
using DynamicData;
using Avalon.Clinic.Dialogs.Roles;

namespace Avalon.Clinic.ViewModels.RoleVM
{
	public  class ListRolesViewModel : ReactiveViewModelBase
    {
        private RoleService role_service = new RoleService();
		public ListRolesViewModel()
		{
		}
		public ListRolesViewModel(IEnumerable<RolesViewModel> list )
		{
			RolesViewModels = new ObservableCollection<RolesViewModel>(list.ToList());

            EditCommand = ReactiveCommand.CreateFromTask<int, Task>(async (id) => {
                var dlg = new EditRoleDlg(id);
                int row_effect = await dlg.ShowDialog<int>(Program.MainWindow);
                if (row_effect > 0) {
                    await ReloadData();
                }
                return Task.Delay(1);
            });

            NewCommand = ReactiveCommand.CreateFromTask(async () => {
                var dlg = new AddRoleDlg();
                var row_effect = await dlg.ShowDialog<int>(Program.MainWindow);
                if (row_effect > 0) {
                    await ReloadData();
                }
            });

            DeleteCommand = ReactiveCommand.CreateFromTask<int>(async (id) => {

                var result = await DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams {
                    ContentHeader = "Confirm action",
                    SupportingText = "Are you sure to delete?",
                    DialogHeaderIcon = Material.Dialog.Icons.DialogIconKind.Help,
                    StartupLocation = WindowStartupLocation.CenterOwner,
                    NegativeResult = new DialogResult("cancel"),
                    Borderless = true,
                    DialogButtons = new[]
                    {
                        new DialogButton
                        {
                            Content = "CANCEL",
                            Result = "cancel"
                        },
                        new DialogButton
                        {
                            Content = "DELETE",
                            Result = "delete"
                        }
                    }
                }).ShowDialog(Program.MainWindow);

                if (result.GetResult == "delete") {
                    var row_effect = await role_service.DeleteAsync(id);
                    if (row_effect > 0) {
                        await ReloadData();
                    }
                }
            });
        }
		public ObservableCollection<RolesViewModel> RolesViewModels {get;set;}

		public ICommand NewCommand { get; }

        public ReactiveCommand<int, Task> EditCommand { get; }
        public ReactiveCommand<int, Unit> DeleteCommand { get; }

        private async Task ReloadData() {
            await Task.Run(async () => {
                await Dispatcher.UIThread.InvokeAsync(async () => {
                    RolesViewModels.Clear();
                    RolesViewModels.AddRange(await role_service.GetAllAsync());
                });
            }
            );
        }
    }
}
