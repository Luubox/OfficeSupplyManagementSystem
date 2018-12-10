using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class OrderLineItem
    {
        private Item _orderLineItemItem;
        private int _orderLineItemAmount;
        private decimal _orderLineItemSubTotal;

        internal Item OrderLineItemItem { get => _orderLineItemItem; set => _orderLineItemItem = value; }
        public int OrderLineItemAmount { get => _orderLineItemAmount; set => _orderLineItemAmount = value; }

        public decimal OrderLineItemSubTotal
        {
            get
            {
                _orderLineItemSubTotal =
                    Convert.ToDecimal(OrderLineItemItem.ItemPrice) *
                    OrderLineItemAmount;
                return _orderLineItemSubTotal;
            }
        }

        public OrderLineItem()
        {
            
        }

        public OrderLineItem(Item orderLineItemItem, int orderLineItemAmount)
        {
            _orderLineItemItem = orderLineItemItem;
            _orderLineItemAmount = orderLineItemAmount;
        } 
    }
}
