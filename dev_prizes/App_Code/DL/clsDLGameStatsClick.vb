Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLGameStatsClick
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add game_stats_view data.
        ''' </summary>
        Public Function AddGameStatsClick(ByVal objBEGameStatsClick As clsBEGameStatsClick) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGameStatsClick"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddGameStatsClick")
                cmd.Parameters.AddWithValue("GameId", objBEGameStatsClick.GameId)
                cmd.Parameters.AddWithValue("DateAdded", objBEGameStatsClick.DateAdded)
                cmd.Parameters.AddWithValue("Typex", objBEGameStatsClick.Typex)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddGameStatsClick")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace