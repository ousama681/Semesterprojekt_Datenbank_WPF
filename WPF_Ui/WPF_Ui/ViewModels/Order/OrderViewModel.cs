using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Views.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Repository;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Services.Data;

namespace WPF_Ui.ViewModels.Order
{
    public class OrderViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }

        private ObservableCollection<Models.Order> orders;
        public ObservableCollection<Models.Order> Orders
        {
            get => orders;
            set => SetProperty(ref orders, value);
        }

        // TreeView
        private ObservableCollection<ArticleGroup> articleGroups;
        public ObservableCollection<ArticleGroup> ArticleGroups
        {
            get => articleGroups;
            set => SetProperty(ref articleGroups, value);
        }

        private ArticleGroup selectedArticleGroup;
        public ArticleGroup SelectedArticleGroup
        {
            get => selectedArticleGroup;
            set => SetProperty(ref selectedArticleGroup, value);
        }

        // TreeView end

        // Positions 

        private ObservableCollection<Position> positions;
        public ObservableCollection<Position> Positions
        {
            get => positions;
            set => SetProperty(ref positions, value);
        }

        // Positions end


        public readonly IOrderRepository repository;

        MainWindow? mainWindow;

        public OrderViewModel(IOrderRepository repository)
        {
            DeleteCommand = new RelayCommand(OnDelete);
            EditCommand = new RelayCommand(OnEdit);
            AddCommand = new RelayCommand(OnAdd);
            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;

            ArticleGroups = new ObservableCollection<ArticleGroup>();
            Positions = new ObservableCollection<Position>();

            this.repository = repository;
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
            CreateHierarchicalTree();
            LoadOrders();
            LoadPositions();
        }

        private async void LoadPositions()
        {
            var repository = new PositionRepository(new DataContext());
            List<Models.Position> positions = await repository.GetAllAsync();
            Positions = new ObservableCollection<Position>(positions);
        }

        private async void LoadOrders()
        {
            List<Models.Order> orders = await repository.GetAllAsync();
            Orders = new ObservableCollection<Models.Order>(orders);
        }

        private async void CreateHierarchicalTree()
        {
            var artGroupRepository = new ArticleGroupRepository(new DataContext());
            var ags = await artGroupRepository.GetAllAsync();
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

        public void OnAdd()
        {
            //mainWindow?.RootNavigation.Navigate(typeof(CustomerAddPage));
        }
        private void OnDelete()
        {

        }

        public void OnEdit()
        {
            //mainWindow?.RootNavigation.Navigate(typeof(CustomerEditPage));
        }
    }
}
