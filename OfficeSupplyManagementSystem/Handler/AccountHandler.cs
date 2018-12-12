using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.ViewModel;

namespace OfficeSupplyManagementSystem.Handler
{
    class AccountHandler
    {
        public AccountViewModel AccountViewModel { get; set; }

        public AccountHandler(AccountViewModel accountViewModel)
        {
            AccountViewModel = accountViewModel;
        }

        /// <summary>
        /// Creates a new Account object, adds it to the catalogue and saves to local file
        /// </summary>
        public void CreateAccount()
        {
            AccountViewModel.AccountCatalog.AccountList.Add(AccountViewModel.NewAccount);
            AccountViewModel.AccountCatalog.SaveFile();
        }

        /// <summary>
        /// Updates the target Account at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void DeleteAccount()
        {
            AccountViewModel.AccountCatalog.AccountList.RemoveAt(AccountViewModel.TargetIndex);
            AccountViewModel.AccountCatalog.SaveFile();
        }

        /// <summary>
        /// Deteles the target Account at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void EditAccount()
        {
            AccountViewModel.AccountCatalog.AccountList[AccountViewModel.TargetIndex] = AccountViewModel.TargetAccount;
            AccountViewModel.AccountCatalog.SaveFile();
        }
    }
}
