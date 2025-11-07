Imports System.IO
Imports System.Linq
Imports System.Windows.Forms.LinkLabel

Public Class Form1

    Dim numbers As New List(Of Integer)

    Dim filepath As String = "numbers.txt"
    Private Sub btnWrite_Click(sender As Object, e As EventArgs) Handles btnWrite.Click

        Try

            Using writer As New StreamWriter(filepath)
                writer.WriteLine(NumericUpDown1.Value)
                writer.Close()
            End Using
            MessageBox.Show("Number written successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        Try
            ListBox1.Items.Clear()
            Using reader As New StreamReader(filepath)
                Dim line As String = reader.ReadLine()

                While line IsNot Nothing
                    Dim num As Integer
                    If Integer.TryParse(line, num) Then
                        numbers.Add(num)
                    End If
                    line = reader.ReadLine()
                End While
                reader.Close()
            End Using

            For Each num In numbers
                ListBox1.Items.Add(num)
            Next

            MessageBox.Show("Numbers succesfully shown.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click

    End Sub
End Class
