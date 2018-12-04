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
    class ResupplyOrderViewModel : INotifyPropertyChanged
    {
        public ResupplyOrderCatalog ResupplyOrderCatalog { get; set; }
        public ResupplyOrderHandler ResupplyOrderHandler { get; set; }

        public ICommand CreateResupplyOrderCommand { get; set; }
        public ICommand DeleteResupplyOrderCommand { get; set; }
        public ICommand EditResupplyOrderCommand { get; set; }

        public int TargetIndex { get; set; }

        private ResupplyOrder _newResupplyOrder;

        public ResupplyOrder NewResupplyOrder
        {
            get { return _newResupplyOrder; }
            set
            {
                _newResupplyOrder = value;
                OnPropertyChanged();
            }
        }

        private ResupplyOrder _targetResupplyOrder;

        public ResupplyOrder TargetResupplyOrder
        {
            get { return _targetResupplyOrder; }
            set
            {
                _targetResupplyOrder = value;
                OnPropertyChanged();
            }
        }

        public ResupplyOrderViewModel()
        {
            ResupplyOrderCatalog = ResupplyOrderCatalog.Instance;
            ResupplyOrderHandler = new ResupplyOrderHandler(this);

            CreateResupplyOrderCommand = new RelayCommand(ResupplyOrderHandler.CreateResupplyOrder);
            DeleteResupplyOrderCommand = new RelayCommand(ResupplyOrderHandler.DeleteResupplyOrder);
            EditResupplyOrderCommand = new RelayCommand(ResupplyOrderHandler.EditResupplyOrder);

            NewResupplyOrder = new ResupplyOrder();
            TargetResupplyOrder = new ResupplyOrder();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
