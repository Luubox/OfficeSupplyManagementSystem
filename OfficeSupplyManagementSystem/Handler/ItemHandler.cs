using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.Model;
using OfficeSupplyManagementSystem.ViewModel;

namespace OfficeSupplyManagementSystem.Handler
{
    class ItemHandler
    {
        public ItemViewModel ItemViewModel { get; set; }

        public ItemHandler(ItemViewModel itemViewModel)
        {
            ItemViewModel = itemViewModel;
        }

        /// <summary>
        /// Creates a new Item object, adds it to the catalogue and saves to local file
        /// </summary>
        public void CreateItem()
        {
            ItemViewModel.ItemCatalog.ItemList.Add(ItemViewModel.NewItem);
            ItemViewModel.ItemCatalog.SaveFile();
        }

        /// <summary>
        /// Updates the target Item at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void DeleteItem()
        {
            ItemViewModel.ItemCatalog.ItemList.RemoveAt(ItemViewModel.TargetIndex);
            ItemViewModel.ItemCatalog.SaveFile();
        }

        /// <summary>
        /// Deletes the target Item at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void EditItem()
        {
            ItemViewModel.ItemCatalog.ItemList[ItemViewModel.TargetIndex] = ItemViewModel.TargetItem;
            ItemViewModel.ItemCatalog.SaveFile();
        }

        /// <summary>
        /// Sorts the ItemCatalog by ItemNumber
        /// </summary>
        public void SortList()
        {
            ItemViewModel.ItemCatalog.ItemList.OrderBy(x => x.ItemNumber);
        }
    }
}
