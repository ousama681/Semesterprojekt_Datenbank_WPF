using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.Customer;

namespace WPF_Ui.Views.Pages.Customer
{
    /// <summary>
    /// Interaction logic for CustomerAddPage.xaml
    /// </summary>
    public partial class CustomerAddPage : INavigableView<WPF_Ui.ViewModels.Customer.CustomerAddViewModel>
    {
        public CustomerAddViewModel ViewModel { get; }
        public CustomerAddPage(CustomerAddViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }


    }
}
