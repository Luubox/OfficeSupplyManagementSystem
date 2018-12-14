using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.Common;

namespace OfficeSupplyManagementSystem.Model
{
    class Item
    {
        //Private fields
        private string _itemName;
        private int _itemNumber;
        private string _itemCategory;
        private int _itemAmount;
        private bool _itemStatus;
        private decimal _itemPrice;
        private string _itemInfo;


        #region Legacy CategoryList

        //A list of string values used as categories for the Item objects
        //private ObservableCollection<string> _categoryList = new ObservableCollection<string>()
        //{
        //    "Kalendere",
        //    "Office2Office",
        //    "Print",
        //    "Arkivering og registrering",
        //    "Blokke og protokoller",
        //    "Datatilbehør",
        //    "Kontorartikler",
        //    "Kontormaskiner",
        //    "Kontorpapir",
        //    "Konvolutter, emballage og forsendelse",
        //    "Mærkning og etikettering",
        //    "Møbler, inventar og belysning",
        //    "Præsentation, AV- og konference",
        //    "Rengørings- og hygiejneartikler",
        //    "Sikkerhed",
        //    "Skoleartikler",
        //    "Skriveartikler og korrektionsmidler",
        //    "Husholdning",
        //    "Kontorartikler",
        //    "Kolonial, service og engangsartikler",
        //    "Abena børnebleer",
        //    "Affaldssystemer",
        //    "Aftørringspapir",
        //    "Beklædning",
        //    "Borddækning",
        //    "Børnebleer",
        //    "Creme",
        //    "Cremer, sæber, desinfektion",
        //    "Dispenser til aftørringspapir",
        //    "Drikkevarer og konfekture",
        //    "Engangs",
        //    "Engangs- og cateringartikler",
        //    "Engsservie- og cateringartikler",
        //    "Fodtøj",
        //    "Handsker",
        //    "Håndrens",
        //    "Personlig hygiejne",
        //    "Plastposer og sække",
        //    "Reklameartikler",
        //    "Rengøring"
        //};

        #endregion

        //Public properties accessing the private fields
        public string ItemName { get => _itemName; set => _itemName = value; } // => lambda expression
        public string ItemNumber
        {
            get
            {
                //Returns an empty string if the itemNumber is 0,
                //When creating a new object this means that the input fields in the xaml code is empty,
                //and as such shows the placeholder text.
                if (_itemNumber != 0) return _itemNumber.ToString();
                else return string.Empty;
            }
            //Converts the input string to a int, so that it lines up with the private field
            set => _itemNumber = Convert.ToInt32(value);
        }
        public string ItemCategory { get => _itemCategory; set => _itemCategory = value; }
        public string ItemAmount
        {
            get
            {
                //Again returns an empty string if 0, to facilitate the xaml view
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
                //Returns a string formatted with two decimals and whatever the value is infront of the decimal point
                //or an empty string if the field has no value, to facilitate the xaml view
                if (_itemPrice != 0) return _itemPrice.ToString("#.00");
                else return string.Empty;
            }
            set
            {
                //Checks whether the input string contains a comma, and replaces it with a period.
                //This is to prevent culture input issues with the underlying code.
                if (value.Contains(',')) value = value.Replace(',', '.');
                //Sets the backing field to the string value converted to a decimal with two decimal points
                _itemPrice = decimal.Round(Convert.ToDecimal(value), 2, MidpointRounding.AwayFromZero);
            }
        }
        public string ItemInfo { get => _itemInfo; set => _itemInfo = value; }
        //public ObservableCollection<string> CategoryList { get => _categoryList; }

        //default or empty constructor (takes 0 parameters)
        public Item()
        {

        }

        //constructor (takes a parameter for each backing field in the class definition)
        public Item(string itemName, int itemNumber, string itemCategory, int itemAmount, bool itemStatus,
            int itemPrice, string itemInfo)
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
