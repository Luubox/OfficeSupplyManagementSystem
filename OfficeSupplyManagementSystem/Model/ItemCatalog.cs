﻿using System;
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

        /// <summary>
        /// johan != vores mand
        /// </summary>
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
                Add(new Item("Bleer", 01, "Sanitation", 10000, true, 10, "Name says it all"));
                //Add(new Item("Hansker", 02, "Arbejdstøj", 10000, true, 12, "Name says it all"));
                //Add(new Item("Skeer", 03, "Cutlery", 10000, true, 110, "Name says it all"));
                //Add(new Item("Arbejdsbukser", 04, "Arbejdstøj", 10000, true, 15, "Name says it all"));
                //Add(new Item("Printer Blæk", 05, "Printer", 10000, true, 1055, "Name says it all"));
            }
        }

        public void Add(Item newItem)
        {
            ItemList.Add(newItem);
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Item>>(ItemList);
        }
        //Add method that corresponds to the item class constructor (names dont have to match, only for clarity) 
        public void Add(string itemName, int itemNumber, string itemCategory, int itemAmount, bool itemStatus, int itemPrice, string itemInfo)
        {
            Item newItem = new Item(itemName, itemNumber, itemCategory, itemAmount, itemStatus, itemPrice, itemInfo);
            ItemList.Add(newItem);
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Item>>(ItemList);
        }
    }
}
