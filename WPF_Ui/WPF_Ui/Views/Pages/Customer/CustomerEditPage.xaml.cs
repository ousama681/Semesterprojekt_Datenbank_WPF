using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.Customer;

namespace WPF_Ui.Views.Pages.Customer
{
    /// <summary>
    /// Interaction logic for CustomerEditPage.xaml
    /// </summary>
    public partial class CustomerEditPage : INavigableView<WPF_Ui.ViewModels.Customer.CustomerEditViewModel>
    {
        public CustomerEditViewModel ViewModel { get; }
        public CustomerEditPage(CustomerEditViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }


    }
}
