using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_UI.Views.Windows;

namespace WPF_Ui.ViewModels
{
    public class CustomerViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

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
            CustomerEditWindow customerEditWindow = new CustomerEditWindow();
            customerEditWindow.Show();
        }


    }
}
