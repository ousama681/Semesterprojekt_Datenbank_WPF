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
        public readonly ITownRepository _townRepository;

        private ObservableCollection<WPF_Ui.Models.Customer> _customerList;
        public ObservableCollection<WPF_Ui.Models.Customer> CustomerList
        {
            get { return _customerList; }
            set { SetProperty(ref _customerList, value); }
        }
        private WPF_Ui.Models.Customer _selectedCustomer;
        public WPF_Ui.Models.Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { SetProperty(ref _selectedCustomer, value); }
        }

        MainWindow? mainWindow;

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
