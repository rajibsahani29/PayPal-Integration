Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class GetAjaxData
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strResponceText As String = String.Empty
        Dim strDoAction As String = Request.Params.Get("DoAction")
        'Response.Write(strDoAction)
        Try
            If strDoAction = "getGameCostsByCompanyIdAndCredx" Then
                Dim intCompanyId As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                Dim intNoOfCredits As Integer = objFunction.ReturnInteger(Request.Params.Get("NoOfCredits"))
                Dim dstGameCosts As DataSet = (New clsDLGameCosts()).GetGameCostsByCompanyIdAndUserCredx(intCompanyId, intNoOfCredits)
                If objFunction.CheckDataSet(dstGameCosts) Then
                    strResponceText = objFunction.ReturnDouble(dstGameCosts.Tables(0).Rows(0)("amount")).ToString("0.00")
                End If
            ElseIf strDoAction = "AddCreditHistoryTemp" Then

                If objFunction.ValidateLogin() Then
                    'Response.Redirect("~/Default.aspx")
                    Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                    objBECreditHistoryTemp.UserId = objFunction.ReturnInteger(Session("LoginUserId"))
                    objBECreditHistoryTemp.Creditx = objFunction.ReturnInteger(Session("NoOfCredit"))
                    objBECreditHistoryTemp.Whenx = DateTime.Now
                    objBECreditHistoryTemp.PaymentMethodId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("PaymentId"))
                    objBECreditHistoryTemp.AmountTaken = objFunction.ReturnDouble(Request.Params.Get("AmountTaken"))
                    objBECreditHistoryTemp.Ref = ""
                    objBECreditHistoryTemp.History = ""
                    objBECreditHistoryTemp.Authorised = 0
                    objBECreditHistoryTemp.Emailx = objFunction.ReturnString(Session("ClientEmailId"))

                    Dim intCreditHistoryTempId As Integer = (New clsDLCreditHistoryTemp()).AddCreditHistoryTemp(objBECreditHistoryTemp)
                    If intCreditHistoryTempId > 0 Then

                        Session("CreditHistoryTempId") = objFunction.ReturnString(intCreditHistoryTempId)

                        Dim myCookie As HttpCookie = New HttpCookie("UserSettings")
                        myCookie("CreditHistoryTempId") = objFunction.ReturnString((141275 + intCreditHistoryTempId))
                        myCookie("NoOfCredit") = objFunction.ReturnString(Session("NoOfCredit"))
                        myCookie.Expires = Now.AddDays(1)
                        Response.Cookies.Add(myCookie)

                        'If (Request.Cookies("UserSettings") IsNot Nothing) Then
                        '    Trace.Warn("Cookie UserId = " + objFunction.ReturnString(Request.Cookies("UserSettings")("UserId")))
                        '    Trace.Warn("Cookie NoOfCredit = " + objFunction.ReturnString(Request.Cookies("UserSettings")("NoOfCredit")))
                        'End If

                        strResponceText = objFunction.ReturnString((intCreditHistoryTempId + 141275)) + "$" + objFunction.ReturnString(Session("NoOfCredit")) + "$" + "Success"
                    End If
                End If
            ElseIf strDoAction = "AddCreditHistoryTempForWinAbode" Then
                If objFunction.ReturnString(Session("WinAbodeRegisterClientId")) <> "" Then
                    If objFunction.ReturnString(Session("NoOfCreditPurchase")) <> "" And objFunction.ReturnInteger(Session("NoOfCreditPurchase")) > 0 Then
                        Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                        objBECreditHistoryTemp.UserId = objFunction.ReturnInteger(Session("WinAbodeRegisterClientId"))
                        objBECreditHistoryTemp.Creditx = objFunction.ReturnInteger(Session("NoOfCreditPurchase"))
                        objBECreditHistoryTemp.Whenx = DateTime.Now
                        objBECreditHistoryTemp.PaymentMethodId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("PaymentId"))
                        objBECreditHistoryTemp.AmountTaken = objFunction.ReturnDouble(Request.Params.Get("AmountTaken"))
                        objBECreditHistoryTemp.Ref = ""
                        objBECreditHistoryTemp.History = ""
                        objBECreditHistoryTemp.Authorised = 0
                        objBECreditHistoryTemp.Emailx = objFunction.ReturnString(Session("ClientEmailId"))

                        Dim intCreditHistoryTempId As Integer = (New clsDLCreditHistoryTemp()).AddCreditHistoryTemp(objBECreditHistoryTemp)
                        If intCreditHistoryTempId > 0 Then

                            Session("CreditHistoryTempId") = objFunction.ReturnString(intCreditHistoryTempId)

                            Dim myCookie As HttpCookie = New HttpCookie("UserSettings")
                            myCookie("CreditHistoryTempId") = objFunction.ReturnString((141275 + intCreditHistoryTempId))
                            myCookie("NoOfCredit") = objFunction.ReturnString(Session("NoOfCreditPurchase"))
                            myCookie.Expires = Now.AddDays(1)
                            Response.Cookies.Add(myCookie)

                            'If (Request.Cookies("UserSettings") IsNot Nothing) Then
                            '    Trace.Warn("Cookie UserId = " + objFunction.ReturnString(Request.Cookies("UserSettings")("UserId")))
                            '    Trace.Warn("Cookie NoOfCredit = " + objFunction.ReturnString(Request.Cookies("UserSettings")("NoOfCredit")))
                            'End If

                            strResponceText = objFunction.ReturnString((intCreditHistoryTempId + 141275)) + "$" + objFunction.ReturnString(Session("NoOfCreditPurchase")) + "$" + "Success"
                        End If
                    End If
                End If
            End If

            Response.Clear()
            Response.Write(strResponceText)
            Response.End()

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class
