using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OfficeSupplyManagementSystem.Annotations;
using OfficeSupplyManagementSystem.Handler;
using OfficeSupplyManagementSystem.Model;

namespace OfficeSupplyManagementSystem.ViewModel
{
    //class implements INotifyPropertyChanged so as to allow the GUI to update based on changes
    class ItemViewModel : INotifyPropertyChanged
    {
        //Implements ItemCatalog class
        public ItemCatalog ItemCatalog { get; set; }
        public ItemHandler ItemHandler { get; set; }

        public ICommand CreateItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand EditItemCommand { get; set; }
        public ICommand SortItemCommand { get; set; }
        public ICommand SaveItemListCommand { get; set; }

        private int _targetIndex;
        public int TargetIndex
        {
            get { return _targetIndex; }
            set
            {
                _targetIndex = value;
                Debug.WriteLine(_targetIndex);
            }
        }

        private Item _newItem;
        public Item NewItem
        {
            get { return _newItem; }
            set
            {
                _newItem = value;
                OnPropertyChanged();
            }
        }

        private Item _targetItem;

        public Item TargetItem
        {
            get { return _targetItem; }
            set
            {
                _targetItem = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<string> _categoryListtest = new ObservableCollection<string>()
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
        public ObservableCollection<string> CategoryListtest
        {
            get { return _categoryListtest; }
            set
            {
                _categoryListtest = value; 
                OnPropertyChanged();
            }
        }


        //Constructor that takes 0 parameters
        public ItemViewModel()
        {
            //Initiates the ItemCatalog by accessing the public Instance property (singleton instance)
            ItemCatalog = ItemCatalog.Instance;
            ItemHandler = new ItemHandler(this);

            CreateItemCommand = new RelayCommand(ItemHandler.CreateItem);
            DeleteItemCommand = new RelayCommand(ItemHandler.DeleteItem);
            EditItemCommand = new RelayCommand(ItemHandler.EditItem);
            SortItemCommand = new RelayCommand(ItemHandler.SortList);
            SaveItemListCommand = new RelayCommand(ItemCatalog.SaveFile);

            NewItem = new Item();
            TargetItem = new Item();
        }

        //default implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
