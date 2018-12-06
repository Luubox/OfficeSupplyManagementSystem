using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using GalaSoft.MvvmLight.Command;
using OfficeSupplyManagementSystem.View;

namespace OfficeSupplyManagementSystem.ViewModel
{
    class FrontPageViewModel
    {
        public ICommand NavigateToItemCommand { get; set; }

        public Grid PageGrid { get; set; }

        public FrontPageViewModel()
        {
            //CreatePageGrid();

            NavigateToItemCommand = new RelayCommand(NavigateToItem);
        }

        public void NavigateToItem()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(ItemPage));
        }
        #region Deprecated Code
        //private void CreatePageGrid() //TODO: Hjæææælp!
        //{
        //    PageGrid = new Grid();
        //    RowDefinition rd1 = new RowDefinition();
        //    RowDefinition rd2 = new RowDefinition();

        //    rd1.Height = new GridLength(1, GridUnitType.Star);
        //    PageGrid.RowDefinitions.Add(rd1);
        //    rd2.Height = new GridLength(5, GridUnitType.Star);
        //    PageGrid.RowDefinitions.Add(rd2);

        //    PageGrid.Background = new SolidColorBrush(Color.FromArgb(255,255,0,0));
        //}
        #endregion
    }
}
