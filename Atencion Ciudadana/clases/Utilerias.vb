Imports MySql.Data.MySqlClient

Public Class Utilerias

    'Private sServer As String = "189.254.149.231"
    'Private connection As New MySqlConnection("Server=" & sServer & ";User id=" & sUs & ";Password='" & sCadena & "';Database=amcanew; sslmode=none")
    Private connection As New MySqlConnection("Server=" & sServer & ";port=3306; User id=" & sUs & "; Password='" & sCadena & "';Database=" & sDataBase & "; sslmode=none")


    Public Sub LlenaGrid(ByVal _sSQL As String, ByVal dg As DataGridView)

        Try
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(_sSQL, connection)
            adapter.Fill(table)

            dg.DataSource = table

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub CargaCombo(ByVal _sTabla As String, ByVal _sCampo_ID As String, ByVal _sCampo_Descripcion As String, ByVal _oComboBox As ComboBox, ByVal _nOp As Byte, Optional ByVal _sCriterio As String = "")

        Dim _sSQL As String
        Try
            _sSQL = "SELECT " & _sCampo_ID & ", " & _sCampo_Descripcion & " FROM " & _sTabla & " "
            If _nOp = 2 Then
                _sSQL = _sSQL & "WHERE " & _sCriterio
            End If
            If _nOp = 3 Then
                _sSQL = _sSQL & _sCriterio
            End If
            con.Open()

            Dim table As New DataSet()
            Dim adapter As New MySqlDataAdapter(_sSQL, con)
            adapter.Fill(table)

            _oComboBox.DataSource = Nothing
            _oComboBox.Items.Clear()
            With _oComboBox
                .DataSource = table
                .DisplayMember = _sCampo_Descripcion
                .ValueMember = _sCampo_ID
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Public Function MaxValue(ByVal Query As String) As Integer
        Try
            Dim Ultimo As Integer = 0
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(Query, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows
                    Ultimo = dRow("Tot")
                Next
            End If
            Return Ultimo + 1
        Catch ex As Exception
            Return 0
            MessageBox.Show(ex.Message)
        End Try


    End Function

    Public Sub ExecuteSQL(ByVal strSQL As String, ByVal numOpe As Byte)
        Dim cnSQL As MySqlConnection
        Dim cmSQL As MySqlCommand

        Dim intRowsAffected As Integer

        Try
            cnSQL = New MySqlConnection("Server=" & sServer & ";User id=" & sUs & ";Password='" & sCadena & "';Database=" & sDataBase & "; sslmode=none")
            cnSQL.Open()

            cmSQL = New MySqlCommand(strSQL, cnSQL)

            Select Case numOpe
                Case 1
                    intRowsAffected = cmSQL.ExecuteNonQuery()
                    If intRowsAffected <> 1 Then
                        MsgBox("Update Failed.", MsgBoxStyle.Critical, "Update")
                    End If
                    MsgBox("Informaciòn registrada exitosamente.", MsgBoxStyle.Information, "Guardar")
                Case 2
                    cmSQL.ExecuteNonQuery()
                    'MsgBox("Informaciòn actualizada exitosamente.", MsgBoxStyle.Information, "Guardar")
                Case 3
                    cmSQL.ExecuteNonQuery()
                    'MsgBox("Informaciòn eliminada exitosamente.", MsgBoxStyle.Information, "Eliminar")
                Case 4
                    cmSQL.ExecuteNonQuery()
            End Select


            ' Close and Clean up objects
            cnSQL.Close()


        Catch e As mySqlException
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")
        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        Finally
            cnSQL.Close()
        End Try

    End Sub

End Class