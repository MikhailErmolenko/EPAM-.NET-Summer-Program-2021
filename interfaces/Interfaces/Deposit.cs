using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public abstract class Deposit: IComparable<Deposit>
    {
        public int CompareTo(Deposit deposit)
        {
            if (Amount + Income() > deposit.Amount + deposit.Income())
                return 1;
            if (Amount + Income() < deposit.Amount + deposit.Income())
                return -1;
            else return 0;
        }
        public decimal Amount { get; }
        public int Period { get; }

        public Deposit(decimal depositAmount, int depositPeriod)
        {
            Amount = depositAmount;
            Period = depositPeriod;
        }

        public abstract decimal Income();
    }
}