Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLCompany
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add credit_history data.
        ''' </summary>
        Public Function AddCompany(ByVal objBECompany As clsBECompany) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCompany"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddCompany")
                cmd.Parameters.AddWithValue("Name", objBECompany.Name)
                cmd.Parameters.AddWithValue("Address1", objBECompany.Address1)
                cmd.Parameters.AddWithValue("Address2", objBECompany.Address2)
                cmd.Parameters.AddWithValue("City", objBECompany.City)
                cmd.Parameters.AddWithValue("CountryId", objBECompany.CountryId)
                cmd.Parameters.AddWithValue("Email", objBECompany.Email)
                cmd.Parameters.AddWithValue("Phone", objBECompany.Phone)
                cmd.Parameters.AddWithValue("ContactName", objBECompany.ContactName)
                cmd.Parameters.AddWithValue("Username", objBECompany.Username)
                cmd.Parameters.AddWithValue("Passwordx", objBECompany.Passwordx)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddCompany")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to add credit_history data.
        ''' </summary>
        Public Function UpdateCompany(ByVal objBECompany As clsBECompany) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCompany"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCompany")
                cmd.Parameters.AddWithValue("CompanyId", objBECompany.CompanyId)
                cmd.Parameters.AddWithValue("Name", objBECompany.Name)
                cmd.Parameters.AddWithValue("Address1", objBECompany.Address1)
                cmd.Parameters.AddWithValue("Address2", objBECompany.Address2)
                cmd.Parameters.AddWithValue("City", objBECompany.City)
                cmd.Parameters.AddWithValue("Email", objBECompany.Email)
                cmd.Parameters.AddWithValue("Phone", objBECompany.Phone)
                cmd.Parameters.AddWithValue("ContactName", objBECompany.ContactName)
                cmd.Parameters.AddWithValue("Username", objBECompany.Username)
                cmd.Parameters.AddWithValue("Passwordx", objBECompany.Passwordx)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCompany")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update lastlogged by id.
        ''' </summary>
        Public Function UpdateCompanyLastLogged(ByVal objBECompany As clsBECompany) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCompany"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCompanyLastLogged")
                cmd.Parameters.AddWithValue("LastLogged", objBECompany.LastLogged)
                cmd.Parameters.AddWithValue("CompanyId", objBECompany.CompanyId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCompanyLastLogged")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to check the login credential of company.
        ''' </summary>
        Public Function CheckCompanyLogin(ByVal objBECompany As clsBECompany) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCompany"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckCompanyLogin")
                cmd.Parameters.AddWithValue("Username", objBECompany.Username)
                cmd.Parameters.AddWithValue("Passwordx", objBECompany.Passwordx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckCompanyLogin")
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
        ''' This function is used to get company details.
        ''' </summary>
        Public Function GetCompanyDetail() As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCompany"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCompanyDetail")
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCompanyDetail")
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
