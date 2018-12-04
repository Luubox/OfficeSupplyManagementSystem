﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSupplyManagementSystem.Model
{
    class Account
    {
        //private properties
        private string _accountNumber;
        private int _accountCvr;
        private string _accountDeliveryAddress;
        private int _accountContact;
        private string _accountBankingInfo;
        private bool _accountStatus;

        //public properties (full properties)
        public string Number { get => _accountNumber; set => _accountNumber = value; } // => lampda expressions
        public int Cvr { get => _accountCvr; set => _accountCvr = value; }
        public string DeliveryAddress { get => _accountDeliveryAddress; set => _accountDeliveryAddress = value; }
        public int Contact { get => _accountContact; set => _accountContact = value; }
        public string BankingInfo { get => _accountBankingInfo; set => _accountBankingInfo = value; }
        public bool Status { get => _accountStatus; set => _accountStatus = value; }

        //default or empty contructor (takes 0 parameters)
        public Account()
        {

        }

        //constructor (takes 7 parameters of varying types)
        public Account(string accountNumber, int accountCvr, string accountDeliveryAddress, int acccountContact, string accountBankingInfo, bool accountStatus)
        {
            _accountNumber = accountNumber;
            _accountCvr = accountCvr;
            _accountDeliveryAddress = accountDeliveryAddress;
            _accountContact = acccountContact;
            _accountBankingInfo = accountBankingInfo;
            _accountStatus = accountStatus;
        }
    }
}