Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLGameStatsView
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add game_stats_view data.
        ''' </summary>
        Public Function AddGameStatsView(ByVal objBEGameStatsView As clsBEGameStatsView) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGameStatsView"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddGameStatsView")
                cmd.Parameters.AddWithValue("GameId", objBEGameStatsView.GameId)
                cmd.Parameters.AddWithValue("DateAdded", objBEGameStatsView.DateAdded)
                cmd.Parameters.AddWithValue("Typex", objBEGameStatsView.Typex)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddGameStatsView")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
