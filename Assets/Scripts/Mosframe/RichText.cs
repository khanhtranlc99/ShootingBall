using System;
using System.Text;

namespace Mosframe
{
	public class RichText
	{
		public static string bold(object text)
		{
			return new StringBuilder("<b>").Append(text).Append("</b>").ToString();
		}

		public static string italic(object text)
		{
			return new StringBuilder("<i>").Append(text).Append("</i>").ToString();
		}

		public static string size(object text, int size)
		{
			return new StringBuilder("<size=").Append(size).Append(">").Append(text).Append("</size>").ToString();
		}

		public static string color(object text, string color)
		{
			return new StringBuilder("<color=").Append(color).Append(">").Append(text).Append("</color>").ToString();
		}

		public static string aqua(object text)
		{
			return new StringBuilder("<color=").Append("#00ffffff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string black(object text)
		{
			return new StringBuilder("<color=").Append("#000000ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string blue(object text)
		{
			return new StringBuilder("<color=").Append("#0000ffff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string brown(object text)
		{
			return new StringBuilder("<color=").Append("#a52a2aff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string cyan(object text)
		{
			return new StringBuilder("<color=").Append("#00ffffff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string darkBlue(object text)
		{
			return new StringBuilder("<color=").Append("#0000a0ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string green(object text)
		{
			return new StringBuilder("<color=").Append("#008000ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string grey(object text)
		{
			return new StringBuilder("<color=").Append("#808080ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string lightBlue(object text)
		{
			return new StringBuilder("<color=").Append("#add8e6ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string lime(object text)
		{
			return new StringBuilder("<color=").Append("#00ff00ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string magenta(object text)
		{
			return new StringBuilder("<color=").Append("#ff00ffff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string maroon(object text)
		{
			return new StringBuilder("<color=").Append("#800000ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string navy(object text)
		{
			return new StringBuilder("<color=").Append("#000080ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string olive(object text)
		{
			return new StringBuilder("<color=").Append("#808000ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string orange(object text)
		{
			return new StringBuilder("<color=").Append("#ffa500ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string purple(object text)
		{
			return new StringBuilder("<color=").Append("#800080ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string red(object text)
		{
			return new StringBuilder("<color=").Append("#ff0000ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string silver(object text)
		{
			return new StringBuilder("<color=").Append("#c0c0c0ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string teal(object text)
		{
			return new StringBuilder("<color=").Append("#008080ff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string white(object text)
		{
			return new StringBuilder("<color=").Append("#ffffffff").Append(">").Append(text).Append("</color>").ToString();
		}

		public static string yellow(object text)
		{
			return new StringBuilder("<color=").Append("#ffff00ff").Append(">").Append(text).Append("</color>").ToString();
		}
	}
}
