using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public class Account
    {
        public decimal Balance { get; set; }
        public string Name { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public void AccountSummary()
        {
            Console.WriteLine("Account: {0}", Name);
            Console.WriteLine("Banlance: {0}", Balance);
        }
    }

    public class CheckingAccount: Account
    {
        public CheckingAccount()
        {
            base.Name = "Checking Account";
        }
        
        public void Credit(decimal amount)
        {
            // Check credentials

            Balance -= amount;
        }

    }

    public class SavingAccount : Account
    {
        private const decimal MinimumBalance = 50;

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount >= MinimumBalance)
                Balance -= amount;
            else
                Console.WriteLine("Insuficient fund");
        }

        public SavingAccount()
        {
            base.Name = "Saving Account";
        }

    }
}
