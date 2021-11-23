namespace Aggregation
{
    public class LongDeposit: Deposit
	{
        public LongDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod) { }

		public override decimal Income()
		{
			decimal growingAmount = Amount;
			for (int i = 0; i < Period-6; i++)
			{
				growingAmount += growingAmount * 0.15m;
				System.Math.Round(growingAmount, 2, System.MidpointRounding.AwayFromZero);
			}
			return growingAmount - Amount;
		}
	}
}