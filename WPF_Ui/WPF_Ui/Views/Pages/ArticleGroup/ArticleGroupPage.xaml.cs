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
