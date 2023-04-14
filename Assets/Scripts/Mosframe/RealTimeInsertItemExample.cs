using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mosframe
{
	public class RealTimeInsertItemExample : MonoBehaviour
	{
		private void Start()
		{
			this.insertItem(0, new RealTimeInsertItemExample.CustomData
			{
				name = "data00",
				value = 100
			});
			this.insertItem(0, new RealTimeInsertItemExample.CustomData
			{
				name = "data01",
				value = 100
			});
		}

		public void insertItem(int index, RealTimeInsertItemExample.CustomData data)
		{
			RealTimeInsertItemExample.data.Insert(index, data);
			this.scrollView.totalItemCount = RealTimeInsertItemExample.data.Count;
		}

		public static List<RealTimeInsertItemExample.CustomData> data = new List<RealTimeInsertItemExample.CustomData>();

		public DynamicScrollView scrollView;

		public int dataIndex = 1;

		public string dataName = "Insert01";

		public class CustomData
		{
			public string name;

			public int value;
		}
	}
}
