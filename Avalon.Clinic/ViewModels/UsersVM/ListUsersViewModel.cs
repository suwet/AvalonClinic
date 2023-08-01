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
using System.Reactive;
using System.Windows.Input;
using Avalon.Clinic.Dialogs.Users;
using Avalon.Clinic.Services;
using Avalon.Clinic.ViewModels;
using Avalon.Clinic.ViewModels.UsersVM;
using Avalonia.Controls;
using Avalonia.Threading;
using DynamicData;
using Material.Dialog;

namespace Avalon.Clinic.ViewModels.UsersVM
{
	public  class ListUsersViewModel : ReactiveViewModelBase
	{
        private UserService _userservice = new UserService();
        private string _filter_text = string.Empty;
        private bool _search_progress_visible = false;
		public ListUsersViewModel()
		{
		}
		public ListUsersViewModel(IEnumerable<UsersViewModel> list )
		{
			Users = new ObservableCollection<UsersViewModel>(list.ToList());
            
            EditCommand = ReactiveCommand.CreateFromTask<int,Task>(async (id) => {
                 var dlg = new EditUserDlg(id);
                 int row_effect = await dlg.ShowDialog<int>(Program.MainWindow);
                if (row_effect > 0) {
                    await ReloadData();
                }
                return Task.Delay(1);
            });
            
            DlgNewUserCommand = ReactiveCommand.CreateFromTask(async () => {
                var dlg = new AddUserDlg();
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

                if(result.GetResult == "delete") {
                    var row_effect = await _userservice .DeleteAsync(id);
                    if (row_effect > 0) {
                        await ReloadData();
                    }
                }
            });
		}
		public ObservableCollection<UsersViewModel> Users {get;set;}
        
        public ICommand DlgNewUserCommand { get; }

        public ReactiveCommand<int, Task> EditCommand { get; }
        public ReactiveCommand<int, Unit> DeleteCommand { get; }
        
        private async Task ReloadData() {
            await Task.Run(async () => {
                    await Dispatcher.UIThread.InvokeAsync(async () => {
                        Users.Clear();
                        Users.AddRange(await _userservice.GetAllAsync());
                    });
                }
            );
        }
	}
}
