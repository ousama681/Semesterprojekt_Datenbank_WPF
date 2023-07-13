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
using WPF_Ui.ViewModels.ArticleGroup;

namespace WPF_Ui.Views.Pages.ArticleGroup
{
    /// <summary>
    /// Interaction logic for ArticleGroupPage.xaml
    /// </summary>
    public partial class ArticleGroupPage : INavigableView<ArticleGroupViewModel>
    {
        public ArticleGroupViewModel ViewModel
        {
            get;
        }

        public ArticleGroupPage(ArticleGroupViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();

        }
    }
}
