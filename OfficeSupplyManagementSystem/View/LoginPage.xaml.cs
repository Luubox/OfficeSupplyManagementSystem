using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OfficeSupplyManagementSystem.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OfficeSupplyManagementSystem.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private LoginViewModel loginViewModel;
        public LoginPage()
        {
            this.InitializeComponent();

            loginViewModel = new LoginViewModel();
        }

        private void PasswordBox_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PasswordBox_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            Debug.WriteLine(e.Key);
            if (e.Key.ToString() == "Enter")
            {
                Debug.WriteLine(loginViewModel.TempUser.Username);
                Debug.WriteLine(loginViewModel.TempUser.Password);
                loginViewModel.CheckCredentials();
            }
        }
    }
}
