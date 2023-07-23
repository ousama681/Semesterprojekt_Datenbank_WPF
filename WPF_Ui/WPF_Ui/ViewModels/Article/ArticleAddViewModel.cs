using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Views.Pages.Article;
using WPF_Ui.Views.Pages.Customer;
using WPF_Ui.Views.Windows;

namespace WPF_Ui.ViewModels.Article
{
    public partial class ArticleAddViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand AddCommand { get; set; }
        public ICommand BackCommand { get; set; }
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleGroupRepository _articleGroupRepository;
        MainWindow mainWindow;

        private int _articleNumber;
        public int ArticleNumber
        {
            get { return _articleNumber; }
            set { SetProperty(ref _articleNumber, value); }
        }

        private string _articleName;
        public string ArticleName
        {
            get { return _articleName; }
            set { SetProperty(ref _articleName, value); }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private string _articleGroup;
        public string ArticleGroup
        {
            get { return _articleGroup; }
            set { SetProperty(ref _articleGroup, value); }
        }

        public ArticleAddViewModel(IArticleRepository articleRepository, IArticleGroupRepository articleGroupRepository)
        {
            _articleGroupRepository = articleGroupRepository;
            _articleRepository = articleRepository;
            AddCommand = new RelayCommand(OnAddClick);
            BackCommand = new RelayCommand(OnBackClick);
            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
            ArticleNumber = _articleRepository.MaxNr();
            ArticleName = string.Empty;
            Price = 0;
            ArticleGroup = string.Empty;
        }

        public void OnNavigatedFrom()
        {

        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        [RelayCommand]
        private void OnBackClick()
        {
            mainWindow?.RootNavigation.Navigate(typeof(ArticlePage));
        }

        [RelayCommand]
        private async void OnAddClick()
        {
            Models.ArticleGroup newArticleGroup = new Models.ArticleGroup
            {
                Name = ArticleGroup
            };

            var articleGroup = await _articleGroupRepository.GetByNameAsync(newArticleGroup);
            if (articleGroup.Id != 0)
            {
                Models.Article newArticle = new Models.Article
                {
                    Nr = ArticleNumber,
                    Name = ArticleName,
                    Price = Price,
                    ArticleGroupId = articleGroup.Id,
                    Mwstid = 1
                };
            
                await _articleRepository.AddAsync(newArticle);
                OnBackClick();
            }
            else
            {
                MessageBox.Show("Please add valid Articlegroup");
            }
        }
    }
}
