Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL
Imports PayPal.PayPalAPIInterfaceService
Imports PayPal.PayPalAPIInterfaceService.Model

Partial Class payment_process_paypal
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    Public strCreditHistoryTempId As String = ""

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/Default.aspx")
            End If

            If objFunction.ReturnString(Session("TotalCreditAmount")) = "" Then
                Response.Redirect("~/purchasecredits.aspx")
            End If

            txtPaymentAmount.Text = objFunction.ReturnDouble(Session("TotalCreditAmount")).ToString("0.00")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Protected Sub BUT_PayNow_Click(sender As Object, e As EventArgs) Handles BUT_PayNow.Click
        Try

            Dim intCreditHistoryTempId As Integer = AddCreditHistoryTemp()
            If intCreditHistoryTempId > 0 Then
                strCreditHistoryTempId = objFunction.ReturnString(intCreditHistoryTempId)
            Else
                Response.Redirect("~/purchasecredits.aspx")
            End If

            Dim strpaypalUrl As String = GetPayPalUrl(txtPaymentAmount.Text)

            If strpaypalUrl <> Nothing And strpaypalUrl <> "" Then
                Response.Redirect(strpaypalUrl)
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    Function AddCreditHistoryTemp() As Integer
        Try
            Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
            objBECreditHistoryTemp.UserId = objFunction.ReturnInteger(Session("LoginUserId"))
            objBECreditHistoryTemp.Creditx = objFunction.ReturnInteger(Session("NoOfCredit"))
            objBECreditHistoryTemp.Whenx = DateTime.Now
            objBECreditHistoryTemp.PaymentMethodId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("PaypalPaymentId"))
            objBECreditHistoryTemp.AmountTaken = objFunction.ReturnDouble(Session("TotalCreditAmount"))
            objBECreditHistoryTemp.Ref = ""
            objBECreditHistoryTemp.History = ""
            objBECreditHistoryTemp.Authorised = 0
            objBECreditHistoryTemp.Emailx = objFunction.ReturnString(Session("ClientEmailId"))

            Dim intCreditHistoryTempId As Integer = (New clsDLCreditHistoryTemp()).AddCreditHistoryTemp(objBECreditHistoryTemp)
            If intCreditHistoryTempId > 0 Then

                'Session("CreditHistoryTempEntryFlag") = "Success"
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

                Return (intCreditHistoryTempId + 141275)
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return 0
    End Function

    Function GetPayPalUrl(ByVal strPaymentAmount As String) As String
        Try
            Dim objPaypalService As PayPalAPIInterfaceServiceService = New PayPalAPIInterfaceServiceService()

            Dim strCancelUrl As String = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("ServerLoc")) + "payment_process_paypal.aspx"
            Dim strSuccessUrl As String = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("ServerLoc")) + "thankyou_paypal_temp.aspx"
            Dim objExpressCheckoutReq = New SetExpressCheckoutReq
            'objExpressCheckoutReq = PayPalPayment("GBP", strPaymentAmount, strCancelUrl, strSuccessUrl, intCreditHistoryTempId)
            objExpressCheckoutReq = PayPalPayment("GBP", strPaymentAmount, strCancelUrl, strSuccessUrl)

            Dim objExpressCheckoutResponse = New SetExpressCheckoutResponseType
            objExpressCheckoutResponse = objPaypalService.SetExpressCheckout(objExpressCheckoutReq)

            'string strAck = service.SetExpressCheckout(req).Ack.ToString();
            Dim strAck As String = objFunction.ReturnString(objPaypalService.SetExpressCheckout(objExpressCheckoutReq).Ack)
            If strAck <> Nothing And (strAck = "SUCCESS" Or strAck = "SUCCESSWITHWARNING") Then
                Session("Token") = objFunction.ReturnString(objExpressCheckoutResponse.Token)
                Return String.Format("{0}?cmd=_express-checkout&token={1}&useraction=commit", "https://www.sandbox.paypal.com/cgi-bin/webscr", objExpressCheckoutResponse.Token)
                'Return String.Format("{0}?cmd=_express-checkout&token={1}&useraction=commit", "https://www.paypal.com/cgi-bin/webscr", objExpressCheckoutResponse.Token)

            Else
                Return objFunction.ReturnString(objExpressCheckoutResponse.Errors)
            End If
            Return Nothing
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    Function PayPalPayment(ByVal strCurrencyCode As String, ByVal strPaymentAmount As String, ByVal strCancelUrl As String, ByVal strSuccessUrl As String) As SetExpressCheckoutReq
        Try
            Dim objExpressCheckoutRequest = New SetExpressCheckoutRequestDetailsType()
            Dim objOrderTotal = New BasicAmountType() With
                {
                    .currencyID = CType([Enum].Parse(GetType(CurrencyCodeType), strCurrencyCode), CurrencyCodeType),
                    .value = strPaymentAmount
                }
            objExpressCheckoutRequest.OrderTotal = objOrderTotal
            objExpressCheckoutRequest.PaymentAction = PaymentActionCodeType.AUTHORIZATION
            objExpressCheckoutRequest.CancelURL = strCancelUrl
            objExpressCheckoutRequest.ReturnURL = strSuccessUrl
            'objExpressCheckoutRequest.Custom = intCreditHistoryTempId
            objExpressCheckoutRequest.Custom = objFunction.ReturnString(Session("CreditHistoryTempId")) + "#" + strPaymentAmount
            objExpressCheckoutRequest.BuyerEmail = objFunction.ReturnString(Session("ClientEmailId"))

            objExpressCheckoutRequest.AddressOverride = "0"
            Dim shipAddress = New AddressType()
            shipAddress.Name = "SHAERON SOFTWARE"
            shipAddress.Street1 = "BENGALURU"
            shipAddress.Street2 = "BENGALURU"
            shipAddress.CityName = "BENGALURU"
            shipAddress.StateOrProvince = "Alaska"
            shipAddress.CountryName = "Algeria"
            shipAddress.PostalCode = "WC2N 5DU"
            shipAddress.Phone = "9967777656"
            objExpressCheckoutRequest.Address = shipAddress

            Dim objSetExpressCheckoutReq = New SetExpressCheckoutReq() With
                {
                    .SetExpressCheckoutRequest = New SetExpressCheckoutRequestType() With
                    {
                        .SetExpressCheckoutRequestDetails = objExpressCheckoutRequest, .Version = "60.0"
                    }
                }

            Return objSetExpressCheckoutReq
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

End Class
