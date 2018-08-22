Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLGames
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add game data.
        ''' </summary>
        Public Function AddGames(ByVal objBEGames As clsBEGames) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGames"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddGames")
                cmd.Parameters.AddWithValue("Name", objBEGames.Name)
                cmd.Parameters.AddWithValue("ServerLoc", objBEGames.ServerLoc)
                cmd.Parameters.AddWithValue("Status", objBEGames.Status)
                cmd.Parameters.AddWithValue("Wonx", objBEGames.Wonx)
                cmd.Parameters.AddWithValue("Wony", objBEGames.Wony)
                cmd.Parameters.AddWithValue("CompanyId", objBEGames.CompanyId)
                cmd.Parameters.AddWithValue("EmailSignature", objBEGames.EmailSignature)
                cmd.Parameters.AddWithValue("MaxBalls", objBEGames.MaxBalls)
                cmd.Parameters.AddWithValue("ServerId", objBEGames.ServerId)
                cmd.Parameters.AddWithValue("LaunchDate", (If(objBEGames.LaunchDate <> DateTime.MinValue, objBEGames.LaunchDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("EndDate", (If(objBEGames.EndDate <> DateTime.MinValue, objBEGames.EndDate, DirectCast(DBNull.Value, Object))))

                Dim intGamesId As Integer = ExecuteNoneQueryByCommand(cmd, "AddGames", "Y")
                Return intGamesId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update game data.
        ''' </summary>
        Public Function UpdateGames(ByVal objBEGames As clsBEGames) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGames"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateGames")
                cmd.Parameters.AddWithValue("GamesId", objBEGames.GamesId)
                cmd.Parameters.AddWithValue("Name", objBEGames.Name)
                cmd.Parameters.AddWithValue("ServerLoc", objBEGames.ServerLoc)
                cmd.Parameters.AddWithValue("Status", objBEGames.Status)
                cmd.Parameters.AddWithValue("Wonx", objBEGames.Wonx)
                cmd.Parameters.AddWithValue("Wony", objBEGames.Wony)
                cmd.Parameters.AddWithValue("EmailSignature", objBEGames.EmailSignature)
                cmd.Parameters.AddWithValue("MaxBalls", objBEGames.MaxBalls)
                cmd.Parameters.AddWithValue("ServerId", objBEGames.ServerId)
                cmd.Parameters.AddWithValue("LaunchDate", (If(objBEGames.LaunchDate <> DateTime.MinValue, objBEGames.LaunchDate, DirectCast(DBNull.Value, Object))))
                cmd.Parameters.AddWithValue("EndDate", (If(objBEGames.EndDate <> DateTime.MinValue, objBEGames.EndDate, DirectCast(DBNull.Value, Object))))

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateGames")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update games wonx and wonx by id.
        ''' </summary>
        Public Function UpdateGamesWonxWonyById(ByVal objBEGames As clsBEGames) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGames"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateGamesWonxWonyById")
                cmd.Parameters.AddWithValue("Wonx", objBEGames.Wonx)
                cmd.Parameters.AddWithValue("Wony", objBEGames.Wony)
                cmd.Parameters.AddWithValue("GamesId", objBEGames.GamesId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateGamesWonxWonyById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get games data by id.
        ''' </summary>
        Public Function GetGamesById(ByVal objBEGames As clsBEGames) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGames"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetGamesById")
                cmd.Parameters.AddWithValue("GamesId", objBEGames.GamesId)
                cmd.Parameters.AddWithValue("CompanyId", objBEGames.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetGamesById")
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
        ''' This function is used to get games data by company_id.
        ''' </summary>
        Public Function GetGamesByCompanyId(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGames"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetGamesByCompanyId")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetGamesByCompanyId")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
