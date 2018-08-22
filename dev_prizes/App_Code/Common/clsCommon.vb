Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Globalization

Public Class clsCommon

    ''' <summary>
    ''' This function is used check the user is valid or not.
    ''' </summary>
    Public Function ValidateLogin() As Boolean
        Try
            If HttpContext.Current.Request.Cookies("UserLoginSettings") IsNot Nothing Then
                If String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Request.Cookies("UserLoginSettings")("CookieLoginUserId"))) OrElse String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Request.Cookies("UserLoginSettings")("CookieUserLogged"))) OrElse ReturnInteger(HttpContext.Current.Request.Cookies("UserLoginSettings")("CookieUserLogged")) <> 1 Then
                    Return False
                Else
                    Return True
                End If
            ElseIf String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session("LoginUserId"))) OrElse String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session("UserLogged"))) OrElse ReturnInteger(HttpContext.Current.Session("UserLogged")) <> 1 Then
                Return False
            Else
                Return True
            End If

            'If String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session("LoginUserId"))) OrElse String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session("UserLogged"))) OrElse ReturnInteger(HttpContext.Current.Session("UserLogged")) <> 1 Then
            '    Return False
            'Else
            '    Return True
            'End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used check the admin user is valid or not.
    ''' </summary>
    Public Function AdminValidateLogin() As Boolean
        Try
            If String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session("AdminLoginUserId"))) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used check DataSet with all possible condition.
    ''' </summary>
    Public Function CheckDataSet(ByVal dstData As DataSet) As Boolean
        Try
            Return (If(dstData IsNot Nothing, (If((dstData.Tables.Count > 0), (If((dstData.Tables(0).Rows.Count > 0), True, False)), False)), False))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' This function is used check DataTable with all possible condition.
    ''' </summary>
    Public Function CheckDataTable(ByVal dtData As DataTable) As Boolean
        Try
            Return (If(dtData IsNot Nothing, (If((dtData.Rows.Count > 0), True, False)), False))
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' This function is used fill dropdown value by DataSet.
    ''' </summary>
    Public Sub FillDropDownByDataSet(ByVal ddlControl As DropDownList, ByVal dstData As DataSet, Optional ByVal strSelectText As String = "")
        Try
            Dim objDBCommonFunction As clsDBCommonFunction = New clsDBCommonFunction
            objDBCommonFunction.FillDropDownByDataSet(ddlControl, dstData, strSelectText)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        
    End Sub

    ''' <summary>
    ''' This function is used to convert value into Integer.
    ''' </summary>
    Public Function ReturnInteger(ByVal IntegerValue As Object) As Integer
        Try
            Dim intValue As Integer = 0
            Integer.TryParse(Convert.ToString(IntegerValue), intValue)
            Return intValue
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to convert value into Double.
    ''' </summary>
    Public Function ReturnDouble(ByVal DoubleValue As Object) As Double
        Try
            Dim dblValue As Double = 0
            Double.TryParse(Convert.ToString(DoubleValue), dblValue)
            Return dblValue
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to convert value into Long.
    ''' </summary>
    Public Function ReturnLong(ByVal LongIntValue As Object) As Long
        Try
            Dim lngValue As Long = 0
            Long.TryParse(Convert.ToString(LongIntValue), lngValue)
            Return lngValue
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to convert value into Float.
    ''' </summary>
    Public Function ReturnFloat(ByVal FloatValue As Object) As Single
        Try
            Dim fltValue As Single = 0
            Single.TryParse(Convert.ToString(FloatValue), fltValue)
            Return fltValue
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to convert value into Floating Value.
    ''' </summary>
    Public Function ReturnFloatingValue(ByVal FloatValue As Object, Optional ByVal intDecimalPlace As Integer = 2) As String
        Try
            Dim strFormat As String = "{0:0._}"
            strFormat = strFormat.Replace("_", "".PadRight(intDecimalPlace, "0"c))
            Dim fltValue As Single = 0
            Single.TryParse(Convert.ToString(FloatValue), fltValue)
            Return String.Format(strFormat, fltValue)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to convert value into String.
    ''' </summary>
    Public Function ReturnString(ByVal StringValue As Object) As String
        Try
            If String.IsNullOrEmpty(Convert.ToString(StringValue)) Then
                Return String.Empty
            Else
                Return Convert.ToString(StringValue).Trim()
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to convert value into DateTime.
    ''' </summary>
    Public Function ReturnDateTime(ByVal strDate As String, Optional ByVal strFormat As String = "dd-MM-yyyy") As DateTime
        Try
            If String.IsNullOrEmpty(Convert.ToString(strDate)) Then
                Return DateTime.MinValue
            Else
                Dim provider As CultureInfo = CultureInfo.InvariantCulture
                If strFormat = String.Empty Then
                    strFormat = "dd-MM-yyyy"
                End If
                Return DateTime.ParseExact(strDate, strFormat, provider)
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to convert value into Compact Price.
    ''' </summary>
    Public Function ReturnCompactPrice(ByVal StringValue As Object) As String
        Try
            If String.IsNullOrWhiteSpace(Convert.ToString(StringValue)) Then
                Return String.Empty
            Else
                Dim intPrice As Integer = 0
                Dim dblPrice As Double = 0
                intPrice = Convert.ToInt32(StringValue)
                dblPrice = Convert.ToDouble(StringValue)
                If dblPrice > intPrice Then
                    Return Convert.ToString(StringValue).Trim()
                Else
                    Return intPrice.ToString()
                End If
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to check valid integer value.
    ''' </summary>
    Public Function ValidateInt(ByVal strNumber As String) As Boolean
        Try
            Dim myInt As Integer
            Return Integer.TryParse(strNumber, myInt)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' This function is used to check valid integer value.
    ''' </summary>
    Public Function ValidateDouble(ByVal strNumber As String) As Boolean
        Try
            Dim myInt As Double
            Return Double.TryParse(strNumber, myInt)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return Nothing
    End Function

End Class
