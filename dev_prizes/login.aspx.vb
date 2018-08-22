Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class _login
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBEClient As clsBEClient = New clsBEClient
    Dim objDLClient As clsDLClient = New clsDLClient
    Dim objEmail As clsEmail = New clsEmail


    ''' <summary>
    ''' Load event of the page
    ''' </summary>

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Request.Cookies("UserLoginSettings") IsNot Nothing Then
                If objFunction.ReturnInteger(Request.Cookies("UserLoginSettings")("CookieLoginUserId")) > 0 Then
                    Session("LoginUserId") = objFunction.ReturnString(Request.Cookies("UserLoginSettings")("CookieLoginUserId"))
                End If
            End If

            If objFunction.ValidateLogin() Then
                objBEClient.ClientId = objFunction.ReturnInteger(Session("LoginUserId"))
                objBEClient.LastLogin = DateTime.Now
                objDLClient.UpdateClientLastLogin(objBEClient)

                Response.Redirect("~/Default.aspx")
            End If

            If Not Page.IsPostBack Then

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to check client login.
    ''' </summary>
    Protected Sub BUT_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Login.Click
        Try
            If objEmail.CheckEmailAddress(TB_Email.Text) Then
                Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
                objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
                objBEGameStatsClick.DateAdded = DateTime.Now
                objBEGameStatsClick.Typex = 1
                Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

                objBEClient.Emailx = TB_Email.Text
                objBEClient.Passwordx = TB_Password.Text
                objBEClient.CompanyId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))

                Dim dstClientLogin As DataSet = objDLClient.CheckClientLogin(objBEClient)

                If objFunction.CheckDataSet(dstClientLogin) Then
                    Session("LoginUserId") = objFunction.ReturnString(dstClientLogin.Tables(0).Rows(0)("id"))
                    Session("UserLogged") = "1"

                    objBEClient.ClientId = objFunction.ReturnInteger(dstClientLogin.Tables(0).Rows(0)("id"))
                    objBEClient.LastLogin = DateTime.Now
                    objDLClient.UpdateClientLastLogin(objBEClient)

                    If objFunction.ReturnInteger(dstClientLogin.Tables(0).Rows(0)("verifiedx")) = 0 Then
                        Session("UserVerifiedx") = "1"
                    End If

                    Dim myCookie As HttpCookie = New HttpCookie("UserLoginSettings")
                    myCookie("CookieLoginUserId") = objFunction.ReturnString(dstClientLogin.Tables(0).Rows(0)("id"))
                    myCookie("CookieUserLogged") = "1"
                    myCookie.Expires = Now.AddDays(10)
                    Response.Cookies.Add(myCookie)
                    'Response.Redirect("default_logged.aspx")
                    Response.Redirect(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("FirstPageName")))

                    'If objFunction.ReturnInteger(dstClientLogin.Tables(0).Rows(0)("verifiedx")) = 1 Then

                    'Else
                    '    LABEL_Login.Text = "Your account has not been verified yet."
                    'End If
                Else
                    LABEL_Login.Text = "Email and/or Password is incorrect."
                End If
            Else
                LABEL_Login.Text = "Enter the Correct Email and Password."

            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to reset client account.
    ''' </summary>
    Protected Sub BUT_Reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Reset.Click
        Try
            If objEmail.CheckEmailAddress(TB_Email_Reset.Text) Then
                objBEClient.Emailx = TB_Email_Reset.Text
                objBEClient.CompanyId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                Dim dstCheckClientEmail As DataSet = objDLClient.CheckClientEmail(objBEClient)
                If objFunction.CheckDataSet(dstCheckClientEmail) Then
                    'Dim strVerificationLink As String = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("ServerLoc")) + "forgottenpassword.aspx?e=" + objFunction.ReturnString(dstCheckClientEmail.Tables(0).Rows(0)("emailx")) + "&v=" + objFunction.ReturnString((141275 + objFunction.ReturnInteger(dstCheckClientEmail.Tables(0).Rows(0)("id"))))
                    'Dim strEmailContent As String = (New clsEmailContent()).ResetEmail(objFunction.ReturnString(dstCheckClientEmail.Tables(0).Rows(0)("name1")), strVerificationLink, objFunction.ReturnString(dstCheckClientEmail.Tables(0).Rows(0)("email_signature")))
                    'Trace.Warn("strEmailContent = " + strEmailContent)

                    'Dim strMailStatus As String = clsEmail.SendEmail(objFunction.ReturnString(dstCheckClientEmail.Tables(0).Rows(0)("name1")), objFunction.ReturnString(dstCheckClientEmail.Tables(0).Rows(0)("emailx")), "Please reset your account", "Test Msg", strEmailContent, Me)
                    'If strMailStatus = "Success" Then
                    '    TB_Email_Reset.Text = ""
                    '    LABEL_Login.Text = "An email to reset your password has been sent to you."
                    'ElseIf strMailStatus = "EmailIdMissing" Then
                    '    LABEL_Login.Text = "Email Id not available."
                    'Else
                    '    LABEL_Login.Text = "Error in sending your reset email. Please check all details and try again."
                    'End If
                Else
                    LABEL_Login.Text = "Email address has not been registered."
                End If
            Else
                LABEL_Login.Text = "There is an issue with the Email."

            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class
