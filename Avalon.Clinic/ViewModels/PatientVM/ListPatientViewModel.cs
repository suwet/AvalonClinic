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
using Avalon.Clinic.Dialogs;
using Avalon.Clinic.Models;
using Avalon.Clinic.Services.Patients;
using System.Net.Http.Headers;
using DynamicData;
using System.Reactive.Linq;
using System.Diagnostics;
using Avalonia.Threading;
using System.Reflection.Emit;
using Avalonia;
using Avalonia.Controls;
using Material.Dialog;

namespace Avalon.Clinic.ViewModels.PatientVM {
    public class ListPatientViewModel : ReactiveViewModelBase {
        private PatientService _patientService = new PatientService();
        private string _filter_text = string.Empty;
        private bool _search_progress_visible = false;
        private ObservableCollection<PatientViewModel> _patients = new ObservableCollection<PatientViewModel>();
        public ListPatientViewModel() {
            //EditCommand = ReactiveCommand.Create<int>(OpenEditModal);

            DlgNewPatientCommand = ReactiveCommand.CreateFromTask(async () => {
                //await Task.Delay(10);
                var dlg = new AddPatientDlg();
                var row_effect = await dlg.ShowDialog<int>(Program.MainWindow);
                if (row_effect > 0) {
                    // Reload Data
                    await ReloadData();
                }
            });

            DeleteCommand = ReactiveCommand.CreateFromTask<int>(async (id) => 
            {
                var row_effect = await _patientService.DeleteAsync(id);
                if (row_effect > 0) {
                    // Reload Data
                    await ReloadData();
                }
            });

                this
                .WhenAnyValue(p => p.Filter_Text)
                .Do(s => { Search_Progress_Visible = true; })
                .Where(x => x != null)
                .Throttle(TimeSpan.FromMilliseconds(1000))
                .DistinctUntilChanged()
                .Subscribe(async (result) => {
                    var _result_set = await Task.Run<List<PatientViewModel>>(() => _patientService.SearchAsync(result));
                    await Dispatcher.UIThread.InvokeAsync(() => {
                        PatientViewModels.Clear();
                        PatientViewModels.AddRange(_result_set);
                    });
                }
                );
        }
        public ListPatientViewModel(IEnumerable<PatientViewModel> list) {
            PatientViewModels = new ObservableCollection<PatientViewModel>(list.ToList());
            EditCommand = ReactiveCommand.CreateFromTask<int,Task>(async (id) => {
                var dlg = new EditPatientDlg(id);
                int row_effect = await dlg.ShowDialog<int>(Program.MainWindow);
                if (row_effect > 0) {
                    // Reload Data
                    ReloadData();
                }

                return Task.Delay(1);
            });
            
            DlgNewPatientCommand = ReactiveCommand.CreateFromTask(async () => {
                //await Task.Delay(10);
                var dlg = new AddPatientDlg();
                var row_effect = await dlg.ShowDialog<int>(Program.MainWindow);
                if (row_effect > 0) {
                    // Reload Data
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
                    var row_effect = await _patientService.DeleteAsync(id);
                    if (row_effect > 0) {
                        // Reload Data
                        await ReloadData();
                    }
                }
            });

            this
                 .WhenAnyValue(p => p.Filter_Text)
                 .SubscribeOn(RxApp.MainThreadScheduler)
                 .Do(s => { Search_Progress_Visible = true; })
                 .Where(x => x!=null)
                 .Throttle(TimeSpan.FromMilliseconds(1000))
                 .DistinctUntilChanged()
                 .Subscribe(async (result) => {
                     Search_Progress_Visible = false;
                     //var _result_set = await Task.Run<List<PatientViewModel>>(() => _patientService.SearchAsync(result));
                     await Dispatcher.UIThread.InvokeAsync(async () => {
                         PatientViewModels.Clear();
                         PatientViewModels.AddRange(await Task.Run<List<PatientViewModel>>(async () => await _patientService.SearchAsync(result)));
                         Search_Progress_Visible = false;
                     });
                 }
                 );
        }

        public ObservableCollection<PatientViewModel> PatientViewModels 
        {
            get => _patients;
            set => this.RaiseAndSetIfChanged(ref _patients, value);
        }

        public string Filter_Text 
        { 
            get => _filter_text;
            set => this.RaiseAndSetIfChanged(ref _filter_text, value);
        }

        public bool Search_Progress_Visible {
            get => _search_progress_visible; 
            set => this.RaiseAndSetIfChanged(ref _search_progress_visible, value);
        }
        public ICommand DlgNewPatientCommand { get; }

        public ReactiveCommand<int, Task> EditCommand { get; }
        public ReactiveCommand<int, Unit> DeleteCommand { get; }

        private async Task ReloadData() {
            await Task.Run(async () => {
                    //PatientViewModels = null;
                    //PatientViewModels = new ObservableCollection<PatientViewModel>(await _patientService.GetAllAsync());
                    await Dispatcher.UIThread.InvokeAsync(async () => {
                        PatientViewModels.Clear();
                        PatientViewModels.AddRange(await _patientService.GetAllAsync());
                    });
                }
            );
        }
    }
}
