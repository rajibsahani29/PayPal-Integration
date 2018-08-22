Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    
    Public txndatetime As String, storename As String, chargetotal As String, sharedsecret As String, result As String, currency As String, strtimezone As String, hash As String

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If Not Page.IsPostBack Then

                Dim objBEGameStatsView As clsBEGameStatsView = New clsBEGameStatsView
                objBEGameStatsView.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
                objBEGameStatsView.DateAdded = DateTime.Now
                objBEGameStatsView.Typex = 1
                Dim intAffectedRow As Integer = (New clsDLGameStatsView()).AddGameStatsView(objBEGameStatsView)

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

End Class
