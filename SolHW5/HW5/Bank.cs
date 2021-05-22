using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Bank
    {
        BankAccount[] bankAccount;
        BusinessBankAccount[] businessBankAccount;
        int numOfBA;
        int numOfBBA;

        public Bank(int size)
        {
            bankAccount = new BankAccount[size];
            businessBankAccount = new BusinessBankAccount[size];
            numOfBA = 0;
            numOfBBA = 0;
        }

        public void AddAccount(BankAccount b)
        {
            if (bankAccount.Length==numOfBA)
            {
                throw new IndexOutOfRangeException("Bank account array is full");
            }
            bankAccount[numOfBA++] = b;
        }
        public void AddAccount(BusinessBankAccount b)
        {
            if (businessBankAccount.Length==numOfBBA)
            {
                throw new IndexOutOfRangeException("Business bank account array is full");
            }
            businessBankAccount[numOfBBA++] = b;
        }
        public BankAccount getBankAccount(string name)
        {
            foreach (BankAccount b in bankAccount)
            {
                if (b.accountName==name)
                {
                    return b;
                }
            }
            throw new ArgumentException("Bank account with the provided name couldn't be found");
        }
        public BusinessBankAccount getBusinessBankAccount(string name)
        {
            foreach (BusinessBankAccount b in businessBankAccount)
            {
                if (b.accountName == name)
                {
                    return b;
                }
            }
            throw new ArgumentException("Business bank account with the provided name couldn't be found");
        }
        public void CloseBankAccount(BankAccount b)
        {
            int index = 0;
            foreach (BankAccount ba in bankAccount)
            {
                index++;
                if (b.Equals(ba) && ba.CurrentAmount == 0)
                {
                    for (int i = index - 1; i < bankAccount.Length; i++)
                    {
                        bankAccount[i] = bankAccount[i + 1];
                    }
                    return;
                }
                else if (b.Equals(ba) && ba.CurrentAmount != 0)
                {
                    throw new ArgumentException("Cannot shut an account which hasn't 0 funds");
                }
            }
            throw new ArgumentException("Bank account couldn't be found");
        }
        public void CloseBankAccount(BusinessBankAccount b)
        {
            int index = 0;
            foreach (BusinessBankAccount bba in businessBankAccount)
            {
                index++;
                if (b.Equals(bba) && bba.CurrentAmount == 0)
                {
                    for (int i = index - 1; i < businessBankAccount.Length; i++)
                    {
                        businessBankAccount[i] = businessBankAccount[i + 1];
                    }
                    return;
                }
                else if (b.Equals(bba) && bba.CurrentAmount != 0)
                {
                    throw new ArgumentException("Cannot shut an account which hasn't got 0 funds");
                }
            }
            throw new ArgumentException("Bank account couldn't be found");
        }
        public void MonthElapsed()
        {
            foreach (BusinessBankAccount bba in businessBankAccount)
            {
                bba.MonthElapsed();
            }
        }

       
    }
}
