using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Views.Pages.Customer;
using WPF_Ui.Views.Windows;
using WPF_Ui.Models;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace WPF_Ui.ViewModels.Customer
{
    public class CustomerViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public readonly ICustomerRepository _customerRepository;
        private ObservableCollection<WPF_Ui.Models.Customer> _customerList;
        public ObservableCollection<WPF_Ui.Models.Customer> CustomerList
        {
            get { return _customerList; }
            set { SetProperty(ref _customerList, value); }
        }

        MainWindow? mainWindow;

        public CustomerViewModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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

        private async void InitializeViewModel()
        {
            _isInitialized = true;
            List<WPF_Ui.Models.Customer> customers = await _customerRepository.GetAllAsync();
            CustomerList = new ObservableCollection<WPF_Ui.Models.Customer>(customers);
        }

        public void OnAdd()
        {
            mainWindow?.RootNavigation.Navigate(typeof(CustomerAddPage));
        }
        private void OnDelete()
        {

        }

        public void OnEdit()
        {
            mainWindow?.RootNavigation.Navigate(typeof(CustomerEditPage));
        }
    }
}
