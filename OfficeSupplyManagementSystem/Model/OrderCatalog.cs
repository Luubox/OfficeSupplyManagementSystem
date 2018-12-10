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

        //collection class that follows the Singleton pattern, meaning there can be only one instance

        //private property of the class, named _instance for clarity 
        private static OrderCatalog _instance = new OrderCatalog();

        //public property of the class
        public static OrderCatalog Instance { get => _instance; } // => lambda expression

        //ObervableCollection of Orders with automatic get; set;
        public ObservableCollection<Order> OrderList { get; set; }

        //constructor that take 0 parameters
        public OrderCatalog()
        {
            //initiates the ObservableCollection of items
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
                //TODO add default orders to the collection for testing purposes
                //OrderList.Add(new Order(514785, "Sanitation", 250, "gertsvej 12", new DateTime(), "Jensen", "Test Status"));
                OrderList.Add(new Order(514785, "Sanitation", "Testvej", DateTime.Now, "testaccount", "testStatus",
                    new ObservableCollection<OrderLineItem>()
                    {
                        new OrderLineItem(ItemCatalog.Instance.ItemList[0], 20),
                        new OrderLineItem(ItemCatalog.Instance.ItemList[1], 40),
                        new OrderLineItem(ItemCatalog.Instance.ItemList[2], 60)
                    }));

                SaveFile();
            }
        }

        public void SaveFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<Order>>(OrderList);
        }
    }
}
