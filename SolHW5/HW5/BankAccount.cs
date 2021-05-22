using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class BankAccount
    {
        public string accountName;
        public static int accountNum = 0;
        protected double currentAmount;
        protected double limit;

        public BankAccount(string accountName, double currentAmount, double limit)
        {
            accountNum++;
            this.accountName = accountName;
            if (currentAmount < 0) 
            {
                throw new ArgumentException("Current amount cannot be negative...");
            }
            this.currentAmount = currentAmount;
            this.Limit = limit;
        }

        

        public double CurrentAmount
        {
            get => currentAmount;
        }
        public double Limit
        { 
            get => limit;
            set => limit = value;
        }

        public void Deposit(double amountToAdd)
        {
            if (amountToAdd<0)
            {
                throw new ArgumentException("Cannot add negative value");
            }
            this.currentAmount += amountToAdd;
        }
        public void Withdraw(double amountToWithraw)
        {
            if (amountToWithraw<0)
            {
                throw new ArgumentException("Cannot withraw negative value");
            }
            else if (amountToWithraw>limit+currentAmount)
            {
                throw new InvalidOperationException("Error: cannot withraw a value greater than the limit");
            }
            currentAmount -= amountToWithraw;
        }
        public string PrintAccount()
        {
            return "Account name: " + accountName + "\nAccount number: " + accountNum + "\nCurrent amount: " + currentAmount + "Limit: " + limit;
        }
    }
}
