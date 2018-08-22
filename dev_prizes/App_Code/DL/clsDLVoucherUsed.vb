Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLVoucherUsed
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add vouchers_used data.
        ''' </summary>
        Public Function AddVoucherUsed(ByVal objBEVoucherUsed As clsBEVoucherUsed) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spVoucherUsed"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddVoucherUsed")
                cmd.Parameters.AddWithValue("ClientId", objBEVoucherUsed.ClientId)
                cmd.Parameters.AddWithValue("VouchersId", objBEVoucherUsed.VouchersId)
                cmd.Parameters.AddWithValue("Whenx", objBEVoucherUsed.Whenx)
                cmd.Parameters.AddWithValue("CreditsGiven", objBEVoucherUsed.CreditsGiven)
                cmd.Parameters.AddWithValue("CreditsBought", objBEVoucherUsed.CreditsBought)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddVoucherUsed")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
