using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class ResupplyOrder
    {
        //Private properties for class
        private int _resupplyOrderNumber;
        private string _resupplyOrderSupplier;
        private DateTime _resupplyOrderDate;
        private DateTime _resupplyOrderExpectedDeliveryDate;
        private int _resupplyOrderAmount;
        private bool _resupplyOrderStatus;

        //Public properties for class
        public int ResupplyOrderNumber
        {
            get => _resupplyOrderNumber;
            set => _resupplyOrderNumber = value;
        }

        public string ResupplyOrderSupplier
        {
            get => _resupplyOrderSupplier;
            set => _resupplyOrderSupplier = value;
        }

        public DateTime ResupplyOrderDate
        {
            get => _resupplyOrderDate;
            set => _resupplyOrderDate = value;
        }

        public int ResupplyOrderAmount
        {
            get => _resupplyOrderAmount;
            set => _resupplyOrderAmount = value;
        }
        public bool ResupplyOrderStatus
        {
            get => _resupplyOrderStatus;
            set => _resupplyOrderStatus = value;
        }

        public DateTime ResupplyOrderExpectedDeliveryDate
        {
            get => _resupplyOrderExpectedDeliveryDate;
            set => _resupplyOrderExpectedDeliveryDate = value;
        }

        //Empty constructor
        public ResupplyOrder()
        {

        }

        //Constructor with the parameters
        public ResupplyOrder(int resupplyOrderNumber, string resupplyOrderSupplier, DateTime resupplyOrderDate,
            int resupplyOrderAmount, DateTime resupplyOrderExpectedDeliveryDate, bool resupplyOrderStatus)
        {
            _resupplyOrderNumber = resupplyOrderNumber;
            _resupplyOrderSupplier = resupplyOrderSupplier;
            _resupplyOrderDate = resupplyOrderDate;
            _resupplyOrderAmount = resupplyOrderAmount;
            _resupplyOrderExpectedDeliveryDate = resupplyOrderExpectedDeliveryDate;
            _resupplyOrderStatus = resupplyOrderStatus;
        }
    }
}
