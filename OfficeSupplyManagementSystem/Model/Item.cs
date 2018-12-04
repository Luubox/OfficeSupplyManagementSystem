using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class Item
    {
        //private properties
        private string _itemName;
        private int _itemNumber;
        private string _itemCategory;
        private int _itemAmount;
        private bool _itemStatus;
        private int _itemPrice;
        private string _itemInfo;

        //public properties (full property)
        public string ItemName { get => _itemName; set => _itemName = value; } // => lambda expression
        public int ItemNumber { get => _itemNumber; set => _itemNumber = value; }
        public string ItemCategory { get => _itemCategory; set => _itemCategory = value; }
        public int ItemAmount { get => _itemAmount; set => _itemAmount = value; }
        public bool ItemStatus { get => _itemStatus; set => _itemStatus = value; }
        public int ItemPrice { get => _itemPrice; set => _itemPrice = value; }
        public string ItemInfo { get => _itemInfo; set => _itemInfo = value; }

        //default or empty constructor (takes 0 parameters)
        public Item()
        {

        }

        //constructor (takes 6 parameters of varying types)
        public Item(string itemName, int itemNumber, string itemCategory, int itemAmount, bool itemStatus, int itemPrice, string itemInfo)
        {
            _itemName = itemName;
            _itemNumber = itemNumber;
            _itemCategory = itemCategory;
            _itemAmount = itemAmount;
            _itemStatus = itemStatus;
            _itemPrice = itemPrice;
            _itemInfo = itemInfo;
        }
    }
}
