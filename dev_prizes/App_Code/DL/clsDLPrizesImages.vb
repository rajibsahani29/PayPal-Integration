Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLPrizesImages
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add prizes_images.
        ''' </summary>
        Public Function AddPrizesImages(ByVal objBEPrizesImages As clsBEPrizesImages) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizesImages"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddPrizesImages")
                cmd.Parameters.AddWithValue("PrizesId", objBEPrizesImages.PrizesId)
                cmd.Parameters.AddWithValue("ImageLoc", objBEPrizesImages.ImageLoc)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddPrizesImages")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update prizes_images data.
        ''' </summary>
        Public Function UpdatePrizesImages(ByVal objBEPrizesImages As clsBEPrizesImages) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizesImages"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdatePrizesImages")
                cmd.Parameters.AddWithValue("PrizesImagesId", objBEPrizesImages.PrizesImagesId)
                cmd.Parameters.AddWithValue("ImageLoc", objBEPrizesImages.ImageLoc)

                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdatePrizesImages")

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete prizes_images by ids.
        ''' </summary>
        Public Function DeletePrizesImageseByIds(ByVal strDeletedPrizesImagesIds As String) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizesImages"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeletePrizesImageseByIds")
                cmd.Parameters.AddWithValue("DeletedPrizesImagesIds", strDeletedPrizesImagesIds)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeletePrizesImageseByIds")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete prizes_images by id.
        ''' </summary>
        Public Function DeletePrizesImageseById(ByVal intPrizesImagesId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizesImages"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeletePrizesImageseById")
                cmd.Parameters.AddWithValue("PrizesImagesId", intPrizesImagesId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeletePrizesImageseById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get prizes_images data by prizesid.
        ''' </summary>
        Public Function GetPrizesImagesByPrizesId(ByVal intPrizesId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spPrizesImages"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetPrizesImagesByPrizesId")
                cmd.Parameters.AddWithValue("PrizesId", intPrizesId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetPrizesImagesByPrizesId")
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
