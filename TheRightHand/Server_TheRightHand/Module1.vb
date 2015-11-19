Imports System.Net.Sockets
Imports System.IO
Imports System.Net

Module Module1
    Private _Server As TcpListener
    Private _Client As TcpClient
    Private _IpEndoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 8000)
    Private _ConnList As List(Of Connection)

    Private Structure Connection
        Dim Stream As NetworkStream
        Dim StreamReader As StreamReader
        Dim StreamWriter As StreamWriter
        Dim Nickname As String
    End Structure
    Sub Main()
        Try
            _Server = New TcpListener(_IpEndoint)
            _Server.Start()
            Console.WriteLine("Der Server wurde erfolgreich gestartet!")
        Catch ex As Exception
            Console.WriteLine("Der Server konnte nicht erfolgreich gestartet werden!")
            Console.WriteLine(ex)
            Console.ReadKey()
        End Try

        While True
            Dim Con As New Connection
            _Client = _Server.AcceptTcpClient
            Con.Stream = _Client.GetStream
            Con.StreamReader = New StreamReader(Con.Stream)
            Con.StreamWriter = New StreamWriter(Con.Stream)
            Con.Nickname = Con.StreamReader.ReadLine
        End While
    End Sub

End Module
