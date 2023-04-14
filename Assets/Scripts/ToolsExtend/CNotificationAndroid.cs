using System;
using UnityEngine;

namespace ToolsExtend
{
	public class CNotificationAndroid : INotification
	{
		private void SetAppActivity(bool active)
		{
			//using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(this.pluginpackage))
			//{
			//	androidJavaClass.CallStatic("setAppActivity", new object[]
			//	{
			//		active ? 1 : 0
			//	});
			//}
		}

		public void Init()
		{
			try
			{
				this.SetAppActivity(true);
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log("error on Init Android " + ex.Message);
			}
		}

		public void SendNotification(int id, string title, string content, string small_icon, string big_icon, long delay, bool hasSound = false, bool hasVibrate = false)
		{
			//using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(this.pluginpackage))
			//{
			//	androidJavaClass.CallStatic("startNotify", new object[]
			//	{
			//		title,
			//		content,
			//		small_icon,
			//		big_icon,
			//		hasSound ? 1 : 0,
			//		hasVibrate ? 1 : 0,
			//		delay,
			//		id,
			//		this.unityPackage
			//	});
			//}
		}

		public void CancelNotification(int id)
		{
			//using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(this.pluginpackage))
			//{
			//	androidJavaClass.CallStatic("cancelNotify", new object[]
			//	{
			//		id
			//	});
			//}
		}

		public void CancelAllNotification()
		{
			//using (AndroidJavaClass androidJavaClass = new AndroidJavaClass(this.pluginpackage))
			//{
			//	androidJavaClass.CallStatic("cancelAllNotify", new object[0]);
			//}
		}

		public void OnApplicationPause(bool paused)
		{
			//if (paused)
			//{
			//	this.SetAppActivity(false);
			//}
			//else
			//{
			//	this.SetAppActivity(true);
			//}
		}

		private string pluginpackage = "enet.utils.unity.LocalNotification";

		private string unityPackage = "com.unity3d.player.UnityPlayerActivity";
	}
}
