using System;
using UnityEngine;

namespace Mosframe
{
	public class HtmlColor
	{
		public static string convert(Color32 value)
		{
			return string.Format("#{0:x02}{1:x02}{2:x02}{3:x02}", new object[]
			{
				value.r,
				value.g,
				value.b,
				value.a
			});
		}

		public static string convert(Color value)
		{
			Color32 color = value;
			return string.Format("#{0:x02}{1:x02}{2:x02}{3:x02}", new object[]
			{
				color.r,
				color.g,
				color.b,
				color.a
			});
		}

		public static string convert(int value)
		{
			return string.Format("#{0:x02}{1:x02}{2:x02}ff", (value & 16711680) >> 16, (value & 65280) >> 8, (value & 255) >> 0);
		}

		public static string convert(uint value)
		{
			return string.Format("#{0:x02}{1:x02}{2:x02}{3:x02}", new object[]
			{
				(value & 16711680u) >> 16,
				(value & 65280u) >> 8,
				(value & 255u) >> 0,
				(value & 4278190080u) >> 24
			});
		}

		public const string aqua = "#00ffffff";

		public const string black = "#000000ff";

		public const string blue = "#0000ffff";

		public const string brown = "#a52a2aff";

		public const string cyan = "#00ffffff";

		public const string darkBlue = "#0000a0ff";

		public const string green = "#008000ff";

		public const string grey = "#808080ff";

		public const string lightBlue = "#add8e6ff";

		public const string lime = "#00ff00ff";

		public const string magenta = "#ff00ffff";

		public const string maroon = "#800000ff";

		public const string navy = "#000080ff";

		public const string olive = "#808000ff";

		public const string orange = "#ffa500ff";

		public const string purple = "#800080ff";

		public const string red = "#ff0000ff";

		public const string silver = "#c0c0c0ff";

		public const string teal = "#008080ff";

		public const string white = "#ffffffff";

		public const string yellow = "#ffff00ff";
	}
}
