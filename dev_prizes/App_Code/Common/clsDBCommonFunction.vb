Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class clsDBCommonFunction
    Inherits BaseDB

    Public Sub FillDropDownByDataSet(ByVal ddlControl As DropDownList, ByVal dstData As DataSet, Optional ByVal strSelectText As String = "")
        ddlControl.Items.Clear()
        ddlControl.DataSource = dstData
        ddlControl.DataValueField = "Id"
        ddlControl.DataTextField = "Value"
        ddlControl.DataBind()
        If Not String.IsNullOrEmpty(strSelectText) Then
            ddlControl.Items.Insert(0, New ListItem(strSelectText, "-1"))
            ddlControl.Items(0).Selected = True
        End If
    End Sub

End Class
