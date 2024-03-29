﻿using System;
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
using WPF_Ui.ViewModels.Article;

namespace WPF_Ui.Views.Pages.Article
{
    /// <summary>
    /// Interaction logic for ArticleEditPage.xaml
    /// </summary>
    public partial class ArticleEditPage : INavigableView<WPF_Ui.ViewModels.Article.ArticleEditViewModel>
    {
        public ArticleEditViewModel ViewModel { get; }

        public ArticleEditPage(ArticleEditViewModel viewModel, ArticleViewModel articleViewModel)
        {
            ViewModel = viewModel;
            ViewModel.SelectedArticle = articleViewModel.SelectedArticle;
            InitializeComponent();
            DataContext = this;
        }
    }
}
