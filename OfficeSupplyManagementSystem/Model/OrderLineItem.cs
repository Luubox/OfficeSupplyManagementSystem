using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class OrderLineItem
    {
        //Private fields
        private Item _orderLineItemItem = new Item();
        private int _orderLineItemAmount;
        private decimal _orderLineItemSubTotal;

        //Public properties accessing the private fields
        internal Item OrderLineItemItem { get => _orderLineItemItem; set => _orderLineItemItem = value; }
        public int OrderLineItemAmount { get => _orderLineItemAmount; set => _orderLineItemAmount = value; }

        //TODO: Finde ud af hvorfor den crasher her nogle gange, men ikke altid når OrderPage.xaml bliver initialized
        public decimal OrderLineItemSubTotal => _orderLineItemSubTotal =
            Convert.ToDecimal(OrderLineItemItem.ItemPrice) * OrderLineItemAmount;

        public OrderLineItem()
        {

        }

        /// <summary>
        /// Creates a new OrderLineItem object
        /// </summary>
        /// <param name="orderLineItemItem">The desired Item for the OrderLine</param>
        /// <param name="orderLineItemAmount">The amount of said Items</param>
        public OrderLineItem(Item orderLineItemItem, int orderLineItemAmount)
        {
            _orderLineItemItem = orderLineItemItem;
            _orderLineItemAmount = orderLineItemAmount;
        }
    }
}
