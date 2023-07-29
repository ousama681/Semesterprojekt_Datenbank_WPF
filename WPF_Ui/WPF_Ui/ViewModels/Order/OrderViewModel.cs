using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Models;
using WPF_Ui.Services.Data;
using WPF_Ui.Services.Data.Interfaces;
using WPF_Ui.Services.Data.Repository;
using WPF_Ui.Views.Windows;

namespace WPF_Ui.ViewModels.Order
{
    public class OrderViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddPosCommand { get; set; }
        public ICommand DeletePosCommand { get; set; }
        public ICommand CreateInvCommand { get; set; }

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

        // Articles 

        private ObservableCollection<ArticleGroup> artGrpArticles;
        public ObservableCollection<ArticleGroup> ArtGrpArticles
        {
            get => artGrpArticles;
            set => SetProperty(ref artGrpArticles, value);
        }

        private Models.Article selectedArticle;
        public Models.Article SelectedArticle
        {
            get => selectedArticle;
            set => SetProperty(ref selectedArticle, value);
        }

        // Articles End 

        // Orders

        private ObservableCollection<Position> orderPositions;
        public ObservableCollection<Position> OrderPositions
        {
            get => orderPositions;
            set => SetProperty(ref orderPositions, value);
        }


        private Models.Order selectedOrder;
        public Models.Order SelectedOrder
        {
            get => selectedOrder;
            set => SetProperty(ref selectedOrder, value);
        }

        private Position selectedPosition;
        public Position SelectedPosition
        {
            get => selectedPosition;
            set => SetProperty(ref selectedPosition, value);
        }

        public event EventHandler ScrollToSelectedOrderRequested;

        // orders end

        // customers 

        private Models.Customer selectedCustomer;
        public Models.Customer SelectedCustomer
        {
            get => selectedCustomer;
            set => SetProperty(ref selectedCustomer, value);
        }

        private ObservableCollection<Models.Customer> customers;
        public ObservableCollection<Models.Customer> Customers
        {
            get => customers;
            set => SetProperty(ref customers, value);
        }


        // customers end



        // positions

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        // positions end

        public readonly IOrderRepository repository;

        MainWindow? mainWindow;

        public OrderViewModel(IOrderRepository repository)
        {
            DeleteCommand = new RelayCommand(OnDelete);
            EditCommand = new RelayCommand(OnEdit);
            AddCommand = new RelayCommand(OnAdd);
            AddPosCommand = new RelayCommand(OnAddPosCommand);
            DeletePosCommand = new RelayCommand(OnDeletePosCommand);
            CreateInvCommand = new RelayCommand(OnCreateInvCommand);
            mainWindow = Window.GetWindow(Application.Current.MainWindow) as MainWindow;

            ArticleGroups = new ObservableCollection<ArticleGroup>();
            OrderPositions = new ObservableCollection<Position>();

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
            LoadCustomers();
        }

        private async void LoadCustomers()
        {
            var repository = new CustomerRepository(new DataContext());
            List<Models.Customer> customers = await repository.GetAllAsync();
            Customers = new ObservableCollection<Models.Customer>(customers);
        }

        private async void LoadPositions()
        {
            var repository = new PositionRepository(new DataContext());
            List<Models.Position> positions = await repository.GetAllAsync();
            OrderPositions = new ObservableCollection<Position>(positions);
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

        public async void OnAdd()
        {
            Models.Order order = new Models.Order() { Date = DateTime.Today, CustomerId = SelectedCustomer.Id, };
            await repository.AddAsync(order);
            SelectedOrder = await repository.GetAsync(order);
            // Order hinzufpgen
            OnNavigatedTo();

            // Damit das Grid zum neu hinzugefügten Element Scrollt
            // Funktioniert nicht richtig oder gar nicht.
            //ScrollToSelectedOrderRequested?.Invoke(this, EventArgs.Empty);
        }
        private async void OnDelete()
        {
            Models.Order toDelete = await repository.GetAsync(SelectedOrder);
            await repository.DeleteAsync(toDelete);

            OnNavigatedTo();
        }

        public void OnEdit()
        {
            //mainWindow?.RootNavigation.Navigate(typeof(CustomerEditPage));
        }

        public async void OnAddPosCommand()
        {


            Position pos = new Position()
            {
                Quantity = this.Quantity,
                ArticleId = SelectedArticle.Id,
                OrderId = SelectedOrder.Id,
                PriceNetto = this.Quantity * SelectedArticle.Price
            };

            var repository = new PositionRepository(new DataContext());
            await repository.AddAsync(pos);

            OnNavigatedTo();
        }

        public async void OnDeletePosCommand()
        {
            var repository = new PositionRepository(new DataContext());
            await repository.DeleteAsync(SelectedPosition);
        }

        public async void OnCreateInvCommand()
        {
            Models.Order order = SelectedOrder;
            decimal totalPrice = OrderPositions.Sum((p) => p.PriceNetto);

            Models.Invoice toAdd = new Models.Invoice()
            {
                Date = DateTime.Today,
                NetPrice = totalPrice,
                CustomerId = SelectedOrder.CustomerId,
                OrderId = SelectedOrder.Id
            };

            var invoiceRepository = new InvoiceRepository(new DataContext());
            bool isSuccessfull = await invoiceRepository.AddAsync(toAdd);

            if (isSuccessfull)
            {
                if (order.IsInvoiceGenerated != true)
                {
                    order = await repository.GetAsync(order);

                    order.IsInvoiceGenerated = true;

                    await repository.UpdateAsync(order);
                }
            }

        }

        internal async void SetPositionsOfOrder()
        {
            var repository = new PositionRepository(new DataContext());
            List<Models.Position> positions = await repository.GetOrderPositions(SelectedOrder);
            OrderPositions = new ObservableCollection<Position>(positions);
        }

        internal async Task<IEnumerable<Models.Article>> GetArticles()
        {
            var repository = new ArticleRepository(new DataContext());
            return await repository.GetAllAsync();
        }
    }
}
