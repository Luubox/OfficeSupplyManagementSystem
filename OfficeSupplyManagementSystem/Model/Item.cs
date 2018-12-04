using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.Common;

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
        private double _itemPrice;
        private string _itemInfo;

        //public properties (full property)
        public string ItemName { get => _itemName; set => _itemName = value; } // => lambda expression

        public string ItemNumber
        {
            get
            {
                if (_itemNumber != 0) return _itemNumber.ToString();
                else return string.Empty;
            }
            set => _itemNumber = Convert.ToInt32(value);
        }
        public string ItemCategory { get => _itemCategory; set => _itemCategory = value; }

        public string ItemAmount
        {
            get
            {
                if (_itemAmount != 0) return _itemAmount.ToString();
                else return string.Empty;
            }
            set => _itemAmount = Convert.ToInt32(value);
        }
        public bool ItemStatus { get => _itemStatus; set => _itemStatus = value; }

        public string ItemPrice
        {
            get
            {
                if (_itemPrice != 0.0d) return _itemPrice.ToString();
                else return string.Empty;
            }
            set
            {
                if (value.Contains(',')) value = value.Replace(',', '.');
                _itemPrice = StringToDoubleConverter.ConvertToDouble(value);
            }
        }
        public string ItemInfo { get => _itemInfo; set => _itemInfo = value; }

        //default or empty constructor (takes 0 parameters)
        public Item()
        {

        }

        //constructor (takes 7 parameters of varying types)
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
