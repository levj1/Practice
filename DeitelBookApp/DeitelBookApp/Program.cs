using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person john = new Person("John");
            Account boaChecking = new CheckingAccount();
            boaChecking.Deposit(12.9M);
            boaChecking.Deposit(2021.9M);
            boaChecking.Withdraw(1300.9M);

            Account boaSaving = new SavingAccount();
            boaSaving.Deposit(75);
            boaSaving.Withdraw(30);

            // Summary
            boaChecking.AccountSummary();
            boaSaving.AccountSummary();

            Console.ReadLine();
        }
    }
}
