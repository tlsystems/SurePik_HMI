Public Class frmInterface

    ' TnD
    Public Const InputType As Short = 1
    Public Const FlagType As Short = 2
    Public Const TimerType As Short = 3
    Public Const OutputType As Short = 4
    Public Const CounterType As Short = 5
    Public Const RegisterType As Short = 6
    Public Const NumberType As Short = 7
    Public Const ASCIIType As Short = 8
    Public Const FloatType As Short = 19
    Public Const SystemType As Short = 20
    Public Const StringType As Short = 22
    Public Const ArrayType As Short = 21
    Public Const ByteType As Short = 25

    Const TnDTargetType As Integer = 0
    Dim lcTndStation As String = My.Computer.Name

    Const ThinkAndDoSuccess As Short = 1

    Dim lnTndNTagRead1Stat As Short
    Dim lnTndNTagWrite1Stat As Short

    Dim lbConrtollerInitError As Boolean

    Dim lnHeartbeat As Integer

    '''''''''''''''''' '
    ' Carousel 1 items '
    '''''''''''''''''' '
    Dim lnRequestedBin_c1 As Integer
    Dim lnSetBinPos_c1 As Integer

    Dim lnNumBins_c1 As Integer
    Dim lnCurBin_c1 As Integer
    Dim lnTgtBin_c1 As Integer

    Dim lnReqBin_c1 As Integer

    Dim lnStatReg1_c1 As Integer
    Dim lnStatReg2_c1 As Integer

    Dim lnVFDRunStat_c1 As Integer
    Dim lnVFDFaultStat_c1 As Integer

    ' Status Register 1
    ' Read from controller
    Dim lbSR1_Enabled_c1 As Boolean
    Dim lbSR1_Move_c1 As Boolean
    Dim lbSR1_Moving_c1 As Boolean
    Dim lbSR1_CW1_CCW0_c1 As Boolean
    Dim lbSR1_ManualMode_c1 As Boolean
    Dim lbSR1_EncoderSetup_c1 As Boolean
    Dim lbSR1_Homing_c1 As Boolean
    Dim lbSR1_AutoControl_c1 As Boolean
    Dim lbSR1_VFD_c1 As Boolean
    Dim lbSR1_SafetyCkt_c1 As Boolean
    Dim lbSR1_Ready_c1 As Boolean

    ' Status Register 2
    ' Write to controller
    Dim lbHomingStart_c1 As Boolean
    Dim lbHomingStop_c1 As Boolean
    Dim lbEncoderStart_c1 As Boolean
    Dim lbEncoderStop_c1 As Boolean
    Dim lbManualMode_c1 As Boolean
    Dim lbHomingStartLatch_c1 As Boolean

    ' Flags
    'Read from controller
    Dim lbMoveFWD_c1 As Boolean
    Dim lbMoveREV_c1 As Boolean
    Dim lbMoveSPD0_c1 As Boolean
    Dim lbMoveSPD1_c1 As Boolean

    Dim lnTndNTagReadMM1Stat_c1 As Short
    Dim lnTndNTagWriteMM1Stat_c1 As Short
    Dim lnTndNTagWriteMM2Stat_c1 As Short
    Dim lnTndNTagWriteMM3Stat_c1 As Short
    Dim lnTndNTagWriteMM4Stat_c1 As Short

    Dim lbFWD_c1 As Boolean
    Dim lbREV_c1 As Boolean
    Dim lbSTOP_c1 As Boolean
    Dim lbJogF_c1 As Boolean
    Dim lbJogR_c1 As Boolean

    '''''''''''''''''' '
    ' Carousel 2 items '
    '''''''''''''''''' '
    Dim lnRequestedBin_c2 As Integer
    Dim lnSetBinPos_c2 As Integer

    Dim lnNumBins_c2 As Integer
    Dim lnCurBin_c2 As Integer
    Dim lnTgtBin_c2 As Integer

    Dim lnReqBin_c2 As Integer

    Dim lnStatReg1_c2 As Integer
    Dim lnStatReg2_c2 As Integer

    Dim lnVFDRunStat_c2 As Integer
    Dim lnVFDFaultStat_c2 As Integer

    ' Status Register 1
    ' Read from controller
    Dim lbSR1_Enabled_c2 As Boolean
    Dim lbSR1_Move_c2 As Boolean
    Dim lbSR1_Moving_c2 As Boolean
    Dim lbSR1_CW1_CCW0_c2 As Boolean
    Dim lbSR1_ManualMode_c2 As Boolean
    Dim lbSR1_EncoderSetup_c2 As Boolean
    Dim lbSR1_Homing_c2 As Boolean
    Dim lbSR1_AutoControl_c2 As Boolean
    Dim lbSR1_VFD_c2 As Boolean
    Dim lbSR1_SafetyCkt_c2 As Boolean
    Dim lbSR1_Ready_c2 As Boolean

    ' Status Register 2
    ' Write to controller
    Dim lbHomingStart_c2 As Boolean
    Dim lbHomingStop_c2 As Boolean
    Dim lbEncoderStart_c2 As Boolean
    Dim lbEncoderStop_c2 As Boolean
    Dim lbManualMode_c2 As Boolean
    Dim lbHomingStartLatch_c2 As Boolean

    ' Flags
    'Read from controller
    Dim lbMoveFWD_c2 As Boolean
    Dim lbMoveREV_c2 As Boolean
    Dim lbMoveSPD0_c2 As Boolean
    Dim lbMoveSPD1_c2 As Boolean

    Dim lnTndNTagReadMM1Stat_c2 As Short
    Dim lnTndNTagWriteMM1Stat_c2 As Short
    Dim lnTndNTagWriteMM2Stat_c2 As Short
    Dim lnTndNTagWriteMM3Stat_c2 As Short
    Dim lnTndNTagWriteMM4Stat_c2 As Short

    Dim lbFWD_c2 As Boolean
    Dim lbREV_c2 As Boolean
    Dim lbSTOP_c2 As Boolean
    Dim lbJogF_c2 As Boolean
    Dim lbJogR_c2 As Boolean

    '''''''''''''''''' '
    ' Carousel 3 items '
    '''''''''''''''''' '
    Dim lnRequestedBin_c3 As Integer
    Dim lnSetBinPos_c3 As Integer

    Dim lnNumBins_c3 As Integer
    Dim lnCurBin_c3 As Integer
    Dim lnTgtBin_c3 As Integer

    Dim lnReqBin_c3 As Integer

    Dim lnStatReg1_c3 As Integer
    Dim lnStatReg2_c3 As Integer

    Dim lnVFDRunStat_c3 As Integer
    Dim lnVFDFaultStat_c3 As Integer

    ' Status Register 1
    ' Read from controller
    Dim lbSR1_Enabled_c3 As Boolean
    Dim lbSR1_Move_c3 As Boolean
    Dim lbSR1_Moving_c3 As Boolean
    Dim lbSR1_CW1_CCW0_c3 As Boolean
    Dim lbSR1_ManualMode_c3 As Boolean
    Dim lbSR1_EncoderSetup_c3 As Boolean
    Dim lbSR1_Homing_c3 As Boolean
    Dim lbSR1_AutoControl_c3 As Boolean
    Dim lbSR1_VFD_c3 As Boolean
    Dim lbSR1_SafetyCkt_c3 As Boolean
    Dim lbSR1_Ready_c3 As Boolean

    ' Status Register 2
    ' Write to controller
    Dim lbHomingStart_c3 As Boolean
    Dim lbHomingStop_c3 As Boolean
    Dim lbEncoderStart_c3 As Boolean
    Dim lbEncoderStop_c3 As Boolean
    Dim lbManualMode_c3 As Boolean
    Dim lbHomingStartLatch_c3 As Boolean

    ' Flags
    'Read from controller
    Dim lbMoveFWD_c3 As Boolean
    Dim lbMoveREV_c3 As Boolean
    Dim lbMoveSPD0_c3 As Boolean
    Dim lbMoveSPD1_c3 As Boolean

    Dim lnTndNTagReadMM1Stat_c3 As Short
    Dim lnTndNTagWriteMM1Stat_c3 As Short
    Dim lnTndNTagWriteMM2Stat_c3 As Short
    Dim lnTndNTagWriteMM3Stat_c3 As Short
    Dim lnTndNTagWriteMM4Stat_c3 As Short

    Dim lbFWD_c3 As Boolean
    Dim lbREV_c3 As Boolean
    Dim lbSTOP_c3 As Boolean
    Dim lbJogF_c3 As Boolean
    Dim lbJogR_c3 As Boolean

    '''''''''''''''''' '
    ' Carousel 4 items '
    '''''''''''''''''' '
    Dim lnRequestedBin_c4 As Integer
    Dim lnSetBinPos_c4 As Integer

    Dim lnNumBins_c4 As Integer
    Dim lnCurBin_c4 As Integer
    Dim lnTgtBin_c4 As Integer

    Dim lnReqBin_c4 As Integer

    Dim lnStatReg1_c4 As Integer
    Dim lnStatReg2_c4 As Integer

    Dim lnVFDRunStat_c4 As Integer
    Dim lnVFDFaultStat_c4 As Integer

    ' Status Register 1
    ' Read from controller
    Dim lbSR1_Enabled_c4 As Boolean
    Dim lbSR1_Move_c4 As Boolean
    Dim lbSR1_Moving_c4 As Boolean
    Dim lbSR1_CW1_CCW0_c4 As Boolean
    Dim lbSR1_ManualMode_c4 As Boolean
    Dim lbSR1_EncoderSetup_c4 As Boolean
    Dim lbSR1_Homing_c4 As Boolean
    Dim lbSR1_AutoControl_c4 As Boolean
    Dim lbSR1_VFD_c4 As Boolean
    Dim lbSR1_SafetyCkt_c4 As Boolean
    Dim lbSR1_Ready_c4 As Boolean

    ' Status Register 2
    ' Write to controller
    Dim lbHomingStart_c4 As Boolean
    Dim lbHomingStop_c4 As Boolean
    Dim lbEncoderStart_c4 As Boolean
    Dim lbEncoderStop_c4 As Boolean
    Dim lbManualMode_c4 As Boolean
    Dim lbHomingStartLatch_c4 As Boolean

    ' Flags
    'Read from controller
    Dim lbMoveFWD_c4 As Boolean
    Dim lbMoveREV_c4 As Boolean
    Dim lbMoveSPD0_c4 As Boolean
    Dim lbMoveSPD1_c4 As Boolean

    Dim lnTndNTagReadMM1Stat_c4 As Short
    Dim lnTndNTagWriteMM1Stat_c4 As Short
    Dim lnTndNTagWriteMM2Stat_c4 As Short
    Dim lnTndNTagWriteMM3Stat_c4 As Short
    Dim lnTndNTagWriteMM4Stat_c4 As Short

    Dim lbFWD_c4 As Boolean
    Dim lbREV_c4 As Boolean
    Dim lbSTOP_c4 As Boolean
    Dim lbJogF_c4 As Boolean
    Dim lbJogR_c4 As Boolean

    '''''''''
    ' Setup '
    '''''''''
    Dim lbPrmLoad_c1 As Boolean
    Dim lbPrmLoad_c2 As Boolean
    Dim lbPrmLoad_c3 As Boolean
    Dim lbPrmLoad_c4 As Boolean

    'Carousel 1
    Dim lbReadErrorPrm_c1 As Boolean
    Dim lbWriteErrorPrm_c1 As Boolean
    Dim lnTndNTagRead1StatPrm_c1 As Short
    Dim lnTndNTagWrite1StatPrm_c1 As Short

    Dim lnNumBinsPrm_c1 As Short
    Dim lnRatioPrm_c1 As Integer
    Dim lnBinTolPctPrm_c1 As Short
    Dim lnControlTypePrm_c1 As Short
    Dim lnMMMDelayPrm_c1 As Short
    Dim lnStepsPerRevPrm_c1 As Short
    Dim nPosOffsetPct_c1 As Short

    Dim lnSlowPreset1Prm_c1 As Short
    Dim lnSlowPreset2Prm_c1 As Short
    Dim lnSlowPreset3Prm_c1 As Short
    Dim lnStopPresetPrm_c1 As Short

    Dim lnSafetyConfigPrm_c1 As UInt32

    'Carousel 2
    Dim lbReadErrorPrm_c2 As Boolean
    Dim lbWriteErrorPrm_c2 As Boolean
    Dim lnTndNTagRead1StatPrm_c2 As Short
    Dim lnTndNTagWrite1StatPrm_c2 As Short

    Dim lnNumBinsPrm_c2 As Short
    Dim lnRatioPrm_c2 As Integer
    Dim lnBinTolPctPrm_c2 As Short
    Dim lnControlTypePrm_c2 As Short
    Dim lnMMMDelayPrm_c2 As Short
    Dim lnStepsPerRevPrm_c2 As Short
    Dim nPosOffsetPct_c2 As Short

    Dim lnSlowPreset1Prm_c2 As Short
    Dim lnSlowPreset2Prm_c2 As Short
    Dim lnSlowPreset3Prm_c2 As Short
    Dim lnStopPresetPrm_c2 As Short

    Dim lnSafetyConfigPrm_c2 As UInt32

    'Carousel 3
    Dim lbReadErrorPrm_c3 As Boolean
    Dim lbWriteErrorPrm_c3 As Boolean
    Dim lnTndNTagRead1StatPrm_c3 As Short
    Dim lnTndNTagWrite1StatPrm_c3 As Short

    Dim lnNumBinsPrm_c3 As Short
    Dim lnRatioPrm_c3 As Integer
    Dim lnBinTolPctPrm_c3 As Short
    Dim lnControlTypePrm_c3 As Short
    Dim lnMMMDelayPrm_c3 As Short
    Dim lnStepsPerRevPrm_c3 As Short
    Dim nPosOffsetPct_c3 As Short

    Dim lnSlowPreset1Prm_c3 As Short
    Dim lnSlowPreset2Prm_c3 As Short
    Dim lnSlowPreset3Prm_c3 As Short
    Dim lnStopPresetPrm_c3 As Short

    Dim lnSafetyConfigPrm_c3 As UInt32

    'Carousel 4
    Dim lbReadErrorPrm_c4 As Boolean
    Dim lbWriteErrorPrm_c4 As Boolean
    Dim lnTndNTagRead1StatPrm_c4 As Short
    Dim lnTndNTagWrite1StatPrm_c4 As Short

    Dim lnNumBinsPrm_c4 As Short
    Dim lnRatioPrm_c4 As Integer
    Dim lnBinTolPctPrm_c4 As Short
    Dim lnControlTypePrm_c4 As Short
    Dim lnMMMDelayPrm_c4 As Short
    Dim lnStepsPerRevPrm_c4 As Short
    Dim nPosOffsetPct_c4 As Short

    Dim lnSlowPreset1Prm_c4 As Short
    Dim lnSlowPreset2Prm_c4 As Short
    Dim lnSlowPreset3Prm_c4 As Short
    Dim lnStopPresetPrm_c4 As Short

    Dim lnSafetyConfigPrm_c4 As UInt32

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.lblVersion.Text = String.Format("V {0}", My.Application.Info.Version.ToString)

        ' Connect to Controller
        Me.TnDStartup()

        ' Manual Mode
        Me.ManualModeStartup_c1()
        Me.ManualModeStartup_c2()
        Me.ManualModeStartup_c3()
        Me.ManualModeStartup_c4()

        ' Setup
        Me.PrmLoad_c1()

        'Process timers
        Me.tmrObserver.Enabled = True

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' Closing the form will reset values in the controller.
        Dim result As Boolean
        If (MessageBox.Show("Are you sure you wish to exit?", "Application Exit", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then
            e.Cancel = True
            result = True
        End If
        If result = False Then
            Me.StopMM_c1()
            Me.StopMM_c2()
            Me.StopMM_c3()
            Me.StopMM_c4()
            Me.lnStatReg2_c1 = 0
            Me.lnStatReg2_c1 += 2 ^ 1 'Stop Homing
            Me.lnStatReg2_c2 = 0
            Me.lnStatReg2_c2 += 2 ^ 1 'Stop Homing
            Me.lnStatReg2_c3 = 0
            Me.lnStatReg2_c3 += 2 ^ 1 'Stop Homing
            Me.lnStatReg2_c4 = 0
            Me.lnStatReg2_c4 += 2 ^ 1 'Stop Homing
            'All data items in the ocx must be written to.
            Me.AxTndNTagWrite1.UpdateLongValue(0, lnStatReg2_c1)
            Me.AxTndNTagWrite1.UpdateLongValue(1, lnReqBin_c1)
            Me.AxTndNTagWrite1.UpdateLongValue(2, lnStatReg2_c2)
            Me.AxTndNTagWrite1.UpdateLongValue(3, lnReqBin_c2)
            Me.AxTndNTagWrite1.UpdateLongValue(4, lnStatReg2_c3)
            Me.AxTndNTagWrite1.UpdateLongValue(5, lnReqBin_c3)
            Me.AxTndNTagWrite1.UpdateLongValue(6, lnStatReg2_c4)
            Me.AxTndNTagWrite1.UpdateLongValue(7, lnReqBin_c4)
            Me.AxTndNTagWrite1.UpdateLongValue(8, lnHeartbeat)
            Me.AxTndNTagWrite1.UpdateLongValue(9, lnSetBinPos_c1)
            Me.AxTndNTagWrite1.UpdateLongValue(10, lnSetBinPos_c2)
            Me.AxTndNTagWrite1.UpdateLongValue(11, lnSetBinPos_c3)
            Me.AxTndNTagWrite1.UpdateLongValue(12, lnSetBinPos_c4)
            Me.AxTndNTagWrite1.Write()
        End If

    End Sub

    Sub TnDStartup()

        Dim nrc As Short

        ' Connect to the tndstation
        Me.AxTndNTagRead1.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWrite1.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagRead1.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWrite1.ThinkAndDoStationName = Me.lcTndStation

        'Manual Mode
        ' Carousel 1
        Me.AxTndNTagReadMM1_c1.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagReadMM1_c1.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM1_c1.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM1_c1.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM2_c1.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM2_c1.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM3_c1.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM3_c1.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM4_c1.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM4_c1.ThinkAndDoStationName = Me.lcTndStation
        ' Carousel 2
        Me.AxTndNTagReadMM1_c2.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagReadMM1_c2.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM1_c2.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM1_c2.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM2_c2.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM2_c2.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM3_c2.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM3_c2.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM4_c2.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM4_c2.ThinkAndDoStationName = Me.lcTndStation
        ' Carousel 3
        Me.AxTndNTagReadMM1_c3.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagReadMM1_c3.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM1_c3.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM1_c3.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM2_c3.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM2_c3.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM3_c3.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM3_c3.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM4_c3.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM4_c3.ThinkAndDoStationName = Me.lcTndStation
        ' Carousel 4
        Me.AxTndNTagReadMM1_c4.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagReadMM1_c4.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM1_c4.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM1_c4.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM2_c4.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM2_c4.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM3_c4.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM3_c4.ThinkAndDoStationName = Me.lcTndStation
        Me.AxTndNTagWriteMM4_c4.RuntimeTargetType = TnDTargetType
        Me.AxTndNTagWriteMM4_c4.ThinkAndDoStationName = Me.lcTndStation

        If (ThinkAndDoSuccess = Me.AxTndNTagRead1.Connect) Then
            ' Register tags
            nrc = Me.AxTndNTagRead1.StartTagList()
            ' Carousel 1
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 59, "") ' 0 MoveFWD
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 60, "") ' 1 MoveREV
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 61, "") ' 2 MoveSPD0
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 62, "") ' 3 MoveSPD1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 1, "") ' 4 NumBins_c1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 19, "") ' 5 CurBin_c1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 25, "") ' 6 TgtBin_c1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 37, "") ' 7 StatReg1_c1
            ' Carousel 2
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 63, "") ' 8 MoveFWD
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 64, "") ' 9 MoveREV
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 65, "") ' 10 MoveSPD0
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 66, "") ' 11 MoveSPD1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 2, "") ' 12 NumBins_c2
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 20, "") ' 13 CurBin_c2
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 26, "") ' 14 TgtBin_c2
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 38, "") ' 15 StatReg1_c2
            ' Carousel 3
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 67, "") ' 16 MoveFWD
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 68, "") ' 17 MoveREV
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 69, "") ' 18 MoveSPD0
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 70, "") ' 19 MoveSPD1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 3, "") ' 20 NumBins_c3
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 21, "") ' 21 CurBin_c3
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 27, "") ' 22 TgtBin_c3
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 39, "") ' 23 StatReg1_c3
            ' Carousel 4
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 71, "") ' 24 MoveFWD
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 72, "") ' 25 MoveREV
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 73, "") ' 26 MoveSPD0
            nrc = Me.AxTndNTagRead1.AddToTagList(FlagType, 74, "") ' 27 MoveSPD1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 4, "") ' 28 NumBins_c4
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 22, "") ' 29 CurBin_c4
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 28, "") ' 30 TgtBin_c4
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 40, "") ' 31 StatReg1_c4
            ' VFDs
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 67, "") ' 32 VFDRunStatus_c1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 68, "") ' 33 VFDRunStatus_c2
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 69, "") ' 34 VFDRunStatus_c3
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 70, "") ' 35 VFDRunStatus_c4
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 73, "") ' 36 VFDFaultStatus_c1
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 74, "") ' 37 VFDFaultStatus_c2
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 75, "") ' 38 VFDFaultStatus_c3
            nrc = Me.AxTndNTagRead1.AddToTagList(NumberType, 76, "") ' 39 VFDFaultStatus_c4

            nrc = Me.AxTndNTagRead1.EndTagList()
            If (ThinkAndDoSuccess = Me.AxTndNTagWrite1.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWrite1.StartTagList()
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 43, "") ' StatReg2_c1
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 49, "") ' ReqBin_c1
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 44, "") ' StatReg2_c2
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 50, "") ' ReqBin_c2
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 45, "") ' StatReg2_c3
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 51, "") ' ReqBin_c3
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 46, "") ' StatReg2_c4
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 52, "") ' ReqBin_c4
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 0, "") ' Heartbeat
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 335, "") ' SetBinPos_c1
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 336, "") ' SetBinPos_c2
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 337, "") ' SetBinPos_c3
                nrc = Me.AxTndNTagWrite1.AddToTagList(NumberType, 338, "") ' SetBinPos_c4
                nrc = Me.AxTndNTagWrite1.EndTagList()
            Else
                MsgBox("Cannot connect Write1 to controller.")
                Me.lbConrtollerInitError = True
            End If
            ' Manual Mode
            ' Carousel 1
            If (ThinkAndDoSuccess = Me.AxTndNTagReadMM1_c1.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadMM1_c1.StartTagList()
                nrc = Me.AxTndNTagReadMM1_c1.AddToTagList(FlagType, 9, "") ' FWD
                nrc = Me.AxTndNTagReadMM1_c1.AddToTagList(FlagType, 10, "") ' REV
                nrc = Me.AxTndNTagReadMM1_c1.AddToTagList(FlagType, 11, "") ' STOP
                nrc = Me.AxTndNTagReadMM1_c1.EndTagList()
            Else
                MsgBox("Cannot connect ReadMM1_c1 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM1_c1.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM1_c1.StartTagList()
                nrc = Me.AxTndNTagWriteMM1_c1.AddToTagList(FlagType, 9, "") ' FWD
                nrc = Me.AxTndNTagWriteMM1_c1.EndTagList()
                Me.AxTndNTagWriteMM1_c1.UpdateLongValue(0, 0)  'FWD
                Me.AxTndNTagWriteMM1_c1.Write()
            Else
                MsgBox("Cannot connect WriteMM1_c1 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM2_c1.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM2_c1.StartTagList()
                nrc = Me.AxTndNTagWriteMM2_c1.AddToTagList(FlagType, 10, "") ' REV
                nrc = Me.AxTndNTagWriteMM2_c1.EndTagList()
                Me.AxTndNTagWriteMM2_c1.UpdateLongValue(0, 0)  'REV
                Me.AxTndNTagWriteMM2_c1.Write()
            Else
                MsgBox("Cannot connect WriteMM2_c1 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM3_c1.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM3_c1.StartTagList()
                nrc = Me.AxTndNTagWriteMM3_c1.AddToTagList(FlagType, 11, "") ' STOP
                nrc = Me.AxTndNTagWriteMM3_c1.EndTagList()
                Me.AxTndNTagWriteMM3_c1.UpdateLongValue(0, 1)  'STOP
                Me.AxTndNTagWriteMM3_c1.Write()
            Else
                MsgBox("Cannot connect WriteMM3_c1 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM4_c1.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM4_c1.StartTagList()
                nrc = Me.AxTndNTagWriteMM4_c1.AddToTagList(FlagType, 12, "") ' JogF
                nrc = Me.AxTndNTagWriteMM4_c1.AddToTagList(FlagType, 13, "") ' JogR
                nrc = Me.AxTndNTagWriteMM4_c1.EndTagList()
                Me.ReadTagsMM_c1()
            Else
                MsgBox("Cannot connect WriteMM4_c1 to controller.")
            End If
            ' Carousel 2
            If (ThinkAndDoSuccess = Me.AxTndNTagReadMM1_c2.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadMM1_c2.StartTagList()
                nrc = Me.AxTndNTagReadMM1_c2.AddToTagList(FlagType, 22, "") ' FWD
                nrc = Me.AxTndNTagReadMM1_c2.AddToTagList(FlagType, 23, "") ' REV
                nrc = Me.AxTndNTagReadMM1_c2.AddToTagList(FlagType, 24, "") ' STOP
                nrc = Me.AxTndNTagReadMM1_c2.EndTagList()
            Else
                MsgBox("Cannot connect ReadMM1_c2 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM1_c2.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM1_c2.StartTagList()
                nrc = Me.AxTndNTagWriteMM1_c2.AddToTagList(FlagType, 22, "") ' FWD
                nrc = Me.AxTndNTagWriteMM1_c2.EndTagList()
                Me.AxTndNTagWriteMM1_c2.UpdateLongValue(0, 0)  'FWD
                Me.AxTndNTagWriteMM1_c2.Write()
            Else
                MsgBox("Cannot connect WriteMM1_c2 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM2_c2.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM2_c2.StartTagList()
                nrc = Me.AxTndNTagWriteMM2_c2.AddToTagList(FlagType, 23, "") ' REV
                nrc = Me.AxTndNTagWriteMM2_c2.EndTagList()
                Me.AxTndNTagWriteMM2_c2.UpdateLongValue(0, 0)  'REV
                Me.AxTndNTagWriteMM2_c2.Write()
            Else
                MsgBox("Cannot connect WriteMM2_c2 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM3_c2.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM3_c2.StartTagList()
                nrc = Me.AxTndNTagWriteMM3_c2.AddToTagList(FlagType, 24, "") ' STOP
                nrc = Me.AxTndNTagWriteMM3_c2.EndTagList()
                Me.AxTndNTagWriteMM3_c2.UpdateLongValue(0, 1)  'STOP
                Me.AxTndNTagWriteMM3_c2.Write()
            Else
                MsgBox("Cannot connect WriteMM3_c2 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM4_c2.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM4_c2.StartTagList()
                nrc = Me.AxTndNTagWriteMM4_c2.AddToTagList(FlagType, 25, "") ' JogF
                nrc = Me.AxTndNTagWriteMM4_c2.AddToTagList(FlagType, 26, "") ' JogR
                nrc = Me.AxTndNTagWriteMM4_c2.EndTagList()
                Me.ReadTagsMM_c2()
            Else
                MsgBox("Cannot connect WriteMM4_c2 to controller.")
            End If
            ' Carousel 3
            If (ThinkAndDoSuccess = Me.AxTndNTagReadMM1_c3.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadMM1_c3.StartTagList()
                nrc = Me.AxTndNTagReadMM1_c3.AddToTagList(FlagType, 35, "") ' FWD
                nrc = Me.AxTndNTagReadMM1_c3.AddToTagList(FlagType, 36, "") ' REV
                nrc = Me.AxTndNTagReadMM1_c3.AddToTagList(FlagType, 37, "") ' STOP
                nrc = Me.AxTndNTagReadMM1_c3.EndTagList()
            Else
                MsgBox("Cannot connect ReadMM1_c3 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM1_c3.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM1_c3.StartTagList()
                nrc = Me.AxTndNTagWriteMM1_c3.AddToTagList(FlagType, 35, "") ' FWD
                nrc = Me.AxTndNTagWriteMM1_c3.EndTagList()
                Me.AxTndNTagWriteMM1_c3.UpdateLongValue(0, 0)  'FWD
                Me.AxTndNTagWriteMM1_c3.Write()
            Else
                MsgBox("Cannot connect WriteMM1_c3 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM2_c3.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM2_c3.StartTagList()
                nrc = Me.AxTndNTagWriteMM2_c3.AddToTagList(FlagType, 36, "") ' REV
                nrc = Me.AxTndNTagWriteMM2_c3.EndTagList()
                Me.AxTndNTagWriteMM2_c3.UpdateLongValue(0, 0)  'REV
                Me.AxTndNTagWriteMM2_c3.Write()
            Else
                MsgBox("Cannot connect WriteMM2_c3 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM3_c3.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM3_c3.StartTagList()
                nrc = Me.AxTndNTagWriteMM3_c3.AddToTagList(FlagType, 37, "") ' STOP
                nrc = Me.AxTndNTagWriteMM3_c3.EndTagList()
                Me.AxTndNTagWriteMM3_c3.UpdateLongValue(0, 1)  'STOP
                Me.AxTndNTagWriteMM3_c3.Write()
            Else
                MsgBox("Cannot connect WriteMM3_c3 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM4_c3.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM4_c3.StartTagList()
                nrc = Me.AxTndNTagWriteMM4_c3.AddToTagList(FlagType, 38, "") ' JogF
                nrc = Me.AxTndNTagWriteMM4_c3.AddToTagList(FlagType, 39, "") ' JogR
                nrc = Me.AxTndNTagWriteMM4_c3.EndTagList()
                Me.ReadTagsMM_c3()
            Else
                MsgBox("Cannot connect WriteMM4_c3 to controller.")
            End If
            ' Carousel 4
            If (ThinkAndDoSuccess = Me.AxTndNTagReadMM1_c4.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadMM1_c4.StartTagList()
                nrc = Me.AxTndNTagReadMM1_c4.AddToTagList(FlagType, 48, "") ' FWD
                nrc = Me.AxTndNTagReadMM1_c4.AddToTagList(FlagType, 49, "") ' REV
                nrc = Me.AxTndNTagReadMM1_c4.AddToTagList(FlagType, 50, "") ' STOP
                nrc = Me.AxTndNTagReadMM1_c4.EndTagList()
            Else
                MsgBox("Cannot connect ReadMM1_c4 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM1_c4.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM1_c4.StartTagList()
                nrc = Me.AxTndNTagWriteMM1_c4.AddToTagList(FlagType, 48, "") ' FWD
                nrc = Me.AxTndNTagWriteMM1_c4.EndTagList()
                Me.AxTndNTagWriteMM1_c4.UpdateLongValue(0, 0)  'FWD
                Me.AxTndNTagWriteMM1_c4.Write()
            Else
                MsgBox("Cannot connect WriteMM1_c4 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM2_c4.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM2_c4.StartTagList()
                nrc = Me.AxTndNTagWriteMM2_c4.AddToTagList(FlagType, 49, "") ' REV
                nrc = Me.AxTndNTagWriteMM2_c4.EndTagList()
                Me.AxTndNTagWriteMM2_c4.UpdateLongValue(0, 0)  'REV
                Me.AxTndNTagWriteMM2_c4.Write()
            Else
                MsgBox("Cannot connect WriteMM2_c4 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM3_c4.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM3_c4.StartTagList()
                nrc = Me.AxTndNTagWriteMM3_c4.AddToTagList(FlagType, 50, "") ' STOP
                nrc = Me.AxTndNTagWriteMM3_c4.EndTagList()
                Me.AxTndNTagWriteMM3_c4.UpdateLongValue(0, 1)  'STOP
                Me.AxTndNTagWriteMM3_c4.Write()
            Else
                MsgBox("Cannot connect WriteMM3_c4 to controller.")
            End If
            If (ThinkAndDoSuccess = Me.AxTndNTagWriteMM4_c4.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagWriteMM4_c4.StartTagList()
                nrc = Me.AxTndNTagWriteMM4_c4.AddToTagList(FlagType, 51, "") ' JogF
                nrc = Me.AxTndNTagWriteMM4_c4.AddToTagList(FlagType, 52, "") ' JogR
                nrc = Me.AxTndNTagWriteMM4_c4.EndTagList()
                Me.ReadTagsMM_c4()
            Else
                MsgBox("Cannot connect WriteMM4_c4 to controller.")
            End If

            ' Start Tag timer to Read/Write data
            Me.tmrTnDNTag1.Enabled = True
        Else
            MsgBox("Cannot connect Read1 to controller.")
            Me.lbConrtollerInitError = True
        End If

    End Sub

    Private Sub tmrTnDNTag1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTnDNTag1.Tick
        ' A timer can be used to Read from and/or Write to the controller.

        Me.tmrTnDNTag1.Enabled = False

        '''''''''''''
        ' Read tags '
        '''''''''''''
        Dim nrc_r As Short

        nrc_r = AxTndNTagRead1.Read()
        Me.lnTndNTagRead1Stat = nrc_r

        If nrc_r = ThinkAndDoSuccess Then
            ' Read Data from controller
            ' Carousel 1
            Me.lbMoveFWD_c1 = AxTndNTagRead1.GetValueAt(0)
            Me.lbMoveREV_c1 = AxTndNTagRead1.GetValueAt(1)
            Me.lbMoveSPD0_c1 = AxTndNTagRead1.GetValueAt(2)
            Me.lbMoveSPD1_c1 = AxTndNTagRead1.GetValueAt(3)
            Me.lnNumBins_c1 = AxTndNTagRead1.GetValueAt(4)
            Me.lnCurBin_c1 = AxTndNTagRead1.GetValueAt(5)
            Me.lnTgtBin_c1 = AxTndNTagRead1.GetValueAt(6)
            Me.lnStatReg1_c1 = AxTndNTagRead1.GetValueAt(7)
            ' Carousel 2
            Me.lbMoveFWD_c2 = AxTndNTagRead1.GetValueAt(8)
            Me.lbMoveREV_c2 = AxTndNTagRead1.GetValueAt(9)
            Me.lbMoveSPD0_c2 = AxTndNTagRead1.GetValueAt(10)
            Me.lbMoveSPD1_c2 = AxTndNTagRead1.GetValueAt(11)
            Me.lnNumBins_c2 = AxTndNTagRead1.GetValueAt(12)
            Me.lnCurBin_c2 = AxTndNTagRead1.GetValueAt(13)
            Me.lnTgtBin_c2 = AxTndNTagRead1.GetValueAt(14)
            Me.lnStatReg1_c2 = AxTndNTagRead1.GetValueAt(15)
            ' Carousel 3
            Me.lbMoveFWD_c3 = AxTndNTagRead1.GetValueAt(16)
            Me.lbMoveREV_c3 = AxTndNTagRead1.GetValueAt(17)
            Me.lbMoveSPD0_c3 = AxTndNTagRead1.GetValueAt(18)
            Me.lbMoveSPD1_c3 = AxTndNTagRead1.GetValueAt(19)
            Me.lnNumBins_c3 = AxTndNTagRead1.GetValueAt(20)
            Me.lnCurBin_c3 = AxTndNTagRead1.GetValueAt(21)
            Me.lnTgtBin_c3 = AxTndNTagRead1.GetValueAt(22)
            Me.lnStatReg1_c3 = AxTndNTagRead1.GetValueAt(23)
            ' Carousel 4
            Me.lbMoveFWD_c4 = AxTndNTagRead1.GetValueAt(24)
            Me.lbMoveREV_c4 = AxTndNTagRead1.GetValueAt(25)
            Me.lbMoveSPD0_c4 = AxTndNTagRead1.GetValueAt(26)
            Me.lbMoveSPD1_c4 = AxTndNTagRead1.GetValueAt(27)
            Me.lnNumBins_c4 = AxTndNTagRead1.GetValueAt(28)
            Me.lnCurBin_c4 = AxTndNTagRead1.GetValueAt(29)
            Me.lnTgtBin_c4 = AxTndNTagRead1.GetValueAt(30)
            Me.lnStatReg1_c4 = AxTndNTagRead1.GetValueAt(31)
            ' VFDs
            Me.lnVFDRunStat_c1 = AxTndNTagRead1.GetValueAt(32)
            Me.lnVFDRunStat_c2 = AxTndNTagRead1.GetValueAt(33)
            Me.lnVFDRunStat_c3 = AxTndNTagRead1.GetValueAt(34)
            Me.lnVFDRunStat_c4 = AxTndNTagRead1.GetValueAt(35)
            Me.lnVFDFaultStat_c1 = AxTndNTagRead1.GetValueAt(36)
            Me.lnVFDFaultStat_c2 = AxTndNTagRead1.GetValueAt(37)
            Me.lnVFDFaultStat_c3 = AxTndNTagRead1.GetValueAt(38)
            Me.lnVFDFaultStat_c4 = AxTndNTagRead1.GetValueAt(39)

            ' Update Form
            ' Carousel 1
            Me.txtNumBins_c1.Text = Me.lnNumBins_c1
            Me.txtCurrentBin_c1.Text = Me.lnCurBin_c1
            If Me.lnTgtBin_c1 <> 0 Then Me.txtTargetBin_c1.Text = Me.lnTgtBin_c1 Else Me.txtTargetBin_c1.Text = Me.lnNumBins_c1
            Me.txtStatReg1_c1.Text = Me.lnStatReg1_c1
            ' Carousel 2
            Me.txtNumBins_c2.Text = Me.lnNumBins_c2
            Me.txtCurrentBin_c2.Text = Me.lnCurBin_c2
            If Me.lnTgtBin_c2 <> 0 Then Me.txtTargetBin_c2.Text = Me.lnTgtBin_c2 Else Me.txtTargetBin_c2.Text = Me.lnNumBins_c2
            Me.txtStatReg1_c2.Text = Me.lnStatReg1_c2
            ' Carousel 3
            Me.txtNumBins_c3.Text = Me.lnNumBins_c3
            Me.txtCurrentBin_c3.Text = Me.lnCurBin_c3
            If Me.lnTgtBin_c3 <> 0 Then Me.txtTargetBin_c3.Text = Me.lnTgtBin_c3 Else Me.txtTargetBin_c3.Text = Me.lnNumBins_c3
            Me.txtStatReg1_c3.Text = Me.lnStatReg1_c3
            ' Carousel 4
            Me.txtNumBins_c4.Text = Me.lnNumBins_c4
            Me.txtCurrentBin_c4.Text = Me.lnCurBin_c4
            If Me.lnTgtBin_c4 <> 0 Then Me.txtTargetBin_c4.Text = Me.lnTgtBin_c4 Else Me.txtTargetBin_c4.Text = Me.lnNumBins_c4
            Me.txtStatReg1_c4.Text = Me.lnStatReg1_c4

            ' Breakout Status Register 1
            ' Carousel 1
            Me.lbSR1_Enabled_c1 = Me.lnStatReg1_c1 And 2 ^ 0
            Me.lbSR1_Move_c1 = Me.lnStatReg1_c1 And 2 ^ 1
            Me.lbSR1_Moving_c1 = Me.lnStatReg1_c1 And 2 ^ 2
            Me.lbSR1_CW1_CCW0_c1 = Me.lnStatReg1_c1 And 2 ^ 3
            Me.lbSR1_ManualMode_c1 = Me.lnStatReg1_c1 And 2 ^ 4
            Me.lbSR1_EncoderSetup_c1 = Me.lnStatReg1_c1 And 2 ^ 5
            Me.lbSR1_Homing_c1 = Me.lnStatReg1_c1 And 2 ^ 6
            Me.lbSR1_AutoControl_c1 = Me.lnStatReg1_c1 And 2 ^ 7
            Me.lbSR1_VFD_c1 = Me.lnStatReg1_c1 And 2 ^ 8
            Me.lbSR1_SafetyCkt_c1 = Me.lnStatReg1_c1 And 2 ^ 9
            Me.lbSR1_Ready_c1 = Me.lnStatReg1_c1 And 2 ^ 10
            ' Carousel 2
            Me.lbSR1_Enabled_c2 = Me.lnStatReg1_c2 And 2 ^ 0
            Me.lbSR1_Move_c2 = Me.lnStatReg1_c2 And 2 ^ 1
            Me.lbSR1_Moving_c2 = Me.lnStatReg1_c2 And 2 ^ 2
            Me.lbSR1_CW1_CCW0_c2 = Me.lnStatReg1_c2 And 2 ^ 3
            Me.lbSR1_ManualMode_c2 = Me.lnStatReg1_c2 And 2 ^ 4
            Me.lbSR1_EncoderSetup_c2 = Me.lnStatReg1_c2 And 2 ^ 5
            Me.lbSR1_Homing_c2 = Me.lnStatReg1_c2 And 2 ^ 6
            Me.lbSR1_AutoControl_c2 = Me.lnStatReg1_c2 And 2 ^ 7
            Me.lbSR1_VFD_c2 = Me.lnStatReg1_c2 And 2 ^ 8
            Me.lbSR1_SafetyCkt_c2 = Me.lnStatReg1_c2 And 2 ^ 9
            Me.lbSR1_Ready_c2 = Me.lnStatReg1_c2 And 2 ^ 10
            ' Carousel 3
            Me.lbSR1_Enabled_c3 = Me.lnStatReg1_c3 And 2 ^ 0
            Me.lbSR1_Move_c3 = Me.lnStatReg1_c3 And 2 ^ 1
            Me.lbSR1_Moving_c3 = Me.lnStatReg1_c3 And 2 ^ 2
            Me.lbSR1_CW1_CCW0_c3 = Me.lnStatReg1_c3 And 2 ^ 3
            Me.lbSR1_ManualMode_c3 = Me.lnStatReg1_c3 And 2 ^ 4
            Me.lbSR1_EncoderSetup_c3 = Me.lnStatReg1_c3 And 2 ^ 5
            Me.lbSR1_Homing_c3 = Me.lnStatReg1_c3 And 2 ^ 6
            Me.lbSR1_AutoControl_c3 = Me.lnStatReg1_c3 And 2 ^ 7
            Me.lbSR1_VFD_c3 = Me.lnStatReg1_c3 And 2 ^ 8
            Me.lbSR1_SafetyCkt_c3 = Me.lnStatReg1_c3 And 2 ^ 9
            Me.lbSR1_Ready_c3 = Me.lnStatReg1_c3 And 2 ^ 10
            ' Carousel 4
            Me.lbSR1_Enabled_c4 = Me.lnStatReg1_c4 And 2 ^ 0
            Me.lbSR1_Move_c4 = Me.lnStatReg1_c4 And 2 ^ 1
            Me.lbSR1_Moving_c4 = Me.lnStatReg1_c4 And 2 ^ 2
            Me.lbSR1_CW1_CCW0_c4 = Me.lnStatReg1_c4 And 2 ^ 3
            Me.lbSR1_ManualMode_c4 = Me.lnStatReg1_c4 And 2 ^ 4
            Me.lbSR1_EncoderSetup_c4 = Me.lnStatReg1_c4 And 2 ^ 5
            Me.lbSR1_Homing_c4 = Me.lnStatReg1_c4 And 2 ^ 6
            Me.lbSR1_AutoControl_c4 = Me.lnStatReg1_c4 And 2 ^ 7
            Me.lbSR1_VFD_c4 = Me.lnStatReg1_c4 And 2 ^ 8
            Me.lbSR1_SafetyCkt_c4 = Me.lnStatReg1_c4 And 2 ^ 9
            Me.lbSR1_Ready_c4 = Me.lnStatReg1_c4 And 2 ^ 10

        Else
            ' Carousel 1
            Me.txtNumBins_c1.Text = "?"
            Me.txtCurrentBin_c1.Text = "?"
            Me.txtTargetBin_c1.Text = "?"
            Me.txtStatReg1_c1.Text = "?"
            Me.lbSR1_Enabled_c1 = False
            Me.lbSR1_Move_c1 = False
            Me.lbSR1_Moving_c1 = False
            Me.lbSR1_CW1_CCW0_c1 = False
            Me.lbSR1_ManualMode_c1 = False
            Me.lbSR1_EncoderSetup_c1 = False
            Me.lbSR1_Homing_c1 = False
            Me.lbSR1_AutoControl_c1 = False
            Me.lbSR1_VFD_c1 = False
            Me.lbSR1_SafetyCkt_c1 = False
            Me.lbSR1_Ready_c1 = False
            Me.lbMoveFWD_c1 = False
            Me.lbMoveREV_c1 = False
            Me.lbMoveSPD0_c1 = False
            Me.lbMoveSPD1_c1 = False
            ' Carousel 2
            Me.txtNumBins_c2.Text = "?"
            Me.txtCurrentBin_c2.Text = "?"
            Me.txtTargetBin_c2.Text = "?"
            Me.txtStatReg1_c2.Text = "?"
            Me.lbSR1_Enabled_c2 = False
            Me.lbSR1_Move_c2 = False
            Me.lbSR1_Moving_c2 = False
            Me.lbSR1_CW1_CCW0_c2 = False
            Me.lbSR1_ManualMode_c2 = False
            Me.lbSR1_EncoderSetup_c2 = False
            Me.lbSR1_Homing_c2 = False
            Me.lbSR1_AutoControl_c2 = False
            Me.lbSR1_VFD_c2 = False
            Me.lbSR1_SafetyCkt_c2 = False
            Me.lbSR1_Ready_c2 = False
            Me.lbMoveFWD_c2 = False
            Me.lbMoveREV_c2 = False
            Me.lbMoveSPD0_c2 = False
            Me.lbMoveSPD1_c2 = False
            ' Carousel 3
            Me.txtNumBins_c3.Text = "?"
            Me.txtCurrentBin_c3.Text = "?"
            Me.txtTargetBin_c3.Text = "?"
            Me.txtStatReg1_c3.Text = "?"
            Me.lbSR1_Enabled_c3 = False
            Me.lbSR1_Move_c3 = False
            Me.lbSR1_Moving_c3 = False
            Me.lbSR1_CW1_CCW0_c3 = False
            Me.lbSR1_ManualMode_c3 = False
            Me.lbSR1_EncoderSetup_c3 = False
            Me.lbSR1_Homing_c3 = False
            Me.lbSR1_AutoControl_c3 = False
            Me.lbSR1_VFD_c3 = False
            Me.lbSR1_SafetyCkt_c3 = False
            Me.lbSR1_Ready_c3 = False
            Me.lbMoveFWD_c3 = False
            Me.lbMoveREV_c3 = False
            Me.lbMoveSPD0_c3 = False
            Me.lbMoveSPD1_c3 = False
            ' Carousel 4
            Me.txtNumBins_c4.Text = "?"
            Me.txtCurrentBin_c4.Text = "?"
            Me.txtTargetBin_c4.Text = "?"
            Me.txtStatReg1_c4.Text = "?"
            Me.lbSR1_Enabled_c4 = False
            Me.lbSR1_Move_c4 = False
            Me.lbSR1_Moving_c4 = False
            Me.lbSR1_CW1_CCW0_c4 = False
            Me.lbSR1_ManualMode_c4 = False
            Me.lbSR1_EncoderSetup_c4 = False
            Me.lbSR1_Homing_c4 = False
            Me.lbSR1_AutoControl_c4 = False
            Me.lbSR1_VFD_c4 = False
            Me.lbSR1_SafetyCkt_c4 = False
            Me.lbSR1_Ready_c4 = False
            Me.lbMoveFWD_c4 = False
            Me.lbMoveREV_c4 = False
            Me.lbMoveSPD0_c4 = False
            Me.lbMoveSPD1_c4 = False

        End If

        ' Status Register Breakout
        Me.StatReg1Breakout_c1()
        Me.StatReg1Breakout_c2()
        Me.StatReg1Breakout_c3()
        Me.StatReg1Breakout_c4()

        ' Flags
        Me.FlagsBreakout_c1()
        Me.FlagsBreakout_c2()
        Me.FlagsBreakout_c3()
        Me.FlagsBreakout_c4()

        'Manual Mode
        Me.ReadTagsMM_c1()
        Me.ReadTagsMM_c2()
        Me.ReadTagsMM_c3()
        Me.ReadTagsMM_c4()

        ' Button Colors
        Me.ManModeButtonColors_c1()
        Me.ManModeButtonColors_c2()
        Me.ManModeButtonColors_c3()
        Me.ManModeButtonColors_c4()
        Me.JogButtonColors()
        Me.EncoderSetupColors_c1()
        Me.EncoderSetupColors_c2()
        Me.EncoderSetupColors_c3()
        Me.EncoderSetupColors_c4()
        Me.HomingSetupColors_c1()
        Me.HomingSetupColors_c2()
        Me.HomingSetupColors_c3()
        Me.HomingSetupColors_c4()

        ''''''''''''''
        ' Write tags '
        ''''''''''''''
        Dim nrc_w As Short

        ' Heartbeat
        If Me.lnHeartbeat >= (2 ^ 31) - 1 Then
            Me.lnHeartbeat = 0
        Else
            Me.lnHeartbeat = Me.lnHeartbeat + 1
        End If

        ' The requested bin location
        lnReqBin_c1 = Me.lnRequestedBin_c1
        lnReqBin_c2 = Me.lnRequestedBin_c2
        lnReqBin_c3 = Me.lnRequestedBin_c3
        lnReqBin_c4 = Me.lnRequestedBin_c4

        ' Carousel 1
        'StatReg2
        Me.lnStatReg2_c1 = 0
        'Homing
        If Me.lbHomingStart_c1 Then Me.lnStatReg2_c1 += 2 ^ 0
        If Me.lbHomingStop_c1 Then Me.lnStatReg2_c1 += 2 ^ 1
        'Encoder
        If Me.lbEncoderStart_c1 Then Me.lnStatReg2_c1 += 2 ^ 3
        If Me.lbEncoderStop_c1 Then Me.lnStatReg2_c1 += 2 ^ 4
        'Manual mode
        If Me.lbManualMode_c1 Then Me.lnStatReg2_c1 += 2 ^ 5

        ' Carousel 2
        'StatReg2
        Me.lnStatReg2_c2 = 0
        'Homing
        If Me.lbHomingStart_c2 Then Me.lnStatReg2_c2 += 2 ^ 0
        If Me.lbHomingStop_c2 Then Me.lnStatReg2_c2 += 2 ^ 1
        'Encoder
        If Me.lbEncoderStart_c2 Then Me.lnStatReg2_c2 += 2 ^ 3
        If Me.lbEncoderStop_c2 Then Me.lnStatReg2_c2 += 2 ^ 4
        'Manual mode
        If Me.lbManualMode_c2 Then Me.lnStatReg2_c2 += 2 ^ 5

        ' Carousel 3
        'StatReg2
        Me.lnStatReg2_c3 = 0
        'Homing
        If Me.lbHomingStart_c3 Then Me.lnStatReg2_c3 += 2 ^ 0
        If Me.lbHomingStop_c3 Then Me.lnStatReg2_c3 += 2 ^ 1
        'Encoder
        If Me.lbEncoderStart_c3 Then Me.lnStatReg2_c3 += 2 ^ 3
        If Me.lbEncoderStop_c3 Then Me.lnStatReg2_c3 += 2 ^ 4
        'Manual mode
        If Me.lbManualMode_c3 Then Me.lnStatReg2_c3 += 2 ^ 5

        ' Carousel 4
        'StatReg2
        Me.lnStatReg2_c4 = 0
        'Homing
        If Me.lbHomingStart_c4 Then Me.lnStatReg2_c4 += 2 ^ 0
        If Me.lbHomingStop_c4 Then Me.lnStatReg2_c4 += 2 ^ 1
        'Encoder
        If Me.lbEncoderStart_c4 Then Me.lnStatReg2_c4 += 2 ^ 3
        If Me.lbEncoderStop_c4 Then Me.lnStatReg2_c4 += 2 ^ 4
        'Manual mode
        If Me.lbManualMode_c4 Then Me.lnStatReg2_c4 += 2 ^ 5

        If nrc_r = ThinkAndDoSuccess Then
            'All data items in the ocx must be written to.
            Me.AxTndNTagWrite1.UpdateLongValue(0, lnStatReg2_c1)
            Me.AxTndNTagWrite1.UpdateLongValue(1, lnReqBin_c1)
            Me.AxTndNTagWrite1.UpdateLongValue(2, lnStatReg2_c2)
            Me.AxTndNTagWrite1.UpdateLongValue(3, lnReqBin_c2)
            Me.AxTndNTagWrite1.UpdateLongValue(4, lnStatReg2_c3)
            Me.AxTndNTagWrite1.UpdateLongValue(5, lnReqBin_c3)
            Me.AxTndNTagWrite1.UpdateLongValue(6, lnStatReg2_c4)
            Me.AxTndNTagWrite1.UpdateLongValue(7, lnReqBin_c4)
            Me.AxTndNTagWrite1.UpdateLongValue(8, lnHeartbeat)
            Me.AxTndNTagWrite1.UpdateLongValue(9, lnSetBinPos_c1)
            Me.AxTndNTagWrite1.UpdateLongValue(10, lnSetBinPos_c2)
            Me.AxTndNTagWrite1.UpdateLongValue(11, lnSetBinPos_c3)
            Me.AxTndNTagWrite1.UpdateLongValue(12, lnSetBinPos_c4)
            nrc_w = Me.AxTndNTagWrite1.Write()
            Me.lnTndNTagWrite1Stat = nrc_w
            If nrc_w = ThinkAndDoSuccess Then
                ' Success
                'Manual Mode
                Me.WriteTagsMM_c1()
                Me.WriteTagsMM_c2()
                Me.WriteTagsMM_c3()
                Me.WriteTagsMM_c4()

                Me.tmrTnDNTag1.Enabled = True
            Else
                ' Failure
            End If
        End If

    End Sub

    Private Sub tmrObserver_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrObserver.Tick

        'Homing check
        Me.Homingcheck_c1()
        Me.Homingcheck_c2()
        Me.Homingcheck_c3()
        Me.Homingcheck_c4()

        'Encoder check
        Me.EncoderCheck_c1()
        Me.EncoderCheck_c2()
        Me.EncoderCheck_c3()
        Me.EncoderCheck_c4()

        'Errors
        If Me.lbConrtollerInitError Or _
        Me.lnTndNTagRead1Stat <> ThinkAndDoSuccess Or _
        Me.lnTndNTagWrite1Stat <> ThinkAndDoSuccess Or _
        Me.lnTndNTagReadMM1Stat_c1 <> ThinkAndDoSuccess Or _
        Me.lnTndNTagWriteMM4Stat_c1 <> ThinkAndDoSuccess Or _
        Me.lnTndNTagReadMM1Stat_c2 <> ThinkAndDoSuccess Or _
        Me.lnTndNTagWriteMM4Stat_c2 <> ThinkAndDoSuccess Or _
        Me.lnTndNTagReadMM1Stat_c3 <> ThinkAndDoSuccess Or _
        Me.lnTndNTagWriteMM4Stat_c3 <> ThinkAndDoSuccess Or _
        Me.lnTndNTagReadMM1Stat_c4 <> ThinkAndDoSuccess Or _
        Me.lnTndNTagWriteMM4Stat_c4 <> ThinkAndDoSuccess _
        Then
            Me.lblCCFE.Visible = True
        Else
            Me.lblCCFE.Visible = False
        End If

        ' Man Mode State
        Dim lbNotReady As Boolean
        lbNotReady = Not Me.lbSR1_Enabled_c1 Or Not Me.lbSR1_Ready_c1 Or Not Me.lbSR1_AutoControl_c1
        If Me.lbManualMode_c1 And lbNotReady Then
            Me.lbManualMode_c1 = False
            Me.chkManMode_c1.Checked = False
            Me.StopMM_c1()
        End If

    End Sub

    Private Sub Homingcheck_c1()
        If Me.lbHomingStart_c1 = True And Me.tmrHomingStart_c1.Enabled = False Then
            Me.tmrHomingStart_c1.Enabled = True
            Me.lnRequestedBin_c1 = 0
        End If
        If Me.lbHomingStop_c1 = True And Me.tmrHomingStop_c1.Enabled = False Then
            Me.tmrHomingStop_c1.Enabled = True
            Me.lnRequestedBin_c1 = 0
        End If
    End Sub

    Private Sub Homingcheck_c2()
        If Me.lbHomingStart_c2 = True And Me.tmrHomingStart_c2.Enabled = False Then
            Me.tmrHomingStart_c2.Enabled = True
            Me.lnRequestedBin_c2 = 0
        End If
        If Me.lbHomingStop_c2 = True And Me.tmrHomingStop_c2.Enabled = False Then
            Me.tmrHomingStop_c2.Enabled = True
            Me.lnRequestedBin_c2 = 0
        End If
    End Sub

    Private Sub Homingcheck_c3()
        If Me.lbHomingStart_c3 = True And Me.tmrHomingStart_c3.Enabled = False Then
            Me.tmrHomingStart_c3.Enabled = True
            Me.lnRequestedBin_c3 = 0
        End If
        If Me.lbHomingStop_c3 = True And Me.tmrHomingStop_c3.Enabled = False Then
            Me.tmrHomingStop_c3.Enabled = True
            Me.lnRequestedBin_c3 = 0
        End If
    End Sub

    Private Sub Homingcheck_c4()
        If Me.lbHomingStart_c4 = True And Me.tmrHomingStart_c4.Enabled = False Then
            Me.tmrHomingStart_c4.Enabled = True
            Me.lnRequestedBin_c4 = 0
        End If
        If Me.lbHomingStop_c4 = True And Me.tmrHomingStop_c4.Enabled = False Then
            Me.tmrHomingStop_c4.Enabled = True
            Me.lnRequestedBin_c4 = 0
        End If
    End Sub

    Private Sub EncoderCheck_c1()
        'Encoder setup check
        If Me.lbEncoderStart_c1 = True And Me.tmrEncoderStart_c1.Enabled = False Then
            Me.tmrEncoderStart_c1.Enabled = True
            Me.lnRequestedBin_c1 = 0
        End If
        If Me.lbEncoderStop_c1 = True And Me.tmrEncoderStop_c1.Enabled = False Then
            Me.tmrEncoderStop_c1.Enabled = True
            Me.lnRequestedBin_c1 = 0
        End If

    End Sub

    Private Sub EncoderCheck_c2()
        'Encoder setup check
        If Me.lbEncoderStart_c2 = True And Me.tmrEncoderStart_c2.Enabled = False Then
            Me.tmrEncoderStart_c2.Enabled = True
            Me.lnRequestedBin_c2 = 0
        End If
        If Me.lbEncoderStop_c2 = True And Me.tmrEncoderStop_c2.Enabled = False Then
            Me.tmrEncoderStop_c2.Enabled = True
            Me.lnRequestedBin_c2 = 0
        End If

    End Sub

    Private Sub EncoderCheck_c3()
        'Encoder setup check
        If Me.lbEncoderStart_c3 = True And Me.tmrEncoderStart_c3.Enabled = False Then
            Me.tmrEncoderStart_c3.Enabled = True
            Me.lnRequestedBin_c3 = 0
        End If
        If Me.lbEncoderStop_c3 = True And Me.tmrEncoderStop_c3.Enabled = False Then
            Me.tmrEncoderStop_c3.Enabled = True
            Me.lnRequestedBin_c3 = 0
        End If

    End Sub

    Private Sub EncoderCheck_c4()
        'Encoder setup check
        If Me.lbEncoderStart_c4 = True And Me.tmrEncoderStart_c4.Enabled = False Then
            Me.tmrEncoderStart_c4.Enabled = True
            Me.lnRequestedBin_c4 = 0
        End If
        If Me.lbEncoderStop_c4 = True And Me.tmrEncoderStop_c4.Enabled = False Then
            Me.tmrEncoderStop_c4.Enabled = True
            Me.lnRequestedBin_c4 = 0
        End If

    End Sub

    Private Sub StatReg1Breakout_c1()
        If Me.lbSR1_Enabled_c1 Then Me.lblSR1_0_c1.BackColor = Color.Goldenrod Else Me.lblSR1_0_c1.BackColor = Color.Transparent
        If Me.lbSR1_Move_c1 Then Me.lblSR1_1_c1.BackColor = Color.Goldenrod Else Me.lblSR1_1_c1.BackColor = Color.Transparent
        If Me.lbSR1_Moving_c1 Then Me.lblSR1_2_c1.BackColor = Color.Goldenrod Else Me.lblSR1_2_c1.BackColor = Color.Transparent
        If Me.lbSR1_CW1_CCW0_c1 Then Me.lblSR1_3_c1.BackColor = Color.Goldenrod Else Me.lblSR1_3_c1.BackColor = Color.Transparent
        If Me.lbSR1_ManualMode_c1 Then Me.lblSR1_4_c1.BackColor = Color.Goldenrod Else Me.lblSR1_4_c1.BackColor = Color.Transparent
        If Me.lbSR1_EncoderSetup_c1 Then Me.lblSR1_5_c1.BackColor = Color.Goldenrod Else Me.lblSR1_5_c1.BackColor = Color.Transparent
        If Me.lbSR1_Homing_c1 Then Me.lblSR1_6_c1.BackColor = Color.Goldenrod Else Me.lblSR1_6_c1.BackColor = Color.Transparent
        If Me.lbSR1_AutoControl_c1 Then Me.lblSR1_7_c1.BackColor = Color.Goldenrod Else Me.lblSR1_7_c1.BackColor = Color.Transparent
        If Me.lbSR1_VFD_c1 Then Me.lblSR1_8_c1.BackColor = Color.Goldenrod Else Me.lblSR1_8_c1.BackColor = Color.Transparent
        If Me.lbSR1_SafetyCkt_c1 Then Me.lblSR1_9_c1.BackColor = Color.Goldenrod Else Me.lblSR1_9_c1.BackColor = Color.Transparent
        If Me.lbSR1_Ready_c1 Then Me.lblSR1_10_c1.BackColor = Color.Goldenrod Else Me.lblSR1_10_c1.BackColor = Color.Transparent
    End Sub

    Private Sub StatReg1Breakout_c2()
        If Me.lbSR1_Enabled_c2 Then Me.lblSR1_0_c2.BackColor = Color.Goldenrod Else Me.lblSR1_0_c2.BackColor = Color.Transparent
        If Me.lbSR1_Move_c2 Then Me.lblSR1_1_c2.BackColor = Color.Goldenrod Else Me.lblSR1_1_c2.BackColor = Color.Transparent
        If Me.lbSR1_Moving_c2 Then Me.lblSR1_2_c2.BackColor = Color.Goldenrod Else Me.lblSR1_2_c2.BackColor = Color.Transparent
        If Me.lbSR1_CW1_CCW0_c2 Then Me.lblSR1_3_c2.BackColor = Color.Goldenrod Else Me.lblSR1_3_c2.BackColor = Color.Transparent
        If Me.lbSR1_ManualMode_c2 Then Me.lblSR1_4_c2.BackColor = Color.Goldenrod Else Me.lblSR1_4_c2.BackColor = Color.Transparent
        If Me.lbSR1_EncoderSetup_c2 Then Me.lblSR1_5_c2.BackColor = Color.Goldenrod Else Me.lblSR1_5_c2.BackColor = Color.Transparent
        If Me.lbSR1_Homing_c2 Then Me.lblSR1_6_c2.BackColor = Color.Goldenrod Else Me.lblSR1_6_c2.BackColor = Color.Transparent
        If Me.lbSR1_AutoControl_c2 Then Me.lblSR1_7_c2.BackColor = Color.Goldenrod Else Me.lblSR1_7_c2.BackColor = Color.Transparent
        If Me.lbSR1_VFD_c2 Then Me.lblSR1_8_c2.BackColor = Color.Goldenrod Else Me.lblSR1_8_c2.BackColor = Color.Transparent
        If Me.lbSR1_SafetyCkt_c2 Then Me.lblSR1_9_c2.BackColor = Color.Goldenrod Else Me.lblSR1_9_c2.BackColor = Color.Transparent
        If Me.lbSR1_Ready_c2 Then Me.lblSR1_10_c2.BackColor = Color.Goldenrod Else Me.lblSR1_10_c2.BackColor = Color.Transparent
    End Sub

    Private Sub StatReg1Breakout_c3()
        If Me.lbSR1_Enabled_c3 Then Me.lblSR1_0_c3.BackColor = Color.Goldenrod Else Me.lblSR1_0_c3.BackColor = Color.Transparent
        If Me.lbSR1_Move_c3 Then Me.lblSR1_1_c3.BackColor = Color.Goldenrod Else Me.lblSR1_1_c3.BackColor = Color.Transparent
        If Me.lbSR1_Moving_c3 Then Me.lblSR1_2_c3.BackColor = Color.Goldenrod Else Me.lblSR1_2_c3.BackColor = Color.Transparent
        If Me.lbSR1_CW1_CCW0_c3 Then Me.lblSR1_3_c3.BackColor = Color.Goldenrod Else Me.lblSR1_3_c3.BackColor = Color.Transparent
        If Me.lbSR1_ManualMode_c3 Then Me.lblSR1_4_c3.BackColor = Color.Goldenrod Else Me.lblSR1_4_c3.BackColor = Color.Transparent
        If Me.lbSR1_EncoderSetup_c3 Then Me.lblSR1_5_c3.BackColor = Color.Goldenrod Else Me.lblSR1_5_c3.BackColor = Color.Transparent
        If Me.lbSR1_Homing_c3 Then Me.lblSR1_6_c3.BackColor = Color.Goldenrod Else Me.lblSR1_6_c3.BackColor = Color.Transparent
        If Me.lbSR1_AutoControl_c3 Then Me.lblSR1_7_c3.BackColor = Color.Goldenrod Else Me.lblSR1_7_c3.BackColor = Color.Transparent
        If Me.lbSR1_VFD_c3 Then Me.lblSR1_8_c3.BackColor = Color.Goldenrod Else Me.lblSR1_8_c3.BackColor = Color.Transparent
        If Me.lbSR1_SafetyCkt_c3 Then Me.lblSR1_9_c3.BackColor = Color.Goldenrod Else Me.lblSR1_9_c3.BackColor = Color.Transparent
        If Me.lbSR1_Ready_c3 Then Me.lblSR1_10_c3.BackColor = Color.Goldenrod Else Me.lblSR1_10_c3.BackColor = Color.Transparent
    End Sub

    Private Sub StatReg1Breakout_c4()
        If Me.lbSR1_Enabled_c4 Then Me.lblSR1_0_c4.BackColor = Color.Goldenrod Else Me.lblSR1_0_c4.BackColor = Color.Transparent
        If Me.lbSR1_Move_c4 Then Me.lblSR1_1_c4.BackColor = Color.Goldenrod Else Me.lblSR1_1_c4.BackColor = Color.Transparent
        If Me.lbSR1_Moving_c4 Then Me.lblSR1_2_c4.BackColor = Color.Goldenrod Else Me.lblSR1_2_c4.BackColor = Color.Transparent
        If Me.lbSR1_CW1_CCW0_c4 Then Me.lblSR1_3_c4.BackColor = Color.Goldenrod Else Me.lblSR1_3_c4.BackColor = Color.Transparent
        If Me.lbSR1_ManualMode_c4 Then Me.lblSR1_4_c4.BackColor = Color.Goldenrod Else Me.lblSR1_4_c4.BackColor = Color.Transparent
        If Me.lbSR1_EncoderSetup_c4 Then Me.lblSR1_5_c4.BackColor = Color.Goldenrod Else Me.lblSR1_5_c4.BackColor = Color.Transparent
        If Me.lbSR1_Homing_c4 Then Me.lblSR1_6_c4.BackColor = Color.Goldenrod Else Me.lblSR1_6_c4.BackColor = Color.Transparent
        If Me.lbSR1_AutoControl_c4 Then Me.lblSR1_7_c4.BackColor = Color.Goldenrod Else Me.lblSR1_7_c4.BackColor = Color.Transparent
        If Me.lbSR1_VFD_c4 Then Me.lblSR1_8_c4.BackColor = Color.Goldenrod Else Me.lblSR1_8_c4.BackColor = Color.Transparent
        If Me.lbSR1_SafetyCkt_c4 Then Me.lblSR1_9_c4.BackColor = Color.Goldenrod Else Me.lblSR1_9_c4.BackColor = Color.Transparent
        If Me.lbSR1_Ready_c4 Then Me.lblSR1_10_c4.BackColor = Color.Goldenrod Else Me.lblSR1_10_c4.BackColor = Color.Transparent
    End Sub

    Private Sub FlagsBreakout_c1()
        If Me.lbMoveFWD_c1 Then Me.lblMoveFWD_c1.BackColor = Color.Goldenrod Else Me.lblMoveFWD_c1.BackColor = Color.Transparent
        If Me.lbMoveREV_c1 Then Me.lblMoveREV_c1.BackColor = Color.Goldenrod Else Me.lblMoveREV_c1.BackColor = Color.Transparent
        If Me.lbMoveSPD0_c1 Then Me.lblMoveSPD0_c1.BackColor = Color.Goldenrod Else Me.lblMoveSPD0_c1.BackColor = Color.Transparent
        If Me.lbMoveSPD1_c1 Then Me.lblMoveSPD1_c1.BackColor = Color.Goldenrod Else Me.lblMoveSPD1_c1.BackColor = Color.Transparent
    End Sub

    Private Sub FlagsBreakout_c2()
        If Me.lbMoveFWD_c2 Then Me.lblMoveFWD_c2.BackColor = Color.Goldenrod Else Me.lblMoveFWD_c2.BackColor = Color.Transparent
        If Me.lbMoveREV_c2 Then Me.lblMoveREV_c2.BackColor = Color.Goldenrod Else Me.lblMoveREV_c2.BackColor = Color.Transparent
        If Me.lbMoveSPD0_c2 Then Me.lblMoveSPD0_c2.BackColor = Color.Goldenrod Else Me.lblMoveSPD0_c2.BackColor = Color.Transparent
        If Me.lbMoveSPD1_c2 Then Me.lblMoveSPD1_c2.BackColor = Color.Goldenrod Else Me.lblMoveSPD1_c2.BackColor = Color.Transparent
    End Sub

    Private Sub FlagsBreakout_c3()
        If Me.lbMoveFWD_c3 Then Me.lblMoveFWD_c3.BackColor = Color.Goldenrod Else Me.lblMoveFWD_c3.BackColor = Color.Transparent
        If Me.lbMoveREV_c3 Then Me.lblMoveREV_c3.BackColor = Color.Goldenrod Else Me.lblMoveREV_c3.BackColor = Color.Transparent
        If Me.lbMoveSPD0_c3 Then Me.lblMoveSPD0_c3.BackColor = Color.Goldenrod Else Me.lblMoveSPD0_c3.BackColor = Color.Transparent
        If Me.lbMoveSPD1_c3 Then Me.lblMoveSPD1_c3.BackColor = Color.Goldenrod Else Me.lblMoveSPD1_c3.BackColor = Color.Transparent
    End Sub

    Private Sub FlagsBreakout_c4()
        If Me.lbMoveFWD_c4 Then Me.lblMoveFWD_c4.BackColor = Color.Goldenrod Else Me.lblMoveFWD_c4.BackColor = Color.Transparent
        If Me.lbMoveREV_c4 Then Me.lblMoveREV_c4.BackColor = Color.Goldenrod Else Me.lblMoveREV_c4.BackColor = Color.Transparent
        If Me.lbMoveSPD0_c4 Then Me.lblMoveSPD0_c4.BackColor = Color.Goldenrod Else Me.lblMoveSPD0_c4.BackColor = Color.Transparent
        If Me.lbMoveSPD1_c4 Then Me.lblMoveSPD1_c4.BackColor = Color.Goldenrod Else Me.lblMoveSPD1_c4.BackColor = Color.Transparent
    End Sub

    Private Sub ManModeButtonColors_c1()
        If Me.lbFWD_c1 Then Me.btnFWD_c1.BackColor = Color.Lime Else Me.btnFWD_c1.UseVisualStyleBackColor = True
        If Me.lbREV_c1 Then Me.btnREV_c1.BackColor = Color.Lime Else Me.btnREV_c1.UseVisualStyleBackColor = True
        If Me.lbSTOP_c1 Then Me.btnSTOP_c1.BackColor = Color.Red Else Me.btnSTOP_c1.UseVisualStyleBackColor = True

        If Me.lbSR1_Homing_c1 And Me.lbHomingStartLatch_c1 Then Me.btnHomingStart_c1.BackColor = Color.Lime Else Me.btnHomingStart_c1.UseVisualStyleBackColor = True
        'If Me.lbHomingStop_c1 Or (Not Me.lbHomingStartLatch_c1 And Me.lbSR1_Homing_c1) Then Me.btnHomingStop_c1.BackColor = Color.Red Else Me.btnHomingStop_c1.UseVisualStyleBackColor = True
    End Sub

    Private Sub ManModeButtonColors_c2()
        If Me.lbFWD_c2 Then Me.btnFWD_c2.BackColor = Color.Lime Else Me.btnFWD_c2.UseVisualStyleBackColor = True
        If Me.lbREV_c2 Then Me.btnREV_c2.BackColor = Color.Lime Else Me.btnREV_c2.UseVisualStyleBackColor = True
        If Me.lbSTOP_c2 Then Me.btnSTOP_c2.BackColor = Color.Red Else Me.btnSTOP_c2.UseVisualStyleBackColor = True

        If Me.lbSR1_Homing_c2 And Me.lbHomingStartLatch_c2 Then Me.btnHomingStart_c2.BackColor = Color.Lime Else Me.btnHomingStart_c2.UseVisualStyleBackColor = True
        'If Me.lbHomingStop_c2 Or (Not Me.lbHomingStartLatch_c2 And Me.lbSR1_Homing_c2) Then Me.btnHomingStop_c2.BackColor = Color.Red Else Me.btnHomingStop_c2.UseVisualStyleBackColor = True
    End Sub

    Private Sub ManModeButtonColors_c3()
        If Me.lbFWD_c3 Then Me.btnFWD_c3.BackColor = Color.Lime Else Me.btnFWD_c3.UseVisualStyleBackColor = True
        If Me.lbREV_c3 Then Me.btnREV_c3.BackColor = Color.Lime Else Me.btnREV_c3.UseVisualStyleBackColor = True
        If Me.lbSTOP_c3 Then Me.btnSTOP_c3.BackColor = Color.Red Else Me.btnSTOP_c3.UseVisualStyleBackColor = True

        If Me.lbSR1_Homing_c3 And Me.lbHomingStartLatch_c3 Then Me.btnHomingStart_c3.BackColor = Color.Lime Else Me.btnHomingStart_c3.UseVisualStyleBackColor = True
        'If Me.lbHomingStop_c3 Or (Not Me.lbHomingStartLatch_c3 And Me.lbSR1_Homing_c3) Then Me.btnHomingStop_c3.BackColor = Color.Red Else Me.btnHomingStop_c3.UseVisualStyleBackColor = True
    End Sub

    Private Sub ManModeButtonColors_c4()
        If Me.lbFWD_c4 Then Me.btnFWD_c4.BackColor = Color.Lime Else Me.btnFWD_c4.UseVisualStyleBackColor = True
        If Me.lbREV_c4 Then Me.btnREV_c4.BackColor = Color.Lime Else Me.btnREV_c4.UseVisualStyleBackColor = True
        If Me.lbSTOP_c4 Then Me.btnSTOP_c4.BackColor = Color.Red Else Me.btnSTOP_c4.UseVisualStyleBackColor = True

        If Me.lbSR1_Homing_c4 And Me.lbHomingStartLatch_c4 Then Me.btnHomingStart_c4.BackColor = Color.Lime Else Me.btnHomingStart_c4.UseVisualStyleBackColor = True
        'If Me.lbHomingStop_c4 Or (Not Me.lbHomingStartLatch_c4 And Me.lbSR1_Homing_c4) Then Me.btnHomingStop_c4.BackColor = Color.Red Else Me.btnHomingStop_c4.UseVisualStyleBackColor = True
    End Sub

    Private Sub JogButtonColors()
        'Carousel 1
        If Me.lbJogF_c1 Then Me.btnJogF_c1.BackColor = Color.Lime Else Me.btnJogF_c1.UseVisualStyleBackColor = True
        If Me.lbJogR_c1 Then Me.btnJogR_c1.BackColor = Color.Lime Else Me.btnJogR_c1.UseVisualStyleBackColor = True
        'Carousel 2
        If Me.lbJogF_c2 Then Me.btnJogF_c2.BackColor = Color.Lime Else Me.btnJogF_c2.UseVisualStyleBackColor = True
        If Me.lbJogR_c2 Then Me.btnJogR_c2.BackColor = Color.Lime Else Me.btnJogR_c2.UseVisualStyleBackColor = True
        'Carousel 3
        If Me.lbJogF_c3 Then Me.btnJogF_c3.BackColor = Color.Lime Else Me.btnJogF_c3.UseVisualStyleBackColor = True
        If Me.lbJogR_c3 Then Me.btnJogR_c3.BackColor = Color.Lime Else Me.btnJogR_c3.UseVisualStyleBackColor = True
        'Carousel 4
        If Me.lbJogF_c4 Then Me.btnJogF_c4.BackColor = Color.Lime Else Me.btnJogF_c4.UseVisualStyleBackColor = True
        If Me.lbJogR_c4 Then Me.btnJogR_c4.BackColor = Color.Lime Else Me.btnJogR_c4.UseVisualStyleBackColor = True
    End Sub

    Private Sub btnRetrieve_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve_c1.Click
        ' Request the carousel to move to the bin entered in the text box.
        Me.RetrievePart_c1()
    End Sub

    Private Sub RetrievePart_c1()
        Dim lbError As Boolean
        lbError = Not Me.lbSR1_Enabled_c1 Or Not Me.lbSR1_Ready_c1 Or Me.lbSR1_ManualMode_c1 Or Me.lbSR1_Homing_c1 Or Me.lbSR1_EncoderSetup_c1

        If Val(Me.txtReqBin_c1.Text) <= 0 Or Val(Me.txtReqBin_c1.Text) > Me.lnNumBins_c1 Then
            MsgBox("Location is out of bounds.", MsgBoxStyle.Exclamation, "Movement Error")
            Me.txtReqBin_c1.Text = "0"
            Me.lnRequestedBin_c1 = 0
        ElseIf lbError Then
            MsgBox("Carousel is not ready for move.", MsgBoxStyle.Exclamation, "Attention")
        Else
            ' Sets the value of the requested bin and starts a timer that when timed out will reset the value.
            Me.lnRequestedBin_c1 = Val(Me.txtReqBin_c1.Text)
            Me.tmrReqBin_c1.Enabled = True
        End If
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub btnRetrieve_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve_c2.Click
        ' Request the carousel to move to the bin entered in the text box.
        Me.RetrievePart_c2()
    End Sub

    Private Sub RetrievePart_c2()
        Dim lbError As Boolean
        lbError = Not Me.lbSR1_Enabled_c2 Or Not Me.lbSR1_Ready_c2 Or Me.lbSR1_ManualMode_c2 Or Me.lbSR1_Homing_c2 Or Me.lbSR1_EncoderSetup_c2

        If Val(Me.txtReqBin_c2.Text) <= 0 Or Val(Me.txtReqBin_c2.Text) > Me.lnNumBins_c2 Then
            MsgBox("Location is out of bounds.", MsgBoxStyle.Exclamation, "Movement Error")
            Me.txtReqBin_c2.Text = "0"
            Me.lnRequestedBin_c2 = 0
        ElseIf lbError Then
            MsgBox("Carousel is not ready for move.", MsgBoxStyle.Exclamation, "Attention")
        Else
            ' Sets the value of the requested bin and starts a timer that when timed out will reset the value.
            Me.lnRequestedBin_c2 = Val(Me.txtReqBin_c2.Text)
            Me.tmrReqBin_c2.Enabled = True
        End If
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub btnRetrieve_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve_c3.Click
        ' Request the carousel to move to the bin entered in the text box.
        Me.RetrievePart_c3()
    End Sub

    Private Sub RetrievePart_c3()
        Dim lbError As Boolean
        lbError = Not Me.lbSR1_Enabled_c3 Or Not Me.lbSR1_Ready_c3 Or Me.lbSR1_ManualMode_c3 Or Me.lbSR1_Homing_c3 Or Me.lbSR1_EncoderSetup_c3

        If Val(Me.txtReqBin_c3.Text) <= 0 Or Val(Me.txtReqBin_c3.Text) > Me.lnNumBins_c3 Then
            MsgBox("Location is out of bounds.", MsgBoxStyle.Exclamation, "Movement Error")
            Me.txtReqBin_c3.Text = "0"
            Me.lnRequestedBin_c3 = 0
        ElseIf lbError Then
            MsgBox("Carousel is not ready for move.", MsgBoxStyle.Exclamation, "Attention")
        Else
            ' Sets the value of the requested bin and starts a timer that when timed out will reset the value.
            Me.lnRequestedBin_c3 = Val(Me.txtReqBin_c3.Text)
            Me.tmrReqBin_c3.Enabled = True
        End If
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub btnRetrieve_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetrieve_c4.Click
        ' Request the carousel to move to the bin entered in the text box.
        Me.RetrievePart_c4()
    End Sub

    Private Sub RetrievePart_c4()
        Dim lbError As Boolean
        lbError = Not Me.lbSR1_Enabled_c4 Or Not Me.lbSR1_Ready_c4 Or Me.lbSR1_ManualMode_c4 Or Me.lbSR1_Homing_c4 Or Me.lbSR1_EncoderSetup_c4

        If Val(Me.txtReqBin_c4.Text) <= 0 Or Val(Me.txtReqBin_c4.Text) > Me.lnNumBins_c4 Then
            MsgBox("Location is out of bounds.", MsgBoxStyle.Exclamation, "Movement Error")
            Me.txtReqBin_c4.Text = "0"
            Me.lnRequestedBin_c4 = 0
        ElseIf lbError Then
            MsgBox("Carousel is not ready for move.", MsgBoxStyle.Exclamation, "Attention")
        Else
            ' Sets the value of the requested bin and starts a timer that when timed out will reset the value.
            Me.lnRequestedBin_c4 = Val(Me.txtReqBin_c4.Text)
            Me.tmrReqBin_c4.Enabled = True
        End If
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub SetFocusReqBin_c1()
        Me.txtReqBin_c1.Focus()
        Me.txtReqBin_c1.SelectAll()
    End Sub

    Private Sub SetFocusReqBin_c2()
        Me.txtReqBin_c2.Focus()
        Me.txtReqBin_c2.SelectAll()
    End Sub

    Private Sub SetFocusReqBin_c3()
        Me.txtReqBin_c3.Focus()
        Me.txtReqBin_c3.SelectAll()
    End Sub

    Private Sub SetFocusReqBin_c4()
        Me.txtReqBin_c4.Focus()
        Me.txtReqBin_c4.SelectAll()
    End Sub

    Private Sub tmrReqBin_c1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReqBin_c1.Tick
        ' The timer resets the requested bin.
        Me.tmrReqBin_c1.Enabled = False
        Me.lnRequestedBin_c1 = 0
    End Sub

    Private Sub tmrReqBin_c2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReqBin_c2.Tick
        ' The timer resets the requested bin.
        Me.tmrReqBin_c2.Enabled = False
        Me.lnRequestedBin_c2 = 0
    End Sub

    Private Sub tmrReqBin_c3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReqBin_c3.Tick
        ' The timer resets the requested bin.
        Me.tmrReqBin_c3.Enabled = False
        Me.lnRequestedBin_c3 = 0
    End Sub

    Private Sub tmrReqBin_c4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReqBin_c4.Tick
        ' The timer resets the requested bin.
        Me.tmrReqBin_c4.Enabled = False
        Me.lnRequestedBin_c4 = 0
    End Sub

    Private Sub btnHomingStart_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomingStart_c1.Click
        If Not Me.lbHomingStart_c1 And Not Me.lbSR1_Homing_c1 Then
            Me.SetBinPosition_c1()
        End If
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub btnHomingStop_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbManualMode_c1 Then
            Me.lbHomingStop_c1 = True
        End If
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub SetBinPosition_c1()
        If Not Me.lbManualMode_c1 And Not Me.lbSR1_ManualMode_c1 Then
            If Val(Me.txtSetBinPos_c1.Text) <= 0 Or Val(Me.txtSetBinPos_c1.Text) > Me.lnNumBins_c1 Then
                MsgBox("Location is not valid.", MsgBoxStyle.Exclamation, "Setup Error")
                Me.txtSetBinPos_c1.Text = "0"
                Me.lnSetBinPos_c1 = 0
            Else
                Me.lnSetBinPos_c1 = Val(Me.txtSetBinPos_c1.Text)
                Me.lbHomingStart_c1 = True
            End If
        End If
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub HomingSetupColors_c1()
        If Me.lbSR1_Homing_c1 Then Me.btnHomingStart_c1.BackColor = Color.Lime Else Me.btnHomingStart_c1.UseVisualStyleBackColor = True
    End Sub

    Private Sub tmrHomingStart_c1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStart_c1.Tick
        Me.lbHomingStart_c1 = False
        Me.tmrHomingStart_c1.Enabled = False
    End Sub

    Private Sub tmrHomingStop_c1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStop_c1.Tick
        Me.lbHomingStop_c1 = False
        Me.tmrHomingStop_c1.Enabled = False
    End Sub

    Private Sub btnHomingStart_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomingStart_c2.Click
        If Not Me.lbHomingStart_c2 And Not Me.lbSR1_Homing_c2 Then
            Me.SetBinPosition_c2()
        End If
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub btnHomingStop_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbManualMode_c2 Then
            Me.lbHomingStop_c2 = True
        End If
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub SetBinPosition_c2()
        If Not Me.lbManualMode_c2 And Not Me.lbSR1_ManualMode_c2 Then
            If Val(Me.txtSetBinPos_c2.Text) <= 0 Or Val(Me.txtSetBinPos_c2.Text) > Me.lnNumBins_c2 Then
                MsgBox("Location is not valid.", MsgBoxStyle.Exclamation, "Setup Error")
                Me.txtSetBinPos_c2.Text = "0"
                Me.lnSetBinPos_c2 = 0
            Else
                Me.lnSetBinPos_c2 = Val(Me.txtSetBinPos_c2.Text)
                Me.lbHomingStart_c2 = True
            End If
        End If
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub HomingSetupColors_c2()
        If Me.lbSR1_Homing_c2 Then Me.btnHomingStart_c2.BackColor = Color.Lime Else Me.btnHomingStart_c2.UseVisualStyleBackColor = True
    End Sub

    Private Sub tmrHomingStart_c2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStart_c2.Tick
        Me.lbHomingStart_c2 = False
        Me.tmrHomingStart_c2.Enabled = False
    End Sub

    Private Sub tmrHomingStop_c2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStop_c2.Tick
        Me.lbHomingStop_c2 = False
        Me.tmrHomingStop_c2.Enabled = False
    End Sub

    Private Sub btnHomingStart_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomingStart_c3.Click
        If Not Me.lbHomingStart_c3 And Not Me.lbSR1_Homing_c3 Then
            Me.SetBinPosition_c3()
        End If
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub btnHomingStop_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbManualMode_c3 Then
            Me.lbHomingStop_c3 = True
        End If
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub SetBinPosition_c3()
        If Not Me.lbManualMode_c3 And Not Me.lbSR1_ManualMode_c3 Then
            If Val(Me.txtSetBinPos_c3.Text) <= 0 Or Val(Me.txtSetBinPos_c3.Text) > Me.lnNumBins_c3 Then
                MsgBox("Location is not valid.", MsgBoxStyle.Exclamation, "Setup Error")
                Me.txtSetBinPos_c3.Text = "0"
                Me.lnSetBinPos_c3 = 0
            Else
                Me.lnSetBinPos_c3 = Val(Me.txtSetBinPos_c3.Text)
                Me.lbHomingStart_c3 = True
            End If
        End If
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub HomingSetupColors_c3()
        If Me.lbSR1_Homing_c3 Then Me.btnHomingStart_c3.BackColor = Color.Lime Else Me.btnHomingStart_c3.UseVisualStyleBackColor = True
    End Sub

    Private Sub tmrHomingStart_c3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStart_c3.Tick
        Me.lbHomingStart_c3 = False
        Me.tmrHomingStart_c3.Enabled = False
    End Sub

    Private Sub tmrHomingStop_c3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStop_c3.Tick
        Me.lbHomingStop_c3 = False
        Me.tmrHomingStop_c3.Enabled = False
    End Sub

    Private Sub btnHomingStart_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomingStart_c4.Click
        If Not Me.lbHomingStart_c4 And Not Me.lbSR1_Homing_c4 Then
            Me.SetBinPosition_c4()
        End If
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub btnHomingStop_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbManualMode_c4 Then
            Me.lbHomingStop_c4 = True
        End If
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub SetBinPosition_c4()
        If Not Me.lbManualMode_c4 And Not Me.lbSR1_ManualMode_c4 Then
            If Val(Me.txtSetBinPos_c4.Text) <= 0 Or Val(Me.txtSetBinPos_c4.Text) > Me.lnNumBins_c4 Then
                MsgBox("Location is not valid.", MsgBoxStyle.Exclamation, "Setup Error")
                Me.txtSetBinPos_c4.Text = "0"
                Me.lnSetBinPos_c4 = 0
            Else
                Me.lnSetBinPos_c4 = Val(Me.txtSetBinPos_c4.Text)
                Me.lbHomingStart_c4 = True
            End If
        End If
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub HomingSetupColors_c4()
        If Me.lbSR1_Homing_c4 Then Me.btnHomingStart_c4.BackColor = Color.Lime Else Me.btnHomingStart_c4.UseVisualStyleBackColor = True
    End Sub

    Private Sub tmrHomingStart_c4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStart_c4.Tick
        Me.lbHomingStart_c4 = False
        Me.tmrHomingStart_c4.Enabled = False
    End Sub

    Private Sub tmrHomingStop_c4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHomingStop_c4.Tick
        Me.lbHomingStop_c4 = False
        Me.tmrHomingStop_c4.Enabled = False
    End Sub

    Private Sub ManualModeStartup_c1()
        Me.lbFWD_c1 = False
        Me.lbREV_c1 = False
        Me.lbSTOP_c1 = True
        Me.lbJogF_c1 = False
        Me.lbJogR_c1 = False
    End Sub

    Private Sub ManualModeStartup_c2()
        Me.lbFWD_c2 = False
        Me.lbREV_c2 = False
        Me.lbSTOP_c2 = True
        Me.lbJogF_c2 = False
        Me.lbJogR_c2 = False
    End Sub

    Private Sub ManualModeStartup_c3()
        Me.lbFWD_c3 = False
        Me.lbREV_c3 = False
        Me.lbSTOP_c3 = True
        Me.lbJogF_c3 = False
        Me.lbJogR_c3 = False
    End Sub

    Private Sub ManualModeStartup_c4()
        Me.lbFWD_c4 = False
        Me.lbREV_c4 = False
        Me.lbSTOP_c4 = True
        Me.lbJogF_c4 = False
        Me.lbJogR_c4 = False
    End Sub

    Private Sub ReadTagsMM_c1()
        Dim nrc_r As Short
        ' Read tags
        nrc_r = AxTndNTagReadMM1_c1.Read()
        Me.lnTndNTagReadMM1Stat_c1 = nrc_r
        If nrc_r = ThinkAndDoSuccess Then
            Me.lbFWD_c1 = AxTndNTagReadMM1_c1.GetValueAt(0)
            Me.lbREV_c1 = AxTndNTagReadMM1_c1.GetValueAt(1)
            Me.lbSTOP_c1 = AxTndNTagReadMM1_c1.GetValueAt(2)
        Else
            MsgBox("Cannot read tags from controller ReadTagsMM_c1")
        End If
    End Sub

    Private Sub WriteTagsMM_c1()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM4_c1.UpdateLongValue(0, Val(Me.lbJogF_c1))
        Me.AxTndNTagWriteMM4_c1.UpdateLongValue(1, Val(Me.lbJogR_c1))
        nrc_w = Me.AxTndNTagWriteMM4_c1.Write()
        Me.lnTndNTagWriteMM4Stat_c1 = nrc_w
    End Sub

    Private Sub ReadTagsMM_c2()
        Dim nrc_r As Short
        ' Read tags
        nrc_r = AxTndNTagReadMM1_c2.Read()
        Me.lnTndNTagReadMM1Stat_c2 = nrc_r
        If nrc_r = ThinkAndDoSuccess Then
            Me.lbFWD_c2 = AxTndNTagReadMM1_c2.GetValueAt(0)
            Me.lbREV_c2 = AxTndNTagReadMM1_c2.GetValueAt(1)
            Me.lbSTOP_c2 = AxTndNTagReadMM1_c2.GetValueAt(2)
        Else
            MsgBox("Cannot read tags from controller ReadTagsMM_c2")
        End If
    End Sub

    Private Sub WriteTagsMM_c2()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM4_c2.UpdateLongValue(0, Val(Me.lbJogF_c2))
        Me.AxTndNTagWriteMM4_c2.UpdateLongValue(1, Val(Me.lbJogR_c2))
        nrc_w = Me.AxTndNTagWriteMM4_c2.Write()
        Me.lnTndNTagWriteMM4Stat_c2 = nrc_w
    End Sub

    Private Sub ReadTagsMM_c3()
        Dim nrc_r As Short
        ' Read tags
        nrc_r = AxTndNTagReadMM1_c3.Read()
        Me.lnTndNTagReadMM1Stat_c3 = nrc_r
        If nrc_r = ThinkAndDoSuccess Then
            Me.lbFWD_c3 = AxTndNTagReadMM1_c3.GetValueAt(0)
            Me.lbREV_c3 = AxTndNTagReadMM1_c3.GetValueAt(1)
            Me.lbSTOP_c3 = AxTndNTagReadMM1_c3.GetValueAt(2)
        Else
            MsgBox("Cannot read tags from controller ReadTagsMM_c3")
        End If
    End Sub

    Private Sub WriteTagsMM_c3()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM4_c3.UpdateLongValue(0, Val(Me.lbJogF_c3))
        Me.AxTndNTagWriteMM4_c3.UpdateLongValue(1, Val(Me.lbJogR_c3))
        nrc_w = Me.AxTndNTagWriteMM4_c3.Write()
        Me.lnTndNTagWriteMM4Stat_c3 = nrc_w
    End Sub

    Private Sub ReadTagsMM_c4()
        Dim nrc_r As Short
        ' Read tags
        nrc_r = AxTndNTagReadMM1_c4.Read()
        Me.lnTndNTagReadMM1Stat_c4 = nrc_r
        If nrc_r = ThinkAndDoSuccess Then
            Me.lbFWD_c4 = AxTndNTagReadMM1_c4.GetValueAt(0)
            Me.lbREV_c4 = AxTndNTagReadMM1_c4.GetValueAt(1)
            Me.lbSTOP_c4 = AxTndNTagReadMM1_c4.GetValueAt(2)
        Else
            MsgBox("Cannot read tags from controller ReadTagsMM_c4")
        End If
    End Sub

    Private Sub WriteTagsMM_c4()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM4_c4.UpdateLongValue(0, Val(Me.lbJogF_c4))
        Me.AxTndNTagWriteMM4_c4.UpdateLongValue(1, Val(Me.lbJogR_c4))
        nrc_w = Me.AxTndNTagWriteMM4_c4.Write()
        Me.lnTndNTagWriteMM4Stat_c4 = nrc_w
    End Sub

    Private Sub btnFWD_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFWD_c1.Click
        Me.ForwardMM_c1()
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub btnSTOP_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTOP_c1.Click
        Me.StopMM_c1()
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub btnREV_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREV_c1.Click
        Me.ReverseMM_c1()
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub ForwardMM_c1()

        If Not Me.lbREV_c1 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM1_c1.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM1_c1.Write()
            Me.lnTndNTagWriteMM1Stat_c1 = nrc_w
        End If
    End Sub

    Private Sub ReverseMM_c1()
        If Not Me.lbFWD_c1 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM2_c1.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM2_c1.Write()
            Me.lnTndNTagWriteMM2Stat_c1 = nrc_w
            If nrc_w = ThinkAndDoSuccess Then
            End If
        End If
    End Sub

    Private Sub StopMM_c1()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM3_c1.UpdateLongValue(0, 1)
        nrc_w = Me.AxTndNTagWriteMM3_c1.Write()
        Me.lnTndNTagWriteMM3Stat_c1 = nrc_w
    End Sub

    Private Sub btnFWD_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFWD_c2.Click
        Me.ForwardMM_c2()
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub btnSTOP_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTOP_c2.Click
        Me.StopMM_c2()
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub btnREV_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREV_c2.Click
        Me.ReverseMM_c2()
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub ForwardMM_c2()

        If Not Me.lbREV_c2 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM1_c2.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM1_c2.Write()
            Me.lnTndNTagWriteMM1Stat_c2 = nrc_w
        End If
    End Sub

    Private Sub ReverseMM_c2()
        If Not Me.lbFWD_c2 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM2_c2.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM2_c2.Write()
            Me.lnTndNTagWriteMM2Stat_c2 = nrc_w
            If nrc_w = ThinkAndDoSuccess Then
            End If
        End If
    End Sub

    Private Sub StopMM_c2()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM3_c2.UpdateLongValue(0, 1)
        nrc_w = Me.AxTndNTagWriteMM3_c2.Write()
        Me.lnTndNTagWriteMM3Stat_c2 = nrc_w
    End Sub

    Private Sub btnFWD_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFWD_c3.Click
        Me.ForwardMM_c3()
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub btnSTOP_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTOP_c3.Click
        Me.StopMM_c3()
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub btnREV_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREV_c3.Click
        Me.ReverseMM_c3()
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub ForwardMM_c3()

        If Not Me.lbREV_c3 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM1_c3.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM1_c3.Write()
            Me.lnTndNTagWriteMM1Stat_c3 = nrc_w
        End If
    End Sub

    Private Sub ReverseMM_c3()
        If Not Me.lbFWD_c3 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM2_c3.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM2_c3.Write()
            Me.lnTndNTagWriteMM2Stat_c3 = nrc_w
            If nrc_w = ThinkAndDoSuccess Then
            End If
        End If
    End Sub

    Private Sub StopMM_c3()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM3_c3.UpdateLongValue(0, 1)
        nrc_w = Me.AxTndNTagWriteMM3_c3.Write()
        Me.lnTndNTagWriteMM3Stat_c3 = nrc_w
    End Sub

    Private Sub btnFWD_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFWD_c4.Click
        Me.ForwardMM_c4()
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub btnSTOP_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTOP_c4.Click
        Me.StopMM_c4()
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub btnREV_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnREV_c4.Click
        Me.ReverseMM_c4()
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub ForwardMM_c4()

        If Not Me.lbREV_c4 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM1_c4.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM1_c4.Write()
            Me.lnTndNTagWriteMM1Stat_c4 = nrc_w
        End If
    End Sub

    Private Sub ReverseMM_c4()
        If Not Me.lbFWD_c4 Then
            Dim nrc_w As Short
            ' Write tags
            Me.AxTndNTagWriteMM2_c4.UpdateLongValue(0, 1)
            nrc_w = Me.AxTndNTagWriteMM2_c4.Write()
            Me.lnTndNTagWriteMM2Stat_c4 = nrc_w
            If nrc_w = ThinkAndDoSuccess Then
            End If
        End If
    End Sub

    Private Sub StopMM_c4()
        Dim nrc_w As Short
        ' Write tags
        Me.AxTndNTagWriteMM3_c4.UpdateLongValue(0, 1)
        nrc_w = Me.AxTndNTagWriteMM3_c4.Write()
        Me.lnTndNTagWriteMM3Stat_c4 = nrc_w
    End Sub

    Private Sub btnJogF_c1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c1.MouseDown
        Me.lbJogF_c1 = True
        Me.lbJogR_c1 = False
    End Sub

    Private Sub btnJogF_c1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c1.MouseUp
        Me.lbJogF_c1 = False
        Me.lbJogR_c1 = False
    End Sub

    Private Sub btnJogR_c1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c1.MouseDown
        Me.lbJogF_c1 = False
        Me.lbJogR_c1 = True
    End Sub

    Private Sub btnJogR_c1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c1.MouseUp
        Me.lbJogF_c1 = False
        Me.lbJogR_c1 = False
    End Sub

    Private Sub chkManMode_c1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManMode_c1.CheckedChanged
        If Not Me.lbSR1_Homing_c1 And Not Me.lbSR1_Move_c1 Then
            Me.lbManualMode_c1 = Not Me.lbManualMode_c1
            If Not Me.lbManualMode_c1 Then StopMM_c1()
        Else
            Me.chkManMode_c1.Checked = False
        End If
    End Sub

    Private Sub btnJogF_c2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c2.MouseDown
        Me.lbJogF_c2 = True
        Me.lbJogR_c2 = False
    End Sub

    Private Sub btnJogF_c2_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c2.MouseUp
        Me.lbJogF_c2 = False
        Me.lbJogR_c2 = False
    End Sub

    Private Sub btnJogR_c2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c2.MouseDown
        Me.lbJogF_c2 = False
        Me.lbJogR_c2 = True
    End Sub

    Private Sub btnJogR_c2_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c2.MouseUp
        Me.lbJogF_c2 = False
        Me.lbJogR_c2 = False
    End Sub

    Private Sub chkManMode_c2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManMode_c2.CheckedChanged
        If Not Me.lbSR1_Homing_c2 And Not Me.lbSR1_Move_c2 Then
            Me.lbManualMode_c2 = Not Me.lbManualMode_c2
            If Not Me.lbManualMode_c2 Then StopMM_c2()
        Else
            Me.chkManMode_c2.Checked = False
        End If
    End Sub

    Private Sub btnJogF_c3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c3.MouseDown
        Me.lbJogF_c3 = True
        Me.lbJogR_c3 = False
    End Sub

    Private Sub btnJogF_c3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c3.MouseUp
        Me.lbJogF_c3 = False
        Me.lbJogR_c3 = False
    End Sub

    Private Sub btnJogR_c3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c3.MouseDown
        Me.lbJogF_c3 = False
        Me.lbJogR_c3 = True
    End Sub

    Private Sub btnJogR_c3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c3.MouseUp
        Me.lbJogF_c3 = False
        Me.lbJogR_c3 = False
    End Sub

    Private Sub chkManMode_c3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManMode_c3.CheckedChanged
        If Not Me.lbSR1_Homing_c3 And Not Me.lbSR1_Move_c3 Then
            Me.lbManualMode_c3 = Not Me.lbManualMode_c3
            If Not Me.lbManualMode_c3 Then StopMM_c3()
        Else
            Me.chkManMode_c3.Checked = False
        End If
    End Sub

    Private Sub btnJogF_c4_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c4.MouseDown
        Me.lbJogF_c4 = True
        Me.lbJogR_c4 = False
    End Sub

    Private Sub btnJogF_c4_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogF_c4.MouseUp
        Me.lbJogF_c4 = False
        Me.lbJogR_c4 = False
    End Sub

    Private Sub btnJogR_c4_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c4.MouseDown
        Me.lbJogF_c4 = False
        Me.lbJogR_c4 = True
    End Sub

    Private Sub btnJogR_c4_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJogR_c4.MouseUp
        Me.lbJogF_c4 = False
        Me.lbJogR_c4 = False
    End Sub

    Private Sub chkManMode_c4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManMode_c4.CheckedChanged
        If Not Me.lbSR1_Homing_c4 And Not Me.lbSR1_Move_c4 Then
            Me.lbManualMode_c4 = Not Me.lbManualMode_c4
            If Not Me.lbManualMode_c4 Then StopMM_c4()
        Else
            Me.chkManMode_c4.Checked = False
        End If
    End Sub

    Private Sub TabPageSetup_c1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageSetup_c1.Enter
        Me.PrmLoad_c1()
    End Sub

    Private Sub PrmLoad_c1()

        If Me.lbPrmLoad_c1 Then

            If Not Me.lbReadErrorPrm_c1 And Not Me.lbWriteErrorPrm_c1 Then
                Me.ReadTagsPrm_c1()
            End If

        Else

            Me.lblReadErrorPrm_c1.Visible = False
            Me.lblWriteErrorPrm_c1.Visible = False

            Dim nrc As Short

            ' Connect to the tndstation
            Me.AxTndNTagReadPrm_c1.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite1Prm_c1.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite2Prm_c1.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagReadPrm_c1.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite1Prm_c1.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite2Prm_c1.ThinkAndDoStationName = Me.lcTndStation

            If (ThinkAndDoSuccess = Me.AxTndNTagReadPrm_c1.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadPrm_c1.StartTagList()
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 1, "") ' NumBins
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 91, "") ' Ratio
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 103, "") ' BinTolPct
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 61, "") ' ControlType
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 55, "") ' ManModeMotorDelay
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(FlagType, 162, "") ' CarouselEnabled
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 79, "") ' StepsPerRev
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 109, "") ' SlowPreset1
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 115, "") ' SlowPreset2
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 121, "") ' SlowPreset3
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 97, "") ' StopPreset
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 85, "") ' Offset
                nrc = Me.AxTndNTagReadPrm_c1.AddToTagList(NumberType, 292, "") ' SafetyConfig
                nrc = Me.AxTndNTagReadPrm_c1.EndTagList()
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite1Prm_c1.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite1Prm_c1.StartTagList()
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 1, "") ' NumBins
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 91, "") ' Ratio
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 103, "") ' BinTolPct
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 61, "") ' ControlType
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 55, "") ' ManModeMotorDelay
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(FlagType, 162, "") ' CarouselEnabled
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 79, "") ' StepsPerRev
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 109, "") ' SlowPreset1
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 115, "") ' SlowPreset2
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 121, "") ' SlowPreset3
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 97, "") ' StopPreset
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 85, "") ' Offset
                    nrc = Me.AxTndNTagWrite1Prm_c1.AddToTagList(NumberType, 292, "") ' SafetyConfig
                    nrc = Me.AxTndNTagWrite1Prm_c1.EndTagList()
                    Me.ReadTagsPrm_c1()
                Else
                    MsgBox("Cannot connect Write1Prm_c1 to controller.")
                    Me.lblWriteErrorPrm_c1.Visible = True
                End If
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite2Prm_c1.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite2Prm_c1.StartTagList()
                    nrc = Me.AxTndNTagWrite2Prm_c1.AddToTagList(SystemType, 43, "") ' WriteRetentiveData
                    nrc = Me.AxTndNTagWrite2Prm_c1.EndTagList()
                    Me.WriteTagsPrm_c1()
                    Me.ReadTagsPrm_c1()
                Else
                    MsgBox("Cannot connect Write2Prm_c1 to controller.")
                    Me.lblWriteErrorPrm_c1.Visible = True
                    Me.lbWriteErrorPrm_c1 = True
                End If
            Else
                MsgBox("Cannot connect Read1Prm_c1 to controller.")
                Me.lblReadErrorPrm_c1.Visible = True
                Me.lbReadErrorPrm_c1 = True
            End If

            Me.lbPrmLoad_c1 = True

        End If

    End Sub

    Private Sub btnReadPrm_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadPrm_c1.Click
        If Not Me.lbReadErrorPrm_c1 And Not Me.lbWriteErrorPrm_c1 Then
            Me.ReadTagsPrm_c1()
        End If
    End Sub

    Private Sub btnWritePrm_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWritePrm_c1.Click
        If Not Me.lbReadErrorPrm_c1 And Not Me.lbWriteErrorPrm_c1 Then
            Me.WriteTagsPrm_c1()
        End If
    End Sub

    Private Sub ReadTagsPrm_c1()

        Me.lblPW_c1.Visible = True
        Me.lblPW_c1.Refresh()

        Me.ButtonsDisabledPrm_c1()

        Me.udNumBinsPrm_c1.Minimum = 6
        Me.udNumBinsPrm_c1.Maximum = 999
        Me.udControlTypePrm_c1.Minimum = 1
        Me.udControlTypePrm_c1.Maximum = 1
        Me.udMMMDelayPrm_c1.Minimum = 1000
        Me.udMMMDelayPrm_c1.Maximum = 10000
        Me.udMMMDelayPrm_c1.Increment = 100
        Me.udStepsPerRevPrm_c1.Minimum = 0
        Me.udStepsPerRevPrm_c1.Maximum = 32767
        Me.udnPosOffsetPct_c1.Minimum = -100
        Me.udnPosOffsetPct_c1.Maximum = 100

        Me.udRatioPrm_c1.Minimum = 11
        Me.udRatioPrm_c1.Maximum = 99
        Me.udRatioPrm_c1.Increment = 1

        Me.udBinTolPctPrm_c1.Minimum = 0.1
        Me.udBinTolPctPrm_c1.Maximum = 10
        Me.udBinTolPctPrm_c1.Increment = 0.1

        Me.udSlowPreset1Prm_c1.Minimum = 2
        Me.udSlowPreset1Prm_c1.Maximum = 3
        Me.udSlowPreset1Prm_c1.Increment = 0.5

        Me.udSlowPreset2Prm_c1.Minimum = 0.75
        Me.udSlowPreset2Prm_c1.Maximum = 1
        Me.udSlowPreset2Prm_c1.Increment = 0.05

        Me.udSlowPreset3Prm_c1.Minimum = 0.1
        Me.udSlowPreset3Prm_c1.Maximum = 0.5
        Me.udSlowPreset3Prm_c1.Increment = 0.001

        Me.udStopPresetPrm_c1.Minimum = 0.005
        Me.udStopPresetPrm_c1.Maximum = 0.09
        Me.udStopPresetPrm_c1.Increment = 0.001

        Dim nrc_r As Short

        ' Read tags
        nrc_r = AxTndNTagReadPrm_c1.Read()
        Me.lnTndNTagRead1StatPrm_c1 = nrc_r

        If nrc_r = ThinkAndDoSuccess Then
            Me.lnNumBinsPrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(0)
            Me.lnRatioPrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(1)
            Me.lnBinTolPctPrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(2)
            Me.lnControlTypePrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(3)
            Me.lnMMMDelayPrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(4)
            Me.chkEnabledPrm_c1.Checked = AxTndNTagReadPrm_c1.GetValueAt(5)
            Me.lnStepsPerRevPrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(6)
            Me.lnSlowPreset1Prm_c1 = AxTndNTagReadPrm_c1.GetValueAt(7)
            Me.lnSlowPreset2Prm_c1 = AxTndNTagReadPrm_c1.GetValueAt(8)
            Me.lnSlowPreset3Prm_c1 = AxTndNTagReadPrm_c1.GetValueAt(9)
            Me.lnStopPresetPrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(10)
            Me.nPosOffsetPct_c1 = AxTndNTagReadPrm_c1.GetValueAt(11)
            Me.lnSafetyConfigPrm_c1 = AxTndNTagReadPrm_c1.GetValueAt(12)
            Me.lblReadErrorPrm_c1.Visible = False
        Else
            MsgBox("Cannot read tags from controller ReadTagsPrm_c1")
            Me.lblReadErrorPrm_c1.Visible = True
            Me.chkEnabledPrm_c1.Checked = False
        End If

        Me.udNumBinsPrm_c1.Value = Me.lnNumBinsPrm_c1
        Me.udRatioPrm_c1.Value = Me.lnRatioPrm_c1
        Me.udBinTolPctPrm_c1.Value = Me.lnBinTolPctPrm_c1 / 10
        Me.udControlTypePrm_c1.Value = Me.lnControlTypePrm_c1
        Me.udMMMDelayPrm_c1.Value = Me.lnMMMDelayPrm_c1
        Me.udStepsPerRevPrm_c1.Value = Me.lnStepsPerRevPrm_c1
        Me.udnPosOffsetPct_c1.Value = Me.nPosOffsetPct_c1
        Me.udSlowPreset1Prm_c1.Value = Me.lnSlowPreset1Prm_c1 / 1000
        Me.udSlowPreset2Prm_c1.Value = Me.lnSlowPreset2Prm_c1 / 1000
        Me.udSlowPreset3Prm_c1.Value = Me.lnSlowPreset3Prm_c1 / 1000
        Me.udStopPresetPrm_c1.Value = Me.lnStopPresetPrm_c1 / 1000

        ' Breakout SafetyConfig
        Me.chkES1_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 0
        Me.chkES2_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 1
        Me.chkES3_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 2
        Me.chkES4_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 3
        Me.chkES5_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 4
        Me.chkES6_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 5
        Me.chkES7_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 6
        Me.chkES8_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 7
        '
        Me.chkPE1_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 8
        Me.chkPE2_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 9
        Me.chkPE3_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 10
        Me.chkPE4_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 11
        Me.chkPE5_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 12
        Me.chkPE6_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 13
        Me.chkPE7_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 14
        Me.chkPE8_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 15
        '
        Me.chkLG1_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 16
        Me.chkLG2_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 17
        Me.chkLG3_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 18
        Me.chkLG4_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 19
        Me.chkLG5_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 20
        Me.chkLG6_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 21
        Me.chkLG7_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 22
        Me.chkLG8_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 23
        '
        Me.chkMT1_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 24
        Me.chkMT2_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 25
        Me.chkMT3_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 26
        Me.chkMT4_c1.Checked = Me.lnSafetyConfigPrm_c1 And 2 ^ 27

        Me.lblPW_c1.Visible = False
        Me.lblPW_c1.Refresh()

        Me.ButtonsEnabledPrm_c1()

    End Sub

    Private Sub SafetyConfigCalc_c1()
        Me.lnSafetyConfigPrm_c1 = 0
        If Me.chkES1_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 0
        If Me.chkES2_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 1
        If Me.chkES3_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 2
        If Me.chkES4_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 3
        If Me.chkES5_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 4
        If Me.chkES6_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 5
        If Me.chkES7_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 6
        If Me.chkES8_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 7
        '
        If Me.chkPE1_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 8
        If Me.chkPE2_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 9
        If Me.chkPE3_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 10
        If Me.chkPE4_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 11
        If Me.chkPE5_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 12
        If Me.chkPE6_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 13
        If Me.chkPE7_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 14
        If Me.chkPE8_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 15
        '
        If Me.chkLG1_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 16
        If Me.chkLG2_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 17
        If Me.chkLG3_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 18
        If Me.chkLG4_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 19
        If Me.chkLG5_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 20
        If Me.chkLG6_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 21
        If Me.chkLG7_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 22
        If Me.chkLG8_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 23
        '
        If Me.chkMT1_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 24
        If Me.chkMT2_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 25
        If Me.chkMT3_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 26
        If Me.chkMT4_c1.Checked Then Me.lnSafetyConfigPrm_c1 += 2 ^ 27
    End Sub

    Private Sub WriteTagsPrm_c1()

        Me.lblPW_c1.Visible = True
        Me.lblPW_c1.Refresh()

        Me.ButtonsDisabledPrm_c1()

        Dim nrc_w As Short

        ' Write tags
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(0, Me.udNumBinsPrm_c1.Value)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(1, Me.udRatioPrm_c1.Value)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(2, Me.udBinTolPctPrm_c1.Value * 10)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(3, Me.udControlTypePrm_c1.Value)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(4, Me.udMMMDelayPrm_c1.Value)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(5, Val(Me.chkEnabledPrm_c1.Checked))
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(6, Me.udStepsPerRevPrm_c1.Value)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(7, Me.udSlowPreset1Prm_c1.Value * 1000)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(8, Me.udSlowPreset2Prm_c1.Value * 1000)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(9, Me.udSlowPreset3Prm_c1.Value * 1000)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(10, Me.udStopPresetPrm_c1.Value * 1000)
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(11, Me.udnPosOffsetPct_c1.Value)
        Me.SafetyConfigCalc_c1()
        Me.AxTndNTagWrite1Prm_c1.UpdateLongValue(12, Me.lnSafetyConfigPrm_c1)

        nrc_w = Me.AxTndNTagWrite1Prm_c1.Write()
        Me.lnTndNTagWrite1StatPrm_c1 = nrc_w

        If nrc_w = ThinkAndDoSuccess Then
            ' Success
            Me.lblWriteErrorPrm_c1.Visible = False
            Me.AxTndNTagWrite2Prm_c1.UpdateLongValue(0, 1) ' WriteRetentiveData
            Me.AxTndNTagWrite2Prm_c1.Write()
            Me.tmrPrm_c1.Enabled = True
        Else
            ' Failure
            Me.lblWriteErrorPrm_c1.Visible = True
            Me.ButtonsEnabledPrm_c1()
        End If

    End Sub

    Private Sub tmrPrm_c1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPrm_c1.Tick
        Me.tmrPrm_c1.Enabled = False
        Me.AxTndNTagWrite2Prm_c1.UpdateLongValue(0, 0) ' WriteRetentiveData
        Me.AxTndNTagWrite2Prm_c1.Write()
        Me.ReadTagsPrm_c1()
        Me.ButtonsEnabledPrm_c1()
    End Sub

    Private Sub ButtonsDisabledPrm_c1()
        Me.btnReadPrm_c1.Enabled = False
        Me.btnWritePrm_c1.Enabled = False
    End Sub

    Private Sub ButtonsEnabledPrm_c1()
        Me.btnReadPrm_c1.Enabled = True
        Me.btnWritePrm_c1.Enabled = True
    End Sub

    Private Sub btnEncoderStart_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncoderStart_c1.Click
        If Not Me.lbEncoderStart_c1 And Not Me.lbSR1_EncoderSetup_c1 Then
            Me.lbEncoderStart_c1 = True
        End If
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub btnEncoderStop_c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbEncoderStart_c1 Then
            Me.lbEncoderStop_c1 = True
        End If
        Me.SetFocusReqBin_c1()
    End Sub

    Private Sub tmrEncoderStart_c1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStart_c1.Tick
        Me.lbEncoderStart_c1 = False
        Me.tmrEncoderStart_c1.Enabled = False
    End Sub

    Private Sub tmrEncoderStop_c1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStop_c1.Tick
        Me.lbEncoderStop_c1 = False
        Me.tmrEncoderStop_c1.Enabled = False
    End Sub

    Private Sub EncoderSetupColors_c1()
        If Me.lbSR1_EncoderSetup_c1 Then Me.btnEncoderStart_c1.BackColor = Color.Lime Else Me.btnEncoderStart_c1.UseVisualStyleBackColor = True
        'If Me.lbEncoderStop_c1 Then Me.btnEncoderStop_c1.BackColor = Color.Red Else Me.btnEncoderStop_c1.UseVisualStyleBackColor = True
    End Sub

    Private Sub TabPageSetup_c2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageSetup_c2.Enter
        Me.PrmLoad_c2()
    End Sub

    Private Sub PrmLoad_c2()

        If Me.lbPrmLoad_c2 Then

            If Not Me.lbReadErrorPrm_c2 And Not Me.lbWriteErrorPrm_c2 Then
                Me.ReadTagsPrm_c2()
            End If

        Else

            Me.lblReadErrorPrm_c2.Visible = False
            Me.lblWriteErrorPrm_c2.Visible = False

            Dim nrc As Short

            ' Connect to the tndstation
            Me.AxTndNTagReadPrm_c2.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite1Prm_c2.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite2Prm_c2.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagReadPrm_c2.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite1Prm_c2.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite2Prm_c2.ThinkAndDoStationName = Me.lcTndStation

            If (ThinkAndDoSuccess = Me.AxTndNTagReadPrm_c2.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadPrm_c2.StartTagList()
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 2, "") ' NumBins
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 92, "") ' Ratio
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 104, "") ' BinTolPct
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 62, "") ' ControlType
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 56, "") ' ManModeMotorDelay
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(FlagType, 163, "") ' CarouselEnabled
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 80, "") ' StepsPerRev
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 110, "") ' SlowPreset1
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 116, "") ' SlowPreset2
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 122, "") ' SlowPreset3
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 98, "") ' StopPreset
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 86, "") ' Offset
                nrc = Me.AxTndNTagReadPrm_c2.AddToTagList(NumberType, 293, "") ' SafetyConfig
                nrc = Me.AxTndNTagReadPrm_c2.EndTagList()
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite1Prm_c2.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite1Prm_c2.StartTagList()
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 2, "") ' NumBins
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 92, "") ' Ratio
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 104, "") ' BinTolPct
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 62, "") ' ControlType
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 56, "") ' ManModeMotorDelay
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(FlagType, 163, "") ' CarouselEnabled
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 80, "") ' StepsPerRev
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 110, "") ' SlowPreset1
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 116, "") ' SlowPreset2
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 122, "") ' SlowPreset3
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 98, "") ' StopPreset
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 86, "") ' Offset
                    nrc = Me.AxTndNTagWrite1Prm_c2.AddToTagList(NumberType, 293, "") ' SafetyConfig
                    nrc = Me.AxTndNTagWrite1Prm_c2.EndTagList()
                    Me.ReadTagsPrm_c2()
                Else
                    MsgBox("Cannot connect Write1Prm_c2 to controller.")
                    Me.lblWriteErrorPrm_c2.Visible = True
                End If
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite2Prm_c2.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite2Prm_c2.StartTagList()
                    nrc = Me.AxTndNTagWrite2Prm_c2.AddToTagList(SystemType, 43, "") ' WriteRetentiveData
                    nrc = Me.AxTndNTagWrite2Prm_c2.EndTagList()
                    Me.WriteTagsPrm_c2()
                    Me.ReadTagsPrm_c2()
                Else
                    MsgBox("Cannot connect Write2Prm_c2 to controller.")
                    Me.lblWriteErrorPrm_c2.Visible = True
                    Me.lbWriteErrorPrm_c2 = True
                End If
            Else
                MsgBox("Cannot connect Read1Prm_c2 to controller.")
                Me.lblReadErrorPrm_c2.Visible = True
                Me.lbReadErrorPrm_c2 = True
            End If

            Me.lbPrmLoad_c2 = True

        End If

    End Sub

    Private Sub btnReadPrm_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadPrm_c2.Click
        If Not Me.lbReadErrorPrm_c2 And Not Me.lbWriteErrorPrm_c2 Then
            Me.ReadTagsPrm_c2()
        End If
    End Sub

    Private Sub btnWritePrm_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWritePrm_c2.Click
        If Not Me.lbReadErrorPrm_c2 And Not Me.lbWriteErrorPrm_c2 Then
            Me.WriteTagsPrm_c2()
        End If
    End Sub

    Private Sub ReadTagsPrm_c2()

        Me.lblPW_c2.Visible = True
        Me.lblPW_c2.Refresh()

        Me.ButtonsDisabledPrm_c2()

        Me.udNumBinsPrm_c2.Minimum = 6
        Me.udNumBinsPrm_c2.Maximum = 999
        Me.udControlTypePrm_c2.Minimum = 1
        Me.udControlTypePrm_c2.Maximum = 2
        Me.udMMMDelayPrm_c2.Minimum = 1000
        Me.udMMMDelayPrm_c2.Maximum = 10000
        Me.udMMMDelayPrm_c2.Increment = 100
        Me.udStepsPerRevPrm_c2.Minimum = 0
        Me.udStepsPerRevPrm_c2.Maximum = 32767
        Me.udnPosOffsetPct_c2.Minimum = -100
        Me.udnPosOffsetPct_c2.Maximum = 100

        Me.udRatioPrm_c2.Minimum = 11
        Me.udRatioPrm_c2.Maximum = 99
        Me.udRatioPrm_c2.Increment = 1

        Me.udBinTolPctPrm_c2.Minimum = 0.1
        Me.udBinTolPctPrm_c2.Maximum = 10
        Me.udBinTolPctPrm_c2.Increment = 0.1

        Me.udBinTolPctPrm_c2.Minimum = 0.1
        Me.udBinTolPctPrm_c2.Maximum = 10
        Me.udBinTolPctPrm_c2.Increment = 0.1

        Me.udSlowPreset1Prm_c2.Minimum = 2
        Me.udSlowPreset1Prm_c2.Maximum = 3
        Me.udSlowPreset1Prm_c2.Increment = 0.5

        Me.udSlowPreset2Prm_c2.Minimum = 0.75
        Me.udSlowPreset2Prm_c2.Maximum = 1
        Me.udSlowPreset2Prm_c2.Increment = 0.05

        Me.udSlowPreset3Prm_c2.Minimum = 0.1
        Me.udSlowPreset3Prm_c2.Maximum = 0.5
        Me.udSlowPreset3Prm_c2.Increment = 0.001

        Me.udStopPresetPrm_c2.Minimum = 0.005
        Me.udStopPresetPrm_c2.Maximum = 0.09
        Me.udStopPresetPrm_c2.Increment = 0.001

        Dim nrc_r As Short

        ' Read tags
        nrc_r = AxTndNTagReadPrm_c2.Read()
        Me.lnTndNTagRead1StatPrm_c2 = nrc_r

        If nrc_r = ThinkAndDoSuccess Then
            Me.lnNumBinsPrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(0)
            Me.lnRatioPrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(1)
            Me.lnBinTolPctPrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(2)
            Me.lnControlTypePrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(3)
            Me.lnMMMDelayPrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(4)
            Me.chkEnabledPrm_c2.Checked = AxTndNTagReadPrm_c2.GetValueAt(5)
            Me.lnStepsPerRevPrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(6)
            Me.lnSlowPreset1Prm_c2 = AxTndNTagReadPrm_c2.GetValueAt(7)
            Me.lnSlowPreset2Prm_c2 = AxTndNTagReadPrm_c2.GetValueAt(8)
            Me.lnSlowPreset3Prm_c2 = AxTndNTagReadPrm_c2.GetValueAt(9)
            Me.lnStopPresetPrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(10)
            Me.nPosOffsetPct_c2 = AxTndNTagReadPrm_c2.GetValueAt(11)
            Me.lnSafetyConfigPrm_c2 = AxTndNTagReadPrm_c2.GetValueAt(12)
            Me.lblReadErrorPrm_c2.Visible = False
        Else
            MsgBox("Cannot read tags from controller ReadTagsPrm_c2")
            Me.lblReadErrorPrm_c2.Visible = True
            Me.chkEnabledPrm_c2.Checked = False
        End If

        Me.udNumBinsPrm_c2.Value = Me.lnNumBinsPrm_c2
        Me.udRatioPrm_c2.Value = Me.lnRatioPrm_c2
        Me.udBinTolPctPrm_c2.Value = Me.lnBinTolPctPrm_c2 / 10
        Me.udControlTypePrm_c2.Value = Me.lnControlTypePrm_c2
        Me.udMMMDelayPrm_c2.Value = Me.lnMMMDelayPrm_c2
        Me.udStepsPerRevPrm_c2.Value = Me.lnStepsPerRevPrm_c2
        Me.udnPosOffsetPct_c2.Value = Me.nPosOffsetPct_c2
        Me.udSlowPreset1Prm_c2.Value = Me.lnSlowPreset1Prm_c2 / 1000
        Me.udSlowPreset2Prm_c2.Value = Me.lnSlowPreset2Prm_c2 / 1000
        Me.udSlowPreset3Prm_c2.Value = Me.lnSlowPreset3Prm_c2 / 1000
        Me.udStopPresetPrm_c2.Value = Me.lnStopPresetPrm_c2 / 1000

        ' Breakout SafetyConfig
        Me.chkES1_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 0
        Me.chkES2_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 1
        Me.chkES3_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 2
        Me.chkES4_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 3
        Me.chkES5_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 4
        Me.chkES6_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 5
        Me.chkES7_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 6
        Me.chkES8_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 7
        '
        Me.chkPE1_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 8
        Me.chkPE2_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 9
        Me.chkPE3_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 10
        Me.chkPE4_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 11
        Me.chkPE5_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 12
        Me.chkPE6_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 13
        Me.chkPE7_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 14
        Me.chkPE8_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 15
        '
        Me.chkLG1_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 16
        Me.chkLG2_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 17
        Me.chkLG3_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 18
        Me.chkLG4_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 19
        Me.chkLG5_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 20
        Me.chkLG6_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 21
        Me.chkLG7_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 22
        Me.chkLG8_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 23
        '
        Me.chkMT1_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 24
        Me.chkMT2_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 25
        Me.chkMT3_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 26
        Me.chkMT4_c2.Checked = Me.lnSafetyConfigPrm_c2 And 2 ^ 27

        Me.lblPW_c2.Visible = False
        Me.lblPW_c2.Refresh()

        Me.ButtonsEnabledPrm_c2()

    End Sub

    Private Sub SafetyConfigCalc_c2()
        Me.lnSafetyConfigPrm_c2 = 0
        If Me.chkES1_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 0
        If Me.chkES2_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 1
        If Me.chkES3_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 2
        If Me.chkES4_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 3
        If Me.chkES5_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 4
        If Me.chkES6_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 5
        If Me.chkES7_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 6
        If Me.chkES8_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 7
        '
        If Me.chkPE1_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 8
        If Me.chkPE2_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 9
        If Me.chkPE3_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 10
        If Me.chkPE4_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 11
        If Me.chkPE5_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 12
        If Me.chkPE6_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 13
        If Me.chkPE7_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 14
        If Me.chkPE8_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 15
        '
        If Me.chkLG1_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 16
        If Me.chkLG2_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 17
        If Me.chkLG3_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 18
        If Me.chkLG4_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 19
        If Me.chkLG5_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 20
        If Me.chkLG6_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 21
        If Me.chkLG7_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 22
        If Me.chkLG8_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 23
        '
        If Me.chkMT1_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 24
        If Me.chkMT2_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 25
        If Me.chkMT3_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 26
        If Me.chkMT4_c2.Checked Then Me.lnSafetyConfigPrm_c2 += 2 ^ 27
    End Sub

    Private Sub WriteTagsPrm_c2()

        Me.lblPW_c2.Visible = True
        Me.lblPW_c2.Refresh()

        Me.ButtonsDisabledPrm_c2()

        Dim nrc_w As Short

        ' Write tags
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(0, Me.udNumBinsPrm_c2.Value)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(1, Me.udRatioPrm_c2.Value)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(2, Me.udBinTolPctPrm_c2.Value * 10)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(3, Me.udControlTypePrm_c2.Value)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(4, Me.udMMMDelayPrm_c2.Value)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(5, Val(Me.chkEnabledPrm_c2.Checked))
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(6, Me.udStepsPerRevPrm_c2.Value)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(7, Me.udSlowPreset1Prm_c2.Value * 1000)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(8, Me.udSlowPreset2Prm_c2.Value * 1000)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(9, Me.udSlowPreset3Prm_c2.Value * 1000)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(10, Me.udStopPresetPrm_c2.Value * 1000)
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(11, Me.udnPosOffsetPct_c2.Value)
        Me.SafetyConfigCalc_c2()
        Me.AxTndNTagWrite1Prm_c2.UpdateLongValue(12, Me.lnSafetyConfigPrm_c2)

        nrc_w = Me.AxTndNTagWrite1Prm_c2.Write()
        Me.lnTndNTagWrite1StatPrm_c2 = nrc_w

        If nrc_w = ThinkAndDoSuccess Then
            ' Success
            Me.lblWriteErrorPrm_c2.Visible = False
            Me.AxTndNTagWrite2Prm_c2.UpdateLongValue(0, 1) ' WriteRetentiveData
            Me.AxTndNTagWrite2Prm_c2.Write()
            Me.tmrPrm_c2.Enabled = True
        Else
            ' Failure
            Me.lblWriteErrorPrm_c2.Visible = True
            Me.ButtonsEnabledPrm_c2()
        End If

    End Sub

    Private Sub tmrPrm_c2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPrm_c2.Tick
        Me.tmrPrm_c2.Enabled = False
        Me.AxTndNTagWrite2Prm_c2.UpdateLongValue(0, 0) ' WriteRetentiveData
        Me.AxTndNTagWrite2Prm_c2.Write()
        Me.ReadTagsPrm_c2()
        Me.ButtonsEnabledPrm_c2()
    End Sub

    Private Sub ButtonsDisabledPrm_c2()
        Me.btnReadPrm_c2.Enabled = False
        Me.btnWritePrm_c2.Enabled = False
    End Sub

    Private Sub ButtonsEnabledPrm_c2()
        Me.btnReadPrm_c2.Enabled = True
        Me.btnWritePrm_c2.Enabled = True
    End Sub

    Private Sub btnEncoderStart_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncoderStart_c2.Click
        If Not Me.lbEncoderStart_c2 And Not Me.lbSR1_EncoderSetup_c2 Then
            Me.lbEncoderStart_c2 = True
        End If
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub btnEncoderStop_c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbEncoderStart_c2 Then
            Me.lbEncoderStop_c2 = True
        End If
        Me.SetFocusReqBin_c2()
    End Sub

    Private Sub tmrEncoderStart_c2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStart_c2.Tick
        Me.lbEncoderStart_c2 = False
        Me.tmrEncoderStart_c2.Enabled = False
    End Sub

    Private Sub tmrEncoderStop_c2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStop_c2.Tick
        Me.lbEncoderStop_c2 = False
        Me.tmrEncoderStop_c2.Enabled = False
    End Sub

    Private Sub EncoderSetupColors_c2()
        If Me.lbSR1_EncoderSetup_c2 Then Me.btnEncoderStart_c2.BackColor = Color.Lime Else Me.btnEncoderStart_c2.UseVisualStyleBackColor = True
        'If Me.lbEncoderStop_c2 Then Me.btnEncoderStop_c2.BackColor = Color.Red Else Me.btnEncoderStop_c2.UseVisualStyleBackColor = True
    End Sub

    Private Sub TabPageSetup_c3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageSetup_c3.Enter
        Me.PrmLoad_c3()
    End Sub

    Private Sub PrmLoad_c3()

        If Me.lbPrmLoad_c3 Then

            If Not Me.lbReadErrorPrm_c3 And Not Me.lbWriteErrorPrm_c3 Then
                Me.ReadTagsPrm_c3()
            End If

        Else

            Me.lblReadErrorPrm_c3.Visible = False
            Me.lblWriteErrorPrm_c3.Visible = False

            Dim nrc As Short

            ' Connect to the tndstation
            Me.AxTndNTagReadPrm_c3.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite1Prm_c3.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite2Prm_c3.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagReadPrm_c3.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite1Prm_c3.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite2Prm_c3.ThinkAndDoStationName = Me.lcTndStation

            If (ThinkAndDoSuccess = Me.AxTndNTagReadPrm_c3.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadPrm_c3.StartTagList()
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 3, "") ' NumBins
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 93, "") ' Ratio
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 105, "") ' BinTolPct
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 63, "") ' ControlType
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 57, "") ' ManModeMotorDelay
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(FlagType, 164, "") ' CarouselEnabled
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 81, "") ' StepsPerRev
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 111, "") ' SlowPreset1
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 117, "") ' SlowPreset2
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 123, "") ' SlowPreset3
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 99, "") ' StopPreset
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 87, "") ' Offset
                nrc = Me.AxTndNTagReadPrm_c3.AddToTagList(NumberType, 294, "") ' SafetyConfig
                nrc = Me.AxTndNTagReadPrm_c3.EndTagList()
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite1Prm_c3.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite1Prm_c3.StartTagList()
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 3, "") ' NumBins
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 93, "") ' Ratio
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 105, "") ' BinTolPct
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 63, "") ' ControlType
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 57, "") ' ManModeMotorDelay
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(FlagType, 164, "") ' CarouselEnabled
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 81, "") ' StepsPerRev
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 111, "") ' SlowPreset1
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 117, "") ' SlowPreset2
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 123, "") ' SlowPreset3
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 99, "") ' StopPreset
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 87, "") ' Offset
                    nrc = Me.AxTndNTagWrite1Prm_c3.AddToTagList(NumberType, 294, "") ' SafetyConfig
                    nrc = Me.AxTndNTagWrite1Prm_c3.EndTagList()
                    Me.ReadTagsPrm_c3()
                Else
                    MsgBox("Cannot connect Write1Prm_c3 to controller.")
                    Me.lblWriteErrorPrm_c3.Visible = True
                End If
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite2Prm_c3.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite2Prm_c3.StartTagList()
                    nrc = Me.AxTndNTagWrite2Prm_c3.AddToTagList(SystemType, 43, "") ' WriteRetentiveData
                    nrc = Me.AxTndNTagWrite2Prm_c3.EndTagList()
                    Me.WriteTagsPrm_c3()
                    Me.ReadTagsPrm_c3()
                Else
                    MsgBox("Cannot connect Write2Prm_c3 to controller.")
                    Me.lblWriteErrorPrm_c3.Visible = True
                    Me.lbWriteErrorPrm_c3 = True
                End If
            Else
                MsgBox("Cannot connect Read1Prm_c3 to controller.")
                Me.lblReadErrorPrm_c3.Visible = True
                Me.lbReadErrorPrm_c3 = True
            End If

            Me.lbPrmLoad_c3 = True

        End If

    End Sub

    Private Sub btnReadPrm_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadPrm_c3.Click
        If Not Me.lbReadErrorPrm_c3 And Not Me.lbWriteErrorPrm_c3 Then
            Me.ReadTagsPrm_c3()
        End If
    End Sub

    Private Sub btnWritePrm_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWritePrm_c3.Click
        If Not Me.lbReadErrorPrm_c3 And Not Me.lbWriteErrorPrm_c3 Then
            Me.WriteTagsPrm_c3()
        End If
    End Sub

    Private Sub ReadTagsPrm_c3()

        Me.lblPW_c3.Visible = True
        Me.lblPW_c3.Refresh()

        Me.ButtonsDisabledPrm_c3()

        Me.udNumBinsPrm_c3.Minimum = 6
        Me.udNumBinsPrm_c3.Maximum = 999
        Me.udControlTypePrm_c3.Minimum = 1
        Me.udControlTypePrm_c3.Maximum = 2
        Me.udMMMDelayPrm_c3.Minimum = 1000
        Me.udMMMDelayPrm_c3.Maximum = 10000
        Me.udMMMDelayPrm_c3.Increment = 100
        Me.udStepsPerRevPrm_c3.Minimum = 0
        Me.udStepsPerRevPrm_c3.Maximum = 32767
        Me.udnPosOffsetPct_c3.Minimum = -100
        Me.udnPosOffsetPct_c3.Maximum = 100

        Me.udRatioPrm_c3.Minimum = 11
        Me.udRatioPrm_c3.Maximum = 99
        Me.udRatioPrm_c3.Increment = 1

        Me.udBinTolPctPrm_c3.Minimum = 0.1
        Me.udBinTolPctPrm_c3.Maximum = 10
        Me.udBinTolPctPrm_c3.Increment = 0.1

        Me.udBinTolPctPrm_c3.Minimum = 0.1
        Me.udBinTolPctPrm_c3.Maximum = 10
        Me.udBinTolPctPrm_c3.Increment = 0.1

        Me.udSlowPreset1Prm_c3.Minimum = 2
        Me.udSlowPreset1Prm_c3.Maximum = 3
        Me.udSlowPreset1Prm_c3.Increment = 0.5

        Me.udSlowPreset2Prm_c3.Minimum = 0.75
        Me.udSlowPreset2Prm_c3.Maximum = 1
        Me.udSlowPreset2Prm_c3.Increment = 0.05

        Me.udSlowPreset3Prm_c3.Minimum = 0.1
        Me.udSlowPreset3Prm_c3.Maximum = 0.5
        Me.udSlowPreset3Prm_c3.Increment = 0.001

        Me.udStopPresetPrm_c3.Minimum = 0.005
        Me.udStopPresetPrm_c3.Maximum = 0.09
        Me.udStopPresetPrm_c3.Increment = 0.001

        Dim nrc_r As Short

        ' Read tags
        nrc_r = AxTndNTagReadPrm_c3.Read()
        Me.lnTndNTagRead1StatPrm_c3 = nrc_r

        If nrc_r = ThinkAndDoSuccess Then
            Me.lnNumBinsPrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(0)
            Me.lnRatioPrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(1)
            Me.lnBinTolPctPrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(2)
            Me.lnControlTypePrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(3)
            Me.lnMMMDelayPrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(4)
            Me.chkEnabledPrm_c3.Checked = AxTndNTagReadPrm_c3.GetValueAt(5)
            Me.lnStepsPerRevPrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(6)
            Me.lnSlowPreset1Prm_c3 = AxTndNTagReadPrm_c3.GetValueAt(7)
            Me.lnSlowPreset2Prm_c3 = AxTndNTagReadPrm_c3.GetValueAt(8)
            Me.lnSlowPreset3Prm_c3 = AxTndNTagReadPrm_c3.GetValueAt(9)
            Me.lnStopPresetPrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(10)
            Me.nPosOffsetPct_c3 = AxTndNTagReadPrm_c3.GetValueAt(11)
            Me.lnSafetyConfigPrm_c3 = AxTndNTagReadPrm_c3.GetValueAt(12)
            Me.lblReadErrorPrm_c3.Visible = False
        Else
            MsgBox("Cannot read tags from controller ReadTagsPrm_c3")
            Me.lblReadErrorPrm_c3.Visible = True
            Me.chkEnabledPrm_c3.Checked = False
        End If

        Me.udNumBinsPrm_c3.Value = Me.lnNumBinsPrm_c3
        Me.udRatioPrm_c3.Value = Me.lnRatioPrm_c3
        Me.udBinTolPctPrm_c3.Value = Me.lnBinTolPctPrm_c3 / 10
        Me.udControlTypePrm_c3.Value = Me.lnControlTypePrm_c3
        Me.udMMMDelayPrm_c3.Value = Me.lnMMMDelayPrm_c3
        Me.udStepsPerRevPrm_c3.Value = Me.lnStepsPerRevPrm_c3
        Me.udnPosOffsetPct_c3.Value = Me.nPosOffsetPct_c3
        Me.udSlowPreset1Prm_c3.Value = Me.lnSlowPreset1Prm_c3 / 1000
        Me.udSlowPreset2Prm_c3.Value = Me.lnSlowPreset2Prm_c3 / 1000
        Me.udSlowPreset3Prm_c3.Value = Me.lnSlowPreset3Prm_c3 / 1000
        Me.udStopPresetPrm_c3.Value = Me.lnStopPresetPrm_c3 / 1000

        ' Breakout SafetyConfig
        Me.chkES1_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 0
        Me.chkES2_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 1
        Me.chkES3_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 2
        Me.chkES4_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 3
        Me.chkES5_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 4
        Me.chkES6_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 5
        Me.chkES7_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 6
        Me.chkES8_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 7
        '
        Me.chkPE1_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 8
        Me.chkPE2_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 9
        Me.chkPE3_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 10
        Me.chkPE4_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 11
        Me.chkPE5_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 12
        Me.chkPE6_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 13
        Me.chkPE7_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 14
        Me.chkPE8_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 15
        '
        Me.chkLG1_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 16
        Me.chkLG2_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 17
        Me.chkLG3_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 18
        Me.chkLG4_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 19
        Me.chkLG5_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 20
        Me.chkLG6_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 21
        Me.chkLG7_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 22
        Me.chkLG8_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 23
        '
        Me.chkMT1_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 24
        Me.chkMT2_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 25
        Me.chkMT3_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 26
        Me.chkMT4_c3.Checked = Me.lnSafetyConfigPrm_c3 And 2 ^ 27

        Me.lblPW_c3.Visible = False
        Me.lblPW_c3.Refresh()

        Me.ButtonsEnabledPrm_c3()

    End Sub

    Private Sub SafetyConfigCalc_c3()
        Me.lnSafetyConfigPrm_c3 = 0
        If Me.chkES1_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 0
        If Me.chkES2_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 1
        If Me.chkES3_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 2
        If Me.chkES4_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 3
        If Me.chkES5_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 4
        If Me.chkES6_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 5
        If Me.chkES7_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 6
        If Me.chkES8_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 7
        '
        If Me.chkPE1_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 8
        If Me.chkPE2_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 9
        If Me.chkPE3_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 10
        If Me.chkPE4_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 11
        If Me.chkPE5_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 12
        If Me.chkPE6_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 13
        If Me.chkPE7_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 14
        If Me.chkPE8_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 15
        '
        If Me.chkLG1_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 16
        If Me.chkLG2_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 17
        If Me.chkLG3_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 18
        If Me.chkLG4_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 19
        If Me.chkLG5_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 20
        If Me.chkLG6_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 21
        If Me.chkLG7_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 22
        If Me.chkLG8_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 23
        '
        If Me.chkMT1_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 24
        If Me.chkMT2_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 25
        If Me.chkMT3_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 26
        If Me.chkMT4_c3.Checked Then Me.lnSafetyConfigPrm_c3 += 2 ^ 27
    End Sub

    Private Sub WriteTagsPrm_c3()

        Me.lblPW_c3.Visible = True
        Me.lblPW_c3.Refresh()

        Me.ButtonsDisabledPrm_c3()

        Dim nrc_w As Short

        ' Write tags
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(0, Me.udNumBinsPrm_c3.Value)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(1, Me.udRatioPrm_c3.Value)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(2, Me.udBinTolPctPrm_c3.Value * 10)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(3, Me.udControlTypePrm_c3.Value)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(4, Me.udMMMDelayPrm_c3.Value)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(5, Val(Me.chkEnabledPrm_c3.Checked))
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(6, Me.udStepsPerRevPrm_c3.Value)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(7, Me.udSlowPreset1Prm_c3.Value * 1000)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(8, Me.udSlowPreset2Prm_c3.Value * 1000)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(9, Me.udSlowPreset3Prm_c3.Value * 1000)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(10, Me.udStopPresetPrm_c3.Value * 1000)
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(11, Me.udnPosOffsetPct_c3.Value)
        Me.SafetyConfigCalc_c3()
        Me.AxTndNTagWrite1Prm_c3.UpdateLongValue(12, Me.lnSafetyConfigPrm_c3)

        nrc_w = Me.AxTndNTagWrite1Prm_c3.Write()
        Me.lnTndNTagWrite1StatPrm_c3 = nrc_w

        If nrc_w = ThinkAndDoSuccess Then
            ' Success
            Me.lblWriteErrorPrm_c3.Visible = False
            Me.AxTndNTagWrite2Prm_c3.UpdateLongValue(0, 1) ' WriteRetentiveData
            Me.AxTndNTagWrite2Prm_c3.Write()
            Me.tmrPrm_c3.Enabled = True
        Else
            ' Failure
            Me.lblWriteErrorPrm_c3.Visible = True
            Me.ButtonsEnabledPrm_c3()
        End If

    End Sub

    Private Sub tmrPrm_c3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPrm_c3.Tick
        Me.tmrPrm_c3.Enabled = False
        Me.AxTndNTagWrite2Prm_c3.UpdateLongValue(0, 0) ' WriteRetentiveData
        Me.AxTndNTagWrite2Prm_c3.Write()
        Me.ReadTagsPrm_c3()
        Me.ButtonsEnabledPrm_c3()
    End Sub

    Private Sub ButtonsDisabledPrm_c3()
        Me.btnReadPrm_c3.Enabled = False
        Me.btnWritePrm_c3.Enabled = False
    End Sub

    Private Sub ButtonsEnabledPrm_c3()
        Me.btnReadPrm_c3.Enabled = True
        Me.btnWritePrm_c3.Enabled = True
    End Sub

    Private Sub btnEncoderStart_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncoderStart_c3.Click
        If Not Me.lbEncoderStart_c3 And Not Me.lbSR1_EncoderSetup_c3 Then
            Me.lbEncoderStart_c3 = True
        End If
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub btnEncoderStop_c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbEncoderStart_c3 Then
            Me.lbEncoderStop_c3 = True
        End If
        Me.SetFocusReqBin_c3()
    End Sub

    Private Sub tmrEncoderStart_c3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStart_c3.Tick
        Me.lbEncoderStart_c3 = False
        Me.tmrEncoderStart_c3.Enabled = False
    End Sub

    Private Sub tmrEncoderStop_c3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStop_c3.Tick
        Me.lbEncoderStop_c3 = False
        Me.tmrEncoderStop_c3.Enabled = False
    End Sub

    Private Sub EncoderSetupColors_c3()
        If Me.lbSR1_EncoderSetup_c3 Then Me.btnEncoderStart_c3.BackColor = Color.Lime Else Me.btnEncoderStart_c3.UseVisualStyleBackColor = True
        'If Me.lbEncoderStop_c3 Then Me.btnEncoderStop_c3.BackColor = Color.Red Else Me.btnEncoderStop_c3.UseVisualStyleBackColor = True
    End Sub

    Private Sub TabPageSetup_c4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageSetup_c4.Enter
        Me.PrmLoad_c4()
    End Sub

    Private Sub PrmLoad_c4()

        If Me.lbPrmLoad_c4 Then

            If Not Me.lbReadErrorPrm_c4 And Not Me.lbWriteErrorPrm_c4 Then
                Me.ReadTagsPrm_c4()
            End If
        Else

            Me.lblReadErrorPrm_c4.Visible = False
            Me.lblWriteErrorPrm_c4.Visible = False

            Dim nrc As Short

            ' Connect to the tndstation
            Me.AxTndNTagReadPrm_c4.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite1Prm_c4.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagWrite2Prm_c4.RuntimeTargetType = TnDTargetType
            Me.AxTndNTagReadPrm_c4.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite1Prm_c4.ThinkAndDoStationName = Me.lcTndStation
            Me.AxTndNTagWrite2Prm_c4.ThinkAndDoStationName = Me.lcTndStation

            If (ThinkAndDoSuccess = Me.AxTndNTagReadPrm_c4.Connect) Then
                ' Register tags
                nrc = Me.AxTndNTagReadPrm_c4.StartTagList()
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 4, "") ' NumBins
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 94, "") ' Ratio
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 106, "") ' BinTolPct
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 64, "") ' ControlType
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 58, "") ' ManModeMotorDelay
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(FlagType, 165, "") ' CarouselEnabled
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 82, "") ' StepsPerRev
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 112, "") ' SlowPreset1
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 118, "") ' SlowPreset2
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 124, "") ' SlowPreset3
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 100, "") ' StopPreset
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 88, "") ' Offset
                nrc = Me.AxTndNTagReadPrm_c4.AddToTagList(NumberType, 295, "") ' SafetyConfig
                nrc = Me.AxTndNTagReadPrm_c4.EndTagList()
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite1Prm_c4.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite1Prm_c4.StartTagList()
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 4, "") ' NumBins
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 94, "") ' Ratio
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 106, "") ' BinTolPct
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 64, "") ' ControlType
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 58, "") ' ManModeMotorDelay
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(FlagType, 165, "") ' CarouselEnabled
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 82, "") ' StepsPerRev
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 112, "") ' SlowPreset1
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 118, "") ' SlowPreset2
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 124, "") ' SlowPreset3
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 100, "") ' StopPreset
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 88, "") ' Offset
                    nrc = Me.AxTndNTagWrite1Prm_c4.AddToTagList(NumberType, 295, "") ' SafetyConfig
                    nrc = Me.AxTndNTagWrite1Prm_c4.EndTagList()
                    Me.ReadTagsPrm_c4()
                Else
                    MsgBox("Cannot connect Write1Prm_c4 to controller.")
                    Me.lblWriteErrorPrm_c4.Visible = True
                End If
                If (ThinkAndDoSuccess = Me.AxTndNTagWrite2Prm_c4.Connect) Then
                    ' Register tags
                    nrc = Me.AxTndNTagWrite2Prm_c4.StartTagList()
                    nrc = Me.AxTndNTagWrite2Prm_c4.AddToTagList(SystemType, 43, "") ' WriteRetentiveData
                    nrc = Me.AxTndNTagWrite2Prm_c4.EndTagList()
                    Me.WriteTagsPrm_c4()
                    Me.ReadTagsPrm_c4()
                Else
                    MsgBox("Cannot connect Write2Prm_c4 to controller.")
                    Me.lblWriteErrorPrm_c4.Visible = True
                    Me.lbWriteErrorPrm_c4 = True
                End If
            Else
                MsgBox("Cannot connect Read1Prm_c4 to controller.")
                Me.lblReadErrorPrm_c4.Visible = True
                Me.lbReadErrorPrm_c4 = True
            End If

            Me.lbPrmLoad_c4 = True

        End If

    End Sub

    Private Sub btnReadPrm_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadPrm_c4.Click
        If Not Me.lbReadErrorPrm_c4 And Not Me.lbWriteErrorPrm_c4 Then
            Me.ReadTagsPrm_c4()
        End If
    End Sub

    Private Sub btnWritePrm_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWritePrm_c4.Click
        If Not Me.lbReadErrorPrm_c4 And Not Me.lbWriteErrorPrm_c4 Then
            Me.WriteTagsPrm_c4()
        End If
    End Sub

    Private Sub ReadTagsPrm_c4()

        Me.lblPW_c4.Visible = True
        Me.lblPW_c4.Refresh()

        Me.ButtonsDisabledPrm_c4()

        Me.udNumBinsPrm_c4.Minimum = 6
        Me.udNumBinsPrm_c4.Maximum = 999
        Me.udControlTypePrm_c4.Minimum = 1
        Me.udControlTypePrm_c4.Maximum = 2
        Me.udMMMDelayPrm_c4.Minimum = 1000
        Me.udMMMDelayPrm_c4.Maximum = 10000
        Me.udMMMDelayPrm_c4.Increment = 100
        Me.udStepsPerRevPrm_c4.Minimum = 0
        Me.udStepsPerRevPrm_c4.Maximum = 32767
        Me.udnPosOffsetPct_c4.Minimum = -100
        Me.udnPosOffsetPct_c4.Maximum = 100

        Me.udRatioPrm_c4.Minimum = 11
        Me.udRatioPrm_c4.Maximum = 99
        Me.udRatioPrm_c4.Increment = 1

        Me.udBinTolPctPrm_c4.Minimum = 0.1
        Me.udBinTolPctPrm_c4.Maximum = 10
        Me.udBinTolPctPrm_c4.Increment = 0.1

        Me.udBinTolPctPrm_c4.Minimum = 0.1
        Me.udBinTolPctPrm_c4.Maximum = 10
        Me.udBinTolPctPrm_c4.Increment = 0.1

        Me.udSlowPreset1Prm_c4.Minimum = 2
        Me.udSlowPreset1Prm_c4.Maximum = 3
        Me.udSlowPreset1Prm_c4.Increment = 0.5

        Me.udSlowPreset2Prm_c4.Minimum = 0.75
        Me.udSlowPreset2Prm_c4.Maximum = 1
        Me.udSlowPreset2Prm_c4.Increment = 0.05

        Me.udSlowPreset3Prm_c4.Minimum = 0.1
        Me.udSlowPreset3Prm_c4.Maximum = 0.5
        Me.udSlowPreset3Prm_c4.Increment = 0.001

        Me.udStopPresetPrm_c4.Minimum = 0.005
        Me.udStopPresetPrm_c4.Maximum = 0.09
        Me.udStopPresetPrm_c4.Increment = 0.001

        Dim nrc_r As Short

        ' Read tags
        nrc_r = AxTndNTagReadPrm_c4.Read()
        Me.lnTndNTagRead1StatPrm_c4 = nrc_r

        If nrc_r = ThinkAndDoSuccess Then
            Me.lnNumBinsPrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(0)
            Me.lnRatioPrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(1)
            Me.lnBinTolPctPrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(2)
            Me.lnControlTypePrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(3)
            Me.lnMMMDelayPrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(4)
            Me.chkEnabledPrm_c4.Checked = AxTndNTagReadPrm_c4.GetValueAt(5)
            Me.lnStepsPerRevPrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(6)
            Me.lnSlowPreset1Prm_c4 = AxTndNTagReadPrm_c4.GetValueAt(7)
            Me.lnSlowPreset2Prm_c4 = AxTndNTagReadPrm_c4.GetValueAt(8)
            Me.lnSlowPreset3Prm_c4 = AxTndNTagReadPrm_c4.GetValueAt(9)
            Me.lnStopPresetPrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(10)
            Me.nPosOffsetPct_c4 = AxTndNTagReadPrm_c4.GetValueAt(11)
            Me.lnSafetyConfigPrm_c4 = AxTndNTagReadPrm_c4.GetValueAt(12)
            Me.lblReadErrorPrm_c4.Visible = False
        Else
            MsgBox("Cannot read tags from controller ReadTagsPrm_c4")
            Me.lblReadErrorPrm_c4.Visible = True
            Me.chkEnabledPrm_c4.Checked = False
        End If

        Me.udNumBinsPrm_c4.Value = Me.lnNumBinsPrm_c4
        Me.udRatioPrm_c4.Value = Me.lnRatioPrm_c4
        Me.udBinTolPctPrm_c4.Value = Me.lnBinTolPctPrm_c4 / 10
        Me.udControlTypePrm_c4.Value = Me.lnControlTypePrm_c4
        Me.udMMMDelayPrm_c4.Value = Me.lnMMMDelayPrm_c4
        Me.udStepsPerRevPrm_c4.Value = Me.lnStepsPerRevPrm_c4
        Me.udnPosOffsetPct_c4.Value = Me.nPosOffsetPct_c4
        Me.udSlowPreset1Prm_c4.Value = Me.lnSlowPreset1Prm_c4 / 1000
        Me.udSlowPreset2Prm_c4.Value = Me.lnSlowPreset2Prm_c4 / 1000
        Me.udSlowPreset3Prm_c4.Value = Me.lnSlowPreset3Prm_c4 / 1000
        Me.udStopPresetPrm_c4.Value = Me.lnStopPresetPrm_c4 / 1000

        ' Breakout SafetyConfig
        Me.chkES1_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 0
        Me.chkES2_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 1
        Me.chkES3_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 2
        Me.chkES4_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 3
        Me.chkES5_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 4
        Me.chkES6_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 5
        Me.chkES7_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 6
        Me.chkES8_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 7
        '
        Me.chkPE1_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 8
        Me.chkPE2_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 9
        Me.chkPE3_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 10
        Me.chkPE4_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 11
        Me.chkPE5_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 12
        Me.chkPE6_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 13
        Me.chkPE7_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 14
        Me.chkPE8_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 15
        '
        Me.chkLG1_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 16
        Me.chkLG2_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 17
        Me.chkLG3_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 18
        Me.chkLG4_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 19
        Me.chkLG5_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 20
        Me.chkLG6_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 21
        Me.chkLG7_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 22
        Me.chkLG8_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 23
        '
        Me.chkMT1_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 24
        Me.chkMT2_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 25
        Me.chkMT3_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 26
        Me.chkMT4_c4.Checked = Me.lnSafetyConfigPrm_c4 And 2 ^ 27

        Me.lblPW_c4.Visible = False
        Me.lblPW_c4.Refresh()

        Me.ButtonsEnabledPrm_c4()

    End Sub

    Private Sub SafetyConfigCalc_c4()
        Me.lnSafetyConfigPrm_c4 = 0
        If Me.chkES1_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 0
        If Me.chkES2_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 1
        If Me.chkES3_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 2
        If Me.chkES4_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 3
        If Me.chkES5_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 4
        If Me.chkES6_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 5
        If Me.chkES7_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 6
        If Me.chkES8_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 7
        '
        If Me.chkPE1_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 8
        If Me.chkPE2_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 9
        If Me.chkPE3_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 10
        If Me.chkPE4_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 11
        If Me.chkPE5_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 12
        If Me.chkPE6_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 13
        If Me.chkPE7_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 14
        If Me.chkPE8_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 15
        '
        If Me.chkLG1_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 16
        If Me.chkLG2_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 17
        If Me.chkLG3_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 18
        If Me.chkLG4_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 19
        If Me.chkLG5_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 20
        If Me.chkLG6_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 21
        If Me.chkLG7_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 22
        If Me.chkLG8_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 23
        '
        If Me.chkMT1_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 24
        If Me.chkMT2_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 25
        If Me.chkMT3_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 26
        If Me.chkMT4_c4.Checked Then Me.lnSafetyConfigPrm_c4 += 2 ^ 27
    End Sub

    Private Sub WriteTagsPrm_c4()

        Me.lblPW_c4.Visible = True
        Me.lblPW_c4.Refresh()

        Me.ButtonsDisabledPrm_c4()

        Dim nrc_w As Short

        ' Write tags
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(0, Me.udNumBinsPrm_c4.Value)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(1, Me.udRatioPrm_c4.Value)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(2, Me.udBinTolPctPrm_c4.Value * 10)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(3, Me.udControlTypePrm_c4.Value)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(4, Me.udMMMDelayPrm_c4.Value)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(5, Val(Me.chkEnabledPrm_c4.Checked))
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(6, Me.udStepsPerRevPrm_c4.Value)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(7, Me.udSlowPreset1Prm_c4.Value * 1000)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(8, Me.udSlowPreset2Prm_c4.Value * 1000)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(9, Me.udSlowPreset3Prm_c4.Value * 1000)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(10, Me.udStopPresetPrm_c4.Value * 1000)
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(11, Me.udnPosOffsetPct_c4.Value)
        Me.SafetyConfigCalc_c4()
        Me.AxTndNTagWrite1Prm_c4.UpdateLongValue(12, Me.lnSafetyConfigPrm_c4)

        nrc_w = Me.AxTndNTagWrite1Prm_c4.Write()
        Me.lnTndNTagWrite1StatPrm_c4 = nrc_w

        If nrc_w = ThinkAndDoSuccess Then
            ' Success
            Me.lblWriteErrorPrm_c4.Visible = False
            Me.AxTndNTagWrite2Prm_c4.UpdateLongValue(0, 1) ' WriteRetentiveData
            Me.AxTndNTagWrite2Prm_c4.Write()
            Me.tmrPrm_c4.Enabled = True
        Else
            ' Failure
            Me.lblWriteErrorPrm_c4.Visible = True
            Me.ButtonsEnabledPrm_c4()
        End If

    End Sub

    Private Sub tmrPrm_c4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPrm_c4.Tick
        Me.tmrPrm_c4.Enabled = False
        Me.AxTndNTagWrite2Prm_c4.UpdateLongValue(0, 0) ' WriteRetentiveData
        Me.AxTndNTagWrite2Prm_c4.Write()
        Me.ReadTagsPrm_c4()
        Me.ButtonsEnabledPrm_c4()
    End Sub

    Private Sub ButtonsDisabledPrm_c4()
        Me.btnReadPrm_c4.Enabled = False
        Me.btnWritePrm_c4.Enabled = False
    End Sub

    Private Sub ButtonsEnabledPrm_c4()
        Me.btnReadPrm_c4.Enabled = True
        Me.btnWritePrm_c4.Enabled = True
    End Sub

    Private Sub btnEncoderStart_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncoderStart_c4.Click
        If Not Me.lbEncoderStart_c4 And Not Me.lbSR1_EncoderSetup_c4 Then
            Me.lbEncoderStart_c4 = True
        End If
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub btnEncoderStop_c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Me.lbEncoderStart_c4 Then
            Me.lbEncoderStop_c4 = True
        End If
        Me.SetFocusReqBin_c4()
    End Sub

    Private Sub tmrEncoderStart_c4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStart_c4.Tick
        Me.lbEncoderStart_c4 = False
        Me.tmrEncoderStart_c4.Enabled = False
    End Sub

    Private Sub tmrEncoderStop_c4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEncoderStop_c4.Tick
        Me.lbEncoderStop_c4 = False
        Me.tmrEncoderStop_c4.Enabled = False
    End Sub

    Private Sub EncoderSetupColors_c4()
        If Me.lbSR1_EncoderSetup_c4 Then Me.btnEncoderStart_c4.BackColor = Color.Lime Else Me.btnEncoderStart_c4.UseVisualStyleBackColor = True
        'If Me.lbEncoderStop_c4 Then Me.btnEncoderStop_c4.BackColor = Color.Red Else Me.btnEncoderStop_c4.UseVisualStyleBackColor = True
    End Sub

End Class
