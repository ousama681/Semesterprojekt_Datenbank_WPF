using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Views.Windows;

namespace WPF_Ui.ViewModels.ArticleGroupWM
{
    public class ArticleGroupViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }


        private string newArticleGroupName;
        public string NewArticleGroupName
        {
            get => newArticleGroupName;
            set => SetProperty(ref newArticleGroupName, value);
        }

        private string searchText = "Search";

        public string SearchText
        {
            get => searchText;
            set => SetProperty(ref searchText, value);
        }

        private TreeView agTreeView;
        public TreeView AgTreeView
        {
            get => agTreeView;
            set => SetProperty(ref agTreeView, value);
        }


        private ArticleGroup selectedArticleGroup;
        public ArticleGroup SelectedArticleGroup
        {
            get => selectedArticleGroup;
            set => SetProperty(ref selectedArticleGroup, value);
        }

        // TreeView
        private ObservableCollection<ArticleGroup> articleGroups;
        public ObservableCollection<ArticleGroup> ArticleGroups
        {
            get => articleGroups;
            set => SetProperty(ref articleGroups, value);
        }

        public readonly IArticleGroupRepository repository;

        MainWindow? mainWindow;

        public ArticleGroupViewModel(IArticleGroupRepository repository)
        {
            DeleteCommand = new RelayCommand(OnDelete);
            EditCommand = new RelayCommand(OnEdit);
            AddCommand = new RelayCommand(OnAdd);
            SearchCommand = new RelayCommand(OnSearch);

            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;
            ArticleGroups = new ObservableCollection<ArticleGroup>();

            this.repository = repository;
        }

        public async void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }

            CreateHierarchicalTree();
        }

        private async void CreateHierarchicalTree()
        {
            var ags = await repository.GetAllAsync();
            ArticleGroups.Clear();
            ArticleGroups = new ObservableCollection<ArticleGroup>(ags.Where(ag => ag.ParentId == null).ToList());
        }

        public void OnNavigatedFrom()
        {

        }

        private void InitializeViewModel()
        {
            _isInitialized = true;
        }

        public async void OnAdd()
        {
            ArticleGroup ag = new ArticleGroup()
            {
                Name = NewArticleGroupName,
                ParentId = SelectedArticleGroup.Id
            };
            try
            {
                await repository.AddAsync(ag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            OnNavigatedTo();
        }
        private async void OnDelete()
        {
            ArticleGroup ag = new ArticleGroup()
            {
                Id = SelectedArticleGroup.Id,
                Name = SelectedArticleGroup.Name,
                ParentId = SelectedArticleGroup.Id
            };

            try
            {
                ag = await repository.GetAsync(ag);
                await repository.DeleteAsync(ag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            OnNavigatedTo();
        }

        public async void OnEdit()
        {
            ArticleGroup ag = new ArticleGroup()
            {
                Id = SelectedArticleGroup.Id,
                Name = SelectedArticleGroup.Name,
                ParentId = SelectedArticleGroup.Id
            };
            try
            {

                ag = await repository.GetAsync(ag);
                ag.Name = NewArticleGroupName;
                await repository.UpdateAsync(ag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            OnNavigatedTo();
        }

        public async void OnSearch()
        {

            // Implement Search
        }
    }
}
