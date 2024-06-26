Namespace My

    Partial Friend Class MyApplication
        Dim _conexionMc As ConexionBD
        Public Property conexionMC As ConexionBD
            Get
                Return _conexionMc
            End Get
            Set(ByVal value As ConexionBD)
                _conexionMc = value
            End Set
        End Property
        Public EsInterno As Boolean
    End Class

End Namespace
