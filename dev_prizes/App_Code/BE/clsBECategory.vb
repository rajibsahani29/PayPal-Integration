Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBECategory

        Private intCategoryId As Integer
        Public Property CategoryId() As Integer
            Get
                Return intCategoryId
            End Get
            Set(ByVal value As Integer)
                intCategoryId = value
            End Set
        End Property

        Private strNamex As String
        Public Property Namex() As String
            Get
                Return strNamex
            End Get
            Set(ByVal value As String)
                strNamex = value
            End Set
        End Property

        Private intCompanyId As Integer
        Public Property CompanyId() As Integer
            Get
                Return intCompanyId
            End Get
            Set(ByVal value As Integer)
                intCompanyId = value
            End Set
        End Property

    End Class

End Namespace
