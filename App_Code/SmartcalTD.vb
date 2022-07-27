Imports Microsoft.VisualBasic

Public Class SmartcalTD
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

    Public Shared Function InterestPortionTotal(ByVal NPV As Double, ByVal IntRate As Double, ByVal TimeLength As Int32, ByVal iR As Int32) As Double
        '(A6*19.05/100)*(E6/12)/E6
        Dim FinalVal As Double
        FinalVal = (NPV * IntRate / 100) * (TimeLength / iR)
        Return FinalVal
    End Function

    Public Shared Function InterestPortionPERiR(ByVal NPV As Double, ByVal IntRate As Double, ByVal TimeLength As Int32, ByVal iR As Int32) As Double
        '(A6*19.05/100)*(E6/12)/E6
        Dim FinalVal As Double
        FinalVal = (NPV * IntRate / 100) * (TimeLength / iR) / TimeLength
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
    Public Shared Function ScheduleReducingBal(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal RepayType As Int32) As Binders
        Dim sPayment As New binders
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
            Dim x As New binders
            x.ErrorCode = -99
            x.ErrorString = "Invalid date Range"
            Return x
        End If

        Dim NumPayNew As Int32 = 0
        'If iR = smartcalc.irEnum.Daily And theDayIsSunday() Then
        '    '
        'End If

        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0

        If RepayType = 1 Then


            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    EMIvalue = Math.Round(MKCalcPayment(iR, NumPay, IntRate, NPV, FV, bStart), 2)
                    currentEMI = EMIvalue
                    currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1
                    ' If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate
                Else
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue
                    i = i + 1
                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    'currentDate = DateAdd(DateInterval.Day, mIr, currentDate)
                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate

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
                'xx.Add(currenrPrincipal)
                'xx.Add(currentInterest)
                'xx.Add(currentEMI)
                'xx.Add(Period)
                'xx.Add(i)
                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)

                Dim xx1 As New smartitems()
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
                sPayment.Add(xx1)
                'Dim xx2 As New smartitems()
                'xx2.setValues(0, currentInterest, currentEMI, OutstandingBal, Period, i, "I", currentDate)
                'sPayment.Add(xx2)



            Loop

        Else

            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    EMIvalue = Math.Round(MKCalcPayment(iR, NumPay, IntRate, NPV, FV, bStart), 2)
                    currentEMI = EMIvalue
                    currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                    currenrPrincipal = 0   'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1
                    ' If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate
                Else
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                    currenrPrincipal = 0    'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue
                    i = i + 1
                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    'currentDate = DateAdd(DateInterval.Day, mIr, currentDate)
                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate

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
                'xx.Add(currenrPrincipal)
                'xx.Add(currentInterest)
                'xx.Add(currentEMI)
                'xx.Add(Period)
                'xx.Add(i)
                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)

                Dim xx1 As New smartitems()
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
                sPayment.Add(xx1)
                'Dim xx2 As New smartitems()
                'xx2.setValues(0, currentInterest, currentEMI, OutstandingBal, Period, i, "I", currentDate)
                'sPayment.Add(xx2)



            Loop



        End If


        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function

    'Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
    'Dim totalBalance = currentNPV + totalInterest

    Public Shared Function ScheduleFlatRate(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal Repaytype As Int32) As Binders
        Dim sPayment As New binders
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
            Dim x As New binders
            x.ErrorCode = -99
            x.ErrorString = "Invalid date Range"
            Return x
        End If



        cummulativePrincipal = 0
        cummulativeInterest = 0

        currentNPV = NPV
        i = 0

        If Repaytype = 1 Then
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

                    ' If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate
                Else
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                    currenrPrincipal = Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue
                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate

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
                'xx.Add(currenrPrincipal)
                'xx.Add(currentInterest)
                'xx.Add(currentEMI)
                'xx.Add(Period)
                'xx.Add(i)
                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                'sPayment.Add(xx)

                Dim xx1 As New smartitems()
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
                sPayment.Add(xx1)

            Loop
        Else

            Do While i < NumPay

                Period = NumPay - i
                If i = 0 Then
                    Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                    Dim totalBalance = currentNPV + totalInterest
                    EMIvalue = totalBalance / NumPay
                    IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                    currentEMI = EMIvalue
                    currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, Period, iR), 2)
                    currenrPrincipal = 0  'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                    i = i + 1

                    ' If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '     currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    ' End If

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate
                Else
                    currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, Period, iR)), 2)
                    currenrPrincipal = 0 'Math.Round((EMIvalue - currentInterest), 2)
                    NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                    currentEMI = EMIvalue
                    i = i + 1

                    currentDate = DateAdd(incr, mIr, currentDate)

                    'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                    '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                    'End If

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate

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
                'xx.Add(currenrPrincipal)
                'xx.Add(currentInterest)
                'xx.Add(currentEMI)
                'xx.Add(Period)
                'xx.Add(i)
                OutstandingBal = NextNPV
                'xx.Add(OutstandingBal)
                'sPayment.Add(xx)

                Dim xx1 As New smartitems()
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
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
            Dim x As New binders
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
                xcurrentDate = currentDate

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
            'xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate)
            'sPayment.Add(xx1)

        Loop

        'If NextNPV <> 0 Then
        '    currenrPrincipal = currenrPrincipal + NextNPV
        'End If

        Return sPayment
    End Function

    Public Shared Function ScheduleStraightLineRate(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal repaytype As Int32) As Binders
        Dim sPayment As New binders
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
          
            Dim x As New binders
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
                Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                Dim totalBalance = currentNPV + totalInterest
                EMIvalue = totalBalance / NumPay
                PrinValue = currentNPV / NumPay
                IntValue = totalInterest / NumPay
                IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                currentEMI = IntRate 'EMIvalue
                NowPrincipal = 0 'Math.Round((currentNPV - PrinValue), 2)
                currentInterest = Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, iR), 2)
                currenrPrincipal = 0 'Math.Round((EMIvalue - currentInterest), 2)
                'NextNPV = Math.Round((currentNPV - currenrPrincipal), 2)
                i = i + 1

                'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                'End If

                xcurrentDate = currentDate
                xcurrentDate2 = currentDate
            Else
                NextNPV = origNPV
                currentInterest = Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, iR)), 2)
                currenrPrincipal = 0 ' Math.Round((EMIvalue - currentInterest), 2)
                'NextNPV = Math.Round((NextNPV - currenrPrincipal), 2)
                currentEMI = IntRate ' EMIvalue

                ' NowPrincipal = NowPrincipal - PrinValue
                currenrPrincipal = 0 ' Math.Round(PrinValue, 2)
                currentInterest = Math.Round(IntRate, 2)
                'NextNPV = Math.Round(NowPrincipal, 2)

                i = i + 1

                currentDate = DateAdd(incr, mIr, currentDate)

                'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                '   currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                'End If

                xcurrentDate = currentDate
                xcurrentDate2 = currentDate

                If i = 24 Then
                    Dim m As Int32 = i
                End If

            End If

            currentEMI = Math.Round(currentEMI, 2)

            If i = NumPay Then
                currenrPrincipal = origNPV ' NextNPV
                'currenrPrincipal(+NextNPV)
                currentEMI = origNPV 'EMIvalue + NextNPV
                NextNPV = 0 ' NextNPV - NextNPV
                'Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                'If x <> 0 Then
                '    cummulativePrincipal = cummulativePrincipal + x
                'End If
            End If

            Dim xx As New System.Collections.ArrayList
            'cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
            'cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
            'OutstandingBal = Math.Round(NowPrincipal, 2)
            'Math.Round((NextNPV - currenrPrincipal), 2)
            'NextNPV


            Dim xx1 As New SmartItems()
            xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
            sPayment.Add(xx1)

        Loop


        Return sPayment
    End Function

    Public Shared Function ScheduleBulletMethod(ByVal iR As Int32, ByVal NumPay As Int32, ByVal IntRate As Double, ByVal NPV As Double, ByVal FV As Double, ByVal bStart As Int32, ByVal StartDate As Date, ByVal Dtenor As Int32) As Binders
        Dim sPayment As New Binders
        Dim currentNPV As Double
        Dim NextNPV As Double
        Dim currentInterest As Double
        Dim currenrPrincipal As Double
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
        Dim IntValue As Double = 0
        Do While i < NumPay

            Period = NumPay - i
            If i = 0 Then
                Dim totalInterest As Double = Math.Round(InterestPortionTotal(currentNPV, IntRate, Period, iR), 2)
                Dim totalBalance = currentNPV + totalInterest
                'EMIvalue = totalBalance / NumPay
                'PrinValue = currentNPV / NumPay
                ' IntValue = totalInterest / NumPay
                'IntRate = MKCalcInterest(iR, NumPay, EMIvalue, NPV, 0, 0)
                currentEMI = totalInterest 'EMIvalue
                NowPrincipal = Math.Round((currentNPV - PrinValue), 2)
                currentInterest = totalInterest ' Math.Round(InterestPortionPERiR(currentNPV, IntRate, origperiod, iR), 2)
                currenrPrincipal = 0 ' Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = 0 'Math.Round((currentNPV - currenrPrincipal), 2)
                i = i + 1

                'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                '    currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                'End If

                xcurrentDate = currentDate
                xcurrentDate2 = currentDate
            Else
                NextNPV = 0 'origNPV
                currentInterest = 0 ' Math.Round((InterestPortionPERiR(NextNPV, IntRate, origperiod, iR)), 2)
                currenrPrincipal = 0 'Math.Round((EMIvalue - currentInterest), 2)
                NextNPV = 0 'Math.Round((NextNPV - currenrPrincipal), 2)
                currentEMI = 0 ' EMIvalue

                'NowPrincipal = NowPrincipal - PrinValue
                'currenrPrincipal = Math.Round(PrinValue, 2)
                'currentInterest = Math.Round(IntValue, 2)
                'NextNPV = Math.Round(NowPrincipal, 2)

                i = i + 1

                currentDate = DateAdd(incr, mIr, currentDate)

                'If iR = smartcalc.irEnum.Daily And theDayIsSunday(currentDate) Then
                '   currentDate = DateAdd(DateInterval.Day, 1, currentDate)
                'End If

                xcurrentDate = currentDate
                xcurrentDate2 = currentDate

                If i = 24 Then
                    Dim m As Int32 = i
                End If

            End If

            currentEMI = Math.Round(currentEMI, 2)

            If i = NumPay Then
                currenrPrincipal = origNPV ' NextNPV
                'currenrPrincipal(+NextNPV)
                currentEMI = origNPV 'EMIvalue + NextNPV
                NextNPV = 0 ' NextNPV - NextNPV
                'Dim x As Double = NPV - (cummulativePrincipal + currenrPrincipal)
                'If x <> 0 Then
                '    cummulativePrincipal = cummulativePrincipal + x
                'End If
            End If

            Dim xx As New System.Collections.ArrayList
            'cummulativePrincipal = Math.Round((cummulativePrincipal + currenrPrincipal), 2)
            'cummulativeInterest = Math.Round((cummulativeInterest + currentInterest), 2)
            'OutstandingBal = Math.Round(NowPrincipal, 2)
            ''Math.Round((NextNPV - currenrPrincipal), 2)
            'NextNPV


            Dim xx1 As New SmartItems()
            xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
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

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate
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

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate

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
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
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

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate
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

                    xcurrentDate = currentDate
                    xcurrentDate2 = currentDate

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
                xx1.setValues(currenrPrincipal, currentInterest, currentEMI, OutstandingBal, Period, i, "New", xcurrentDate, xcurrentDate2)
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
