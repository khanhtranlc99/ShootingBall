using System;

namespace ToolsExtend
{
	[Serializable]
	public class NotificationItem
	{
		public int id;

		public string title;

		public string[] content;

		public string small_icon;

		public string big_icon;

		public bool hasSound;

		public bool hasVibrate;

		public NotificationType notificationType;

		public NotificationTimeType notificationTimeType;

		public int delayTime;

		public int delayDate;

		public DayOfWeek dateInWeek;

		public int exactHour;

		public int exactMinute;

		public int exactSecond;

		public string exactDate;

		public int repeatTimes;
	}
}
