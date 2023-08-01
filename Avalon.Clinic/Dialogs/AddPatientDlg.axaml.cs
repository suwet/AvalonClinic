using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DynamicData;
using Avalon.Clinic.Models;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using Avalon.Clinic.ViewModels.PatientVM;
using Avalon.Clinic.ViewModels.M_yearVM;
using Avalon.Clinic.ViewModels.M_monthVM;
using Avalon.Clinic.ViewModels.M_dayVM;
using System.Reactive.Disposables;
using Avalon.Clinic.ViewModels.BloodGroupVM;
using Avalonia.Media;

namespace Avalon.Clinic.Dialogs {
    public partial class AddPatientDlg : ReactiveWindow<PatientViewModel> {
        private ComboBox cmb_d;
        private ComboBox cmb_m;
        private ComboBox cmb_y;
        private ComboBox cmb_bloodgroup;
        private RadioButton rdo_m;
        private RadioButton rdo_w;

        public AddPatientDlg() {
            InitializeComponent();
            this.Opened += OnOpened;
#if DEBUG
            this.AttachDevTools();
#endif
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

        private void OnOpened(object? sender, EventArgs e) {
            int window_w = (int)this.DesiredSize.Width / 2;
            int window_h = (int)this.DesiredSize.Height / 2;
            int x = (int)(Program.MainWindow.Bounds.Width / 2) - window_w;
            int y = (int)(Program.MainWindow.Bounds.Height / 2) - (window_h * 2);
            this.Position = new Avalonia.PixelPoint(x, y);
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            //this.ViewModel = new PatientViewModel();
            this.DataContext = new PatientViewModel();

            cmb_d = this.Find<ComboBox>("cmb_day");
            cmb_m = this.Find<ComboBox>("cmb_month");
            cmb_y = this.Find<ComboBox>("cmb_year");
            cmb_bloodgroup = this.Find<ComboBox>("cmb_bloodgroup");
            rdo_m = this.Find<RadioButton>("rdo_man");
            rdo_w = this.Find<RadioButton>("rdo_woman");
            // set defaul value
            rdo_m.IsChecked = true;
            (this.DataContext as PatientViewModel).Sex = "man";
            (this.DataContext as PatientViewModel).BloodGroupId = 1;
            (this.DataContext as PatientViewModel).Active = "Y";

            cmb_d.SelectionChanged += Cmb_d_SelectionChanged;
            cmb_m.SelectionChanged += Cmb_m_SelectionChanged;
            cmb_y.SelectionChanged += Cmb_y_SelectionChanged;
            cmb_bloodgroup.SelectionChanged += Cmb_bloodgroup_SelectionChanged;

            rdo_m.Checked += Rdo_m_Checked;
            rdo_w.Checked += Rdo_w_Checked;
        }

        private void Cmb_bloodgroup_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selectd_item = e.AddedItems[0] as BloodGroupViewModel;
            (this.DataContext as PatientViewModel).BloodGroupId = selectd_item.Id;
        }

        private void Rdo_w_Checked(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e) {
            if (rdo_w.IsChecked.HasValue && rdo_w.IsChecked.Value) {
                (this.DataContext as PatientViewModel).Sex = "woman";
            }
        }

        private void Rdo_m_Checked(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e) {
            if (rdo_m.IsChecked.HasValue && rdo_m.IsChecked.Value) {
                (this.DataContext as PatientViewModel).Sex = "man";
            }
        }

        private void Cmb_y_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selected_year = e.AddedItems[0] as M_yearViewModel;
            (this.DataContext as PatientViewModel).BirthDate = new DateTime(selected_year.YearNumberTH,
                (this.DataContext as PatientViewModel).BirthDate.Month,
                (this.DataContext as PatientViewModel).BirthDate.Day);
        }

        private void Cmb_m_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selectd_item = e.AddedItems[0] as M_monthViewModel;
            (this.DataContext as PatientViewModel).BirthDate = new DateTime(
                (this.DataContext as PatientViewModel).BirthDate.Year, selectd_item.MonthNumber,
                (this.DataContext as PatientViewModel).BirthDate.Day);
        }

        private void Cmb_d_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var selectd_item = e.AddedItems[0] as M_dayViewModel;
            (this.DataContext as PatientViewModel).BirthDate = new DateTime(
                (this.DataContext as PatientViewModel).BirthDate.Year,
                (this.DataContext as PatientViewModel).BirthDate.Day,
                selectd_item.DayNumber);
        }

        public override void Render(DrawingContext context) {
            base.Render(context);
        }
    }
}
