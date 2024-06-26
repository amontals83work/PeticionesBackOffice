
Imports System.Data.SqlClient

Public Class Form1

    Public connectionString As String = "Data Source=192.168.50.48;Initial Catalog=DespachoMc;Persist Security Info=True;User ID=sa;Password=Binabiq2018_;MultipleActiveResultSets=True"
    Public connection As SqlConnection = New SqlConnection(connectionString)
    Private filaSeleccionada As DataGridViewRow = Nothing
    Public tabla As String = "PeticionesBackOffice" 'zz_PeticionesBackOffice

    Public Sub Form1()
        InitializeComponent()
        CenterToScreen()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connection.Open()
        Dim sql As String = "SELECT Cliente,Expediente,Peticion,Usuario,FechaInicio,FechaFin,Borrado,IdCliente,DNI,Email FROM " + tabla + " WHERE Borrado=0 ORDER BY FechaInicio DESC"
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql, connection)
        Dim dt As New DataTable
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        connection.Close()

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        Dim registrosSeleccionados As New List(Of DataGridViewRow)
        Dim auxSQL As String

        For Each fila As DataGridViewRow In DataGridView1.Rows
            Dim seleccionado = Convert.ToBoolean(fila.Cells("Borrado").Value)
            If seleccionado Then
                registrosSeleccionados.Add(fila)
            End If
        Next

        If registrosSeleccionados.Count > 0 Then
            Try
                connection.Open()

                For Each filaSeleccionada In registrosSeleccionados
                    Dim cliente = filaSeleccionada.Cells("Cliente").Value
                    Dim expediente = filaSeleccionada.Cells("Expediente").Value
                    Dim peticion = filaSeleccionada.Cells("Peticion").Value
                    Dim usuario = filaSeleccionada.Cells("Usuario").Value
                    Dim idCliente = filaSeleccionada.Cells("IdCliente").Value
                    Dim dni = filaSeleccionada.Cells("DNI").Value
                    Dim update = 0

                    Dim cmd As New SqlCommand("UPDATE " + tabla + " SET Borrado=1, FechaFin=GETDATE() WHERE Expediente=@Expediente AND Peticion=@Peticion", connection)
                    cmd.Parameters.AddWithValue("@Expediente", expediente)
                    cmd.Parameters.AddWithValue("@Peticion", peticion)
                    update = cmd.ExecuteNonQuery

                    If update > 0 Then
                        If cliente = "AXACTOR" Then
                            Dim auxCmd As New SqlCommand("INSERT INTO AXALLAMADAS(idclienteald,fecha,gestion,observaciones,usuario) VALUES (@expediente,GETDATE(),@gestion,@observaciones,@usuario)", connection)
                            auxCmd.Parameters.Clear()
                            auxCmd.Parameters.AddWithValue("@expediente", expediente)
                            auxCmd.Parameters.AddWithValue("@gestion", 99)
                            auxCmd.Parameters.AddWithValue("@observaciones", peticion + " NO LOCALIZADA desde Back Office")
                            auxCmd.Parameters.AddWithValue("@usuario", usuario)
                            auxCmd.ExecuteNonQuery()

                        ElseIf cliente = "NASSAU" Then
                            Dim auxCmd As New SqlCommand("INSERT INTO NASSLLAMADAS(codigoparticipante,fecha,gestion,observaciones,usuario) VALUES (@expediente,GETDATE(),@gestion,@observaciones,@usuario)", connection)
                            auxCmd.Parameters.Clear()
                            auxCmd.Parameters.AddWithValue("@expediente", expediente)
                            auxCmd.Parameters.AddWithValue("@gestion", 99)
                            auxCmd.Parameters.AddWithValue("@observaciones", peticion + " NO LOCALIZADA desde Back Office")
                            auxCmd.Parameters.AddWithValue("@usuario", usuario)
                            auxCmd.ExecuteNonQuery()

                        Else
                            Dim idExpediente = 0
                            Dim auxMc As New MCCommand
                            If IsNumeric(expediente) Then
                                auxSQL = "SELECT idExpediente FROM Expedientes WHERE (Expediente = @expediente OR RefCliente = @refCliente) AND IdCliente = @idCliente"
                                auxMc = New MCCommand(auxSQL)
                                auxMc.Parameters.Clear()
                                auxMc.Parametros.AddWithValue("@expediente", CInt(expediente))
                                auxMc.Parametros.AddWithValue("@refCliente", expediente.ToString)
                                auxMc.Parametros.AddWithValue("@idCliente", CInt(idCliente))
                            Else
                                auxSQL = "SELECT idExpediente FROM Expedientes WHERE RefCliente = @refCliente"
                                auxMc = New MCCommand(auxSQL)
                                auxMc.Parameters.Clear()
                                auxMc.Parametros.AddWithValue("@refCliente", expediente.ToString)
                            End If
                            Dim result = auxMc.ExecuteScalar
                            idExpediente = If(IsDBNull(result), 0, Convert.ToInt32(result))

                            Dim auxCmd As New SqlCommand("INSERT INTO Acciones(IdExpediente,idTipoNota,Fecha,Observaciones,Usuario,Borrado) VALUES (@idExpediente,@idTipoNota,GETDATE(),@observaciones,@usuario,0)", connection)
                            auxCmd.Parameters.Clear()
                            auxCmd.Parameters.AddWithValue("@idExpediente", idExpediente)
                            auxCmd.Parameters.AddWithValue("@idTipoNota", 23)
                            auxCmd.Parameters.AddWithValue("@observaciones", peticion + " NO LOCALIZADA desde Back Office")
                            auxCmd.Parameters.AddWithValue("@usuario", usuario)
                            auxCmd.ExecuteNonQuery()
                        End If
                    End If
                Next

                Dim sql = "SELECT Cliente,Expediente,Peticion,Usuario,FechaInicio,FechaFin,Borrado,IdCliente,DNI,Email FROM " + tabla + " WHERE Borrado=0 ORDER BY FechaInicio DESC"
                Dim adapter = New SqlDataAdapter(sql, connection)
                Dim dt As New DataTable
                adapter.Fill(dt)
                DataGridView1.DataSource = dt

                If registrosSeleccionados.Count > 1 Then
                    MessageBox.Show("Registros borrados con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf registrosSeleccionados.Count = 1 Then
                    MessageBox.Show("Registro borrado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show("Error al marcar los registros como borrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                connection.Close()
            End Try
        Else
            MessageBox.Show("No hay registros seleccionados para borrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim registrosSeleccionados As New List(Of DataGridViewRow)
        Dim auxSQL As String

        For Each fila As DataGridViewRow In DataGridView1.Rows
            Dim seleccionado = Convert.ToBoolean(fila.Cells("Borrado").Value)
            If seleccionado Then
                registrosSeleccionados.Add(fila)
            End If
        Next

        If registrosSeleccionados.Count > 0 Then
            Try
                connection.Open()

                For Each filaSeleccionada In registrosSeleccionados
                    Dim cliente = filaSeleccionada.Cells("Cliente").Value
                    Dim expediente = filaSeleccionada.Cells("Expediente").Value
                    Dim peticion = filaSeleccionada.Cells("Peticion").Value
                    Dim usuario = filaSeleccionada.Cells("Usuario").Value
                    Dim idCliente = filaSeleccionada.Cells("IdCliente").Value
                    Dim dni = filaSeleccionada.Cells("DNI").Value
                    Dim update = 0

                    Dim cmd As New SqlCommand("UPDATE " + tabla + " SET Borrado=1, FechaFin=GETDATE() WHERE Expediente=@Expediente AND Peticion=@Peticion", connection)
                    cmd.Parameters.AddWithValue("@Expediente", expediente)
                    cmd.Parameters.AddWithValue("@Peticion", peticion)
                    update = cmd.ExecuteNonQuery

                    If update > 0 Then
                        If cliente = "AXACTOR" Then
                            Dim auxCmd As New SqlCommand("INSERT INTO AXALLAMADAS(idclienteald,fecha,gestion,observaciones,usuario) VALUES (@expediente,GETDATE(),@gestion,@observaciones,@usuario)", connection)
                            auxCmd.Parameters.Clear()
                            auxCmd.Parameters.AddWithValue("@expediente", expediente)
                            auxCmd.Parameters.AddWithValue("@gestion", 99)
                            auxCmd.Parameters.AddWithValue("@observaciones", peticion + " ENVIADA desde Back Office")
                            auxCmd.Parameters.AddWithValue("@usuario", usuario)
                            auxCmd.ExecuteNonQuery()

                        ElseIf cliente = "NASSAU" Then
                            Dim auxCmd As New SqlCommand("INSERT INTO NASSLLAMADAS(codigoparticipante,fecha,gestion,observaciones,usuario) VALUES (@expediente,GETDATE(),@gestion,@observaciones,@usuario)", connection)
                            auxCmd.Parameters.Clear()
                            auxCmd.Parameters.AddWithValue("@expediente", expediente)
                            auxCmd.Parameters.AddWithValue("@gestion", 99)
                            auxCmd.Parameters.AddWithValue("@observaciones", peticion + " ENVIADA desde Back Office")
                            auxCmd.Parameters.AddWithValue("@usuario", usuario)
                            auxCmd.ExecuteNonQuery()

                        Else
                            Dim idExpediente = 0
                            Dim auxMc As New MCCommand
                            If IsNumeric(expediente) Then
                                auxSQL = "SELECT idExpediente FROM Expedientes WHERE (Expediente = @expediente OR RefCliente = @refCliente) AND IdCliente = @idCliente"
                                auxMc = New MCCommand(auxSQL)
                                auxMc.Parameters.Clear()
                                auxMc.Parametros.AddWithValue("@expediente", CInt(expediente))
                                auxMc.Parametros.AddWithValue("@refCliente", expediente.ToString)
                                auxMc.Parametros.AddWithValue("@idCliente", CInt(idCliente))
                            Else
                                auxSQL = "SELECT idExpediente FROM Expedientes WHERE RefCliente = @refCliente"
                                auxMc = New MCCommand(auxSQL)
                                auxMc.Parameters.Clear()
                                auxMc.Parametros.AddWithValue("@refCliente", expediente.ToString)
                            End If
                            Dim result = auxMc.ExecuteScalar
                            idExpediente = If(IsDBNull(result), 0, Convert.ToInt32(result))

                            Dim auxCmd As New SqlCommand("INSERT INTO Acciones(IdExpediente,idTipoNota,Fecha,Observaciones,Usuario,Borrado) VALUES (@idExpediente,@idTipoNota,GETDATE(),@observaciones,@usuario,0)", connection)
                            auxCmd.Parameters.Clear()
                            auxCmd.Parameters.AddWithValue("@idExpediente", idExpediente)
                            auxCmd.Parameters.AddWithValue("@idTipoNota", 23)
                            auxCmd.Parameters.AddWithValue("@observaciones", peticion + " ENVIADA desde Back Office")
                            auxCmd.Parameters.AddWithValue("@usuario", usuario)
                            auxCmd.ExecuteNonQuery()
                        End If
                    End If
                Next

                Dim sql = "SELECT Cliente,Expediente,Peticion,Usuario,FechaInicio,FechaFin,Borrado,IdCliente,DNI,Email FROM " + tabla + " WHERE Borrado=0 ORDER BY FechaInicio DESC"
                Dim adapter = New SqlDataAdapter(sql, connection)
                Dim dt As New DataTable
                adapter.Fill(dt)
                DataGridView1.DataSource = dt

                If registrosSeleccionados.Count > 1 Then
                    MessageBox.Show("Registros enviados con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf registrosSeleccionados.Count = 1 Then
                    MessageBox.Show("Registro enviado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show("Error al marcar los registros como enviados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                connection.Close()
            End Try
        Else
            MessageBox.Show("No hay registros seleccionados para enviar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        FormExcel.ShowDialog()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        connection.Open()
        Dim sql As String = "SELECT Cliente,Expediente,Peticion,Usuario,FechaInicio,FechaFin,Borrado,IdCliente,DNI,Email FROM " + tabla + " WHERE Borrado=0 ORDER BY FechaInicio DESC"
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql, connection)
        Dim dt As New System.Data.DataTable
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        connection.Close()

    End Sub

End Class
