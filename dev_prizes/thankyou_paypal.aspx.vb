Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class thankyou_paypal
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then

                Dim intCreditHisTempId As Integer = 0
                If Request.Cookies("UserSettings") IsNot Nothing Then
                    intCreditHisTempId = objFunction.ReturnInteger(Request.Cookies("UserSettings")("CreditHistoryTempId")) - 141275
                ElseIf objFunction.ReturnString(Session("CreditHistoryTempId")) <> "" Then
                    intCreditHisTempId = objFunction.ReturnInteger(Session("CreditHistoryTempId"))
                End If

                If Session("ResponsePaymentStatus") = "Approved" Or Session("ResponsePaymentStatus") = "COMPLETED" Then

                    If intCreditHisTempId > 0 Then
                        Dim objEmailContent As New clsEmailContent()
                        Dim intCompanyId As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempWithClientById(intCreditHisTempId, intCompanyId)
                        If objFunction.CheckDataSet(dstData) Then
                            Dim strEmailContent As String = objEmailContent.Thankyou_SuccessPayment(objFunction.ReturnString(dstData.Tables(0).Rows(0)("credx")), SetDateVal(dstData.Tables(0).Rows(0)("whenx")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")).ToString("0.00"), objFunction.ReturnString(dstData.Tables(0).Rows(0)("email_signature")))
                            Trace.Warn("strEmailContent = " + strEmailContent)
                            Dim strMailStatus As String = clsEmail.SendEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("emailx")), "Thank you for your payment", "Test Msg", strEmailContent, Me)
                            If strMailStatus = "Success" Then
                                'Label_Register.Text = "Thank you for registering. A verification email has been sent to you."
                            ElseIf strMailStatus = "EmailIdMissing" Then
                                'Label_Register.Text = "Email Id not available."
                            Else
                                'Label_Register.Text = "Error in sending your verification email. Please check all details and try again."
                            End If
                        End If
                    End If

                ElseIf Session("ResponsePaymentStatus") = "Rejected" Or Session("ResponsePaymentStatus") = "FAILURE" Then
                    If intCreditHisTempId > 0 Then
                        Dim objEmailContent As New clsEmailContent()
                        Dim intCompanyId As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempWithClientById(intCreditHisTempId, intCompanyId)
                        If objFunction.CheckDataSet(dstData) Then
                            Dim strEmailContent As String = objEmailContent.Thankyou_DeclinedPayment(SetDateVal(dstData.Tables(0).Rows(0)("whenx")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("email_signature")))
                            Trace.Warn("strEmailContent = " + strEmailContent)
                            Dim strMailStatus As String = clsEmail.SendEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("emailx")), "Important message about your recent payment", "Test Msg", strEmailContent, Me)
                            If strMailStatus = "Success" Then
                                'Label_Register.Text = "Thank you for registering. A verification email has been sent to you."
                            ElseIf strMailStatus = "EmailIdMissing" Then
                                'Label_Register.Text = "Email Id not available."
                            Else
                                'Label_Register.Text = "Error in sending your verification email. Please check all details and try again."
                            End If
                        End If
                    End If
                End If

                LABEL_Thankyou1.Text = objFunction.ReturnDouble(Session("ResponseAmountTaken")).ToString("0.00")
                LABEL_Thankyou2.Text = Session("ResponsePaymentStatus")

                'Request.Cookies.Remove("UserSettings")
                If HttpContext.Current.Request.Cookies("UserSettings") IsNot Nothing Then
                    Response.Cookies("UserSettings").Expires = Now.AddDays(-1)
                End If
                Session("TotalCreditAmount") = Nothing
                Session("NoOfCredit") = Nothing
                Session("CreditHistoryTempId") = Nothing
                'Session("CreditHistoryTempEntryFlag") = Nothing
                Session("ResponseAmountTaken") = Nothing
                Session("ResponsePaymentStatus") = Nothing

            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used to set date value
    ''' </summary>
    Public Function SetDateVal(ByVal value As Object) As String
        Try
            If objFunction.ReturnString(value) <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(value)
                Return dt.ToString("dd/MM/yyyy")
            Else
                Return ""
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ""
    End Function

End Class
