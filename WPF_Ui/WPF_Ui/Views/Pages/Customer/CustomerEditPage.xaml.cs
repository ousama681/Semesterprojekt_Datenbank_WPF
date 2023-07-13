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
using WPF_Ui.ViewModels;
using WPF_Ui.Views.Pages;
using WPF_Ui.ViewModels.Customer;

namespace WPF_Ui.Views.Pages.Customer
{
    /// <summary>
    /// Interaction logic for CustomerEditPage.xaml
    /// </summary>
    public partial class CustomerEditPage : INavigableView<WPF_Ui.ViewModels.Customer.CustomerEditViewModel>
    {
        public CustomerEditViewModel ViewModel { get; }
        public CustomerEditPage(CustomerEditViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }


    }
}
