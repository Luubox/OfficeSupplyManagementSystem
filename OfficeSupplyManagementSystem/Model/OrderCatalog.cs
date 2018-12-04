using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            var order =
                await PersistencyService.LoadCollectionFromJsonAsync<Order>();
            if (order.Count != 0)
            {
                foreach (var order in order)
                {
                    OrderList.Add(order);
                }

                SaveFile();
            }
            else
            {
//                OrderList.Add(new Order(514785, "Sanitation", 250, "gertsvej 12", , "Jensen"));
            }
        }

        public void SaveFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Order>>(OrderList);
        }

        public void Add(int orderNumber, string orderType, int orderTotalPrice,
            string orderDeliveryAddress, DateTime orderDate, string orderAccount)
        {
            Order newOrder = new Order(orderNumber, orderType, orderTotalPrice, orderDeliveryAddress, orderDate, orderAccount);
            OrderList.Add(newOrder);
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Order>>(OrderList);
        }
    }
}
