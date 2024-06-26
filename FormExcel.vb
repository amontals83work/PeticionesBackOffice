Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Net

Public Class FormExcel

    Public connectionString As String = "Data Source=192.168.50.48;Initial Catalog=DespachoMc;Persist Security Info=True;User ID=sa;Password=Binabiq2018_;MultipleActiveResultSets=True"
    Public connection As SqlConnection = New SqlConnection(connectionString)
    Public tabla As String = "PeticionesBackOffice"

    Public Sub FormExcel()
        InitializeComponent()
        CenterToScreen()
    End Sub

    Private Sub FormExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rBtnPendiente.AutoCheck = True
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            connection.Open()

            If rBtnPendiente.Checked Then
                Dim cmdPendientes As New SqlCommand("SELECT Cliente,Expediente,DNI,Email,Peticion,Usuario,FechaInicio FROM " + tabla + " WHERE borrado=0 ORDER BY FechaInicio DESC", connection)
                Dim reader As SqlDataReader = cmdPendientes.ExecuteReader()
                Dim writer As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\BackOffice_Pendientes_" + Date.Now.ToString("yyyyMMdd_HHmmss") + ".csv")
                writer.WriteLine("Cliente,Expediente,DNI,Email,Peticion,Usuario,Fecha Petición")
                While reader.Read()
                    writer.WriteLine(reader("Cliente").ToString & "," & reader("Expediente").ToString & "," & reader("DNI").ToString & "," & reader("Email").ToString & "," & reader("Peticion").ToString & "," & reader("Usuario").ToString & "," & reader("FechaInicio").ToString)
                End While
                writer.Close()

            ElseIf rBtnFinalizado.Checked Then
                Dim cmdPendientes As New SqlCommand("SELECT Cliente,Expediente,DNI,Email,Peticion,Usuario,FechaInicio,FechaFin FROM " + tabla + " WHERE borrado=1 ORDER BY FechaInicio DESC", connection)
                Dim reader As SqlDataReader = cmdPendientes.ExecuteReader()
                Dim writer As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\BackOffice_Finalizados_" + Date.Now.ToString("yyyyMMdd_HHmmss") + ".csv")
                writer.WriteLine("Cliente,Expediente,DNI,Email,Peticion,Usuario,Fecha Petición,Fecha Realizado")
                While reader.Read()
                    writer.WriteLine(reader("Cliente").ToString & "," & reader("Expediente").ToString & "," & reader("DNI").ToString & "," & reader("Email").ToString & "," & reader("Peticion").ToString & "," & reader("Usuario").ToString & "," & reader("FechaInicio").ToString & "," & reader("FechaFin").ToString)
                End While
                writer.Close()

            ElseIf rBtnTodo.Checked Then
                Dim cmdPendientes As New SqlCommand("SELECT Cliente,Expediente,DNI,Email,Peticion,Usuario,FechaInicio,FechaFin FROM " + tabla + " ORDER BY FechaInicio DESC", connection)
                Dim reader As SqlDataReader = cmdPendientes.ExecuteReader()
                Dim writer As New StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\BackOffice_" + Date.Now.ToString("yyyyMMdd_HHmmss") + ".csv")
                Dim realizado As Object
                writer.WriteLine("Cliente,Expediente,DNI,Email,Peticion,Usuario,Fecha Petición,Fecha Realizado")
                While reader.Read()
                    realizado = If(reader("FechaFin") Is Nothing Or reader("FechaFin") Is DBNull.Value, "", reader("FechaFin").ToString())
                    writer.WriteLine(reader("Cliente").ToString & "," & reader("Expediente").ToString & "," & reader("DNI").ToString & "," & reader("Email").ToString & "," & reader("Peticion").ToString & "," & reader("Usuario").ToString & "," & reader("FechaInicio").ToString & "," & realizado.ToString)
                End While
                writer.Close()

            Else
                MessageBox.Show("Debe seleccionar una opción")
            End If

            connection.Close()
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub
End Class