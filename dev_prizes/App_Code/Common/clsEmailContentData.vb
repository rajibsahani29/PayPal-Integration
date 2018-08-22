Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class clsEmailContentData
    Inherits BaseDB

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' This function is used to get agent details and fill in dropdown.
    ''' </summary>
    Public Function CustomizedReply(ByVal intBookingId As Integer) As DataSet

        Dim cmd As New SqlCommand()
        Try
            cmd.CommandText = "EW_spEmailContentData"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("Action", "CustomizedReply")
            cmd.Parameters.AddWithValue("BookingId", intBookingId)
            Dim dstData As DataSet = FillDataSetByCommand(cmd, "CustomizedReply")
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
