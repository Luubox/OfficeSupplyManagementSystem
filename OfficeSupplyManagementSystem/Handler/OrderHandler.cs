using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Handler
{
    class OrderHandler
    {
        public OrderViewModel OrderViewModel { get; set; }

        public OrderHandler(OrderViewModel orderViewModel)
        {
            OrderViewModel = orderViewModel;
        }

        public void CreateOrder()
        {
            OrderViewModel.OrderCatalog.OrderList.Add(OrderViewModel.NewOrder);
        }

        public void DeleteOrder()
        {
            OrderViewModel.OrderCatalog.OrderList.RemoveAt(OrderViewModel
                .TargetIndex);
        }
        public void EditOrder()
        {
            OrderViewModel.OrderCatalog.OrderList[OrderViewModel.TargetIndex] =
                OrderViewModel.TargetOrder;
        }
    }
}
