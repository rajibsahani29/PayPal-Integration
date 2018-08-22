Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class _default_logged
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not objFunction.ValidateLogin() Then
            Response.Redirect("~/Default.aspx")
        End If

        If Request.Cookies("UserLoginSettings") IsNot Nothing Then
            If objFunction.ReturnInteger(Request.Cookies("UserLoginSettings")("CookieLoginUserId")) > 0 Then
                Session("LoginUserId") = objFunction.ReturnString(Request.Cookies("UserLoginSettings")("CookieLoginUserId"))
            End If
        End If

        If Not Page.IsPostBack Then

            'Dim intClientId As Integer = 0
            'If Request.Cookies("UserLoginSettings") IsNot Nothing Then
            '    If objFunction.ReturnInteger(Request.Cookies("UserLoginSettings")("CookieLoginUserId")) > 0 Then
            '        intClientId = objFunction.ReturnInteger(Request.Cookies("UserLoginSettings")("CookieLoginUserId"))
            '    End If
            'ElseIf objFunction.ReturnInteger(Session("LoginUserId")) > 0 Then
            '    intClientId = objFunction.ReturnInteger(Session("LoginUserId"))
            'End If

            Dim objBEClient As clsBEClient = New clsBEClient
            objBEClient.ClientId = objFunction.ReturnInteger(Session("LoginUserId"))
            objBEClient.CompanyId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
            Dim dstClient As DataSet = (New clsDLClient()).GetClientById(objBEClient)

            If objFunction.CheckDataSet(dstClient) Then
                LABEL_Master1.Text = objFunction.ReturnString(dstClient.Tables(0).Rows(0)("name1"))
                LABEL_Master2.Text = objFunction.ReturnString(dstClient.Tables(0).Rows(0)("creditx"))
                Session("ClientName") = objFunction.ReturnString(dstClient.Tables(0).Rows(0)("name1"))
                Session("ClientCredit") = objFunction.ReturnString(dstClient.Tables(0).Rows(0)("creditx"))
            End If

        End If

    End Sub

    ''' <summary>
    ''' This event is used to logout form system.
    ''' </summary>
    Protected Sub BUT_Logout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Logout.Click
        Try
            Session("LoginUserId") = Nothing
            Session("UserLogged") = Nothing
            Session("ClientName") = Nothing
            Session("ClientCredit") = Nothing
            If HttpContext.Current.Request.Cookies("UserLoginSettings") IsNot Nothing Then
                Response.Cookies("UserLoginSettings").Expires = Now.AddDays(-1)
            End If
            Response.Redirect("Default.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to resend verification email.
    ''' </summary>
    Protected Sub BUT_resend_verification_Click(sender As Object, e As System.EventArgs) Handles BUT_resend_verification.Click
        Try
            Dim objBEClient As clsBEClient = New clsBEClient
            Dim intClientId As Integer = objFunction.ReturnInteger(Session("LoginUserId"))
            objBEClient.ClientId = intClientId
            objBEClient.CompanyId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
            Dim objEmailContent As New clsEmailContent()
            Dim dstData As DataSet = (New clsDLClient()).GetClientById(objBEClient)
            If objFunction.CheckDataSet(dstData) Then
                Dim strVerificationLink As String = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("ServerLoc")) + "verify.aspx?e=" + objFunction.ReturnString(dstData.Tables(0).Rows(0)("emailx")) + "&v=" + objFunction.ReturnString((141275 + intClientId))
                Dim strEmailContent As String = objEmailContent.RegistrationVerification(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), strVerificationLink, objFunction.ReturnString(dstData.Tables(0).Rows(0)("email_signature")))
                Trace.Warn("strEmailContent = " + strEmailContent)
                Dim strMailStatus As String = clsEmail.SendEmail(objFunction.ReturnString(dstData.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstData.Tables(0).Rows(0)("emailx")), "Please verify your account", "Test Msg", strEmailContent, Me)
                If strMailStatus = "Success" Then
                    BUT_resend_verification.Visible = False
                    LABEL_verification.Text = "Email sent to " + objFunction.ReturnString(dstData.Tables(0).Rows(0)("emailx")) + " - please check your JUNK/SPAM folders."
                ElseIf strMailStatus = "EmailIdMissing" Then
                    LABEL_verification.Text = "Email address entered was not registered."
                Else
                    LABEL_verification.Text = "Error in sending your verification email. Please try again."
                End If
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class