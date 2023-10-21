using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using TndRtData;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace SurePik_HMI
{
	public partial class SurePic_HMI : Form
	{
		private bool _formLoaded = false;

		#region constructor, startup, shuddown

		public SurePic_HMI()
		{
			InitializeComponent();
		}

		private void SurePikHMI_Load(object sender, EventArgs e)
		{
			lblVersion.Text = "";

			// Connect to Controller
			TndStartup();

			// Manual Mode
			ManualModeStartup_c1();
			ManualModeStartup_c2();
			ManualModeStartup_c3();
			ManualModeStartup_c4();

			// Setup
			PrmLoad_c1();

			// Process timers
			tmrObserver.Enabled = true;

			_formLoaded = true;
		}

		private void SurePikHMI_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Closing the form will reset values in the controller.

			bool result = false;

			if (MessageBox.Show("Are you sure you wish to exit?", "Application Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
			{
				e.Cancel = true;
				result = true;
			}

			if (!result)
			{
				StopMM_c1();
				StopMM_c2();
				StopMM_c3();
				StopMM_c4();

				//. Dave, I create functions to test, set, and clear bits in an int or 
				//	uint to replace all of the 2^x expressions. In C# the ^ operator is
				//	for exclusive or, not exponentiation.
				SetBit(ref lnStatReg2_c1, 1); // Stop Homing
				SetBit(ref lnStatReg2_c2, 1); // Stop Homing
				SetBit(ref lnStatReg2_c3, 1); // Stop Homing
				SetBit(ref lnStatReg2_c4, 1); // Stop Homing

				// // All data items in the TndNTag must be written to.
				//. Dave, I put all of the data table reads and write in try/catch
				//	blocks. If there are any error when reading and writing to the
				//	data table, the code in the catch block will run. About the 
				//	only error that can occur is if the runtime goes down.
				try
				{
					diStatusReg2_c1.SetValue(lnStatReg2_c1);
					diRequestedBin_c1.SetValue(lnReqBin_c1);

					diStatusReg2_c2.SetValue(lnStatReg2_c2);
					diRequestedBin_c2.SetValue(lnReqBin_c2);

					diStatusReg2_c3.SetValue(lnStatReg2_c3);
					diRequestedBin_c3.SetValue(lnReqBin_c3);

					diStatusReg2_c4.SetValue(lnStatReg2_c4);
					diRequestedBin_c4.SetValue(lnReqBin_c4);

					diHeartbeat.SetValue(lnHeartbeat);

					diSetBinPos_c1.SetValue(lnSetBinPos_c1);
					diSetBinPos_c2.SetValue(lnSetBinPos_c2);
					diSetBinPos_c3.SetValue(lnSetBinPos_c3);
					diSetBinPos_c4.SetValue(lnSetBinPos_c4);
				}
				catch
				{
				}
			}
		}

		private void TndStartup()
		{
			_tndNTag.Open();

			tmrTnDNTag1.Enabled = true;
		}

		private bool TestBit(int number, int bit)
		{
			return (number & (1 << bit)) != 0;
		}
		private void SetBit(ref int number, int bit)
		{
			number |= 1 << bit;
		}
		private void ClearBit(int number, int bit)
		{
			number &= ~(1 << bit);
		}

		private bool TestBit(uint number, int bit)
		{
			return (number & (1 << bit)) != 0;
		}
		private void SetBit(ref uint number, int bit)
		{
			number |= (uint)(1 << bit);
		}
		private void ClearBit(uint number, int bit)
		{
			number &= ~(uint)(1 << bit);
		}


		#endregion


		private void tmrTnDNTag1_Tick(object sender, EventArgs e)
		{
			//  A timer can be used to Read from and/or Write to the controller.
			tmrTnDNTag1.Enabled = false;

			//  Read tags
			//
			if (GetCarouselValues())
				UpdateForm();
			else
				SetDefaultCarouselValues();

			//  Status Register Breakout
			StatReg1Breakout_c1();
			StatReg1Breakout_c2();
			StatReg1Breakout_c3();
			StatReg1Breakout_c4();

			//  Flags
			FlagsBreakout_c1();
			FlagsBreakout_c2();
			FlagsBreakout_c3();
			FlagsBreakout_c4();

			// Manual Mode
			ReadTagsMM_c1();
			ReadTagsMM_c2();
			ReadTagsMM_c3();
			ReadTagsMM_c4();

			//  Button Colors
			ManModeButtonColors_c1();
			ManModeButtonColors_c2();
			ManModeButtonColors_c3();
			ManModeButtonColors_c4();
			JogButtonColors();
			EncoderSetupColors_c1();
			EncoderSetupColors_c2();
			EncoderSetupColors_c3();
			EncoderSetupColors_c4();
			HomingSetupColors_c1();
			HomingSetupColors_c2();
			HomingSetupColors_c3();
			HomingSetupColors_c4();

			//
			//  Write tags
			//

			//  Heartbeat
			if (lnHeartbeat == int.MaxValue)
				lnHeartbeat = 0;
			else
				lnHeartbeat++;

			//  The requested bin location
			lnReqBin_c1 = lnRequestedBin_c1;
			lnReqBin_c2 = lnRequestedBin_c2;
			lnReqBin_c3 = lnRequestedBin_c3;
			lnReqBin_c4 = lnRequestedBin_c4;

			//  Carousel 1
			// StatReg2
			lnStatReg2_c1 = 0;
			// Homing
			if (lbHomingStart_c1) SetBit(ref lnStatReg2_c1, 0);
			if (lbHomingStop_c1) SetBit(ref lnStatReg2_c1, 1);
			// Encoder
			if (lbEncoderStart_c1) SetBit(ref lnStatReg2_c1, 3);
			if (lbEncoderStop_c1) SetBit(ref lnStatReg2_c1, 4);
			// Manual mode
			if (lbManualMode_c1) SetBit(ref lnStatReg2_c1, 5);
			
			//  Carousel 2
			// StatReg2
			lnStatReg2_c2 = 0;
			// Homing
			if (lbHomingStart_c2) SetBit(ref lnStatReg2_c2, 0);
			if (lbHomingStop_c2) SetBit(ref lnStatReg2_c2, 1);
			// Encoder
			if (lbEncoderStart_c2) SetBit(ref lnStatReg2_c2, 3);
			if (lbEncoderStop_c2) SetBit(ref lnStatReg2_c2, 4);
			// Manual mode
			if (lbManualMode_c2) SetBit(ref lnStatReg2_c2, 5);
			
			//  Carousel 3
			// StatReg2
			lnStatReg2_c3 = 0;
			// Homing
			if (lbHomingStart_c3) SetBit(ref lnStatReg2_c3, 0);
			if (lbHomingStop_c3) SetBit(ref lnStatReg2_c3, 1);
			// Encoder
			if (lbEncoderStart_c3) SetBit(ref lnStatReg2_c3, 3);
			if (lbEncoderStop_c3) SetBit(ref lnStatReg2_c3, 4);
			// Manual mode
			if (lbManualMode_c3) SetBit(ref lnStatReg2_c3, 5);
			
			//  Carousel 4
			// StatReg2
			lnStatReg2_c4 = 0;
			// Homing
			if (lbHomingStart_c4) SetBit(ref lnStatReg2_c4, 0);
			if (lbHomingStop_c4) SetBit(ref lnStatReg2_c4, 1);
			// Encoder
			if (lbEncoderStart_c4) SetBit(ref lnStatReg2_c4, 3);
			if (lbEncoderStop_c4) SetBit(ref lnStatReg2_c4, 4);
			// Manual mode
			if (lbManualMode_c4) SetBit(ref lnStatReg2_c4, 5);

			try
			{
				// All data items in the ocx must be written to.
				diStatusReg2_c1.SetValue(lnStatReg2_c1);
				diRequestedBin_c1.SetValue(lnReqBin_c1);
				diStatusReg2_c2.SetValue(lnStatReg2_c2);
				diRequestedBin_c2.SetValue(lnReqBin_c2);
				diStatusReg2_c3.SetValue(lnStatReg2_c3);
				diRequestedBin_c3.SetValue(lnReqBin_c3);
				diStatusReg2_c4.SetValue(lnStatReg2_c4);
				diRequestedBin_c4.SetValue(lnReqBin_c4);
				diHeartbeat.SetValue(lnHeartbeat);
				diSetBinPos_c1.SetValue(lnSetBinPos_c1);
				diSetBinPos_c2.SetValue(lnSetBinPos_c2);
				diSetBinPos_c3.SetValue(lnSetBinPos_c3);
				diSetBinPos_c4.SetValue(lnSetBinPos_c4);

				//  Success
				// Manual Mode
				WriteTagsMM_c1();
				WriteTagsMM_c2();
				WriteTagsMM_c3();
				WriteTagsMM_c4();

				tmrTnDNTag1.Enabled = true;
			}
			catch
			{

			}
		}

		private bool GetCarouselValues()
		{
			try
			{
				//  Read Data from controller
				//  Carousel 1
				diMotorFWC_c1.GetValue(out lbMoveFWD_c1);
				diMotorREV_c1.GetValue(out lbMoveREV_c1);
				diMotorSPD0_c1.GetValue(out lbMoveSPD0_c1);
				diMotorSPD1_c1.GetValue(out lbMoveSPD1_c1);
				diNumOfBins_c1.GetValue(out lnNumBins_c1);
				diCurrentBin_c1.GetValue(out lnCurBin_c1);
				diTargetBin_c1.GetValue(out lnTgtBin_c1);
				diStatusReg_c1.GetValue(out lnStatReg1_c1);
				//  Carousel 2
				diMotorFWC_c2.GetValue(out lbMoveFWD_c2);
				diMotorREV_c2.GetValue(out lbMoveREV_c2);
				diMotorSPD0_c2.GetValue(out lbMoveSPD0_c2);
				diMotorSPD1_c2.GetValue(out lbMoveSPD1_c2);
				diNumOfBins_c2.GetValue(out lnNumBins_c2);
				diCurrentBin_c2.GetValue(out lnCurBin_c2);
				diTargetBin_c2.GetValue(out lnTgtBin_c2);
				diStatusReg_c2.GetValue(out lnStatReg1_c2);
				//  Carousel 3
				diMotorFWC_c3.GetValue(out lbMoveFWD_c3);
				diMotorREV_c3.GetValue(out lbMoveREV_c3);
				diMotorSPD0_c3.GetValue(out lbMoveSPD0_c3);
				diMotorSPD1_c3.GetValue(out lbMoveSPD1_c3);
				diNumOfBins_c3.GetValue(out lnNumBins_c3);
				diCurrentBin_c3.GetValue(out lnCurBin_c3);
				diTargetBin_c3.GetValue(out lnTgtBin_c3);
				diStatusReg_c3.GetValue(out lnStatReg1_c3);
				//  Carousel 4
				diMotorFWC_c4.GetValue(out lbMoveFWD_c4);
				diMotorREV_c4.GetValue(out lbMoveREV_c4);
				diMotorSPD0_c4.GetValue(out lbMoveSPD0_c4);
				diMotorSPD1_c4.GetValue(out lbMoveSPD1_c4);
				diNumOfBins_c4.GetValue(out lnNumBins_c4);
				diCurrentBin_c4.GetValue(out lnCurBin_c4);
				diTargetBin_c4.GetValue(out lnTgtBin_c4);
				diStatusReg_c4.GetValue(out lnStatReg1_c4);
				//  VFDs
				diVFDRunStatus_c1.GetValue(out lnVFDRunStat_c1);
				diVFDRunStatus_c2.GetValue(out lnVFDRunStat_c2);
				diVFDRunStatus_c3.GetValue(out lnVFDRunStat_c3);
				diVFDRunStatus_c4.GetValue(out lnVFDRunStat_c4);
				diVFDFault1Status_c1.GetValue(out lnVFDFaultStat_c1);
				diVFDFault1Status_c2.GetValue(out lnVFDFaultStat_c2);
				diVFDFault1Status_c3.GetValue(out lnVFDFaultStat_c3);
				diVFDFault1Status_c4.GetValue(out lnVFDFaultStat_c4);
			}
			catch
			{
				return false;
			}

			return true;
		}
		private void UpdateForm()
		{
			//  Update Form
			//  Carousel 1
			txtNumBins_c1.Text		= $"{lnNumBins_c1}";
			txtCurrentBin_c1.Text	= $"{lnCurBin_c1}";
			txtTargetBin_c1.Text	= (lnTgtBin_c1 != 0) ? $"{lnTgtBin_c1}" : $"{lnNumBins_c1}";
			txtStatReg1_c1.Text		= $"{lnStatReg1_c1}";

			//  Carousel 2
			txtNumBins_c2.Text		= lnNumBins_c2.ToString();
			txtCurrentBin_c2.Text	= lnCurBin_c2.ToString();
			txtTargetBin_c2.Text	= (lnTgtBin_c2 != 0) ? $"{lnTgtBin_c2}" : $"{lnNumBins_c2}";
			txtStatReg1_c2.Text		= lnStatReg1_c2.ToString();

			//  Carousel 3
			txtNumBins_c3.Text		= lnNumBins_c3.ToString();
			txtCurrentBin_c3.Text	= lnCurBin_c3.ToString();
			txtTargetBin_c3.Text	= (lnTgtBin_c3 != 0) ? $"{lnTgtBin_c3}" : $"{lnNumBins_c3}";
			txtStatReg1_c3.Text		= $"{lnStatReg1_c3}";

			//  Carousel 4
			txtNumBins_c4.Text		= $"{lnNumBins_c4}";
			txtCurrentBin_c4.Text	= $"{lnCurBin_c4}";
			txtTargetBin_c4.Text	= (lnTgtBin_c4 != 0) ? $"{lnTgtBin_c4}" : $"{lnNumBins_c4}";
			txtStatReg1_c4.Text		= $"{lnStatReg1_c4}";

			//  Breakout Status Register 1
			//  Carousel 1
			lbSR1_Enabled_c1		= TestBit(lnStatReg1_c1,  0);
			lbSR1_Move_c1			= TestBit(lnStatReg1_c1,  1);
			lbSR1_Moving_c1			= TestBit(lnStatReg1_c1,  2);
			lbSR1_CW1_CCW0_c1		= TestBit(lnStatReg1_c1,  3);
			lbSR1_ManualMode_c1		= TestBit(lnStatReg1_c1,  4);
			lbSR1_EncoderSetup_c1	= TestBit(lnStatReg1_c1,  5);
			lbSR1_Homing_c1			= TestBit(lnStatReg1_c1,  6);
			lbSR1_AutoControl_c1	= TestBit(lnStatReg1_c1,  7);
			lbSR1_VFD_c1			= TestBit(lnStatReg1_c1,  8);
			lbSR1_SafetyCkt_c1		= TestBit(lnStatReg1_c1,  9);
			lbSR1_Ready_c1			= TestBit(lnStatReg1_c1, 10);
			//  Carousel 2
			lbSR1_Enabled_c2		= TestBit(lnStatReg1_c2,  0);
			lbSR1_Move_c2			= TestBit(lnStatReg1_c2,  1);
			lbSR1_Moving_c2			= TestBit(lnStatReg1_c2,  2);
			lbSR1_CW1_CCW0_c2		= TestBit(lnStatReg1_c2,  3);
			lbSR1_ManualMode_c2		= TestBit(lnStatReg1_c2,  4);
			lbSR1_EncoderSetup_c2	= TestBit(lnStatReg1_c2,  5);
			lbSR1_Homing_c2			= TestBit(lnStatReg1_c2,  6);
			lbSR1_AutoControl_c2	= TestBit(lnStatReg1_c2,  7);
			lbSR1_VFD_c2			= TestBit(lnStatReg1_c2,  8);
			lbSR1_SafetyCkt_c2		= TestBit(lnStatReg1_c2,  9);
			lbSR1_Ready_c2			= TestBit(lnStatReg1_c2, 10);
			//  Carousel 3
			lbSR1_Enabled_c3		= TestBit(lnStatReg1_c3,  0);
			lbSR1_Move_c3			= TestBit(lnStatReg1_c3,  1);
			lbSR1_Moving_c3			= TestBit(lnStatReg1_c3,  2);
			lbSR1_CW1_CCW0_c3		= TestBit(lnStatReg1_c3,  3);
			lbSR1_ManualMode_c3		= TestBit(lnStatReg1_c3,  4);
			lbSR1_EncoderSetup_c3	= TestBit(lnStatReg1_c3,  5);
			lbSR1_Homing_c3			= TestBit(lnStatReg1_c3,  6);
			lbSR1_AutoControl_c3	= TestBit(lnStatReg1_c3,  7);
			lbSR1_VFD_c3			= TestBit(lnStatReg1_c3,  8);
			lbSR1_SafetyCkt_c3		= TestBit(lnStatReg1_c3,  9);
			lbSR1_Ready_c3			= TestBit(lnStatReg1_c3, 10);
			//  Carousel 4
			lbSR1_Enabled_c4		= TestBit(lnStatReg1_c4,  0);
			lbSR1_Move_c4			= TestBit(lnStatReg1_c4,  1);
			lbSR1_Moving_c4			= TestBit(lnStatReg1_c4,  2);
			lbSR1_CW1_CCW0_c4		= TestBit(lnStatReg1_c4,  3);
			lbSR1_ManualMode_c4		= TestBit(lnStatReg1_c4,  4);
			lbSR1_EncoderSetup_c4	= TestBit(lnStatReg1_c4,  5);
			lbSR1_Homing_c4			= TestBit(lnStatReg1_c4,  6);
			lbSR1_AutoControl_c4	= TestBit(lnStatReg1_c4,  7);
			lbSR1_VFD_c4			= TestBit(lnStatReg1_c4,  8);
			lbSR1_SafetyCkt_c4		= TestBit(lnStatReg1_c4,  9);
			lbSR1_Ready_c4			= TestBit(lnStatReg1_c4, 10);
		}
		private void SetDefaultCarouselValues()
		{
			//  Carousel 1
			txtNumBins_c1.Text = "?";
			txtCurrentBin_c1.Text = "?";
			txtTargetBin_c1.Text = "?";
			txtStatReg1_c1.Text = "?";
			lbSR1_Enabled_c1 = false;
			lbSR1_Move_c1 = false;
			lbSR1_Moving_c1 = false;
			lbSR1_CW1_CCW0_c1 = false;
			lbSR1_ManualMode_c1 = false;
			lbSR1_EncoderSetup_c1 = false;
			lbSR1_Homing_c1 = false;
			lbSR1_AutoControl_c1 = false;
			lbSR1_VFD_c1 = false;
			lbSR1_SafetyCkt_c1 = false;
			lbSR1_Ready_c1 = false;
			lbMoveFWD_c1 = false;
			lbMoveREV_c1 = false;
			lbMoveSPD0_c1 = false;
			lbMoveSPD1_c1 = false;
			//  Carousel 2
			txtNumBins_c2.Text = "?";
			txtCurrentBin_c2.Text = "?";
			txtTargetBin_c2.Text = "?";
			txtStatReg1_c2.Text = "?";
			lbSR1_Enabled_c2 = false;
			lbSR1_Move_c2 = false;
			lbSR1_Moving_c2 = false;
			lbSR1_CW1_CCW0_c2 = false;
			lbSR1_ManualMode_c2 = false;
			lbSR1_EncoderSetup_c2 = false;
			lbSR1_Homing_c2 = false;
			lbSR1_AutoControl_c2 = false;
			lbSR1_VFD_c2 = false;
			lbSR1_SafetyCkt_c2 = false;
			lbSR1_Ready_c2 = false;
			lbMoveFWD_c2 = false;
			lbMoveREV_c2 = false;
			lbMoveSPD0_c2 = false;
			lbMoveSPD1_c2 = false;
			//  Carousel 3
			txtNumBins_c3.Text = "?";
			txtCurrentBin_c3.Text = "?";
			txtTargetBin_c3.Text = "?";
			txtStatReg1_c3.Text = "?";
			lbSR1_Enabled_c3 = false;
			lbSR1_Move_c3 = false;
			lbSR1_Moving_c3 = false;
			lbSR1_CW1_CCW0_c3 = false;
			lbSR1_ManualMode_c3 = false;
			lbSR1_EncoderSetup_c3 = false;
			lbSR1_Homing_c3 = false;
			lbSR1_AutoControl_c3 = false;
			lbSR1_VFD_c3 = false;
			lbSR1_SafetyCkt_c3 = false;
			lbSR1_Ready_c3 = false;
			lbMoveFWD_c3 = false;
			lbMoveREV_c3 = false;
			lbMoveSPD0_c3 = false;
			lbMoveSPD1_c3 = false;
			//  Carousel 4
			txtNumBins_c4.Text = "?";
			txtCurrentBin_c4.Text = "?";
			txtTargetBin_c4.Text = "?";
			txtStatReg1_c4.Text = "?";
			lbSR1_Enabled_c4 = false;
			lbSR1_Move_c4 = false;
			lbSR1_Moving_c4 = false;
			lbSR1_CW1_CCW0_c4 = false;
			lbSR1_ManualMode_c4 = false;
			lbSR1_EncoderSetup_c4 = false;
			lbSR1_Homing_c4 = false;
			lbSR1_AutoControl_c4 = false;
			lbSR1_VFD_c4 = false;
			lbSR1_SafetyCkt_c4 = false;
			lbSR1_Ready_c4 = false;
			lbMoveFWD_c4 = false;
			lbMoveREV_c4 = false;
			lbMoveSPD0_c4 = false;
			lbMoveSPD1_c4 = false;
		}

		private void tmrObserver_Tick(object sender, EventArgs e)
		{
			// Homing check
			HomingCheck_c1();
			HomingCheck_c2();
			HomingCheck_c3();
			HomingCheck_c4();

			// Encoder check
			EncoderCheck_c1();
			EncoderCheck_c2();
			EncoderCheck_c3();
			EncoderCheck_c4();

			// These errors come from TnD Read and TnD Write OCX that are no longer valid - DMILAN 6/12/22
			// Subs ReadTagsMM_c1() WriteTagsMM_c1() etc...
			// Original code was If Me.lbTndNTagReadMM1Stat_c1 <> ThinkAndDoSuccess or ... so this conversion was not correct to start with.
			//// Errors
			//if (lbTndNTagReadMM1Stat_c1	 ||
			//    lbTndNTagWriteMM4Stat_c1 ||
			//    lbTndNTagReadMM1Stat_c2	 ||
			//    lbTndNTagWriteMM4Stat_c2 ||
			//    lbTndNTagReadMM1Stat_c3	 ||
			//    lbTndNTagWriteMM4Stat_c3 ||
			//    lbTndNTagReadMM1Stat_c4	 ||
			//    lbTndNTagWriteMM4Stat_c4)
			//{
			//	lblCCFE.Visible = true;
			//}
			//else
			//{
			//	lblCCFE.Visible = false;

			//}

			// Man Mode State
			bool lbNotReady;
			lbNotReady = !lbSR1_Enabled_c1 ||
			             !lbSR1_Ready_c1 ||
			             !lbSR1_AutoControl_c1;
			if (lbManualMode_c1 && lbNotReady)
			{
				lbManualMode_c1 = false;
				chkManMode_c1.Checked = false;
				StopMM_c1();
			}
		}

		private void HomingCheck_c1()
		{
			if (lbHomingStart_c1 && !tmrHomingStart_c1.Enabled)
			{
				tmrHomingStart_c1.Enabled = true;
				lnRequestedBin_c1 = 0;
			}

			if (lbHomingStop_c1 && !tmrHomingStop_c1.Enabled)
			{
				tmrHomingStop_c1.Enabled = true;
				lnRequestedBin_c1 = 0;
			}
		}
		private void HomingCheck_c2()
		{
			if (lbHomingStart_c2 && !tmrHomingStart_c2.Enabled)
			{
				tmrHomingStart_c2.Enabled = true;
				lnRequestedBin_c2 = 0;
			}

			if (lbHomingStop_c2 && !tmrHomingStop_c2.Enabled)
			{
				tmrHomingStop_c2.Enabled = true;
				lnRequestedBin_c2 = 0;
			}
		}
		private void HomingCheck_c3()
		{
			if (lbHomingStart_c3 && !tmrHomingStart_c3.Enabled)
			{
				tmrHomingStart_c3.Enabled = true;
				lnRequestedBin_c3 = 0;
			}

			if (lbHomingStop_c3 && !tmrHomingStop_c3.Enabled)
			{
				tmrHomingStop_c3.Enabled = true;
				lnRequestedBin_c3 = 0;
			}
		}
		private void HomingCheck_c4()
		{
			if (lbHomingStart_c4 && !tmrHomingStart_c4.Enabled)
			{
				tmrHomingStart_c4.Enabled = true;
				lnRequestedBin_c4 = 0;
			}

			if (lbHomingStop_c4 && !tmrHomingStop_c4.Enabled)
			{
				tmrHomingStop_c4.Enabled = true;
				lnRequestedBin_c4 = 0;
			}
		}

		private void EncoderCheck_c1()
		{
			// Encoder setup check
			if (lbEncoderStart_c1 && !tmrEncoderStart_c1.Enabled)
			{
				tmrEncoderStart_c1.Enabled = true;
				lnRequestedBin_c1 = 0;
			}
			if (lbEncoderStop_c1 && !tmrEncoderStop_c1.Enabled)
			{
				tmrEncoderStop_c1.Enabled = true;
				lnRequestedBin_c1 = 0;
			}
		}
		private void EncoderCheck_c2()
		{
			// Encoder setup check
			if (lbEncoderStart_c2 && !tmrEncoderStart_c2.Enabled)
			{
				tmrEncoderStart_c2.Enabled = true;
				lnRequestedBin_c2 = 0;
			}
			if (lbEncoderStop_c2 && !tmrEncoderStop_c2.Enabled)
			{
				tmrEncoderStop_c2.Enabled = true;
				lnRequestedBin_c2 = 0;
			}
		}
		private void EncoderCheck_c3()
		{
			// Encoder setup check
			if (lbEncoderStart_c3 && !tmrEncoderStart_c3.Enabled)
			{
				tmrEncoderStart_c3.Enabled = true;
				lnRequestedBin_c3 = 0;
			}
			if (lbEncoderStop_c3 && !tmrEncoderStop_c3.Enabled)
			{
				tmrEncoderStop_c3.Enabled = true;
				lnRequestedBin_c3 = 0;
			}
		}
		private void EncoderCheck_c4()
		{
			// Encoder setup check
			if (lbEncoderStart_c4 && !tmrEncoderStart_c4.Enabled)
			{
				tmrEncoderStart_c4.Enabled = true;
				lnRequestedBin_c4 = 0;
			}
			if (lbEncoderStop_c4 && !tmrEncoderStop_c4.Enabled)
			{
				tmrEncoderStop_c4.Enabled = true;
				lnRequestedBin_c4 = 0;
			}
		}

		private void StatReg1Breakout_c1()
		{
			lblSR1_0_c1.BackColor  = lbSR1_Enabled_c1		? Color.Goldenrod : Color.Transparent;
			lblSR1_1_c1.BackColor  = lbSR1_Move_c1			? Color.Goldenrod : Color.Transparent;
			lblSR1_2_c1.BackColor  = lbSR1_Moving_c1		? Color.Goldenrod : Color.Transparent;
			lblSR1_3_c1.BackColor  = lbSR1_CW1_CCW0_c1		? Color.Goldenrod : Color.Transparent;
			lblSR1_4_c1.BackColor  = lbSR1_ManualMode_c1	? Color.Goldenrod : Color.Transparent;
			lblSR1_5_c1.BackColor  = lbSR1_EncoderSetup_c1	? Color.Goldenrod : Color.Transparent;
			lblSR1_6_c1.BackColor  = lbSR1_Homing_c1		? Color.Goldenrod : Color.Transparent;
			lblSR1_7_c1.BackColor  = lbSR1_AutoControl_c1	? Color.Goldenrod : Color.Transparent;
			lblSR1_8_c1.BackColor  = lbSR1_VFD_c1			? Color.Goldenrod : Color.Transparent;
			lblSR1_9_c1.BackColor  = lbSR1_SafetyCkt_c1		? Color.Goldenrod : Color.Transparent;
			lblSR1_10_c1.BackColor = lbSR1_Ready_c1			? Color.Goldenrod : Color.Transparent;
		}
		private void StatReg1Breakout_c2()
		{
			lblSR1_0_c2.BackColor  = lbSR1_Enabled_c2		? Color.Goldenrod : Color.Transparent;
			lblSR1_1_c2.BackColor  = lbSR1_Move_c2			? Color.Goldenrod : Color.Transparent;
			lblSR1_2_c2.BackColor  = lbSR1_Moving_c2		? Color.Goldenrod : Color.Transparent;
			lblSR1_3_c2.BackColor  = lbSR1_CW1_CCW0_c2		? Color.Goldenrod : Color.Transparent;
			lblSR1_4_c2.BackColor  = lbSR1_ManualMode_c2	? Color.Goldenrod : Color.Transparent;
			lblSR1_5_c2.BackColor  = lbSR1_EncoderSetup_c2	? Color.Goldenrod : Color.Transparent;
			lblSR1_6_c2.BackColor  = lbSR1_Homing_c2		? Color.Goldenrod : Color.Transparent;
			lblSR1_7_c2.BackColor  = lbSR1_AutoControl_c2	? Color.Goldenrod : Color.Transparent;
			lblSR1_8_c2.BackColor  = lbSR1_VFD_c2			? Color.Goldenrod : Color.Transparent;
			lblSR1_9_c2.BackColor  = lbSR1_SafetyCkt_c2		? Color.Goldenrod : Color.Transparent;
			lblSR1_10_c2.BackColor = lbSR1_Ready_c2			? Color.Goldenrod : Color.Transparent;
		}
		private void StatReg1Breakout_c3()
		{
			lblSR1_0_c3.BackColor  = lbSR1_Enabled_c3		? Color.Goldenrod : Color.Transparent;
			lblSR1_1_c3.BackColor  = lbSR1_Move_c3			? Color.Goldenrod : Color.Transparent;
			lblSR1_2_c3.BackColor  = lbSR1_Moving_c3		? Color.Goldenrod : Color.Transparent;
			lblSR1_3_c3.BackColor  = lbSR1_CW1_CCW0_c3		? Color.Goldenrod : Color.Transparent;
			lblSR1_4_c3.BackColor  = lbSR1_ManualMode_c3	? Color.Goldenrod : Color.Transparent;
			lblSR1_5_c3.BackColor  = lbSR1_EncoderSetup_c3	? Color.Goldenrod : Color.Transparent;
			lblSR1_6_c3.BackColor  = lbSR1_Homing_c3		? Color.Goldenrod : Color.Transparent;
			lblSR1_7_c3.BackColor  = lbSR1_AutoControl_c3	? Color.Goldenrod : Color.Transparent;
			lblSR1_8_c3.BackColor  = lbSR1_VFD_c3			? Color.Goldenrod : Color.Transparent;
			lblSR1_9_c3.BackColor  = lbSR1_SafetyCkt_c3		? Color.Goldenrod : Color.Transparent;
			lblSR1_10_c3.BackColor = lbSR1_Ready_c3			? Color.Goldenrod : Color.Transparent;
		}
		private void StatReg1Breakout_c4()
		{
			lblSR1_0_c4.BackColor  = lbSR1_Enabled_c4		? Color.Goldenrod : Color.Transparent;
			lblSR1_1_c4.BackColor  = lbSR1_Move_c4			? Color.Goldenrod : Color.Transparent;
			lblSR1_2_c4.BackColor  = lbSR1_Moving_c4		? Color.Goldenrod : Color.Transparent;
			lblSR1_3_c4.BackColor  = lbSR1_CW1_CCW0_c4		? Color.Goldenrod : Color.Transparent;
			lblSR1_4_c4.BackColor  = lbSR1_ManualMode_c4	? Color.Goldenrod : Color.Transparent;
			lblSR1_5_c4.BackColor  = lbSR1_EncoderSetup_c4	? Color.Goldenrod : Color.Transparent;
			lblSR1_6_c4.BackColor  = lbSR1_Homing_c4		? Color.Goldenrod : Color.Transparent;
			lblSR1_7_c4.BackColor  = lbSR1_AutoControl_c4	? Color.Goldenrod : Color.Transparent;
			lblSR1_8_c4.BackColor  = lbSR1_VFD_c4			? Color.Goldenrod : Color.Transparent;
			lblSR1_9_c4.BackColor  = lbSR1_SafetyCkt_c4		? Color.Goldenrod : Color.Transparent;
			lblSR1_10_c4.BackColor = lbSR1_Ready_c4			? Color.Goldenrod : Color.Transparent;
		}

		private void FlagsBreakout_c1()
		{
			lblMoveFWD_c1.BackColor  = lbMoveFWD_c1  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c1.BackColor  = lbMoveREV_c1	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c1.BackColor = lbMoveSPD0_c1 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c1.BackColor = lbMoveSPD1_c1 ? Color.Goldenrod : Color.Transparent;
		}
		private void FlagsBreakout_c2()
		{
			lblMoveFWD_c2.BackColor  = lbMoveFWD_c2  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c2.BackColor  = lbMoveREV_c2	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c2.BackColor = lbMoveSPD0_c2 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c2.BackColor = lbMoveSPD1_c2 ? Color.Goldenrod : Color.Transparent;
		}
		private void FlagsBreakout_c3()
		{
			lblMoveFWD_c3.BackColor  = lbMoveFWD_c3  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c3.BackColor  = lbMoveREV_c3	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c3.BackColor = lbMoveSPD0_c3 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c3.BackColor = lbMoveSPD1_c3 ? Color.Goldenrod : Color.Transparent;
		}
		private void FlagsBreakout_c4()
		{
			lblMoveFWD_c4.BackColor  = lbMoveFWD_c4  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c4.BackColor  = lbMoveREV_c4	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c4.BackColor = lbMoveSPD0_c4 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c4.BackColor = lbMoveSPD1_c4 ? Color.Goldenrod : Color.Transparent;
		}

		private void ManModeButtonColors_c1()
		{
			if (lbFWD_c1)  btnFWD_c1.BackColor  = Color.Lime; else btnFWD_c1.UseVisualStyleBackColor = true;
			if (lbREV_c1)  btnREV_c1.BackColor  = Color.Lime; else btnREV_c1.UseVisualStyleBackColor = true;
			if (lbSTOP_c1) btnSTOP_c1.BackColor = Color.Red;  else btnSTOP_c1.UseVisualStyleBackColor = true;
			//if (lbSR1_Homing_c1 && lbHomingStartLatch_c1)
			//	btnHomingStart_c1.BackColor = Color.Lime;
			//else
			//	btnHomingStart_c1.UseVisualStyleBackColor = true;
		}
		private void ManModeButtonColors_c2()
		{
			if (lbFWD_c2)  btnFWD_c2.BackColor  = Color.Lime; else btnFWD_c2.UseVisualStyleBackColor = true;
			if (lbREV_c2)  btnREV_c2.BackColor  = Color.Lime; else btnREV_c2.UseVisualStyleBackColor = true;
			if (lbSTOP_c2) btnSTOP_c2.BackColor = Color.Red;  else btnSTOP_c2.UseVisualStyleBackColor = true;
			//if (lbSR1_Homing_c2 && lbHomingStartLatch_c2)
			//	btnHomingStart_c2.BackColor = Color.Lime;
			//else
			//	btnHomingStart_c2.UseVisualStyleBackColor = true;
		}
		private void ManModeButtonColors_c3()
		{
			if (lbFWD_c3)  btnFWD_c3.BackColor  = Color.Lime; else btnFWD_c3.UseVisualStyleBackColor = true;
			if (lbREV_c3)  btnREV_c3.BackColor  = Color.Lime; else btnREV_c3.UseVisualStyleBackColor = true;
			if (lbSTOP_c3) btnSTOP_c3.BackColor = Color.Red;  else btnSTOP_c3.UseVisualStyleBackColor = true;
			//if (lbSR1_Homing_c3 && lbHomingStartLatch_c3)
			//	btnHomingStart_c3.BackColor = Color.Lime;
			//else
			//	btnHomingStart_c3.UseVisualStyleBackColor = true;
		}
		private void ManModeButtonColors_c4()
		{
			if (lbFWD_c4)  btnFWD_c4.BackColor  = Color.Lime; else btnFWD_c4.UseVisualStyleBackColor = true;
			if (lbREV_c4)  btnREV_c4.BackColor  = Color.Lime; else btnREV_c4.UseVisualStyleBackColor = true;
			if (lbSTOP_c4) btnSTOP_c4.BackColor = Color.Red;  else btnSTOP_c4.UseVisualStyleBackColor = true;
			//if (lbSR1_Homing_c4 && lbHomingStartLatch_c4)
			//	btnHomingStart_c4.BackColor = Color.Lime;
			//else
			//	btnHomingStart_c4.UseVisualStyleBackColor = true;
		}

		private void JogButtonColors()
		{
			// Carousel 1
			if (lbJogF_c1) btnJogF_c1.BackColor = Color.Lime; else btnJogF_c1.UseVisualStyleBackColor = true;
			if (lbJogR_c1) btnJogR_c1.BackColor = Color.Lime; else btnJogR_c1.UseVisualStyleBackColor = true;
			// Carousel 2
			if (lbJogF_c2) btnJogF_c2.BackColor = Color.Lime; else btnJogF_c2.UseVisualStyleBackColor = true;
			if (lbJogR_c2) btnJogR_c2.BackColor = Color.Lime; else btnJogR_c2.UseVisualStyleBackColor = true;
			// Carousel 3
			if (lbJogF_c3) btnJogF_c3.BackColor = Color.Lime; else btnJogF_c3.UseVisualStyleBackColor = true;
			if (lbJogR_c3) btnJogR_c3.BackColor = Color.Lime; else btnJogR_c3.UseVisualStyleBackColor = true;
			// Carousel 4
			if (lbJogF_c4) btnJogF_c4.BackColor = Color.Lime; else btnJogF_c4.UseVisualStyleBackColor = true;
			if (lbJogR_c4) btnJogR_c4.BackColor = Color.Lime; else btnJogR_c4.UseVisualStyleBackColor = true;
		}

		private void btnRetrieve_c1_Click(object sender, EventArgs e)
		{
			// Request the carousel to move to the bin entered in the text box.
			RetrievePart_c1();
		}
		private void RetrievePart_c1()
		{
			bool lbError =  !lbSR1_Enabled_c1 || 
							!lbSR1_Ready_c1 || 
							lbSR1_ManualMode_c1 || 
							lbSR1_Homing_c1 ||
							lbSR1_EncoderSetup_c1;

			if (int.Parse(txtReqBin_c1.Text) <= 0 || 
				int.Parse(txtReqBin_c1.Text) > lnNumBins_c1)
			{
				MessageBox.Show("Location is out of bounds.", "Movement Error",
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtReqBin_c1.Text = "0";
				lnRequestedBin_c1 = 0;
			}
			else if (lbError)
			{
				MessageBox.Show("Carousel is not ready for move.", "Attention",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				// Sets the value of the requested bin and starts a timer that when timed out will reset the value.
				lnRequestedBin_c1 = int.Parse(txtReqBin_c1.Text);
				tmrReqBin_c1.Enabled = true;
			}
			SetFocusReqBin_c1();
		}
		private void btnRetrieve_c2_Click(object sender, EventArgs e)
		{
			// Request the carousel to move to the bin entered in the text box.
			RetrievePart_c2();
		}
		private void RetrievePart_c2()
		{
			bool lbError = !lbSR1_Enabled_c2 ||
			               !lbSR1_Ready_c2 ||
			               lbSR1_ManualMode_c2 ||
			               lbSR1_Homing_c2 ||
			               lbSR1_EncoderSetup_c2;

			if (int.Parse(txtReqBin_c2.Text) <= 0 ||
			    int.Parse(txtReqBin_c2.Text) > lnNumBins_c2)
			{
				MessageBox.Show("Location is out of bounds.", "Movement Error",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtReqBin_c2.Text = "0";
				lnRequestedBin_c2 = 0;
			}
			else if (lbError)
			{
				MessageBox.Show("Carousel is not ready for move.", "Attention",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				// Sets the value of the requested bin and starts a timer that when timed out will reset the value.
				lnRequestedBin_c2 = int.Parse(txtReqBin_c2.Text);
				tmrReqBin_c2.Enabled = true;
			}
			SetFocusReqBin_c2();
		}
		private void btnRetrieve_c3_Click(object sender, EventArgs e)
		{
			// Request the carousel to move to the bin entered in the text box.
			RetrievePart_c3();
		}
		private void RetrievePart_c3()
		{
			bool lbError = !lbSR1_Enabled_c3 ||
			               !lbSR1_Ready_c3 ||
			               lbSR1_ManualMode_c3 ||
			               lbSR1_Homing_c3 ||
			               lbSR1_EncoderSetup_c3;

			if (int.Parse(txtReqBin_c3.Text) <= 0 ||
			    int.Parse(txtReqBin_c3.Text) > lnNumBins_c3)
			{
				MessageBox.Show("Location is out of bounds.", "Movement Error",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtReqBin_c3.Text = "0";
				lnRequestedBin_c3 = 0;
			}
			else if (lbError)
			{
				MessageBox.Show("Carousel is not ready for move.", "Attention",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				// Sets the value of the requested bin and starts a timer that when timed out will reset the value.
				lnRequestedBin_c3 = int.Parse(txtReqBin_c3.Text);
				tmrReqBin_c3.Enabled = true;
			}
			SetFocusReqBin_c3();
		}
		private void btnRetrieve_c4_Click(object sender, EventArgs e)
		{
			// Request the carousel to move to the bin entered in the text box.
			RetrievePart_c4();
		}
		private void RetrievePart_c4()
		{
			bool lbError = !lbSR1_Enabled_c4 ||
			               !lbSR1_Ready_c4 ||
			               lbSR1_ManualMode_c4 ||
			               lbSR1_Homing_c4 ||
			               lbSR1_EncoderSetup_c4;

			if (int.Parse(txtReqBin_c4.Text) <= 0 ||
			    int.Parse(txtReqBin_c4.Text) > lnNumBins_c4)
			{
				MessageBox.Show("Location is out of bounds.", "Movement Error",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtReqBin_c4.Text = "0";
				lnRequestedBin_c4 = 0;
			}
			else if (lbError)
			{
				MessageBox.Show("Carousel is not ready for move.", "Attention",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				// Sets the value of the requested bin and starts a timer that when timed out will reset the value.
				lnRequestedBin_c4 = int.Parse(txtReqBin_c4.Text);
				tmrReqBin_c4.Enabled = true;
			}
			SetFocusReqBin_c4();
		}

		private void SetFocusReqBin_c1()
		{
			txtReqBin_c1.Focus();
			txtReqBin_c1.SelectAll();
		}
		private void SetFocusReqBin_c2()
		{
			txtReqBin_c2.Focus();
			txtReqBin_c2.SelectAll();
		}
		private void SetFocusReqBin_c3()
		{
			txtReqBin_c3.Focus();
			txtReqBin_c3.SelectAll();
		}
		private void SetFocusReqBin_c4()
		{
			txtReqBin_c4.Focus();
			txtReqBin_c4.SelectAll();
		}

		private void tmrReqBin_c1_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c1.Enabled = False
			lnRequestedBin_c1 = 0;
		}
		private void tmrReqBin_c2_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c2.Enabled = False
			lnRequestedBin_c2 = 0;
		}
		private void tmrReqBin_c3_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c3.Enabled = False
			lnRequestedBin_c3 = 0;
		}
		private void tmrReqBin_c4_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c4.Enabled = False
			lnRequestedBin_c4 = 0;
		}


		private void btnHomingStart_c1_Click(object sender, EventArgs e)
		{
			if (!lbHomingStart_c1 && !lbSR1_Homing_c1)
				SetBinPosition_c1();
			SetFocusReqBin_c1();
		}
		private void btnHomingStop_c1_Click(object sender, EventArgs e)
		{
			if (!lbManualMode_c1)
				lbHomingStop_c1 = true;
			SetFocusReqBin_c1();
		}
		private void SetBinPosition_c1()
		{
			if (!lbManualMode_c1 && !lbSR1_ManualMode_c1)
			{
				if (int.Parse(txtSetBinPos_c1.Text) <= 0 ||
				    int.Parse(txtSetBinPos_c1.Text) > lnNumBins_c1)
				{
					MessageBox.Show("Location is not valid.", "Setup Error",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtSetBinPos_c1.Text = "0";
					lnSetBinPos_c1 = 0;
				}
				else
				{
					lnSetBinPos_c1 = int.Parse(txtSetBinPos_c1.Text);
					lbHomingStart_c1 = true;
				}
			}
			SetFocusReqBin_c1();
		}
		private void HomingSetupColors_c1()
		{
			if (lbSR1_Homing_c1)
				btnHomingStart_c1.BackColor = Color.Lime;
			else
				btnHomingStart_c1.UseVisualStyleBackColor = true;
		}
		private void tmrHomingStart_c1_Tick(object sender, EventArgs e)
		{
			lbHomingStart_c1 = false;
			tmrHomingStart_c1.Enabled = false;
		}
		private void tmrHomingStop_c1_Tick(object sender, EventArgs e)
		{
			lbHomingStop_c1 = false;
			tmrHomingStop_c1.Enabled = false;
		}

		private void btnHomingStart_c2_Click(object sender, EventArgs e)
		{
			if (!lbHomingStart_c2 && !lbSR1_Homing_c2)
				SetBinPosition_c2();
			SetFocusReqBin_c2();
		}
		private void btnHomingStop_c2_Click(object sender, EventArgs e)
		{
			if (!lbManualMode_c2)
				lbHomingStop_c2 = true;
			SetFocusReqBin_c2();
		}
		private void SetBinPosition_c2()
		{
			if (!lbManualMode_c2 && !lbSR1_ManualMode_c2)
			{
				if (int.Parse(txtSetBinPos_c2.Text) <= 0 ||
				    int.Parse(txtSetBinPos_c2.Text) > lnNumBins_c2)
				{
					MessageBox.Show("Location is not valid.", "Setup Error",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtSetBinPos_c2.Text = "0";
					lnSetBinPos_c2 = 0;
				}
				else
				{
					lnSetBinPos_c2 = int.Parse(txtSetBinPos_c2.Text);
					lbHomingStart_c2 = true;
				}
			}
			SetFocusReqBin_c2();
		}
		private void HomingSetupColors_c2()
		{
			if (lbSR1_Homing_c2)
				btnHomingStart_c2.BackColor = Color.Lime;
			else
				btnHomingStart_c2.UseVisualStyleBackColor = true;
		}
		private void tmrHomingStart_c2_Tick(object sender, EventArgs e)
		{
			lbHomingStart_c2 = false;
			tmrHomingStart_c2.Enabled = false;
		}
		private void tmrHomingStop_c2_Tick(object sender, EventArgs e)
		{
			lbHomingStop_c2 = false;
			tmrHomingStop_c2.Enabled = false;
		}
		
		private void btnHomingStart_c3_Click(object sender, EventArgs e)
		{
			if (!lbHomingStart_c3 && !lbSR1_Homing_c3)
				SetBinPosition_c3();
			SetFocusReqBin_c3();
		}
		private void btnHomingStop_c3_Click(object sender, EventArgs e)
		{
			if (!lbManualMode_c3)
				lbHomingStop_c3 = true;
			SetFocusReqBin_c3();
		}
		private void SetBinPosition_c3()
		{
			if (!lbManualMode_c3 && !lbSR1_ManualMode_c3)
			{
				if (int.Parse(txtSetBinPos_c3.Text) <= 0 ||
				    int.Parse(txtSetBinPos_c3.Text) > lnNumBins_c3)
				{
					MessageBox.Show("Location is not valid.", "Setup Error",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtSetBinPos_c3.Text = "0";
					lnSetBinPos_c3 = 0;
				}
				else
				{
					lnSetBinPos_c3 = int.Parse(txtSetBinPos_c3.Text);
					lbHomingStart_c3 = true;
				}
			}
			SetFocusReqBin_c3();
		}
		private void HomingSetupColors_c3()
		{
			if (lbSR1_Homing_c3)
				btnHomingStart_c3.BackColor = Color.Lime;
			else
				btnHomingStart_c3.UseVisualStyleBackColor = true;
		}
		private void tmrHomingStart_c3_Tick(object sender, EventArgs e)
		{
			lbHomingStart_c3 = false;
			tmrHomingStart_c3.Enabled = false;
		}
		private void tmrHomingStop_c3_Tick(object sender, EventArgs e)
		{
			lbHomingStop_c3 = false;
			tmrHomingStop_c3.Enabled = false;
		}

		private void btnHomingStart_c4_Click(object sender, EventArgs e)
		{
			if (!lbHomingStart_c4 && !lbSR1_Homing_c4)
				SetBinPosition_c4();
			SetFocusReqBin_c4();
		}
		private void btnHomingStop_c4_Click(object sender, EventArgs e)
		{
			if (!lbManualMode_c4)
				lbHomingStop_c4 = true;
			SetFocusReqBin_c4();
		}
		private void SetBinPosition_c4()
		{
			if (!lbManualMode_c4 && !lbSR1_ManualMode_c4)
			{
				if (int.Parse(txtSetBinPos_c4.Text) <= 0 ||
				    int.Parse(txtSetBinPos_c4.Text) > lnNumBins_c4)
				{
					MessageBox.Show("Location is not valid.", "Setup Error",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtSetBinPos_c4.Text = "0";
					lnSetBinPos_c4 = 0;
				}
				else
				{
					lnSetBinPos_c4 = int.Parse(txtSetBinPos_c4.Text);
					lbHomingStart_c4 = true;
				}
			}
			SetFocusReqBin_c4();
		}
		private void HomingSetupColors_c4()
		{
			if (lbSR1_Homing_c4)
				btnHomingStart_c4.BackColor = Color.Lime;
			else
				btnHomingStart_c4.UseVisualStyleBackColor = true;
		}
		private void tmrHomingStart_c4_Tick(object sender, EventArgs e)
		{
			lbHomingStart_c4 = false;
			tmrHomingStart_c4.Enabled = false;
		}
		private void tmrHomingStop_c4_Tick(object sender, EventArgs e)
		{
			lbHomingStop_c4 = false;
			tmrHomingStop_c4.Enabled = false;
		}

		private void ManualModeStartup_c1()
		{
			lbFWD_c1 = false;
			lbREV_c1 = false;
			lbSTOP_c1 = true;
			lbJogF_c1 = false;
			lbJogR_c1 = false;
		}
		private void ManualModeStartup_c2()
		{
			lbFWD_c2 = false;
			lbREV_c2 = false;
			lbSTOP_c2 = true;
			lbJogF_c2 = false;
			lbJogR_c2 = false;
		}
		private void ManualModeStartup_c3()
		{
			lbFWD_c3 = false;
			lbREV_c3 = false;
			lbSTOP_c3 = true;
			lbJogF_c3 = false;
			lbJogR_c3 = false;
		}
		private void ManualModeStartup_c4()
		{
			lbFWD_c4 = false;
			lbREV_c4 = false;
			lbSTOP_c4 = true;
			lbJogF_c4 = false;
			lbJogR_c4 = false;
		}

		private void ReadTagsMM_c1()
		{
			// Read tags
			//lbTndNTagReadMM1Stat_c1 = AxTndNTagReadMM1_c1.Read();
			try
			{
				diJOGF_button_c1.GetValue(out lbFWD_c1);
				diJOGR_button_c1.GetValue(out lbREV_c1);
				diSTOP_button_c1.GetValue(out lbSTOP_c1);
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c1");
			}
		}
		private void WriteTagsMM_c1()
		{
			// Write tags
			diJOGF_button_c1.SetValue(lbJogF_c1);
			diJOGR_button_c1.SetValue(lbJogR_c1);
			//lbTndNTagWriteMM4Stat_c1 = true;
		}
		private void ReadTagsMM_c2()
		{
			// Read tags
			//lbTndNTagReadMM1Stat_c2 = AxTndNTagReadMM1_c2.Read();
			try
			{
				diJOGF_button_c2.GetValue(out lbFWD_c2);
				diJOGR_button_c2.GetValue(out lbREV_c2);
				diSTOP_button_c2.GetValue(out lbSTOP_c2);
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c2");
			}
		}
		private void WriteTagsMM_c2()
		{
			// Write tags
			diJOGF_button_c2.SetValue(lbJogF_c2);
			diJOGR_button_c2.SetValue(lbJogR_c2);
			//lbTndNTagWriteMM4Stat_c2 = true;
		}
		private void ReadTagsMM_c3()
		{
			// Read tags
			// lbTndNTagReadMM1Stat_c3 = AxTndNTagReadMM1_c3.Read();
			try
			{
				diJOGF_button_c3.GetValue(out lbFWD_c3);
				diJOGR_button_c3.GetValue(out lbREV_c3);
				diSTOP_button_c3.GetValue(out lbSTOP_c3);
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c3");
			}
		}
		private void WriteTagsMM_c3()
		{
			// Write tags
			diJOGF_button_c3.SetValue(lbJogF_c3);
			diJOGR_button_c3.SetValue(lbJogR_c3);
			//lbTndNTagWriteMM4Stat_c3 = true;
		}
		private void ReadTagsMM_c4()
		{
			// Read tags
			// lbTndNTagReadMM1Stat_c4 = AxTndNTagReadMM1_c4.Read();
			try
			{
				diJOGF_button_c4.GetValue(out lbFWD_c4);
				diJOGR_button_c4.GetValue(out lbREV_c4);
				diSTOP_button_c4.GetValue(out lbSTOP_c4);
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c4");
			}
		}
		private void WriteTagsMM_c4()
		{
			// Write tags
			diJOGF_button_c4.SetValue(lbJogF_c4);
			diJOGR_button_c4.SetValue(lbJogR_c4);
			//lbTndNTagWriteMM4Stat_c4 = true;
		}

		private void btnFWD_c1_Click(object sender, EventArgs a)
		{
			ForwardMM_c1();
			SetFocusReqBin_c1();
		}
		private void btnSTOP_c1_Click(object sender, EventArgs e)
		{
			StopMM_c1();
			SetFocusReqBin_c1();
		}
		private void btnREV_c1_Click(object sender, EventArgs e)
		{
			ReverseMM_c1();
			SetFocusReqBin_c1();
		}
		private void ForwardMM_c1()
		{
			if (!lbREV_c1)
			{
				// Write tags
				diFWD_button_c1.SetValue(true);
				//lbTndNTagWriteMM1Stat_c1 = true;
			}
		}
		private void ReverseMM_c1()
		{
			if (!lbFWD_c1)
			{
				// Write tags
				diREV_button_c1.SetValue(true);
				//lbTndNTagWriteMM2Stat_c1 = true;
			}
		}
		private void StopMM_c1()
		{
			// Write tags
			try
			{
				diSTOP_button_c1.SetValue(true);
				//lbTndNTagWriteMM3Stat_c1 = true;
			}
			catch
			{
			}
		}

		private void btnFWD_c2_Click(object sender, EventArgs a)
		{
			ForwardMM_c2();
			SetFocusReqBin_c2();
		}
		private void btnSTOP_c2_Click(object sender, EventArgs e)
		{
			StopMM_c2();
			SetFocusReqBin_c2();
		}
		private void btnREV_c2_Click(object sender, EventArgs e)
		{
			ReverseMM_c2();
			SetFocusReqBin_c2();
		}
		private void ForwardMM_c2()
		{
			if (!lbREV_c2)
			{
				// Write tags
				diFWD_button_c2.SetValue(true);
				//lbTndNTagWriteMM1Stat_c2 = true;
			}
		}
		private void ReverseMM_c2()
		{
			if (!lbFWD_c2)
			{
				// Write tags
				diREV_button_c2.SetValue(true);
				//lbTndNTagWriteMM2Stat_c2 = true;
			}
		}
		private void StopMM_c2()
		{
			try
			{
				// Write tags
				diSTOP_button_c2.SetValue(true);
				//lbTndNTagWriteMM3Stat_c2 = true;
			}
			catch
			{
			}
		}

		private void btnFWD_c3_Click(object sender, EventArgs a)
		{
			ForwardMM_c3();
			SetFocusReqBin_c3();
		}
		private void btnSTOP_c3_Click(object sender, EventArgs e)
		{
			StopMM_c3();
			SetFocusReqBin_c3();
		}
		private void btnREV_c3_Click(object sender, EventArgs e)
		{
			ReverseMM_c3();
			SetFocusReqBin_c3();
		}
		private void ForwardMM_c3()
		{
			if (!lbREV_c3)
			{
				// Write tags
				diFWD_button_c3.SetValue(true);
				//lbTndNTagWriteMM1Stat_c3 = true;
			}
		}
		private void ReverseMM_c3()
		{
			if (!lbFWD_c3)
			{
				// Write tags
				diREV_button_c3.SetValue(true);
				//lbTndNTagWriteMM2Stat_c3 = true;
			}
		}
		private void StopMM_c3()
		{
			try
			{
				// Write tags
				diSTOP_button_c3.SetValue(true);
				//lbTndNTagWriteMM3Stat_c3 = true;
			}
			catch
			{
			}
		}

		private void btnFWD_c4_Click(object sender, EventArgs a)
		{
			ForwardMM_c4();
			SetFocusReqBin_c4();
		}
		private void btnSTOP_c4_Click(object sender, EventArgs e)
		{
			StopMM_c4();
			SetFocusReqBin_c4();
		}
		private void btnREV_c4_Click(object sender, EventArgs e)
		{
			ReverseMM_c4();
			SetFocusReqBin_c4();
		}
		private void ForwardMM_c4()
		{
			if (!lbREV_c4)
			{
				// Write tags
				diFWD_button_c4.SetValue(true);
				//lbTndNTagWriteMM1Stat_c4 = true;
			}
		}
		private void ReverseMM_c4()
		{
			if (!lbFWD_c4)
			{
				// Write tags
				diREV_button_c4.SetValue(true);
				//lbTndNTagWriteMM2Stat_c4 = true;
			}
		}
		private void StopMM_c4()
		{
			try
			{
				// Write tags
				diSTOP_button_c4.SetValue(true);
				//lbTndNTagWriteMM3Stat_c4 = true;
			}
			catch
			{
			}
		}

		private void btnJogF_c1_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c1 = true;
			lbJogR_c1 = false;
		}
		private void btnJogF_c1_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c1 = false;
			lbJogR_c1 = false;
		}
		private void btnJogR_c1_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c1 = false;
			lbJogR_c1 = true;
		}
		private void btnJogR_c1_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c1 = false;
			lbJogR_c1 = false;
		}
		private void chkManMode_c1_CheckedChanged(object sender, MouseEventArgs e)
		{
			if (!lbSR1_Homing_c1 && !lbSR1_Move_c1)
			{
				lbManualMode_c1 = !lbManualMode_c1;
				if (!lbManualMode_c1)
					StopMM_c1();
				else
					chkManMode_c1.Checked = false;
			}
		}

		private void btnJogF_c2_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c2 = true;
			lbJogR_c2 = false;
		}
		private void btnJogF_c2_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c2 = false;
			lbJogR_c2 = false;
		}
		private void btnJogR_c2_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c2 = false;
			lbJogR_c2 = true;
		}
		private void btnJogR_c2_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c2 = false;
			lbJogR_c2 = false;
		}
		private void chkManMode_c2_CheckedChanged(object sender, MouseEventArgs e)
		{
			if (!lbSR1_Homing_c2 && !lbSR1_Move_c2)
			{
				lbManualMode_c2 = !lbManualMode_c2;
				if (!lbManualMode_c2)
					StopMM_c2();
				else
					chkManMode_c2.Checked = false;
			}
		}

		private void btnJogF_c3_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c3 = true;
			lbJogR_c3 = false;
		}
		private void btnJogF_c3_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c3 = false;
			lbJogR_c3 = false;
		}
		private void btnJogR_c3_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c3 = false;
			lbJogR_c3 = true;
		}
		private void btnJogR_c3_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c3 = false;
			lbJogR_c3 = false;
		}
		private void chkManMode_c3_CheckedChanged(object sender, MouseEventArgs e)
		{
			if (!lbSR1_Homing_c3 && !lbSR1_Move_c3)
			{
				lbManualMode_c3 = !lbManualMode_c3;
				if (!lbManualMode_c3)
					StopMM_c3();
				else
					chkManMode_c3.Checked = false;
			}
		}

		private void btnJogF_c4_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c4 = true;
			lbJogR_c4 = false;
		}
		private void btnJogF_c4_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c4 = false;
			lbJogR_c4 = false;
		}
		private void btnJogR_c4_MouseDown(object sender, MouseEventArgs e)
		{
			lbJogF_c4 = false;
			lbJogR_c4 = true;
		}
		private void btnJogR_c4_MouseUp(object sender, MouseEventArgs e)
		{
			lbJogF_c4 = false;
			lbJogR_c4 = false;
		}
		private void chkManMode_c4_CheckedChanged(object sender, MouseEventArgs e)
		{
			if (!lbSR1_Homing_c4 && !lbSR1_Move_c4)
			{
				lbManualMode_c4 = !lbManualMode_c4;
				if (!lbManualMode_c4)
					StopMM_c4();
				else
					chkManMode_c4.Checked = false;
			}
		}

		private void TabPageSetup_c1_Enter(object sender, EventArgs e)
		{
			PrmLoad_c1();
		}
		private void TabPageSetup_c2_Enter(object sender, EventArgs e)
		{
			PrmLoad_c2();
		}
		private void TabPageSetup_c3_Enter(object sender, EventArgs e)
		{
			PrmLoad_c3();
		}
		private void TabPageSetup_c4_Enter(object sender, EventArgs e)
		{
			if (!_formLoaded)
				return;

			PrmLoad_c4();
		}

		private void PrmLoad_c1()
		{
				ReadTagsPrm_c1();
		}
		private void PrmLoad_c2()
		{
				ReadTagsPrm_c2();
		}
		private void PrmLoad_c3()
		{
				ReadTagsPrm_c3();
		}
		private void PrmLoad_c4()
		{
				ReadTagsPrm_c4();
		}

		private void btnReadPrm_c1_Click(object sender, EventArgs e)
		{
				ReadTagsPrm_c1();
		}
		private void btnReadPrm_c2_Click(object sender, EventArgs e)
		{
				ReadTagsPrm_c2();
		}
		private void btnReadPrm_c3_Click(object sender, EventArgs e)
		{
				ReadTagsPrm_c3();
		}
		private void btnReadPrm_c4_Click(object sender, EventArgs e)
		{
				ReadTagsPrm_c4();
		}

		private void btnWritePrm_c1_Click(object sender, EventArgs e)
		{
				WriteTagsPrm_c1();
		}
		private void btnWritePrm_c2_Click(object sender, EventArgs e)
		{
				WriteTagsPrm_c2();
		}
		private void btnWritePrm_c3_Click(object sender, EventArgs e)
		{
				WriteTagsPrm_c3();
		}
		private void btnWritePrm_c4_Click(object sender, EventArgs e)
		{
				WriteTagsPrm_c4();
		}

		private void ReadTagsPrm_c1()
		{
			lblPW_c1.Visible = true;
			lblPW_c1.Refresh();

			ButtonsDisabledPrm_c1();
						
			udNumBinsPrm_c1.Minimum = 6;
			udNumBinsPrm_c1.Maximum = 999;
			udControlTypePrm_c1.Minimum = 1;
			udControlTypePrm_c1.Maximum = 1;
			udMMMDelayPrm_c1.Minimum = 1000;
			udMMMDelayPrm_c1.Maximum = 10000;
			udMMMDelayPrm_c1.Increment = 100;
			udStepsPerRevPrm_c1.Minimum = 0;
			udStepsPerRevPrm_c1.Maximum = 32767;
			udnPosOffsetPct_c1.Minimum = -100;
			udnPosOffsetPct_c1.Maximum = 100;

			udRatioPrm_c1.Minimum = 11;
			udRatioPrm_c1.Maximum = 99;
			udRatioPrm_c1.Increment = 1;

			udBinTolPctPrm_c1.Minimum = 0.1M;
			udBinTolPctPrm_c1.Maximum = 10;
			udBinTolPctPrm_c1.Increment = 0.1M;

			udSlowPreset1Prm_c1.Minimum = 2;
			udSlowPreset1Prm_c1.Maximum = 3;
			udSlowPreset1Prm_c1.Increment = 0.5M;

			udSlowPreset2Prm_c1.Minimum = 0.75M;
			udSlowPreset2Prm_c1.Maximum = 1;
			udSlowPreset2Prm_c1.Increment = 0.05M;

			udSlowPreset3Prm_c1.Minimum = 0.1M;
			udSlowPreset3Prm_c1.Maximum = 0.5M;
			udSlowPreset3Prm_c1.Increment = 0.001M;

			udStopPresetPrm_c1.Minimum = 0.005M;
			udStopPresetPrm_c1.Maximum = 0.09M;
			udStopPresetPrm_c1.Increment = 0.001M;


			// Read tags
			//lnTndNTagRead1StatPrm_c1 = AxTndNTagReadPrm_c1.Read();
			try
			{
				diNumOfBins_c1.GetValue(out lnNumBinsPrm_c1);
				dinRatio_c1.GetValue(out lnRatioPrm_c1);
				dinBinTolPct_c1.GetValue(out lnBinTolPctPrm_c1);
				diControlType_c1.GetValue(out lnControlTypePrm_c1);
				diMMMDelayPreset_c1.GetValue(out lnMMMDelayPrm_c1);
				diCarouselEnabled_c1.GetValue(out bool bCarouselEnabled);
				chkEnabledPrm_c1.Checked = bCarouselEnabled;
				diStepsPerRev_c1.GetValue(out lnStepsPerRevPrm_c1);
				dinBin_SlowPreset1_c1.GetValue(out lnSlowPreset1Prm_c1);
				dinBin_SlowPreset2_c1.GetValue(out lnSlowPreset2Prm_c1);
				dinBin_SlowPreset3_c1.GetValue(out lnSlowPreset3Prm_c1);
				dinBin_StopPreset_c1.GetValue(out lnStopPresetPrm_c1);
				dinPosOffsetPct_c1.GetValue(out nPosOffsetPct_c1);
				diSafetyConfig_c1.GetValue(out lnSafetyConfigPrm_c1);
				lblReadErrorPrm_c1.Visible = false;
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c1");
				lblReadErrorPrm_c1.Visible = true;
				chkEnabledPrm_c1.Checked = false;
			}

            udNumBinsPrm_c1.Value = lnNumBinsPrm_c1;
            udRatioPrm_c1.Value = lnRatioPrm_c1;
            udBinTolPctPrm_c1.Value = lnBinTolPctPrm_c1 / 10.0M;
            udControlTypePrm_c1.Value = lnControlTypePrm_c1;
            udMMMDelayPrm_c1.Value = lnMMMDelayPrm_c1;
			udStepsPerRevPrm_c1.Value = lnStepsPerRevPrm_c1;
			udnPosOffsetPct_c1.Value = nPosOffsetPct_c1;
			udSlowPreset1Prm_c1.Value = lnSlowPreset1Prm_c1 / 1000.0M;
			udSlowPreset2Prm_c1.Value = lnSlowPreset2Prm_c1 / 1000.0M;
            udSlowPreset3Prm_c1.Value = lnSlowPreset3Prm_c1 / 1000.0M;
            udStopPresetPrm_c1.Value = lnStopPresetPrm_c1 / 1000.0M;

			// Breakout SafetyConfig
			chkES1_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 0);
			chkES2_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 1);
			chkES3_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 2);
			chkES4_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 3);
			chkES5_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 4);
			chkES6_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 5);
			chkES7_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 6);
			chkES8_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 7);
			//
			chkPE1_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 8);
			chkPE2_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 9);
			chkPE3_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 10);
			chkPE4_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 11);
			chkPE5_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 12);
			chkPE6_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 13);
			chkPE7_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 14);
			chkPE8_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 15);
			//
			chkLG1_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 16);
			chkLG2_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 17);
			chkLG3_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 18);
			chkLG4_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 19);
			chkLG5_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 20);
			chkLG6_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 21);
			chkLG7_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 22);
			chkLG8_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 23);
			//
			chkMT1_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 24);
			chkMT2_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 25);
			chkMT3_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 26);
			chkMT4_c1.Checked = TestBit(lnSafetyConfigPrm_c1, 27);
			
			lblPW_c1.Visible = false;
			lblPW_c1.Refresh();

			ButtonsEnabledPrm_c1();
		}
		private void ReadTagsPrm_c2()
		{
			lblPW_c2.Visible = true;
			lblPW_c2.Refresh();

			ButtonsDisabledPrm_c2();

			udNumBinsPrm_c2.Minimum = 6;
			udNumBinsPrm_c2.Maximum = 999;
			udControlTypePrm_c2.Minimum = 1;
			udControlTypePrm_c2.Maximum = 1;
			udMMMDelayPrm_c2.Minimum = 1000;
			udMMMDelayPrm_c2.Maximum = 10000;
			udMMMDelayPrm_c2.Increment = 100;
			udStepsPerRevPrm_c2.Minimum = 0;
			udStepsPerRevPrm_c2.Maximum = 32767;
			udnPosOffsetPct_c2.Minimum = -100;
			udnPosOffsetPct_c2.Maximum = 100;

			udRatioPrm_c2.Minimum = 11;
			udRatioPrm_c2.Maximum = 99;
			udRatioPrm_c2.Increment = 1;

			udBinTolPctPrm_c2.Minimum = 0.1M;
			udBinTolPctPrm_c2.Maximum = 10;
			udBinTolPctPrm_c2.Increment = 0.1M;

			udSlowPreset1Prm_c2.Minimum = 2;
			udSlowPreset1Prm_c2.Maximum = 3;
			udSlowPreset1Prm_c2.Increment = 0.5M;

			udSlowPreset2Prm_c2.Minimum = 0.75M;
			udSlowPreset2Prm_c2.Maximum = 1;
			udSlowPreset2Prm_c2.Increment = 0.05M;

			udSlowPreset3Prm_c2.Minimum = 0.1M;
			udSlowPreset3Prm_c2.Maximum = 0.5M;
			udSlowPreset3Prm_c2.Increment = 0.001M;

			udStopPresetPrm_c2.Minimum = 0.005M;
			udStopPresetPrm_c2.Maximum = 0.09M;
			udStopPresetPrm_c2.Increment = 0.001M;


			// Read tags
			//lnTndNTagRead1StatPrm_c2 = AxTndNTagReadPrm_c2.Read();
			try
			{
				diNumOfBins_c2.GetValue(out lnNumBinsPrm_c2);
				dinRatio_c2.GetValue(out lnRatioPrm_c2);
				dinBinTolPct_c2.GetValue(out lnBinTolPctPrm_c2);
				diControlType_c2.GetValue(out lnControlTypePrm_c2);
				diMMMDelayPreset_c2.GetValue(out lnMMMDelayPrm_c2);
				diCarouselEnabled_c2.GetValue(out bool bCarouselEnabled);
				chkEnabledPrm_c2.Checked = bCarouselEnabled;
				diStepsPerRev_c2.GetValue(out lnStepsPerRevPrm_c2);
				dinBin_SlowPreset1_c2.GetValue(out lnSlowPreset1Prm_c2);
				dinBin_SlowPreset2_c2.GetValue(out lnSlowPreset2Prm_c2);
				dinBin_SlowPreset3_c2.GetValue(out lnSlowPreset3Prm_c2);
				dinBin_StopPreset_c2.GetValue(out lnStopPresetPrm_c2);
				dinPosOffsetPct_c2.GetValue(out nPosOffsetPct_c2);
				diSafetyConfig_c2.GetValue(out lnSafetyConfigPrm_c2);
				lblReadErrorPrm_c2.Visible = false;
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c2");
				lblReadErrorPrm_c2.Visible = true;
				chkEnabledPrm_c2.Checked = false;
			}

			udNumBinsPrm_c2.Value = lnNumBinsPrm_c2;
			udRatioPrm_c2.Value = lnRatioPrm_c2;
			udBinTolPctPrm_c2.Value = lnBinTolPctPrm_c2 / 10.0M;
			udControlTypePrm_c2.Value = lnControlTypePrm_c2;
			udMMMDelayPrm_c2.Value = lnMMMDelayPrm_c2;
			udStepsPerRevPrm_c2.Value = lnStepsPerRevPrm_c2;
			udnPosOffsetPct_c2.Value = nPosOffsetPct_c2;
			udSlowPreset1Prm_c2.Value = lnSlowPreset1Prm_c2 / 1000.0M;
			udSlowPreset2Prm_c2.Value = lnSlowPreset2Prm_c2 / 1000.0M;
			udSlowPreset3Prm_c2.Value = lnSlowPreset3Prm_c2 / 1000.0M;
			udStopPresetPrm_c2.Value = lnStopPresetPrm_c2 / 1000.0M;

			// Breakout SafetyConfig
			chkES1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 0);
			chkES2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 1);
			chkES3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 2);
			chkES4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 3);
			chkES5_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 4);
			chkES6_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 5);
			chkES7_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 6);
			chkES8_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 7);
			//
			chkPE1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 8);
			chkPE2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 9);
			chkPE3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 10);
			chkPE4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 11);
			chkPE5_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 12);
			chkPE6_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 13);
			chkPE7_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 14);
			chkPE8_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 15);
			//
			chkLG1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 16);
			chkLG2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 17);
			chkLG3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 18);
			chkLG4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 19);
			chkLG5_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 20);
			chkLG6_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 21);
			chkLG7_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 22);
			chkLG8_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 23);
			//
			chkMT1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 24);
			chkMT2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 25);
			chkMT3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 26);
			chkMT4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 27);

			lblPW_c2.Visible = false;
			lblPW_c2.Refresh();

			ButtonsEnabledPrm_c2();
		}
		private void ReadTagsPrm_c3()
		{
			lblPW_c3.Visible = true;
			lblPW_c3.Refresh();

			ButtonsDisabledPrm_c3();

			udNumBinsPrm_c3.Minimum = 6;
			udNumBinsPrm_c3.Maximum = 999;
			udControlTypePrm_c3.Minimum = 1;
			udControlTypePrm_c3.Maximum = 1;
			udMMMDelayPrm_c3.Minimum = 1000;
			udMMMDelayPrm_c3.Maximum = 10000;
			udMMMDelayPrm_c3.Increment = 100;
			udStepsPerRevPrm_c3.Minimum = 0;
			udStepsPerRevPrm_c3.Maximum = 32767;
			udnPosOffsetPct_c3.Minimum = -100;
			udnPosOffsetPct_c3.Maximum = 100;

			udRatioPrm_c3.Minimum = 11;
			udRatioPrm_c3.Maximum = 99;
			udRatioPrm_c3.Increment = 1;

			udBinTolPctPrm_c3.Minimum = 0.1M;
			udBinTolPctPrm_c3.Maximum = 10;
			udBinTolPctPrm_c3.Increment = 0.1M;

			udSlowPreset1Prm_c3.Minimum = 2;
			udSlowPreset1Prm_c3.Maximum = 3;
			udSlowPreset1Prm_c3.Increment = 0.5M;

			udSlowPreset2Prm_c3.Minimum = 0.75M;
			udSlowPreset2Prm_c3.Maximum = 1;
			udSlowPreset2Prm_c3.Increment = 0.05M;

			udSlowPreset3Prm_c3.Minimum = 0.1M;
			udSlowPreset3Prm_c3.Maximum = 0.5M;
			udSlowPreset3Prm_c3.Increment = 0.001M;

			udStopPresetPrm_c3.Minimum = 0.005M;
			udStopPresetPrm_c3.Maximum = 0.09M;
			udStopPresetPrm_c3.Increment = 0.001M;


			// Read tags
			//lnTndNTagRead1StatPrm_c3 = AxTndNTagReadPrm_c3.Read();
			try
			{
				diNumOfBins_c3.GetValue(out lnNumBinsPrm_c3);
				dinRatio_c3.GetValue(out lnRatioPrm_c3);
				dinBinTolPct_c3.GetValue(out lnBinTolPctPrm_c3);
				diControlType_c3.GetValue(out lnControlTypePrm_c3);
				diMMMDelayPreset_c3.GetValue(out lnMMMDelayPrm_c3);
				diCarouselEnabled_c3.GetValue(out bool bCarouselEnabled);
				chkEnabledPrm_c3.Checked = bCarouselEnabled;
				diStepsPerRev_c3.GetValue(out lnStepsPerRevPrm_c3);
				dinBin_SlowPreset1_c3.GetValue(out lnSlowPreset1Prm_c3);
				dinBin_SlowPreset2_c3.GetValue(out lnSlowPreset2Prm_c3);
				dinBin_SlowPreset3_c3.GetValue(out lnSlowPreset3Prm_c3);
				dinBin_StopPreset_c3.GetValue(out lnStopPresetPrm_c3);
				dinPosOffsetPct_c3.GetValue(out nPosOffsetPct_c3);
				diSafetyConfig_c3.GetValue(out lnSafetyConfigPrm_c3);
				lblReadErrorPrm_c3.Visible = false;
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c3");
				lblReadErrorPrm_c3.Visible = true;
				chkEnabledPrm_c3.Checked = false;
			}

			udNumBinsPrm_c3.Value = lnNumBinsPrm_c3;
			udRatioPrm_c3.Value = lnRatioPrm_c3;
			udBinTolPctPrm_c3.Value = lnBinTolPctPrm_c3 / 10.0M;
			udControlTypePrm_c3.Value = lnControlTypePrm_c3;
			udMMMDelayPrm_c3.Value = lnMMMDelayPrm_c3;
			udStepsPerRevPrm_c3.Value = lnStepsPerRevPrm_c3;
			udnPosOffsetPct_c3.Value = nPosOffsetPct_c3;
			udSlowPreset1Prm_c3.Value = lnSlowPreset1Prm_c3 / 1000.0M;
			udSlowPreset2Prm_c3.Value = lnSlowPreset2Prm_c3 / 1000.0M;
			udSlowPreset3Prm_c3.Value = lnSlowPreset3Prm_c3 / 1000.0M;
			udStopPresetPrm_c3.Value = lnStopPresetPrm_c3 / 1000.0M;

			// Breakout SafetyConfig
			chkES1_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 0);
			chkES2_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 1);
			chkES3_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 2);
			chkES4_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 3);
			chkES5_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 4);
			chkES6_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 5);
			chkES7_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 6);
			chkES8_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 7);
			//
			chkPE1_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 8);
			chkPE2_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 9);
			chkPE3_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 10);
			chkPE4_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 11);
			chkPE5_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 12);
			chkPE6_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 13);
			chkPE7_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 14);
			chkPE8_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 15);
			//
			chkLG1_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 16);
			chkLG2_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 17);
			chkLG3_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 18);
			chkLG4_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 19);
			chkLG5_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 20);
			chkLG6_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 21);
			chkLG7_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 22);
			chkLG8_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 23);
			//
			chkMT1_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 24);
			chkMT2_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 25);
			chkMT3_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 26);
			chkMT4_c3.Checked = TestBit(lnSafetyConfigPrm_c3, 27);

			lblPW_c3.Visible = false;
			lblPW_c3.Refresh();

			ButtonsEnabledPrm_c3();
		}
		private void ReadTagsPrm_c4()
		{
			lblPW_c4.Visible = true;
			lblPW_c4.Refresh();

			ButtonsDisabledPrm_c4();

			udNumBinsPrm_c4.Minimum = 6;
			udNumBinsPrm_c4.Maximum = 999;
			udControlTypePrm_c4.Minimum = 1;
			udControlTypePrm_c4.Maximum = 1;
			udMMMDelayPrm_c4.Minimum = 1000;
			udMMMDelayPrm_c4.Maximum = 10000;
			udMMMDelayPrm_c4.Increment = 100;
			udStepsPerRevPrm_c4.Minimum = 0;
			udStepsPerRevPrm_c4.Maximum = 32767;
			udnPosOffsetPct_c4.Minimum = -100;
			udnPosOffsetPct_c4.Maximum = 100;

			udRatioPrm_c4.Minimum = 11;
			udRatioPrm_c4.Maximum = 99;
			udRatioPrm_c4.Increment = 1;

			udBinTolPctPrm_c4.Minimum = 0.1M;
			udBinTolPctPrm_c4.Maximum = 10;
			udBinTolPctPrm_c4.Increment = 0.1M;

			udSlowPreset1Prm_c4.Minimum = 2;
			udSlowPreset1Prm_c4.Maximum = 3;
			udSlowPreset1Prm_c4.Increment = 0.5M;

			udSlowPreset2Prm_c4.Minimum = 0.75M;
			udSlowPreset2Prm_c4.Maximum = 1;
			udSlowPreset2Prm_c4.Increment = 0.05M;

			udSlowPreset3Prm_c4.Minimum = 0.1M;
			udSlowPreset3Prm_c4.Maximum = 0.5M;
			udSlowPreset3Prm_c4.Increment = 0.001M;

			udStopPresetPrm_c4.Minimum = 0.005M;
			udStopPresetPrm_c4.Maximum = 0.09M;
			udStopPresetPrm_c4.Increment = 0.001M;


			// Read tags
			//lnTndNTagRead1StatPrm_c4 = AxTndNTagReadPrm_c4.Read();
			try
			{
				diNumOfBins_c4.GetValue(out lnNumBinsPrm_c4);
				dinRatio_c4.GetValue(out lnRatioPrm_c4);
				dinBinTolPct_c4.GetValue(out lnBinTolPctPrm_c4);
				diControlType_c4.GetValue(out lnControlTypePrm_c4);
				diMMMDelayPreset_c4.GetValue(out lnMMMDelayPrm_c4);
				diCarouselEnabled_c4.GetValue(out bool bCarouselEnabled);
				chkEnabledPrm_c4.Checked = bCarouselEnabled;
				diStepsPerRev_c4.GetValue(out lnStepsPerRevPrm_c4);
				dinBin_SlowPreset1_c4.GetValue(out lnSlowPreset1Prm_c4);
				dinBin_SlowPreset2_c4.GetValue(out lnSlowPreset2Prm_c4);
				dinBin_SlowPreset3_c4.GetValue(out lnSlowPreset3Prm_c4);
				dinBin_StopPreset_c4.GetValue(out lnStopPresetPrm_c4);
				dinPosOffsetPct_c4.GetValue(out nPosOffsetPct_c4);
				diSafetyConfig_c4.GetValue(out lnSafetyConfigPrm_c4);
				lblReadErrorPrm_c4.Visible = false;
			}
			catch
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c4");
				lblReadErrorPrm_c4.Visible = true;
				chkEnabledPrm_c4.Checked = false;
			}

			udNumBinsPrm_c4.Value = lnNumBinsPrm_c4;
			udRatioPrm_c4.Value = lnRatioPrm_c4;
			udBinTolPctPrm_c4.Value = lnBinTolPctPrm_c4 / 10.0M;
			udControlTypePrm_c4.Value = lnControlTypePrm_c4;
			udMMMDelayPrm_c4.Value = lnMMMDelayPrm_c4;
			udStepsPerRevPrm_c4.Value = lnStepsPerRevPrm_c4;
			udnPosOffsetPct_c4.Value = nPosOffsetPct_c4;
			udSlowPreset1Prm_c4.Value = lnSlowPreset1Prm_c4 / 1000.0M;
			udSlowPreset2Prm_c4.Value = lnSlowPreset2Prm_c4 / 1000.0M;
			udSlowPreset3Prm_c4.Value = lnSlowPreset3Prm_c4 / 1000.0M;
			udStopPresetPrm_c4.Value = lnStopPresetPrm_c4 / 1000.0M;

			// Breakout SafetyConfig
			chkES1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 0);
			chkES2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 1);
			chkES3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 2);
			chkES4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 3);
			chkES5_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 4);
			chkES6_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 5);
			chkES7_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 6);
			chkES8_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 7);
			//
			chkPE1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 8);
			chkPE2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 9);
			chkPE3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 10);
			chkPE4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 11);
			chkPE5_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 12);
			chkPE6_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 13);
			chkPE7_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 14);
			chkPE8_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 15);
			//
			chkLG1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 16);
			chkLG2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 17);
			chkLG3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 18);
			chkLG4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 19);
			chkLG5_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 20);
			chkLG6_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 21);
			chkLG7_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 22);
			chkLG8_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 23);
			//
			chkMT1_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 24);
			chkMT2_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 25);
			chkMT3_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 26);
			chkMT4_c2.Checked = TestBit(lnSafetyConfigPrm_c2, 27);

			lblPW_c4.Visible = false;
			lblPW_c4.Refresh();

			ButtonsEnabledPrm_c4();
		}

		private void SafetyConfigCalc_c1()
		{
			lnSafetyConfigPrm_c1 = 0;
			if (chkES1_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 0);
			if (chkES2_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 1);
			if (chkES3_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 2);
			if (chkES4_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 3);
			if (chkES5_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 4);
			if (chkES6_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 5);
			if (chkES7_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 6);
			if (chkES8_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 7);
			if (chkPE1_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 8);
			if (chkPE2_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 9);
			if (chkPE3_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 10);
			if (chkPE4_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 11);
			if (chkPE5_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 12);
			if (chkPE6_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 13);
			if (chkPE7_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 14);
			if (chkPE8_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 15);
			if (chkLG1_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 16);
			if (chkLG2_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 17);
			if (chkLG3_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 18);
			if (chkLG4_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 19);
			if (chkLG5_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 20);
			if (chkLG6_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 21);
			if (chkLG7_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 22);
			if (chkLG8_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 23);
			if (chkMT1_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 24);
			if (chkMT2_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 25);
			if (chkMT3_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 26);
			if (chkMT4_c1.Checked) SetBit(ref lnSafetyConfigPrm_c1, 27);
		}
		private void SafetyConfigCalc_c2()
		{
			lnSafetyConfigPrm_c2 = 0;
			if (chkES1_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 0);
			if (chkES2_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 1);
			if (chkES3_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 2);
			if (chkES4_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 3);
			if (chkES5_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 4);
			if (chkES6_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 5);
			if (chkES7_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 6);
			if (chkES8_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 7);
			if (chkPE1_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 8);
			if (chkPE2_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 9);
			if (chkPE3_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 10);
			if (chkPE4_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 11);
			if (chkPE5_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 12);
			if (chkPE6_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 13);
			if (chkPE7_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 14);
			if (chkPE8_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 15);
			if (chkLG1_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 16);
			if (chkLG2_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 17);
			if (chkLG3_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 18);
			if (chkLG4_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 19);
			if (chkLG5_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 20);
			if (chkLG6_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 21);
			if (chkLG7_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 22);
			if (chkLG8_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 23);
			if (chkMT1_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 24);
			if (chkMT2_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 25);
			if (chkMT3_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 26);
			if (chkMT4_c2.Checked) SetBit(ref lnSafetyConfigPrm_c2, 27);
		}
		private void SafetyConfigCalc_c3()
		{
			lnSafetyConfigPrm_c3 = 0;
			if (chkES1_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 0);
			if (chkES2_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 1);
			if (chkES3_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 2);
			if (chkES4_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 3);
			if (chkES5_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 4);
			if (chkES6_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 5);
			if (chkES7_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 6);
			if (chkES8_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 7);
			if (chkPE1_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 8);
			if (chkPE2_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 9);
			if (chkPE3_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 10);
			if (chkPE4_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 11);
			if (chkPE5_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 12);
			if (chkPE6_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 13);
			if (chkPE7_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 14);
			if (chkPE8_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 15);
			if (chkLG1_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 16);
			if (chkLG2_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 17);
			if (chkLG3_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 18);
			if (chkLG4_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 19);
			if (chkLG5_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 20);
			if (chkLG6_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 21);
			if (chkLG7_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 22);
			if (chkLG8_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 23);
			if (chkMT1_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 24);
			if (chkMT2_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 25);
			if (chkMT3_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 26);
			if (chkMT4_c3.Checked) SetBit(ref lnSafetyConfigPrm_c3, 27);
		}
		private void SafetyConfigCalc_c4()
		{
			lnSafetyConfigPrm_c4 = 0;
			if (chkES1_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 0);
			if (chkES2_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 1);
			if (chkES3_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 2);
			if (chkES4_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 3);
			if (chkES5_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 4);
			if (chkES6_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 5);
			if (chkES7_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 6);
			if (chkES8_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 7);
			if (chkPE1_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 8);
			if (chkPE2_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 9);
			if (chkPE3_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 10);
			if (chkPE4_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 11);
			if (chkPE5_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 12);
			if (chkPE6_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 13);
			if (chkPE7_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 14);
			if (chkPE8_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 15);
			if (chkLG1_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 16);
			if (chkLG2_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 17);
			if (chkLG3_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 18);
			if (chkLG4_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 19);
			if (chkLG5_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 20);
			if (chkLG6_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 21);
			if (chkLG7_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 22);
			if (chkLG8_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 23);
			if (chkMT1_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 24);
			if (chkMT2_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 25);
			if (chkMT3_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 26);
			if (chkMT4_c4.Checked) SetBit(ref lnSafetyConfigPrm_c4, 27);
		}

		private void WriteTagsPrm_c1()
		{
			lblPW_c1.Visible = true;
			lblPW_c1.Refresh();

			ButtonsDisabledPrm_c1();

			try
			{
				// Write tags
				diNumOfBins_c1.SetValue((int)udNumBinsPrm_c1.Value);
				dinRatio_c1.SetValue((int)udRatioPrm_c1.Value);
				dinBinTolPct_c1.SetValue((int)(udBinTolPctPrm_c1.Value * 10));
				diControlType_c1.SetValue((int)udControlTypePrm_c1.Value);
				diMMMDelayPreset_c1.SetValue((int)udMMMDelayPrm_c1.Value);
				diCarouselEnabled_c1.SetValue(chkEnabledPrm_c1.Checked);
				diStepsPerRev_c1.SetValue((int)udStepsPerRevPrm_c1.Value);
				dinBin_SlowPreset1_c1.SetValue((int)(udSlowPreset1Prm_c1.Value * 1000));
				dinBin_SlowPreset2_c1.SetValue((int)(udSlowPreset2Prm_c1.Value * 1000));
				dinBin_SlowPreset3_c1.SetValue((int)(udSlowPreset3Prm_c1.Value * 1000));
				dinBin_StopPreset_c1.SetValue((int)(udStopPresetPrm_c1.Value * 1000));
				dinPosOffsetPct_c1.SetValue((int)udnPosOffsetPct_c1.Value);
				SafetyConfigCalc_c1();
				diSafetyConfig_c1.SetValue((int)lnSafetyConfigPrm_c1);

				// Success
				lblWriteErrorPrm_c1.Visible = false;
				diWriteRetentiveData.SetValue(true);
				tmrPrm_c1.Enabled = true;
				//ButtonsEnabledPrm_c1();
			}
			catch
			{
				// Failure
				lblWriteErrorPrm_c1.Visible = true;
				ButtonsEnabledPrm_c1();
			}
		}
		private void WriteTagsPrm_c2()
		{
			lblPW_c2.Visible = true;
			lblPW_c2.Refresh();

			ButtonsDisabledPrm_c2();

			try
			{
				// Write tags
				diNumOfBins_c2.SetValue((int)udNumBinsPrm_c2.Value);
				dinRatio_c2.SetValue((int)udRatioPrm_c2.Value);
				dinBinTolPct_c2.SetValue((int)(udBinTolPctPrm_c2.Value * 10));
				diControlType_c2.SetValue((int)udControlTypePrm_c2.Value);
				diMMMDelayPreset_c2.SetValue((int)udMMMDelayPrm_c2.Value);
				diCarouselEnabled_c2.SetValue(chkEnabledPrm_c2.Checked);
				diStepsPerRev_c2.SetValue((int)udStepsPerRevPrm_c2.Value);
				dinBin_SlowPreset1_c2.SetValue((int)(udSlowPreset1Prm_c2.Value * 1000));
				dinBin_SlowPreset2_c2.SetValue((int)(udSlowPreset2Prm_c2.Value * 1000));
				dinBin_SlowPreset3_c2.SetValue((int)(udSlowPreset3Prm_c2.Value * 1000));
				dinBin_StopPreset_c2.SetValue((int)(udStopPresetPrm_c2.Value * 1000));
				dinPosOffsetPct_c2.SetValue((int)udnPosOffsetPct_c2.Value);
				SafetyConfigCalc_c2();
				diSafetyConfig_c2.SetValue((int)lnSafetyConfigPrm_c2);

				// Success
				diWriteRetentiveData.SetValue(true);
				tmrPrm_c2.Enabled = true;
			}
			catch
			{
				// Failure
				lblWriteErrorPrm_c2.Visible = true;
				ButtonsEnabledPrm_c2();
			}
		}
		private void WriteTagsPrm_c3()
		{
			lblPW_c3.Visible = true;
			lblPW_c3.Refresh();

			ButtonsDisabledPrm_c3();

			try
			{
				// Write tags
				diNumOfBins_c3.SetValue((int)udNumBinsPrm_c3.Value);
				dinRatio_c3.SetValue((int)udRatioPrm_c3.Value);
				dinBinTolPct_c3.SetValue((int)(udBinTolPctPrm_c3.Value * 10));
				diControlType_c3.SetValue((int)udControlTypePrm_c3.Value);
				diMMMDelayPreset_c3.SetValue((int)udMMMDelayPrm_c3.Value);
				diCarouselEnabled_c3.SetValue(chkEnabledPrm_c3.Checked);
				diStepsPerRev_c3.SetValue((int)udStepsPerRevPrm_c3.Value);
				dinBin_SlowPreset1_c3.SetValue((int)(udSlowPreset1Prm_c3.Value * 1000));
				dinBin_SlowPreset2_c3.SetValue((int)(udSlowPreset2Prm_c3.Value * 1000));
				dinBin_SlowPreset3_c3.SetValue((int)(udSlowPreset3Prm_c3.Value * 1000));
				dinBin_StopPreset_c3.SetValue((int)(udStopPresetPrm_c3.Value * 1000));
				dinPosOffsetPct_c3.SetValue((int)udnPosOffsetPct_c3.Value);
				SafetyConfigCalc_c3();
				diSafetyConfig_c3.SetValue((int)lnSafetyConfigPrm_c3);

				//lnTndNTagWrite1StatPrm_c3 = AxTndNTagWrite1Prm_c3.Write();
				// Success
				diWriteRetentiveData.SetValue(true);
				tmrPrm_c3.Enabled = true;
			}
			catch
			{
				// Failure
				lblWriteErrorPrm_c3.Visible = true;
				ButtonsEnabledPrm_c3();
			}
		}
		private void WriteTagsPrm_c4()
		{
			lblPW_c4.Visible = true;
			lblPW_c4.Refresh();

			ButtonsDisabledPrm_c4();

			try
			{
				// Write tags
				diNumOfBins_c4.SetValue((int)udNumBinsPrm_c4.Value);
				dinRatio_c4.SetValue((int)udRatioPrm_c4.Value);
				dinBinTolPct_c4.SetValue((int)(udBinTolPctPrm_c4.Value * 10));
				diControlType_c4.SetValue((int)udControlTypePrm_c4.Value);
				diMMMDelayPreset_c4.SetValue((int)udMMMDelayPrm_c4.Value);
				diCarouselEnabled_c4.SetValue(chkEnabledPrm_c4.Checked);
				diStepsPerRev_c4.SetValue((int)udStepsPerRevPrm_c4.Value);
				dinBin_SlowPreset1_c4.SetValue((int)(udSlowPreset1Prm_c4.Value * 1000));
				dinBin_SlowPreset2_c4.SetValue((int)(udSlowPreset2Prm_c4.Value * 1000));
				dinBin_SlowPreset3_c4.SetValue((int)(udSlowPreset3Prm_c4.Value * 1000));
				dinBin_StopPreset_c4.SetValue((int)(udStopPresetPrm_c4.Value * 1000));
				dinPosOffsetPct_c4.SetValue((int)udnPosOffsetPct_c4.Value);
				SafetyConfigCalc_c4();
				diSafetyConfig_c4.SetValue((int)lnSafetyConfigPrm_c4);


				//lnTndNTagWrite1StatPrm_c4 = AxTndNTagWrite1Prm_c4.Write();
				// Success
				diWriteRetentiveData.SetValue(true);
				tmrPrm_c4.Enabled = true;
			}
			catch
			{
				// Failure
				lblWriteErrorPrm_c4.Visible = true;
				ButtonsEnabledPrm_c4();
			}
		}

		private void tmrPrm_c1_Tick(object sender, EventArgs e)
		{
			tmrPrm_c1.Enabled = false;
//#warning WriteRetentiveData set to false
            //AxTndNTagWrite2Prm_c1.UpdateLongValue(0, 0);    // WriteRetentiveData
            //diWriteRetentiveData.SetValue(false);
            ReadTagsPrm_c1();
			ButtonsEnabledPrm_c1();
		}
		private void tmrPrm_c2_Tick(object sender, EventArgs e)
		{
			tmrPrm_c2.Enabled = false;
//#warning WriteRetentiveData set to false
			//AxTndNTagWrite2Prm_c2.UpdateLongValue(0, 0);    // WriteRetentiveData
			//diWriteRetentiveData.SetValue(false);
			ReadTagsPrm_c2();
			ButtonsEnabledPrm_c2();
		}
		private void tmrPrm_c3_Tick(object sender, EventArgs e)
		{
			tmrPrm_c3.Enabled = false;
//#warning WriteRetentiveData set to false
			//AxTndNTagWrite2Prm_c3.UpdateLongValue(0, 0);    // WriteRetentiveData
			//diWriteRetentiveData.SetValue(false);
			ReadTagsPrm_c3();
			ButtonsEnabledPrm_c3();
		}
		private void tmrPrm_c4_Tick(object sender, EventArgs e)
		{
			tmrPrm_c4.Enabled = false;
//#warning WriteRetentiveData set to false
			//AxTndNTagWrite2Prm_c4.UpdateLongValue(0, 0);    // WriteRetentiveData
			//diWriteRetentiveData.SetValue(false);
			ReadTagsPrm_c4();
			ButtonsEnabledPrm_c4();
		}

		private void ButtonsDisabledPrm_c1()
		{
			btnReadPrm_c1.Enabled = false;
			btnWritePrm_c1.Enabled = false;
		}
		private void ButtonsDisabledPrm_c2()
		{
			btnReadPrm_c2.Enabled = false;
			btnWritePrm_c2.Enabled = false;
		}
		private void ButtonsDisabledPrm_c3()
		{
			btnReadPrm_c3.Enabled = false;
			btnWritePrm_c3.Enabled = false;
		}
		private void ButtonsDisabledPrm_c4()
		{
			btnReadPrm_c4.Enabled = false;
			btnWritePrm_c4.Enabled = false;
		}

		private void ButtonsEnabledPrm_c1()
		{
			btnReadPrm_c1.Enabled = true;
			btnWritePrm_c1.Enabled = true;
		}
		private void ButtonsEnabledPrm_c2()
		{
			btnReadPrm_c2.Enabled = true;
			btnWritePrm_c2.Enabled = true;
		}
		private void ButtonsEnabledPrm_c3()
		{
			btnReadPrm_c3.Enabled = true;
			btnWritePrm_c3.Enabled = true;
		}
		private void ButtonsEnabledPrm_c4()
		{
			btnReadPrm_c4.Enabled = true;
			btnWritePrm_c4.Enabled = true;
		}

		private void btnEncoderStart_c1_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c1 && !lbSR1_EncoderSetup_c1)
				lbEncoderStart_c1 = true;
			SetFocusReqBin_c1();
		}
		private void btnEncoderStart_c2_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c2 && !lbSR1_EncoderSetup_c2)
				lbEncoderStart_c2 = true;
			SetFocusReqBin_c2();
		}
		private void btnEncoderStart_c3_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c3 && !lbSR1_EncoderSetup_c3)
				lbEncoderStart_c3 = true;
			SetFocusReqBin_c3();
		}
		private void btnEncoderStart_c4_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c4 && !lbSR1_EncoderSetup_c4)
				lbEncoderStart_c4 = true;
			SetFocusReqBin_c4();
		}

		private void btnEncoderStop_c1_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c1)
				lbEncoderStop_c1 = true;
			SetFocusReqBin_c1();
		}
		private void btnEncoderStop_c2_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c2)
				lbEncoderStop_c2 = true;
			SetFocusReqBin_c2();
		}
		private void btnEncoderStop_c3_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c3)
				lbEncoderStop_c3 = true;
			SetFocusReqBin_c3();
		}
		private void btnEncoderStop_c4_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c4)
				lbEncoderStop_c4 = true;
			SetFocusReqBin_c4();
		}

		private void tmrEncoderStart_c1_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c1 = false;
			tmrEncoderStart_c1.Enabled = false;
		}
		private void tmrEncoderStart_c2_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c2 = false;
			tmrEncoderStart_c2.Enabled = false;
		}
		private void tmrEncoderStart_c3_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c3 = false;
			tmrEncoderStart_c3.Enabled = false;
		}
		private void tmrEncoderStart_c4_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c4 = false;
			tmrEncoderStart_c4.Enabled = false;
		}

		private void tmrEncoderStop_c1_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c1 = false;
			tmrEncoderStop_c1.Enabled = false;
		}
		private void tmrEncoderStop_c2_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c2 = false;
			tmrEncoderStop_c2.Enabled = false;
		}
		private void tmrEncoderStop_c3_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c3 = false;
			tmrEncoderStop_c3.Enabled = false;
		}
		private void tmrEncoderStop_c4_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c4 = false;
			tmrEncoderStop_c4.Enabled = false;
		}

		private void EncoderSetupColors_c1()
		{
			if (lbSR1_EncoderSetup_c1)
				btnEncoderStart_c1.BackColor = Color.Lime;
			else
				btnEncoderStart_c1.UseVisualStyleBackColor = true;
		}
		private void EncoderSetupColors_c2()
		{
			if (lbSR1_EncoderSetup_c2)
				btnEncoderStart_c2.BackColor = Color.Lime;
			else
				btnEncoderStart_c2.UseVisualStyleBackColor = true;
		}
		private void EncoderSetupColors_c3()
		{
			if (lbSR1_EncoderSetup_c3)
				btnEncoderStart_c3.BackColor = Color.Lime;
			else
				btnEncoderStart_c3.UseVisualStyleBackColor = true;
		}
		private void EncoderSetupColors_c4()
		{
			if (lbSR1_EncoderSetup_c4)
				btnEncoderStart_c4.BackColor = Color.Lime;
			else
				btnEncoderStart_c4.UseVisualStyleBackColor = true;
		}

		#region

		//private bool lbConrtollerInitError;

		private int lnHeartbeat;

		// 
		// Carousel 1 items
		// 
		private int lnRequestedBin_c1;
		private int lnSetBinPos_c1;

		private int lnNumBins_c1;
		private int lnCurBin_c1;
		private int lnTgtBin_c1;

		private int lnReqBin_c1;

		private int lnStatReg1_c1;
		private int lnStatReg2_c1;

		private int lnVFDRunStat_c1;
		private int lnVFDFaultStat_c1;

		// Status Register 1
		// Read from controller
		private bool lbSR1_Enabled_c1;
		private bool lbSR1_Move_c1;
		private bool lbSR1_Moving_c1;
		private bool lbSR1_CW1_CCW0_c1;
		private bool lbSR1_ManualMode_c1;
		private bool lbSR1_EncoderSetup_c1;
		private bool lbSR1_Homing_c1;
		private bool lbSR1_AutoControl_c1;
		private bool lbSR1_VFD_c1;
		private bool lbSR1_SafetyCkt_c1;
		private bool lbSR1_Ready_c1;

		// Status Register 2
		// Write to controller
		private bool lbHomingStart_c1;
		private bool lbHomingStop_c1;
		private bool lbEncoderStart_c1;
		private bool lbEncoderStop_c1;
		private bool lbManualMode_c1;
		//private bool lbHomingStartLatch_c1;

		// Flags
		// From controller  controller;
		private bool lbMoveFWD_c1;
		private bool lbMoveREV_c1;
		private bool lbMoveSPD0_c1;
		private bool lbMoveSPD1_c1;

		//private bool lbTndNTagReadMM1Stat_c1;
		//private bool lbTndNTagWriteMM1Stat_c1;
		//private bool lbTndNTagWriteMM2Stat_c1;
		//private bool lbTndNTagWriteMM3Stat_c1;
		//private bool lbTndNTagWriteMM4Stat_c1;

		private bool lbFWD_c1;
		private bool lbREV_c1;
		private bool lbSTOP_c1;
		private bool lbJogF_c1;
		private bool lbJogR_c1;

		//
		// Carousel 2 items
		//
		private int lnRequestedBin_c2;
		private int lnSetBinPos_c2;

		private int lnNumBins_c2;
		private int lnCurBin_c2;
		private int lnTgtBin_c2;

		private int lnReqBin_c2;

		private int lnStatReg1_c2;
		private int lnStatReg2_c2;

		private int lnVFDRunStat_c2;
		private int lnVFDFaultStat_c2;

		// Status Register 1
		// Read from controller
		private bool lbSR1_Enabled_c2;
		private bool lbSR1_Move_c2;
		private bool lbSR1_Moving_c2;
		private bool lbSR1_CW1_CCW0_c2;
		private bool lbSR1_ManualMode_c2;
		private bool lbSR1_EncoderSetup_c2;
		private bool lbSR1_Homing_c2;
		private bool lbSR1_AutoControl_c2;
		private bool lbSR1_VFD_c2;
		private bool lbSR1_SafetyCkt_c2;
		private bool lbSR1_Ready_c2;

		// Status Register 2
		// Write to controller
		private bool lbHomingStart_c2;
		private bool lbHomingStop_c2;
		private bool lbEncoderStart_c2;
		private bool lbEncoderStop_c2;
		private bool lbManualMode_c2;
		//private bool lbHomingStartLatch_c2;

		// Flags
		// Read from controller
		private bool lbMoveFWD_c2;
		private bool lbMoveREV_c2;
		private bool lbMoveSPD0_c2;
		private bool lbMoveSPD1_c2;

		//private bool lbTndNTagReadMM1Stat_c2;
		//private bool lbTndNTagWriteMM1Stat_c2;
		//private bool lbTndNTagWriteMM2Stat_c2;
		//private bool lbTndNTagWriteMM3Stat_c2;
		//private bool lbTndNTagWriteMM4Stat_c2;

		private bool lbFWD_c2;
		private bool lbREV_c2;
		private bool lbSTOP_c2;
		private bool lbJogF_c2;
		private bool lbJogR_c2;

		//
		// Carousel 3 items
		//
		private int lnRequestedBin_c3;
		private int lnSetBinPos_c3;

		private int lnNumBins_c3;
		private int lnCurBin_c3;
		private int lnTgtBin_c3;

		private int lnReqBin_c3;

		private int lnStatReg1_c3;
		private int lnStatReg2_c3;

		private int lnVFDRunStat_c3;
		private int lnVFDFaultStat_c3;

		// Status Register 1  Register;
		// Read from controller  from;
		private bool lbSR1_Enabled_c3;
		private bool lbSR1_Move_c3;
		private bool lbSR1_Moving_c3;
		private bool lbSR1_CW1_CCW0_c3;
		private bool lbSR1_ManualMode_c3;
		private bool lbSR1_EncoderSetup_c3;
		private bool lbSR1_Homing_c3;
		private bool lbSR1_AutoControl_c3;
		private bool lbSR1_VFD_c3;
		private bool lbSR1_SafetyCkt_c3;
		private bool lbSR1_Ready_c3;

		// Status Register 1  Register;
		// Write from controller  to;
		private bool lbHomingStart_c3;
		private bool lbHomingStop_c3;
		private bool lbEncoderStart_c3;
		private bool lbEncoderStop_c3;
		private bool lbManualMode_c3;
		//private bool lbHomingStartLatch_c3;

		// Flags
		// From controller  controller;
		private bool lbMoveFWD_c3;
		private bool lbMoveREV_c3;
		private bool lbMoveSPD0_c3;
		private bool lbMoveSPD1_c3;

		//private bool lbTndNTagReadMM1Stat_c3;
		//private bool lbTndNTagWriteMM1Stat_c3;
		//private bool lbTndNTagWriteMM2Stat_c3;
		//private bool lbTndNTagWriteMM3Stat_c3;
		//private bool lbTndNTagWriteMM4Stat_c3;

		private bool lbFWD_c3;
		private bool lbREV_c3;
		private bool lbSTOP_c3;
		private bool lbJogF_c3;
		private bool lbJogR_c3;

		//
		// Carousel 4 items
		//
		private int lnRequestedBin_c4;
		private int lnSetBinPos_c4;

		private int lnNumBins_c4;
		private int lnCurBin_c4;
		private int lnTgtBin_c4;

		private int lnReqBin_c4;

		private int lnStatReg1_c4;
		private int lnStatReg2_c4;

		private int lnVFDRunStat_c4;
		private int lnVFDFaultStat_c4;

		// Status Register 1
		// Read from controller
		private bool lbSR1_Enabled_c4;
		private bool lbSR1_Move_c4;
		private bool lbSR1_Moving_c4;
		private bool lbSR1_CW1_CCW0_c4;
		private bool lbSR1_ManualMode_c4;
		private bool lbSR1_EncoderSetup_c4;
		private bool lbSR1_Homing_c4;
		private bool lbSR1_AutoControl_c4;
		private bool lbSR1_VFD_c4;
		private bool lbSR1_SafetyCkt_c4;
		private bool lbSR1_Ready_c4;

		// Status Register 1
		// Write from controller
		private bool lbHomingStart_c4;
		private bool lbHomingStop_c4;
		private bool lbEncoderStart_c4;
		private bool lbEncoderStop_c4;
		private bool lbManualMode_c4;
		//private bool lbHomingStartLatch_c4;

		// Flags
		// From controller
		private bool lbMoveFWD_c4;
		private bool lbMoveREV_c4;
		private bool lbMoveSPD0_c4;
		private bool lbMoveSPD1_c4;

		//private bool lbTndNTagReadMM1Stat_c4;
		//private bool lbTndNTagWriteMM1Stat_c4;
		//private bool lbTndNTagWriteMM2Stat_c4;
		//private bool lbTndNTagWriteMM3Stat_c4;
		//private bool lbTndNTagWriteMM4Stat_c4;

		private bool lbFWD_c4;
		private bool lbREV_c4;
		private bool lbSTOP_c4;
		private bool lbJogF_c4;
		private bool lbJogR_c4;

		//
		// Setup
		//
		//private bool lbPrmLoad_c1;
		//private bool lbPrmLoad_c2;
		//private bool lbPrmLoad_c3;
		//private bool lbPrmLoad_c4;

		// Carousel 1
		//private bool lbReadErrorPrm_c1;
		//private bool lbWriteErrorPrm_c1;
		//private bool lnTndNTagRead1StatPrm_c1;
		//private bool lnTndNTagWrite1StatPrm_c1;

		private short lnNumBinsPrm_c1;
		private int lnRatioPrm_c1;
		private short lnBinTolPctPrm_c1;
		private short lnControlTypePrm_c1;
		private short lnMMMDelayPrm_c1;
		private short lnStepsPerRevPrm_c1;
		private short nPosOffsetPct_c1;

		private short lnSlowPreset1Prm_c1;
		private short lnSlowPreset2Prm_c1;
		private short lnSlowPreset3Prm_c1;
		private short lnStopPresetPrm_c1;

		private uint lnSafetyConfigPrm_c1;

		// Carousel 2
		//private bool lbReadErrorPrm_c2;
		//private bool lbWriteErrorPrm_c2;
		//private bool lbTndNTagRead1StatPrm_c2;
		//private bool lbTndNTagWrite1StatPrm_c2;

		private short lnNumBinsPrm_c2;
		private int lnRatioPrm_c2;
		private short lnBinTolPctPrm_c2;
		private short lnControlTypePrm_c2;
		private short lnMMMDelayPrm_c2;
		private short lnStepsPerRevPrm_c2;
		private short nPosOffsetPct_c2;

		private short lnSlowPreset1Prm_c2;
		private short lnSlowPreset2Prm_c2;
		private short lnSlowPreset3Prm_c2;
		private short lnStopPresetPrm_c2;

		private uint lnSafetyConfigPrm_c2;

		// Carousel 3
		//private bool lbReadErrorPrm_c3;
		//private bool lbWriteErrorPrm_c3;
		//private bool lbTndNTagRead1StatPrm_c3;
		//private bool lbTndNTagWrite1StatPrm_c3;

		private short lnNumBinsPrm_c3;
		private int lnRatioPrm_c3;
		private short lnBinTolPctPrm_c3;
		private short lnControlTypePrm_c3;
		private short lnMMMDelayPrm_c3;
		private short lnStepsPerRevPrm_c3;
		private short nPosOffsetPct_c3;

		private short lnSlowPreset1Prm_c3;
		private short lnSlowPreset2Prm_c3;
		private short lnSlowPreset3Prm_c3;
		private short lnStopPresetPrm_c3;

		private uint lnSafetyConfigPrm_c3;

		// Carousel 4
		//private bool lbReadErrorPrm_c4;
		//private bool lbWriteErrorPrm_c4;

		private short lnNumBinsPrm_c4;
		private int lnRatioPrm_c4;
		private short lnBinTolPctPrm_c4;
		private short lnControlTypePrm_c4;
		private short lnMMMDelayPrm_c4;
		private short lnStepsPerRevPrm_c4;
		private short nPosOffsetPct_c4;

		private short lnSlowPreset1Prm_c4;
		private short lnSlowPreset2Prm_c4;
		private short lnSlowPreset3Prm_c4;
		private short lnStopPresetPrm_c4;

		private uint lnSafetyConfigPrm_c4;

		#endregion

		private readonly CTndNTag _tndNTag = new CTndNTag();

		private CTndNTag.DI diWriteRetentiveData = new CTndNTag.DI("WriteRetentiveData");

		#region Main Read/Write data items --------------------------------------------------------

		// Carousel 1
		private CTndNTag.DI diMotorFWC_c1	= new CTndNTag.DI("MotorFWD_c1");
		private CTndNTag.DI diMotorREV_c1	= new CTndNTag.DI("MotorREV_c1");
		private CTndNTag.DI diMotorSPD0_c1	= new CTndNTag.DI("MotorSPD0_c1");
		private CTndNTag.DI diMotorSPD1_c1	= new CTndNTag.DI("MotorSPD1_c1");
		private CTndNTag.DI diNumOfBins_c1	= new CTndNTag.DI("NumOfBins_c1");
		private CTndNTag.DI diCurrentBin_c1 = new CTndNTag.DI("CurrentBin_c1");
		private CTndNTag.DI diTargetBin_c1	= new CTndNTag.DI("TargetBin_c1");
		private CTndNTag.DI diStatusReg_c1	= new CTndNTag.DI("StatusReg1_c1");
		// Carousel 2
		private CTndNTag.DI diMotorFWC_c2	= new CTndNTag.DI("MotorFWD_c2");
		private CTndNTag.DI diMotorREV_c2	= new CTndNTag.DI("MotorREV_c2");
		private CTndNTag.DI diMotorSPD0_c2	= new CTndNTag.DI("MotorSPD0_c2");
		private CTndNTag.DI diMotorSPD1_c2	= new CTndNTag.DI("MotorSPD1_c2");
		private CTndNTag.DI diNumOfBins_c2	= new CTndNTag.DI("NumOfBins_c2");
		private CTndNTag.DI diCurrentBin_c2 = new CTndNTag.DI("CurrentBin_c2");
		private CTndNTag.DI diTargetBin_c2	= new CTndNTag.DI("TargetBin_c2");
		private CTndNTag.DI diStatusReg_c2	= new CTndNTag.DI("StatusReg1_c2");
		// Carousel 3
		private CTndNTag.DI diMotorFWC_c3	= new CTndNTag.DI("MotorFWD_c3");
		private CTndNTag.DI diMotorREV_c3	= new CTndNTag.DI("MotorREV_c3");
		private CTndNTag.DI diMotorSPD0_c3	= new CTndNTag.DI("MotorSPD0_c3");
		private CTndNTag.DI diMotorSPD1_c3	= new CTndNTag.DI("MotorSPD1_c3");
		private CTndNTag.DI diNumOfBins_c3	= new CTndNTag.DI("NumOfBins_c3");
		private CTndNTag.DI diCurrentBin_c3 = new CTndNTag.DI("CurrentBin_c3");
		private CTndNTag.DI diTargetBin_c3	= new CTndNTag.DI("TargetBin_c3");
		private CTndNTag.DI diStatusReg_c3	= new CTndNTag.DI("StatusReg1_c3");
		// Carousel 4
		private CTndNTag.DI diMotorFWC_c4	= new CTndNTag.DI("MotorFWD_c4");
		private CTndNTag.DI diMotorREV_c4	= new CTndNTag.DI("MotorREV_c4");
		private CTndNTag.DI diMotorSPD0_c4	= new CTndNTag.DI("MotorSPD0_c4");
		private CTndNTag.DI diMotorSPD1_c4	= new CTndNTag.DI("MotorSPD1_c4");
		private CTndNTag.DI diNumOfBins_c4	= new CTndNTag.DI("NumOfBins_c4");
		private CTndNTag.DI diCurrentBin_c4 = new CTndNTag.DI("CurrentBin_c4");
		private CTndNTag.DI diTargetBin_c4	= new CTndNTag.DI("TargetBin_c4");
		private CTndNTag.DI diStatusReg_c4	= new CTndNTag.DI("StatusReg1_c4");
		// VFDs
		private CTndNTag.DI diVFDRunStatus_c1	 = new CTndNTag.DI("VFDRunStatus_c1");
		private CTndNTag.DI diVFDRunStatus_c2	 = new CTndNTag.DI("VFDRunStatus_c2");
		private CTndNTag.DI diVFDRunStatus_c3	 = new CTndNTag.DI("VFDRunStatus_c3");
		private CTndNTag.DI diVFDRunStatus_c4	 = new CTndNTag.DI("VFDRunStatus_c4");
		private CTndNTag.DI diVFDFault1Status_c1 = new CTndNTag.DI("VFDFault1Status_c1");
		private CTndNTag.DI diVFDFault1Status_c2 = new CTndNTag.DI("VFDFault1Status_c2");
		private CTndNTag.DI diVFDFault1Status_c3 = new CTndNTag.DI("VFDFault1Status_c3");
		private CTndNTag.DI diVFDFault1Status_c4 = new CTndNTag.DI("VFDFault1Status_c4");

		private CTndNTag.DI diStatusReg2_c1		= new CTndNTag.DI("StatusReg2_c1");
		private CTndNTag.DI diRequestedBin_c1	= new CTndNTag.DI("RequestedBin_c1");
		private CTndNTag.DI diStatusReg2_c2		= new CTndNTag.DI("StatusReg2_c2");
		private CTndNTag.DI diRequestedBin_c2	= new CTndNTag.DI("RequestedBin_c2");
		private CTndNTag.DI diStatusReg2_c3		= new CTndNTag.DI("StatusReg2_c3");
		private CTndNTag.DI diRequestedBin_c3	= new CTndNTag.DI("RequestedBin_c3");
		private CTndNTag.DI diStatusReg2_c4		= new CTndNTag.DI("StatusReg2_c4");
		private CTndNTag.DI diRequestedBin_c4	= new CTndNTag.DI("RequestedBin_c4");
		private CTndNTag.DI diHeartbeat			= new CTndNTag.DI("Heartbeat");
		private CTndNTag.DI diSetBinPos_c1		= new CTndNTag.DI("SetBinPos_c1");
		private CTndNTag.DI diSetBinPos_c2		= new CTndNTag.DI("SetBinPos_c2");
		private CTndNTag.DI diSetBinPos_c3		= new CTndNTag.DI("SetBinPos_c3");
		private CTndNTag.DI diSetBinPos_c4		= new CTndNTag.DI("SetBinPos_c4");

		#endregion

		#region Manual Mode data items ------------------------------------------------------------

		// private readonly CTndNTag AxTndNTagReadMM1_c1 = new CTndNTag();
		private CTndNTag.DI diFWD_button_c1 = new CTndNTag.DI("FWD_button_c1");
		private CTndNTag.DI diREV_button_c1 = new CTndNTag.DI("REV_button_c1");
		private CTndNTag.DI diSTOP_button_c1 = new CTndNTag.DI("STOP_button_c1");
		// private readonly CTndNTag AxTndNTagWriteMM4_c1 = new CTndNTag();
		private CTndNTag.DI diJOGF_button_c1 = new CTndNTag.DI("JOGF_button_c1");
		private CTndNTag.DI diJOGR_button_c1 = new CTndNTag.DI("JOGR_button_c1");

		// private readonly CTndNTag AxTndNTagReadMM1_c2 = new CTndNTag();
		private CTndNTag.DI diFWD_button_c2 = new CTndNTag.DI("FWD_button_c2");
		private CTndNTag.DI diREV_button_c2 = new CTndNTag.DI("REV_button_c2");
		private CTndNTag.DI diSTOP_button_c2 = new CTndNTag.DI("STOP_button_c2");
		// private readonly CTndNTag AxTndNTagWriteMM4_c2 = new CTndNTag();
		private CTndNTag.DI diJOGF_button_c2 = new CTndNTag.DI("JOGF_button_c2");
		private CTndNTag.DI diJOGR_button_c2 = new CTndNTag.DI("JOGR_button_c2");

		// private readonly CTndNTag AxTndNTagReadMM1_c3 = new CTndNTag();
		private CTndNTag.DI diFWD_button_c3 = new CTndNTag.DI("FWD_button_c3");
		private CTndNTag.DI diREV_button_c3 = new CTndNTag.DI("REV_button_c3");
		private CTndNTag.DI diSTOP_button_c3 = new CTndNTag.DI("STOP_button_c3");
		// private readonly CTndNTag AxTndNTagWriteMM4_c3 = new CTndNTag();
		private CTndNTag.DI diJOGF_button_c3 = new CTndNTag.DI("JOGF_button_c3");
		private CTndNTag.DI diJOGR_button_c3 = new CTndNTag.DI("JOGR_button_c3");

		// private readonly CTndNTag AxTndNTagReadMM1_c4 = new CTndNTag();
		private CTndNTag.DI diFWD_button_c4 = new CTndNTag.DI("FWD_button_c4");
		private CTndNTag.DI diREV_button_c4 = new CTndNTag.DI("REV_button_c4");
		private CTndNTag.DI diSTOP_button_c4 = new CTndNTag.DI("STOP_button_c4");
		// private readonly CTndNTag AxTndNTagWriteMM4_c4 = new CTndNTag();
		private CTndNTag.DI diJOGF_button_c4 = new CTndNTag.DI("JOGF_button_c4");
		private CTndNTag.DI diJOGR_button_c4 = new CTndNTag.DI("JOGR_button_c4");

		#endregion

		#region Parameters data items -------------------------------------------------------------

		//.d private CTndNTag.DI diNumOfBins_c1			= new CTndNTag.DI("NumOfBins_c1");			// NumBins
		private CTndNTag.DI dinRatio_c1				= new CTndNTag.DI("nRatio_c1");				// Ratio
		private CTndNTag.DI dinBinTolPct_c1			= new CTndNTag.DI("nBinTolPct_c1");			// BinTolPct
		private CTndNTag.DI diControlType_c1		= new CTndNTag.DI("ControlType_c1");		// ControlType
		private CTndNTag.DI diMMMDelayPreset_c1		= new CTndNTag.DI("MMMDelayPreset_c1");		// ManModeMotor
		private CTndNTag.DI diCarouselEnabled_c1	= new CTndNTag.DI("CarouselEnabled_c1");	// CarouselEnab
		private CTndNTag.DI diStepsPerRev_c1		= new CTndNTag.DI("StepsPerRev_c1");		// StepsPerRev
		private CTndNTag.DI dinBin_SlowPreset1_c1	= new CTndNTag.DI("nBin_SlowPreset1_c1");	// SlowPreset1
		private CTndNTag.DI dinBin_SlowPreset2_c1	= new CTndNTag.DI("nBin_SlowPreset2_c1");	// SlowPreset2
		private CTndNTag.DI dinBin_SlowPreset3_c1	= new CTndNTag.DI("nBin_SlowPreset3_c1");	// SlowPreset3
		private CTndNTag.DI dinBin_StopPreset_c1	= new CTndNTag.DI("nBin_StopPreset_c1");	// StopPreset
		private CTndNTag.DI dinPosOffsetPct_c1		= new CTndNTag.DI("nPosOffsetPct_c1");		// Offset
		private CTndNTag.DI diSafetyConfig_c1		= new CTndNTag.DI("SafetyConfig_c1");		// SafetyConfig

		//.d private CTndNTag.DI diNumOfBins_c2			= new CTndNTag.DI("NumOfBins_c2");			// NumBins
		private CTndNTag.DI dinRatio_c2				= new CTndNTag.DI("nRatio_c2");				// Ratio
		private CTndNTag.DI dinBinTolPct_c2			= new CTndNTag.DI("nBinTolPct_c2");			// BinTolPct
		private CTndNTag.DI diControlType_c2		= new CTndNTag.DI("ControlType_c2");		// ControlType
		private CTndNTag.DI diMMMDelayPreset_c2		= new CTndNTag.DI("MMMDelayPreset_c2");		// ManModeMotor
		private CTndNTag.DI diCarouselEnabled_c2	= new CTndNTag.DI("CarouselEnabled_c2");	// CarouselEnab
		private CTndNTag.DI diStepsPerRev_c2		= new CTndNTag.DI("StepsPerRev_c2");		// StepsPerRev
		private CTndNTag.DI dinBin_SlowPreset1_c2	= new CTndNTag.DI("nBin_SlowPreset1_c2");	// SlowPreset1
		private CTndNTag.DI dinBin_SlowPreset2_c2	= new CTndNTag.DI("nBin_SlowPreset2_c2");	// SlowPreset2
		private CTndNTag.DI dinBin_SlowPreset3_c2	= new CTndNTag.DI("nBin_SlowPreset3_c2");	// SlowPreset3
		private CTndNTag.DI dinBin_StopPreset_c2	= new CTndNTag.DI("nBin_StopPreset_c2");	// StopPreset
		private CTndNTag.DI dinPosOffsetPct_c2		= new CTndNTag.DI("nPosOffsetPct_c2");		// Offset
		private CTndNTag.DI diSafetyConfig_c2		= new CTndNTag.DI("SafetyConfig_c2");		// SafetyConfig

		//.d private CTndNTag.DI diNumOfBins_c3			= new CTndNTag.DI("NumOfBins_c3");			// NumBins
		private CTndNTag.DI dinRatio_c3				= new CTndNTag.DI("nRatio_c3");				// Ratio
		private CTndNTag.DI dinBinTolPct_c3			= new CTndNTag.DI("nBinTolPct_c3");			// BinTolPct
		private CTndNTag.DI diControlType_c3		= new CTndNTag.DI("ControlType_c3");		// ControlType
		private CTndNTag.DI diMMMDelayPreset_c3		= new CTndNTag.DI("MMMDelayPreset_c3");		// ManModeMotor
		private CTndNTag.DI diCarouselEnabled_c3	= new CTndNTag.DI("CarouselEnabled_c3");	// CarouselEnab
		private CTndNTag.DI diStepsPerRev_c3		= new CTndNTag.DI("StepsPerRev_c3");		// StepsPerRev
		private CTndNTag.DI dinBin_SlowPreset1_c3	= new CTndNTag.DI("nBin_SlowPreset1_c3");	// SlowPreset1
		private CTndNTag.DI dinBin_SlowPreset2_c3	= new CTndNTag.DI("nBin_SlowPreset2_c3");	// SlowPreset2
		private CTndNTag.DI dinBin_SlowPreset3_c3	= new CTndNTag.DI("nBin_SlowPreset3_c3");	// SlowPreset3
		private CTndNTag.DI dinBin_StopPreset_c3	= new CTndNTag.DI("nBin_StopPreset_c3");	// StopPreset
		private CTndNTag.DI dinPosOffsetPct_c3		= new CTndNTag.DI("nPosOffsetPct_c3");		// Offset
		private CTndNTag.DI diSafetyConfig_c3		= new CTndNTag.DI("SafetyConfig_c3");		// SafetyConfig

		//.d private CTndNTag.DI diNumOfBins_c4			= new CTndNTag.DI("NumOfBins_c4");			// NumBins
		private CTndNTag.DI dinRatio_c4				= new CTndNTag.DI("nRatio_c4");				// Ratio
		private CTndNTag.DI dinBinTolPct_c4			= new CTndNTag.DI("nBinTolPct_c4");			// BinTolPct
		private CTndNTag.DI diControlType_c4		= new CTndNTag.DI("ControlType_c4");		// ControlType
		private CTndNTag.DI diMMMDelayPreset_c4		= new CTndNTag.DI("MMMDelayPreset_c4");		// ManModeMotor
		private CTndNTag.DI diCarouselEnabled_c4	= new CTndNTag.DI("CarouselEnabled_c4");	// CarouselEnab
		private CTndNTag.DI diStepsPerRev_c4		= new CTndNTag.DI("StepsPerRev_c4");		// StepsPerRev
		private CTndNTag.DI dinBin_SlowPreset1_c4	= new CTndNTag.DI("nBin_SlowPreset1_c4");	// SlowPreset1
		private CTndNTag.DI dinBin_SlowPreset2_c4	= new CTndNTag.DI("nBin_SlowPreset2_c4");	// SlowPreset2
		private CTndNTag.DI dinBin_SlowPreset3_c4	= new CTndNTag.DI("nBin_SlowPreset3_c4");	// SlowPreset3
		private CTndNTag.DI dinBin_StopPreset_c4	= new CTndNTag.DI("nBin_StopPreset_c4");	// StopPreset
		private CTndNTag.DI dinPosOffsetPct_c4		= new CTndNTag.DI("nPosOffsetPct_c4");		// Offset
		private CTndNTag.DI diSafetyConfig_c4		= new CTndNTag.DI("SafetyConfig_c4");       // SafetyConfig

        #endregion

    }
}
