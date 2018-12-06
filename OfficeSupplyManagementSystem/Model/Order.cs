using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class Order
    {
        //Private Properties
        private int _orderNumber;
        private string _orderType;
        private int _orderTotalPrice;
        private string _orderDeliveryAddress;
        private DateTime _orderDate;
        private string _orderAccount;

        //public properties (full property)
        public int OrderNumber { get => _orderNumber; set => _orderNumber = value; }
        public string OrderType { get => _orderType; set => _orderType = value; }
        public int OrderTotalPrice { get => _orderTotalPrice; set => _orderTotalPrice = value; }
        public string OrderDeliveryAddress { get => _orderDeliveryAddress; set => _orderDeliveryAddress = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public string OrderAccount { get => _orderAccount; set => _orderAccount = value; }

        //default or empty constructor that takes 0 parameters
        public Order()
        {
            
        }

        //constructor that takes 7 parameters of different types
        public Order(int orderNumber, string orderType, int orderTotalPrice, 
            string orderDeliveryAddress, DateTime orderDate, string orderAccount)
        {
            _orderNumber = orderNumber;
            _orderType = orderType;
            _orderTotalPrice = orderTotalPrice;
            _orderDeliveryAddress = orderDeliveryAddress;
            _orderDate = orderDate;
            _orderAccount = orderAccount;
        }
    }
}
