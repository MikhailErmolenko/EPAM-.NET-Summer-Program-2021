namespace Aggregation
{
    public class SpecialDeposit: Deposit
	{
        public SpecialDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod) { }

		public override decimal Income()
		{
			decimal growingAmount = Amount;
			for (int i = 1; i <= Period; i++)
			{
				growingAmount += growingAmount * i/100;
				System.Math.Round(growingAmount, 2, System.MidpointRounding.AwayFromZero);
			}
			return growingAmount - Amount;
		}
	}
}