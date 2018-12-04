using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<string> _categoryList = new ObservableCollection<string>()
        {
            "Kalendere",
            "Office2Office",
            "Print",
            "Arkivering og registrering",
            "Blokke og protokoller",
            "Datatilbehør",
            "Kontorartikler",
            "Kontormaskiner",
            "Kontorpapir",
            "Konvolutter, emballage og forsendelse",
            "Mærkning og etikettering",
            "Møbler, inventar og belysning",
            "Præsentation, AV- og konference",
            "Rengørings- og hygiejneartikler",
            "Sikkerhed",
            "Skoleartikler",
            "Skriveartikler og korrektionsmidler",
            "Husholdning",
            "Kontorartikler",
            "Kolonial, service og engangsartikler",
            "Abena børnebleer",
            "Affaldssystemer",
            "Aftørringspapir",
            "Beklædning",
            "Borddækning",
            "Børnebleer",
            "Creme",
            "Cremer, sæber, desinfektion",
            "Dispenser til aftørringspapir",
            "Drikkevarer og konfekture",
            "Engangs",
            "Engangs- og cateringartikler",
            "Engsservie- og cateringartikler",
            "Fodtøj",
            "Handsker",
            "Håndrens",
            "Personlig hygiejne",
            "Plastposer og sække",
            "Reklameartikler",
            "Rengøring"
        };

        //public properties (full property)
        public string ItemName { get => _itemName; set => _itemName = value; } // => lambda expression
        public int ItemNumber { get => _itemNumber; set => _itemNumber = value; }
        public string ItemCategory { get => _itemCategory; set => _itemCategory = value; }
        public int ItemAmount { get => _itemAmount; set => _itemAmount = value; }
        public bool ItemStatus { get => _itemStatus; set => _itemStatus = value; }
        public int ItemPrice { get => _itemPrice; set => _itemPrice = value; }
        public string ItemInfo { get => _itemInfo; set => _itemInfo = value; }
        public ObservableCollection<string> CategoryList{ get => _categoryList; }

        //default or empty constructor (takes 0 parameters)
        public Item()
        {

        }

        //constructor (takes 7 parameters of varying types)
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
