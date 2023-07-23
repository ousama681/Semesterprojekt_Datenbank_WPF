using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.ArticleGroupWM;

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

        private void TreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            ViewModel.SelectedArticleGroup = (Models.ArticleGroup)ArtGroupTr.SelectedItem;
            AddCmd.IsEnabled = true;
            DelCmd.IsEnabled = true;
            EditCmd.IsEnabled = true;
        }
    }
}
