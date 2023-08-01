using Avalon.Clinic.Services;
using Avalon.Clinic.ViewModels.RoleVM;
using Avalon.Models;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalon.Clinic.Pages {
    public partial class Roles : UserControl {
        private RoleService service = new RoleService();
        public Roles() {
            InitializeComponent();
            var results= service.GetAll();
            this.DataContext = new ListRolesViewModel(results);
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
