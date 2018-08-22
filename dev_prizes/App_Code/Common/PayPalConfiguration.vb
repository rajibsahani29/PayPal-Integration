Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports PayPal
Imports PayPal.Manager


Public Class PayPalConfiguration

    Public Shared Function GetConfig() As Dictionary(Of String, String)
        Return ConfigManager.Instance.GetProperties()
    End Function

    Private Shared Function GetAccessToken() As String
        Dim accessToken As String = New PayPal.OAuthTokenCredential(System.Configuration.ConfigurationManager.AppSettings("clientId"), System.Configuration.ConfigurationManager.AppSettings("clientSecret"), GetConfig()).GetAccessToken()
        Return accessToken
    End Function

    Public Shared Function GetAPIContext() As APIContext
        Dim apiContext As APIContext = New APIContext(GetAccessToken())
        apiContext.Config = GetConfig()
        Return apiContext
    End Function


End Class


