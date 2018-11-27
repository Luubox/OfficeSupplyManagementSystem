using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class ItemCatalog
    {
        private static ItemCatalog _instance = new ItemCatalog();

        public static ItemCatalog Instance { get => _instance; }

        public ObservableCollection<Item> ItemList { get; set; }

        public ItemCatalog()
        {
            ItemList = new ObservableCollection<Item>();
        }

        public void Add(string itemName, int itemNumber, string itemCategory, int itemAmount, bool itemStatus, int itemPrice, string itemInfo)
        {
            ItemList.Add(new Item(itemName, itemNumber, itemCategory, itemAmount, itemStatus, itemPrice, itemInfo));
        }
    }
}
