using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class Account
    {
        //private fields
        private string _accountNumber;
        private string _accountName;
        private int _accountCvr;
        private string _accountDeliveryAddress;
        private int _accountContact;
        private string _accountBankingInfo;
        private bool _accountStatus;
        private decimal _accountRevenue;

        //public properties accessing the private fields
        public string AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public string AccountName { get => _accountName; set => _accountName = value; }

        public string AccountCvr
        {
            get
            {
                if (_accountCvr != 0) return _accountCvr.ToString();
                else return string.Empty;
            }
            set => _accountCvr = Convert.ToInt32(value);
        }
        public string AccountDeliveryAddress { get => _accountDeliveryAddress; set => _accountDeliveryAddress = value; }
        public int AccountContact { get => _accountContact; set => _accountContact = value; }
        public string AccountBankingInfo { get => _accountBankingInfo; set => _accountBankingInfo = value; }

        public string AccountStatus
        {
            get { return _accountStatus.ToString(); }
            set
            {
                switch (value.ToLower())
                {
                    case "true":
                        _accountStatus = true;
                        break;
                    case "false":
                        _accountStatus = false;
                        break;
                    default:
                        _accountStatus = true;
                        break;
                }
            }
        }

        public decimal AccountRevenue { get => _accountRevenue; set => _accountRevenue = value; }

        public Account()
        {

        }

        public Account(string accountNumber, string accountName, int accountCvr, string accountDeliveryAddress, int accountContact, string accountBankingInfo, string accountStatus, decimal accountRevenue)
        {
            _accountNumber = accountNumber;
            _accountName = accountName;
            _accountCvr = accountCvr;
            _accountDeliveryAddress = accountDeliveryAddress;
            _accountContact = accountContact;
            _accountBankingInfo = accountBankingInfo;
            AccountStatus = accountStatus;
            _accountRevenue = accountRevenue;
        }
    }
}
