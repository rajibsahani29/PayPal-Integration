Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEPrizesImages

        Private intPrizesImagesId As Integer
        Public Property PrizesImagesId() As Integer
            Get
                Return intPrizesImagesId
            End Get
            Set(ByVal value As Integer)
                intPrizesImagesId = value
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

        Private strImageLoc As String
        Public Property ImageLoc() As String
            Get
                Return strImageLoc
            End Get
            Set(ByVal value As String)
                strImageLoc = value
            End Set
        End Property

    End Class

End Namespace