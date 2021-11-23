namespace Aggregation
{
    public class BaseDeposit: Deposit
	{
        public BaseDeposit(decimal depositAmount, int depositPeriod) : base(depositAmount, depositPeriod) {}

		public override decimal Income()
		{
			decimal growingAmount = Amount;
            for (int i=0; i<Period; i++)
			{
				growingAmount += growingAmount*0.05m;
				System.Math.Round(growingAmount, 2, System.MidpointRounding.AwayFromZero);
			}
			return growingAmount - Amount;
		}
	}
}