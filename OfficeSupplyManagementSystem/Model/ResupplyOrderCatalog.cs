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
            }
            else
            {
                ResupplyOrderList.Add(new ResupplyOrder(452, "Hjem og fix", DateTime.Today, 244, DateTime.Today, true));
                ResupplyOrderList.Add(new ResupplyOrder(453, "T-Hansen", DateTime.Today, 291, DateTime.Today, true));
                ResupplyOrderList.Add(new ResupplyOrder(454, "Ikea", DateTime.Today, 482, DateTime.Today, true));
                ResupplyOrderList.Add(new ResupplyOrder(455, "Wallmart", DateTime.Today, 285, DateTime.Today, true));
            }
        }

        public void SaveFile()
        {
            PersistencyService.SaveCollectionAsJsonAsync<ObservableCollection<ResupplyOrder>>(ResupplyOrderList, typeof(ResupplyOrder));
        }
    }
}
