using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Debug.WriteLine("Det virker!!!");
        }

        public void DeleteItem()
        {

        }

        public void EditItem()
        {

        }
    }
}
