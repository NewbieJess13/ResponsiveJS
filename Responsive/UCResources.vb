Imports ClassSql

Public Class UCResources
    Private Sub UCResources_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsSql.connectionString = My.Settings.ResponsiveDBCS
        LoadData()
    End Sub
    Dim dt As New DataTable
    Dim id As String

    Private Sub LoadData()
        Dim dt As DataTable = MsSql.Table("SELECT * FROM tbl_Info", Nothing)
        dgList.Rows.Clear()
        For Each dr As DataRow In dt.Rows
            dgList.Rows.Add(dr(0), dr(1) & " " & dr(2) & " " & dr(3), dr(4), dr(5), dr(6), dr(1), dr(2), dr(3))
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtFirst.Text <> "" Or txtMiddle.Text <> "" Or txtLast.Text <> "" Or txtAge.Text <> "" Or txtEmail.Text <> "" Or txtPhone.Text <> "" Then
            Try
                startTimer()
                MsSql.ExecuteQuery("INSERT INTO tbl_Info (FirstName,MiddelName,LastName,Age,EmailAd,PhoneNo) VALUES ('" & txtFirst.Text & "','" & txtMiddle.Text & "','" & txtLast.Text & "','" & txtAge.Text & "','" & txtEmail.Text & "','" & txtPhone.Text & "')", Nothing)
                txtFirst.Clear()
                txtMiddle.Clear()
                txtLast.Clear()
                txtAge.Clear()
                txtEmail.Clear()
                txtPhone.Clear()
                MessageBox.Show("New Record has been inserted", "Responsive", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Please fill out all the fields to proceed!", "Responsive", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtFirst.Text <> "" Or txtMiddle.Text <> "" Or txtLast.Text <> "" Or txtAge.Text <> "" Or txtEmail.Text <> "" Or txtPhone.Text <> "" Then
            startTimer()
            MsSql.ExecuteQuery("UPDATE tbl_Info SET FirstName='" & txtFirst.Text & "', MiddelName='" & txtMiddle.Text & "', LastName= '" & txtLast.Text & "', Age ='" & txtAge.Text & "', EmailAd='" & txtEmail.Text & "', PhoneNo='" & txtPhone.Text & "' WHERE id = '" & id & "'", Nothing)
            MessageBox.Show("Data has been updated!", "Responsive", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Else
            MessageBox.Show("Please select the data you want to update!", "Responsive", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If txtFirst.Text <> "" Or txtMiddle.Text <> "" Or txtLast.Text <> "" Or txtAge.Text <> "" Or txtEmail.Text <> "" Or txtPhone.Text <> "" Then
            If MessageBox.Show("Are you sure you want to delete this record?", "Responsive", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                startTimer()
                MsSql.ExecuteQuery("DELETE FROM tbl_Info WHERE id = '" & id & "'", Nothing)
                MessageBox.Show("Data has been deleted", "Responsive", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            End If

        Else
            MessageBox.Show("Please select the data that you want to delete!", "Responsive", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
    Public Sub startTimer()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub dgList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgList.CellDoubleClick
        Try
            If e.RowIndex >= 0 Or e.ColumnIndex >= 0 Then
                id = dgList.Rows(e.RowIndex).Cells(0).Value
                txtFirst.Text = dgList.Rows(e.RowIndex).Cells(5).Value
                txtMiddle.Text = dgList.Rows(e.RowIndex).Cells(6).Value
                txtLast.Text = dgList.Rows(e.RowIndex).Cells(7).Value
                txtAge.Text = dgList.Rows(e.RowIndex).Cells(2).Value
                txtEmail.Text = dgList.Rows(e.RowIndex).Cells(3).Value
                txtPhone.Text = dgList.Rows(e.RowIndex).Cells(4).Value
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
