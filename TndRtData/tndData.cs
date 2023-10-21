using System;
using System.Text;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming


namespace TndRtData
{
	public sealed class tndDataTable
	{
		public enum DataItemType : byte
		{
			Null			= 0x00, // 0
			Input			= 0x01, // 1
			Flag			= 0x02, // 2
			Timer			= 0x03, // 3
			Output			= 0x04, // 4
			Counter			= 0x05, // 5
			Register		= 0x06, // 6
			Number			= 0x07, // 7
			Ascii			= 0x08, // 8
			Comm			= 0x0a, // 10
			Axis			= 0x0c, // 12
			Float			= 0x13, // 19
			System			= 0x14, // 20
			Array			= 0x15, // 21
			String			= 0x16, // 22
			Byte			= 0x19, // 25
			TimerPreset		= 0x1d, // 29
			TimerDone		= 0x32, // 50
			TimerEnable		= 0x33, // 51
		}

		private const string tndDataTableDLL = "TndData.dll";

		private const int MaxRTIndex = 0x0000ffff;

		public struct ArrayInfo
		{
			public ushort arrayIndex;
			public byte btType;
			public uint dwRuntimeID;
			public ushort wDims;
			public ushort wDim1;
			public ushort wDim2;
			public ushort wDim3;
		}

		public enum RetCode
		{
			NoError			= 0,	// No Error, operation successful
			NoDataTable		= 1,	// Unable to link to tnd DataTable
			RWOpFailed		= 2,	// Read/Write Error (invalid type/index, DI forced, write to R/O DI)
			ArrayOpFailed	= 3,	// Invalid Array Index
			StringOpFailed	= 4,	// Size mismatch
			TimeoutError	= 5,	// Operation Timed-out
			InvalidIndex	= 6,	// Index > MaxRTIndex
			InvalidType		= 7,	// Invalid type for selected operation
			InvalidValue	= 8,	// Invalid parameter value
		}


		#region DLL Imports for data item access functions

		// 0 - IsValid
		[DllImport(tndDataTableDLL, EntryPoint = "IsValid", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndIsValid();

		// 1,2,3 - Project Information
		[DllImport(tndDataTableDLL, EntryPoint = "ReadProjectDirectoryW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndReadProjectDirectoryW(StringBuilder projDirectory, ushort wBufferSize);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadProjectFileNameW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndReadProjectFileNameW(StringBuilder projDir, ushort wBufferSize);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadProjectTimeStampW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndReadProjectTimeStampW(StringBuilder projTimeStamp, ushort wBufferSize);

		// 4 - Scan Synchronization
		[DllImport(tndDataTableDLL, EntryPoint = "WaitForScan", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndWaitForScan(uint maxWaitTime);

		// 5-8 - Read/Write DataItems
		[DllImport(tndDataTableDLL, EntryPoint = "ReadDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndReadDataItem(byte type, ushort index, ref int val);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadDataItem2", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndReadDataItem2(uint typeIndex, ref int val);
		[DllImport(tndDataTableDLL, EntryPoint = "WriteDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndWriteDataItem(byte type, ushort index, int val);

		// 9,10 - Read/Write Float DataItems
		[DllImport(tndDataTableDLL, EntryPoint = "WriteDataItem2", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndWriteDataItem2(uint typeIndex, int val);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadFloatDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndReadFloatDataItem(uint index, ref double fVal);
		[DllImport(tndDataTableDLL, EntryPoint = "WriteFloatDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndWriteFloatDataItem(uint index, double fVal);

		// 11,12,13 - Read/Write String DataItems
		[DllImport(tndDataTableDLL, EntryPoint = "ReadStringDataItemW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndReadStringDataItemW(uint index, StringBuilder sb, uint wBufferSize);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadStringDataItem2W", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndReadStringDataItem2W(uint index, StringBuilder sb, uint wBufferSize);
		[DllImport(tndDataTableDLL, EntryPoint = "WriteStringDataItemW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndWriteStringDataItemW(uint index, StringBuilder sb, uint wBufferSize);

		// 14 - Get Array Information
		[DllImport(tndDataTableDLL, EntryPoint = "GetArrayInfo", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndGetArrayInfo(ushort arrayIndex, out byte btType, out uint dwRuntimeID,
												   out ushort wDims, out ushort wDim1, out ushort wDim2, out ushort wDim3);

		// 15,16 - Integer Array access by index
		[DllImport(tndDataTableDLL, EntryPoint = "ReadArrayDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndReadArrayDataItem(ushort arrayIndex, ushort itemIndex, out long lValue);
		[DllImport(tndDataTableDLL, EntryPoint = "WriteArrayDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndWriteArrayDataItem(ushort arrayIndex, ushort itemIndex, long lValue);

		// 17,18 - Float Array access by index
		[DllImport(tndDataTableDLL, EntryPoint = "ReadArrayFloatDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndReadArrayFloatDataItem(ushort arrayIndex, ushort itemIndex, out double fValue);
		[DllImport(tndDataTableDLL, EntryPoint = "WriteArrayFloatDataItem", CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndWriteArrayFloatDataItem(ushort arrayIndex, ushort itemIndex, double fValue);

		// 19,20,21 - String Array access by index
		[DllImport(tndDataTableDLL, EntryPoint = "ReadArrayStringDataItemW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndReadArrayStringDataItemW(ushort arrayIndex, ushort itemIndex, StringBuilder text, ushort wBufferSize);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadArrayStringDataItem2W", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndReadArrayStringDataItem2W(ushort arrayIndex, ushort itemIndex, StringBuilder text, ushort wBufferSize);
		[DllImport(tndDataTableDLL, EntryPoint = "WriteArrayStringDataItemW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		private static extern uint tndWriteArrayStringDataItemW(ushort arrayIndex, ushort itemIndex, StringBuilder text, ushort wBufferSize);

		// 22-26 - COM Port access
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndComPortWrite(ushort wCommNumber, byte[] pWriteData, ushort wWriteCount);
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndComPortWriteDone(ushort wCommNumber);
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndComPortRead(ushort wCommNumber, byte[] pWriteData, ushort wWriteCount);
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndComPortReadDone(ushort wCommNumber);
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl)]
		private static extern uint tndComPortControl(ushort wCommNumber, byte btControl);

		#endregion

		#region DataTable Access

		public static bool IsConnected()
		{
			try
			{
				var sb = new StringBuilder(255);
				var retcode = (RetCode)tndReadProjectDirectoryW(sb, (ushort)sb.Capacity);
				return retcode == RetCode.NoError;
			}
			catch
			{
				return false;
			}
		}

		// 0 - IsValid
		public static bool IsValid()
		{
			try
			{
				return RetCode.NoError == (RetCode)tndIsValid();
			}
			catch
			{
				return false;
			}
		}

		// 1,2,3 - Project Information
		public static string ReadProjectDirectory()
		{
			try
			{
				var sb = new StringBuilder(255);
				uint errorCode = tndReadProjectDirectoryW(sb, (ushort)sb.Capacity);
				if ((RetCode)errorCode != RetCode.NoError)
				{
					return "";
				}
				return sb.ToString();
			}
			catch (Exception)
			{
				return "";
			}
		}
		public static string ReadProjectFileName()
		{
			try
			{
				var sb = new StringBuilder(255);
				uint errorCode = tndReadProjectFileNameW(sb, (ushort)sb.Capacity);
				if ((RetCode)errorCode != RetCode.NoError)
				{
					return "";
				}
				return sb.ToString();
			}
			catch (Exception)
			{
				return "";
			}
		}
		public static string ReadProjectTimeStamp()
		{
			try
			{
				var sb = new StringBuilder(255);
				if ((RetCode)tndReadProjectTimeStampW(sb, (ushort)sb.Capacity) != RetCode.NoError)
					return "";
				return sb.ToString();
			}
			catch
			{
				return "";
			}
		}

		// 4 - Scan Synchronization
		public static void WaitForScan(uint maxWaitTime)
		{
			try
			{
				tndWaitForScan(maxWaitTime);
			}
			catch
			{

			}
		}

		// 5-8 - Read/Write DataItems
		public static RetCode ReadDataItem(DataItemType type, int index, out int value)
		{
			value = 0;
			try
			{
				if (index < 0 || index > MaxRTIndex)
					return RetCode.InvalidIndex;
				else
					return (RetCode)tndReadDataItem((byte)type, (ushort)index, ref value);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}
		public static RetCode ReadDataItem2(uint typeIndex, out int val)
		{
			val = 0;
			try
			{
				return (RetCode)tndReadDataItem2(typeIndex, ref val);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}
		public static RetCode WriteDataItem(DataItemType type, int index, int val)
		{
			try
			{
				if (index < 0 || index > MaxRTIndex)
					return RetCode.InvalidIndex;
				else
					return (RetCode)tndWriteDataItem((byte)type, (ushort)index, val);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}
		public static RetCode WriteDataItem2(uint typeIndex, int val)
		{
			try
			{
				return (RetCode)tndWriteDataItem2(typeIndex, val);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}

		// 9,10 - Read/Write Float DataItems
		public static RetCode ReadFloatDataItem(uint rtidOrIndex, out double val)
		{
			var index = (ushort)(rtidOrIndex &= 0x0000ffff);
			val = 0;
			try
			{
				if (rtidOrIndex < 0 || rtidOrIndex > MaxRTIndex)
					return RetCode.InvalidIndex;
				else
					return (RetCode)tndReadFloatDataItem(index, ref val);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}
		public static RetCode WriteFloatDataItem(uint rtidOrIndex, double fVal)
		{
			var index = (ushort)(rtidOrIndex &= 0x0000ffff);
			try
			{
				if (rtidOrIndex < 0 || rtidOrIndex > MaxRTIndex)
					return RetCode.InvalidIndex;
				else
					return (RetCode)tndWriteFloatDataItem(index, fVal);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}

		// 11,12,13 - Read/Write String DataItems
		public static RetCode ReadStringDataItem(uint rtidOrIndex, out string value)
		{
			var index = (ushort)(rtidOrIndex &= 0x0000ffff);
			try
			{
				var sb = new StringBuilder(255);
				RetCode retcode = (RetCode)tndReadStringDataItemW(index, sb, (ushort)sb.Capacity);
				if (retcode != RetCode.NoError)
					value = "";
				else
					value = sb.ToString();
				return retcode;
			}
			catch
			{
				value = "";
				return RetCode.NoDataTable;
			}
		}
		public static RetCode ReadStringDataItem2(uint rtidOrIndex, out string value)
		{
			var index = (ushort)(rtidOrIndex &= 0x0000ffff);
			try
			{
				var sb = new StringBuilder(255);
				RetCode retcode = (RetCode)tndReadStringDataItem2W(index, sb, (ushort)sb.Capacity);
				if (retcode != RetCode.NoError)
					value = "";
				else
					value = sb.ToString();
				return retcode;
			}
			catch
			{
				value = "";
				return RetCode.NoDataTable;
			}
		}
		public static RetCode WriteStringDataItem(uint rtidOrIndex, string text)
		{
			var index = (ushort)(rtidOrIndex &= 0x0000ffff);
			try
			{
				var sb = new StringBuilder(text);
				sb.Append('\0');
				return (RetCode)tndWriteStringDataItemW(index, sb, (ushort)sb.Length);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}

		// 14 - Get Array Information
		public static ArrayInfo GetArrayInfo(int arrayIndex)
		{
			var arrayInfo = new ArrayInfo();
			arrayInfo.arrayIndex = (ushort)arrayIndex;
			try
			{
				tndGetArrayInfo((ushort)arrayIndex, out var btType, out var dwRuntimeID, out var wDims, out var wDim1, out var wDim2, out var wDim3);
				arrayInfo.btType = btType;
				arrayInfo.wDims = wDims;
				arrayInfo.wDim1 = wDim1;
				arrayInfo.wDim2 = wDim2;
				arrayInfo.wDim3 = wDim3;
				arrayInfo.dwRuntimeID = dwRuntimeID;
			}
			catch
			{

			}
			return arrayInfo;
		}

		// 15,16 - Read/Write Array DataItem
		public static RetCode ReadArrayDataItem(int arrayIndex, int itemIndex, out long lvalue)
		{
			try
			{
				RetCode retcode = (RetCode)tndReadArrayDataItem((ushort)arrayIndex, (ushort)itemIndex, out lvalue);
				return retcode;
			}
			catch
			{
				lvalue = 0;
				return RetCode.NoDataTable;
			}
		}
		public static RetCode WriteArrayDataItem(int arrayIndex, int itemIndex, long lValue)
		{
			try
			{
				return (RetCode)tndWriteArrayDataItem((ushort)arrayIndex, (ushort)itemIndex, lValue);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}


		// 17,18 - Read/Write Float Array DataItem
		public static RetCode ReadArrayFloatDataItem(int arrayIndex, int itemIndex, out double fValue)
		{
			try
			{
				RetCode retcode = (RetCode)tndReadArrayFloatDataItem((ushort)arrayIndex, (ushort)itemIndex, out fValue);
				return retcode;
			}
			catch
			{
				fValue = 0;
				return RetCode.NoDataTable;
			}
		}
		public static RetCode WriteArrayFloatDataItem(int arrayIndex, int itemIndex, double fValue)
		{
			try
			{
				return (RetCode)tndWriteArrayFloatDataItem((ushort)arrayIndex, (ushort)itemIndex, fValue);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}

		// 19,20,21 - Read/Write String Array DataItem
		public static RetCode ReadArrayStringDataItemW(int arrayIndex, int itemIndex, out string val)
		{
			try
			{
				var sb = new StringBuilder(255);
				RetCode retcode = (RetCode)tndReadArrayStringDataItemW((ushort)arrayIndex, (ushort)itemIndex, sb, (ushort)sb.Capacity);
				if (retcode != RetCode.NoError)
					val = "";
				else
					val = sb.ToString();
				return retcode;
			}
			catch
			{
				val = "";
				return RetCode.NoDataTable;
			}
		}
		public static RetCode ReadArrayStringDataItem2W(int arrayIndex, int itemIndex, out string val)
		{
			try
			{
				var sb = new StringBuilder(255);
				RetCode retcode = (RetCode)tndReadArrayStringDataItem2W((ushort)arrayIndex, (ushort)itemIndex, sb, (ushort)sb.Capacity);
				if (retcode != RetCode.NoError)
					val = "";
				else
					val = sb.ToString();
				return retcode;
			}
			catch
			{
				val = "";
				return RetCode.NoDataTable;
			}
		}
		public static RetCode WriteArrayStringDataItemW(int arrayIndex, int itemIndex, string text)
		{
			try
			{
				var sb = new StringBuilder(text);
				sb.Append('\0');
				return (RetCode)tndWriteArrayStringDataItemW((ushort)arrayIndex, (ushort)itemIndex, sb, (ushort)sb.Capacity);
			}
			catch
			{
				return RetCode.NoDataTable;
			}
		}

#if ComPort
		// 22-26 - ComPort Routines
		public static RetCode ComPortWrite(int wCommNumber, byte[] pWriteData, int wWriteCount)
		{
			return RetCode.NoError;
		}
		public static RetCode ComPortWriteDone(int wCommNumber)
		{
			return RetCode.NoError;
		}
		public static RetCode ComPortRead(int wCommNumber, byte[] pWriteData, int wWriteCount)
		{
			return RetCode.NoError;
		}
		public static RetCode ComPortReadDone(int wCommNumber)
		{
			return RetCode.NoError;
		}
		public static RetCode ComPortControl(int wCommNumber, byte btControl)
		{
			return RetCode.NoError;
		}

#endif

#endregion

#if AnsiStringFunctions
		// String function that use ASCII strings 
		[DllImport(tndDataTableDLL, EntryPoint = "ReadProjectDirectoryA", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint tndReadProjectDirectoryA(StringBuilder projDirectory, ushort length);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadProjectFileNameA", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint tndReadProjectFileNameA(StringBuilder projFileName, ushort length);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadProjectTimeStampA", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint tndReadProjectTimeStampA(StringBuilder projTimeStamp, ushort length);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadStringDataItemA", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint tndReadStringDataItemA(uint index, StringBuilder sb, uint length);
		[DllImport(tndDataTableDLL, EntryPoint = "ReadStringDataItem2A", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint tndReadStringDataItem2A(uint index, StringBuilder sb, uint length);
		[DllImport(tndDataTableDLL, EntryPoint = "WriteStringDataItemA", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint tndWriteStringDataItemA(uint index, StringBuilder sb, uint length);
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint ReadArrayStringDataItemA(ushort arrayIndex, ushort itemIndex, StringBuilder text, ushort length);
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint ReadArrayStringDataItem2A(ushort arrayIndex, ushort itemIndex, StringBuilder text, ushort length);
		[DllImport(tndDataTableDLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		private static extern uint WriteArrayStringDataItemA(ushort arrayIndex, ushort itemIndex, StringBuilder text, ushort length);


		public static string ReadProjectTimeStampA()
		{
			var sb = new StringBuilder(255);
			ReturnCode = (RetCode)tndReadProjectTimeStampA(sb, (ushort)sb.Capacity);
			if (ReturnCode != RetCode.NoError)
				return "";
			return sb.ToString();
		}
		public static string ReadProjectDirectoryA()
		{
			var sb = new StringBuilder(255);
			ReturnCode = (RetCode)tndReadProjectDirectoryA(sb, (ushort)sb.Capacity);
			if (ReturnCode != RetCode.NoError)
				return "";
			return sb.ToString();
		}
		public static string ReadProjectFileNameA()
		{
			var sb = new StringBuilder(255);
			ReturnCode = (RetCode)tndReadProjectFileNameA(sb, (ushort)sb.Capacity);
			if (ReturnCode != RetCode.NoError)
				return "";
			return sb.ToString();
		}
		public static string ReadStringDataItemA(int itemIndex)
		{
			var sb = new StringBuilder(255);
			ReturnCode = (RetCode)tndReadStringDataItemA((ushort)itemIndex, sb, (ushort)sb.Capacity);
			if (ReturnCode != RetCode.NoError)
				return "";
			return sb.ToString();
		}
		public static string ReadStringDataItem2A(int itemIndex)
		{
			var sb = new StringBuilder(255);
			ReturnCode = (RetCode)tndReadStringDataItem2A((ushort)itemIndex, sb, (ushort)sb.Capacity);
			if (ReturnCode != RetCode.NoError)
				return "";
			return sb.ToString();
		}
		public static void WriteStringDataItem(int itemIndex, string text)
		{
			var sb = new StringBuilder(text);
			ReturnCode = (RetCode)tndWriteStringDataItemA((ushort)itemIndex, sb, (ushort)sb.Capacity);
		}
				public static RetCode ReadArrayStringDataItemA(int arrayIndex, int itemIndex, StringBuilder text, int length)
		{
			return RetCode.NoError;
		}
		public static RetCode ReadArrayStringDataItem2A(int arrayIndex, int itemIndex, StringBuilder text, int length)
		{
			return RetCode.NoError;
		}
		public static RetCode WriteArrayStringDataItemA(int arrayIndex, int itemIndex, StringBuilder text, int length)
		{
			return RetCode.NoError;
		}

#endif
	}

}
