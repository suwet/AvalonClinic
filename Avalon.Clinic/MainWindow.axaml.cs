using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalon.Clinic.Dialogs;
using Avalon.Clinic.Models;
using Avalon.Clinic.ViewModels;
using Material.Styles.Controls;
using Material.Styles.Models;
using Material.Styles.Themes;
using Material.Styles.Themes.Base;
using ReactiveUI;
using Avalon.Clinic.Pages;

namespace Avalon.Clinic
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        private readonly List<SnackbarModel> helloSnackBars = new ();
        private ListBox DrawerList;
        private NavigationDrawer LeftDrawer;
        //private ScrollViewer mainScroller;
        private ToggleButton NavDrawerSwitch;
        private Carousel PageCarousel;

        public MainWindow()
        {

            //Debug.WriteLine(Thread.CurrentThread.CurrentUICulture.Name);

            InitializeComponent();
            this.AttachDevTools(KeyGesture.Parse("Shift+F12"));
            var vm = new MainWindowViewModel();
            this.DataContext = vm;
            Debug.WriteLine(Thread.CurrentThread.CurrentUICulture.Name);
            //this.WhenActivated(d => d(ViewModel.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            #region Control getter and event binding

            NavDrawerSwitch = this.Get<ToggleButton>(nameof(NavDrawerSwitch));

            DrawerList = this.Get<ListBox>(nameof(DrawerList));
            DrawerList.PointerReleased += DrawerSelectionChanged;
            DrawerList.KeyUp += DrawerList_KeyUp;

            PageCarousel = this.Get<Carousel>(nameof(PageCarousel));

            //mainScroller = this.Get<ScrollViewer>(nameof(mainScroller));

            LeftDrawer = this.Get<NavigationDrawer>(nameof(LeftDrawer));



            #endregion

        }

        private void DrawerList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
                DrawerSelectionChanged(sender, null);
        }

        public void DrawerSelectionChanged(object sender, RoutedEventArgs? args)
        {
            if (sender is not ListBox listBox)
                return;

            if (!listBox.IsFocused && !listBox.IsKeyboardFocusWithin)
                return;
            try
            {
                PageCarousel.SelectedIndex = listBox.SelectedIndex;
                /* 
                if(PageCarousel.SelectedItem is ILazyLoad)
                {
                    Task.Run(()
                    =>
                    {
                        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(async()
                        =>
                        {
                             await (PageCarousel.SelectedItem as ILazyLoad).LoadItems();
                        });
                       
                    });
                   
                }
                */
                //mainScroller.Offset = Vector.Zero;
                //mainScroller.VerticalScrollBarVisibility =
                //listBox.SelectedIndex == 5 ? ScrollBarVisibility.Disabled : ScrollBarVisibility.Auto;
            }
            catch
            {
                // ignored
            }

            LeftDrawer.OptionalCloseLeftDrawer();
        }

        private void TemplatedControl_OnTemplateApplied(object? sender, TemplateAppliedEventArgs e)
        {
            SnackbarHost.Post("Welcome to demo of Material.Avalonia!");
        }

        private void HelloButtonMenuItem_OnClick(object? sender, RoutedEventArgs e)
        {
            var helloSnackBar = new SnackbarModel("Hello, user!", TimeSpan.Zero);
            SnackbarHost.Post(helloSnackBar);
            helloSnackBars.Add(helloSnackBar);
        }

        private void GoodbyeButtonMenuItem_OnClick(object? sender, RoutedEventArgs e)
        {
            foreach (var snackbarModel in helloSnackBars)
            {
                SnackbarHost.Remove(snackbarModel);
            }

            SnackbarHost.Post("See ya next time, user!");
        }

        private void MaterialIcon_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var materialTheme = Application.Current.LocateMaterialTheme<MaterialTheme>();
            materialTheme.BaseTheme = materialTheme.BaseTheme == BaseThemeMode.Light ? BaseThemeMode.Dark : BaseThemeMode.Light;
        }
    }
}
