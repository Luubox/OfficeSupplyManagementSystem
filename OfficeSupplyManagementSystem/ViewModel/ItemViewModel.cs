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
    class ItemViewModel : INotifyPropertyChanged 
    {
        public ItemCatalog ItemCatalog { get; set; }

        public ItemViewModel()
        {
            ItemCatalog = ItemCatalog.Instance;
        }

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
