using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        public int TargetIndex { get; set; }

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

        //Constructor that takes 0 parameters
        public ItemViewModel()
        {
            //Initiates the ItemCatalog by accessing the public Instance property (singleton instance)
            ItemCatalog = ItemCatalog.Instance;
            ItemHandler = new ItemHandler(this);

            CreateItemCommand = new RelayCommand(ItemHandler.CreateItem);
            DeleteItemCommand = new RelayCommand(ItemHandler.DeleteItem);
            EditItemCommand = new RelayCommand(ItemHandler.EditItem);

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
