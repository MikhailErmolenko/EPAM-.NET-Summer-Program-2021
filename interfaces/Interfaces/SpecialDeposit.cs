using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
	public class SpecialDeposit : Deposit, IProlongable
	{
		public SpecialDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod) { }

		public override decimal Income()
		{
			decimal growingAmount = Amount;
			for (int i = 1; i <= Period; i++)
			{
				growingAmount += growingAmount * i / 100;
				Math.Round(growingAmount, 2, MidpointRounding.AwayFromZero);
			}
			return growingAmount - Amount;
		}
		public bool CanToProlong()
		{
			if (Amount > 1000)
				return true;
			else return false;
		}
	}
}
