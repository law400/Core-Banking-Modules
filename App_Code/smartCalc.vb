Imports Microsoft.VisualBasic

Public Class smartCalc
    Public Enum irEnum
        Monthly = 12
        Weekly = 52
        BiWeekly = 26
        BiMontly = 6
        Annually = 1
        SemiAnnually = 2
        Quarterly = 4
        Daily = 365
    End Enum

    Public Shared Function MKCalcInterest_iR12(ByVal NumPay As Double, ByVal Payment As Double, ByVal NPV As Double, ByVal FV As Double, _
       ByVal bStart As Int32) As String
        '{
        ' Start with an arbitrary 1% Interest rate
        Dim IntRate As Double
        Dim iPer As Double
        IntRate = 1.0 / 1200.0
        NPV *= (-1)
        iPer = Math.Log((Payment + Payment * IntRate * bStart - FV * IntRate) / _
            (NPV * IntRate + Payment + Payment * IntRate * bStart)) / _
             Math.Log(1 + IntRate)

        If (iPer > NumPay) Then
            '{
            Do While (iPer > NumPay)
                '{
                IntRate -= 0.000001
                iPer = Math.Log((Payment + Payment * IntRate * bStart - FV * IntRate) / _
                     (NPV * IntRate + Payment + Payment * IntRate * bStart)) / _
                    Math.Log(1 + IntRate)
                '}
            Loop
            '}
        Else
            '{
            Do While (iPer < NumPay)
                '{
                IntRate += 0.000001
                iPer = Math.Log((Payment + Payment * IntRate * bStart - FV * IntRate) / _
                     (NPV * IntRate + Payment + Payment * IntRate * bStart)) / _
                    Math.Log(1 + IntRate)
                '}
            Loop
            '}
        End If
        Return IntRate * 1200.0
        '}
    End Function

    Public Shared Function MKCalcInterest(ByVal iR As Int32, ByVal NumPay As Double, ByVal Payment As Double, ByVal NPV As Double, ByVal FV As Double, _
      ByVal bStart As Int32) As String
        '{
        ' Start with an arbitrary 1% Interest rate
        Dim IntRate As Double
        Dim iPer As Double
        IntRate = 1.0 / (iR * 100.0)
        NPV *= (-1)
        iPer = Math.Log((Payment + Payment * IntRate * bStart - FV * IntRate) / _
            (NPV * IntRate + Payment + Payment * IntRate * bStart)) / _
             Math.Log(1 + IntRate)

        If (iPer > NumPay) Then
            '{
            Do While (iPer > NumPay)
                '{
                IntRate -= 0.000001
                iPer = Math.Log((Payment + Payment * IntRate * bStart - FV * IntRate) / _
                     (NPV * IntRate + Payment + Payment * IntRate * bStart)) / _
                    Math.Log(1 + IntRate)
                '}
            Loop
            '}
        Else
            '{
            Do While (iPer < NumPay)
                '{
                IntRate += 0.000001
                iPer = Math.Log((Payment + Payment * IntRate * bStart - FV * IntRate) / _
                     (NPV * IntRate + Payment + Payment * IntRate * bStart)) / _
                    Math.Log(1 + IntRate)
                '}
            Loop
            '}
        End If
        Return IntRate * iR * 100.0
        '}
    End Function

    'Public Function MKCalcPayment(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32) As Double
    '    Dim P As Double
    '    IntRate = IntRate / (iR * 100.0)
    '    P = (NPV * Math.Pow(1 + IntRate, NumPay) + FV) / _
    '           ((1 + IntRate * bStart) * ((Math.Pow((1 + IntRate), NumPay) - 1) / _
    '           IntRate))
    '    Return P '* (-1) ' // Just convert it into a positive value.
    '    '}
    'End Function

    Public Shared Function InterestPortionTotal(ByVal NPV As Double, ByVal IntRate As Double, ByVal TimeLength As Int32, ByVal iR As Double) As Double
        '(A6*19.05/100)*(E6/12)/E6
        Dim FinalVal As Double
        FinalVal = (NPV * IntRate / 100) * (TimeLength / iR)
        Return FinalVal
    End Function
    Public Shared Function InterestPortionTotalInd(ByVal NPV As Double, ByVal IntRate As Double, ByVal TimeLength As Int32, ByVal iR As Double) As Double
        '(A6*19.05/100)*(E6/12)/E6
        Dim FinalVal As Double
        FinalVal = (NPV * IntRate / 100)
        Return FinalVal
    End Function
    Public Shared Function InterestPortionTotalST(ByVal NPV As Double, ByVal IntRate As Double, ByVal TimeLength As Int32, ByVal iR As Double) As Double
        '(A6*19.05/100)*(E6/12)/E6
        Dim FinalVal As Double
        FinalVal = (NPV * IntRate * 12 * iR) / 36500
        Return FinalVal
    End Function

    Public Shared Function InterestPortionPERiR(ByVal NPV As Double, ByVal IntRate As Double, ByVal TimeLength As Int32, ByVal iR As Double) As Double
        '(A6*19.05/100)*(E6/12)/E6
        Dim FinalVal As Double
        FinalVal = (NPV * IntRate / 100) * (TimeLength / iR) / TimeLength
        Return FinalVal
    End Function
    Public Shared Function InterestPortionPERiR3(ByVal NPV As Double, ByVal IntRate As Double, ByVal TimeLength As Int32, ByVal iR As Int32) As Double
        '(A6*19.05/100)*(E6/12)/E6
        Dim FinalVal As Double
        FinalVal = (NPV * IntRate * 12 * TimeLength) / (100 * iR)

        Return FinalVal
    End Function


    Public Shared Function MKCalcPayment(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32) As Double
        Dim P As Double
        IntRate = IntRate / (iR * 100.0)
        P = (NPV * Math.Pow(1 + IntRate, NumPay) + FV) / _
               ((1 + IntRate * bStart) * ((Math.Pow((1 + IntRate), NumPay) - 1) / _
               IntRate))
        Return P '* (-1) ' // Just convert it into a positive value.
        '}
    End Function

    Public Shared Function ScheduleReducingBal(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32) As System.Collections.ArrayList
        Dim sPayment As New System.Collections.ArrayList
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0

        Do While i < NumPay

            Period = NumPay - i
            If i = 0 Then
                EMIvalue = Math.Round(MKCalcPayment(iR, NumPay, IntRate, NPV, FV, bStart), 2)
                currentEMI = EMIvalue
                currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                i = i + 1
            Else
                currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                currentEMI = EMIvalue
                i = i + 1

                If i = 24 Then
                    Dim m As Int32 = i
                End If

            End If

            If i = NumPay And NextNPV <> 0 Then
                currenrPrincipal = currenrPrincipal + NextNPV
                currentEMI = EMIvalue + NextNPV
                NextNPV = NextNPV - NextNPV
                Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                If x <> 0 Then
                    cummulativePrincipal = cummulativePrincipal + x
                End If

            End If

            Dim xx As New System.Collections.ArrayList
            cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
            cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
            xx.Add(currenrPrincipal)
            xx.Add(currentInterest)
            xx.Add(currentEMI)
            xx.Add(Period)
            xx.Add(i)
            OutstandingBal = NextNPV
            xx.Add(OutstandingBal)
            sPayment.Add(xx)

        Loop


        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function
    Public Shared Sub SetIrEnumVals(ByRef mIr As Int32, ByRef incr As String)
        If mIr = irEnum.Monthly Then
            incr = "m"
            mIr = 1
        ElseIf mIr = irEnum.Annually Then
            incr = "y"
            mIr = 1
        ElseIf mIr = irEnum.SemiAnnually Then
            incr = "m"
            mIr = 6
        ElseIf mIr = irEnum.Quarterly Then
            incr = "M"
            mIr = 3
        ElseIf mIr = irEnum.BiMontly Then
            incr = "m"
            mIr = 2
        ElseIf mIr = irEnum.Weekly Then
            incr = "d"
            mIr = 7
        ElseIf mIr = irEnum.BiWeekly Then
            incr = "d"
            mIr = 14
        ElseIf mIr = irEnum.Daily Then
            incr = "d"
            mIr = 1
        End If
    End Sub
    Public Shared Function IsvalidMir(ByVal mIr As Int32) As Boolean
        Dim retVal As Boolean = False
        If mIr = irEnum.Monthly Then
            retVal = True
        ElseIf mIr = irEnum.Annually Then
            retVal = True
        ElseIf mIr = irEnum.SemiAnnually Then
            retVal = True
        ElseIf mIr = irEnum.Quarterly Then
            retVal = True
        ElseIf mIr = irEnum.BiMontly Then
            retVal = True
        ElseIf mIr = irEnum.Weekly Then
            retVal = True
        ElseIf mIr = irEnum.BiWeekly Then
            retVal = True
        ElseIf mIr = irEnum.Daily Then
            retVal = True
        Else
            retVal = False
        End If
        Return retVal
    End Function

    Public Shared Function RecalcTenorForDailyPayments(ByVal FirstPmtDate As Date, ByVal TotalTenor As Int32) As Int32
        Dim tenor As Int32 = 0
        Dim kpDate As Date = FirstPmtDate
        Dim k As Int32 = 0
        Dim dtPart As Int32 = 0
        For k = 1 To TotalTenor
            If k = 1 Then
                kpDate = DateAdd(DateInterval.Day, 0, kpDate)
            Else
                kpDate = DateAdd(DateInterval.Day, 1, kpDate)
            End If

            'dtPart = Weekday(kpDate)
            ' If dtPart <> 1 Then
            tenor = tenor + 1
            ' End If


            'dtPart = DatePart(DateInterval.Weekday, kpDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
        Next
        Return tenor
    End Function

    Public Shared Function theDayIsSunday(ByVal theDate As Date) As Boolean
        Dim dtPart As Int32 = 0
        'dtPart = DatePart(DateInterval.Weekday, theDate, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
        dtPart = Weekday(theDate)
        If dtPart <> 1 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function ScheduleReducingBal(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal RepayType As Int32) As binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = StartDate
        Dim xcurrentDate As String = ""
        Dim xcurrentDate2 As String

        Dim n As Integer
        Dim mIr As Int32 = iR
        Dim incr As String = ""
        If mIr = irEnum.Monthly Then
            incr = "m"
            mIr = 1
            n = 1
        ElseIf mIr = irEnum.Annually Then
            incr = "y"
            mIr = 0.083
            n = 12
        ElseIf mIr = irEnum.SemiAnnually Then
            incr = "m"
            mIr = 0.167
            n = 6
        ElseIf mIr = irEnum.Quarterly Then
            incr = "m"
            mIr = 0.25
            n = 4
        ElseIf mIr = irEnum.BiMontly Then
            incr = "m"
            mIr = 0.5
            n = 2
        ElseIf mIr = irEnum.Weekly Then
            incr = "d"
            mIr = 4
            n = 7
        ElseIf mIr = irEnum.BiWeekly Then
            incr = "d"
            mIr = 2
            n = 14
        Else : mIr = irEnum.Daily
            incr = "d"
            n = 1
            If NumPay < 30 Then
                mIr = NumPay

            Else
                mIr = mIr

            End If
            'Dim x As New SmartArrayClass
            'x.ErrorCode = -99
            'x.ErrorString = "Invalid date Range"
            'Return x
        End If

        Dim totalInterest1 As Double = 0
        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0
        iR = mIr
        If RepayType <> 3 Then
            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    ''Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                    Dim totalBalance = currentNPV
                    EMIvalue = totalBalance / NumPay
                    currentInterest = Math.Round(InterestPortionTotalInd(totalBalance, IntRate, Period, iR), 2)
                    ''currentInterest = Math.Round((totalBalance / NumPay), 2)
                    currentEMI = EMIvalue + currentInterest

                    currenrPrincipal = Math.Round((EMIvalue), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1

                    ' If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    currentInterest = Math.Round(InterestPortionTotalInd(NextNPV, IntRate, Period, iR), 2)
                    currenrPrincipal = Math.Round((EMIvalue), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue + currentInterest
                    i = i + 1

                    currentDate = DateAdd(incr, n, currentDate)

                    'If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If


                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = currenrPrincipal + NextNPV
                    currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If

                End If

                Dim xx As New System.Collections.ArrayList
                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)

                currentInterest = Math.Round((currentInterest), 2)

                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                'sPayment.Add(xx)
                currentEMI = Math.Round((currentEMI), 2)
                Dim xx1 As New SmartItems

                If bStart = 2 Then
                    xx1.setValues(currenrPrincipal, 0, currentEMI - currentInterest, OutstandingBal, Period, i, "P", xcurrentDate, xcurrentDate2)
                    sPayment.Add(xx1)

                Else
                    xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                    sPayment.Add(xx1)

                End If

            Loop
        Else

            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                    Dim totalBalance = currentNPV + totalInterest
                    EMIvalue = totalBalance / NumPay
                    '' currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                    currentInterest = totalInterest / NumPay
                    currenrPrincipal = 0  'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    currentEMI = currentInterest + currenrPrincipal

                    i = i + 1

                    ' If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    currentInterest = currentInterest
                    currenrPrincipal = 0 'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = currentInterest + currenrPrincipal
                    i = i + 1

                    currentDate = DateAdd(incr, n, currentDate)

                    'If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If


                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = currenrPrincipal + NextNPV
                    '' currentEMI = EMIvalue + NextNPV
                    currentEMI = currentInterest + currenrPrincipal

                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If

                End If

                Dim xx As New System.Collections.ArrayList
                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)

                currentInterest = Math.Round((currentInterest), 2)

                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                'sPayment.Add(xx)
                currentEMI = Math.Round((currentEMI), 2)

                Dim xx1 As New SmartItems
                If bStart = 2 Then
                    xx1.setValues(currenrPrincipal, 0, currentEMI - currentInterest, OutstandingBal, Period, i, "P", xcurrentDate, xcurrentDate2)


                Else
                    If i = NumPay Then
                        xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                    Else
                        xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "I", xcurrentDate, xcurrentDate2)

                    End If
                End If

                sPayment.Add(xx1)

            Loop



        End If

        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function

    'Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
    'Dim totalBalance = currentNPV + totalInterest

    Public Shared Function ScheduleFlatRate(ByVal iR As Double, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal Repaytype As Int32) As Binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = StartDate
        Dim xcurrentDate As String = ""
        Dim xcurrentDate2 As String

        Dim n As Integer
        Dim mIr As Int32 = iR
        Dim incr As String = ""
        If mIr = irEnum.Monthly Then
            incr = "m"
            mIr = 1
            n = 1
        ElseIf mIr = irEnum.Annually Then
            incr = "y"
            mIr = 0.083
            n = 12
        ElseIf mIr = irEnum.SemiAnnually Then
            incr = "m"
            mIr = 0.167
            n = 6
        ElseIf mIr = irEnum.Quarterly Then
            incr = "m"
            mIr = 0.25
            n = 4
        ElseIf mIr = irEnum.BiMontly Then
            incr = "m"
            mIr = 0.5
            n = 2
        ElseIf mIr = irEnum.Weekly Then
            incr = "d"
            mIr = 4
            n = 7
        ElseIf mIr = irEnum.BiWeekly Then
            incr = "d"
            mIr = 2
            n = 14
        Else : mIr = irEnum.Daily
            incr = "d"
            n = 1
            If NumPay < 30 Then
                mIr = NumPay

            Else
                mIr = mIr

            End If
            'Dim x As New SmartArrayClass
            'x.ErrorCode = -99
            'x.ErrorString = "Invalid date Range"
            'Return x
        End If

        Dim totalInterest1 As Double = 0
        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0
        iR = mIr
        If Repaytype <> 3 Then
            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                    Dim totalBalance = currentNPV + totalInterest
                    EMIvalue = totalBalance / NumPay
                    currentEMI = EMIvalue
                    currentInterest = totalInterest / NumPay
                    ''currentInterest = Math.Round((totalBalance / NumPay), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1

                    ' If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    currentInterest = currentInterest
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue
                    i = i + 1

                    currentDate = DateAdd(incr, n, currentDate)

                    'If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If


                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = currenrPrincipal + NextNPV
                    currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If

                End If

                Dim xx As New System.Collections.ArrayList
                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 4)

                currentInterest = Math.Round((currentInterest), 4)

                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                'sPayment.Add(xx)
                currentEMI = Math.Round((currentEMI), 2)
                Dim xx1 As New SmartItems

                If bStart = 2 Then
                    xx1.setValues(currenrPrincipal, 0, currentEMI - currentInterest, OutstandingBal, Period, i, "P", xcurrentDate, xcurrentDate2)
                    sPayment.Add(xx1)

                Else
                    xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                    sPayment.Add(xx1)

                End If

            Loop
        Else

            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                    Dim totalBalance = currentNPV + totalInterest
                    EMIvalue = totalBalance / NumPay
                    '' currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                    currentInterest = totalInterest / NumPay
                    currenrPrincipal = 0  'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    currentEMI = currentInterest + currenrPrincipal

                    i = i + 1

                    ' If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    currentInterest = currentInterest
                    currenrPrincipal = 0 'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = currentInterest + currenrPrincipal
                    i = i + 1

                    currentDate = DateAdd(incr, n, currentDate)

                    'If iR = LoanMaster.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If


                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = currenrPrincipal + NextNPV
                    '' currentEMI = EMIvalue + NextNPV
                    currentEMI = currentInterest + currenrPrincipal

                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If

                End If

                Dim xx As New System.Collections.ArrayList
                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 4)

                currentInterest = Math.Round((currentInterest), 4)

                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                'sPayment.Add(xx)
                currentEMI = Math.Round((currentEMI), 2)

                Dim xx1 As New SmartItems
                If bStart = 2 Then
                    xx1.setValues(currenrPrincipal, 0, currentEMI - currentInterest, OutstandingBal, Period, i, "P", xcurrentDate, xcurrentDate2)


                Else
                    If i = NumPay Then
                        xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                    Else
                        xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "I", xcurrentDate, xcurrentDate2)

                    End If
                End If

                sPayment.Add(xx1)

            Loop



        End If

        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function

    Public Shared Function ScheduleFlatRate(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32) As System.Collections.ArrayList
        Dim sPayment As New System.Collections.ArrayList
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = Date.Now
        Dim xcurrentDate As String = ""


        Dim mIr As Int32 = iR
        Dim incr As String = ""
        If mIr = irEnum.Monthly Then
            incr = "m"
            mIr = 1
        ElseIf mIr = irEnum.Annually Then
            incr = "y"
            mIr = mIr * 1
        ElseIf mIr = irEnum.SemiAnnually Then
            incr = "m"
            mIr = mIr * 6
        ElseIf mIr = irEnum.Quarterly Then
            incr = "m"
            mIr = mIr * 3
        ElseIf mIr = irEnum.BiMontly Then
            incr = "m"
            mIr = mIr * 2
        ElseIf mIr = irEnum.Weekly Then
            incr = "d"
            mIr = mIr * 7
        ElseIf mIr = irEnum.BiWeekly Then
            incr = "d"
            mIr = mIr * 14
        Else
            Dim x As New Binders
            x.ErrorCode = -99
            x.ErrorString = "Invalid date Range"
            Return x
        End If



        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0


        Do While i < NumPay

            Period = NumPay - i
            If i = 0 Then
                Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                Dim totalBalance = currentNPV + totalInterest
                EMIvalue = totalBalance / NumPay
                IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                currentEMI = EMIvalue
                currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                i = i + 1
            Else
                currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                currentEMI = EMIvalue
                i = i + 1

                currentDate = DateAdd(incr, mIr, currentDate)
                xcurrentDate = Format(currentDate, "dd/MM/yyyy")

                If i = 24 Then
                    Dim m As Int32 = i
                End If

            End If


            If i = NumPay And NextNPV <> 0 Then
                currenrPrincipal = currenrPrincipal + NextNPV
                currentEMI = EMIvalue + NextNPV
                NextNPV = NextNPV - NextNPV
                Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                If x <> 0 Then
                    cummulativePrincipal = cummulativePrincipal + x
                End If

            End If

            Dim xx As New System.Collections.ArrayList
            cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
            cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
            xx.Add(currenrPrincipal)
            xx.Add(currentInterest)
            xx.Add(currentEMI)
            xx.Add(Period)
            xx.Add(i)
            OutstandingBal = NextNPV
            xx.Add(OutstandingBal)
            sPayment.Add(xx)

            'Dim xx1 As New smartitems()
            'xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate)
            'sPayment.Add(xx1)

        Loop

        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function
    Public Shared Function ScheduleStraightLineRateTD2(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal repaytype As Int32, ByVal Inttax As Double) As Binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = StartDate
        Dim xcurrentDate As String = ""
        Dim xcurrentDate2 As String = ""


        Dim mIr As Int32 = iR
        Dim incr As String = ""
        If IsvalidMir(mIr) Then
            SetIrEnumVals(mIr, incr)
        Else
            'If mIr = irEnum.Monthly Then
            '    incr = "m"
            '    mIr = 1
            'ElseIf mIr = irEnum.Annually Then
            '    incr = "y"
            '    mIr = 1
            'ElseIf mIr = irEnum.SemiAnnually Then
            '    incr = "m"
            '    mIr = 6
            'ElseIf mIr = irEnum.Quarterly Then
            '    incr = "m"
            '    mIr = 3
            'ElseIf mIr = irEnum.BiMontly Then
            '    incr = "m"
            '    mIr = 2
            'ElseIf mIr = irEnum.Weekly Then
            '    incr = "d"
            '    mIr = 7
            'ElseIf mIr = irEnum.BiWeekly Then
            '    incr = "d"
            '    mIr = 14
            'ElseIf mIr = irEnum.Daily Then
            '    incr = "d"
            '    mIr = 1
            'Else
            Dim x As New Binders
            x.ErrorCode = -99
            x.ErrorString = "Invalid date Range"
            Return x
        End If



        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0

        Dim origperiod As Int32 = NumPay
        Dim origNPV As Double = currentNPV
        Dim NowPrincipal As Double
        Dim PrinValue As Double
        Dim IntValue As Double


        If repaytype = 0 Then
            Dim errorval As Double = 1.172
            Inttax = Inttax * errorval

            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                    totalInterest = totalInterest - Inttax
                    Dim totalBalance = currentNPV + totalInterest

                    Inttax = Inttax / NumPay
                    EMIvalue = totalBalance / NumPay
                    PrinValue = currentNPV / NumPay
                    IntValue = totalInterest / NumPay
                    'IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                    currentEMI = EMIvalue
                    NowPrincipal = Math.Round((currentNPV - PrinValue), 2)
                    currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, iR), 2)
                    currentInterest = currentInterest - Inttax
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    NextNPV = origNPV
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, iR)), 2)
                    currentInterest = currentInterest - Inttax
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue

                    NowPrincipal = NowPrincipal - PrinValue
                    currenrPrincipal = Math.Round(PrinValue, 2)
                    currentInterest = Math.Round(IntValue, 2)
                    NextNPV = Math.Round(NowPrincipal, 2)

                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '   currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If

                currentEMI = Math.Round(currentEMI, 2)

                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = NextNPV
                    'currenrPrincipal(+NextNPV)
                    'currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If
                End If

                Dim xx As New System.Collections.ArrayList
                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
                OutstandingBal = Math.Round(NowPrincipal, 2)
                'Math.Round((NextNPV - currenrPrincipal), 2)
                'NextNPV


                Dim xx1 As New SmartItems()
                xx1.setValues(currenrPrincipal, Math.Round(currentInterest, 2), currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                sPayment.Add(xx1)

            Loop
            ''Else


            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                    Dim totalBalance = currentNPV + totalInterest
                    EMIvalue = totalInterest / NumPay  'totalBalance / NumPay
                    PrinValue = 0 'currentNPV / NumPay
                    IntValue = totalInterest / NumPay
                    'IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                    currentEMI = EMIvalue
                    NowPrincipal = Math.Round((currentNPV - PrinValue), 2)
                    currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, iR), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    NextNPV = origNPV
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, iR)), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue

                    NowPrincipal = NowPrincipal - PrinValue
                    currenrPrincipal = Math.Round(PrinValue, 2)
                    currentInterest = Math.Round(IntValue, 2)
                    NextNPV = Math.Round(NowPrincipal, 2)


                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '   currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If

                currentEMI = Math.Round(currentEMI, 2)

                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = NextNPV
                    'currenrPrincipal(+NextNPV)
                    'currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If
                    currenrPrincipal = currenrPrincipal + x
                    NowPrincipal = NowPrincipal - currenrPrincipal
                    currentEMI = currentEMI + currenrPrincipal
                End If

                Dim xx As New System.Collections.ArrayList
                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
                OutstandingBal = Math.Round(NowPrincipal, 2)

                'Math.Round((NextNPV - currenrPrincipal), 2)
                'NextNPV


                Dim xx1 As New SmartItems()
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                sPayment.Add(xx1)

            Loop

        End If
        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function


    Public Shared Function ScheduleStraightLineRateTD(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal repaytype As Int32, ByVal Intamt As Double) As Binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = StartDate
        Dim xcurrentDate As String = ""
        Dim xcurrentDate2 As String = ""


        Dim mIr As Int32 = iR
        Dim incr As String = ""
        If IsvalidMir(mIr) Then
            SetIrEnumVals(mIr, incr)
        Else
            'If mIr = irEnum.Monthly Then
            '    incr = "m"
            '    mIr = 1
            'ElseIf mIr = irEnum.Annually Then
            '    incr = "y"
            '    mIr = 1
            'ElseIf mIr = irEnum.SemiAnnually Then
            '    incr = "m"
            '    mIr = 6
            'ElseIf mIr = irEnum.Quarterly Then
            '    incr = "m"
            '    mIr = 3
            'ElseIf mIr = irEnum.BiMontly Then
            '    incr = "m"
            '    mIr = 2
            'ElseIf mIr = irEnum.Weekly Then
            '    incr = "d"
            '    mIr = 7
            'ElseIf mIr = irEnum.BiWeekly Then
            '    incr = "d"
            '    mIr = 14
            'ElseIf mIr = irEnum.Daily Then
            '    incr = "d"
            '    mIr = 1
            'Else
            Dim x As New Binders
            x.ErrorCode = -99
            x.ErrorString = "Invalid date Range"
            Return x
        End If



        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0

        Dim origperiod As Int32 = NumPay
        Dim origNPV As Double = currentNPV
        Dim NowPrincipal As Double
        Dim PrinValue As Double
        Dim IntValue As Double







        Do While i < NumPay

            Period = NumPay - i
            If i = 0 Then
                Dim totalInterest As Double = Intamt
                '' Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)

                Dim totalBalance = 0 ''currentNPV + totalInterest
                EMIvalue = Math.Round((totalInterest / NumPay), 2)  'totalBalance / NumPay
                PrinValue = 0 'currentNPV / NumPay
                IntValue = totalInterest / NumPay
                'IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                currentEMI = EMIvalue
                NowPrincipal = Math.Round((currentNPV - PrinValue), 2)
                currentInterest = Math.Round(IntValue, 2) ''Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, iR), 2)
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                i = i + 1

                'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                'End If

                xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
            Else
                NextNPV = origNPV
                currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, iR)), 2)
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                currentEMI = EMIvalue

                NowPrincipal = NowPrincipal - PrinValue
                currenrPrincipal = Math.Round(PrinValue, 2)
                currentInterest = Math.Round(IntValue, 2)
                NextNPV = Math.Round(NowPrincipal, 2)


                i = i + 1

                currentDate = DateAdd(incr, mIr, currentDate)

                'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                '   currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                'End If

                xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                If i = 24 Then
                    Dim m As Int32 = i
                End If

            End If

            currentEMI = Math.Round(currentEMI, 2)

            If i = NumPay And NextNPV <> 0 Then
                currenrPrincipal = NextNPV
                'currenrPrincipal(+NextNPV)
                'currentEMI = EMIvalue + NextNPV
                NextNPV = NextNPV - NextNPV
                Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                If x <> 0 Then
                    cummulativePrincipal = cummulativePrincipal + x
                End If
                currenrPrincipal = currenrPrincipal + x
                NowPrincipal = NowPrincipal - currenrPrincipal
                currentEMI = currentEMI + currenrPrincipal
            End If

            Dim xx As New System.Collections.ArrayList
            cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
            cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
            OutstandingBal = Math.Round(NowPrincipal, 2)

            'Math.Round((NextNPV - currenrPrincipal), 2)
            'NextNPV


            Dim xx1 As New SmartItems()
            xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
            sPayment.Add(xx1)

        Loop

        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function
    Public Shared Function ScheduleStraightLineRate(ByVal totaldays As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal bstart As Double, ByVal ir As Int32, ByVal StartDate As Date, ByVal repaytype As Int32) As Binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = StartDate
        Dim xcurrentDate As String = ""
        Dim xcurrentDate2 As String = ""

        Dim mIr As Int32 = ir
        Dim incr As String = ""
        If IsvalidMir(mIr) Then
            SetIrEnumVals(mIr, incr)
        Else

        End If
        'Dim mIr As Int32 = iR
        'Dim incr As String = ""
        'If mIr = irEnum.Monthly Then
        '    incr = "m"
        '    mIr = 1
        'ElseIf mIr = irEnum.Annually Then
        '    incr = "y"
        '    mIr = 0.083
        'ElseIf mIr = irEnum.SemiAnnually Then
        '    incr = "m"
        '    mIr = 0.167
        'ElseIf mIr = irEnum.Quarterly Then
        '    incr = "m"
        '    mIr = 0.25
        'ElseIf mIr = irEnum.BiMontly Then
        '    incr = "m"
        '    mIr = 0.5
        'ElseIf mIr = irEnum.Weekly Then
        '    incr = "d"
        '    mIr = 4
        'ElseIf mIr = irEnum.BiWeekly Then
        '    incr = "d"
        '    mIr = 2
        'Else : mIr = irEnum.Daily
        '    incr = "d"
        '    If NumPay < 30 Then
        '        mIr = NumPay

        '    Else
        '        mIr = mIr

        '    End If
        '    'Dim x As New SmartArrayClass
        '    'x.ErrorCode = -99
        '    'x.ErrorString = "Invalid date Range"
        '    'Return x
        'End If


        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0
        ''iR = mIr
        Dim origperiod As Int32 = NumPay
        Dim origNPV As Double = currentNPV
        Dim NowPrincipal As Double
        Dim PrinValue As Double
        Dim IntValue As Double
        Dim totalInterest As Double
        If repaytype <> 3 Then
            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    totalInterest = Math.Round(InterestPortionTotalST(currentNPV, IntRate, Period, totaldays), 2)
                    '' Dim totalInterest As Double = Math.Round((currentNPV * IntRate) / 100, 2)

                    Dim totalBalance = currentNPV + totalInterest
                    EMIvalue = totalBalance / NumPay
                    PrinValue = currentNPV / NumPay
                    IntValue = totalInterest / NumPay
                    'IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                    currentEMI = EMIvalue
                    NowPrincipal = Math.Round((currentNPV - PrinValue), 2)
                    ''currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, totaldays), 2)
                    currentInterest = totalInterest / NumPay
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    NextNPV = origNPV
                    currentInterest = totalInterest / NumPay
                    ''currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, totaldays)), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue

                    NowPrincipal = NowPrincipal - PrinValue
                    currenrPrincipal = Math.Round(PrinValue, 2)
                    currentInterest = Math.Round(IntValue, 2)
                    NextNPV = Math.Round(NowPrincipal, 2)

                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '   currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If

                currentEMI = Math.Round(currentEMI, 2)

                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = NextNPV
                    'currenrPrincipal(+NextNPV)
                    'currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If
                End If

                currentInterest = Math.Round(currentInterest, 2)
                Dim xx As New System.Collections.ArrayList
                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
                OutstandingBal = Math.Round(NowPrincipal, 2)
                'Math.Round((NextNPV - currenrPrincipal), 2)
                'NextNPV

                Dim xx1 As New SmartItems

                If bstart = 2 Then
                    xx1.setValues(currenrPrincipal, 0, currentEMI - currentInterest, OutstandingBal, Period, i, "P", xcurrentDate, xcurrentDate2)
                    sPayment.Add(xx1)

                Else
                    xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                    sPayment.Add(xx1)

                End If

            Loop
        Else


            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    totalInterest = Math.Round(InterestPortionTotalST(currentNPV, IntRate, Period, totaldays), 2)
                    Dim totalBalance = currentNPV + totalInterest
                    EMIvalue = totalInterest / NumPay  'totalBalance / NumPay
                    PrinValue = 0 'currentNPV / NumPay
                    IntValue = totalInterest / NumPay
                    'IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                    currentEMI = EMIvalue
                    NowPrincipal = Math.Round((currentNPV - PrinValue), 2)
                    currentInterest = totalInterest / NumPay
                    '' currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, iR), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    NextNPV = origNPV
                    '' currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, totaldays)), 2)
                    currentInterest = totalInterest / NumPay

                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue

                    NowPrincipal = NowPrincipal - PrinValue
                    currenrPrincipal = Math.Round(PrinValue, 2)
                    currentInterest = Math.Round(IntValue, 2)
                    NextNPV = Math.Round(NowPrincipal, 2)


                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '   currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 24 Then
                        Dim m As Int32 = i
                    End If

                End If

                currentEMI = Math.Round(currentEMI, 2)

                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = NextNPV
                    'currenrPrincipal(+NextNPV)
                    'currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV
                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If
                    currenrPrincipal = currenrPrincipal + x
                    NowPrincipal = NowPrincipal - currenrPrincipal
                    currentEMI = currentEMI + currenrPrincipal
                End If

                Dim xx As New System.Collections.ArrayList
                currentInterest = Math.Round(currentInterest, 2)

                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
                OutstandingBal = Math.Round(NowPrincipal, 2)

                'Math.Round((NextNPV - currenrPrincipal), 2)
                'NextNPV


                Dim xx1 As New SmartItems
                If bstart = 2 Then
                    xx1.setValues(currenrPrincipal, 0, currentEMI - currentInterest, OutstandingBal, Period, i, "P", xcurrentDate, xcurrentDate2)


                Else
                    If i = NumPay Then
                        xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                    Else
                        xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "I", xcurrentDate, xcurrentDate2)

                    End If
                End If

                sPayment.Add(xx1)

            Loop


        End If
        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function

    Public Shared Function ScheduleBulletMethod(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal Dtenor As Int32) As Binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = StartDate
        Dim xcurrentDate As String = ""
        Dim xcurrentDate2 As String = ""


        Dim mIr As Int32 = iR
        Dim incr As String = ""
        If IsvalidMir(mIr) Then
            SetIrEnumVals(mIr, incr)
        Else
            'If mIr = irEnum.Monthly Then
            '    incr = "m"
            '    mIr = 1
            'ElseIf mIr = irEnum.Annually Then
            '    incr = "y"
            '    mIr = 1
            'ElseIf mIr = irEnum.SemiAnnually Then
            '    incr = "m"
            '    mIr = 6
            'ElseIf mIr = irEnum.Quarterly Then
            '    incr = "m"
            '    mIr = 3
            'ElseIf mIr = irEnum.BiMontly Then
            '    incr = "m"
            '    mIr = 2
            'ElseIf mIr = irEnum.Weekly Then
            '    incr = "d"
            '    mIr = 7
            'ElseIf mIr = irEnum.BiWeekly Then
            '    incr = "d"
            '    mIr = 14
            'ElseIf mIr = irEnum.Daily Then
            '    incr = "d"
            '    mIr = 1
            'Else
            Dim x As New Binders
            x.ErrorCode = -99
            x.ErrorString = "Invalid date Range"
            Return x
        End If

        mIr = mIr


        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0

        Dim origperiod As Int32 = NumPay
        Dim origNPV As Double = currentNPV
        Dim NowPrincipal As Double
        Dim PrinValue As Double
        Dim IntValue As Double


        Do While i < NumPay

            Period = NumPay - i          'Dtenor - i   'NumPay - i
            If i = 0 Then
                Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                Dim totalBalance = currentNPV + totalInterest
                EMIvalue = totalBalance / NumPay
                PrinValue = currentNPV / NumPay
                IntValue = totalInterest / NumPay
                'IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                currentEMI = EMIvalue
                NowPrincipal = currentNPV
                currentInterest = (Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, iR), 2))
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                i = i + 1
                currentDate = DateAdd(incr, mIr * Dtenor, currentDate)
                xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
            Else
                NextNPV = origNPV
                currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, iR)), 2)
                currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                currentEMI = EMIvalue

                NowPrincipal = NowPrincipal - PrinValue
                currenrPrincipal = Math.Round(PrinValue, 2)
                currentInterest = Math.Round(IntValue, 2)
                NextNPV = Math.Round(NowPrincipal, 2)


                i = i + 1

                currentDate = DateAdd(incr, mIr, currentDate)
                xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                If i = 24 Then
                    Dim m As Int32 = i
                End If

            End If


            If i = NumPay And NextNPV <> 0 Then
                currenrPrincipal = NextNPV
                'currenrPrincipal(+NextNPV)
                'currentEMI = EMIvalue + NextNPV
                NextNPV = NextNPV - NextNPV
                Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                If x <> 0 Then
                    cummulativePrincipal = cummulativePrincipal + x
                End If
            End If

            Dim xx As New System.Collections.ArrayList
            cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
            cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
            OutstandingBal = Math.Round(NowPrincipal, 2)
            'Math.Round((NextNPV - currenrPrincipal), 2)
            'NextNPV


            Dim xx1 As New SmartItems()
            xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
            sPayment.Add(xx1)

        Loop

        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function


    Public Shared Function ScheduleDecreasingInstall(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal Repaytype As Int32) As Binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        Dim currentDate As Date = StartDate
        Dim xcurrentDate As String = ""
        Dim xcurrentDate2 As String = ""

        Dim mIr As Int32 = iR
        Dim incr As String = ""


        If IsvalidMir(mIr) Then
            SetIrEnumVals(mIr, incr)
        Else
            'If mIr = irEnum.Monthly Then
            '    incr = "m"
            '    mIr = 1
            'ElseIf mIr = irEnum.Annually Then
            '    incr = "y"
            '    mIr = 1
            'ElseIf mIr = irEnum.SemiAnnually Then
            '    incr = "m"
            '    mIr = 6
            'ElseIf mIr = irEnum.Quarterly Then
            '    incr = "m"
            '    mIr = 3
            'ElseIf mIr = irEnum.BiMontly Then
            '    incr = "m"
            '    mIr = 2
            'ElseIf mIr = irEnum.Weekly Then
            '    incr = "d"
            '    mIr = 7
            'ElseIf mIr = irEnum.BiWeekly Then
            '    incr = "d"
            '    mIr = 14
            'ElseIf mIr = irEnum.Daily Then
            '    incr = "d"
            '    mIr = 1
            'Else
            Dim x As New Binders
            x.ErrorCode = -99
            x.ErrorString = "Invalid date Range"
            Return x
        End If



        cummulativePrincipal = 0
        cummulativeInterest = 0
        currentNPV = NPV
        i = 0

        If Repaytype = 1 Then
            Dim currenrPrincipal As Double = Math.Round(NPV / NumPay, 2)
            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    ' EMIvalue = Math.Round(MKCalcPayment(iR, NumPay, IntRate, NPV, FV, bStart), 2)
                    currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                    EMIvalue = Math.Round((currenrPrincipal + currentInterest), 2)
                    'currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue

                    i = i + 1

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                    EMIvalue = Math.Round((currenrPrincipal + currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue
                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    If iR = smartCalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                        currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 20 Then
                        Dim m As Int32 = i
                    End If

                End If

                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = currenrPrincipal + NextNPV
                    currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV

                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If
                End If

                Dim xx As New System.Collections.ArrayList

                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
                'xx.Add(currenrPrincipal)
                'xx.Add(currentInterest)
                'xx.Add(currentEMI)
                'xx.Add(Period)
                'xx.Add(i)
                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                Dim xx1 As New SmartItems()
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                sPayment.Add(xx1)
            Loop
        Else
            Dim currenrPrincipal As Double = 0
            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    ' EMIvalue = Math.Round(MKCalcPayment(iR, NumPay, IntRate, NPV, FV, bStart), 2)
                    currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                    EMIvalue = Math.Round(currentInterest, 2)
                    'EMIvalue = Math.Round((currenrPrincipal + currentInterest), 2)
                    'currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - 0), 2)  'currenrPrincipal), 2)
                    currentEMI = EMIvalue

                    i = i + 1

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")
                Else
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                    EMIvalue = Math.Round(currentInterest, 2)
                    NextNPV = Math.Round((NextNPV - 0), 2)
                    currentEMI = EMIvalue
                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    If iR = smartCalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                        currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    End If

                    xcurrentDate = Format(currentDate, "dd/MM/yyyy")
                    xcurrentDate2 = Format(currentDate, "MM-dd-yyyy")

                    If i = 20 Then
                        Dim m As Int32 = i
                    End If

                End If

                If i = NumPay And NextNPV <> 0 Then
                    currenrPrincipal = currenrPrincipal + NextNPV
                    currentEMI = EMIvalue + NextNPV
                    NextNPV = NextNPV - NextNPV

                    Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                    If x <> 0 Then
                        cummulativePrincipal = cummulativePrincipal + x
                    End If
                End If

                Dim xx As New System.Collections.ArrayList

                cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
                cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
                'xx.Add(currenrPrincipal)
                'xx.Add(currentInterest)
                'xx.Add(currentEMI)
                'xx.Add(Period)
                'xx.Add(i)
                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                Dim xx1 As New SmartItems()
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "PI", xcurrentDate, xcurrentDate2)
                sPayment.Add(xx1)
            Loop

        End If

        Return sPayment
    End Function


    Public Shared Function ScheduleDecreasingInstall(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32) As System.Collections.ArrayList
        Dim sPayment As New System.Collections.ArrayList
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double = Math.Round(NPV / NumPay, 2)
        Dim EMIvalue As Double
        Dim i As Int32
        Dim Period As Int32
        Dim cummulativePrincipal As Double
        Dim cummulativeInterest As Double
        Dim OutstandingBal As Double
        Dim currentEMI As Double

        cummulativePrincipal = 0
        cummulativeInterest = 0
        currentNPV = NPV
        i = 0
        Do While i < NumPay

            Period = NumPay - i
            If i = 0 Then
                ' EMIvalue = Math.Round(MKCalcPayment(iR, NumPay, IntRate, NPV, FV, bStart), 2)
                currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                EMIvalue = Math.Round((currenrPrincipal + currentInterest), 2)
                'currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                currentEMI = EMIvalue
                i = i + 1
            Else
                currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                EMIvalue = Math.Round((currenrPrincipal + currentInterest), 2)
                NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                currentEMI = EMIvalue
                i = i + 1

                If i = 20 Then
                    Dim m As Int32 = i
                End If

            End If

            If i = NumPay And NextNPV <> 0 Then
                currenrPrincipal = currenrPrincipal + NextNPV
                currentEMI = EMIvalue + NextNPV
                NextNPV = NextNPV - NextNPV

                Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                If x <> 0 Then
                    cummulativePrincipal = cummulativePrincipal + x
                End If
            End If

            Dim xx As New System.Collections.ArrayList

            cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
            cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
            xx.Add(currenrPrincipal)
            xx.Add(currentInterest)
            xx.Add(currentEMI)
            xx.Add(Period)
            xx.Add(i)
            OutstandingBal = NextNPV
            xx.Add(OutstandingBal)
            sPayment.Add(xx)
        Loop

        Return sPayment
    End Function
End Class
