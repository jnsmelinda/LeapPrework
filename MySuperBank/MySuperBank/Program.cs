using System;

namespace MySuperBank
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var account = new BankAccount("Melcsi", 10000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with ${account.Balance} initial balance.");

            var account2 = new BankAccount("Joni", 1000000);
            Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with ${account2.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Hammpock");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
            // Test that the initial balances must be positive.
            BankAccount invalidAccount;
                try
                {
                    invalidAccount = new BankAccount("invalid", -55);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exception caught creating account with negative balance");
                    Console.WriteLine(e.ToString());
                }

            account.MakeWithdrawal(50, DateTime.Now, "XBox");
            Console.WriteLine(account.Balance);

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            account.MakeWithdrawal(500, DateTime.Now, "Rent");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
