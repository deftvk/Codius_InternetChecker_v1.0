Imports System.IO
Imports System.Net
Imports Codius

Public Class frmMain
    Dim flagHasInternet As Boolean = False

    Dim flagFirstTime As Boolean = True
    Dim flagNoServers As Boolean = False

    Dim dataFormat As String = "yyyy.MM.dd HH:mm:ss"
    Dim logFilePath As String = Application.StartupPath + "\log.txt"

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ДобавитьВЛогЗавершениеРаботы()
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.notifyIcon.Text = "Инициализация..."
        ДобавитьВЛог("Программа запущена " + Format(Now, dataFormat))
        ДобавитьВЛог(Format(Now, dataFormat) + " Инициализация... Первый запрос может занимать продолжительное время")

        Me.notifyIcon.Visible = True
        tmrMain.Enabled = True
    End Sub
    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        tmrMain.Enabled = False
        '================================================================================================

        Dim tmpFlagHasInternet As Boolean = ПроверитьПодключениеКИнтернет()
        If tmpFlagHasInternet <> flagHasInternet Or flagFirstTime Then
            If flagFirstTime Then flagFirstTime = False
            If tmpFlagHasInternet Then
                lblHasInet.Text = "Интернет есть"
                lblHasInet.Image = My.Resources.iglobe
                Me.notifyIcon.Icon = My.Resources.globe
            Else
                lblHasInet.Text = "Интернета нет"
                lblHasInet.Image = My.Resources.iglobe_none
                Me.notifyIcon.Icon = My.Resources.globe_none
            End If

            Me.notifyIcon.BalloonTipTitle = Me.Text
            Me.notifyIcon.BalloonTipText = lblHasInet.Text
            Me.notifyIcon.BalloonTipIcon = ToolTipIcon.Info
            If tmpFlagHasInternet Then
                Me.notifyIcon.ShowBalloonTip(3000)
            Else
                Me.notifyIcon.ShowBalloonTip(30000)
            End If

            Me.notifyIcon.Text = Me.Text + vbNewLine + lblHasInet.Text
            ДобавитьВЛог(Format(Now, dataFormat) + " " + lblHasInet.Text)

            flagHasInternet = tmpFlagHasInternet
        End If

        '================================================================================================
        If tmrMain.Interval <> My.Settings.Period * 1000 Then tmrMain.Interval = My.Settings.Period * 1000
        tmrMain.Enabled = True
    End Sub

#Region "Нажатия кнопок"
    Private Sub btnsConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click, mnuConfig.Click
        Dim frm As New frmConfig
        frm.filePath = Me.logFilePath

        frm.txtCount.Text = My.Settings.Period.ToString
        frm.txtServers.Text = My.Settings.Servers
        frm.chkSaveToFile.Checked = My.Settings.SaveLogToFile
        frm.chkMinimizeToTray.Checked = My.Settings.MinimizeToTray

        Dim autoRun As Boolean = AppConfig.GetAutorunState() ' Запоминаем во временную переменную состояние реестра
        frm.chkStartWithWin.Checked = autoRun

        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            If autoRun <> frm.chkStartWithWin.Checked Then AppConfig.SetAutorun(frm.chkStartWithWin.Checked)

            If Val(frm.txtCount.Text) > 1 Then
                My.Settings.Period = Val(frm.txtCount.Text)
                Me.tmrMain.Interval = My.Settings.Period
                Me.tmrMain.Enabled = False
                Me.tmrMain.Enabled = True
            End If
            My.Settings.Servers = frm.txtServers.Text
            My.Settings.SaveLogToFile = frm.chkSaveToFile.Checked

            My.Settings.MinimizeToTray = frm.chkMinimizeToTray.Checked
            My.Settings.Save()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click, mnuExit.Click
        ДобавитьВЛогЗавершениеРаботы()
        End
    End Sub
    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        Dim frm As New frmAbout
        frm.ShowDialog()
    End Sub

#End Region

#Region "Служебные функции"
    Private Function ЗаписатьДанныеВФайл(filename As String, strLine As String, Optional append As Boolean = True) As Boolean
        Dim objStreamWriter As StreamWriter
        Try
            objStreamWriter = New StreamWriter(filename, append)
            objStreamWriter.WriteLine(strLine)
            objStreamWriter.Close()
        Catch ex As Exception
            If objStreamWriter IsNot Nothing Then objStreamWriter.Close()
            MsgBox(ex.ToString)
            Return False
        End Try
        Return True
    End Function
    Private Function ПрочестьДанныеИзФайла(filename As String) As Boolean
        Dim objStreamReader As StreamReader

        Try
            objStreamReader = New StreamReader(filename)
            Dim strLine As String = objStreamReader.ReadLine
            Do While Not strLine Is Nothing
                Console.WriteLine(strLine)
                strLine = objStreamReader.ReadLine
            Loop
        Catch ex As Exception
            If objStreamReader IsNot Nothing Then objStreamReader.Close()
            MsgBox(ex.ToString)
            Return False
        End Try

        Return True
    End Function
    Private Function ПроверитьПодключениеКИнтернет() As Boolean
        Static index As Integer = 0
        Dim servers As String() = My.Settings.Servers.Split(Chr(13)).Where(Function(s) Not String.IsNullOrEmpty(s.Trim)).ToArray

        If servers.Count = 0 Then
            servers = {"www.ya.ru"}
            'If Not flagNoServers Then
            '    ДобавитьВЛог(Format(Now, dataFormat) + " Нет списка серверов - необходимо добавить в настройках.")
            '    flagNoServers = True ' Больше не выводим сообщение о некорректном списке серверов
            'End If
            'Return False
        End If

        flagNoServers = False

        If index > servers.Count - 1 Then index = 0

        Dim url As String = servers(index).Trim
        index += 1 ' Проходим по все серверам

        If Not String.IsNullOrEmpty(url) Then
            Return ПолучитьОтветСервера(url)
        End If
        Return False
    End Function
    Private Function ПолучитьОтветСервера(url As String) As Boolean
        '' Приводит к синему экрану смерти через время
        'Console.WriteLine(Now.ToString + " Начало пинга")
        'If flagFirstTime Then
        '    If My.Computer.Network.Ping("www.ya.ru", 5000) Then
        '        Console.WriteLine(Now.ToString + " ОК")
        '        Return True
        '    Else
        '        Console.WriteLine(Now.ToString + " --")
        '        Return False
        '    End If
        'End If

        Dim t As New TimeSpan()
        Try
            'Console.WriteLine(Now.ToString + " Начало проверки")
            Dim start As DateTime = Now
            Me.lblState.Text = "Запрос " + url
            Application.DoEvents()
            'Console.WriteLine(Now.ToString + " Создан запрос")
            Dim wRequest As HttpWebRequest = HttpWebRequest.Create(url)
            Application.DoEvents()
            Me.lblState.Text = "Запрос отправлен на " + url
            'Console.WriteLine(Now.ToString + " Запрос отправлен")
            Dim wResponse As HttpWebResponse = wRequest.GetResponse
            Application.DoEvents()
            'Console.WriteLine(Now.ToString + " Ответ получен")
            wResponse.Close()
            'Console.WriteLine(Now.ToString + " Запрос закрыт")
            'Console.WriteLine("===================================")
            t = Now - start
            Me.lblState.Text = "Получен ответ от " + url + " за " + TimeSpanToMiliseconds(t)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function TimeSpanToMiliseconds(t As TimeSpan) As String
        Dim str As String = t.Milliseconds.ToString + " мс"
        If t.Seconds > 0 Then str = t.Seconds.ToString + " с " + str
        If t.Minutes > 0 Then str = t.Minutes.ToString + " мин " + str
        If t.Hours > 0 Then str = t.Hours.ToString + " мин " + str

        Return str
    End Function
    Private Sub ДобавитьВЛог(logstring As String)
        If My.Settings.SaveLogToFile Then
            ЗаписатьДанныеВФайл(logFilePath, logstring)
        End If
        If Not String.IsNullOrWhiteSpace(Me.txtLog.Text) Then Me.txtLog.Text += vbNewLine
        Me.txtLog.Text += logstring
        Me.txtLog.SelectionStart = Me.txtLog.Text.Length
        'Me.txtLog.Select(Me.txtLog.Text.Length, 0)
        Me.txtLog.ScrollToCaret()
    End Sub
    Private Sub ДобавитьВЛогЗавершениеРаботы()
        ДобавитьВЛог("Программа завершена " + Format(Now, dataFormat))
        ДобавитьВЛог("==================================================")
        Me.notifyIcon.Visible = False
    End Sub
#End Region

#Region "Работа с треем"
    Dim winState As FormWindowState = FormWindowState.Normal
    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState <> FormWindowState.Minimized And winState <> Me.WindowState Then
            winState = Me.WindowState ' Запоминаем состояние окна до сворачивания 
        End If

        If My.Settings.MinimizeToTray Then
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Hide()
            Else
                Me.Show()
            End If
        End If

        If Me.WindowState = FormWindowState.Minimized Then
            Me.mnuNormal.Visible = True
            Me.mnuMini.Visible = False
        Else
            Me.mnuNormal.Visible = False
            Me.mnuMini.Visible = True
        End If
    End Sub
    Private Sub notifyIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles notifyIcon.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Show()
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = winState
            Else
                If Not Me.Focused Then Me.Focus()
            End If
        End If
    End Sub
    Private Sub mnuMini_Click(sender As Object, e As EventArgs) Handles mnuMini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub mnuNormal_Click(sender As Object, e As EventArgs) Handles mnuNormal.Click
        Me.WindowState = winState
    End Sub
#End Region




End Class
