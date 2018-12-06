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
        private int _resupplyOrderAmount;

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

        //Empty constructor
        public ResupplyOrder()
        {

        }

        //Constructor with the parameters
        public ResupplyOrder(int resupplyOrderNumber, string resupplyOrderSupplier, DateTime resupplyOrderDate,
            int resupplyOrderAmount)
        {
            _resupplyOrderNumber = resupplyOrderNumber;
            _resupplyOrderSupplier = resupplyOrderSupplier;
            _resupplyOrderDate = resupplyOrderDate;
            _resupplyOrderAmount = resupplyOrderAmount;
        }
    }
}
