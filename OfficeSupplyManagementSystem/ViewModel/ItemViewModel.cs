using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OfficeSupplyManagementSystem.Annotations;
using OfficeSupplyManagementSystem.Model;

namespace OfficeSupplyManagementSystem.ViewModel
{
    //class implements INotifyPropertyChanged so as to allow the GUI to update based on changes
    class ItemViewModel : INotifyPropertyChanged 
    {
        //Implements ItemCatalog class
        public ItemCatalog ItemCatalog { get; set; }

        //Constructor that takes 0 parameters
        public ItemViewModel()
        {
            //Initiates the ItemCatalog by accessing the public Instance property (singleton instance)
            ItemCatalog = ItemCatalog.Instance;
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
