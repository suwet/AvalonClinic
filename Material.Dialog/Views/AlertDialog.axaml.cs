using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Material.Dialog.Interfaces;
using Material.Dialog.ViewModels;

namespace Material.Dialog.Views
{
    public class AlertDialog : Window, IDialogWindowResult<DialogResult>, IHasNegativeResult
    {
        public AlertDialog() {
            this.Opened += OnOpened;
            InitializeComponent(); 
            
#if DEBUG
            
            this.AttachDevTools();
        
#endif
            
        }
        private void OnOpened(object? sender, EventArgs e) {
            int window_w = (int)this.DesiredSize.Width / 2;
            int window_h = (int)this.DesiredSize.Height / 2;
            int x = (int)(Owner.Bounds.Width / 2) - window_w;
            int y = (int)(Owner.Bounds.Height / 2) - window_h;
            this.Position = new Avalonia.PixelPoint(x, y);
        }
        
        public DialogResult GetResult() => (DataContext as AlertDialogViewModel)?.DialogResult;

        public void SetNegativeResult(DialogResult result)
        {
            if (DataContext is AlertDialogViewModel viewModel)
                viewModel.DialogResult = result;
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);
            int window_w = (int)this.DesiredSize.Width/2;
            int window_h = (int)this.DesiredSize.Height/2;
            int x = (Screens.Primary.WorkingArea.Width/2)-window_w;
            int y = (Screens.Primary.WorkingArea.Height/2)-window_h;

            this.Position = new Avalonia.PixelPoint(x,y);

        }
        private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
    }
}
