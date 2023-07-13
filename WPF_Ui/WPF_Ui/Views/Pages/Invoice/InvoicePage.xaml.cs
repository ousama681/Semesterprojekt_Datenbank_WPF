using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.Invoice;

namespace WPF_Ui.Views.Pages.Invoice
{
    /// <summary>
    /// Interaction logic for InvoicePage.xaml
    /// </summary>
    public partial class InvoicePage : INavigableView<InvoiceViewModel>
    {
        public InvoiceViewModel ViewModel
        {
            get;
        }

        public InvoicePage(InvoiceViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();

        }
    }
}
