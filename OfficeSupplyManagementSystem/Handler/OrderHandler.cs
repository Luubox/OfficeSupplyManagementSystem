using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.ViewModel;

namespace OfficeSupplyManagementSystem.Handler
{
    class OrderHandler
    {
        public OrderViewModel OrderViewModel { get; set; }

        public OrderHandler(OrderViewModel orderViewModel)
        {
            OrderViewModel = orderViewModel;
        }

        /// <summary>
        /// Creates a new Order object, adds it to the catalogue and saves to local file
        /// </summary>
        public void CreateOrder()
        {
            OrderViewModel.OrderCatalog.OrderList.Add(OrderViewModel.NewOrder);
            OrderViewModel.OrderCatalog.SaveFile();
        }

        /// <summary>
        /// Updates the target Order at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void DeleteOrder()
        {
            OrderViewModel.OrderCatalog.OrderList.RemoveAt(OrderViewModel
                .TargetIndex);
            OrderViewModel.OrderCatalog.SaveFile();
        }

        /// <summary>
        /// Deletes the target Order at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void EditOrder()
        {
            OrderViewModel.OrderCatalog.OrderList.Insert(OrderViewModel.TargetIndex, OrderViewModel.TargetOrder);
            OrderViewModel.OrderCatalog.OrderList.RemoveAt(OrderViewModel.TargetIndex);
            OrderViewModel.OrderCatalog.SaveFile();
        }
    }
}
