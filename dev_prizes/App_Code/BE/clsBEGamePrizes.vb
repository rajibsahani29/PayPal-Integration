Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEGamePrizes

        Private intGamePrizesId As Integer
        Public Property GamePrizesId() As Integer
            Get
                Return intGamePrizesId
            End Get
            Set(ByVal value As Integer)
                intGamePrizesId = value
            End Set
        End Property

        Private intGamesId As Integer
        Public Property GamesId() As Integer
            Get
                Return intGamesId
            End Get
            Set(ByVal value As Integer)
                intGamesId = value
            End Set
        End Property

        Private intPrizesId As Integer
        Public Property PrizesId() As Integer
            Get
                Return intPrizesId
            End Get
            Set(ByVal value As Integer)
                intPrizesId = value
            End Set
        End Property

        Private intOrderx As Integer
        Public Property Orderx() As Integer
            Get
                Return intOrderx
            End Get
            Set(ByVal value As Integer)
                intOrderx = value
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
