using System;

namespace ToolsExtend
{
	public interface INotification
	{
		void Init();

		void SendNotification(int id, string title, string content, string small_icon, string big_icon, long delay, bool hasSound = false, bool hasVibrate = false);

		void CancelNotification(int id);

		void CancelAllNotification();

		void OnApplicationPause(bool paused);
	}
}
