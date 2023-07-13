using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.Customer;

namespace WPF_Ui.Views.Pages.Customer
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : INavigableView<CustomerViewModel>
    {
        public CustomerViewModel ViewModel
        {
            get;
        }

        public CustomerPage(CustomerViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = this;

        }
    }
}
