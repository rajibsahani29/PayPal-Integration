Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail

Public Class clsEmail

    Public Shared Function SendEmail(ByVal namex As String, ByVal emailx As String, ByVal subjectx As String, ByVal messageLink As String, ByVal filex As String, ByVal controlx As Control, Optional ByVal replyto As String = "", Optional ByVal cc As String = "", Optional ByVal bcc As String = "") As String

        'Dim TemplateFile As String = HttpContext.Current.Server.MapPath("~/emails/" + filex + ".html")
        'Dim TemplateFile As String = HttpContext.Current.Server.MapPath("~/emails/" + filex)

        'Dim md As MailDefinition = New MailDefinition

        'md.BodyFileName = filex

        'md.From = "Easyways <donotreply@tentaclesolutions.co.uk>" '"rsthelord@gmail.com" '"Easyways <donotreply@tentaclesolutions.co.uk>"

        'md.Subject = subjectx

        'md.Priority = Net.Mail.MailPriority.High

        'md.IsBodyHtml = True

        'Dim replacements As ListDictionary = New ListDictionary
        'replacements.Add("<%To%>", namex)
        'replacements.Add("<%linkx%>", messageLink)

        'Dim msg As System.Net.Mail.MailMessage
        'msg = md.CreateMailMessage(emailx, replacements, controlx)

        'Dim sc As SmtpClient = New SmtpClient()

        'Try
        '    sc.Host = "mail.systems.easyways.co.uk"
        '    'sc.Host = "smtp.gmail.com"
        '    'sc.Port = '587 '25
        '    'sc.Credentials = New System.Net.NetworkCredential("rsthelord@gmail.com", "Keshav123")
        '    sc.Credentials = New System.Net.NetworkCredential("donotreply@systems.easyways.co.uk", "d7jh6kH4J2HG")
        '    sc.Send(msg)

        '    HttpContext.Current.Trace.Warn("Mail Status", "Send Success")

        '    ' sc.Dispose()
        '    Return 1
        'Catch ex As Exception
        '    Return -1
        '    '  sc.Dispose()
        'Finally
        '    '  sc.Dispose()
        'End Try

        Try
            'Dim fromaddr As String = "test@gmail.com"
            'Dim password As String = "pword"
            'Dim strHostName As String = "smtp.gmail.com"
            'Dim intPort As Integer = 587

            '  Dim fromaddr As String = "donotreply@systems.easyways.co.uk"
            '  Dim password As String = "d7jh6kH4J2HG"
            '  Dim strHostName As String = "mail.systems.easyways.co.uk"
            '  Dim intPort As Integer = 25

            If emailx <> "" Then
                'Dim fromaddr As String = "donotreply@systems.easyways.co.uk"
                'Dim password As String = "d7jh6kH4J2HG"
                'Dim strHostName As String = "mail.placetheball.com"

                Dim fromaddr As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("MailFrom"))
                Dim password As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("MailFromPass"))
                Dim strHostName As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("MailHost"))
                'Dim intPort As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MailPort"))

                Dim Message As New MailMessage()
                Dim smtp As SmtpClient

                Message.From = New MailAddress(fromaddr)
                smtp = New SmtpClient()
                smtp.Host = strHostName
                'smtp.Port = intPort
                'smtp.EnableSsl = True
                ' smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
                ' smtp.UseDefaultCredentials = False
                smtp.Credentials = New NetworkCredential(fromaddr, password)
                ' smtp.TargetName = "STARTTLS/smtp.gmail.com"

                Message.IsBodyHtml = True
                Message.Body = filex
                Message.Subject = subjectx
                Message.[To].Add(emailx)
                If replyto <> "" Then
                    Message.ReplyToList.Add(replyto)
                End If
                If cc <> "" Then
                    Message.CC.Add(cc)
                End If
                If bcc <> "" Then
                    Message.Bcc.Add(bcc)
                End If
                smtp.Send(Message)
                Return "Success"
            Else
                'Return "Email Id Not Available"
                Return "EmailIdMissing"
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        'Return "Error in mail sending"
        Return "Error"
    End Function

    ''' <summary>
    ''' Check Email Address
    ''' </summary>
    Public Function CheckEmailAddress(ByVal strEmailId As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

        Dim emailAddressMatch As Match = Regex.Match(strEmailId, pattern)
        If emailAddressMatch.Success Then
            If (CheckEmailHost(strEmailId)) Then
                'emailaddresscheck = True
                Return True
            Else
                'emailaddresscheck = False
                Return False
            End If
        Else
            'emailaddresscheck = False
            Return False
        End If
    End Function

    ''' <summary>
    ''' Check Email Address
    ''' </summary>
    Public Function CheckEmailHost(ByVal strEmailId As String) As Boolean

        Try
            Dim bnlFlag As Boolean = False
            Dim strName As String = ""
            Dim strHostName() As String = strEmailId.Split("@")
            strName = strHostName(1)

            Dim host As IPHostEntry = Dns.GetHostEntry(strName)
            Dim ip As IPAddress() = host.AddressList

            For index = 0 To ip.Length - 1
                'EmailhostCheck = True
                bnlFlag = True
            Next index

            Return bnlFlag
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            Return False
        End Try
        Return False
    End Function

End Class
