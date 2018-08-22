Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class purchase_credits
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/Default.aspx")
            End If

            If Not Page.IsPostBack Then
                Dim intCompanyId As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                Dim intGameCostCredit As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameCostCredit"))
                Dim dstGameCosts As DataSet = (New clsDLGameCosts()).GetGameCostsByCompanyIdAndCredx(intCompanyId, intGameCostCredit)
                If objFunction.CheckDataSet(dstGameCosts) Then
                    LABEL_COST.Text = objFunction.ReturnDouble(dstGameCosts.Tables(0).Rows(0)("amount")).ToString("0.00")
                End If

                Dim dstData As DataSet = (New clsDLClientDetails()).GetClientDetailByClientId(objFunction.ReturnInteger(Session("LoginUserId")))
                If objFunction.CheckDataSet(dstData) Then
                    Dim intBuyVisited As Integer = objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("buy_visited")) + 1
                    Dim objBEClientDetails As clsBEClientDetails = New clsBEClientDetails
                    objBEClientDetails.ClientDetailsId = objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("id"))
                    objBEClientDetails.BuyVisited = intBuyVisited
                    Dim intAffectedRow As Integer = (New clsDLClientDetails()).UpdateClientDetailsBuyVisitedById(objBEClientDetails)
                End If

                Dim objBEClient As clsBEClient = New clsBEClient
                objBEClient.CompanyId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                objBEClient.ClientId = objFunction.ReturnInteger(Session("LoginUserId"))
                Dim dstClientData As DataSet = (New clsDLClient()).GetClientById(objBEClient)
                If objFunction.CheckDataSet(dstClientData) Then
                    If objFunction.ReturnString(dstClientData.Tables(0).Rows(0)("VoucherMessagex")) <> "" Then
                        LABEL_Voucher_Msg.Text = objFunction.ReturnString(dstClientData.Tables(0).Rows(0)("VoucherMessagex"))
                    End If
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Buy.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            'Response.Redirect("payment_process1_1.asp")
            Response.Redirect("payment_process1.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Paydoo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Buy_Paydoo.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            'Response.Redirect("payment_process1_1.asp")
            Response.Redirect("payment_process2.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Paytogather_Click(sender As Object, e As System.EventArgs) Handles BUT_Buy_Paytogather.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            Response.Redirect("payment_process3.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to check voucher code.
    ''' </summary>
    Protected Sub BUT_Voucher_Code_Click(sender As Object, e As System.EventArgs) Handles BUT_Voucher_Code.Click
        Try
            Dim objBEVouchers As clsBEVouchers = New clsBEVouchers
            objBEVouchers.CompanyId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
            objBEVouchers.Codex = TB_Voucher_Code.Text
            Dim dstData As DataSet = (New clsDLVouchers()).GetVouchersByCodexAndCompanyId(objBEVouchers)
            If objFunction.CheckDataSet(dstData) Then
                Dim dtStartDate As DateTime = Convert.ToDateTime(dstData.Tables(0).Rows(0)("startx"))
                Dim dtEndDate As DateTime = Convert.ToDateTime(dstData.Tables(0).Rows(0)("endx"))
                Dim dtTodayDate As DateTime = Convert.ToDateTime(DateTime.Now)

                If Convert.ToBoolean(dstData.Tables(0).Rows(0)("stopx")) = True Then
                    DisplayMessageAndRedirect("This voucher has been stopped. Please contact support", "")
                ElseIf ((dtTodayDate >= dtStartDate) And (dtTodayDate <= dtEndDate)) And objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("stopx")) = 0 Then
                    Dim objBEClient As clsBEClient = New clsBEClient
                    objBEClient.CompanyId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                    objBEClient.ClientId = objFunction.ReturnInteger(Session("LoginUserId"))
                    Dim dstClientData As DataSet = (New clsDLClient()).GetClientById(objBEClient)

                    If objFunction.CheckDataSet(dstClientData) Then
                        If objFunction.ReturnInteger(dstClientData.Tables(0).Rows(0)("vc_code_id")) > 0 Then
                            Dim javaScript As String = ""
                            javaScript += "<script type='text/javascript'>"
                            javaScript += "CheckAndUpdateVouchersCodeId('" + objFunction.ReturnString(Session("LoginUserId")) + "', '" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("id")) + "');"
                            javaScript += "</script>"
                            ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
                        Else
                            Dim intAffectedRow As Integer = UpdateVouchersCodeId(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("id")))
                            If intAffectedRow > 0 Then
                                DisplayMessageAndRedirect("Voucher code updated successfully", "purchase_credits.aspx")
                            Else                                DisplayMessageAndRedirect("There was a system error. If this error persists please contact technical support.", "")
                            End If
                        End If
                    Else
                        Dim intAffectedRow As Integer = UpdateVouchersCodeId(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("id")))
                        If intAffectedRow > 0 Then
                            DisplayMessageAndRedirect("Voucher code updated successfully", "purchase_credits.aspx")
                        Else                            DisplayMessageAndRedirect("There was a system error. If this error persists please contact technical support.", "")
                        End If
                    End If
                ElseIf (dtTodayDate < dtStartDate) Then
                    DisplayMessageAndRedirect("Voucher code has not started yet", "")
                ElseIf (dtTodayDate > dtEndDate) Then
                    DisplayMessageAndRedirect("Voucher code has expired", "")
                End If
            Else
                DisplayMessageAndRedirect("The code entered has not been recognised", "")
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to update voucherid of client.
    ''' </summary>
    Protected Function UpdateVouchersCodeId(ByVal intVoucherId As Integer) As Integer
        Try
            Dim objBEClient As clsBEClient = New clsBEClient
            objBEClient.ClientId = objFunction.ReturnInteger(Session("LoginUserId"))
            objBEClient.VouchersCodeId = intVoucherId
            Dim intAffectedRow As Integer = (New clsDLClient()).UpdateClientVouchersCodeId(objBEClient)
            Return intAffectedRow
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return 0
    End Function

    ''' <summary>
    ''' This function is used to display msg and redirect to link.
    ''' </summary>
    Protected Sub DisplayMessageAndRedirect(ByVal strMsg As String, ByVal strPageLink As String)
        Try
            Dim javaScript As String = ""
            javaScript += "<script type='text/javascript'>"
            javaScript += "alert('" + strMsg + "');"
            If strPageLink <> "" Then
                javaScript += "window.location = '" + strPageLink + "';"
            End If
            javaScript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class
