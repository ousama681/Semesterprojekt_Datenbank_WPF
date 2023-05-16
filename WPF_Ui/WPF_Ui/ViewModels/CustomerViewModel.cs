using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Common.Interfaces;

namespace WPF_Ui.ViewModels
{
    public class CustomerViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
                this.Delete = new RelayCommand(OnDelete);
                this.Edit = new RelayCommand(OnEdit);
            }
        }

        public void OnNavigatedFrom()
        {
            
        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        public ICommand Delete { get; set; }
        public ICommand Edit { get; set; }

        private void OnDelete()
        {

        }

        private void OnEdit()
        {

        }

    }
}
