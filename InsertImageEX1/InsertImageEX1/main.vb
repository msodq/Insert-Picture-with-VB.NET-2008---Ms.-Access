Imports System.Data.OleDb
Public Class main
    Private CON As New koneksi_ke_database
    Private cmd As New OleDbCommand
    Dim img As String

    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        img = ""
    End Sub

    'apabila link label add picture di Click
    Private Sub LinkAdd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkAdd.LinkClicked
        Me.OpenFileDialog1.FileName = ""
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            img = Nothing
        ElseIf Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.OpenFileDialog1.Filter = "Image Files (*.jpg)|*.jpg" 'klo perlu tambahin aja ekstensi file image nya ex: png, bmp
            img = OpenFileDialog1.FileName
            PictureBox1.ImageLocation = img
        End If
    End Sub

    'apabila button Insert di Click
    Private Sub btInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInsert.Click
        If img <> "" Then 'cek gambarnya ada or ga
            'Simpan ke database
            Try
                CON.open()
                cmd = New OleDbCommand("INSERT INTO tPicture (gambar) VALUES('" & img & "')", CON.con)
                cmd.ExecuteNonQuery()
                CON.close()
                MsgBox("Insert Gambarnya SUKSES BOZ!", MsgBoxStyle.Information, "Suksek BOZ")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Gambarnya kagak ada BOZ!", MsgBoxStyle.Critical, "Error BOZ")
        End If
    End Sub
End Class
