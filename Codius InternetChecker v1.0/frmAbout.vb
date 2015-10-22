Public Class frmAbout
    Public Version As String = "Версия ПО: 1.0"
    Public UserLicense As String = "Лицензия: Свободная"
    Public Release As String = "Выпуск: Стандартный"
    Public Copyright As String = "© Кодиус, 2011-" + Now.Year.ToString + ". Все права защищены."
    Public Website As String = "http://codius.ru/articles/117"
    Public EMail As String = "info@codius.ru"
    'Public LastDateStartUpdate As String = "29.09.2015"
    'Public LastDateUpdate As String = "09.10.2015"

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lbl() As Label = {Me.lblUser, Me.lblRelease, Me.lblVersion, Me.lblCopyright, Me.lnkWWW, Me.lnkMailTo}
        Dim str() As String = {UserLicense, Release, Version, Copyright, Website, EMail}

        For i As Integer = 0 To lbl.Length - 1
            lbl(i).Text = str(i)
        Next
    End Sub

    Private Sub lnk_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkWWW.LinkClicked, lnkMailTo.LinkClicked
        AppActions.GoToLink(CType(sender, LinkLabel).Text)
    End Sub
End Class