Imports System.Net.Mail
Public Class Feedback
    Dim Subject
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Subject = InputBox("Message Subject? (Dont Change for Default)", "Subject", "Feedback")
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.EnableSsl = True
            SmtpServer.Credentials = New  _
            Net.NetworkCredential("kspunkyb@runedream.org", "asdfasdf")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.live.com"
            mail = New MailMessage()
            mail.From = New MailAddress("kspunkyb@runedream.org")
            mail.To.Add("chucksudden@gmail.com")
            mail.Subject = Subject
            mail.Body = RichTextBox1.Text
            ProgressBar1.Value = "50"
            SmtpServer.Send(mail)
            ProgressBar1.Value = "100"
            MsgBox("Thank you for your Input")
        Catch ex As Exception
            MsgBox(ex.ToString)
            If ex.ToString = "" Then
                cmdSend.Enabled = False
            Else
                MsgBox("An error has occured during sending. Please try again!")
            End If
        End Try
    End Sub
End Class
