using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;
using WPF_Ui.Models;
using WPF_Ui.Services;

namespace WPF_Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            .ConfigureServices((context, services) =>
            {
                // App Host
                services.AddHostedService<ApplicationHostService>();

                // Page resolver service
                services.AddSingleton<IPageService, PageService>();

                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                // Main window with navigation
                services.AddScoped<INavigationWindow, Views.Windows.MainWindow>();
                services.AddScoped<ViewModels.MainWindowViewModel>();

                // Views and ViewModels
                services.AddScoped<Views.Pages.DashboardPage>();
                services.AddScoped<ViewModels.DashboardViewModel>();
                services.AddScoped<Views.Pages.DataPage>();
                services.AddScoped<ViewModels.DataViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.Settings.SettingsPage>();
                services.AddScoped<WPF_Ui.ViewModels.Settings.SettingsViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.Customer.CustomerPage>();
                services.AddScoped<WPF_Ui.ViewModels.Customer.CustomerViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.Customer.CustomerEditPage>();
                services.AddScoped<WPF_Ui.ViewModels.Customer.CustomerEditViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.Customer.CustomerAddPage>();
                services.AddScoped<WPF_Ui.ViewModels.Customer.CustomerAddViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.Article.ArticlePage>();
                services.AddScoped<WPF_Ui.ViewModels.Article.ArticleViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.ArticleGroup.ArticleGroupPage>();
                services.AddScoped<WPF_Ui.ViewModels.ArticleGroup.ArticleGroupViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.Invoice.InvoicePage>();
                services.AddScoped<WPF_Ui.ViewModels.Invoice.InvoiceViewModel>();
                services.AddScoped<WPF_Ui.Views.Pages.Order.OrderPage>();
                services.AddScoped<WPF_Ui.ViewModels.Order.OrderViewModel>();

                // Configuration
                services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
            }).Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}