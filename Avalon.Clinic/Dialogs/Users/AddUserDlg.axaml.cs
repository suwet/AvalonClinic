using System;
using Avalon.Clinic.ViewModels.PatientVM;
using Avalon.Clinic.ViewModels.UsersVM;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace Avalon.Clinic.Dialogs.Users; 

public partial class AddUserDlg : ReactiveWindow<UsersViewModel> {
    public AddUserDlg() {
        InitializeComponent();
        this.Opened += OnOpened;
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
        this.DataContext = new UsersViewModel();
    }
    
    private void OnOpened(object? sender, EventArgs e) {
        int window_w = (int)this.DesiredSize.Width / 2;
        int window_h = (int)this.DesiredSize.Height / 2;
        int x = (int)(Program.MainWindow.Bounds.Width / 2) - window_w;
        int y = (int)(Program.MainWindow.Bounds.Height / 2) - (window_h);
        this.Position = new Avalonia.PixelPoint(x, y);
    }
}

