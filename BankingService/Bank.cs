using System;
using System.Collections.Generic;

namespace BankingService
{
    public class Bank
    {
        public List<Account> Accounts { get; set; }
        public Bank(){
            Accounts = new List<Account>();
        }
        public void AddAccount(string id, string first, string last){
            var account = new Account(id, first, last);
            Accounts.Add(account);
        }
    }
}
