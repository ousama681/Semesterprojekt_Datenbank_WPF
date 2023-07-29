using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Common.Interfaces;
using WPF_Ui.ViewModels.Order;

namespace WPF_Ui.Views.Pages.Order
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : INavigableView<OrderViewModel>
    {
        public OrderViewModel ViewModel
        {
            get;
        }

        public OrderPage(OrderViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = this;


            //ViewModel.ScrollToSelectedOrderRequested += ViewModel_ScrollToSelectedOrderRequested;

        }

        private async void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ViewModel.SelectedArticleGroup = (Models.ArticleGroup)ArtGroupTr.SelectedItem;

            if (ViewModel.SelectedArticleGroup != null) {
                // Load ComboBox with Articles related to TreeView

                IEnumerable<Models.Article> articles = await ViewModel.GetArticles();

                CmbArticles.ItemsSource = articles
                    .Where(a => a.ArticleGroup.Id == ViewModel.SelectedArticleGroup.Id)
                    .ToList();
            }
        }

        private void DgvOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Hier noch prüfen ob Invoice generiert wurde. Wenn ja dann Datagrid ausgrauen und alle Buttons disablen
            // soll man noch Order löschen können wenn Rechnung generiert wurde?


            if (ViewModel.SelectedOrder != null)
            {
                ViewModel.SetPositionsOfOrder();

                if (ViewModel.SelectedOrder.IsInvoiceGenerated == false)
                {
                    this.DelOrdCmd.IsEnabled = true;
                    this.CreateInvoiceCmd.IsEnabled = true;
                } else
                {
                    DelOrdCmd.IsEnabled = false;
                    CreateInvoiceCmd.IsEnabled = false;
                }
            }
            else
            {
                this.DelOrdCmd.IsEnabled = false;
                this.AddPosCmd.IsEnabled = false;
                this.DelPosCmd.IsEnabled = false;
                this.CreateInvoiceCmd.IsEnabled = false;
            }
        }

        private void CmbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.SelectedCustomer != null)
            {
                AddOrdCmd.IsEnabled = true;
            }
            else
            {
                AddOrdCmd.IsEnabled = false;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.SelectedPosition != null)
            {
                DelPosCmd.IsEnabled = true;
            }
            else
            {
                DelPosCmd.IsEnabled = false;
            }
        }

        private void ViewModel_ScrollToSelectedOrderRequested(object sender, EventArgs e)
        {
            // Scroll the DataGrid to the newly added order
            //DgvOrders.ScrollIntoView(DgvOrders.SelectedItem);
        }

        private void CmbArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.SelectedArticle != null)
            {
                AddPosCmd.IsEnabled = true;
            } else
            {
                AddPosCmd.IsEnabled = false;
            }
        }

        private void TxtAnzahl_TextChanged(object sender, TextChangedEventArgs e)
        {

            string text = TxtAnzahl.Text;

            if (IsNumbersOnly(text) && text.Length > 0)
            {
                int anzahl = Convert.ToInt32(text);

                if (anzahl > 0)
                {
                    ViewModel.Quantity = anzahl;
                    AddPosCmd.IsEnabled = true;
                } else
                {
                    AddPosCmd.IsEnabled = false;
                }
            } else
            {
                TxtAnzahl.Clear();
            }

        }

        private bool IsNumbersOnly(string text)
        {

            Regex regex = new Regex("[^0-9.-]+");

            return !regex.IsMatch(text);
        }
    }
}
