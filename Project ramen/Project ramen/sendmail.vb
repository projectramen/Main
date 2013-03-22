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
            Net.NetworkCredential("dummyemail", "dummypassword")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress("dummyemail")
            mail.To.Add("dummytosend")
            mail.Subject = Subject
            mail.Body = RichTextBox1.Text
            ProgressBar1.Value = "50"
            SmtpServer.Send(mail)
            ProgressBar1.Value = "100"
            MsgBox("Email Sent")
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
