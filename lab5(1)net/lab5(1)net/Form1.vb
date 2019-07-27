Option Strict On
Imports System.IO
Public Class frmTextEditor

    Dim store As String = String.Empty
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim check As New StreamReader(OpenFileDialog1.FileName)
                txtTextBox.Text = check.ReadToEnd
                check.Close()
            Catch ex As Exception
                Throw New ApplicationException(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        Me.txtTextBox.Paste()
    End Sub



    Private Sub saveFile(store As String)
        Dim saveFile As New FileStream(store, FileMode.Create, FileAccess.Write)
        Dim writeFile As New StreamWriter(saveFile)
        writeFile.Write(txtTextBox.Text)

        writeFile.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.Filter = "txt files (.txt)|.txt"
        If File.Exists(store) = False Then

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                store = SaveFileDialog1.FileName
                saveFile(store)
            End If
        Else
            saveFile(store)
        End If




    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        txtTextBox.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCut.Click
        txtTextBox.Cut()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click
        SaveFileDialog1.Filter = "txt files (.txt)|.txt"
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            store = SaveFileDialog1.FileName
            saveFile(store)
        End If
    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        txtTextBox.Text = ""
        store = String.Empty
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        MessageBox.Show("NETD-2202" & vbCrLf & vbCrLf & "LAB # 5" & vbCrLf & "Dhruv Vyas", "About")
    End Sub
End Class
