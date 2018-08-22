Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLGameCosts
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to get game_costs by companyid and credx.
        ''' </summary>
        Public Function GetGameCostsByCompanyIdAndCredx(ByVal intCompanyId As Integer, ByVal intCredx As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGameCosts"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetGameCostsByCompanyIdAndCredx")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("Credx", intCredx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetGameCostsByCompanyIdAndCredx")
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
        ''' This function is used to get game_costs by companyid and user entered credx.
        ''' </summary>
        Public Function GetGameCostsByCompanyIdAndUserCredx(ByVal intCompanyId As Integer, ByVal intCredx As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spGameCosts"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetGameCostsByCompanyIdAndUserCredx")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                cmd.Parameters.AddWithValue("Credx", intCredx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetGameCostsByCompanyIdAndUserCredx")
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