using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OfficeSupplyManagementSystem.Annotations;
using OfficeSupplyManagementSystem.Handler;
using OfficeSupplyManagementSystem.Model;

namespace OfficeSupplyManagementSystem.ViewModel
{
    class AccountViewModel : INotifyPropertyChanged
    {
        public AccountCatalog AccountCatalog { get; set; }
        public AccountHandler AccountHandler { get; set; }

        public ICommand CreateAccountCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand EditAccountCommand { get; set; }
        public ICommand SaveAccountCommand { get; set; }

        public int TargetIndex { get; set; }

        private Account _newAccount;

        public Account NewAccount
        {
            get { return _newAccount; }
            set
            {
                _newAccount = value;
                OnPropertyChanged();
            }
        }

        private Account _targetAccount;
        public Account TargetAccount
        {
            get { return _targetAccount; }
            set
            {
                _targetAccount = value;
                OnPropertyChanged();
            }
        }

        public AccountViewModel()
        {
            AccountCatalog = AccountCatalog.Instance;
            AccountHandler = new AccountHandler(this);

            CreateAccountCommand = new RelayCommand(AccountHandler.CreateAccount);
            DeleteAccountCommand = new RelayCommand(AccountHandler.DeleteAccount);
            EditAccountCommand = new RelayCommand(AccountHandler.EditAccount);
            SaveAccountCommand = new RelayCommand(AccountCatalog.SaveFile);

            NewAccount = new Account();
            TargetAccount = new Account();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
