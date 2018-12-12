using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OfficeSupplyManagementSystem.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FrontPage : Page
    {
        public FrontPage()
        {
            this.InitializeComponent();

            BackButton.Visibility = Visibility.Collapsed;
            ContentFrame.Navigate(typeof(ItemPage));
            TitleTextBlock.Text = "Varer";
            ItemListBox.IsSelected = true;
        }

        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
                ItemListBox.IsSelected = true;
            }
        }

        private void MenuListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemListBox.IsSelected)
            {
                BackButton.Visibility = Visibility.Collapsed;
                ContentFrame.Navigate(typeof(ItemPage));
                TitleTextBlock.Text = "Varer";
            }
            else if (OrderListBox.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                ContentFrame.Navigate(typeof(OrderPage));
                TitleTextBlock.Text = "Ordre";
            }
            else if (AccountListBox.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                ContentFrame.Navigate(typeof(AccountPage));
                TitleTextBlock.Text = "Konti";
            }
            else if (ResupplyListBox.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                ContentFrame.Navigate(typeof(ResupplyOrderPage));
                TitleTextBlock.Text = "Varelevering";
            }
        }
    }
}
