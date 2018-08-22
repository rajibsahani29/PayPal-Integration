Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLCreditProblems
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add credit_problems.
        ''' </summary>
        Public Function AddCreditProblems(ByVal objBECreditProblems As clsBECreditProblems) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditProblems"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddCreditProblems")
                cmd.Parameters.AddWithValue("ClientId", objBECreditProblems.ClientId)
                cmd.Parameters.AddWithValue("CompanyId", objBECreditProblems.CompanyId)
                cmd.Parameters.AddWithValue("AllInfo", objBECreditProblems.AllInfo)
                cmd.Parameters.AddWithValue("Whenx", objBECreditProblems.Whenx)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "AddCreditProblems")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get credit_problem.
        ''' </summary>
        Public Function GetCreditProblemsAll() As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditProblems"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCreditProblemsAll")
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCreditProblemsAll")
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
