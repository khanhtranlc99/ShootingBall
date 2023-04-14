using System;
using System.Globalization;
using UnityEngine;

namespace ToolsExtend
{
	public class NotificationSystem : MonoBehaviour
	{
		public INotification CurrentNotification
		{
			get
			{
				return this.notification;
			}
		}

		public bool enableNotify
		{
			get
			{
				return this._enableNotify;
			}
		}

		public static NotificationSystem Instance
		{
			get
			{
				if (NotificationSystem.instance == null)
				{
					NotificationSystem.instance = UnityEngine.Object.FindObjectOfType<NotificationSystem>();
					NotificationSystem.instance.Init();
				}
				return NotificationSystem.instance;
			}
		}

		private void Awake()
		{
			if (NotificationSystem.instance == null)
			{
				this.Init();
			}
		}

		public void Init()
		{
			if (NotificationSystem.instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			NotificationSystem.instance = this;
			UnityEngine.Object.DontDestroyOnLoad(this);
			UnityEngine.Debug.Log("try to create notification crossplatform");
			this.notification = new CNotificationAndroid();
			if (this.notification != null)
			{
				this.notification.Init();
			}
			if (this.enableNotify)
			{
				UnityEngine.Debug.Log("enable notification");
				this.CancelAllNotification();
				this.SetupNewNotification();
			}
			UnityEngine.Debug.Log("Created notification crossplatform android");
		}

		public void SendNotification(int id, string title, string content, string small_icon, string big_icon, long delay, bool hasSound = false, bool hasVibrate = false)
		{
			if (!this.enableNotify)
			{
				return;
			}
			if (delay <= 0L)
			{
				UnityEngine.Debug.Log("can't start a notification with time <=0");
				return;
			}
			if (this.notification != null)
			{
				this.notification.SendNotification(id, title, content, small_icon, big_icon, delay, hasSound, hasVibrate);
				UnityEngine.Debug.Log("Send Notification content : " + content);
			}
			else
			{
				UnityEngine.Debug.Log("Send Notification content : " + content);
			}
		}

		public void CancelNotification(int id)
		{
			if (this.notification != null)
			{
				this.notification.CancelNotification(id);
			}
			else
			{
				UnityEngine.Debug.Log("Cancel notification");
			}
		}

		public void SetupNewNotification()
		{
			if (this.notification == null)
			{
				return;
			}
			foreach (NotificationItem item in this.notifyItems)
			{
				this.SetupNotify(item);
			}
		}

		public void SetupNotify(NotificationItem item)
		{
			NotificationType notificationType = item.notificationType;
			if (notificationType != NotificationType.Once)
			{
				if (notificationType == NotificationType.Repeat)
				{
					this.SetupNotificationPlayMultipleTime(item);
				}
			}
			else
			{
				this.SetupNotificationPlayOnce(item);
			}
		}

		private void SetupNotificationPlayOnce(NotificationItem item)
		{
			long num = 0L;
			DateTime today = DateTime.Today;
			switch (item.notificationTimeType)
			{
			case NotificationTimeType.DelayTime:
				num = (long)item.delayTime * 1000L;
				break;
			case NotificationTimeType.DelayDate:
				num = (long)today.AddDays((double)item.delayDate).AddHours((double)item.exactHour).AddMinutes((double)item.exactMinute).AddSeconds((double)item.exactSecond).Subtract(DateTime.Now).TotalMilliseconds;
				UnityEngine.Debug.Log(num);
				break;
			case NotificationTimeType.DelayDateInWeek:
			{
				DateTime today2 = DateTime.Today;
				int num2 = item.dateInWeek - today2.DayOfWeek;
				if (num2 < 0)
				{
					num2 += 7;
				}
				num = (long)today.AddDays((double)num2).AddHours((double)item.exactHour).AddMinutes((double)item.exactMinute).AddSeconds((double)item.exactSecond).Subtract(DateTime.Now).TotalMilliseconds;
				break;
			}
			case NotificationTimeType.SpecificDate:
			{
				DateTime dateTime = DateTime.ParseExact(item.exactDate, "dd/mm/yyyy", CultureInfo.CurrentCulture);
				TimeSpan value = new TimeSpan(0, item.exactHour, item.exactMinute, item.exactSecond);
				value = dateTime.Add(value).Subtract(DateTime.Now);
				num = (long)value.TotalMilliseconds;
				break;
			}
			}
			this.SendNotification(item.id, item.title, item.content[UnityEngine.Random.Range(0, item.content.Length)], item.small_icon, item.big_icon, num, item.hasSound, false);
		}

		private void SetupNotificationPlayMultipleTime(NotificationItem item)
		{
			DateTime today = DateTime.Today;
			NotificationTimeType notificationTimeType = item.notificationTimeType;
			if (notificationTimeType != NotificationTimeType.DelayDate)
			{
				if (notificationTimeType != NotificationTimeType.DelayTime)
				{
					if (notificationTimeType == NotificationTimeType.DelayDateInWeek)
					{
						DateTime today2 = DateTime.Today;
						int num = item.dateInWeek - today2.DayOfWeek;
						int num2 = num;
						if (num < 0)
						{
							num += 7;
						}
						for (int i = 0; i < item.repeatTimes; i++)
						{
							if (num2 % 3 == 0)
							{
								num2 += 7;
							}
							else
							{
								long delay = (long)DateTime.Today.AddDays((double)(num + i * 7)).AddHours((double)item.exactHour).AddMinutes((double)item.exactMinute).AddSeconds((double)item.exactSecond).Subtract(DateTime.Now).TotalMilliseconds;
								this.SendNotification(item.id + this.repeatitionID * i, item.title, item.content[UnityEngine.Random.Range(0, item.content.Length)], item.small_icon, item.big_icon, delay, item.hasSound, item.hasVibrate);
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < item.repeatTimes; j++)
					{
						long delay2 = (long)item.delayTime * 1000L * (long)(j + 1);
						UnityEngine.Debug.Log("item.content[UnityEngine.Random.Range(0, item.content.Length)]: " + item.content[UnityEngine.Random.Range(0, item.content.Length)]);
						this.SendNotification(item.id + this.repeatitionID * j, item.title, item.content[UnityEngine.Random.Range(0, item.content.Length)], item.small_icon, item.big_icon, delay2, item.hasSound, item.hasVibrate);
					}
				}
			}
			else
			{
				for (int k = 0; k < item.repeatTimes; k++)
				{
					long delay3 = (long)DateTime.Today.AddDays((double)(item.delayDate * (k + 1))).AddHours((double)item.exactHour).AddMinutes((double)item.exactMinute).AddSeconds((double)item.exactSecond).Subtract(DateTime.Now).TotalMilliseconds;
					this.SendNotification(item.id + this.repeatitionID * k, item.title, item.content[UnityEngine.Random.Range(0, item.content.Length)], item.small_icon, item.big_icon, delay3, item.hasSound, item.hasVibrate);
				}
			}
		}

		public void OnApplicationPause(bool paused)
		{
			UnityEngine.Debug.Log("paused is: " + paused);
			if (this.notification != null)
			{
				this.notification.OnApplicationPause(paused);
			}
		}

		public void CancelAllNotification()
		{
			if (this.notification != null)
			{
				this.notification.CancelAllNotification();
			}
		}

		[SerializeField]
		private bool _enableNotify;

		[SerializeField]
		private int repeatitionID;

		[SerializeField]
		private NotificationItem[] notifyItems;

		private INotification notification;

		private static NotificationSystem instance;
	}
}
