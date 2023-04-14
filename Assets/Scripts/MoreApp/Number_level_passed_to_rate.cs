using System;

namespace MoreApp
{
	[Serializable]
	public class Number_level_passed_to_rate
	{
		public void SetRateCondition(string s)
		{
			int.TryParse(s, out this.rate_condition);
		}

		public int rate_condition = 10;
	}
}
