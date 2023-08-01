using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Avalonia.Win32;
using Avalon.Clinic.ViewModels;
using Avalon.Clinic.Services.Patients;
using Avalonia.ReactiveUI;
using Avalon.Clinic.ViewModels.PatientVM;
using ReactiveUI;
using System.Reactive.Disposables;
using System;
using System.Reactive.Linq;

namespace Avalon.Clinic.Pages
{
    public partial class Register : ReactiveUserControl<ListPatientViewModel> 
    {
        private PatientService service = new PatientService();
        private TextBox filter; 
        //private DataGrid grid_pateint;
        public Register()
        {
            var results = service.GetAll();
            this.DataContext = new ListPatientViewModel(results);

            InitializeComponent();
            //filter = this.FindControl<TextBox>("txt_search");

            //grid_pateint = this.FindControl<DataGrid>("grd_patient");

            this.WhenActivated(disposables =>
            {
                /*  Type safe way
                this.BindCommand(ViewModel, x => x.ExampleCommand, x => x.ExampleButton)
               .DisposeWith(disposables);
                */
                //this.Bind(ViewModel, (vm) => vm.Filter_Text, (v) => filter.Text);

               
                /* Handle activation */
                Disposable
                    .Create(() => { /* Handle deactivation */ })
                    .DisposeWith(disposables);
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
