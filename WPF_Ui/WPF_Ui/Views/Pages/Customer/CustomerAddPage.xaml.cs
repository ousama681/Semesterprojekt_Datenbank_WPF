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
using WPF_Ui.ViewModels;
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
