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
    class OrderViewModel : INotifyPropertyChanged
    {
        public OrderCatalog OrderCatalog { get; set; }
        public  OrderHandler OrderHandler { get; set; }

        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand EditOrderCommand { get; set; }

        public int TargetIndex { get; set; }

        private Order _newOrder;
        public Order NewOrder
        {
            get { return _newOrder; }
            set
            {
                _newOrder = value;
                OnPropertyChanged();
            }
        }

        private Order _targetOrder;
        public Order TargetOrder
        {
            get { return _targetOrder; }
            set
            {
                _targetOrder = value;
                OnPropertyChanged();
            }
        }

        public OrderViewModel()
        {
            OrderCatalog = OrderCatalog.Instance;
            OrderHandler = new OrderHandler(this);

            CreateOrderCommand = new RelayCommand(OrderHandler.CreateOrder);
            DeleteOrderCommand = new RelayCommand(OrderHandler.DeleteOrder);
            EditOrderCommand = new RelayCommand(OrderHandler.EditOrder);

            NewOrder = new Order();
            TargetOrder = new Order();
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
