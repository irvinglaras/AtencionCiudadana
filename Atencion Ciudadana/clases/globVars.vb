Imports MySql.Data.MySqlClient

Module globVars

    Public sServer As String = "localhost" '"68.178.230.66" '"68.178.230.66"
    Public sDataBase As String = "atencionciu"
    Public con As MySqlConnection = myconn()
    Public result As Integer
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dReader As MySqlDataReader
    Public ds As New DataSet
    Public sql As String = ""
    Public reportselect, reportname As String
    Public switch, switchcurr As String
    Public issucess As Boolean
    Public fullname As String = ""
    Public usertype As String = ""
    Public userID As Integer = 0

    Public GLOBALid As Integer = Nothing
    Public GLOBALMessage As String = ""
    Public SaveMessage As String = ""
    Public Statactive As String

    Public noResult As Integer
    Public RESIDENCEID As Integer
    Public LNAME As String = ""
    Public FNAME As String = ""
    Public MNAME As String = ""
    Public ext As String = ""
    Public NO As String = ""
    Public STREET As String = ""
    Public PRK As String = ""
    Public POB As String = ""
    Public DOB As String = ""
    Public SEX As String = ""
    Public CIVIL As String = ""
    Public CITIZENSHIP As String = ""
    Public OCCUPATION As String = ""
    Public CLEARANCE As String = ""
    Public userMsg As String
    Public imgpath As String
    Public arrImage() As Byte
    Public position As String
    Public sCadena As String = "a2Uw6QhEzzZQ))Y4" '"$1@2DMUl-Ki5" '"lart770422j7a+-+"
    Public sUs As String = "acuna" '"alerta"


    Public Sub jokenfindthis(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            con.Close()
            da.Dispose()
        End Try


    End Sub
    Public Function jokeninsert(ByVal sql As String) As Boolean

        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql

                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    Return False
                Else
                    Return True
                End If
            End With
        Catch ex As Exception
            Return False
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            con.Close()

        End Try

    End Function


    Public Function jokenupdate(ByVal sql As String) As Boolean
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then

                    Return False
                Else
                    Return True

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            con.Close()

        End Try

    End Function

    Public Function jokendelete(ByVal sql As String) As Boolean
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    Return False
                Else
                    Return True
                End If
            End With
        Catch ex As Exception
            Return False
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            con.Close()

        End Try

    End Function

    'Public Sub reports(ByVal sql As String, ByVal rptname As String, ByVal crystalRpt As Object)
    '    Try
    '        myconn.Open()

    '        Dim reportname As String
    '        With cmd
    '            .Connection = myconn()
    '            .CommandText = sql
    '        End With
    '        ds = New DataSet
    '        da = New MySqlDataAdapter(sql, myconn)
    '        da.Fill(ds)
    '        reportname = rptname
    '        Dim reportdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '        Dim strReportPath As String
    '        strReportPath = Application.StartupPath & "\reports\" & reportname & ".rpt"
    '        With reportdoc
    '            .Load(strReportPath)
    '            .SetDataSource(ds.Tables(0))
    '        End With
    '        With crystalRpt
    '            .Displaytoolbar = True
    '            .DisplayStatusbar = True
    '            .ShowRefreshButton = False
    '            .ShowCloseButton = False
    '            .ShowGroupTreeButton = False
    '            .ReportSource = reportdoc
    '        End With
    '        reportdoc.PrintToPrinter(1, False, 0, 0)
    '    Catch ex As Exception
    '        MsgBox(ex.Message & "No Crystal Reports have been Installed")
    '    Finally
    '        myconn.Close()
    '        da.Dispose()
    '    End Try
    'End Sub

    'Public Sub reportsAll(ByVal sql As String, ByVal rptname As String, ByVal crystalRpt As Object)
    '    Try
    '        myconn.Open()

    '        Dim reportname As String
    '        With cmd
    '            .Connection = myconn()
    '            .CommandText = sql
    '        End With
    '        ds = New DataSet
    '        da = New MySqlDataAdapter(sql, myconn)
    '        da.Fill(ds)
    '        reportname = rptname
    '        Dim reportdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '        Dim strReportPath As String
    '        strReportPath = Application.StartupPath & "\reports\" & reportname & ".rpt"
    '        With reportdoc
    '            .Load(strReportPath)
    '            .SetDataSource(ds.Tables(0))
    '        End With
    '        With crystalRpt
    '            .Displaytoolbar = True
    '            .DisplayStatusbar = True
    '            .ShowRefreshButton = False
    '            .ShowCloseButton = False
    '            .ShowGroupTreeButton = False
    '            .ReportSource = reportdoc
    '        End With

    '    Catch ex As Exception
    '        MsgBox(ex.Message & "No Crystal Reports have been Installed")
    '    Finally
    '        myconn.Close()
    '        da.Dispose()
    '    End Try
    'End Sub


End Module