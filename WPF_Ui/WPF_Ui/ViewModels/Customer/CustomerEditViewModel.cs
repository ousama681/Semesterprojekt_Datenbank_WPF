﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Views.Pages.Customer;
using WPF_Ui.Views.Windows;

namespace WPF_Ui.ViewModels.Customer
{
    public partial class CustomerEditViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand SaveCommand { get; set; }
        public ICommand BackCommand { get; set; }
        private readonly ICustomerRepository _customerRepository;
        private readonly ITownRepository _townRepository;
        public WPF_Ui.Models.Customer SelectedCustomer { get; set; }
        MainWindow mainWindow;

        private int _customerNumber;
        public int CustomerNumber
        {
            get { return _customerNumber; }
            set { SetProperty(ref _customerNumber, value); }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _website;
        public string Website
        {
            get { return _website; }
            set { SetProperty(ref _website, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        public CustomerEditViewModel(ICustomerRepository customerRepository, ITownRepository townRepository)
        {
            _townRepository = townRepository;
            _customerRepository = customerRepository;
            SaveCommand = new RelayCommand(OnSaveClick);
            BackCommand = new RelayCommand(OnBackClick);
            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        }

        public async void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
            
            CustomerNumber = SelectedCustomer.Nr;
            CustomerName = SelectedCustomer.Name;
            Street = SelectedCustomer.Street;
            ZipCode = SelectedCustomer.Town.ZipCode;
            Email = SelectedCustomer.Email;
            Website = SelectedCustomer.Website;
            Password = SelectedCustomer.Password;
            City = SelectedCustomer.Town.City;
            Country = SelectedCustomer.Town.Country;
        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        public void OnNavigatedFrom()
        {
            
        }

        [RelayCommand]
        private void OnBackClick()
        {
            CustomerPage page;
            if (SelectedCustomer != null)
            {
                page = new CustomerPage(new CustomerViewModel(_customerRepository, _townRepository));
                mainWindow?.GetFrame().Navigate(page);
            }
        }

        [RelayCommand]
        private async void OnSaveClick()
        {
            Town newTown = new Town
            {
                City = City,
                ZipCode = ZipCode,
                Country = "CH"
            };

            var town = await _townRepository.GetAsync(newTown);


            SelectedCustomer.Name = CustomerName;
            SelectedCustomer.Street = Street;
            SelectedCustomer.Email = Email;
            SelectedCustomer.Website = Website;
            SelectedCustomer.Password = Password;
            if (town.Id != 0)
            {
                SelectedCustomer.TownId = town.Id;
                await _customerRepository.UpdateAsync(SelectedCustomer);

                OnBackClick();
            }
            else
            {
                MessageBox.Show("Please check address details");
            }
        }
    }
}
