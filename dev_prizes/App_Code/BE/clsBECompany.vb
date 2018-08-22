Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBECompany

        Private intCompanyId As Integer
        Public Property CompanyId() As Integer
            Get
                Return intCompanyId
            End Get
            Set(ByVal value As Integer)
                intCompanyId = value
            End Set
        End Property

        Private strName As String
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal value As String)
                strName = value
            End Set
        End Property

        Private strAddress1 As String
        Public Property Address1() As String
            Get
                Return strAddress1
            End Get
            Set(ByVal value As String)
                strAddress1 = value
            End Set
        End Property

        Private strAddress2 As String
        Public Property Address2() As String
            Get
                Return strAddress2
            End Get
            Set(ByVal value As String)
                strAddress2 = value
            End Set
        End Property

        Private strCity As String
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal value As String)
                strCity = value
            End Set
        End Property

        Private intCountryId As Integer
        Public Property CountryId() As Integer
            Get
                Return intCountryId
            End Get
            Set(ByVal value As Integer)
                intCountryId = value
            End Set
        End Property

        Private strEmail As String
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal value As String)
                strEmail = value
            End Set
        End Property

        Private strPhone As String
        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal value As String)
                strPhone = value
            End Set
        End Property

        Private strContactName As String
        Public Property ContactName() As String
            Get
                Return strContactName
            End Get
            Set(ByVal value As String)
                strContactName = value
            End Set
        End Property

        Private strUsername As String
        Public Property Username() As String
            Get
                Return strUsername
            End Get
            Set(ByVal value As String)
                strUsername = value
            End Set
        End Property

        Private strPasswordx As String
        Public Property Passwordx() As String
            Get
                Return strPasswordx
            End Get
            Set(ByVal value As String)
                strPasswordx = value
            End Set
        End Property

        Private strLastLogged As DateTime
        Public Property LastLogged() As DateTime
            Get
                Return strLastLogged
            End Get
            Set(ByVal value As DateTime)
                strLastLogged = value
            End Set
        End Property

    End Class

End Namespace
