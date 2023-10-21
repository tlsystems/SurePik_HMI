using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_TndNTag
{
	class Class1
	{
		private const string ProjectPath = @"D:\.TND10\.Projects\UTP40 SurePik\SurePik C4 Rev5.tnd";

		public TestTndNTag_CS()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
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

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
				lnStatReg2_c1 = 0;
				lnStatReg2_c1 += 2 ^ 1; // Stop Homing
				lnStatReg2_c2 = 0;
				lnStatReg2_c2 += 2 ^ 1; // Stop Homing
				lnStatReg2_c3 = 0;
				lnStatReg2_c3 += 2 ^ 1; // Stop Homing
				lnStatReg2_c4 = 0;
				lnStatReg2_c4 += 2 ^ 1; // Stop Homing

				// // All data items in the TndNTag must be written to.

				AxTndNTagWrite1.UpdateLongValue(0, lnStatReg2_c1);
				AxTndNTagWrite1.UpdateLongValue(1, lnReqBin_c1);
				AxTndNTagWrite1.UpdateLongValue(2, lnStatReg2_c2);
				AxTndNTagWrite1.UpdateLongValue(3, lnReqBin_c2);
				AxTndNTagWrite1.UpdateLongValue(4, lnStatReg2_c3);
				AxTndNTagWrite1.UpdateLongValue(5, lnReqBin_c3);
				AxTndNTagWrite1.UpdateLongValue(6, lnStatReg2_c4);
				AxTndNTagWrite1.UpdateLongValue(7, lnReqBin_c4);
				AxTndNTagWrite1.UpdateLongValue(8, lnHeartbeat);
				AxTndNTagWrite1.UpdateLongValue(9, lnSetBinPos_c1);
				AxTndNTagWrite1.UpdateLongValue(10, lnSetBinPos_c2);
				AxTndNTagWrite1.UpdateLongValue(11, lnSetBinPos_c3);
				AxTndNTagWrite1.UpdateLongValue(12, lnSetBinPos_c4);
				AxTndNTagWrite1.Write();
			}

		}

		private void TndStartup()
		{
			AxTndNTagRead1.Open(ProjectPath);
			AxTndNTagWrite1.Open(ProjectPath);

			// Manual Mode Initialize TndNTags
			// Carousel 1
			AxTndNTagReadMM1_c1.Open(ProjectPath);
			AxTndNTagWriteMM1_c1.Open(ProjectPath);
			AxTndNTagWriteMM2_c1.Open(ProjectPath);
			AxTndNTagWriteMM3_c1.Open(ProjectPath);
			AxTndNTagWriteMM4_c1.Open(ProjectPath);
			// Carousel 2
			AxTndNTagReadMM1_c2.Open(ProjectPath);
			AxTndNTagWriteMM1_c2.Open(ProjectPath);
			AxTndNTagWriteMM2_c2.Open(ProjectPath);
			AxTndNTagWriteMM3_c2.Open(ProjectPath);
			AxTndNTagWriteMM4_c2.Open(ProjectPath);
			// Carousel 3
			AxTndNTagReadMM1_c3.Open(ProjectPath);
			AxTndNTagWriteMM1_c3.Open(ProjectPath);
			AxTndNTagWriteMM2_c3.Open(ProjectPath);
			AxTndNTagWriteMM3_c3.Open(ProjectPath);
			AxTndNTagWriteMM4_c3.Open(ProjectPath);
			// Carousel 4
			AxTndNTagReadMM1_c4.Open(ProjectPath);
			AxTndNTagWriteMM1_c4.Open(ProjectPath);
			AxTndNTagWriteMM2_c4.Open(ProjectPath);
			AxTndNTagWriteMM3_c4.Open(ProjectPath);
			AxTndNTagWriteMM4_c4.Open(ProjectPath);

			// Register tags AxTndNTagRead1
			// Carousel 1
			AxTndNTagRead1.AddItem("MotorFWD_c1");
			AxTndNTagRead1.AddItem("MotorREV_c1");
			AxTndNTagRead1.AddItem("MotorSPD0_c1");
			AxTndNTagRead1.AddItem("MotorSPD1_c1");
			AxTndNTagRead1.AddItem("NumOfBins_c1");
			AxTndNTagRead1.AddItem("CurrentBin_c1");
			AxTndNTagRead1.AddItem("TargetBin_c1");
			AxTndNTagRead1.AddItem("StatusReg1_c1");
			// Carousel 2
			AxTndNTagRead1.AddItem("MotorFWD_c2");
			AxTndNTagRead1.AddItem("MotorREV_c2");
			AxTndNTagRead1.AddItem("MotorSPD0_c2");
			AxTndNTagRead1.AddItem("MotorSPD1_c2");
			AxTndNTagRead1.AddItem("NumOfBins_c2");
			AxTndNTagRead1.AddItem("CurrentBin_c2");
			AxTndNTagRead1.AddItem("TargetBin_c2");
			AxTndNTagRead1.AddItem("StatusReg1_c2");
			// Carousel 3
			AxTndNTagRead1.AddItem("MotorFWD_c3");
			AxTndNTagRead1.AddItem("MotorREV_c3");
			AxTndNTagRead1.AddItem("MotorSPD0_c3");
			AxTndNTagRead1.AddItem("MotorSPD1_c3");
			AxTndNTagRead1.AddItem("NumOfBins_c3");
			AxTndNTagRead1.AddItem("CurrentBin_c3");
			AxTndNTagRead1.AddItem("TargetBin_c3");
			AxTndNTagRead1.AddItem("StatusReg1_c3");
			// Carousel 4
			AxTndNTagRead1.AddItem("MotorFWD_c4");
			AxTndNTagRead1.AddItem("MotorREV_c4");
			AxTndNTagRead1.AddItem("MotorSPD0_c4");
			AxTndNTagRead1.AddItem("MotorSPD1_c4");
			AxTndNTagRead1.AddItem("NumOfBins_c4");
			AxTndNTagRead1.AddItem("CurrentBin_c4");
			AxTndNTagRead1.AddItem("TargetBin_c4");
			AxTndNTagRead1.AddItem("StatusReg1_c4");
			// VFDs
			AxTndNTagRead1.AddItem("VFDRunStatus_c1");
			AxTndNTagRead1.AddItem("VFDRunStatus_c2");
			AxTndNTagRead1.AddItem("VFDRunStatus_c3");
			AxTndNTagRead1.AddItem("VFDRunStatus_c4");
			AxTndNTagRead1.AddItem("VFDFault1Status_c1");
			AxTndNTagRead1.AddItem("VFDFault1Status_c2");
			AxTndNTagRead1.AddItem("VFDFault1Status_c3");
			AxTndNTagRead1.AddItem("VFDFault1Status_c4");

			// Register tags AxTndNTagWrite1
			AxTndNTagWrite1.AddItem("StatusReg2_c1");
			AxTndNTagWrite1.AddItem("RequestedBin_c1");
			AxTndNTagWrite1.AddItem("StatusReg2_c2");
			AxTndNTagWrite1.AddItem("RequestedBin_c2");
			AxTndNTagWrite1.AddItem("StatusReg2_c3");
			AxTndNTagWrite1.AddItem("RequestedBin_c3");
			AxTndNTagWrite1.AddItem("StatusReg2_c4");
			AxTndNTagWrite1.AddItem("RequestedBin_c4");
			AxTndNTagWrite1.AddItem("Heartbeat");
			AxTndNTagWrite1.AddItem("SetBinPos_c1");
			AxTndNTagWrite1.AddItem("SetBinPos_c2");
			AxTndNTagWrite1.AddItem("SetBinPos_c3");
			AxTndNTagWrite1.AddItem("SetBinPos_c4");

			// Register tags Manual mode Carousel 1
			// AxTndNTagReadMM1_c1
			AxTndNTagReadMM1_c1.AddItem("FWD_button_c1");
			AxTndNTagReadMM1_c1.AddItem("REV_button_c1");
			AxTndNTagReadMM1_c1.AddItem("STOP_button_c1");
			// AxTndNTagWriteMM1_c1
			AxTndNTagWriteMM1_c1.AddItem("FWD_button_c1");
			// AxTndNTagWriteMM2_c1
			AxTndNTagWriteMM2_c1.AddItem("REV_button_c1");
			// AxTndNTagWriteMM3_c1
			AxTndNTagWriteMM3_c1.AddItem("STOP_button_c1");
			// AxTndNTagWriteMM4_c1
			AxTndNTagWriteMM4_c1.AddItem("JOGF_button_c1");
			AxTndNTagWriteMM4_c1.AddItem("JOGR_button_c1");

			// Register tags Manual mode Carousel 2
			// AxTndNTagReadMM1_c2
			AxTndNTagReadMM1_c2.AddItem("FWD_button_c2");
			AxTndNTagReadMM1_c2.AddItem("REV_button_c2");
			AxTndNTagReadMM1_c2.AddItem("STOP_button_c2");
			// AxTndNTagWriteMM1_c2
			AxTndNTagWriteMM1_c2.AddItem("FWD_button_c2");
			// AxTndNTagWriteMM2_c2
			AxTndNTagWriteMM2_c2.AddItem("REV_button_c2");
			// AxTndNTagWriteMM3_c2
			AxTndNTagWriteMM3_c2.AddItem("STOP_button_c2");
			// AxTndNTagWriteMM4_c2
			AxTndNTagWriteMM4_c2.AddItem("JOGF_button_c2");
			AxTndNTagWriteMM4_c2.AddItem("JOGR_button_c2");

			// Register tags Manual mode Carousel 3
			// AxTndNTagReadMM1_c3
			AxTndNTagReadMM1_c3.AddItem("FWD_button_c3");
			AxTndNTagReadMM1_c3.AddItem("REV_button_c3");
			AxTndNTagReadMM1_c3.AddItem("STOP_button_c3");
			// AxTndNTagWriteMM1_c3
			AxTndNTagWriteMM1_c3.AddItem("FWD_button_c3");
			// AxTndNTagWriteMM2_c3
			AxTndNTagWriteMM2_c3.AddItem("REV_button_c3");
			// AxTndNTagWriteMM3_c3
			AxTndNTagWriteMM3_c3.AddItem("STOP_button_c3");
			// AxTndNTagWriteMM4_c3
			AxTndNTagWriteMM4_c3.AddItem("JOGF_button_c3");
			AxTndNTagWriteMM4_c3.AddItem("JOGR_button_c3");

			// Register tags Manual mode Carousel 4
			// AxTndNTagReadMM1_c4
			AxTndNTagReadMM1_c4.AddItem("FWD_button_c4");
			AxTndNTagReadMM1_c4.AddItem("REV_button_c4");
			AxTndNTagReadMM1_c4.AddItem("STOP_button_c4");
			// AxTndNTagWriteMM1_c4
			AxTndNTagWriteMM1_c4.AddItem("FWD_button_c4");
			// AxTndNTagWriteMM2_c4
			AxTndNTagWriteMM2_c4.AddItem("REV_button_c4");
			// AxTndNTagWriteMM3_c4
			AxTndNTagWriteMM3_c4.AddItem("STOP_button_c4");
			// AxTndNTagWriteMM4_c4
			AxTndNTagWriteMM4_c4.AddItem("JOGF_button_c4");
			AxTndNTagWriteMM4_c4.AddItem("JOGR_button_c4");

		}

		private void tmrTnDNTag1_Tick(object sender, EventArgs e)
		{
			//  A timer can be used to Read from and/or Write to the controller.


			tmrTnDNTag1.Enabled = false;

			//
			//  Read tags // 
			//

			lbTndNTagRead1Stat = AxTndNTagRead1.IsValid();
			if (lbTndNTagRead1Stat)
			{
				//  Read Data from controller
				//  Carousel 1
				lbMoveFWD_c1 = AxTndNTagRead1.GetBoolValue(0);
				lbMoveREV_c1 = AxTndNTagRead1.GetBoolValue(1);
				lbMoveSPD0_c1 = AxTndNTagRead1.GetBoolValue(2);
				lbMoveSPD1_c1 = AxTndNTagRead1.GetBoolValue(3);
				lnNumBins_c1 = AxTndNTagRead1.GetIntValue(4);
				lnCurBin_c1 = AxTndNTagRead1.GetIntValue(5);
				lnTgtBin_c1 = AxTndNTagRead1.GetIntValue(6);
				lnStatReg1_c1 = AxTndNTagRead1.GetIntValue(7);
				//  Carousel 2
				lbMoveFWD_c2 = AxTndNTagRead1.GetBoolValue(8);
				lbMoveREV_c2 = AxTndNTagRead1.GetBoolValue(9);
				lbMoveSPD0_c2 = AxTndNTagRead1.GetBoolValue(10);
				lbMoveSPD1_c2 = AxTndNTagRead1.GetBoolValue(11);
				lnNumBins_c2 = AxTndNTagRead1.GetIntValue(12);
				lnCurBin_c2 = AxTndNTagRead1.GetIntValue(13);
				lnTgtBin_c2 = AxTndNTagRead1.GetIntValue(14);
				lnStatReg1_c2 = AxTndNTagRead1.GetIntValue(15);
				//  Carousel 3
				lbMoveFWD_c3 = AxTndNTagRead1.GetBoolValue(16);
				lbMoveREV_c3 = AxTndNTagRead1.GetBoolValue(17);
				lbMoveSPD0_c3 = AxTndNTagRead1.GetBoolValue(18);
				lbMoveSPD1_c3 = AxTndNTagRead1.GetBoolValue(19);
				lnNumBins_c3 = AxTndNTagRead1.GetIntValue(20);
				lnCurBin_c3 = AxTndNTagRead1.GetIntValue(21);
				lnTgtBin_c3 = AxTndNTagRead1.GetIntValue(22);
				lnStatReg1_c3 = AxTndNTagRead1.GetIntValue(23);
				//  Carousel 4
				lbMoveFWD_c4 = AxTndNTagRead1.GetBoolValue(24);
				lbMoveREV_c4 = AxTndNTagRead1.GetBoolValue(25);
				lbMoveSPD0_c4 = AxTndNTagRead1.GetBoolValue(26);
				lbMoveSPD1_c4 = AxTndNTagRead1.GetBoolValue(27);
				lnNumBins_c4 = AxTndNTagRead1.GetIntValue(28);
				lnCurBin_c4 = AxTndNTagRead1.GetIntValue(29);
				lnTgtBin_c4 = AxTndNTagRead1.GetIntValue(30);
				lnStatReg1_c4 = AxTndNTagRead1.GetIntValue(31);
				//  VFDs
				lnVFDRunStat_c1 = AxTndNTagRead1.GetIntValue(32);
				lnVFDRunStat_c2 = AxTndNTagRead1.GetIntValue(33);
				lnVFDRunStat_c3 = AxTndNTagRead1.GetIntValue(34);
				lnVFDRunStat_c4 = AxTndNTagRead1.GetIntValue(35);
				lnVFDFaultStat_c1 = AxTndNTagRead1.GetIntValue(36);
				lnVFDFaultStat_c2 = AxTndNTagRead1.GetIntValue(37);
				lnVFDFaultStat_c3 = AxTndNTagRead1.GetIntValue(38);
				lnVFDFaultStat_c4 = AxTndNTagRead1.GetIntValue(39);


				//  Update Form
				//  Carousel 1
				txtNumBins_c1.Text = $"{lnNumBins_c1}";
				txtCurrentBin_c1.Text = $"{lnCurBin_c1}";
				txtTargetBin_c1.Text = (lnTgtBin_c1 != 0) ? $"{lnTgtBin_c1}" : $"{lnNumBins_c1}";
				txtStatReg1_c1.Text = $"{lnStatReg1_c1}";

				//  Carousel 2
				txtNumBins_c2.Text = lnNumBins_c2.ToString();
				txtCurrentBin_c2.Text = lnCurBin_c2.ToString();
				txtTargetBin_c2.Text = (lnTgtBin_c2 != 0) ? $"{lnTgtBin_c2}" : $"{lnNumBins_c2}";
				txtStatReg1_c2.Text = lnStatReg1_c2.ToString();

				//  Carousel 3
				txtNumBins_c3.Text = lnNumBins_c3.ToString();
				txtCurrentBin_c3.Text = lnCurBin_c3.ToString();
				txtTargetBin_c3.Text = (lnTgtBin_c3 != 0) ? $"{lnTgtBin_c3}" : $"{lnNumBins_c3}";
				txtStatReg1_c3.Text = $"{lnStatReg1_c3}";

				//  Carousel 4
				txtNumBins_c4.Text = $"{lnNumBins_c4}";
				txtCurrentBin_c4.Text = $"{lnCurBin_c4}";
				txtTargetBin_c4.Text = (lnTgtBin_c4 != 0) ? $"{lnTgtBin_c4}" : $"{lnNumBins_c4}";
				txtStatReg1_c4.Text = $"{lnStatReg1_c4}";

				//  Breakout Status Register 1
				//  Carousel 1
				lbSR1_Enabled_c1 = (lnStatReg1_c1 & 2 ^ 0) != 0;
				lbSR1_Move_c1 = (lnStatReg1_c1 & 2 ^ 1) != 0;
				lbSR1_Moving_c1 = (lnStatReg1_c1 & 2 ^ 2) != 0;
				lbSR1_CW1_CCW0_c1 = (lnStatReg1_c1 & 2 ^ 3) != 0;
				lbSR1_ManualMode_c1 = (lnStatReg1_c1 & 2 ^ 4) != 0;
				lbSR1_EncoderSetup_c1 = (lnStatReg1_c1 & 2 ^ 5) != 0;
				lbSR1_Homing_c1 = (lnStatReg1_c1 & 2 ^ 6) != 0;
				lbSR1_AutoControl_c1 = (lnStatReg1_c1 & 2 ^ 7) != 0;
				lbSR1_VFD_c1 = (lnStatReg1_c1 & 2 ^ 8) != 0;
				lbSR1_SafetyCkt_c1 = (lnStatReg1_c1 & 2 ^ 9) != 0;
				lbSR1_Ready_c1 = (lnStatReg1_c1 & 2 ^ 10) != 0;

				//  Carousel 2
				lbSR1_Enabled_c2 = (lnStatReg1_c2 & 2 ^ 0) != 0;
				lbSR1_Move_c2 = (lnStatReg1_c2 & 2 ^ 1) != 0;
				lbSR1_Moving_c2 = (lnStatReg1_c2 & 2 ^ 2) != 0;
				lbSR1_CW1_CCW0_c2 = (lnStatReg1_c2 & 2 ^ 3) != 0;
				lbSR1_ManualMode_c2 = (lnStatReg1_c2 & 2 ^ 4) != 0;
				lbSR1_EncoderSetup_c2 = (lnStatReg1_c2 & 2 ^ 5) != 0;
				lbSR1_Homing_c2 = (lnStatReg1_c2 & 2 ^ 6) != 0;
				lbSR1_AutoControl_c2 = (lnStatReg1_c2 & 2 ^ 7) != 0;
				lbSR1_VFD_c2 = (lnStatReg1_c2 & 2 ^ 8) != 0;
				lbSR1_SafetyCkt_c2 = (lnStatReg1_c2 & 2 ^ 9) != 0;
				lbSR1_Ready_c2 = (lnStatReg1_c2 & 2 ^ 10) != 0;

				//  Carousel 3
				lbSR1_Enabled_c3 = (lnStatReg1_c3 & 2 ^ 0) != 0;
				lbSR1_Move_c3 = (lnStatReg1_c3 & 2 ^ 1) != 0;
				lbSR1_Moving_c3 = (lnStatReg1_c3 & 2 ^ 2) != 0;
				lbSR1_CW1_CCW0_c3 = (lnStatReg1_c3 & 2 ^ 3) != 0;
				lbSR1_ManualMode_c3 = (lnStatReg1_c3 & 2 ^ 4) != 0;
				lbSR1_EncoderSetup_c3 = (lnStatReg1_c3 & 2 ^ 5) != 0;
				lbSR1_Homing_c3 = (lnStatReg1_c3 & 2 ^ 6) != 0;
				lbSR1_AutoControl_c3 = (lnStatReg1_c3 & 2 ^ 7) != 0;
				lbSR1_VFD_c3 = (lnStatReg1_c3 & 2 ^ 8) != 0;
				lbSR1_SafetyCkt_c3 = (lnStatReg1_c3 & 2 ^ 9) != 0;
				lbSR1_Ready_c3 = (lnStatReg1_c3 & 2 ^ 10) != 0;

				//  Carousel 4
				lbSR1_Enabled_c4 = (lnStatReg1_c4 & 2 ^ 0) != 0;
				lbSR1_Move_c4 = (lnStatReg1_c4 & 2 ^ 1) != 0;
				lbSR1_Moving_c4 = (lnStatReg1_c4 & 2 ^ 2) != 0;
				lbSR1_CW1_CCW0_c4 = (lnStatReg1_c4 & 2 ^ 3) != 0;
				lbSR1_ManualMode_c4 = (lnStatReg1_c4 & 2 ^ 4) != 0;
				lbSR1_EncoderSetup_c4 = (lnStatReg1_c4 & 2 ^ 5) != 0;
				lbSR1_Homing_c4 = (lnStatReg1_c4 & 2 ^ 6) != 0;
				lbSR1_AutoControl_c4 = (lnStatReg1_c4 & 2 ^ 7) != 0;
				lbSR1_VFD_c4 = (lnStatReg1_c4 & 2 ^ 8) != 0;
				lbSR1_SafetyCkt_c4 = (lnStatReg1_c4 & 2 ^ 9) != 0;
				lbSR1_Ready_c4 = (lnStatReg1_c4 & 2 ^ 10) != 0;
			}
			else
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
				;
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
			if (lnHeartbeat >= (2 ^ 31) - 1)
				lnHeartbeat = 0;
			else
				lnHeartbeat += lnHeartbeat;

			//  The requested bin location
			lnReqBin_c1 = lnRequestedBin_c1;
			lnReqBin_c2 = lnRequestedBin_c2;
			lnReqBin_c3 = lnRequestedBin_c3;
			lnReqBin_c4 = lnRequestedBin_c4;

			//  Carousel 1
			// StatReg2
			lnStatReg2_c1 = 0;
			// Homing
			if (lbHomingStart_c1) lnStatReg2_c1 += 2 ^ 0;
			if (lbHomingStop_c1) lnStatReg2_c1 += 2 ^ 1;
			// Encoder
			if (lbEncoderStart_c1) lnStatReg2_c1 += 2 ^ 3;
			if (lbEncoderStop_c1) lnStatReg2_c1 += 2 ^ 4;
			// Manual mode
			if (lbManualMode_c1) lnStatReg2_c1 += 2 ^ 5;
			//  Carousel 2
			// StatReg2
			lnStatReg2_c2 = 0;
			// Homing
			if (lbHomingStart_c2) lnStatReg2_c2 += 2 ^ 0;
			if (lbHomingStop_c2) lnStatReg2_c2 += 2 ^ 1;
			// Encoder
			if (lbEncoderStart_c2) lnStatReg2_c2 += 2 ^ 3;
			if (lbEncoderStop_c2) lnStatReg2_c2 += 2 ^ 4;
			// Manual mode
			if (lbManualMode_c2) lnStatReg2_c2 += 2 ^ 5;
			//  Carousel 3
			// StatReg2
			lnStatReg2_c3 = 0;
			// Homing
			if (lbHomingStart_c3) lnStatReg2_c3 += 2 ^ 0;
			if (lbHomingStop_c3) lnStatReg2_c3 += 2 ^ 1;
			// Encoder
			if (lbEncoderStart_c3) lnStatReg2_c3 += 2 ^ 3;
			if (lbEncoderStop_c3) lnStatReg2_c3 += 2 ^ 4;
			// Manual mode
			if (lbManualMode_c3) lnStatReg2_c3 += 2 ^ 5;
			//  Carousel 4
			// StatReg2
			lnStatReg2_c4 = 0;
			// Homing
			if (lbHomingStart_c4) lnStatReg2_c4 += 2 ^ 0;
			if (lbHomingStop_c4) lnStatReg2_c4 += 2 ^ 1;
			// Encoder
			if (lbEncoderStart_c4) lnStatReg2_c4 += 2 ^ 3;
			if (lbEncoderStop_c4) lnStatReg2_c4 += 2 ^ 4;
			// Manual mode
			if (lbManualMode_c4) lnStatReg2_c4 += 2 ^ 5;

			if (AxTndNTagWrite1.IsValid())
			{
				// All data items in the ocx must be written to.
				AxTndNTagWrite1.UpdateLongValue(0, lnStatReg2_c1);
				AxTndNTagWrite1.UpdateLongValue(1, lnReqBin_c1);
				AxTndNTagWrite1.UpdateLongValue(2, lnStatReg2_c2);
				AxTndNTagWrite1.UpdateLongValue(3, lnReqBin_c2);
				AxTndNTagWrite1.UpdateLongValue(4, lnStatReg2_c3);
				AxTndNTagWrite1.UpdateLongValue(5, lnReqBin_c3);
				AxTndNTagWrite1.UpdateLongValue(6, lnStatReg2_c4);
				AxTndNTagWrite1.UpdateLongValue(7, lnReqBin_c4);
				AxTndNTagWrite1.UpdateLongValue(8, lnHeartbeat);
				AxTndNTagWrite1.UpdateLongValue(9, lnSetBinPos_c1);
				AxTndNTagWrite1.UpdateLongValue(10, lnSetBinPos_c2);
				AxTndNTagWrite1.UpdateLongValue(11, lnSetBinPos_c3);
				AxTndNTagWrite1.UpdateLongValue(12, lnSetBinPos_c4);
				lbTndNTagWrite1Stat = AxTndNTagWrite1.Write();
				if (lbTndNTagWrite1Stat)
				{
					//  Success
					// Manual Mode
					WriteTagsMM_c1();
					WriteTagsMM_c2();
					WriteTagsMM_c3();
					WriteTagsMM_c4();

					tmrTnDNTag1.Enabled = true;
				}
			}
		}

		private void tmrObserver_Tick(object sender, EventArgs e)
		{
			// Homing check
			Homingcheck_c1();
			Homingcheck_c2();
			Homingcheck_c3();
			Homingcheck_c4();

			// Encoder check
			EncoderCheck_c1();
			EncoderCheck_c2();
			EncoderCheck_c3();
			EncoderCheck_c4();

			// Errors
			if (lbConrtollerInitError	 || 
				lbTndNTagRead1Stat		 ||
				lbTndNTagWrite1Stat      ||
				lbTndNTagReadMM1Stat_c1	 ||
				lbTndNTagWriteMM4Stat_c1 ||
				lbTndNTagReadMM1Stat_c2	 ||
				lbTndNTagWriteMM4Stat_c2 ||
				lbTndNTagReadMM1Stat_c3	 ||
				lbTndNTagWriteMM4Stat_c3 ||
				lbTndNTagReadMM1Stat_c4	 ||
				lbTndNTagWriteMM4Stat_c4)
			{
				lblCCFE.Visible = true;
			}
			else
			{
				lblCCFE.Visible = false;

			}

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

		private void Homingcheck_c1()
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
		private void EncoderCheck_c1()
		{
			// 'Encoder setup check
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
		private void FlagsBreakout_c1()
		{
			lblMoveFWD_c1.BackColor  = lbMoveFWD_c1  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c1.BackColor  = lbMoveREV_c1	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c1.BackColor = lbMoveSPD0_c1 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c1.BackColor = lbMoveSPD1_c1 ? Color.Goldenrod : Color.Transparent;
		}
		private void ManModeButtonColors_c1()
		{
			if (lbFWD_c1)  btnFWD_c1.BackColor  = Color.Lime; else btnFWD_c1.UseVisualStyleBackColor = true;
			if (lbREV_c1)  btnREV_c1.BackColor  = Color.Lime; else btnREV_c1.UseVisualStyleBackColor = true;
			if (lbSTOP_c1) btnSTOP_c1.BackColor = Color.Red;  else btnSTOP_c1.UseVisualStyleBackColor = true;
			if (lbSR1_Homing_c1 && lbHomingStartLatch_c1)
				btnHomingStart_c1.BackColor = Color.Lime;
			else
				btnHomingStart_c1.UseVisualStyleBackColor = true;
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
		private void SetFocusReqBin_c1()
		{
			txtReqBin_c1.Focus();
			txtReqBin_c1.SelectAll();
		}
		private void tmrReqBin_c1_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c1.Enabled = False
			lnRequestedBin_c1 = 0;
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
		private void ManualModeStartup_c1()
		{
			lbFWD_c1 = false;
			lbREV_c1 = false;
			lbSTOP_c1 = true;
			lbJogF_c1 = false;
			lbJogR_c1 = false;
		}
		private void ReadTagsMM_c1()
		{
			// Read tags

			lbTndNTagReadMM1Stat_c1 = AxTndNTagReadMM1_c1.Read();
			if (lbTndNTagReadMM1Stat_c1)
			{
				lbFWD_c1 = AxTndNTagReadMM1_c1.GetBoolValue(0);
				lbREV_c1 = AxTndNTagReadMM1_c1.GetBoolValue(1);
				lbSTOP_c1 = AxTndNTagReadMM1_c1.GetBoolValue(2);
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c1");
			}
		}
		private void WriteTagsMM_c1()
		{
			// Write tags
			AxTndNTagWriteMM4_c1.UpdateLongValue(0, lbJogF_c1 ? 1 : 0);
			AxTndNTagWriteMM4_c1.UpdateLongValue(1, lbJogR_c1 ? 1 : 0);
			lbTndNTagWriteMM4Stat_c1 = AxTndNTagWriteMM4_c1.Write();
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
				AxTndNTagWriteMM1_c1.UpdateLongValue(0, 1);
				lbTndNTagWriteMM1Stat_c1 = AxTndNTagWriteMM1_c1.Write();
			}
		}
		private void ReverseMM_c1()
		{
			if (!lbFWD_c1)
			{
				// Write tags
				AxTndNTagWriteMM2_c1.UpdateLongValue(0, 1);
				lbTndNTagWriteMM2Stat_c1 = AxTndNTagWriteMM2_c1.Write();
			}
		}
		private void StopMM_c1()
		{
			// Write tags
			AxTndNTagWriteMM3_c1.UpdateLongValue(0, 1);
			lbTndNTagWriteMM3Stat_c1 = AxTndNTagWriteMM3_c1.Write();
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
		private void TabPageSetup_c1_Enter(object sender, EventArgs e)
		{
			PrmLoad_c1();
		}
		private void PrmLoad_c1()
		{
			if (lbPrmLoad_c1)
			{
				if (!lbReadErrorPrm_c1 && lbWriteErrorPrm_c1)
					ReadTagsPrm_c1();
			}
			else
			{
				lblReadErrorPrm_c1.Visible = false;
				lblWriteErrorPrm_c1.Visible = false;

				if (AxTndNTagReadPrm_c1.IsValid())
				{
					// Register tags
					AxTndNTagReadPrm_c1.AddItem("NumOfBins_c1");        // NumBins
					AxTndNTagReadPrm_c1.AddItem("nRatio_c1");           // Ratio
					AxTndNTagReadPrm_c1.AddItem("nBinTolPct_c1");       // BinTolPct
					AxTndNTagReadPrm_c1.AddItem("ControlType_c1");      // ControlType
					AxTndNTagReadPrm_c1.AddItem("MMMDelayPreset_c1");   // ManModeMotor
					AxTndNTagReadPrm_c1.AddItem("CarouselEnabled_c1");  // CarouselEnab
					AxTndNTagReadPrm_c1.AddItem("StepsPerRev_c1");      // StepsPerRev
					AxTndNTagReadPrm_c1.AddItem("nBin_SlowPreset1_c1"); // SlowPreset1
					AxTndNTagReadPrm_c1.AddItem("nBin_SlowPreset2_c1"); // SlowPreset2
					AxTndNTagReadPrm_c1.AddItem("nBin_SlowPreset3_c1"); // SlowPreset3
					AxTndNTagReadPrm_c1.AddItem("nBin_StopPreset_c1");  // StopPreset
					AxTndNTagReadPrm_c1.AddItem("nPosOffsetPct_c1");    // Offset
					AxTndNTagReadPrm_c1.AddItem("SafetyConfig_c1");     // SafetyConfig
					if (AxTndNTagWrite1Prm_c1.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c1.AddItem("NumOfBins_c1");          // NumBins
						AxTndNTagWrite1Prm_c1.AddItem("nRatio_c1");             // Ratio
						AxTndNTagWrite1Prm_c1.AddItem("nBinTolPct_c1");         // BinTolPct
						AxTndNTagWrite1Prm_c1.AddItem("ControlType_c1");        // ControlType
						AxTndNTagWrite1Prm_c1.AddItem("MMMDelayPreset_c1");     // ManModeMotorDelay
						AxTndNTagWrite1Prm_c1.AddItem("CarouselEnabled_c1");    // CarouselEnabled
						AxTndNTagWrite1Prm_c1.AddItem("StepsPerRev_c1");        // StepsPerRev
						AxTndNTagWrite1Prm_c1.AddItem("nBin_SlowPreset1_c1");   // SlowPreset1
						AxTndNTagWrite1Prm_c1.AddItem("nBin_SlowPreset2_c1");   // SlowPreset2
						AxTndNTagWrite1Prm_c1.AddItem("nBin_SlowPreset3_c1");   // SlowPreset3
						AxTndNTagWrite1Prm_c1.AddItem("nBin_StopPreset_c1");    // StopPreset
						AxTndNTagWrite1Prm_c1.AddItem("nPosOffsetPct_c1");      // Offset
						AxTndNTagWrite1Prm_c1.AddItem("SafetyConfig_c1");       // SafetyConfig

						ReadTagsPrm_c1();
					}
					else
					{
						MessageBox.Show("Cannot connect Write1Prm_c1 to controller.");
						lblWriteErrorPrm_c1.Visible = true;
					}

					if (AxTndNTagWrite2Prm_c1.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c1.AddItem("WriteRetentiveData");
						WriteTagsPrm_c1();
						ReadTagsPrm_c1();
					}
					else
					{
						MessageBox.Show("Cannot connect Write2Prm_c1 to controller.");
						lblWriteErrorPrm_c1.Visible = true;
						lbWriteErrorPrm_c1 = true;
					}
				}
				else
				{
					MessageBox.Show("Cannot connect Read1Prm_c1 to controller.");
					lblReadErrorPrm_c1.Visible = true;
					lbReadErrorPrm_c1 = true;
				}

				lbPrmLoad_c1 = true;
			}
		}
		private void btnReadPrm_c1_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c1 && !lbWriteErrorPrm_c1)
				ReadTagsPrm_c1();
		}
		private void btnWritePrm_c1_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c1 && !lbWriteErrorPrm_c1)
				WriteTagsPrm_c1();
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
			lnTndNTagRead1StatPrm_c1 = AxTndNTagReadPrm_c1.Read();
			if (lnTndNTagRead1StatPrm_c1)
			{
				lnNumBinsPrm_c1 = AxTndNTagReadPrm_c1.GetShortValue(0);
				lnRatioPrm_c1 = AxTndNTagReadPrm_c1.GetShortValue(1);
				lnBinTolPctPrm_c1 = AxTndNTagReadPrm_c1.GetShortValue(2);
				lnControlTypePrm_c1 = AxTndNTagReadPrm_c1.GetShortValue(3);
				lnMMMDelayPrm_c1 = AxTndNTagReadPrm_c1.GetShortValue(4);
				chkEnabledPrm_c1.Checked = AxTndNTagReadPrm_c1.GetBoolValue(5);
				lnStepsPerRevPrm_c1 = AxTndNTagReadPrm_c1.GetShortValue(6);
				lnSlowPreset1Prm_c1 = AxTndNTagReadPrm_c1.GetShortValue(7);
				lnSlowPreset2Prm_c1 = AxTndNTagReadPrm_c1.GetShortValue(8);
				lnSlowPreset3Prm_c1 = AxTndNTagReadPrm_c1.GetShortValue(9);
				lnStopPresetPrm_c1 = AxTndNTagReadPrm_c1.GetShortValue(10);
				nPosOffsetPct_c1 = AxTndNTagReadPrm_c1.GetShortValue(11);
				lnSafetyConfigPrm_c1 = AxTndNTagReadPrm_c1.GetUIntValue(12);
				lblReadErrorPrm_c1.Visible = false;
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c1");
				lblReadErrorPrm_c1.Visible = true;
				chkEnabledPrm_c1.Checked = false;
			}

			udNumBinsPrm_c1.Value = lnNumBinsPrm_c1;
			udRatioPrm_c1.Value = lnRatioPrm_c1;
			udBinTolPctPrm_c1.Value = lnBinTolPctPrm_c1 / 10;
			udControlTypePrm_c1.Value = lnControlTypePrm_c1;
			udMMMDelayPrm_c1.Value = lnMMMDelayPrm_c1;
			udStepsPerRevPrm_c1.Value = lnStepsPerRevPrm_c1;
			udnPosOffsetPct_c1.Value = nPosOffsetPct_c1;
			udSlowPreset1Prm_c1.Value = lnSlowPreset1Prm_c1 / 1000;
			udSlowPreset2Prm_c1.Value = lnSlowPreset2Prm_c1 / 1000;
			udSlowPreset3Prm_c1.Value = lnSlowPreset3Prm_c1 / 1000;
			udStopPresetPrm_c1.Value = lnStopPresetPrm_c1 / 1000;

			// Breakout SafetyConfig
			chkES1_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 0) == 0;
			chkES2_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 1) == 0;
			chkES3_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 2) == 0;
			chkES4_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 3) == 0;
			chkES5_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 4) == 0;
			chkES6_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 5) == 0;
			chkES7_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 6) == 0;
			chkES8_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 7) == 0;
			//
			chkPE1_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 8) == 0;
			chkPE2_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 9) == 0;
			chkPE3_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 10) == 0;
			chkPE4_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 11) == 0;
			chkPE5_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 12) == 0;
			chkPE6_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 13) == 0;
			chkPE7_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 14) == 0;
			chkPE8_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 15) == 0;
			//
			chkLG1_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 16) == 0;
			chkLG2_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 17) == 0;
			chkLG3_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 18) == 0;
			chkLG4_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 19) == 0;
			chkLG5_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 20) == 0;
			chkLG6_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 21) == 0;
			chkLG7_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 22) == 0;
			chkLG8_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 23) == 0;
			//
			chkMT1_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 24) == 0;
			chkMT2_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 25) == 0;
			chkMT3_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 26) == 0;
			chkMT4_c1.Checked = (lnSafetyConfigPrm_c1 & 2 ^ 27) == 0;
			lblPW_c1.Visible = false;
			lblPW_c1.Refresh();

			ButtonsEnabledPrm_c1();
		}
		private void SafetyConfigCalc_c1()
		{
			lnSafetyConfigPrm_c1 = 0;
			if (chkES1_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 0;
			if (chkES2_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 1;
			if (chkES3_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 2;
			if (chkES4_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 3;
			if (chkES5_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 4;
			if (chkES6_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 5;
			if (chkES7_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 6;
			if (chkES8_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 7;
			if (chkPE1_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 8;
			if (chkPE2_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 9;
			if (chkPE3_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 10;
			if (chkPE4_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 11;
			if (chkPE5_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 12;
			if (chkPE6_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 13;
			if (chkPE7_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 14;
			if (chkPE8_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 15;
			if (chkLG1_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 16;
			if (chkLG2_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 17;
			if (chkLG3_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 18;
			if (chkLG4_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 19;
			if (chkLG5_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 20;
			if (chkLG6_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 21;
			if (chkLG7_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 22;
			if (chkLG8_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 23;
			if (chkMT1_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 24;
			if (chkMT2_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 25;
			if (chkMT3_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 26;
			if (chkMT4_c1.Checked) lnSafetyConfigPrm_c1 += 2 ^ 27;
		}
		private void WriteTagsPrm_c1()
		{
			lblPW_c1.Visible = true;
			lblPW_c1.Refresh();

			ButtonsDisabledPrm_c1();

			// Write tags
			AxTndNTagWrite1Prm_c1.UpdateIntValue(0, (int)udNumBinsPrm_c1.Value);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(1, (int)udRatioPrm_c1.Value);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(2, (int)udBinTolPctPrm_c1.Value * 10);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(3, (int)udControlTypePrm_c1.Value);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(4, (int)udMMMDelayPrm_c1.Value);
			AxTndNTagWrite1Prm_c1.UpdateBoolValue(5, chkEnabledPrm_c1.Checked);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(6, (int)udStepsPerRevPrm_c1.Value);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(7, (int)udSlowPreset1Prm_c1.Value * 1000);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(8, (int)udSlowPreset2Prm_c1.Value * 1000);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(9, (int)udSlowPreset3Prm_c1.Value * 1000);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(10, (int)udStopPresetPrm_c1.Value * 1000);
			AxTndNTagWrite1Prm_c1.UpdateIntValue(11, (int)udnPosOffsetPct_c1.Value);
			SafetyConfigCalc_c1();
			AxTndNTagWrite1Prm_c1.UpdateUIntValue(12, lnSafetyConfigPrm_c1);


			lnTndNTagWrite1StatPrm_c1 = AxTndNTagWrite1Prm_c1.Write();

			if (lnTndNTagWrite1StatPrm_c1)
			{
				// Success
				lblWriteErrorPrm_c1.Visible = false;
				AxTndNTagWrite2Prm_c1.UpdateLongValue(0, 1); // WriteRetentiveData
				AxTndNTagWrite2Prm_c1.Write();
				tmrPrm_c1.Enabled = true;
			}
			else
			{
				// Failure
				lblWriteErrorPrm_c1.Visible = true;
				ButtonsEnabledPrm_c1();
			}
		}
		private void tmrPrm_c1_Tick(object sender, EventArgs e)
		{
			tmrPrm_c1.Enabled = false;
			AxTndNTagWrite2Prm_c1.UpdateLongValue(0, 0);    // WriteRetentiveData
			AxTndNTagWrite2Prm_c1.Write();
			ReadTagsPrm_c1();
			ButtonsEnabledPrm_c1();
		}
		private void ButtonsDisabledPrm_c1()
		{
			btnReadPrm_c1.Enabled = false;
			btnWritePrm_c1.Enabled = false;
		}
		private void ButtonsEnabledPrm_c1()
		{
			btnReadPrm_c1.Enabled = true;
			btnWritePrm_c1.Enabled = true;
		}
		private void btnEncoderStart_c1_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c1 && !lbSR1_EncoderSetup_c1)
				lbEncoderStart_c1 = true;
			SetFocusReqBin_c1();
		}
		private void btnEncoderStop_c1_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c1)
				lbEncoderStop_c1 = true;
			SetFocusReqBin_c1();
		}
		private void tmrEncoderStart_c1_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c1 = false;
			tmrEncoderStart_c1.Enabled = false;
		}
		private void tmrEncoderStop_c1_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c1 = false;
			tmrEncoderStop_c1.Enabled = false;
		}
		private void EncoderSetupColors_c1()
		{
			if (lbSR1_EncoderSetup_c1)
				btnEncoderStart_c1.BackColor = Color.Lime;
			else
				btnEncoderStart_c1.UseVisualStyleBackColor = true;
		}
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
		private bool lbHomingStartLatch_c1;

		// Flags
		// From controller  controller;
		private bool lbMoveFWD_c1;
		private bool lbMoveREV_c1;
		private bool lbMoveSPD0_c1;
		private bool lbMoveSPD1_c1;

		private bool lbTndNTagReadMM1Stat_c1;
		private bool lbTndNTagWriteMM1Stat_c1;
		private bool lbTndNTagWriteMM2Stat_c1;
		private bool lbTndNTagWriteMM3Stat_c1;
		private bool lbTndNTagWriteMM4Stat_c1;

		private bool lbFWD_c1;
		private bool lbREV_c1;
		private bool lbSTOP_c1;
		private bool lbJogF_c1;
		private bool lbJogR_c1;
		// Carousel 1
		private bool lbReadErrorPrm_c1;
		private bool lbWriteErrorPrm_c1;
		private bool lnTndNTagRead1StatPrm_c1;
		private bool lnTndNTagWrite1StatPrm_c1;

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


		private void Homingcheck_c2()
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
		private void EncoderCheck_c2()
		{
			// 'Encoder setup check
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
		private void FlagsBreakout_c2()
		{
			lblMoveFWD_c2.BackColor  = lbMoveFWD_c2  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c2.BackColor  = lbMoveREV_c2	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c2.BackColor = lbMoveSPD0_c2 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c2.BackColor = lbMoveSPD1_c2 ? Color.Goldenrod : Color.Transparent;
		}
		private void ManModeButtonColors_c2()
		{
			if (lbFWD_c2)  btnFWD_c2.BackColor  = Color.Lime; else btnFWD_c2.UseVisualStyleBackColor = true;
			if (lbREV_c2)  btnREV_c2.BackColor  = Color.Lime; else btnREV_c2.UseVisualStyleBackColor = true;
			if (lbSTOP_c2) btnSTOP_c2.BackColor = Color.Red;  else btnSTOP_c2.UseVisualStyleBackColor = true;
			if (lbSR1_Homing_c2 && lbHomingStartLatch_c2)
				btnHomingStart_c2.BackColor = Color.Lime;
			else
				btnHomingStart_c2.UseVisualStyleBackColor = true;
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
		private void SetFocusReqBin_c2()
		{
			txtReqBin_c2.Focus();
			txtReqBin_c2.SelectAll();
		}
		private void tmrReqBin_c2_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c2.Enabled = False
			lnRequestedBin_c2 = 0;
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
		private void ManualModeStartup_c2()
		{
			lbFWD_c2 = false;
			lbREV_c2 = false;
			lbSTOP_c2 = true;
			lbJogF_c2 = false;
			lbJogR_c2 = false;
		}
		private void ReadTagsMM_c2()
		{
			// Read tags

			lbTndNTagReadMM1Stat_c2 = AxTndNTagReadMM1_c2.Read();
			if (lbTndNTagReadMM1Stat_c2)
			{
				lbFWD_c2 = AxTndNTagReadMM1_c2.GetBoolValue(0);
				lbREV_c2 = AxTndNTagReadMM1_c2.GetBoolValue(1);
				lbSTOP_c2 = AxTndNTagReadMM1_c2.GetBoolValue(2);
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c2");
			}
		}
		private void WriteTagsMM_c2()
		{
			// Write tags
			AxTndNTagWriteMM4_c2.UpdateLongValue(0, lbJogF_c2 ? 1 : 0);
			AxTndNTagWriteMM4_c2.UpdateLongValue(1, lbJogR_c2 ? 1 : 0);
			lbTndNTagWriteMM4Stat_c2 = AxTndNTagWriteMM4_c2.Write();
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
				AxTndNTagWriteMM1_c2.UpdateLongValue(0, 1);
				lbTndNTagWriteMM1Stat_c2 = AxTndNTagWriteMM1_c2.Write();
			}
		}
		private void ReverseMM_c2()
		{
			if (!lbFWD_c2)
			{
				// Write tags
				AxTndNTagWriteMM2_c2.UpdateLongValue(0, 1);
				lbTndNTagWriteMM2Stat_c2 = AxTndNTagWriteMM2_c2.Write();
			}
		}
		private void StopMM_c2()
		{
			// Write tags
			AxTndNTagWriteMM3_c2.UpdateLongValue(0, 1);
			lbTndNTagWriteMM3Stat_c2 = AxTndNTagWriteMM3_c2.Write();
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
		private void TabPageSetup_c2_Enter(object sender, EventArgs e)
		{
			PrmLoad_c2();
		}
		private void PrmLoad_c2()
		{
			if (lbPrmLoad_c2)
			{
				if (!lbReadErrorPrm_c2 && lbWriteErrorPrm_c2)
					ReadTagsPrm_c2();
			}
			else
			{
				lblReadErrorPrm_c2.Visible = false;
				lblWriteErrorPrm_c2.Visible = false;

				if (AxTndNTagReadPrm_c2.IsValid())
				{
					// Register tags
					AxTndNTagReadPrm_c2.AddItem("NumOfBins_c2");        // NumBins
					AxTndNTagReadPrm_c2.AddItem("nRatio_c2");           // Ratio
					AxTndNTagReadPrm_c2.AddItem("nBinTolPct_c2");       // BinTolPct
					AxTndNTagReadPrm_c2.AddItem("ControlType_c2");      // ControlType
					AxTndNTagReadPrm_c2.AddItem("MMMDelayPreset_c2");   // ManModeMotor
					AxTndNTagReadPrm_c2.AddItem("CarouselEnabled_c2");  // CarouselEnab
					AxTndNTagReadPrm_c2.AddItem("StepsPerRev_c2");      // StepsPerRev
					AxTndNTagReadPrm_c2.AddItem("nBin_SlowPreset1_c2"); // SlowPreset1
					AxTndNTagReadPrm_c2.AddItem("nBin_SlowPreset2_c2"); // SlowPreset2
					AxTndNTagReadPrm_c2.AddItem("nBin_SlowPreset3_c2"); // SlowPreset3
					AxTndNTagReadPrm_c2.AddItem("nBin_StopPreset_c2");  // StopPreset
					AxTndNTagReadPrm_c2.AddItem("nPosOffsetPct_c2");    // Offset
					AxTndNTagReadPrm_c2.AddItem("SafetyConfig_c2");     // SafetyConfig
					if (AxTndNTagWrite1Prm_c2.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c2.AddItem("NumOfBins_c2");          // NumBins
						AxTndNTagWrite1Prm_c2.AddItem("nRatio_c2");             // Ratio
						AxTndNTagWrite1Prm_c2.AddItem("nBinTolPct_c2");         // BinTolPct
						AxTndNTagWrite1Prm_c2.AddItem("ControlType_c2");        // ControlType
						AxTndNTagWrite1Prm_c2.AddItem("MMMDelayPreset_c2");     // ManModeMotorDelay
						AxTndNTagWrite1Prm_c2.AddItem("CarouselEnabled_c2");    // CarouselEnabled
						AxTndNTagWrite1Prm_c2.AddItem("StepsPerRev_c2");        // StepsPerRev
						AxTndNTagWrite1Prm_c2.AddItem("nBin_SlowPreset1_c2");   // SlowPreset1
						AxTndNTagWrite1Prm_c2.AddItem("nBin_SlowPreset2_c2");   // SlowPreset2
						AxTndNTagWrite1Prm_c2.AddItem("nBin_SlowPreset3_c2");   // SlowPreset3
						AxTndNTagWrite1Prm_c2.AddItem("nBin_StopPreset_c2");    // StopPreset
						AxTndNTagWrite1Prm_c2.AddItem("nPosOffsetPct_c2");      // Offset
						AxTndNTagWrite1Prm_c2.AddItem("SafetyConfig_c2");       // SafetyConfig

						ReadTagsPrm_c2();
					}
					else
					{
						MessageBox.Show("Cannot connect Write1Prm_c2 to controller.");
						lblWriteErrorPrm_c2.Visible = true;
					}

					if (AxTndNTagWrite2Prm_c2.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c2.AddItem("WriteRetentiveData");
						WriteTagsPrm_c2();
						ReadTagsPrm_c2();
					}
					else
					{
						MessageBox.Show("Cannot connect Write2Prm_c2 to controller.");
						lblWriteErrorPrm_c2.Visible = true;
						lbWriteErrorPrm_c2 = true;
					}
				}
				else
				{
					MessageBox.Show("Cannot connect Read1Prm_c2 to controller.");
					lblReadErrorPrm_c2.Visible = true;
					lbReadErrorPrm_c2 = true;
				}

				lbPrmLoad_c2 = true;
			}
		}
		private void btnReadPrm_c2_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c2 && !lbWriteErrorPrm_c2)
				ReadTagsPrm_c2();
		}
		private void btnWritePrm_c2_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c2 && !lbWriteErrorPrm_c2)
				WriteTagsPrm_c2();
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
			lbTndNTagRead1StatPrm_c2 = AxTndNTagReadPrm_c2.Read();
			if (lbTndNTagRead1StatPrm_c2)
			{
				lnNumBinsPrm_c2 = AxTndNTagReadPrm_c2.GetShortValue(0);
				lnRatioPrm_c2 = AxTndNTagReadPrm_c2.GetShortValue(1);
				lnBinTolPctPrm_c2 = AxTndNTagReadPrm_c2.GetShortValue(2);
				lnControlTypePrm_c2 = AxTndNTagReadPrm_c2.GetShortValue(3);
				lnMMMDelayPrm_c2 = AxTndNTagReadPrm_c2.GetShortValue(4);
				chkEnabledPrm_c2.Checked = AxTndNTagReadPrm_c2.GetBoolValue(5);
				lnStepsPerRevPrm_c2 = AxTndNTagReadPrm_c2.GetShortValue(6);
				lnSlowPreset1Prm_c2 = AxTndNTagReadPrm_c2.GetShortValue(7);
				lnSlowPreset2Prm_c2 = AxTndNTagReadPrm_c2.GetShortValue(8);
				lnSlowPreset3Prm_c2 = AxTndNTagReadPrm_c2.GetShortValue(9);
				lnStopPresetPrm_c2 = AxTndNTagReadPrm_c2.GetShortValue(10);
				nPosOffsetPct_c2 = AxTndNTagReadPrm_c2.GetShortValue(11);
				lnSafetyConfigPrm_c2 = AxTndNTagReadPrm_c2.GetUIntValue(12);
				lblReadErrorPrm_c2.Visible = false;
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c2");
				lblReadErrorPrm_c2.Visible = true;
				chkEnabledPrm_c2.Checked = false;
			}

			udNumBinsPrm_c2.Value = lnNumBinsPrm_c2;
			udRatioPrm_c2.Value = lnRatioPrm_c2;
			udBinTolPctPrm_c2.Value = lnBinTolPctPrm_c2 / 10;
			udControlTypePrm_c2.Value = lnControlTypePrm_c2;
			udMMMDelayPrm_c2.Value = lnMMMDelayPrm_c2;
			udStepsPerRevPrm_c2.Value = lnStepsPerRevPrm_c2;
			udnPosOffsetPct_c2.Value = nPosOffsetPct_c2;
			udSlowPreset1Prm_c2.Value = lnSlowPreset1Prm_c2 / 1000;
			udSlowPreset2Prm_c2.Value = lnSlowPreset2Prm_c2 / 1000;
			udSlowPreset3Prm_c2.Value = lnSlowPreset3Prm_c2 / 1000;
			udStopPresetPrm_c2.Value = lnStopPresetPrm_c2 / 1000;

			// Breakout SafetyConfig
			chkES1_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 0) == 0;
			chkES2_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 1) == 0;
			chkES3_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 2) == 0;
			chkES4_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 3) == 0;
			chkES5_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 4) == 0;
			chkES6_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 5) == 0;
			chkES7_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 6) == 0;
			chkES8_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 7) == 0;
			//
			chkPE1_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 8) == 0;
			chkPE2_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 9) == 0;
			chkPE3_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 10) == 0;
			chkPE4_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 11) == 0;
			chkPE5_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 12) == 0;
			chkPE6_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 13) == 0;
			chkPE7_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 14) == 0;
			chkPE8_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 15) == 0;
			//
			chkLG1_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 16) == 0;
			chkLG2_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 17) == 0;
			chkLG3_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 18) == 0;
			chkLG4_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 19) == 0;
			chkLG5_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 20) == 0;
			chkLG6_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 21) == 0;
			chkLG7_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 22) == 0;
			chkLG8_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 23) == 0;
			//
			chkMT1_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 24) == 0;
			chkMT2_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 25) == 0;
			chkMT3_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 26) == 0;
			chkMT4_c2.Checked = (lnSafetyConfigPrm_c2 & 2 ^ 27) == 0;
			lblPW_c2.Visible = false;
			lblPW_c2.Refresh();

			ButtonsEnabledPrm_c2();
		}
		private void SafetyConfigCalc_c2()
		{
			lnSafetyConfigPrm_c2 = 0;
			if (chkES1_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 0;
			if (chkES2_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 1;
			if (chkES3_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 2;
			if (chkES4_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 3;
			if (chkES5_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 4;
			if (chkES6_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 5;
			if (chkES7_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 6;
			if (chkES8_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 7;
			if (chkPE1_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 8;
			if (chkPE2_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 9;
			if (chkPE3_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 10;
			if (chkPE4_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 11;
			if (chkPE5_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 12;
			if (chkPE6_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 13;
			if (chkPE7_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 14;
			if (chkPE8_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 15;
			if (chkLG1_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 16;
			if (chkLG2_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 17;
			if (chkLG3_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 18;
			if (chkLG4_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 19;
			if (chkLG5_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 20;
			if (chkLG6_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 21;
			if (chkLG7_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 22;
			if (chkLG8_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 23;
			if (chkMT1_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 24;
			if (chkMT2_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 25;
			if (chkMT3_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 26;
			if (chkMT4_c2.Checked) lnSafetyConfigPrm_c2 += 2 ^ 27;
		}
		private void WriteTagsPrm_c2()
		{
			lblPW_c2.Visible = true;
			lblPW_c2.Refresh();

			ButtonsDisabledPrm_c2();

			// Write tags
			AxTndNTagWrite1Prm_c2.UpdateIntValue(0, (int)udNumBinsPrm_c2.Value);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(1, (int)udRatioPrm_c2.Value);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(2, (int)udBinTolPctPrm_c2.Value * 10);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(3, (int)udControlTypePrm_c2.Value);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(4, (int)udMMMDelayPrm_c2.Value);
			AxTndNTagWrite1Prm_c2.UpdateBoolValue(5, chkEnabledPrm_c2.Checked);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(6, (int)udStepsPerRevPrm_c2.Value);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(7, (int)udSlowPreset1Prm_c2.Value * 1000);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(8, (int)udSlowPreset2Prm_c2.Value * 1000);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(9, (int)udSlowPreset3Prm_c2.Value * 1000);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(10, (int)udStopPresetPrm_c2.Value * 1000);
			AxTndNTagWrite1Prm_c2.UpdateIntValue(11, (int)udnPosOffsetPct_c2.Value);
			SafetyConfigCalc_c2();
			AxTndNTagWrite1Prm_c2.UpdateUIntValue(12, lnSafetyConfigPrm_c2);


			lbTndNTagWrite1StatPrm_c2 = AxTndNTagWrite1Prm_c2.Write();

			if (lbTndNTagWrite1StatPrm_c2)
			{
				// Success
				lblWriteErrorPrm_c2.Visible = false;
				AxTndNTagWrite2Prm_c2.UpdateLongValue(0, 1); // WriteRetentiveData
				AxTndNTagWrite2Prm_c2.Write();
				tmrPrm_c2.Enabled = true;
			}
			else
			{
				// Failure
				lblWriteErrorPrm_c2.Visible = true;
				ButtonsEnabledPrm_c2();
			}
		}
		private void tmrPrm_c2_Tick(object sender, EventArgs e)
		{
			tmrPrm_c2.Enabled = false;
			AxTndNTagWrite2Prm_c2.UpdateLongValue(0, 0);    // WriteRetentiveData
			AxTndNTagWrite2Prm_c2.Write();
			ReadTagsPrm_c2();
			ButtonsEnabledPrm_c2();
		}
		private void ButtonsDisabledPrm_c2()
		{
			btnReadPrm_c2.Enabled = false;
			btnWritePrm_c2.Enabled = false;
		}
		private void ButtonsEnabledPrm_c2()
		{
			btnReadPrm_c2.Enabled = true;
			btnWritePrm_c2.Enabled = true;
		}
		private void btnEncoderStart_c2_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c2 && !lbSR1_EncoderSetup_c2)
				lbEncoderStart_c2 = true;
			SetFocusReqBin_c2();
		}
		private void btnEncoderStop_c2_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c2)
				lbEncoderStop_c2 = true;
			SetFocusReqBin_c2();
		}
		private void tmrEncoderStart_c2_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c2 = false;
			tmrEncoderStart_c2.Enabled = false;
		}
		private void tmrEncoderStop_c2_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c2 = false;
			tmrEncoderStop_c2.Enabled = false;
		}
		private void EncoderSetupColors_c2()
		{
			if (lbSR1_EncoderSetup_c2)
				btnEncoderStart_c2.BackColor = Color.Lime;
			else
				btnEncoderStart_c2.UseVisualStyleBackColor = true;
		}
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
		private bool lbHomingStartLatch_c2;

		// Flags
		// Read from controller
		private bool lbMoveFWD_c2;
		private bool lbMoveREV_c2;
		private bool lbMoveSPD0_c2;
		private bool lbMoveSPD1_c2;

		private bool lbTndNTagReadMM1Stat_c2;
		private bool lbTndNTagWriteMM1Stat_c2;
		private bool lbTndNTagWriteMM2Stat_c2;
		private bool lbTndNTagWriteMM3Stat_c2;
		private bool lbTndNTagWriteMM4Stat_c2;

		private bool lbFWD_c2;
		private bool lbREV_c2;
		private bool lbSTOP_c2;
		private bool lbJogF_c2;
		private bool lbJogR_c2;
		// Carousel 2
		private bool lbReadErrorPrm_c2;
		private bool lbWriteErrorPrm_c2;
		private bool lbTndNTagRead1StatPrm_c2;
		private bool lbTndNTagWrite1StatPrm_c2;

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


		private void Homingcheck_c3()
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
		private void EncoderCheck_c3()
		{
			// 'Encoder setup check
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
		private void FlagsBreakout_c3()
		{
			lblMoveFWD_c3.BackColor  = lbMoveFWD_c3  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c3.BackColor  = lbMoveREV_c3	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c3.BackColor = lbMoveSPD0_c3 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c3.BackColor = lbMoveSPD1_c3 ? Color.Goldenrod : Color.Transparent;
		}
		private void ManModeButtonColors_c3()
		{
			if (lbFWD_c3)  btnFWD_c3.BackColor  = Color.Lime; else btnFWD_c3.UseVisualStyleBackColor = true;
			if (lbREV_c3)  btnREV_c3.BackColor  = Color.Lime; else btnREV_c3.UseVisualStyleBackColor = true;
			if (lbSTOP_c3) btnSTOP_c3.BackColor = Color.Red;  else btnSTOP_c3.UseVisualStyleBackColor = true;
			if (lbSR1_Homing_c3 && lbHomingStartLatch_c3)
				btnHomingStart_c3.BackColor = Color.Lime;
			else
				btnHomingStart_c3.UseVisualStyleBackColor = true;
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
		private void SetFocusReqBin_c3()
		{
			txtReqBin_c3.Focus();
			txtReqBin_c3.SelectAll();
		}
		private void tmrReqBin_c3_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c3.Enabled = False
			lnRequestedBin_c3 = 0;
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
		private void ManualModeStartup_c3()
		{
			lbFWD_c3 = false;
			lbREV_c3 = false;
			lbSTOP_c3 = true;
			lbJogF_c3 = false;
			lbJogR_c3 = false;
		}
		private void ReadTagsMM_c3()
		{
			// Read tags
			lbTndNTagReadMM1Stat_c3 = AxTndNTagReadMM1_c3.Read();
			if (lbTndNTagReadMM1Stat_c3)
			{
				lbFWD_c3 = AxTndNTagReadMM1_c3.GetBoolValue(0);
				lbREV_c3 = AxTndNTagReadMM1_c3.GetBoolValue(1);
				lbSTOP_c3 = AxTndNTagReadMM1_c3.GetBoolValue(2);
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c3");
			}
		}
		private void WriteTagsMM_c3()
		{
			// Write tags
			AxTndNTagWriteMM4_c3.UpdateLongValue(0, lbJogF_c3 ? 1 : 0);
			AxTndNTagWriteMM4_c3.UpdateLongValue(1, lbJogR_c3 ? 1 : 0);
			lbTndNTagWriteMM4Stat_c3 = AxTndNTagWriteMM4_c3.Write();
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
				AxTndNTagWriteMM1_c3.UpdateLongValue(0, 1);
				lbTndNTagWriteMM1Stat_c3 = AxTndNTagWriteMM1_c3.Write();
			}
		}
		private void ReverseMM_c3()
		{
			if (!lbFWD_c3)
			{
				// Write tags
				AxTndNTagWriteMM2_c3.UpdateLongValue(0, 1);
				lbTndNTagWriteMM2Stat_c3 = AxTndNTagWriteMM2_c3.Write();
			}
		}
		private void StopMM_c3()
		{
			// Write tags
			AxTndNTagWriteMM3_c3.UpdateLongValue(0, 1);
			lbTndNTagWriteMM3Stat_c3 = AxTndNTagWriteMM3_c3.Write();
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
		private void TabPageSetup_c3_Enter(object sender, EventArgs e)
		{
			PrmLoad_c3();
		}
		private void PrmLoad_c3()
		{
			if (lbPrmLoad_c3)
			{
				if (!lbReadErrorPrm_c3 && lbWriteErrorPrm_c3)
					ReadTagsPrm_c3();
			}
			else
			{
				lblReadErrorPrm_c3.Visible = false;
				lblWriteErrorPrm_c3.Visible = false;

				if (AxTndNTagReadPrm_c3.IsValid())
				{
					// Register tags
					AxTndNTagReadPrm_c3.AddItem("NumOfBins_c3");        // NumBins
					AxTndNTagReadPrm_c3.AddItem("nRatio_c3");           // Ratio
					AxTndNTagReadPrm_c3.AddItem("nBinTolPct_c3");       // BinTolPct
					AxTndNTagReadPrm_c3.AddItem("ControlType_c3");      // ControlType
					AxTndNTagReadPrm_c3.AddItem("MMMDelayPreset_c3");   // ManModeMotor
					AxTndNTagReadPrm_c3.AddItem("CarouselEnabled_c3");  // CarouselEnab
					AxTndNTagReadPrm_c3.AddItem("StepsPerRev_c3");      // StepsPerRev
					AxTndNTagReadPrm_c3.AddItem("nBin_SlowPreset1_c3"); // SlowPreset1
					AxTndNTagReadPrm_c3.AddItem("nBin_SlowPreset2_c3"); // SlowPreset2
					AxTndNTagReadPrm_c3.AddItem("nBin_SlowPreset3_c3"); // SlowPreset3
					AxTndNTagReadPrm_c3.AddItem("nBin_StopPreset_c3");  // StopPreset
					AxTndNTagReadPrm_c3.AddItem("nPosOffsetPct_c3");    // Offset
					AxTndNTagReadPrm_c3.AddItem("SafetyConfig_c3");     // SafetyConfig
					if (AxTndNTagWrite1Prm_c3.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c3.AddItem("NumOfBins_c3");          // NumBins
						AxTndNTagWrite1Prm_c3.AddItem("nRatio_c3");             // Ratio
						AxTndNTagWrite1Prm_c3.AddItem("nBinTolPct_c3");         // BinTolPct
						AxTndNTagWrite1Prm_c3.AddItem("ControlType_c3");        // ControlType
						AxTndNTagWrite1Prm_c3.AddItem("MMMDelayPreset_c3");     // ManModeMotorDelay
						AxTndNTagWrite1Prm_c3.AddItem("CarouselEnabled_c3");    // CarouselEnabled
						AxTndNTagWrite1Prm_c3.AddItem("StepsPerRev_c3");        // StepsPerRev
						AxTndNTagWrite1Prm_c3.AddItem("nBin_SlowPreset1_c3");   // SlowPreset1
						AxTndNTagWrite1Prm_c3.AddItem("nBin_SlowPreset2_c3");   // SlowPreset2
						AxTndNTagWrite1Prm_c3.AddItem("nBin_SlowPreset3_c3");   // SlowPreset3
						AxTndNTagWrite1Prm_c3.AddItem("nBin_StopPreset_c3");    // StopPreset
						AxTndNTagWrite1Prm_c3.AddItem("nPosOffsetPct_c3");      // Offset
						AxTndNTagWrite1Prm_c3.AddItem("SafetyConfig_c3");       // SafetyConfig

						ReadTagsPrm_c3();
					}
					else
					{
						MessageBox.Show("Cannot connect Write1Prm_c3 to controller.");
						lblWriteErrorPrm_c3.Visible = true;
					}

					if (AxTndNTagWrite2Prm_c3.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c3.AddItem("WriteRetentiveData");
						WriteTagsPrm_c3();
						ReadTagsPrm_c3();
					}
					else
					{
						MessageBox.Show("Cannot connect Write2Prm_c3 to controller.");
						lblWriteErrorPrm_c3.Visible = true;
						lbWriteErrorPrm_c3 = true;
					}
				}
				else
				{
					MessageBox.Show("Cannot connect Read1Prm_c3 to controller.");
					lblReadErrorPrm_c3.Visible = true;
					lbReadErrorPrm_c3 = true;
				}

				lbPrmLoad_c3 = true;
			}
		}
		private void btnReadPrm_c3_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c3 && !lbWriteErrorPrm_c3)
				ReadTagsPrm_c3();
		}
		private void btnWritePrm_c3_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c3 && !lbWriteErrorPrm_c3)
				WriteTagsPrm_c3();
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
			lbTndNTagRead1StatPrm_c3 = AxTndNTagReadPrm_c3.Read();
			if (lbTndNTagRead1StatPrm_c3)
			{
				lnNumBinsPrm_c3 = AxTndNTagReadPrm_c3.GetShortValue(0);
				lnRatioPrm_c3 = AxTndNTagReadPrm_c3.GetShortValue(1);
				lnBinTolPctPrm_c3 = AxTndNTagReadPrm_c3.GetShortValue(2);
				lnControlTypePrm_c3 = AxTndNTagReadPrm_c3.GetShortValue(3);
				lnMMMDelayPrm_c3 = AxTndNTagReadPrm_c3.GetShortValue(4);
				chkEnabledPrm_c3.Checked = AxTndNTagReadPrm_c3.GetBoolValue(5);
				lnStepsPerRevPrm_c3 = AxTndNTagReadPrm_c3.GetShortValue(6);
				lnSlowPreset1Prm_c3 = AxTndNTagReadPrm_c3.GetShortValue(7);
				lnSlowPreset2Prm_c3 = AxTndNTagReadPrm_c3.GetShortValue(8);
				lnSlowPreset3Prm_c3 = AxTndNTagReadPrm_c3.GetShortValue(9);
				lnStopPresetPrm_c3 = AxTndNTagReadPrm_c3.GetShortValue(10);
				nPosOffsetPct_c3 = AxTndNTagReadPrm_c3.GetShortValue(11);
				lnSafetyConfigPrm_c3 = AxTndNTagReadPrm_c3.GetUIntValue(12);
				lblReadErrorPrm_c3.Visible = false;
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c3");
				lblReadErrorPrm_c3.Visible = true;
				chkEnabledPrm_c3.Checked = false;
			}

			udNumBinsPrm_c3.Value = lnNumBinsPrm_c3;
			udRatioPrm_c3.Value = lnRatioPrm_c3;
			udBinTolPctPrm_c3.Value = lnBinTolPctPrm_c3 / 10;
			udControlTypePrm_c3.Value = lnControlTypePrm_c3;
			udMMMDelayPrm_c3.Value = lnMMMDelayPrm_c3;
			udStepsPerRevPrm_c3.Value = lnStepsPerRevPrm_c3;
			udnPosOffsetPct_c3.Value = nPosOffsetPct_c3;
			udSlowPreset1Prm_c3.Value = lnSlowPreset1Prm_c3 / 1000;
			udSlowPreset2Prm_c3.Value = lnSlowPreset2Prm_c3 / 1000;
			udSlowPreset3Prm_c3.Value = lnSlowPreset3Prm_c3 / 1000;
			udStopPresetPrm_c3.Value = lnStopPresetPrm_c3 / 1000;

			// Breakout SafetyConfig
			chkES1_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 0) == 0;
			chkES2_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 1) == 0;
			chkES3_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 2) == 0;
			chkES4_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 3) == 0;
			chkES5_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 4) == 0;
			chkES6_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 5) == 0;
			chkES7_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 6) == 0;
			chkES8_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 7) == 0;
			//
			chkPE1_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 8) == 0;
			chkPE2_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 9) == 0;
			chkPE3_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 10) == 0;
			chkPE4_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 11) == 0;
			chkPE5_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 12) == 0;
			chkPE6_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 13) == 0;
			chkPE7_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 14) == 0;
			chkPE8_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 15) == 0;
			//
			chkLG1_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 16) == 0;
			chkLG2_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 17) == 0;
			chkLG3_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 18) == 0;
			chkLG4_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 19) == 0;
			chkLG5_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 20) == 0;
			chkLG6_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 21) == 0;
			chkLG7_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 22) == 0;
			chkLG8_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 23) == 0;
			//
			chkMT1_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 24) == 0;
			chkMT2_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 25) == 0;
			chkMT3_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 26) == 0;
			chkMT4_c3.Checked = (lnSafetyConfigPrm_c3 & 2 ^ 27) == 0;
			lblPW_c3.Visible = false;
			lblPW_c3.Refresh();

			ButtonsEnabledPrm_c3();
		}
		private void SafetyConfigCalc_c3()
		{
			lnSafetyConfigPrm_c3 = 0;
			if (chkES1_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 0;
			if (chkES2_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 1;
			if (chkES3_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 2;
			if (chkES4_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 3;
			if (chkES5_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 4;
			if (chkES6_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 5;
			if (chkES7_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 6;
			if (chkES8_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 7;
			if (chkPE1_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 8;
			if (chkPE2_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 9;
			if (chkPE3_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 10;
			if (chkPE4_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 11;
			if (chkPE5_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 12;
			if (chkPE6_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 13;
			if (chkPE7_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 14;
			if (chkPE8_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 15;
			if (chkLG1_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 16;
			if (chkLG2_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 17;
			if (chkLG3_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 18;
			if (chkLG4_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 19;
			if (chkLG5_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 20;
			if (chkLG6_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 21;
			if (chkLG7_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 22;
			if (chkLG8_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 23;
			if (chkMT1_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 24;
			if (chkMT2_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 25;
			if (chkMT3_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 26;
			if (chkMT4_c3.Checked) lnSafetyConfigPrm_c3 += 2 ^ 27;
		}
		private void WriteTagsPrm_c3()
		{
			lblPW_c3.Visible = true;
			lblPW_c3.Refresh();

			ButtonsDisabledPrm_c3();

			// Write tags
			AxTndNTagWrite1Prm_c3.UpdateIntValue(0, (int)udNumBinsPrm_c3.Value);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(1, (int)udRatioPrm_c3.Value);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(2, (int)udBinTolPctPrm_c3.Value * 10);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(3, (int)udControlTypePrm_c3.Value);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(4, (int)udMMMDelayPrm_c3.Value);
			AxTndNTagWrite1Prm_c3.UpdateBoolValue(5, chkEnabledPrm_c3.Checked);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(6, (int)udStepsPerRevPrm_c3.Value);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(7, (int)udSlowPreset1Prm_c3.Value * 1000);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(8, (int)udSlowPreset2Prm_c3.Value * 1000);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(9, (int)udSlowPreset3Prm_c3.Value * 1000);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(10, (int)udStopPresetPrm_c3.Value * 1000);
			AxTndNTagWrite1Prm_c3.UpdateIntValue(11, (int)udnPosOffsetPct_c3.Value);
			SafetyConfigCalc_c3();
			AxTndNTagWrite1Prm_c3.UpdateUIntValue(12, lnSafetyConfigPrm_c3);


			lbTndNTagWrite1StatPrm_c3 = AxTndNTagWrite1Prm_c3.Write();

			if (lbTndNTagWrite1StatPrm_c3)
			{
				// Success
				lblWriteErrorPrm_c3.Visible = false;
				AxTndNTagWrite2Prm_c3.UpdateLongValue(0, 1); // WriteRetentiveData
				AxTndNTagWrite2Prm_c3.Write();
				tmrPrm_c3.Enabled = true;
			}
			else
			{
				// Failure
				lblWriteErrorPrm_c3.Visible = true;
				ButtonsEnabledPrm_c3();
			}
		}
		private void tmrPrm_c3_Tick(object sender, EventArgs e)
		{
			tmrPrm_c3.Enabled = false;
			AxTndNTagWrite2Prm_c3.UpdateLongValue(0, 0);    // WriteRetentiveData
			AxTndNTagWrite2Prm_c3.Write();
			ReadTagsPrm_c3();
			ButtonsEnabledPrm_c3();
		}
		private void ButtonsDisabledPrm_c3()
		{
			btnReadPrm_c3.Enabled = false;
			btnWritePrm_c3.Enabled = false;
		}
		private void ButtonsEnabledPrm_c3()
		{
			btnReadPrm_c3.Enabled = true;
			btnWritePrm_c3.Enabled = true;
		}
		private void btnEncoderStart_c3_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c3 && !lbSR1_EncoderSetup_c3)
				lbEncoderStart_c3 = true;
			SetFocusReqBin_c3();
		}
		private void btnEncoderStop_c3_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c3)
				lbEncoderStop_c3 = true;
			SetFocusReqBin_c3();
		}
		private void tmrEncoderStart_c3_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c3 = false;
			tmrEncoderStart_c3.Enabled = false;
		}
		private void tmrEncoderStop_c3_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c3 = false;
			tmrEncoderStop_c3.Enabled = false;
		}
		private void EncoderSetupColors_c3()
		{
			if (lbSR1_EncoderSetup_c3)
				btnEncoderStart_c3.BackColor = Color.Lime;
			else
				btnEncoderStart_c3.UseVisualStyleBackColor = true;
		}
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
		private bool lbHomingStartLatch_c3;

		// Flags
		// From controller  controller;
		private bool lbMoveFWD_c3;
		private bool lbMoveREV_c3;
		private bool lbMoveSPD0_c3;
		private bool lbMoveSPD1_c3;

		private bool lbTndNTagReadMM1Stat_c3;
		private bool lbTndNTagWriteMM1Stat_c3;
		private bool lbTndNTagWriteMM2Stat_c3;
		private bool lbTndNTagWriteMM3Stat_c3;
		private bool lbTndNTagWriteMM4Stat_c3;

		private bool lbFWD_c3;
		private bool lbREV_c3;
		private bool lbSTOP_c3;
		private bool lbJogF_c3;
		private bool lbJogR_c3;
		// Carousel 3
		private bool lbReadErrorPrm_c3;
		private bool lbWriteErrorPrm_c3;
		private bool lbTndNTagRead1StatPrm_c3;
		private bool lbTndNTagWrite1StatPrm_c3;

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

		private void Homingcheck_c4()
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
		private void EncoderCheck_c4()
		{
			// 'Encoder setup check
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
		private void FlagsBreakout_c4()
		{
			lblMoveFWD_c4.BackColor  = lbMoveFWD_c4  ? Color.Goldenrod : Color.Transparent;
			lblMoveREV_c4.BackColor  = lbMoveREV_c4	 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD0_c4.BackColor = lbMoveSPD0_c4 ? Color.Goldenrod : Color.Transparent;
			lblMoveSPD1_c4.BackColor = lbMoveSPD1_c4 ? Color.Goldenrod : Color.Transparent;
		}
		private void ManModeButtonColors_c4()
		{
			if (lbFWD_c4)  btnFWD_c4.BackColor  = Color.Lime; else btnFWD_c4.UseVisualStyleBackColor = true;
			if (lbREV_c4)  btnREV_c4.BackColor  = Color.Lime; else btnREV_c4.UseVisualStyleBackColor = true;
			if (lbSTOP_c4) btnSTOP_c4.BackColor = Color.Red;  else btnSTOP_c4.UseVisualStyleBackColor = true;
			if (lbSR1_Homing_c4 && lbHomingStartLatch_c4)
				btnHomingStart_c4.BackColor = Color.Lime;
			else
				btnHomingStart_c4.UseVisualStyleBackColor = true;
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
		private void SetFocusReqBin_c4()
		{
			txtReqBin_c4.Focus();
			txtReqBin_c4.SelectAll();
		}
		private void tmrReqBin_c4_Tick(object sender, EventArgs e)
		{
			// The timer resets the requested bin.Me.tmrReqBin_c4.Enabled = False
			lnRequestedBin_c4 = 0;
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
		private void ManualModeStartup_c4()
		{
			lbFWD_c4 = false;
			lbREV_c4 = false;
			lbSTOP_c4 = true;
			lbJogF_c4 = false;
			lbJogR_c4 = false;
		}
		private void ReadTagsMM_c4()
		{
			// Read tags
			lbTndNTagReadMM1Stat_c4 = AxTndNTagReadMM1_c4.Read();
			if (lbTndNTagReadMM1Stat_c4)
			{
				lbFWD_c4 = AxTndNTagReadMM1_c4.GetBoolValue(0);
				lbREV_c4 = AxTndNTagReadMM1_c4.GetBoolValue(1);
				lbSTOP_c4 = AxTndNTagReadMM1_c4.GetBoolValue(2);
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsMM_c4");
			}
		}
		private void WriteTagsMM_c4()
		{
			// Write tags
			AxTndNTagWriteMM4_c4.UpdateLongValue(0, lbJogF_c4 ? 1 : 0);
			AxTndNTagWriteMM4_c4.UpdateLongValue(1, lbJogR_c4 ? 1 : 0);
			lbTndNTagWriteMM4Stat_c4 = AxTndNTagWriteMM4_c4.Write();
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
				AxTndNTagWriteMM1_c4.UpdateLongValue(0, 1);
				lbTndNTagWriteMM1Stat_c4 = AxTndNTagWriteMM1_c4.Write();
			}
		}
		private void ReverseMM_c4()
		{
			if (!lbFWD_c4)
			{
				// Write tags
				AxTndNTagWriteMM2_c4.UpdateLongValue(0, 1);
				lbTndNTagWriteMM2Stat_c4 = AxTndNTagWriteMM2_c4.Write();
			}
		}
		private void StopMM_c4()
		{
			// Write tags
			AxTndNTagWriteMM3_c4.UpdateLongValue(0, 1);
			lbTndNTagWriteMM3Stat_c4 = AxTndNTagWriteMM3_c4.Write();
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
		private void TabPageSetup_c4_Enter(object sender, EventArgs e)
		{
			PrmLoad_c4();
		}
		private void PrmLoad_c4()
		{
			if (lbPrmLoad_c4)
			{
				if (!lbReadErrorPrm_c4 && lbWriteErrorPrm_c4)
					ReadTagsPrm_c4();
			}
			else
			{
				lblReadErrorPrm_c4.Visible = false;
				lblWriteErrorPrm_c4.Visible = false;

				if (AxTndNTagReadPrm_c4.IsValid())
				{
					// Register tags
					AxTndNTagReadPrm_c4.AddItem("NumOfBins_c4");        // NumBins
					AxTndNTagReadPrm_c4.AddItem("nRatio_c4");           // Ratio
					AxTndNTagReadPrm_c4.AddItem("nBinTolPct_c4");       // BinTolPct
					AxTndNTagReadPrm_c4.AddItem("ControlType_c4");      // ControlType
					AxTndNTagReadPrm_c4.AddItem("MMMDelayPreset_c4");   // ManModeMotor
					AxTndNTagReadPrm_c4.AddItem("CarouselEnabled_c4");  // CarouselEnab
					AxTndNTagReadPrm_c4.AddItem("StepsPerRev_c4");      // StepsPerRev
					AxTndNTagReadPrm_c4.AddItem("nBin_SlowPreset1_c4"); // SlowPreset1
					AxTndNTagReadPrm_c4.AddItem("nBin_SlowPreset2_c4"); // SlowPreset2
					AxTndNTagReadPrm_c4.AddItem("nBin_SlowPreset3_c4"); // SlowPreset3
					AxTndNTagReadPrm_c4.AddItem("nBin_StopPreset_c4");  // StopPreset
					AxTndNTagReadPrm_c4.AddItem("nPosOffsetPct_c4");    // Offset
					AxTndNTagReadPrm_c4.AddItem("SafetyConfig_c4");     // SafetyConfig
					if (AxTndNTagWrite1Prm_c4.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c4.AddItem("NumOfBins_c4");          // NumBins
						AxTndNTagWrite1Prm_c4.AddItem("nRatio_c4");             // Ratio
						AxTndNTagWrite1Prm_c4.AddItem("nBinTolPct_c4");         // BinTolPct
						AxTndNTagWrite1Prm_c4.AddItem("ControlType_c4");        // ControlType
						AxTndNTagWrite1Prm_c4.AddItem("MMMDelayPreset_c4");     // ManModeMotorDelay
						AxTndNTagWrite1Prm_c4.AddItem("CarouselEnabled_c4");    // CarouselEnabled
						AxTndNTagWrite1Prm_c4.AddItem("StepsPerRev_c4");        // StepsPerRev
						AxTndNTagWrite1Prm_c4.AddItem("nBin_SlowPreset1_c4");   // SlowPreset1
						AxTndNTagWrite1Prm_c4.AddItem("nBin_SlowPreset2_c4");   // SlowPreset2
						AxTndNTagWrite1Prm_c4.AddItem("nBin_SlowPreset3_c4");   // SlowPreset3
						AxTndNTagWrite1Prm_c4.AddItem("nBin_StopPreset_c4");    // StopPreset
						AxTndNTagWrite1Prm_c4.AddItem("nPosOffsetPct_c4");      // Offset
						AxTndNTagWrite1Prm_c4.AddItem("SafetyConfig_c4");       // SafetyConfig

						ReadTagsPrm_c4();
					}
					else
					{
						MessageBox.Show("Cannot connect Write1Prm_c4 to controller.");
						lblWriteErrorPrm_c4.Visible = true;
					}

					if (AxTndNTagWrite2Prm_c4.IsValid())
					{
						// Register tags
						AxTndNTagWrite1Prm_c4.AddItem("WriteRetentiveData");
						WriteTagsPrm_c4();
						ReadTagsPrm_c4();
					}
					else
					{
						MessageBox.Show("Cannot connect Write2Prm_c4 to controller.");
						lblWriteErrorPrm_c4.Visible = true;
						lbWriteErrorPrm_c4 = true;
					}
				}
				else
				{
					MessageBox.Show("Cannot connect Read1Prm_c4 to controller.");
					lblReadErrorPrm_c4.Visible = true;
					lbReadErrorPrm_c4 = true;
				}

				lbPrmLoad_c4 = true;
			}
		}
		private void btnReadPrm_c4_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c4 && !lbWriteErrorPrm_c4)
				ReadTagsPrm_c4();
		}
		private void btnWritePrm_c4_Click(object sender, EventArgs e)
		{
			if (!lbReadErrorPrm_c4 && !lbWriteErrorPrm_c4)
				WriteTagsPrm_c4();
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
			lbTndNTagRead1StatPrm_c4 = AxTndNTagReadPrm_c4.Read();
			if (lbTndNTagRead1StatPrm_c4)
			{
				lnNumBinsPrm_c4 = AxTndNTagReadPrm_c4.GetShortValue(0);
				lnRatioPrm_c4 = AxTndNTagReadPrm_c4.GetShortValue(1);
				lnBinTolPctPrm_c4 = AxTndNTagReadPrm_c4.GetShortValue(2);
				lnControlTypePrm_c4 = AxTndNTagReadPrm_c4.GetShortValue(3);
				lnMMMDelayPrm_c4 = AxTndNTagReadPrm_c4.GetShortValue(4);
				chkEnabledPrm_c4.Checked = AxTndNTagReadPrm_c4.GetBoolValue(5);
				lnStepsPerRevPrm_c4 = AxTndNTagReadPrm_c4.GetShortValue(6);
				lnSlowPreset1Prm_c4 = AxTndNTagReadPrm_c4.GetShortValue(7);
				lnSlowPreset2Prm_c4 = AxTndNTagReadPrm_c4.GetShortValue(8);
				lnSlowPreset3Prm_c4 = AxTndNTagReadPrm_c4.GetShortValue(9);
				lnStopPresetPrm_c4 = AxTndNTagReadPrm_c4.GetShortValue(10);
				nPosOffsetPct_c4 = AxTndNTagReadPrm_c4.GetShortValue(11);
				lnSafetyConfigPrm_c4 = AxTndNTagReadPrm_c4.GetUIntValue(12);
				lblReadErrorPrm_c4.Visible = false;
			}
			else
			{
				MessageBox.Show("Cannot read tags from controller ReadTagsPrm_c4");
				lblReadErrorPrm_c4.Visible = true;
				chkEnabledPrm_c4.Checked = false;
			}

			udNumBinsPrm_c4.Value = lnNumBinsPrm_c4;
			udRatioPrm_c4.Value = lnRatioPrm_c4;
			udBinTolPctPrm_c4.Value = lnBinTolPctPrm_c4 / 10;
			udControlTypePrm_c4.Value = lnControlTypePrm_c4;
			udMMMDelayPrm_c4.Value = lnMMMDelayPrm_c4;
			udStepsPerRevPrm_c4.Value = lnStepsPerRevPrm_c4;
			udnPosOffsetPct_c4.Value = nPosOffsetPct_c4;
			udSlowPreset1Prm_c4.Value = lnSlowPreset1Prm_c4 / 1000;
			udSlowPreset2Prm_c4.Value = lnSlowPreset2Prm_c4 / 1000;
			udSlowPreset3Prm_c4.Value = lnSlowPreset3Prm_c4 / 1000;
			udStopPresetPrm_c4.Value = lnStopPresetPrm_c4 / 1000;

			// Breakout SafetyConfig
			chkES1_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 0) == 0;
			chkES2_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 1) == 0;
			chkES3_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 2) == 0;
			chkES4_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 3) == 0;
			chkES5_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 4) == 0;
			chkES6_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 5) == 0;
			chkES7_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 6) == 0;
			chkES8_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 7) == 0;
			//
			chkPE1_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 8) == 0;
			chkPE2_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 9) == 0;
			chkPE3_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 10) == 0;
			chkPE4_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 11) == 0;
			chkPE5_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 12) == 0;
			chkPE6_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 13) == 0;
			chkPE7_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 14) == 0;
			chkPE8_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 15) == 0;
			//
			chkLG1_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 16) == 0;
			chkLG2_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 17) == 0;
			chkLG3_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 18) == 0;
			chkLG4_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 19) == 0;
			chkLG5_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 20) == 0;
			chkLG6_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 21) == 0;
			chkLG7_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 22) == 0;
			chkLG8_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 23) == 0;
			//
			chkMT1_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 24) == 0;
			chkMT2_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 25) == 0;
			chkMT3_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 26) == 0;
			chkMT4_c4.Checked = (lnSafetyConfigPrm_c4 & 2 ^ 27) == 0;
			lblPW_c4.Visible = false;
			lblPW_c4.Refresh();

			ButtonsEnabledPrm_c4();
		}
		private void SafetyConfigCalc_c4()
		{
			lnSafetyConfigPrm_c4 = 0;
			if (chkES1_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 0;
			if (chkES2_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 1;
			if (chkES3_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 2;
			if (chkES4_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 3;
			if (chkES5_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 4;
			if (chkES6_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 5;
			if (chkES7_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 6;
			if (chkES8_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 7;
			if (chkPE1_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 8;
			if (chkPE2_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 9;
			if (chkPE3_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 10;
			if (chkPE4_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 11;
			if (chkPE5_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 12;
			if (chkPE6_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 13;
			if (chkPE7_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 14;
			if (chkPE8_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 15;
			if (chkLG1_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 16;
			if (chkLG2_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 17;
			if (chkLG3_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 18;
			if (chkLG4_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 19;
			if (chkLG5_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 20;
			if (chkLG6_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 21;
			if (chkLG7_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 22;
			if (chkLG8_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 23;
			if (chkMT1_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 24;
			if (chkMT2_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 25;
			if (chkMT3_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 26;
			if (chkMT4_c4.Checked) lnSafetyConfigPrm_c4 += 2 ^ 27;
		}
		private void WriteTagsPrm_c4()
		{
			lblPW_c4.Visible = true;
			lblPW_c4.Refresh();

			ButtonsDisabledPrm_c4();

			// Write tags
			AxTndNTagWrite1Prm_c4.UpdateIntValue(0, (int)udNumBinsPrm_c4.Value);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(1, (int)udRatioPrm_c4.Value);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(2, (int)udBinTolPctPrm_c4.Value * 10);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(3, (int)udControlTypePrm_c4.Value);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(4, (int)udMMMDelayPrm_c4.Value);
			AxTndNTagWrite1Prm_c4.UpdateBoolValue(5, chkEnabledPrm_c4.Checked);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(6, (int)udStepsPerRevPrm_c4.Value);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(7, (int)udSlowPreset1Prm_c4.Value * 1000);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(8, (int)udSlowPreset2Prm_c4.Value * 1000);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(9, (int)udSlowPreset3Prm_c4.Value * 1000);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(10, (int)udStopPresetPrm_c4.Value * 1000);
			AxTndNTagWrite1Prm_c4.UpdateIntValue(11, (int)udnPosOffsetPct_c4.Value);
			SafetyConfigCalc_c4();
			AxTndNTagWrite1Prm_c4.UpdateUIntValue(12, lnSafetyConfigPrm_c4);


			lbTndNTagWrite1StatPrm_c4 = AxTndNTagWrite1Prm_c4.Write();

			if (lbTndNTagWrite1StatPrm_c4)
			{
				// Success
				lblWriteErrorPrm_c4.Visible = false;
				AxTndNTagWrite2Prm_c4.UpdateLongValue(0, 1); // WriteRetentiveData
				AxTndNTagWrite2Prm_c4.Write();
				tmrPrm_c4.Enabled = true;
			}
			else
			{
				// Failure
				lblWriteErrorPrm_c4.Visible = true;
				ButtonsEnabledPrm_c4();
			}
		}
		private void tmrPrm_c4_Tick(object sender, EventArgs e)
		{
			tmrPrm_c4.Enabled = false;
			AxTndNTagWrite2Prm_c4.UpdateLongValue(0, 0);    // WriteRetentiveData
			AxTndNTagWrite2Prm_c4.Write();
			ReadTagsPrm_c4();
			ButtonsEnabledPrm_c4();
		}
		private void ButtonsDisabledPrm_c4()
		{
			btnReadPrm_c4.Enabled = false;
			btnWritePrm_c4.Enabled = false;
		}
		private void ButtonsEnabledPrm_c4()
		{
			btnReadPrm_c4.Enabled = true;
			btnWritePrm_c4.Enabled = true;
		}
		private void btnEncoderStart_c4_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c4 && !lbSR1_EncoderSetup_c4)
				lbEncoderStart_c4 = true;
			SetFocusReqBin_c4();
		}
		private void btnEncoderStop_c4_Click(object sender, EventArgs e)
		{
			if (!lbEncoderStart_c4)
				lbEncoderStop_c4 = true;
			SetFocusReqBin_c4();
		}
		private void tmrEncoderStart_c4_Tick(object sender, EventArgs e)
		{
			lbEncoderStart_c4 = false;
			tmrEncoderStart_c4.Enabled = false;
		}
		private void tmrEncoderStop_c4_Tick(object sender, EventArgs e)
		{
			lbEncoderStop_c4 = false;
			tmrEncoderStop_c4.Enabled = false;
		}
		private void EncoderSetupColors_c4()
		{
			if (lbSR1_EncoderSetup_c4)
				btnEncoderStart_c4.BackColor = Color.Lime;
			else
				btnEncoderStart_c4.UseVisualStyleBackColor = true;
		}
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
		private bool lbHomingStartLatch_c4;

		// Flags
		// From controller
		private bool lbMoveFWD_c4;
		private bool lbMoveREV_c4;
		private bool lbMoveSPD0_c4;
		private bool lbMoveSPD1_c4;

		private bool lbTndNTagReadMM1Stat_c4;
		private bool lbTndNTagWriteMM1Stat_c4;
		private bool lbTndNTagWriteMM2Stat_c4;
		private bool lbTndNTagWriteMM3Stat_c4;
		private bool lbTndNTagWriteMM4Stat_c4;

		private bool lbFWD_c4;
		private bool lbREV_c4;
		private bool lbSTOP_c4;
		private bool lbJogF_c4;
		private bool lbJogR_c4;
		// Carousel 4
		private bool lbReadErrorPrm_c4;
		private bool lbWriteErrorPrm_c4;
		private bool lbTndNTagRead1StatPrm_c4;
		private bool lbTndNTagWrite1StatPrm_c4;

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
		private void btnRead1_Click(object sender, EventArgs e)
		{
			Read_Read1();
		}
		private void btnWrite1_Click(object sender, EventArgs e)
		{
			Write_Write1();
		}
		private bool Read_Read1()
		{
			if (AxTndNTagRead1.IsValid())
				return false;

			AxTndNTagRead1.Read();
			lbMoveFWD_c1 = AxTndNTagRead1.GetBoolValue(0);
			lbMoveREV_c1 = AxTndNTagRead1.GetBoolValue(1);
			lbMoveSPD0_c1 = AxTndNTagRead1.GetBoolValue(2);
			lbMoveSPD1_c1 = AxTndNTagRead1.GetBoolValue(3);
			lnNumBins_c1 = AxTndNTagRead1.GetIntValue(4);
			lnCurBin_c1 = AxTndNTagRead1.GetIntValue(5);
			lnTgtBin_c1 = AxTndNTagRead1.GetIntValue(6);
			lnStatReg1_c1 = AxTndNTagRead1.GetIntValue(7);
			lbMoveFWD_c2 = AxTndNTagRead1.GetBoolValue(8);
			lbMoveREV_c2 = AxTndNTagRead1.GetBoolValue(9);
			lbMoveSPD0_c2 = AxTndNTagRead1.GetBoolValue(10);
			lbMoveSPD1_c2 = AxTndNTagRead1.GetBoolValue(11);
			lnNumBins_c2 = AxTndNTagRead1.GetIntValue(12);
			lnCurBin_c2 = AxTndNTagRead1.GetIntValue(13);
			lnTgtBin_c2 = AxTndNTagRead1.GetIntValue(14);
			lnStatReg1_c2 = AxTndNTagRead1.GetIntValue(15);
			lbMoveFWD_c3 = AxTndNTagRead1.GetBoolValue(16);
			lbMoveREV_c3 = AxTndNTagRead1.GetBoolValue(17);
			lbMoveSPD0_c3 = AxTndNTagRead1.GetBoolValue(18);
			lbMoveSPD1_c3 = AxTndNTagRead1.GetBoolValue(19);
			lnNumBins_c3 = AxTndNTagRead1.GetIntValue(20);
			lnCurBin_c3 = AxTndNTagRead1.GetIntValue(21);
			lnTgtBin_c3 = AxTndNTagRead1.GetIntValue(22);
			lnStatReg1_c3 = AxTndNTagRead1.GetIntValue(23);
			lbMoveFWD_c4 = AxTndNTagRead1.GetBoolValue(24);
			lbMoveREV_c4 = AxTndNTagRead1.GetBoolValue(25);
			lbMoveSPD0_c4 = AxTndNTagRead1.GetBoolValue(26);
			lbMoveSPD1_c4 = AxTndNTagRead1.GetBoolValue(27);
			lnNumBins_c4 = AxTndNTagRead1.GetIntValue(28);
			lnCurBin_c4 = AxTndNTagRead1.GetIntValue(29);
			lnTgtBin_c4 = AxTndNTagRead1.GetIntValue(30);
			lnStatReg1_c4 = AxTndNTagRead1.GetIntValue(31);
			lnVFDRunStat_c1 = AxTndNTagRead1.GetIntValue(32);
			lnVFDRunStat_c2 = AxTndNTagRead1.GetIntValue(33);
			lnVFDRunStat_c3 = AxTndNTagRead1.GetIntValue(34);
			lnVFDRunStat_c4 = AxTndNTagRead1.GetIntValue(35);
			lnVFDFaultStat_c1 = AxTndNTagRead1.GetIntValue(36);
			lnVFDFaultStat_c2 = AxTndNTagRead1.GetIntValue(37);
			lnVFDFaultStat_c3 = AxTndNTagRead1.GetIntValue(38);
			lnVFDFaultStat_c4 = AxTndNTagRead1.GetIntValue(39);

			return true;
		}
		private bool Write_Write1()
		{
			if (AxTndNTagWrite1.IsValid())
				return false;

			AxTndNTagWrite1.UpdateLongValue(0, lnStatReg2_c1);
			AxTndNTagWrite1.UpdateLongValue(1, lnReqBin_c1);
			AxTndNTagWrite1.UpdateLongValue(2, lnStatReg2_c2);
			AxTndNTagWrite1.UpdateLongValue(3, lnReqBin_c2);
			AxTndNTagWrite1.UpdateLongValue(4, lnStatReg2_c3);
			AxTndNTagWrite1.UpdateLongValue(5, lnReqBin_c3);
			AxTndNTagWrite1.UpdateLongValue(6, lnStatReg2_c4);
			AxTndNTagWrite1.UpdateLongValue(7, lnReqBin_c4);
			AxTndNTagWrite1.UpdateLongValue(8, lnHeartbeat);
			AxTndNTagWrite1.UpdateLongValue(9, lnSetBinPos_c1);
			AxTndNTagWrite1.UpdateLongValue(10, lnSetBinPos_c2);
			AxTndNTagWrite1.UpdateLongValue(11, lnSetBinPos_c3);
			AxTndNTagWrite1.UpdateLongValue(12, lnSetBinPos_c4);

			AxTndNTagWrite1.Write();

			return true;
		}


		#region

		public const short InputType = 1;
		public const short FlagType = 2;
		public const short TimerType = 3;
		public const short OutputType = 4;
		public const short CounterType = 5;
		public const short RegisterType = 6;
		public const short NumberType = 7;
		public const short ASCIIType = 8;
		public const short FloatType = 19;
		public const short SystemType = 20;
		public const short StringType = 22;
		public const short ArrayType = 21;
		public const short ByteType = 25;

		private const short ThinkAndDoSuccess = 1;
		private const int TnDTargetType = 0;

		private string lcTndStation;


		private bool lbTndNTagRead1Stat;
		private bool lbTndNTagWrite1Stat;

		private bool lbConrtollerInitError;

		private int lnHeartbeat;

		//
		// Setup
		//
		private bool lbPrmLoad_c1;
		private bool lbPrmLoad_c2;
		private bool lbPrmLoad_c3;
		private bool lbPrmLoad_c4;



		#endregion

		#region TNdNTag instances

		private readonly TndNTag.TndNTag AxTndNTagRead1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagReadMM1_c1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM1_c1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM2_c1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM3_c1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM4_c1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagReadMM1_c2 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM1_c2 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM2_c2 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM3_c2 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM4_c2 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagReadMM1_c3 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM1_c3 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM2_c3 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM3_c3 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM4_c3 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagReadMM1_c4 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM1_c4 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM2_c4 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM3_c4 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWriteMM4_c4 = new TndNTag.TndNTag();

		private readonly TndNTag.TndNTag AxTndNTagReadPrm_c1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite1Prm_c1 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite2Prm_c1 = new TndNTag.TndNTag();

		private readonly TndNTag.TndNTag AxTndNTagReadPrm_c2 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite1Prm_c2 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite2Prm_c2 = new TndNTag.TndNTag();
		
		private readonly TndNTag.TndNTag AxTndNTagReadPrm_c3 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite1Prm_c3 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite2Prm_c3 = new TndNTag.TndNTag();
		
		private readonly TndNTag.TndNTag AxTndNTagReadPrm_c4 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite1Prm_c4 = new TndNTag.TndNTag();
		private readonly TndNTag.TndNTag AxTndNTagWrite2Prm_c4 = new TndNTag.TndNTag();

		#endregion


	}
}
