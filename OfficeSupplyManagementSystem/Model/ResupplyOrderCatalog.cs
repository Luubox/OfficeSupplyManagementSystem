using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.Persistency;

namespace OfficeSupplyManagementSystem.Model
{
    class ResupplyOrderCatalog
    {
        private static ResupplyOrderCatalog _instance = new ResupplyOrderCatalog();

        public static ResupplyOrderCatalog Instance { get => _instance; }

        public ObservableCollection<ResupplyOrder> ResupplyOrderList { get; set; }

        public ResupplyOrderCatalog()
        {
            ResupplyOrderList = new ObservableCollection<ResupplyOrder>();
            LoadResupplyOrdersAsync();
        }

        public async void LoadResupplyOrdersAsync()
        {
            var resupplyOrders = await PersistencyService.LoadCollectionFromJsonAsync<ResupplyOrder>();
            if (resupplyOrders.Count != 0)
            {
                foreach (var resupplyOrder in resupplyOrders)
                {
                    ResupplyOrderList.Add(resupplyOrder);
                }
                SaveFile();
            }
            else
            {
            }
        }

        public void SaveFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<ResupplyOrder>>(ResupplyOrderList);
        }

        public void Add(int resupplyOrderNumber, string resupplyOrderSupplier, DateTime resupplyOrderDate,
            int resupplyOrderAmount)
        {
            ResupplyOrder newResupplyOrder = new ResupplyOrder(resupplyOrderNumber, resupplyOrderSupplier, resupplyOrderDate, resupplyOrderAmount);
            ResupplyOrderList.Add(newResupplyOrder);
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<ResupplyOrder>>(ResupplyOrderList);
        }
    }
}
