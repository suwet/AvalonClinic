using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalon.Clinic.Pages;

public partial class InterviewHisPoint : UserControl, ILazyLoad {
    public InterviewHisPoint() {
        InitializeComponent();
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    public async Task LoadItems() {
        //this.DataContext = new ListRolesViewModel(await service.GetAllAsync());
        await Task.Delay(1);
    }
}

