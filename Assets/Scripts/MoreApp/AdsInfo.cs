using System;

namespace MoreApp
{
	[Serializable]
	public class AdsInfo
	{
		public AdsInfo()
		{
			this.smart_more_app = new Smart_more_app();
		}

		public Number_level_passed_to_rate number_level_passed_to_rate;

		public Smart_more_app smart_more_app;

		public AdsItemType2 more_app;
	}
}
