Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLVouchers
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add vouchers data.
        ''' </summary>
        Public Function AddVouchers(ByVal objBEVouchers As clsBEVouchers) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spVouchers"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddVouchers")
                cmd.Parameters.AddWithValue("Codex", objBEVouchers.Codex)
                cmd.Parameters.AddWithValue("Startx", objBEVouchers.Startx)
                cmd.Parameters.AddWithValue("Endx", objBEVouchers.Endx)
                cmd.Parameters.AddWithValue("NoToBuy", objBEVouchers.NoToBuy)
                cmd.Parameters.AddWithValue("NoToGive", objBEVouchers.NoToGive)
                cmd.Parameters.AddWithValue("Stopx", objBEVouchers.Stopx)
                cmd.Parameters.AddWithValue("Messagex", objBEVouchers.Messagex)
                cmd.Parameters.AddWithValue("CompanyId", objBEVouchers.CompanyId)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddVouchers")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update vouchers details id.
        ''' </summary>
        Public Function UpdateVouchers(ByVal objBEVouchers As clsBEVouchers) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spVouchers"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateVouchers")
                cmd.Parameters.AddWithValue("VouchersId", objBEVouchers.VouchersId)
                cmd.Parameters.AddWithValue("Codex", objBEVouchers.Codex)
                cmd.Parameters.AddWithValue("Startx", objBEVouchers.Startx)
                cmd.Parameters.AddWithValue("Endx", objBEVouchers.Endx)
                cmd.Parameters.AddWithValue("NoToBuy", objBEVouchers.NoToBuy)
                cmd.Parameters.AddWithValue("NoToGive", objBEVouchers.NoToGive)
                cmd.Parameters.AddWithValue("Messagex", objBEVouchers.Messagex)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateVouchers")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update games status by id.
        ''' </summary>
        Public Function UpdateVoucherStopxById(ByVal objBEVouchers As clsBEVouchers) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spVouchers"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateVoucherStopxById")
                cmd.Parameters.AddWithValue("VouchersId", objBEVouchers.VouchersId)
                cmd.Parameters.AddWithValue("Stopx", objBEVouchers.Stopx)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateVoucherStopxById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get voichers data by company_id.
        ''' </summary>
        Public Function GetVouchersByCompanyId(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spVouchers"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetVouchersByCompanyId")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetVouchersByCompanyId")
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
        ''' This function is used to get voichers data by id.
        ''' </summary>
        Public Function GetVouchersById(ByVal intVouchersId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spVouchers"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetVouchersById")
                cmd.Parameters.AddWithValue("VouchersId", intVouchersId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetVouchersById")
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
        ''' This function is used to get voichers data by codex and company_id.
        ''' </summary>
        Public Function GetVouchersByCodexAndCompanyId(ByVal objBEVouchers As clsBEVouchers) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spVouchers"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetVouchersByCodexAndCompanyId")
                cmd.Parameters.AddWithValue("Codex", objBEVouchers.Codex)
                cmd.Parameters.AddWithValue("CompanyId", objBEVouchers.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetVouchersByCodexAndCompanyId")
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
