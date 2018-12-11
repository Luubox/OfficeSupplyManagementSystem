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
        //Private Properties
        private string _orderNumber;
        private string _orderAccount;
        private DateTime _orderDate;
        private string _orderDeliveryAddress;
        private bool _orderType;
        private ObservableCollection<OrderLineItem> _orderLineItemList = new ObservableCollection<OrderLineItem>();
        private decimal _orderTotalPrice;
        private bool _orderStatus;

        public string OrderNumber
        {
            get
            {
                _orderNumber = "999-";
                _orderNumber += _orderType ? "01-" : "00-";
                //_orderNumber += OrderCatalog.Instance.OrderList.Count;
                _orderNumber += _orderLineItemList.Count;
                return _orderNumber;
            }
        }
        public string OrderAccount { get => _orderAccount; set => _orderAccount = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public string OrderDeliveryAddress { get => _orderDeliveryAddress; set => _orderDeliveryAddress = value; }
        public bool OrderType { get => _orderType; set => _orderType = value; }
        public ObservableCollection<OrderLineItem> OrderLineItemList { get => _orderLineItemList; set => _orderLineItemList = value; }
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
        public bool OrderStatus { get => _orderStatus; set => _orderStatus = value; }

        public Order(){}

        public Order(string orderAccount, DateTime orderDate, string orderDeliveryAddress, bool orderType, ObservableCollection<OrderLineItem> orderLineItemList)
        {
            _orderAccount = orderAccount;
            _orderDate = orderDate;
            _orderDeliveryAddress = orderDeliveryAddress;
            _orderType = orderType;

            foreach (var item in orderLineItemList)
            {
                _orderLineItemList.Add(item);
            }
        }
    }
}
