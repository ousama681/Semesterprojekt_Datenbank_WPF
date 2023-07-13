using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Views.Pages.Customer;
using WPF_Ui.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using WPF_Ui.Views.Pages.Article;

namespace WPF_Ui.ViewModels.Article
{
    public class ArticleViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }

        MainWindow? mainWindow;

        public ArticleViewModel()
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
            mainWindow?.RootNavigation.Navigate(typeof(ArticleAddPage));
        }
        private void OnDelete()
        {

        }

        public void OnEdit()
        {
            mainWindow?.RootNavigation.Navigate(typeof(ArticleEditPage));
        }
    }
}
