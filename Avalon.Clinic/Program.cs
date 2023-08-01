using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using AutoMapper;
using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Avalon.Clinic.Models;
using ShowMeTheXaml;
using Microsoft.Extensions.Configuration;

namespace Avalon.Clinic {
    internal class Program
    {
        public static MainWindow MainWindow { get; private set; }
        //public static MapperConfiguration map_configuration { get; private set; }
        //public static IMapper mapper;
        public static IConfigurationRoot configuration;

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.

        // STA thread is required for IME system.
        [STAThread]
        public static void Main(string[] args)
        {
             configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
             
            BuildAvaloniaApp().Start(AppMain, args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect()
                .With(new X11PlatformOptions
                {
                    EnableMultiTouch = false,
                    UseDBusMenu = true,
                    EnableIme = true,
                    UseGpu = false
                })
                .With(new Win32PlatformOptions
                {
                    EnableMultitouch = true
                })
                .UseXamlDisplay()
                .LogToTrace();
        }

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
        private static void AppMain(Application app, string[] args)
        {
            MainWindow = new MainWindow();
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            app.Run(MainWindow);
        }
    }
}
