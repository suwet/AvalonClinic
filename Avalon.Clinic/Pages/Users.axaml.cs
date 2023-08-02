using System.Threading.Tasks;
using Avalon.Clinic.Services;
using Avalon.Clinic.ViewModels.UsersVM;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Avalon.Clinic.Pages; 

public partial class Users : ReactiveUserControl<ListUsersViewModel>,ILazyLoad  {
    private UserService service = new UserService();
    private TextBox filter; 
    
    public Users() {
        
        InitializeComponent();
        LoadItems();
        
    }
    public async Task  LoadItems()
    {
        this.DataContext = new ListUsersViewModel(await service.GetAllAsync());
    }
    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }
}

