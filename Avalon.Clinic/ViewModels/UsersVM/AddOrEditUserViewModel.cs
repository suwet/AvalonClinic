using System.Reactive;
using System.Windows.Input;
using Avalon.Clinic.Services;
using Avalonia.Controls;
using ReactiveUI;

namespace Avalon.Clinic.ViewModels.UsersVM; 

public partial class UsersViewModel :ReactiveViewModelBase{
    private UserService _userservice = new UserService();
    
    public UsersViewModel() {
        
        var canexecute = this.WhenAnyValue(x=>x.username,y=>y.firstname,
            (a,b)=> (!string.IsNullOrEmpty(a)) && (!string.IsNullOrEmpty(b)));
        SaveAddNew = ReactiveCommand.Create<Window>(async (window) => {
            // Do Save and Close
            var row_effect = await _userservice.AddAsync(this);
            window.Close(row_effect);
        }, canexecute,RxApp.TaskpoolScheduler);

        SaveEdit = ReactiveCommand.Create<Window>(async (window) => {
            // Do Save and Close
            var row_effect = await _userservice.UpdateAsync(this);

            window.Close(row_effect);
        }, canexecute, RxApp.TaskpoolScheduler);

        Cancel = ReactiveCommand.Create<Window>((window) => {
            window.Close();
        });
    }
    
    public ReactiveCommand<Window,Unit> SaveAddNew { get;}

    // Command for edit item
    public ReactiveCommand<Window, Unit> SaveEdit { get; }

    // Common
    ICommand Cancel { get; }
}
