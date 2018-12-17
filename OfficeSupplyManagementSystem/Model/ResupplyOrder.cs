using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //List of suppliers, to be picked from drop-down menu for CREATING and EDITING
        private ObservableCollection<string> _categorySupplierList = new ObservableCollection<string>()
        {
            "T-Hansen",
            "Ikea",
            "Hjem og Fix",
            "XL-Byg",
            "Bog og ide",
            "Wallmart",
            "MegaStore",
            "Matas"
        };

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

        public ObservableCollection<string> CategorySupplierList { get => _categorySupplierList; }

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
