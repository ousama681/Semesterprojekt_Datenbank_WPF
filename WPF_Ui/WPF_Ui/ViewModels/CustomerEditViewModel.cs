using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Common.Interfaces;

namespace WPF_UI.ViewModels
{
    public class CustomerEditViewModel : ObservableObject
    {
        private bool _isInitialised = false;
        public CustomerEditViewModel()
        {
            if(!_isInitialised)
                InitialiseViewModel();
        }

        private void InitialiseViewModel()
        {

        }
    }
}
