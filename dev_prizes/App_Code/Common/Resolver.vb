Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Diagnostics
Imports System.Runtime.Remoting.Messaging

Public Class Resolver
    Public Const DefaultPort As Integer = 53

    Public Shared Function GetDnsServers() As IPEndPoint()
        Dim list As List(Of IPEndPoint) = New List(Of IPEndPoint)()
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        For Each n As NetworkInterface In adapters
            If n.OperationalStatus = OperationalStatus.Up Then
                Dim ipProps As IPInterfaceProperties = n.GetIPProperties()
                For Each ipAddr As IPAddress In ipProps.DnsAddresses
                    Dim entry As IPEndPoint = New IPEndPoint(ipAddr, DefaultPort)
                    If Not list.Contains(entry) Then list.Add(entry)
                Next
            End If
        Next

        Return list.ToArray()
    End Function
End Class
