Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBECreditProblems

        Private intCreditProblemsId As Integer
        Public Property CreditProblemsId() As Integer
            Get
                Return intCreditProblemsId
            End Get
            Set(ByVal value As Integer)
                intCreditProblemsId = value
            End Set
        End Property

        Private intClientId As Integer
        Public Property ClientId() As Integer
            Get
                Return intClientId
            End Get
            Set(ByVal value As Integer)
                intClientId = value
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

        Private strAllInfo As String
        Public Property AllInfo() As String
            Get
                Return strAllInfo
            End Get
            Set(ByVal value As String)
                strAllInfo = value
            End Set
        End Property

        Private dtWhenx As DateTime
        Public Property Whenx() As DateTime
            Get
                Return dtWhenx
            End Get
            Set(ByVal value As DateTime)
                dtWhenx = value
            End Set
        End Property

    End Class

End Namespace