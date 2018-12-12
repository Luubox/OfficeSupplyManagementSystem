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
        private static AccountCatalog _instance = new AccountCatalog();

        public static AccountCatalog Instance { get => _instance; }

        public ObservableCollection<Account> AccountList { get; set; }

        public AccountCatalog()
        {
            AccountList = new ObservableCollection<Account>();
            LoadAccountsAsync();
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
            }
            else
            {
                AccountList.Add(new Account("3527564605", "Kragh & CO.", 582058, "Nikolajsgade 22", 22448866, "836295726490315", "true", 25850));
                AccountList.Add(new Account("6274869663", "Nielsens GørDetDaSelvHus", 918436, "Johansgade 26", 19634657, "325642478573578", "true", 69796));
                AccountList.Add(new Account("6726498592", "Saxilds Vuggestue", 501746, "Saxildsgade 30", 49859034, "267572364782360", "false", 45687));
                AccountList.Add(new Account("8765434900", "Mathias' Skur", 182791, "Patricksgade 22", 94876463, "856748959568747", "true", 35462));
                AccountList.Add(new Account("3456775357", "Rasmussen Gør Det Godt", 758694, "Jonasgade 24", 56734894, "657465765386538", "false", 14527));

                SaveFile();
            }
        }
        
        /// <summary>
        /// Saves the collection to local folder using the SaveCollectionAsJsonAsync in the PersistencyService class,
        /// </summary>
        public void SaveFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Account>>(AccountList, typeof(Account));
        }
    }
}
