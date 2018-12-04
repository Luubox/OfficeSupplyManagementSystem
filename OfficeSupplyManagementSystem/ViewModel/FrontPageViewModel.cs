using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using OfficeSupplyManagementSystem.View;

namespace OfficeSupplyManagementSystem.ViewModel
{
    class FrontPageViewModel
    {
        public ICommand NavigateToItemCommand { get; set; }

        public FrontPageViewModel()
        {
            NavigateToItemCommand = new RelayCommand(NavigateToItem);
        }

        public void NavigateToItem()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(ItemPage));
        }
    }
}
