using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Services.Data.Repository;
using WPF_Ui.ViewModels.Customer;
using WPF_Ui.Views.Pages.Article;
using WPF_Ui.Views.Pages.Customer;
using WPF_Ui.Views.Windows;

namespace WPF_Ui.ViewModels.Article
{
    public partial class ArticleEditViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand SaveCommand { get; set; }
        public ICommand BackCommand { get; set; }
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleGroupRepository _articleGroupRepository;

        public WPF_Ui.Models.Article SelectedArticle { get; set; }
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

        public ArticleEditViewModel(IArticleRepository articleRepository, IArticleGroupRepository articleGroupRepository )
        {
            _articleGroupRepository = articleGroupRepository;
            _articleRepository = articleRepository;
            SaveCommand = new RelayCommand(OnSaveClick);
            BackCommand = new RelayCommand(OnBackClick);
            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }

            ArticleNumber = SelectedArticle.Nr;
            ArticleName = SelectedArticle.Name;
            Price = SelectedArticle.Price;
            ArticleGroup = SelectedArticle.ArticleGroup.Name;
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
            ArticlePage page;
            if (SelectedArticle != null)
            {
                page = new ArticlePage(new ArticleViewModel(_articleRepository, _articleGroupRepository));
                mainWindow?.GetFrame().Navigate(page);
            }
        }

        [RelayCommand]
        private async void OnSaveClick()
        {
            Models.ArticleGroup newArticleGroup = new Models.ArticleGroup
            {
                Name = SelectedArticle.ArticleGroup.Name,
            };

            var articleGroup = await _articleGroupRepository.GetByNameAsync(newArticleGroup);

            SelectedArticle.Name = ArticleName;
            SelectedArticle.Price = Price;

            if (articleGroup.Id != 0)
            {
                SelectedArticle.ArticleGroupId = articleGroup.Id;
                await _articleRepository.UpdateAsync(SelectedArticle);
                OnBackClick();
            }
            else
            {
                MessageBox.Show("Please add valid Articlegroup");
            }
        }
    }
}
