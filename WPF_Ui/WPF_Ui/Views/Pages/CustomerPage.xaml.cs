using Wpf.Ui.Common.Interfaces;

namespace WPF_Ui.Views.Pages
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
