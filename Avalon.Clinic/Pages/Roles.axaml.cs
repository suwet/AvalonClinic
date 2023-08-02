using System.Threading.Tasks;
using Avalon.Clinic.Services;
using Avalon.Clinic.ViewModels.RoleVM;
using Avalon.Models;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Avalon.Clinic.Pages {
    public partial class Roles : ReactiveUserControl<ListRolesViewModel>, ILazyLoad {
        private RoleService service = new RoleService();
        public Roles() {
            InitializeComponent();
             LoadItems();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        public async Task LoadItems() {
            this.DataContext = new ListRolesViewModel(await service.GetAllAsync());
        }
    }
}
