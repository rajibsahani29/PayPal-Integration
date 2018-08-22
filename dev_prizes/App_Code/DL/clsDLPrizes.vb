Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLPrizes
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add prizes data.
        ''' </summary>
        Public Function AddPrizes(ByVal objBEPrizes As clsBEPrizes) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddPrizes")
                cmd.Parameters.AddWithValue("CompanyId", objBEPrizes.CompanyId)
                cmd.Parameters.AddWithValue("Namex", objBEPrizes.Namex)
                cmd.Parameters.AddWithValue("ShortDesc", objBEPrizes.ShortDesc)
                cmd.Parameters.AddWithValue("LongDesc", objBEPrizes.LongDesc)
                cmd.Parameters.AddWithValue("Misc", objBEPrizes.Misc)
                cmd.Parameters.AddWithValue("MainImage", objBEPrizes.MainImage)
                cmd.Parameters.AddWithValue("Valuex", objBEPrizes.Valuex)
                cmd.Parameters.AddWithValue("NoCredits", objBEPrizes.NoCredits)
                cmd.Parameters.AddWithValue("CategoryId", objBEPrizes.CategoryId)
                
                'Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddPrizes")
                Dim intPrizesId As Integer = ExecuteNoneQueryByCommand(cmd, "AddPrizes", "Y")
                Return intPrizesId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update prizes data.
        ''' </summary>
        Public Function UpdatePrizes(ByVal objBEPrizes As clsBEPrizes) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdatePrizes")
                cmd.Parameters.AddWithValue("PrizesId", objBEPrizes.PrizesId)
                cmd.Parameters.AddWithValue("Namex", objBEPrizes.Namex)
                cmd.Parameters.AddWithValue("ShortDesc", objBEPrizes.ShortDesc)
                cmd.Parameters.AddWithValue("LongDesc", objBEPrizes.LongDesc)
                cmd.Parameters.AddWithValue("Misc", objBEPrizes.Misc)
                cmd.Parameters.AddWithValue("MainImage", objBEPrizes.MainImage)
                cmd.Parameters.AddWithValue("Valuex", objBEPrizes.Valuex)
                cmd.Parameters.AddWithValue("NoCredits", objBEPrizes.NoCredits)
                cmd.Parameters.AddWithValue("CategoryId", objBEPrizes.CategoryId)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdatePrizes")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get prizes data by company_id.
        ''' </summary>
        Public Function GetPrizesByCompanyIdFillInDD(ByVal inCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetPrizesByCompanyIdFillInDD")
                cmd.Parameters.AddWithValue("CompanyId", inCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetPrizesByCompanyIdFillInDD")
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
        ''' This function is used to get prizes data by id and company_id.
        ''' </summary>
        Public Function GetPrizesDetailById(ByVal objBEPrizes As clsBEPrizes) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetPrizesDetailById")
                cmd.Parameters.AddWithValue("PrizesId", objBEPrizes.PrizesId)
                cmd.Parameters.AddWithValue("CompanyId", objBEPrizes.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetPrizesDetailById")
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
        ''' This function is used to get prizes data by company_id, status and orderx.
        ''' </summary>
        Public Function GetPrizesByCompanyIdStatusAndOrderx(ByVal objBEPrizes As clsBEPrizes) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizes"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetPrizesByCompanyIdStatusAndOrderx")
                cmd.Parameters.AddWithValue("CategoryId", objBEPrizes.CategoryId)
                cmd.Parameters.AddWithValue("CompanyId", objBEPrizes.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetPrizesByCompanyIdStatusAndOrderx")
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
