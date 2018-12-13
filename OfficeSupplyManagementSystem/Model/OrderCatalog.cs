using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.Persistency;

namespace OfficeSupplyManagementSystem.Model
{
    class OrderCatalog
    {
        private static OrderCatalog _instance = new OrderCatalog();

        public static OrderCatalog Instance { get => _instance; }

        public ObservableCollection<Order> OrderList { get; set; }

        public OrderCatalog()
        {
            OrderList = new ObservableCollection<Order>();
            LoadOrderAsync();
        }

        public async void LoadOrderAsync()
        {
            var orders =
                await PersistencyService.LoadCollectionFromJsonAsync<Order>();
            if (orders.Count != 0)
            {
                foreach (var order in orders)
                {
                    OrderList.Add(order);
                }
            }
            else
            {
                OrderList.Add(new Order("bjarne bjarnesen",DateTime.Now, "bjarnevej 123, 1234 bjarnby",true ,
                    new ObservableCollection<OrderLineItem>()
                    {
                        new OrderLineItem(ItemCatalog.Instance.ItemList[0], 20),
                        new OrderLineItem(ItemCatalog.Instance.ItemList[1], 40),
                        new OrderLineItem(ItemCatalog.Instance.ItemList[2], 60)
                    }));

                SaveFile();
            }
        }

        /// <summary>
        /// Saves the collection to local folder using the SaveCollectionAsJsonAsync in the PersistencyService class,
        /// </summary>
        public void SaveFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Order>>(OrderList);
        }
    }
}
