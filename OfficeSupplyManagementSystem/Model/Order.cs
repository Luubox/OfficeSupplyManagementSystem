using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class Order
    {
        private int _orderNumber;
        private string _orderType;
        private decimal _orderTotalPrice;
        private string _orderDeliveryAddress;
        private DateTime _orderDate;
        private string _orderAccount;
        private string _orderStatus;
        private ObservableCollection<OrderLineItem> _orderLineItemList;

        public int OrderNumber { get => _orderNumber; set => _orderNumber = value; }
        public string OrderType { get => _orderType; set => _orderType = value; }
        public decimal OrderTotalPrice
        {
            get
            {
                foreach (OrderLineItem item in OrderLineItemList)
                {
                    _orderTotalPrice += item.OrderLineItemSubTotal;
                }
                return _orderTotalPrice;
            }
        }
        public string OrderDeliveryAddress { get => _orderDeliveryAddress; set => _orderDeliveryAddress = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public string OrderAccount { get => _orderAccount; set => _orderAccount = value; }
        public string OrderStatus { get => _orderStatus; set => _orderStatus = value; }

        public ObservableCollection<OrderLineItem> OrderLineItemList
        {
            get { return _orderLineItemList; }
            set { _orderLineItemList = value; }
        }

        public Order()
        {
            
        }

        public Order(int orderNumber, string orderType, string orderDeliveryAddress, DateTime orderDate, string orderAccount, string orderStatus, ObservableCollection<OrderLineItem> orderLineItemList)
        {
            _orderNumber = orderNumber;
            _orderType = orderType;
            _orderDeliveryAddress = orderDeliveryAddress;
            _orderDate = orderDate;
            _orderAccount = orderAccount;
            _orderStatus = orderStatus;
            _orderLineItemList = orderLineItemList;
        }
    }
}
