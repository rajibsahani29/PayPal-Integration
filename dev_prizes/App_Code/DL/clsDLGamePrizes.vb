Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLGamePrizes
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add game_prizes data.
        ''' </summary>
        Public Function AddGamePrizes(ByVal objBEGamePrizes As clsBEGamePrizes) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGamePrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddGamePrizes")
                cmd.Parameters.AddWithValue("GamesId", objBEGamePrizes.GamesId)
                cmd.Parameters.AddWithValue("PrizesId", objBEGamePrizes.PrizesId)
                cmd.Parameters.AddWithValue("Orderx", objBEGamePrizes.Orderx)
                cmd.Parameters.AddWithValue("CompanyId", objBEGamePrizes.CompanyId)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddGamePrizes")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get game_prizes data by company_id.
        ''' </summary>
        Public Function GetGamePrizesByCompanyId(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGamePrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetGamePrizesByCompanyId")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetGamePrizesByCompanyId")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get game_prizes data by game_id.
        ''' </summary>
        Public Function GetGamePrizesByGameId(ByVal objBEGamePrizes As clsBEGamePrizes) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGamePrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetGamePrizesByGameId")
                cmd.Parameters.AddWithValue("GamesId", objBEGamePrizes.GamesId)
                cmd.Parameters.AddWithValue("PrizesId", objBEGamePrizes.PrizesId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetGamePrizesByGameId")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to perform gridview operation for game_prizes.
        ''' </summary>
        Public Function PerformGridViewOpertaion(ByVal strAction As String, ByVal objBEGamePrizes As clsBEGamePrizes) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGamePrizes"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "UPDATE" Then
                    cmd.Parameters.AddWithValue("Action", "UpdateGamePrizesOrderxById")
                    cmd.Parameters.AddWithValue("GamePrizesId", objBEGamePrizes.GamePrizesId)
                    cmd.Parameters.AddWithValue("Orderx", objBEGamePrizes.Orderx)
                ElseIf strAction = "DELETE" Then
                    cmd.Parameters.AddWithValue("Action", "DeleteGamePrizesById")
                    cmd.Parameters.AddWithValue("GamePrizesId", objBEGamePrizes.GamePrizesId)
                End If
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "PerformGridViewOpertaion")
                Return intAffectedRow
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
