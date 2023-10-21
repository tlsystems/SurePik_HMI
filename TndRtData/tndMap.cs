using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

using TndNTag;

namespace TndMap
{
	public static class TndRtMap
	{
		private static Dictionary<string, uint> _tagMap = new Dictionary<string, uint>();

		public static bool Load(string projectPath)
		{
			if (_tagMap.Count > 0)
				return true;

			try
			{
				var rtMap = new tndRTMapDS();
				if (!File.Exists(projectPath))
					return false;
				var xx = rtMap.ReadXml(projectPath);

				foreach (var row in rtMap.DataItem)
				{
					Debug.WriteLine($"{row.RTID} {row.Tagname}");
					var rtid = uint.Parse(row.RTID, NumberStyles.AllowHexSpecifier);
					_tagMap.Add((string)row.Tagname, rtid);
				}
			}
			catch
			{
				return false;
			}
			return true;
		}

		public static uint GetRTID(string tagName)
		{
			if (_tagMap.ContainsKey(tagName))
				return _tagMap[tagName];
			else
				return 0;
		}

	}
}
