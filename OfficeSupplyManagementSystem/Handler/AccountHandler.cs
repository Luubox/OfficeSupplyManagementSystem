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

        public void CreateAccount()
        {
            AccountViewModel.AccountCatalog.AccountList.Add(AccountViewModel.NewAccount);
            AccountViewModel.AccountCatalog.SaveFile();
        }

        public void DeleteAccount()
        {
            AccountViewModel.AccountCatalog.AccountList.RemoveAt(AccountViewModel.TargetIndex);
            AccountViewModel.AccountCatalog.SaveFile();
        }

        public void EditAccount()
        {
            AccountViewModel.AccountCatalog.AccountList[AccountViewModel.TargetIndex] = AccountViewModel.TargetAccount;
            AccountViewModel.AccountCatalog.SaveFile();
        }
    }
}
