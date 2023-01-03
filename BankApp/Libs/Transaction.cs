using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankApp.Libs
{
    public static class Transaction
    {
        public static void WriteTransaction(Client client, Bill bill, TypesOfTransaction type, float amount, DateTime dateTime)
        {
            StreamWriter strmWriter = new StreamWriter("../../../Data/Transactions.txt");
            strmWriter.WriteLine($"{client.Login}\n{bill.Number}\n{type}\n{amount}\n{dateTime}");
            strmWriter.Close();
        }

        public static string[,] ReadTransactionsByClient(Client client)
        {
            string[,] transactions = new string[4, 100];
            StreamReader strmReader = new StreamReader("../../../Data/Transactions.txt");
            byte counter = 0;
            while (!strmReader.EndOfStream && counter != 100)
            {
                if (strmReader.ReadLine() == client.Login)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        transactions[i, counter] = strmReader.ReadLine();
                    }
                    counter++;
                }
            }
            return transactions;
        }
    }
    public enum TypesOfTransaction
    {
        Refill,
        Transfer,
        TransferBetweenAccounts,
        Withdrawal
    }
}
