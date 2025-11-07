Imports System.IO
Imports System.Linq
Imports System.Windows.Forms.LinkLabel

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

        numbers.Clear()
        ListBox1.Items.Clear()
        Try

            Using reader As New StreamReader(filepath)
                Dim line As String = reader.ReadLine()
                While line IsNot Nothing
                    Dim num As Integer
                    If Integer.TryParse(line, num) Then
                        numbers.Add(num)
                        ListBox1.Items.Add(num)
                    End If
                    line = reader.ReadLine()
                End While
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
        If numbers.Count = 0 Then
            MessageBox.Show("No numbers to sort. Please read numbers first.", "Retry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim sortnumbers = numbers.OrderBy(Function(n) n).ToList()
        ListBox1.Items.Clear()
        Using writer As New StreamWriter(filepath, False)
            For Each n In sortnumbers
                ListBox1.Items.Add(n)
                writer.WriteLine(n)
            Next
        End Using

        MessageBox.Show("Numbers sorted!", "Sort", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class
