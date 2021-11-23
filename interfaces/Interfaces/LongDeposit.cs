using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
	public class LongDeposit : Deposit, IProlongable
	{
		public LongDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod) { }

		public override decimal Income()
		{
			decimal growingAmount = Amount;
			for (int i = 0; i < Period - 6; i++)
			{
				growingAmount += growingAmount * 0.15m;
				Math.Round(growingAmount, 2, MidpointRounding.AwayFromZero);
			}
			return growingAmount - Amount;
		}
		public bool CanToProlong()
		{
			if (Period <= 36)
				return true;
			else return false;
		}
	}
}