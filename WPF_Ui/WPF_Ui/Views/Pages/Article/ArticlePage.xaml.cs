using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.Article;

namespace WPF_Ui.Views.Pages.Article
{
    /// <summary>
    /// Interaction logic for ArticlePage.xaml
    /// </summary>
    public partial class ArticlePage : INavigableView<ArticleViewModel>
    {
        public ArticleViewModel ViewModel { get; }

        public ArticlePage(ArticleViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = this;
        }
    }
}
