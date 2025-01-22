Imports MySql.Data.MySqlClient
Module moddb
    Public server As String
    Public Serveruser As String
    Public password As String
    Public dbname As String

    Public Sub setCOnfig()
        Dim FILE_NAME As String = Application.StartupPath & "\config.txt"

        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            server = objReader.ReadLine()
            Serveruser = objReader.ReadLine() & vbNewLine
            password = objReader.ReadLine() & vbNewLine & vbNewLine
            dbname = objReader.ReadLine() & vbNewLine & vbNewLine & vbNewLine


        Else

            MsgBox("Config File Does Not Exist!")

        End If
    End Sub
    Public Function myconn() As MySqlConnection
        setCOnfig()
        'Return New MySqlConnection("server=" & server & ";user id=" & Serveruser & ";password=" & password & ";database=" & sDataBase & "; sslmode=none")
        Return New MySqlConnection("Server=" & sServer & ";User id=acuna;Password='a2Uw6QhEzzZQ))Y4';Database=" & sDataBase & "; sslmode=none")
    End Function

End Module
