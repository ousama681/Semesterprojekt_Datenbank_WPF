using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;

namespace WPF_Ui.ViewModels.Customer
{
    public partial class CustomerAddViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand EditCommand { get; set; }

        public CustomerAddViewModel()
        {
            if (!_isInitialized)
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
