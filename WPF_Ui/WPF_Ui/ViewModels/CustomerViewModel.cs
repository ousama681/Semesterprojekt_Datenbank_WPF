using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Wpf.Ui.Common;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;
using WPF_Ui.Views.Windows;
using WPF_UI.Views.Windows;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace WPF_Ui.ViewModels
{
    public class CustomerViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        MainWindow mainWindow = MainWindow.GetWindow(App.Current.MainWindow) as MainWindow;

        public CustomerViewModel()
        {
            this.DeleteCommand = new RelayCommand(OnDelete);
            this.EditCommand = new RelayCommand(OnEdit);
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

            ((NavigationItem)mainWindow.GetNavigation().Items[4]).Visibility = Visibility.Hidden;

            mainWindow.RootNavigation.Navigate(4);
        }


    }
}
