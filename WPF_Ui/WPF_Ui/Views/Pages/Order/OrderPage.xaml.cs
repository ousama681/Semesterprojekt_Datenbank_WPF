using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.Invoice;
using WPF_Ui.ViewModels.Order;

namespace WPF_Ui.Views.Pages.Order
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : INavigableView<OrderViewModel>
    {
        public OrderViewModel ViewModel
        {
            get;
        }

        public OrderPage(OrderViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = this;

        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ViewModel.SelectedArticleGroup = (Models.ArticleGroup)ArtGroupTr.SelectedItem;
        }
    }
}
