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
            ItemList.Add(new Item("Bleer", 01, "Sanitation", 10000, true, 10, "Name says it all"));
            ItemList.Add(new Item("Hansker", 02, "Arbejdstøj", 10000, true, 12, "Name says it all"));
            ItemList.Add(new Item("Skeer", 03, "Cutlery", 10000, true, 110, "Name says it all"));
            ItemList.Add(new Item("Arbejdsbukser", 04, "Arbejdstøj", 10000, true, 15, "Name says it all"));
            ItemList.Add(new Item("Printer Blæk", 05, "Printer", 10000, true, 1055, "Name says it all"));

        }

        public void Add(string itemName, int itemNumber, string itemCategory, int itemAmount, bool itemStatus, int itemPrice, string itemInfo)
        {
            ItemList.Add(new Item(itemName, itemNumber, itemCategory, itemAmount, itemStatus, itemPrice, itemInfo));
        }
    }
}
