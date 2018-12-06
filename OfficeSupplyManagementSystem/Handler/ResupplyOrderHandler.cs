using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.ViewModel;

namespace OfficeSupplyManagementSystem.Handler
{
    class ResupplyOrderHandler
    {
        public ResupplyOrderViewModel ResupplyOrderViewModel { get; set; }

        public ResupplyOrderHandler(ResupplyOrderViewModel resupplyOrderViewModel)
        {
            ResupplyOrderViewModel = resupplyOrderViewModel;
        }

        public void CreateResupplyOrder()
        {
            ResupplyOrderViewModel.ResupplyOrderCatalog.ResupplyOrderList.Add(ResupplyOrderViewModel.NewResupplyOrder);
            ResupplyOrderViewModel.ResupplyOrderCatalog.SaveFile();
        }

        public void EditResupplyOrder()
        {
            ResupplyOrderViewModel.ResupplyOrderCatalog.ResupplyOrderList[ResupplyOrderViewModel.TargetIndex] =
                ResupplyOrderViewModel.TargetResupplyOrder;
            ResupplyOrderViewModel.ResupplyOrderCatalog.SaveFile();
        }

        public void DeleteResupplyOrder()
        {
            ResupplyOrderViewModel.ResupplyOrderCatalog.ResupplyOrderList.RemoveAt(ResupplyOrderViewModel.TargetIndex);
            ResupplyOrderViewModel.ResupplyOrderCatalog.SaveFile();
        }
    }
}
