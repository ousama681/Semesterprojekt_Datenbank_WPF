using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using WPF_Ui.ViewModels;

namespace WPF_Ui.ViewModels.Customer
{
    public partial class CustomerEditViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand EditCommand { get; set; }

        public CustomerEditViewModel()
        {
            if(!_isInitialized)
                InitialiseViewModel();
        }

        private void InitialiseViewModel()
        {

        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        public void OnNavigatedFrom()
        {
            
        }


        [RelayCommand]
        private void OnEditClick()
        {

        }
    }
}
