using ExceptionLession.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLession.Entities
{
    internal class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new DomainException("Não é possivel adicionar um valor menor que zero");
            }
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("Withdraw error: The amount exceeds withdraw limit");
            }
            if (amount > Balance)
            {
                throw new DomainException("Withdraw error: Not enough balance");
            }

            Balance -= amount;
        }

        public override string ToString()
        {
            return $"New Balance: {Balance.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
