using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using UnityEngine;

namespace MoreApp
{
	public class Parse
	{
		public Parse(string jsondata)
		{
			this.JsonData = jsondata;
		}

		public AdsInfo GetAdsInfo()
		{
			AdsInfo adsInfo = new AdsInfo();
			try
			{
				Dictionary<string, object> dictionary = Json.Deserialize(this.JsonData) as Dictionary<string, object>;
				if (dictionary.ContainsKey("number_level_passed_to_rate"))
				{
					Dictionary<string, object> d = dictionary["number_level_passed_to_rate"] as Dictionary<string, object>;
					adsInfo.number_level_passed_to_rate = this.getNumber_level_passed_to_rate(d);
				}
				if (dictionary.ContainsKey("smart_more_app"))
				{
					Dictionary<string, object> dictionary2 = dictionary["smart_more_app"] as Dictionary<string, object>;
					if (dictionary2.ContainsKey("big_ad"))
					{
						Dictionary<string, object> d2 = dictionary2["big_ad"] as Dictionary<string, object>;
						adsInfo.smart_more_app.big_ad = this.getSmartMoreAppItem(d2);
					}
					if (dictionary2.ContainsKey("small_ad"))
					{
						IList list = dictionary2["small_ad"] as IList;
						IEnumerator enumerator = list.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								Dictionary<string, object> d3 = (Dictionary<string, object>)obj;
								adsInfo.smart_more_app.small_ad.Add(this.getSmartMoreAppItem(d3));
							}
						}
						finally
						{
							IDisposable disposable;
							if ((disposable = (enumerator as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
				if (dictionary.ContainsKey("more_app"))
				{
					IList list2 = dictionary["more_app"] as IList;
					if (list2.Count > 0)
					{
						adsInfo.more_app = this.GetMoreApp(list2[0] as Dictionary<string, object>);
					}
				}
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log(ex.Message);
			}
			return adsInfo;
		}

		private Number_level_passed_to_rate getNumber_level_passed_to_rate(Dictionary<string, object> d)
		{
			Number_level_passed_to_rate number_level_passed_to_rate = new Number_level_passed_to_rate();
			if (d != null && d.ContainsKey("rate_condition"))
			{
				number_level_passed_to_rate.SetRateCondition(d["rate_condition"].ToString());
			}
			return number_level_passed_to_rate;
		}

		private AdsItemType2 getSmartMoreAppItem(Dictionary<string, object> d)
		{
			AdsItemType2 adsItemType = new AdsItemType2();
			if (d == null)
			{
				return adsItemType;
			}
			if (d.ContainsKey("url"))
			{
				adsItemType.storeUrl = d["url"].ToString();
			}
			if (d.ContainsKey("image"))
			{
				adsItemType.imageUrl = d["image"].ToString();
			}
			return adsItemType;
		}

		private AdsItemType2 GetMoreApp(Dictionary<string, object> d)
		{
			AdsItemType2 adsItemType = new AdsItemType2();
			if (d == null)
			{
				return adsItemType;
			}
			if (d.ContainsKey("appUrl"))
			{
				adsItemType.storeUrl = d["appUrl"].ToString();
			}
			if (d.ContainsKey("title"))
			{
				adsItemType.title = d["title"].ToString();
			}
			if (d.ContainsKey("description"))
			{
				adsItemType.description = d["description"].ToString();
			}
			if (d.ContainsKey("thumbnailUrl"))
			{
				adsItemType.imageUrl = d["thumbnailUrl"].ToString();
			}
			if (d.ContainsKey("star"))
			{
				int.TryParse(d["star"].ToString(), out adsItemType.stars);
			}
			return adsItemType;
		}

		private string JsonData;

		private const string NUMBER_LEVEL_PASSED_TO_RATE = "number_level_passed_to_rate";

		private const string SMART_MORE_APP = "smart_more_app";

		private const string RATE_CONDITION = "rate_condition";

		private const string MORE_APP = "more_app";

		private const string BIG_AD = "big_ad";

		private const string SMALL_AD = "small_ad";

		private const string URL = "url";

		private const string APPURL = "appUrl";

		private const string IMAGEURL = "image";

		private const string TITLE = "title";

		private const string DESCRIPTION = "description";

		private const string THUMBNAILURL = "thumbnailUrl";

		private const string STAR = "star";
	}
}
