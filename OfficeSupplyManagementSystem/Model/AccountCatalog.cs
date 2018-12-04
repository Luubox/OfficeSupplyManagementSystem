using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using OfficeSupplyManagementSystem.Persistency;

namespace OfficeSupplyManagementSystem.Model
{
    class AccountCatalog
    {
        //collection class follows the singleton pattern, means there can only be one instance.

        //private property of the class (name _instance is for clarity)
        private static AccountCatalog _instance = new AccountCatalog();

        //public property of the class
        public static AccountCatalog Instance { get => _instance; } // => lampda expression

        //ObservableCollection of Items with automatic get; set;
        public ObservableCollection<Account> AccountList { get; set; }

        //constructor that takes 0 parameters
        public AccountCatalog()
        {
            //initiates the ObservableCollection of items
            AccountList = new ObservableCollection<Account>();
            LoadAccountsAsync;
        }

        public async void LoadAccountsAsync()
        {
            var accounts = await PersistencyService.LoadCollectionFromJsonAsync<Account>();
            if (accounts.Count != 0)
            {
                foreach (var account in accounts)
                {
                    AccountList.Add(account);
                }
                SaveFile();
            }
            else
            {
                //adds default accounts to collections for testing purposes
                AccountList.Add(new Account("3527564605", 582058, "Nikolajsgade 22", 22448866, "836295726490315", "Aktiv"));
                AccountList.Add(new Account("6274869663", 918436, "Johansgade 26", 19634657, "325642478573578", "Aktiv"));
                AccountList.Add(new Account("6726498592", 501746, "Saxildsgade 30", 49859034, "267572364782360", "Inaktiv"));
                AccountList.Add(new Account("8765434900", 182791, "Patricksgade 22", 94876463, "856748959568747", "Aktiv"));
                AccountList.Add(new Account("3456775357", 758694, "Jonasgade 24", 56734894, "657465765386538", "Inaktiv"));

                SaveFile();
            }
        }

        public void SafeFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Account>>(AccountList);
        }
        //add method that corresponds to the account class contructer (names don't have to match, only for clarity
        public void Add(string accountNumber, int accountCvr, string accountDeliveryAddress, int acccountContact, string accountBankingInfo, bool accountStatus)
        {
            Account newAccount = new Account(accountNumber, accountCvr, accountDeliveryAddress, acccountContact, accountBankingInfo, accountStatus);
            AccountList.Add(newAccount);
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Account>>(AccountList);
        }
    }
}
