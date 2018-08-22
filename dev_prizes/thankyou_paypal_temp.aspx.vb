Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL
Imports PayPal.PayPalAPIInterfaceService
Imports PayPal.PayPalAPIInterfaceService.Model

Partial Class thankyou_paypal_temp
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBECreditHistory As clsBECreditHistory = New clsBECreditHistory
    Dim objDLCreditHistory As clsDLCreditHistory = New clsDLCreditHistory

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Trace.Warn("CreditHistoryTempId = " + objFunction.ReturnString(Session("CreditHistoryTempId")))
            If (Request.Cookies("UserSettings") Is Nothing) And objFunction.ReturnString(Session("CreditHistoryTempId")) = "" Then
                Dim strMsg As String = "Something went wrong with the credit approval system. Please use the special contact form in the contact section to inform us and we will happily credit your account"
                Dim javaScript As String = ""
                javaScript += "<script type='text/javascript'>"
                javaScript += "alert('" + strMsg + "');"
                javaScript += "window.location = 'thankyou_paypal.aspx';"
                javaScript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
            End If

            If Request.QueryString("token") = "" Then
                Dim strMsg As String = "Something went wrong with the credit approval system. Please use the special contact form in the contact section to inform us and we will happily credit your account"
                Dim javaScript As String = ""
                javaScript += "<script type='text/javascript'>"
                javaScript += "alert('" + strMsg + "');"
                javaScript += "window.location = 'thankyou_paypal.aspx';"
                javaScript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
            End If
            GetPaypalPaymentDetail()
            Dim doResponse As DoExpressCheckoutPaymentResponseType = CommitPayPalPayment()
            Trace.Warn("ResponseCreditHistoryTempId = " + objFunction.ReturnString(Session("ResponseCreditHistoryTempId")))
            If Not Page.IsPostBack Then
                Dim intCreditHistoryTempId As Integer = objFunction.ReturnInteger(Session("ResponseCreditHistoryTempId"))
                Trace.Warn("intCreditHistoryTempId = " + objFunction.ReturnString(intCreditHistoryTempId))
                If intCreditHistoryTempId > 0 Then
                    Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHistoryTempId)
                    If objFunction.CheckDataSet(dstData) Then
                        Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                       "---------- Thankyou_Paypal_Temp RECORD ----- PAGELOAD ENTERED(CustomParameter) " +
                                                       objFunction.ReturnString(DateTime.Now)
                        UpdateHistory(intCreditHistoryTempId, strNewHistory)

                        If objFunction.ReturnString(Session("LoginUserId")) = "" Then
                            Session("LoginUserId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("uid"))
                            Session("UserLogged") = "1"
                        End If

                        If objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = 0 Then
                            ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHistoryTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), doResponse)
                        Else
                            'UpdateCreditHistoryTemp(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                            UpdateCreditHistoryTemp(intCreditHistoryTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                            'Request.Cookies.Remove("UserSettings")
                            'Response.Redirect("thankyou_paypal.aspx")
                        End If
                    End If


                ElseIf Request.Cookies("UserSettings") IsNot Nothing Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Request.Cookies("UserSettings")("CreditHistoryTempId")) - 141275
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then

                            
                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                       "---------- Thankyou_Paypal_Temp RECORD ----- PAGELOAD ENTERED(Cookie) " +
                                                       objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)

                            If objFunction.ReturnString(Session("LoginUserId")) = "" Then
                                Session("LoginUserId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("uid"))
                                Session("UserLogged") = "1"
                            End If

                            If objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = 0 Then
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(Request.Cookies("UserSettings")("NoOfCredit")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")))
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), doResponse)
                            Else
                                'UpdateCreditHistoryTemp(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                UpdateCreditHistoryTemp(intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                'Request.Cookies.Remove("UserSettings")
                                'Response.Redirect("thankyou_paypal.aspx")
                            End If
                        End If
                    End If
                ElseIf objFunction.ReturnString(Session("CreditHistoryTempId")) <> "" Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Session("CreditHistoryTempId"))
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then


                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                           "---------- Thankyou_Paypal_Temp RECORD ----- PAGELOAD ENTERED(Session) " +
                                                           objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)

                            If objFunction.ReturnString(Session("LoginUserId")) = "" Then
                                Session("LoginUserId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("uid"))
                                Session("UserLogged") = "1"
                            End If

                            If objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = 0 Then
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(Session("NoOfCredit")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")))
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), doResponse)
                            Else
                                'UpdateCreditHistoryTemp(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                UpdateCreditHistoryTemp(intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                'Request.Cookies.Remove("UserSettings")
                                'Response.Redirect("thankyou_paypal.aspx")
                            End If
                        End If
                    End If
                End If
            Else
                'Request.Cookies.Remove("UserSettings")
                Dim strMsg As String = "Something went wrong with the credit approval system. Please use the special contact form in the contact section to inform us and we will happily credit your account"
                    Dim javaScript As String = ""
                    javaScript += "<script type='text/javascript'>"
                    javaScript += "alert('" + strMsg + "');"
                    javaScript += "window.location = 'thankyou_paypal.aspx';"
                    javaScript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
                End If


        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

            If ex.Message <> "Thread was being aborted." Then
                If Request.Cookies("UserSettings") IsNot Nothing Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Request.Cookies("UserSettings")("CreditHistoryTempId")) - 141275
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then
                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                           "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception(Cookie) Page_load " +
                                                           objFunction.ReturnString(ex.Message) +
                                                           objFunction.ReturnString(ex.StackTrace) +
                                                           objFunction.ReturnString(ex.InnerException) +
                                                           objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)
                        End If
                    End If
                ElseIf objFunction.ReturnString(Session("CreditHistoryTempId")) <> "" Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Session("CreditHistoryTempId"))
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then
                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                           "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception(Session) Page_load " +
                                                           objFunction.ReturnString(ex.Message) +
                                                           objFunction.ReturnString(ex.StackTrace) +
                                                           objFunction.ReturnString(ex.InnerException) +
                                                           objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)
                        End If
                    End If
                End If
            End If

            'Session("ResponseAmountTaken") = "0"
            'Session("ResponsePaymentStatus") = "Unsuccessful. Please try again. Your card has not been charged."
            Response.Redirect("thankyou_paypal.aspx")

        End Try
    End Sub

    'Sub GetPaypalPaymentDetail(ByVal intCreditHistoryTempId As Integer)
    '    Try
    '        If Request.QueryString("token") <> "" Then
    '            Dim strToken As String = Request.QueryString("token")

    '            Dim objExpressCheckoutDetailsReq As GetExpressCheckoutDetailsReq = New GetExpressCheckoutDetailsReq() With
    '                {
    '                    .GetExpressCheckoutDetailsRequest = New GetExpressCheckoutDetailsRequestType() With
    '                    {
    '                        .Version = "60.0",
    '                        .Token = strToken
    '                    }
    '                }

    '            Dim objPaypalService As PayPalAPIInterfaceServiceService = New PayPalAPIInterfaceServiceService()

    '            Dim objGetExpressCheckoutDetailsResponse = New GetExpressCheckoutDetailsResponseType
    '            objGetExpressCheckoutDetailsResponse = objPaypalService.GetExpressCheckoutDetails(objExpressCheckoutDetailsReq)

    '            If objGetExpressCheckoutDetailsResponse.Errors.Count > 0 Then

    '            Else
    '                Dim respDetails As GetExpressCheckoutDetailsResponseDetailsType = objGetExpressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails
    '                Session("CheckoutDetails") = objGetExpressCheckoutDetailsResponse
    '                'TextBox2.Text = resp.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID;
    '                'CommitPayPalPayment()
    '            End If

    '        End If
    '    Catch ex As Exception
    '        HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
    '        HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

    '        If ex.Message <> "Thread was being aborted." Then
    '            Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHistoryTempId)
    '            If objFunction.CheckDataSet(dstData) Then
    '                Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
    '                                                           "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception GetPaypalPaymentDetail() " +
    '                                                           objFunction.ReturnString(ex.Message) +
    '                                                           objFunction.ReturnString(ex.StackTrace) +
    '                                                           objFunction.ReturnString(ex.InnerException) +
    '                                                           objFunction.ReturnString(DateTime.Now)
    '                UpdateHistory(intCreditHistoryTempId, strNewHistory)
    '            End If
    '        End If

    '    End Try
    'End Sub

    'Function CommitPayPalPayment(ByVal intCreditHistoryTempId As Integer, ByVal strAmountTaken As String) As DoExpressCheckoutPaymentResponseType
    '    Try
    '        Dim objPaypalService As PayPalAPIInterfaceServiceService = New PayPalAPIInterfaceServiceService()
    '        Dim resp = TryCast(Session("CheckoutDetails"), GetExpressCheckoutDetailsResponseType)
    '        Dim value As String = resp.GetExpressCheckoutDetailsResponseDetails.[Custom]
    '        Dim payReq = New DoExpressCheckoutPaymentReq() With
    '            {
    '                .DoExpressCheckoutPaymentRequest = New DoExpressCheckoutPaymentRequestType() With
    '                {
    '                    .Version = "60.0",
    '                    .DoExpressCheckoutPaymentRequestDetails = New DoExpressCheckoutPaymentRequestDetailsType With
    '                    {
    '                        .Token = resp.GetExpressCheckoutDetailsResponseDetails.Token,
    '                        .PaymentAction = PaymentActionCodeType.SALE,
    '                        .PayerID = resp.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID,
    '                        .PaymentDetails = New List(Of PaymentDetailsType) From
    '                        {
    '                            New PaymentDetailsType With
    '                            {
    '                                .OrderTotal = New BasicAmountType With
    '                                {
    '                                    .currencyID = CType([Enum].Parse(GetType(CurrencyCodeType), "USD"), CurrencyCodeType),
    '                                    .value = strAmountTaken
    '                                }
    '                            }
    '                        }
    '                    }
    '                }
    '            }

    '        commit transaction And display results to user
    '        Dim doResponse As DoExpressCheckoutPaymentResponseType = objPaypalService.DoExpressCheckoutPayment(payReq)
    '        Return doResponse
    '        If doResponse.Errors.Count > 0 Then
    '            'lblError.Text = "This transaction cannot be processed. The amount to be charged is zero.";
    '        Else
    '            Dim strTransactionId As String = doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).TransactionID
    '            If strTransactionId <> Nothing Then
    '                'Success
    '            Else
    '                'Error of transaction
    '            End If
    '        End If

    '    Catch ex As Exception
    '        HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
    '        HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

    '        If ex.Message <> "Thread was being aborted." Then
    '            Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHistoryTempId)
    '            If objFunction.CheckDataSet(dstData) Then
    '                Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
    '                                                           "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception CommitPayPalPayment() " +
    '                                                           objFunction.ReturnString(ex.Message) +
    '                                                           objFunction.ReturnString(ex.StackTrace) +
    '                                                           objFunction.ReturnString(ex.InnerException) +
    '                                                           objFunction.ReturnString(DateTime.Now)
    '                UpdateHistory(intCreditHistoryTempId, strNewHistory)
    '            End If
    '        End If

    '    End Try
    '    Return Nothing
    'End Function


    Sub GetPaypalPaymentDetail()
        Try
            If Request.QueryString("token") <> "" Then
                Dim strToken As String = Request.QueryString("token")

                Dim objExpressCheckoutDetailsReq As GetExpressCheckoutDetailsReq = New GetExpressCheckoutDetailsReq() With
                    {
                        .GetExpressCheckoutDetailsRequest = New GetExpressCheckoutDetailsRequestType() With
                        {
                            .Version = "60.0",
                            .Token = strToken
                        }
                    }

                Dim objPaypalService As PayPalAPIInterfaceServiceService = New PayPalAPIInterfaceServiceService()

                Dim objGetExpressCheckoutDetailsResponse = New GetExpressCheckoutDetailsResponseType
                objGetExpressCheckoutDetailsResponse = objPaypalService.GetExpressCheckoutDetails(objExpressCheckoutDetailsReq)

                If objGetExpressCheckoutDetailsResponse.Errors.Count > 0 Then

                Else
                    Dim respDetails As GetExpressCheckoutDetailsResponseDetailsType = objGetExpressCheckoutDetailsResponse.GetExpressCheckoutDetailsResponseDetails
                    Session("CheckoutDetails") = objGetExpressCheckoutDetailsResponse
                    'TextBox2.Text = resp.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID;
                    'CommitPayPalPayment()
                End If

            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

            'If ex.Message <> "Thread was being aborted." Then
            '    Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHistoryTempId)
            '    If objFunction.CheckDataSet(dstData) Then
            '        Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
            '                                                   "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception GetPaypalPaymentDetail() " +
            '                                                   objFunction.ReturnString(ex.Message) +
            '                                                   objFunction.ReturnString(ex.StackTrace) +
            '                                                   objFunction.ReturnString(ex.InnerException) +
            '                                                   objFunction.ReturnString(DateTime.Now)
            '        UpdateHistory(intCreditHistoryTempId, strNewHistory)
            '    End If
            'End If
            Response.Redirect("thankyou_paypal.aspx")
        End Try
    End Sub
    Function CommitPayPalPayment() As DoExpressCheckoutPaymentResponseType
        Try
            Dim strAmountTaken As String
            Dim objPaypalService As PayPalAPIInterfaceServiceService = New PayPalAPIInterfaceServiceService()
            Dim resp = TryCast(Session("CheckoutDetails"), GetExpressCheckoutDetailsResponseType)
            Dim value As String = resp.GetExpressCheckoutDetailsResponseDetails.[Custom]
            Dim strArr() As String
            strArr = value.Split("#")
            Session("ResponseCreditHistoryTempId") = strArr(0)
            strAmountTaken = strArr(1)

            Dim payReq = New DoExpressCheckoutPaymentReq() With
                {
                    .DoExpressCheckoutPaymentRequest = New DoExpressCheckoutPaymentRequestType() With
                    {
                        .Version = "60.0",
                        .DoExpressCheckoutPaymentRequestDetails = New DoExpressCheckoutPaymentRequestDetailsType With
                        {
                            .Token = resp.GetExpressCheckoutDetailsResponseDetails.Token,
                            .PaymentAction = PaymentActionCodeType.SALE,
                            .PayerID = resp.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID,
                            .PaymentDetails = New List(Of PaymentDetailsType) From
                            {
                                New PaymentDetailsType With
                                {
                                    .OrderTotal = New BasicAmountType With
                                    {
                                        .currencyID = CType([Enum].Parse(GetType(CurrencyCodeType), "GBP"), CurrencyCodeType),
                                        .value = strAmountTaken
                                    }
                                }
                            }
                        }
                    }
                }

            'commit transaction and display results to user
            Dim doResponse As DoExpressCheckoutPaymentResponseType = objPaypalService.DoExpressCheckoutPayment(payReq)
            Return doResponse
            'If doResponse.Errors.Count > 0 Then
            '    'lblError.Text = "This transaction cannot be processed. The amount to be charged is zero.";
            'Else
            '    Dim strTransactionId As String = doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).TransactionID
            '    If strTransactionId <> Nothing Then
            '        'Success
            '    Else
            '        'Error of transaction
            '    End If
            'End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

            If ex.Message <> "Thread was being aborted." Then
                Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(objFunction.ReturnInteger(Session("ResponseCreditHistoryTempId")))
                If objFunction.CheckDataSet(dstData) Then
                    Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                               "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception CommitPayPalPayment() " +
                                                               objFunction.ReturnString(ex.Message) +
                                                               objFunction.ReturnString(ex.StackTrace) +
                                                               objFunction.ReturnString(ex.InnerException) +
                                                               objFunction.ReturnString(DateTime.Now)
                    UpdateHistory(objFunction.ReturnInteger(Session("ResponseCreditHistoryTempId")), strNewHistory)
                End If
            End If

        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to manage client credit.
    ''' </summary>
    Protected Sub ManageClientCredit(ByVal intLoginUserId As Integer, ByVal intNoOfCredit As Integer, ByVal intCreditHistoryTempId As Integer, ByVal strHistory As String, ByVal dblAmountTaken As Double, ByVal doResponse As DoExpressCheckoutPaymentResponseType)
        Try

            If doResponse.Errors.Count > 0 Then
                Dim strMsg As String = "This transaction cannot be processed. The amount to be charged is zero."
                Dim javaScript As String = ""
                javaScript += "<script type='text/javascript'>"
                javaScript += "alert('" + strMsg + "');"
                javaScript += "window.location = 'thankyou_paypal.aspx';"
                javaScript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
            Else
                Dim strAmountTaken As String = objFunction.ReturnString(dblAmountTaken)
                Dim strPaymentStatus As String = objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentStatus)

                Dim strHistoryUpdate As String = strHistory + "<br/>" + "--------- THANKYOU_PAYPAL_TEMP RECORD ----- Get REQUEST " + "<br/>" +
                                                      objFunction.ReturnString(doResponse.Ack) + ", " +
                                                      objFunction.ReturnString(doResponse.CorrelationID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentStatus) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PendingReason) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).FeeAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.value) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentDate) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentType) +
                                                      "<br/>" + objFunction.ReturnString(DateTime.Now)

                UpdateHistory(intCreditHistoryTempId, strHistoryUpdate)
                If strPaymentStatus = "COMPLETED" Then

                    Session("ResponseAmountTaken") = strAmountTaken
                    Session("ResponsePaymentStatus") = strPaymentStatus

                    Dim intCompanyId As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))

                    objBECreditHistory.UserId = intLoginUserId
                    objBECreditHistory.Creditx = intNoOfCredit
                    objBECreditHistory.Whenx = DateTime.Now
                    objBECreditHistory.PaymentMethodId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("PaypalPaymentId"))
                    objBECreditHistory.AmountTaken = objFunction.ReturnDouble(strAmountTaken)
                    objBECreditHistory.Ref = objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).TransactionID)

                    Dim intAffectedRow As Integer = objDLCreditHistory.AddCreditHistory(objBECreditHistory)
                    If intAffectedRow > 0 Then

                        Dim objBEClient As clsBEClient = New clsBEClient
                        objBEClient.ClientId = intLoginUserId
                        objBEClient.CompanyId = intCompanyId
                        Dim dstClient As DataSet = (New clsDLClient()).GetClientById(objBEClient)
                        Dim intClientCredit As Integer = 0
                        If objFunction.CheckDataSet(dstClient) Then
                            intClientCredit = objFunction.ReturnInteger(dstClient.Tables(0).Rows(0)("creditx"))
                        End If

                        Dim intNewClientCredit As Integer = intClientCredit + intNoOfCredit
                        objBEClient.Creditx = intNewClientCredit

                        intAffectedRow = (New clsDLClient()).UpdateClientCreditx(objBEClient)

                        Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                        objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                        objBECreditHistoryTemp.Authorised = 1
                        intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempAuthorisedById(objBECreditHistoryTemp)

                        Dim strNewHistory As String = strHistoryUpdate + "<br/>" + "THANKYOU_PAYPAL_TEMP - succeeded " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                      objFunction.ReturnString(doResponse.Ack) + ", " +
                                                      objFunction.ReturnString(doResponse.CorrelationID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentStatus) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PendingReason) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).FeeAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.value) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentDate) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentType) +
                                                      "<br/>" + objFunction.ReturnString(DateTime.Now)

                        objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                        objBECreditHistoryTemp.History = strNewHistory
                        intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)

                    End If
                    'Request.Cookies.Remove("UserSettings")
                    Response.Redirect("thankyou_paypal.aspx")
                ElseIf strPaymentStatus = "FAILURE" Then
                    Session("ResponseAmountTaken") = strAmountTaken
                    Session("ResponsePaymentStatus") = strPaymentStatus

                    Dim intAffectedRow As Integer = 0

                    Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                    objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                    objBECreditHistoryTemp.Authorised = -99
                    intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempAuthorisedById(objBECreditHistoryTemp)

                    Dim strNewHistory As String = strHistoryUpdate + "<br/>" + "THANKYOU_PAYPAL_TEMP - failed " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                      objFunction.ReturnString(doResponse.Ack) + ", " +
                                                      objFunction.ReturnString(doResponse.CorrelationID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentStatus) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PendingReason) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).FeeAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.value) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentDate) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentType) +
                                                      "<br/>" + objFunction.ReturnString(DateTime.Now)

                    objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                    objBECreditHistoryTemp.History = strNewHistory
                    intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
                    'Request.Cookies.Remove("UserSettings")
                    Response.Redirect("thankyou_paypal.aspx")
                ElseIf strPaymentStatus = "PENDING" Then
                    Session("ResponseAmountTaken") = strAmountTaken
                    Session("ResponsePaymentStatus") = strPaymentStatus

                    Dim intAffectedRow As Integer = 0

                    Dim strNewHistory As String = strHistoryUpdate + "<br/>" + "THANKYOU_PAYPAL_TEMP - Pending " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                      objFunction.ReturnString(doResponse.Ack) + ", " +
                                                      objFunction.ReturnString(doResponse.CorrelationID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentStatus) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PendingReason) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).FeeAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.value) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentDate) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentType) +
                                                      "<br/>" + objFunction.ReturnString(DateTime.Now)

                    Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                    objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                    objBECreditHistoryTemp.History = strNewHistory
                    intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
                    'Request.Cookies.Remove("UserSettings")
                    Response.Redirect("thankyou_waiting.aspx")
                Else
                    Session("ResponseAmountTaken") = strAmountTaken
                    Session("ResponsePaymentStatus") = strPaymentStatus

                    Dim intAffectedRow As Integer = 0

                    Dim strNewHistory As String = strHistoryUpdate + "<br/>" + "NO DATA DELIVERED" + "<br/>" + "THANKYOU_PAYPAL_TEMP " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                      objFunction.ReturnString(doResponse.Ack) + ", " +
                                                      objFunction.ReturnString(doResponse.CorrelationID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentStatus) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PendingReason) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).FeeAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.value) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.currencyID) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentDate) + ", " +
                                                      objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentType) +
                                                      "<br/>" + objFunction.ReturnString(DateTime.Now)


                    Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                    objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                    objBECreditHistoryTemp.History = strNewHistory
                    intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
                    'Request.Cookies.Remove("UserSettings")
                    Response.Redirect("thankyou_paypal.aspx")
                End If

                'Dim strTransactionId As String = doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).TransactionID
                'If strTransactionId <> Nothing Then
                '    'Success
                'Else
                '    'Error of transaction
                'End If
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

            If ex.Message <> "Thread was being aborted." Then
                Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHistoryTempId)
                If objFunction.CheckDataSet(dstData) Then
                    Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                               "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception ManageClientCredit() " +
                                                               objFunction.ReturnString(ex.Message) +
                                                               objFunction.ReturnString(ex.StackTrace) +
                                                               objFunction.ReturnString(ex.InnerException) +
                                                               objFunction.ReturnString(DateTime.Now)
                    UpdateHistory(intCreditHistoryTempId, strNewHistory)
                End If
            End If

        End Try
    End Sub

    ''' <summary>
    ''' This function is used to update history of credit_history_temp.
    ''' </summary>
    Sub UpdateCreditHistoryTemp(ByVal intCreditHistoryTempId As Integer, ByVal strHistory As String, ByVal dblAmountTaken As Double, ByVal intAuthorised As Integer)
        Try

            'Dim doResponse As DoExpressCheckoutPaymentResponseType = CommitPayPalPayment(intCreditHistoryTempId, objFunction.ReturnString(dblAmountTaken))
            Dim doResponse As DoExpressCheckoutPaymentResponseType = CommitPayPalPayment()
            If doResponse.Errors.Count > 0 Then
                'lblError.Text = "This transaction cannot be processed. The amount to be charged is zero.";
                Dim strMsg As String = "This transaction cannot be processed. The amount to be charged is zero."
                Dim javaScript As String = ""
                javaScript += "<script type='text/javascript'>"
                javaScript += "alert('" + strMsg + "');"
                javaScript += "window.location = 'thankyou_paypal.aspx';"
                javaScript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
            Else

                Dim strNewHistory As String = strHistory + "<br/>" + "Update THANKYOU_PAYPAL_TEMP UpdateCreditHistoryTemp() " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                          objFunction.ReturnString(doResponse.Ack) + ", " +
                                                          objFunction.ReturnString(doResponse.CorrelationID) + ", " +
                                                          objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentStatus) + ", " +
                                                          objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PendingReason) + ", " +
                                                          objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).FeeAmount.currencyID) + ", " +
                                                          objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.value) + ", " +
                                                          objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).GrossAmount.currencyID) + ", " +
                                                          objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentDate) + ", " +
                                                          objFunction.ReturnString(doResponse.DoExpressCheckoutPaymentResponseDetails.PaymentInfo(0).PaymentType) +
                                                          "<br/>" + objFunction.ReturnString(DateTime.Now)


                Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                objBECreditHistoryTemp.History = strNewHistory
                Dim intAffectedRow As Integer = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)

                If intAffectedRow > 0 Then
                    If intAuthorised = 1 Then
                        Session("ResponseAmountTaken") = dblAmountTaken.ToString("0.00")
                        Session("ResponsePaymentStatus") = "SUCCESS"
                    ElseIf intAuthorised = -99 Then
                        Session("ResponseAmountTaken") = dblAmountTaken.ToString("0.00")
                        Session("ResponsePaymentStatus") = "failed"
                    Else
                        Session("ResponseAmountTaken") = ""
                        Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
                    End If
                Else
                    Session("ResponseAmountTaken") = ""
                    Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
                End If
                Response.Redirect("thankyou_paypal.aspx")
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

            If ex.Message <> "Thread was being aborted." Then
                Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHistoryTempId)
                If objFunction.CheckDataSet(dstData) Then
                    Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                               "---------- Thankyou_Paypal_Temp RECORD ----- Catch ex As Exception UpdateCreditHistoryTemp() " +
                                                               objFunction.ReturnString(ex.Message) +
                                                               objFunction.ReturnString(ex.StackTrace) +
                                                               objFunction.ReturnString(ex.InnerException) +
                                                               objFunction.ReturnString(DateTime.Now)
                    UpdateHistory(intCreditHistoryTempId, strNewHistory)
                End If
            End If

        End Try
    End Sub

    Sub UpdateHistory(ByVal intCreditHistoryTempId As Integer, ByVal strNewHistory As String)
        Try
            Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
            objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
            objBECreditHistoryTemp.History = strNewHistory
            Dim intAffectedRow As Integer = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            'Session("ResponseAmountTaken") = "0"
            'Session("ResponsePaymentStatus") = "Unsuccessful. Please try again. Your card has not been charged."
            Response.Redirect("thankyou_paypal.aspx")
        End Try
    End Sub

End Class
