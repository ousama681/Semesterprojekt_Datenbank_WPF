using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Views.Pages.Customer;
using WPF_Ui.Views.Windows;
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
        public readonly ITownRepository _townRepository;
        MainWindow? mainWindow;

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                FilterCustomers();
            }
        }

        private WPF_Ui.Models.Customer _selectedCustomer;
        public WPF_Ui.Models.Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { SetProperty(ref _selectedCustomer, value); }
        }

        private ObservableCollection<WPF_Ui.Models.Customer> _customerList;
        public ObservableCollection<WPF_Ui.Models.Customer> CustomerList
        {
            get { return _customerList; }
            set
            {
                SetProperty(ref _customerList, value);
                FilterCustomers();
            }
        }

        private ObservableCollection<WPF_Ui.Models.Customer> _filteredCustomers;
        public ObservableCollection<WPF_Ui.Models.Customer> FilteredCustomers
        {
            get { return _filteredCustomers; }
            set { SetProperty(ref _filteredCustomers, value); }
        }

        public CustomerViewModel(ICustomerRepository customerRepository, ITownRepository townRepository)
        {
            _townRepository = townRepository;
            _customerRepository = customerRepository;
            DeleteCommand = new RelayCommand(OnDelete);
            EditCommand = new RelayCommand(OnEdit);
            AddCommand = new RelayCommand(OnAdd);
            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        }

        public async void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
            List<WPF_Ui.Models.Customer> customers = await _customerRepository.GetAllAsync();
            CustomerList = new ObservableCollection<WPF_Ui.Models.Customer>(customers);
            SearchText = string.Empty;
        }

        public void OnNavigatedFrom()
        {

        }

        private void InitializeViewModel()
        {
            _isInitialized = true;

        }

        private void FilterCustomers()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredCustomers = CustomerList;
            }
            else
            {
                FilteredCustomers = new ObservableCollection<WPF_Ui.Models.Customer>(
                CustomerList.Where(c =>
                c.Name.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Nr.ToString().Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Email.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Street.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Website.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Town.City.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Town.ZipCode.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)));
            }
        }

        public void OnAdd()
        {
            mainWindow?.RootNavigation.Navigate(typeof(CustomerAddPage));
        }

        private async void OnDelete()
        {
            await _customerRepository.DeleteAsync(SelectedCustomer);
            OnNavigatedTo();
        }

        public void OnEdit()
        {
            CustomerEditPage editPage;
            if (SelectedCustomer != null)
            {
                editPage = new CustomerEditPage(new CustomerEditViewModel(_customerRepository, _townRepository), this);
                mainWindow?.GetFrame().Navigate(editPage);
            }
        }

    }
}
