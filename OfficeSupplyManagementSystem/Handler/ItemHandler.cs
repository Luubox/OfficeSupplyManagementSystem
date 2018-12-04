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

        public void CreateItem()
        {
            ItemViewModel.ItemCatalog.ItemList.Add(ItemViewModel.NewItem);
        }

        public void DeleteItem()
        {
            ItemViewModel.ItemCatalog.ItemList.RemoveAt(ItemViewModel.TargetIndex);
            // TODO Opret nyt Arkiv-katalog
        }

        public void EditItem()
        {
            //ItemViewModel.ItemCatalog.ItemList.Insert(ItemViewModel.TargetIndex, ItemViewModel.TargetItem);
            ItemViewModel.ItemCatalog.ItemList[ItemViewModel.TargetIndex] = ItemViewModel.TargetItem;
        }

        public void SortItem()
        {
        }
    }
}
