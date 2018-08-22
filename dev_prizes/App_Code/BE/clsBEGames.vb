Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEGames

        Private intGamesId As Integer
        Public Property GamesId() As Integer
            Get
                Return intGamesId
            End Get
            Set(ByVal value As Integer)
                intGamesId = value
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

        Private strServerLoc As String
        Public Property ServerLoc() As String
            Get
                Return strServerLoc
            End Get
            Set(ByVal value As String)
                strServerLoc = value
            End Set
        End Property

        Private bnlStatus As Boolean
        Public Property Status() As Boolean
            Get
                Return bnlStatus
            End Get
            Set(ByVal value As Boolean)
                bnlStatus = value
            End Set
        End Property

        Private dblWonx As Double
        Public Property Wonx() As Double
            Get
                Return dblWonx
            End Get
            Set(ByVal value As Double)
                dblWonx = value
            End Set
        End Property

        Private dblWony As Double
        Public Property Wony() As Double
            Get
                Return dblWony
            End Get
            Set(ByVal value As Double)
                dblWony = value
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

        Private strEmailSignature As String
        Public Property EmailSignature() As String
            Get
                Return strEmailSignature
            End Get
            Set(ByVal value As String)
                strEmailSignature = value
            End Set
        End Property

        Private intMaxBalls As Integer
        Public Property MaxBalls() As Integer
            Get
                Return intMaxBalls
            End Get
            Set(ByVal value As Integer)
                intMaxBalls = value
            End Set
        End Property

        Private strServerId As String
        Public Property ServerId() As String
            Get
                Return strServerId
            End Get
            Set(ByVal value As String)
                strServerId = value
            End Set
        End Property

        Private dtLaunchDate As DateTime
        Public Property LaunchDate() As DateTime
            Get
                Return dtLaunchDate
            End Get
            Set(ByVal value As DateTime)
                dtLaunchDate = value
            End Set
        End Property

        Private dtEndDate As DateTime
        Public Property EndDate() As DateTime
            Get
                Return dtEndDate
            End Get
            Set(ByVal value As DateTime)
                dtEndDate = value
            End Set
        End Property

    End Class

End Namespace