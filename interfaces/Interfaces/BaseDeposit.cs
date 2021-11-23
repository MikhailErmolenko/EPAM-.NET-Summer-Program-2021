using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
	public class BaseDeposit : Deposit
	{
		public BaseDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod) { }

		public override decimal Income()
		{
			decimal growingAmount = Amount;
			for (int i = 0; i < Period; i++)
			{
				growingAmount += growingAmount * 0.05m;
				Math.Round(growingAmount, 2, MidpointRounding.AwayFromZero);
			}
			return growingAmount - Amount;
		}
	}
}