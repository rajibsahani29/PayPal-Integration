Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEVouchers

        Private intVouchersId As Integer
        Public Property VouchersId() As Integer
            Get
                Return intVouchersId
            End Get
            Set(ByVal value As Integer)
                intVouchersId = value
            End Set
        End Property

        Private strCodex As String
        Public Property Codex() As String
            Get
                Return strCodex
            End Get
            Set(ByVal value As String)
                strCodex = value
            End Set
        End Property

        Private dtStartx As DateTime
        Public Property Startx() As DateTime
            Get
                Return dtStartx
            End Get
            Set(ByVal value As DateTime)
                dtStartx = value
            End Set
        End Property

        Private dtEndx As DateTime
        Public Property Endx() As DateTime
            Get
                Return dtEndx
            End Get
            Set(ByVal value As DateTime)
                dtEndx = value
            End Set
        End Property

        Private intNoToBuy As Integer
        Public Property NoToBuy() As Integer
            Get
                Return intNoToBuy
            End Get
            Set(ByVal value As Integer)
                intNoToBuy = value
            End Set
        End Property

        Private intNoToGive As Integer
        Public Property NoToGive() As Integer
            Get
                Return intNoToGive
            End Get
            Set(ByVal value As Integer)
                intNoToGive = value
            End Set
        End Property

        Private bnlStopx As Boolean
        Public Property Stopx() As Boolean
            Get
                Return bnlStopx
            End Get
            Set(ByVal value As Boolean)
                bnlStopx = value
            End Set
        End Property

        Private strMessagex As String
        Public Property Messagex() As String
            Get
                Return strMessagex
            End Get
            Set(ByVal value As String)
                strMessagex = value
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
