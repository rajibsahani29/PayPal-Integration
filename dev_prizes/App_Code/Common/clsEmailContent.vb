Imports Microsoft.VisualBasic
Imports System.Data

Public Class clsEmailContent

    Dim objFunction As New clsCommon()

    Public Function RegistrationVerification(ByVal strName As String, ByVal strEmailVerificationURL As String, ByVal strEmailBlockURL As String, ByVal strSignature As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName)
        lstEmailValue.Add(strEmailVerificationURL)
        lstEmailValue.Add(strEmailBlockURL)
        lstEmailValue.Add(strSignature)
        Return ReadHtmlPage("1.html", lstEmailValue)

    End Function

    Public Function ResetEmail(ByVal strName As String, ByVal strEmailVerificationURL As String, ByVal strEmailBlockURL As String, ByVal strSignature As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName)
        lstEmailValue.Add(strEmailVerificationURL)
        lstEmailValue.Add(strEmailBlockURL)
        lstEmailValue.Add(strSignature)
        Return ReadHtmlPage("2.html", lstEmailValue)

    End Function

    Public Function PlayGameEmail(ByVal strName As String, ByVal strGameHistory As String, ByVal strSignature As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName)
        lstEmailValue.Add(strGameHistory)
        lstEmailValue.Add(strSignature)
        Return ReadHtmlPage("5.html", lstEmailValue)

    End Function

    Public Function CreditHistoryTempEmail(ByVal strName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName)
        Return ReadHtmlPage("6.html", lstEmailValue)

    End Function

    Public Function Thankyou_SuccessPayment(ByVal strNoOfCredits As String, ByVal strDate As String, ByVal strTotalPaymentAmount As String, ByVal strSignature As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strNoOfCredits)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strTotalPaymentAmount)
        lstEmailValue.Add(strSignature)
        Return ReadHtmlPage("7.html", lstEmailValue)

    End Function

    Public Function Thankyou_DeclinedPayment(ByVal strDate As String, ByVal strSignature As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSignature)
        Return ReadHtmlPage("8.html", lstEmailValue)

    End Function

    Public Function Thankyou_WinaAbode(ByVal strName As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName)
        Return ReadHtmlPage("win_abode1.html", lstEmailValue)

    End Function

    Public Function Thankyou_SuccessPaymentCliqPay(ByVal strName As String, ByVal strAddress As String, ByVal strPhone As String, ByVal strEmail As String, ByVal strNoOfCredits As String, ByVal strDate As String, ByVal strTotalPaymentAmount As String, ByVal strSignature As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName)
        lstEmailValue.Add(strAddress)
        lstEmailValue.Add(strPhone)
        lstEmailValue.Add(strEmail)
        lstEmailValue.Add(strNoOfCredits)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strTotalPaymentAmount)
        lstEmailValue.Add(strSignature)
        Return ReadHtmlPage("7_cliqpay.html", lstEmailValue)

    End Function

    Public Function Thankyou_DeclinedPaymentCliqPay(ByVal strName As String, ByVal strAddress As String, ByVal strPhone As String, ByVal strEmail As String, ByVal strDate As String, ByVal strSignature As String) As String

        Dim lstEmailValue As New List(Of String)
        lstEmailValue.Add(strName)
        lstEmailValue.Add(strAddress)
        lstEmailValue.Add(strPhone)
        lstEmailValue.Add(strEmail)
        lstEmailValue.Add(strDate)
        lstEmailValue.Add(strSignature)
        Return ReadHtmlPage("8_cliqpay.html", lstEmailValue)

    End Function

    Public Function FirstDayOfMonthFromDateTime(ByVal dateTime As DateTime) As DateTime
        Return New DateTime(dateTime.Year, dateTime.Month, 1)
    End Function

    Private Function daySuffix(ByVal day As Integer) As String
        If day > 0 Then
            If day Mod 10 = 1 And day Mod 100 <> 11 Then
                Return "st"
            ElseIf day Mod 10 = 2 And day Mod 100 <> 12 Then
                Return "nd"
            ElseIf day Mod 10 = 3 And day Mod 100 <> 13 Then
                Return "rd"
            Else
                Return "th"
            End If
        Else
            Return String.Empty
        End If
    End Function

    Public Function ReadHtmlPage(ByVal strFileName As String, ByVal lstEmailValue As List(Of String)) As String

        Try
            Dim file As String = HttpContext.Current.Server.MapPath("~/emails/" + strFileName)
            HttpContext.Current.Trace.Warn("File path = " + file)
            Dim sr As System.IO.StreamReader
            Dim strContents As String = ""
            If System.IO.File.Exists(file) Then
                sr = System.IO.File.OpenText(file)
                strContents += HttpContext.Current.Server.HtmlDecode(sr.ReadToEnd())
                sr.Close()

                Dim strTempContent As String = strContents

                Dim intCount As Integer = 0

                Dim lngPos1 As Long
                Dim lngPos2 As Long
                Dim strSubString As String

                lngPos1 = InStr(1, strContents, "<%")
                Do While lngPos1 > 0
                    lngPos2 = InStr(Convert.ToInt32(lngPos1 + 1), strContents, "%>")
                    If lngPos2 > 0 Then
                        strSubString = Mid$(strContents, lngPos1 + 1, lngPos2 - lngPos1 - 1)
                        HttpContext.Current.Trace.Warn("sSubString = " + strSubString)
                        'strTempContent = strTempContent.Replace(strSubString, "%" + Convert.ToString(intCount))
                        'strTempContent = strTempContent.Replace("<" + strSubString + "%>", Convert.ToString(intCount))
                        HttpContext.Current.Trace.Warn("intCount = " + objFunction.ReturnString(intCount))
                        If intCount < lstEmailValue.Count Then
                            strTempContent = strTempContent.Replace("<" + strSubString + "%>", Convert.ToString(lstEmailValue(intCount)))
                        End If
                        strTempContent = strTempContent.Replace("<" + strSubString + "%>", Convert.ToString(intCount))
                        intCount += 1
                    Else
                        Exit Do
                    End If
                    lngPos1 = InStr(Convert.ToInt32(lngPos2 + 1), strContents, "<%")
                Loop

                'Trace.Warn("strTempContent = " + strTempContent)

                strContents = strTempContent

            End If
            Return strContents
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing

    End Function

End Class
