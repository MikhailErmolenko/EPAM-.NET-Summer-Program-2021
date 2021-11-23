using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class Client: IEnumerable<Deposit>
    {
        private Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            bool success = false;
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    success = true;
                    break;
                }
            }
            return success;
        }
        public decimal TotalIncome()
        {
            decimal totalIncome = 0;
            foreach (var deposit in deposits)
            {
                if (deposit != null)
                {
                    totalIncome += deposit.Income();
                }
                else break;
            }
            return totalIncome;
        }
        public decimal MaxIncome()
        {
            decimal maxIncome = 0;
            foreach (var deposit in deposits)
            {
                if (deposit != null)
                {
                    if (deposit.Income() > maxIncome)
                        maxIncome = deposit.Income();
                }
                else break;
            }
            return maxIncome;
        }
        public decimal GetIncomeByNumber(int index)
        {
            if (deposits[index - 1] != null)
                return deposits[index - 1].Income();
            else return 0;
        }
        public void SortDeposits()
		{
            Array.Sort(deposits);
            Array.Reverse(deposits);
		}
		public int CountPossibleToProlongDeposit()
		{
			int index = 0;
            foreach (var deposit in deposits)
			{
                if (deposit is IProlongable prolongable && prolongable.CanToProlong())
                    index++;
			}
			return index;
		}

		public IEnumerator<Deposit> GetEnumerator()
		{
			return ((IEnumerable<Deposit>)deposits).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return deposits.GetEnumerator();
		}
	}
}
