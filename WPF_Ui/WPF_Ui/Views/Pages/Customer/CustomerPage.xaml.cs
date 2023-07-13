using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using WPF_Ui.Views.Windows;
using WPF_Ui.Views.Pages;

namespace WPF_Ui.Views.Pages.Customer
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : INavigableView<ViewModels.CustomerViewModel>
    {
        public ViewModels.CustomerViewModel ViewModel
        {
            get;
        }

        public CustomerPage(ViewModels.CustomerViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();

        }
    }
}
