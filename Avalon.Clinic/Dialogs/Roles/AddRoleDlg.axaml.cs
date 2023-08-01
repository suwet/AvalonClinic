using Avalon.Clinic.ViewModels.UsersVM;
using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalon.Clinic.ViewModels.RoleVM;
using Avalonia.ReactiveUI;

namespace Avalon.Clinic.Dialogs.Roles {
    public partial class AddRoleDlg : ReactiveWindow<RolesViewModel> {
        public AddRoleDlg() {
            InitializeComponent();
            this.Opened += OnOpened;
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
