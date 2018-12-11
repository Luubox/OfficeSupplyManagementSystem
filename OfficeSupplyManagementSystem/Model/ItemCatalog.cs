using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;
using OfficeSupplyManagementSystem.Persistency;

namespace OfficeSupplyManagementSystem.Model
{
    class ItemCatalog
    {
        //collection class follows the Singleton pattern, means there can only be one instance.

        //private property of the class (name _instance is for clarity)
        private static ItemCatalog _instance = new ItemCatalog();

        //public property of the class
        public static ItemCatalog Instance { get => _instance; } // => lambda expression

        //ObservableCollection of Items with automatic get; set;
        public ObservableCollection<Item> ItemList { get; set; }

        //constructor that takes 0 parameters
        public ItemCatalog()
        {
            //initiates the ObservableCollection of items
            ItemList = new ObservableCollection<Item>();
            LoadItemsAsync();
        }

        
        public async void LoadItemsAsync()
        {
            var items = await PersistencyService.LoadCollectionFromJsonAsync<Item>();
            if (items.Count != 0)
            {
                foreach (var item in items)
                {
                    ItemList.Add(item);
                }
            }
            else
            {
                //adds default items to collection for testing purposes
                ItemList.Add(new Item("Bleer", 998453, "Sanitation", 10000, true, 10, "Name says it all"));
                ItemList.Add(new Item("Hansker", 994339, "Arbejdstøj", 10000, true, 12, "Name says it all"));
                ItemList.Add(new Item("Skeer", 993231, "Cutlery", 10000, true, 110, "Name says it all"));
                ItemList.Add(new Item("Arbejdsbukser", 998143, "Arbejdstøj", 10000, true, 15, "Name says it all"));
                ItemList.Add(new Item("Printer Blæk", 998888, "Printer", 10000, true, 1055, "Name says it all"));

                SaveFile();
            }
        }

        public void SaveFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Item>>(ItemList, typeof(Item));
        }
    }
}
