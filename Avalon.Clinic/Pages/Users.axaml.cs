using Avalon.Clinic.Services;
using Avalon.Clinic.ViewModels.UsersVM;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Avalon.Clinic.Pages; 

public partial class Users : ReactiveUserControl<ListUsersViewModel>  {
    private UserService service = new UserService();
    private TextBox filter; 
    
    public Users() {
        var result = service.GetAll();
        this.DataContext = new ListUsersViewModel(result);
        InitializeComponent();
        
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}

