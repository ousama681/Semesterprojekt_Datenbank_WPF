using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Views.Pages.Customer;
using WPF_Ui.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using WPF_Ui.Views.Pages.Article;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Services.Data.Repository;
using WPF_Ui.ViewModels.Customer;

namespace WPF_Ui.ViewModels.Article
{
    public class ArticleViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public readonly IArticleRepository _articleRepository;
        private readonly IArticleGroupRepository _articleGroupRepository;
        MainWindow? mainWindow;


        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                FilterArticles();
            }
        }

        private WPF_Ui.Models.Article _selectedArticle;
        public WPF_Ui.Models.Article SelectedArticle
        {
            get { return _selectedArticle; }
            set { SetProperty(ref _selectedArticle, value); }
        }

        private ObservableCollection<WPF_Ui.Models.Article> _articleList;
        public ObservableCollection<WPF_Ui.Models.Article> ArticleList
        {
            get { return _articleList; }
            set
            {
                SetProperty(ref _articleList, value);
                FilterArticles();
            }
        }

        private ObservableCollection<WPF_Ui.Models.Article> _filteredArticles;
        public ObservableCollection<WPF_Ui.Models.Article> FilteredArticles
        {
            get { return _filteredArticles; }
            set { SetProperty(ref _filteredArticles, value); }
        }

        public ArticleViewModel(IArticleRepository articleRepository, IArticleGroupRepository articleGroupRepository)
        {
            _articleRepository = articleRepository;
            _articleGroupRepository = articleGroupRepository;
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
            List<WPF_Ui.Models.Article> articles = await _articleRepository.GetAllAsync();
            ArticleList = new ObservableCollection<WPF_Ui.Models.Article>(articles);
            SearchText = string.Empty;
        }

        public void OnNavigatedFrom()
        {

        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        private void FilterArticles()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredArticles = ArticleList;
            }
            else
            {
                FilteredArticles = new ObservableCollection<WPF_Ui.Models.Article>(
                ArticleList.Where(c =>
                c.Name.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Nr.ToString().Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.Price.ToString().Contains(SearchText, StringComparison.InvariantCultureIgnoreCase) ||
                c.ArticleGroup.Name.Contains(SearchText, StringComparison.InvariantCultureIgnoreCase)));
            }
        }

        public void OnAdd()
        {
            mainWindow?.RootNavigation.Navigate(typeof(ArticleAddPage));
        }
        private async void OnDelete()
        {
            await _articleRepository.DeleteAsync(SelectedArticle);
            OnNavigatedTo();
        }

        public void OnEdit()
        {
            ArticleEditPage editPage;
            if (SelectedArticle != null)
            {
                editPage = new ArticleEditPage(new ArticleEditViewModel(_articleRepository, _articleGroupRepository), this);
                mainWindow?.GetFrame().Navigate(editPage);
            }
        }
    }
}
