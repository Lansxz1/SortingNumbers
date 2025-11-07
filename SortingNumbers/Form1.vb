Imports System.IO
Imports System.Linq
Public Class Form1

    Dim numbers As New List(Of Integer)

    Dim filepath As String = "numbers.txt"
    Private Sub btnWrite_Click(sender As Object, e As EventArgs) Handles btnWrite.Click

        Try

            Using writer As New StreamWriter(filepath, True)
                writer.WriteLine(NumericUpDown1.Value)
                writer.Close()
            End Using
            MessageBox.Show("Number written successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click

    End Sub

    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click

    End Sub
End Class
