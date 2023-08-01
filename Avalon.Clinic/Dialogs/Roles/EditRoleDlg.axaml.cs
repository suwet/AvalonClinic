using System;
using System.Threading.Tasks;
using Avalon.Clinic.ViewModels.RoleVM;
using Avalon.Clinic.ViewModels.UsersVM;
using Avalon.Models;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Avalon.Clinic.Dialogs.Roles {
    public partial class EditRoleDlg : ReactiveWindow<RolesViewModel> {
        private RoleService _roleService = new RoleService();
        public EditRoleDlg() {
            InitializeComponent();
            this.Opened += OnOpened;
        }

        public EditRoleDlg(int id) {
            AvaloniaXamlLoader.Load(this);
            this.Opened += OnOpened;
            this.DataContext = Task.Run<RolesViewModel>(async () => await _roleService.GetByIdAsync(id)).Result;
        }
        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            this.DataContext = new RolesViewModel();
        }
        private void OnOpened(object? sender, EventArgs e) {
            int window_w = (int)this.DesiredSize.Width / 2;
            int window_h = (int)this.DesiredSize.Height / 2;
            int x = (int)(Program.MainWindow.Bounds.Width / 2) - window_w;
            int y = (int)(Program.MainWindow.Bounds.Height / 2) - (window_h);
            this.Position = new Avalonia.PixelPoint(x, y);
        }
    }
}
