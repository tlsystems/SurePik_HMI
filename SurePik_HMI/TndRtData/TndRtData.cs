using System;
using System.IO;
using TndMap;

namespace TndRtData
{
	public class CTndNTag
	{
		public class DI
		{
			public string TagName;
			public uint RTID;

			public DI(string tagname)
			{
				TagName = tagname;
				RTID = 0;
			}

			public void GetValue(out bool bValue)
			{
				bValue = false;
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.ReadDataItem2(RTID, out int bVal);
				bValue = bVal != 0;
			}
			public void GetValue(out short siValue)
			{
				siValue = 0;
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.ReadDataItem2(RTID, out var iValue);
				siValue = (short) iValue;
			}
			public void GetValue(out int iValue)
			{
				iValue = 0;
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.ReadDataItem2(RTID, out iValue);
			}
			public void GetValue(out uint uiValue)
			{
				uiValue = 0;
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.ReadDataItem2(RTID, out var iValue);
				uiValue = (uint) iValue;
			}
			public void GetValue(out double fValue)
			{
				fValue = 0.0;
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.ReadFloatDataItem(RTID, out fValue);
			}
			public void GetValue(out string sValue)
			{
				sValue = "";
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.ReadStringDataItem(RTID, out sValue);
			}

			public void SetValue(bool bValue)
			{
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.WriteDataItem2(RTID, bValue ? 1 : 0);
			}
			public void SetValue(short siValue)
			{
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.WriteDataItem2(RTID, siValue);
			}
			public void SetValue(int iValue)
			{
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.WriteDataItem2(RTID, iValue);
			}
			public void SetValue(double fValue)
			{
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.WriteFloatDataItem(RTID, fValue);
			}
			public void SetValue(string sValue)
			{
				if (!tndDataTable.IsConnected())
					throw new Exception("Not connected to runtime.");

				if (RTID == 0)
				{
					RTID = TndRtMap.GetRTID(TagName);
					if (RTID == 0)
						throw new Exception("Invalid RTID");
				}

				tndDataTable.WriteStringDataItem(RTID, sValue );
			}
		}

		public bool Open()
		{
			if (!tndDataTable.IsConnected())
				return false;

			var projDir = tndDataTable.ReadProjectDirectory();
			var projName = tndDataTable.ReadProjectFileName();
			var mapPath = $"{projDir}{projName}.map.xml";
			if (!File.Exists(mapPath))
				return false;

			TndRtMap.Load(mapPath);
		
			return true;
		}

		public bool IsValid()
		{
			return tndDataTable.IsValid();
		}

	}

}
