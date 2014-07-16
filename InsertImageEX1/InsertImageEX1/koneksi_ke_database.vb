Imports System.Data
Imports System.Data.OleDb
Public Class koneksi_ke_database
    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=Database\dbGambar.mdb;")
    Public Function open() As OleDbConnection
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
        Return con
    End Function

    Public Function close() As OleDbConnection
        con.Close()
        Return con
    End Function
End Class
