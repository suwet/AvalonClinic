using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DynamicData;
using Avalon.Clinic.Models;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using Avalon.Clinic.ViewModels.PatientVM;
using Avalon.Clinic.Services.Patients;
using Avalon.Clinic.ViewModels.BloodGroupVM;
using Avalon.Clinic.ViewModels.M_monthVM;
using Avalon.Clinic.ViewModels.M_dayVM;
using Avalon.Clinic.ViewModels.M_yearVM;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Threading;

namespace Avalon.Clinic.Dialogs {
    public partial class EditPatientDlg : ReactiveWindow<PatientViewModel> {
        private ComboBox cmb_d;
        private ComboBox cmb_m;
        private ComboBox cmb_y;
        private ComboBox cmb_bloodgroup;
        private RadioButton rdo_m;
        private RadioButton rdo_w;
        private bool m_Done = false;
        private PatientService _patientService = new PatientService();

        public EditPatientDlg() {
            InitializeComponentWithDefaultViewModel();
            /*
            int window_w = (int)this.DesiredSize.Width / 2;
            int window_h = (int)this.DesiredSize.Height / 2;
            int x = (int)(Program.MainWindow.Bounds.Width / 2) - window_w;
            int y = (int)(Program.MainWindow.Bounds.Height / 2) - window_h;
            this.Position = new Avalonia.PixelPoint(x, y);
            */

            this.WhenActivated(disposables => {
                /*  Type safe way
                this.BindCommand(ViewModel, x => x.ExampleCommand, x => x.ExampleButton)
               .DisposeWith(disposables);
                */
                //this.Bind(ViewModel, vm => vm.PatientViewModels, view => view.grid_pateint.Items);
                /* Handle activation */
                Disposable
                    .Create(() => {
                        /* Handle deactivation */
                    })
                    .DisposeWith(disposables);
            });
        }

        public EditPatientDlg(int id) {
            this.Opened += OnOpened;
            this.DataContext = Task.Run<PatientViewModel>(async () => await _patientService.GetByIdAsync(id)).Result;
            InitializeComponentWithDefaultViewModel();
            this.WhenActivated(disposables => {
                //this.Bind(ViewModel, vm => vm.PatientViewModels, view => view.grid_pateint.Items);
                /* Handle activation */
                Disposable
                    .Create(() => {
                        /* Handle deactivation */
                    })
                    .DisposeWith(disposables);
            });
        }

        private void OnOpened(object? sender, EventArgs e) {
            int window_w = (int)this.DesiredSize.Width / 2;
            int window_h = (int)this.DesiredSize.Height / 2;
            int x = (int)(Program.MainWindow.Bounds.Width / 2) - window_w;
            int y = (int)(Program.MainWindow.Bounds.Height / 2) - (window_h*2);
            this.Position = new Avalonia.PixelPoint(x, y);
        }

        private void InitializeComponentWithDefaultViewModel() {
            AvaloniaXamlLoader.Load(this);

            var vm = this.DataContext as PatientViewModel;
            cmb_d = this.Find<ComboBox>("cmb_day");
            cmb_m = this.Find<ComboBox>("cmb_month");
            cmb_y = this.Find<ComboBox>("cmb_year");
            cmb_bloodgroup = this.Find<ComboBox>("cmb_bloodgroup");

            rdo_m = this.Find<RadioButton>("rdo_man");
            rdo_w = this.Find<RadioButton>("rdo_woman");


            cmb_d.SelectionChanged += Cmb_d_SelectionChanged;
            cmb_m.SelectionChanged += Cmb_m_SelectionChanged;
            cmb_y.SelectionChanged += Cmb_y_SelectionChanged;
            cmb_bloodgroup.SelectionChanged += Cmb_bloodgroup_SelectionChanged;

            rdo_m.Checked += Rdo_m_Checked;
            rdo_w.Checked += Rdo_w_Checked;


            rdo_m.IsChecked = vm.Sex == "man" ? true : false;
            rdo_w.IsChecked = vm.Sex == "woman" ? true : false;
            cmb_d.SelectedItem = vm.Days.FirstOrDefault(x => x.DayNumber == vm.BirthDate.Day);
            cmb_m.SelectedItem = vm.Months.FirstOrDefault(x => x.MonthNumber == vm.BirthDate.Month);
            cmb_y.SelectedItem = vm.Years.FirstOrDefault(x => x.YearNumberTH == vm.BirthDate.Year);
            cmb_bloodgroup.SelectedItem = vm.BloodGroups.FirstOrDefault(x => x.Id == vm.BloodGroupId);
        }

        private void Rdo_w_Checked(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e) {
            if (rdo_w.IsChecked.HasValue && rdo_w.IsChecked.Value) {
                (this.ViewModel as PatientViewModel).Sex = "woman";
            }
        }

        private void Rdo_m_Checked(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e) {
            if (rdo_m.IsChecked.HasValue && rdo_m.IsChecked.Value) {
                (this.ViewModel as PatientViewModel).Sex = "man";
            }
        }

        private void Cmb_y_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selectd_item = e.AddedItems[0] as M_yearViewModel;
            //this.ViewModel.SelectedYear = selectd_item;
        }

        private void Cmb_bloodgroup_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selectd_item = e.AddedItems[0] as BloodGroupViewModel;
            this.ViewModel.BloodGroupId = selectd_item.Id;
            //this.ViewModel.SelectedBloodGroup = selectd_item;
        }

        private void Cmb_m_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selectd_item = e.AddedItems[0] as M_monthViewModel;
            //this.ViewModel.SelectedMonth = selectd_item;
        }

        private void Cmb_d_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selectd_item = e.AddedItems[0] as M_dayViewModel;
            //this.ViewModel.SelectedDay = selectd_item;
        }

        //protected override void Initialize() => AvaloniaXamlLoader.Load(this); 

        public override void Render(DrawingContext context) {
            base.Render(context);
            /*
            int window_w = (int)this.DesiredSize.Width / 2;
            int window_h = (int)this.DesiredSize.Height / 2;
            int x = (int)(Program.MainWindow.Bounds.Width / 2) - window_w;
            int y = (int)(Program.MainWindow.Bounds.Height / 2) - window_h;
            this.Position = new Avalonia.PixelPoint(x, y);
            */
        }
    }
}
