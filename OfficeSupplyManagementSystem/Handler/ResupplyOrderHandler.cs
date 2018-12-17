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

        /// <summary>
        /// Creates a new ResupplyOrder object, adds it to the catalogue and saves to local file
        /// </summary>
        public void CreateResupplyOrder()
        {
            ResupplyOrderViewModel.ResupplyOrderCatalog.ResupplyOrderList.Add(ResupplyOrderViewModel.NewResupplyOrder);
            ResupplyOrderViewModel.ResupplyOrderCatalog.SaveFile();
        }

        /// <summary>
        /// Updates the target ResupplyOrder at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void EditResupplyOrder()
        {
            ResupplyOrderViewModel.ResupplyOrderCatalog.ResupplyOrderList.Insert(ResupplyOrderViewModel.TargetIndex, 
                ResupplyOrderViewModel.TargetResupplyOrder);
            ResupplyOrderViewModel.ResupplyOrderCatalog.ResupplyOrderList.RemoveAt(ResupplyOrderViewModel.TargetIndex);
            ResupplyOrderViewModel.ResupplyOrderCatalog.SaveFile();
        }

        /// <summary>
        /// Deletes the target ResupplyOrder at TargetIndex in the catalogue and saves to local file
        /// </summary>
        public void DeleteResupplyOrder()
        {
            ResupplyOrderViewModel.ResupplyOrderCatalog.ResupplyOrderList.RemoveAt(ResupplyOrderViewModel.TargetIndex);
            ResupplyOrderViewModel.ResupplyOrderCatalog.SaveFile();
        }
    }
}
