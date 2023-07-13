using Wpf.Ui.Common.Interfaces;
using WPF_Ui.Views.Pages;

namespace WPF_Ui.Views.Pages.Settings
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : INavigableView<WPF_Ui.ViewModels.Settings.SettingsViewModel>
    {
        public WPF_Ui.ViewModels.Settings.SettingsViewModel ViewModel
        {
            get;
        }

        public SettingsPage(WPF_Ui.ViewModels.Settings.SettingsViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}
