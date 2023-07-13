using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Wpf.Ui.Common;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;
using WPF_Ui.Views.Windows;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;
using Wpf.Ui.Mvvm.Contracts;
using WPF_Ui.Views.Pages;
using WPF_Ui.Views.Pages.Customer;

namespace WPF_Ui.ViewModels.Customer
{
    public class CustomerViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        MainWindow? mainWindow;

        public CustomerViewModel()
        {
            DeleteCommand = new RelayCommand(OnDelete);
            EditCommand = new RelayCommand(OnEdit);
            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }

        public void OnNavigatedFrom()
        {

        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        private void OnDelete()
        {

        }

        public void OnEdit()
        {
            //CustomerEditWindow customerEditWindow = new CustomerEditWindow();
            //customerEditWindow.Show();            
            mainWindow?.RootNavigation.Navigate(typeof(CustomerEditPage));
        }
    }
}
