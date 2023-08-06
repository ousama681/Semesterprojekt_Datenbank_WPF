using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

namespace WPF_Ui.ViewModels.Invoice

{
    public class InvoiceViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public readonly IInvoiceRepository _invoiceRepository;
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

        private WPF_Ui.Models.Invoice _selectedInvoice;
        public WPF_Ui.Models.Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set { SetProperty(ref _selectedInvoice, value); }
        }

        private ObservableCollection<WPF_Ui.Models.Invoice> _invoiceList;
        public ObservableCollection<WPF_Ui.Models.Invoice> InvoiceList
        {
            get { return _invoiceList; }
            set
            {
                SetProperty(ref _invoiceList, value);
                FilterCustomers();
            }
        }

        private ObservableCollection<WPF_Ui.Models.Invoice> _filteredInvoices;
        public ObservableCollection<WPF_Ui.Models.Invoice> FilteredInvoices
        {
            get { return _filteredInvoices; }
            set { SetProperty(ref _filteredInvoices, value); }
        }

        public InvoiceViewModel(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
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
            List<WPF_Ui.Models.Invoice> customers = await _invoiceRepository.GetAllAsync();
            InvoiceList = new ObservableCollection<WPF_Ui.Models.Invoice>(customers);
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
                FilteredInvoices = InvoiceList;
            }
            else
            {
                FilteredInvoices = new ObservableCollection<WPF_Ui.Models.Invoice>(
                InvoiceList.Where(c =>
                c.Customer.Name.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Customer.Nr.ToString().Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Customer.Email.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Customer.Street.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Customer.Website.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Customer.Town.City.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Customer.Town.ZipCode.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)));
            }
        }

        public void OnAdd()
        {
            mainWindow?.RootNavigation.Navigate(typeof(CustomerAddPage));
        }
        private async void OnDelete()
        {
            await _invoiceRepository.DeleteAsync(SelectedInvoice);
            OnNavigatedTo();
        }

        public void OnEdit()
        {
            mainWindow?.RootNavigation.Navigate(typeof(CustomerEditPage));
        }
    }
}
