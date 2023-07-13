using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using WPF_Ui.Views.Windows;
using WPF_Ui.Views.Pages;
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

        }
    }
}
