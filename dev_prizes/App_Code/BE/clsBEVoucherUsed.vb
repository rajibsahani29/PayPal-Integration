Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEVoucherUsed

        Private intVoucherUsedId As Integer
        Public Property VoucherUsedId() As Integer
            Get
                Return intVoucherUsedId
            End Get
            Set(ByVal value As Integer)
                intVoucherUsedId = value
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

        Private intVouchersId As Integer
        Public Property VouchersId() As Integer
            Get
                Return intVouchersId
            End Get
            Set(ByVal value As Integer)
                intVouchersId = value
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

        Private intCreditsGiven As Integer
        Public Property CreditsGiven() As Integer
            Get
                Return intCreditsGiven
            End Get
            Set(ByVal value As Integer)
                intCreditsGiven = value
            End Set
        End Property

        Private intCreditsBought As Integer
        Public Property CreditsBought() As Integer
            Get
                Return intCreditsBought
            End Get
            Set(ByVal value As Integer)
                intCreditsBought = value
            End Set
        End Property

    End Class

End Namespace
