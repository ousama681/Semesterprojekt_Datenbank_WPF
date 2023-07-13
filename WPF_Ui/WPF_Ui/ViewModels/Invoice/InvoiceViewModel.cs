using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Views.Windows;

namespace WPF_Ui.ViewModels.Invoice

{
    public class InvoiceViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }

        MainWindow? mainWindow;

        public InvoiceViewModel()
        {
            DeleteCommand = new RelayCommand(OnDelete);
            EditCommand = new RelayCommand(OnEdit);
            AddCommand = new RelayCommand(OnAdd);
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

        public void OnAdd()
        {
            //mainWindow?.RootNavigation.Navigate(typeof(CustomerAddPage));
        }
        private void OnDelete()
        {

        }

        public void OnEdit()
        {
            //mainWindow?.RootNavigation.Navigate(typeof(CustomerEditPage));
        }
    }
}
