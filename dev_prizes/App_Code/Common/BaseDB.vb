Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class BaseDB

    Public ErrorText As String
    Dim objFunction As New clsCommon()
    'Private objCon As SqlConnection = New SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings("ConnectionString")))
    Private objCon As New SqlConnection

    ''' <summary>
    ''' This function is used to execute query and return integer value.
    ''' Also return last inserted id, set RequestLastInsertId to 'Y' if you want.
    ''' </summary>
    Protected Function ExecuteNoneQueryByCommand(ByVal cmdCommand As SqlCommand, ByVal strFunction As String, Optional ByVal RequestLastInsertId As Char = "N") As Integer
        Dim intLastId As Integer = 0
        Try
            Refresh(objCon)
            cmdCommand.Connection = objCon
            HttpContext.Current.Trace.Warn(strFunction & Convert.ToString(" ::"), cmdCommand.CommandText)
            'PrintParameters(cmdCommand)

            If RequestLastInsertId = "Y" Then
                'cmdCommand.CommandText += ";SELECT SCOPE_IDENTITY();"
                intLastId = objFunction.ReturnInteger(cmdCommand.ExecuteScalar())
                HttpContext.Current.Trace.Warn("Last Inserted ID ::", intLastId.ToString())
            Else
                intLastId = cmdCommand.ExecuteNonQuery()
                HttpContext.Current.Trace.Warn("Recored Affected ::", intLastId.ToString())
            End If

            objCon.Close()
        Catch ex As Exception
            objCon.Close()
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return intLastId
    End Function

    ''' <summary>
    ''' This function is used to execute query and return integer value.
    ''' Also return last inserted id, set RequestLastInsertId to 'Y' if you want and return affected row.
    ''' </summary>
    Protected Function ExecuteScalarByCommandReturnAffectedRow(ByVal cmdCommand As SqlCommand, ByVal strFunction As String, Optional ByVal RequestLastInsertId As Char = "N") As Integer
        Dim intLastId As Integer = 0
        Try
            Refresh(objCon)
            cmdCommand.Connection = objCon
            HttpContext.Current.Trace.Warn(strFunction & Convert.ToString(" ::"), cmdCommand.CommandText)
            'PrintParameters(cmdCommand)

            If RequestLastInsertId = "Y" Then
                'cmdCommand.CommandText += ";SELECT SCOPE_IDENTITY();"
                intLastId = objFunction.ReturnInteger(cmdCommand.ExecuteScalar())
                HttpContext.Current.Trace.Warn("Last Inserted ID ::", intLastId.ToString())
            Else
                intLastId = objFunction.ReturnInteger(cmdCommand.ExecuteScalar())
                HttpContext.Current.Trace.Warn("Recored Affected ::", intLastId.ToString())
            End If

            objCon.Close()
        Catch ex As Exception
            objCon.Close()
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return intLastId
    End Function

    ''' <summary>
    ''' This function is used to execute scaler function query.
    ''' </summary>
    Protected Function ExecuteScalerByCommand(ByVal cmdCommand As SqlCommand, ByVal strFunction As String) As Object
        Dim obj As New [Object]()
        Try
            Refresh(objCon)
            cmdCommand.Connection = objCon
            'obj = cmdCommand.ExecuteScalar();
            HttpContext.Current.Trace.Warn(strFunction & Convert.ToString(" ::"), cmdCommand.CommandText)
            'PrintParameters(cmdCommand)
            obj = cmdCommand.ExecuteScalar()
            HttpContext.Current.Trace.Warn("Result ::", obj.ToString())
            objCon.Close()
            If obj Is Nothing Then
                obj = ""
            End If
        Catch ex As Exception
            ErrorText = ex.Message
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return obj
    End Function

    ''' <summary>
    ''' This function is used to execute query to get result and it return DataSet.
    ''' </summary>
    Protected Function FillDataSetByCommand(ByVal cmdCommand As SqlCommand, ByVal strFunction As String) As DataSet
        Dim ds As New DataSet()
        Dim ad As SqlDataAdapter
        Try
            Refresh(objCon)
            cmdCommand.Connection = objCon
            HttpContext.Current.Trace.Warn(strFunction & Convert.ToString(" ::"), cmdCommand.CommandText)
            'PrintParameters(cmdCommand)
            ad = New SqlDataAdapter(cmdCommand)
            ad.Fill(ds)
            objCon.Close()
        Catch ex As Exception
            ErrorText = ex.Message
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return ds
    End Function

    ''' <summary>
    ''' This function is used for error tracing and print parameters which you have pass in query on Trace.axd
    ''' </summary>
    Protected Sub PrintParameters(ByVal cmd As SqlCommand)
        Dim objParameterList As SqlParameterCollection = cmd.Parameters
        Try
            If objParameterList.Count > 0 Then
                For intPl As Integer = 0 To objParameterList.Count - 1
                    HttpContext.Current.Trace.Warn("Parameter ", objParameterList(intPl).ParameterName + "  ::  " + objParameterList(intPl).Value)
                Next
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used refresh the connection.
    ''' </summary>
    Protected Sub Refresh(ByVal con As SqlConnection)
        InitializeConnection(con)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            Else
                con.Close()
                con.Open()
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This function is used initialize the connection.
    ''' </summary>
    Protected Sub InitializeConnection(ByRef con As SqlConnection)
        Try
            'Private objCon As SqlConnection = New SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings("ConnectionString")))
            Dim strSelectedDatabases As String = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("SelectedDatabases"))
            Dim strConnectionString As String = String.Format(objFunction.ReturnString(ConfigurationManager.ConnectionStrings("ConnectionString")), strSelectedDatabases)
            HttpContext.Current.Trace.Warn("strSelectedDatabases = " + strSelectedDatabases)
            HttpContext.Current.Trace.Warn("strConnectionString = " + strConnectionString)
            'con = New SqlConnection(strConnectionString)
            con.ConnectionString = strConnectionString
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

End Class
