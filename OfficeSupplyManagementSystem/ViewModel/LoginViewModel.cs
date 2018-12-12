using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using OfficeSupplyManagementSystem.Annotations;
using OfficeSupplyManagementSystem.Model;
using OfficeSupplyManagementSystem.View;

namespace OfficeSupplyManagementSystem.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public RelayCommand LoginCommand { get; set; }

        private User _tempUser;
        public User TempUser
        {
            get { return _tempUser; }
            set
            {
                _tempUser = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(UserLogin);
            TempUser = new User();
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        private void UserLogin()
        {
            CheckCredentials();
        }

        /// <summary>
        /// Checks the users credentials against the stored user date
        /// </summary>
        private void CheckCredentials()
        {
            //Only checking against hard coded login details at the moment.
            if (TempUser.Username == "admin")
            {
                if (TempUser.Password != "admin")
                {
                    Message = "Incorrect Password";
                }
                else
                {
                    Message = "Login Successful";
                    ((Frame)Window.Current.Content).Navigate(
                        typeof(FrontPage));
                }
            }
            else Message = "Invalid Username";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
