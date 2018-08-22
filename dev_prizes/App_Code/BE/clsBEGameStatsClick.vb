Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEGameStatsClick

        Private intGameStatsClickId As Integer
        Public Property GameStatsClickId() As Integer
            Get
                Return intGameStatsClickId
            End Get
            Set(ByVal value As Integer)
                intGameStatsClickId = value
            End Set
        End Property

        Private intGameId As Integer
        Public Property GameId() As Integer
            Get
                Return intGameId
            End Get
            Set(ByVal value As Integer)
                intGameId = value
            End Set
        End Property

        Private dtDateAdded As DateTime
        Public Property DateAdded() As DateTime
            Get
                Return dtDateAdded
            End Get
            Set(ByVal value As DateTime)
                dtDateAdded = value
            End Set
        End Property

        Private intTypex As Integer
        Public Property Typex() As Integer
            Get
                Return intTypex
            End Get
            Set(ByVal value As Integer)
                intTypex = value
            End Set
        End Property

    End Class

End Namespace