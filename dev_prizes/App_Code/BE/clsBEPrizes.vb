Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEPrizes

        Private intPrizesId As Integer
        Public Property PrizesId() As Integer
            Get
                Return intPrizesId
            End Get
            Set(ByVal value As Integer)
                intPrizesId = value
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

        Private strNamex As String
        Public Property Namex() As String
            Get
                Return strNamex
            End Get
            Set(ByVal value As String)
                strNamex = value
            End Set
        End Property

        Private strShortDesc As String
        Public Property ShortDesc() As String
            Get
                Return strShortDesc
            End Get
            Set(ByVal value As String)
                strShortDesc = value
            End Set
        End Property

        Private strLongDesc As String
        Public Property LongDesc() As String
            Get
                Return strLongDesc
            End Get
            Set(ByVal value As String)
                strLongDesc = value
            End Set
        End Property

        Private strMisc As String
        Public Property Misc() As String
            Get
                Return strMisc
            End Get
            Set(ByVal value As String)
                strMisc = value
            End Set
        End Property

        Private strMainImage As String
        Public Property MainImage() As String
            Get
                Return strMainImage
            End Get
            Set(ByVal value As String)
                strMainImage = value
            End Set
        End Property

        Private dblValuex As Double
        Public Property Valuex() As Double
            Get
                Return dblValuex
            End Get
            Set(ByVal value As Double)
                dblValuex = value
            End Set
        End Property

        Private intNoCredits As Integer
        Public Property NoCredits() As Integer
            Get
                Return intNoCredits
            End Get
            Set(ByVal value As Integer)
                intNoCredits = value
            End Set
        End Property

        Private intCategoryId As Integer
        Public Property CategoryId() As Integer
            Get
                Return intCategoryId
            End Get
            Set(ByVal value As Integer)
                intCategoryId = value
            End Set
        End Property

    End Class

End Namespace
