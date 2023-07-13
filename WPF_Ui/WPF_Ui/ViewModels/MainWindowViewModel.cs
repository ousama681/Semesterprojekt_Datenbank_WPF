using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace WPF_Ui.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "Auftragsverwaltung";

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Dashboard",
                    PageTag = "dashboard",
                    Icon = SymbolRegular.Home24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },
                new NavigationItem()
                {
                    Content = "Customers",
                    PageTag = "customer",
                    Icon = SymbolRegular.ContactCard48,
                    PageType = typeof(WPF_Ui.Views.Pages.Customer.CustomerPage)
                },
                new NavigationItem()
                {
                    Content = "Articles",
                    PageTag = "article",
                    Icon = SymbolRegular.Document48,
                    PageType = typeof(WPF_Ui.Views.Pages.Article.ArticlePage)
                },
                new NavigationItem()
                {
                    Content = "Articlegroups",
                    PageTag = "articleGroup",
                    Icon = SymbolRegular.DocumentBulletList24,
                    PageType = typeof(WPF_Ui.Views.Pages.ArticleGroup.ArticleGroupPage)
                },
                new NavigationItem()
                {
                    Content = "Orders",
                    PageTag = "order",
                    Icon = SymbolRegular.Album20,
                    PageType = typeof(WPF_Ui.Views.Pages.Order.OrderPage)
                },
                new NavigationItem()
                {
                    Content = "Invoices",
                    PageTag = "invoice",
                    Icon = SymbolRegular.ContactCardLink16,
                    PageType = typeof(WPF_Ui.Views.Pages.Invoice.InvoicePage)
                },
            };

            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Settings",
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(WPF_Ui.Views.Pages.Settings.SettingsPage)
                }
            };

            this.

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "Home",
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }
    }
}
