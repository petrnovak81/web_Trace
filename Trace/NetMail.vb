Imports System.Net.Mail

Public Class NetMail
    Public Class NetworkCredential
        Public Property UserName As String
        Public Property Password As String
    End Class

    Private Property IsBodyHtml As Boolean
    Private Property Smtp As String
    Private Property Port As Integer
    Private Property UseDefaultCredentials As Boolean = False
    Private Property Credentials As NetworkCredential
    Private Property EnableSsl As Boolean = True

    Public Class Options
        Sub New()
            [To] = New List(Of String)
            Attachments = New List(Of String)
        End Sub
        Public Property DisplayName As String
        Public Property [To] As List(Of String)
        Public Property Subject As String
        <AllowHtml> _
        Public Property Body As String
        Public Property Attachments As List(Of String)
    End Class

    Public Sub New(_Smtp As String,
                   _Port As Integer,
                   _EnableSsl As Boolean,
                   _UserName As String,
                   _Password As String,
                   Optional _IsBodyHtml As Boolean = True,
                   Optional _UseDefaultCredentials As Boolean = False)

        IsBodyHtml = _IsBodyHtml
        Smtp = _Smtp
        Port = _Port
        UseDefaultCredentials = _UseDefaultCredentials
        Credentials = New NetworkCredential With {.UserName = _UserName, .Password = _Password}
        EnableSsl = _EnableSsl
    End Sub

    Public Sub Send(e As Options)
        Dim mail As New MailMessage()

        ''Pro potvrzení o doručení, přečtení
        'mail.Headers.Add("Disposition-Notification-To", "email@gmail.com")
        'mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess

        For Each i In e.[To]
            If (e.[To].IndexOf(i) = 0) Then
                mail.To.Add(i)
            Else
                mail.Bcc.Add(i)
            End If
        Next

        If e.DisplayName IsNot Nothing Then
            mail.From = New MailAddress(Credentials.UserName, e.DisplayName)
        Else
            mail.From = New MailAddress(Credentials.UserName)
        End If

        mail.Subject = e.Subject
        mail.Body = e.Body
        mail.IsBodyHtml = IsBodyHtml

        Dim a As System.Net.Mail.Attachment = Nothing
        If e.Attachments IsNot Nothing Then
            For Each f As String In e.Attachments
                If System.IO.File.Exists(f) Then
                    a = New System.Net.Mail.Attachment(f)
                    mail.Attachments.Add(a)
                End If
            Next
        End If

        Dim client As New SmtpClient()
        client.Host = Smtp
        client.Port = Port
        client.EnableSsl = False
        client.UseDefaultCredentials = UseDefaultCredentials

        If Credentials.UserName IsNot Nothing Or Credentials.Password IsNot Nothing Then
            client.Credentials = New System.Net.NetworkCredential(Credentials.UserName, Credentials.Password)
        End If

        client.Send(mail)

        If e.Attachments.Count > 0 Then
            a.Dispose()
        End If

        client.Dispose()
    End Sub
End Class
