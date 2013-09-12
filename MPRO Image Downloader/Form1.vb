Imports System
Imports System.IO
Imports System.Net

Public Class Form1
    Dim Phase As Integer = 0
    Dim Counter1 As Integer = 0 'Successfully downloaded images
    Dim Counter2 As Integer = 0 'Skipped downloads (same name or already exists)
    Dim Counter4 As Integer = 0 'Error
    Dim errorlog As String 'error.log file path
    Dim objWriter As System.IO.StreamWriter

    Private Sub btnHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHash.Click
        With OpenFileDialog1
            .FileName = btnHash.Text
            .ShowDialog()
            tbHash.Text = .FileName
        End With
    End Sub

    Private Sub btnDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDest.Click
        With FolderBrowserDialog1
            If Len(tbDest.Text) > 0 Then .SelectedPath = tbDest.Text
            .ShowDialog()
            tbDest.Text = .SelectedPath
        End With
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Select Case btnStart.Text
            Case "START"
                If Not System.IO.File.Exists(tbHash.Text) Or Not System.IO.Directory.Exists(tbDest.Text) Then
                    MsgBox("Hash file or destination folder does not exist.")
                Else
                    EnableUI(False)
                    ResetStats()
                    Save()
                    btnStart.Text = "CANCEL"
                    btnStart.Image = My.Resources.Flag_Red
                    Counter1 = 0
                    Counter2 = 0
                    Counter4 = 0
                    Timer1.Enabled = True

                    Dim count As Integer = 0
                    Dim obj As New StreamReader(tbHash.Text)
                    Dim line As String = obj.ReadLine
                    Do Until line Is Nothing
                        If line.Trim().Length > 0 Then
                            count += 1
                        End If
                        line = obj.ReadLine
                    Loop
                    obj.Close()
                    Label12.Text = count.ToString

                    BackgroundWorker1.RunWorkerAsync()
                End If
            Case "CANCEL"
                BackgroundWorker1.CancelAsync()
                EnableUI(True)
                Timer1.Enabled = False
                btnStart.Text = "START"
                btnStart.Image = My.Resources.Flag_Green
        End Select
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        HandleExit()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ToggleGame(My.Settings.GameIndex)
    End Sub

    Private Sub Save()
        Select Case My.Settings.GameIndex
            Case 0 'CityVille
                My.Settings.HashCV = tbHash.Text
                My.Settings.DestCV = tbDest.Text
            Case 3 'FarmVille
                My.Settings.HashFV = tbHash.Text
                My.Settings.DestFV = tbDest.Text
            Case 6 'CastleVille
                My.Settings.HashCaV = tbHash.Text
                My.Settings.DestCaV = tbDest.Text
            Case 7 'Hidden Chronicles
                My.Settings.HashHC = tbHash.Text
                My.Settings.DestHC = tbDest.Text
            Case 8 'FarmVille 2
                My.Settings.HashFV2 = tbHash.Text
                My.Settings.DestFV2 = tbDest.Text
            Case Else
                MsgBox("Error 39: Game does not exist. Select a game from the menu bar.")
                Exit Sub
        End Select
        My.Settings.Save()
    End Sub

    Private Sub BackgroundWorker1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles BackgroundWorker1.Disposed
        Finish()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'CityVille
        Dim cv_urls() As String = {"http://cityville-zc2.assets4.zgncdn.com/static/", "https://zynga1-a.akamaihd.net/city-zc2/static/assets/",
                                "http://assets.cityville.zynga.com/hashed/", "https://zynga1-a.akamaihd.net/city/static/"}
        Dim cv_destprefix As String = "CityVille\"
        'FarmVille              old: http://static-0.farmville.com/admin-beta/hashed/")
        Dim fv_urls() As String = {"http://static-0.farmville.zgncdn.com/assets/hashed/"}
        Dim fv_destprefix As String = "FarmVille\"
        'CastleVille
        Dim cav_urls() As String = {"http://assets.castle.zgncdn.com/hashed/"}
        Dim cav_destprefix As String = "CastleVille\"
        'Hidden Chronicles
        Dim hc_urls() As String = {"http://hog.assets1.zgncdn.com/hashed/"}
        Dim hc_destprefix As String = "Hidden Chronicles\"
        'FarmVille 2
        Dim fv2_urls() As String = {"https://zynga1-a.akamaihd.net/farm2/", "http://zynga1-a.akamaihd.net/farm2/", "http://zynga2-a.akamaihd.net/farm2/",
                                    "http://zynga3-a.akamaihd.net/farm2/", "http://zynga4-a.akamaihd.net/farm2/"}
        Dim fv2_destprefix As String = "FarmVille 2\"

        Dim sel_urls() As String
        Dim sel_destprefix As String = ""
        Select Case My.Settings.GameIndex
            Case 0 'CityVille
                sel_urls = cv_urls
                sel_destprefix = cv_destprefix
            Case 3 'FarmVille
                sel_urls = fv_urls
                sel_destprefix = fv_destprefix
            Case 6 'CastleVille
                sel_urls = cav_urls
                sel_destprefix = cav_destprefix
            Case 7 'Hidden Chronicles
                sel_urls = hc_urls
                sel_destprefix = hc_destprefix
            Case 8 'FarmVille 2
                sel_urls = fv2_urls
                sel_destprefix = fv2_destprefix
        End Select

        Dim Root As String = tbDest.Text & "\" & sel_destprefix
        If Not Directory.Exists(Root) Then  'If directory does not exist,
            Directory.CreateDirectory(Root) 'it will be created.
        End If

        errorlog = tbDest.Text & "\" & sel_destprefix & "\" & DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss") & "_" & sel_destprefix.Substring(0, sel_destprefix.Length - 1).ToLower() & "_error.log"

        Dim srFileReader As StreamReader
        Dim sInputLine As String
        Dim username As String = Nothing
        Dim pwd As String = Nothing

        Phase = 1
        NI.ShowBalloonTip(5000, "Download started!", "Downloading images for the first time can take a while depending on your hardware and internet connection speed.", ToolTipIcon.Info)
        srFileReader = System.IO.File.OpenText(tbHash.Text)

        Dim image_extensions() As String = {"jpg", "png", "gif"}
        'image_extensions = New String() {"jpg", "png", "gif"}

        sInputLine = srFileReader.ReadLine()
        Do Until sInputLine Is Nothing
            sInputLine = sInputLine.Trim()
            'MsgBox("Line: " + sInputLine)

            If sInputLine.Length = 0 Then 'Empty Line?
                'MsgBox("Skipping, empty line.")
                sInputLine = srFileReader.ReadLine()
                Continue Do
            End If

            Dim ext As String = CStr(IIf(sInputLine.Contains("."), sInputLine.Split(CChar(".")).Last, ""))
            If image_extensions.Contains(ext) Or Not My.Settings.OnlyImages Then
                Dim parts As String()
                Dim target As String
                Dim source As String
                Select Case My.Settings.GameIndex
                    Case 0, 6, 7 'CV, CaV, HC algorithm
                        If sInputLine.Contains("#") Then
                            parts = sInputLine.Split(CChar("#")) 'Splited string (0 => path/hash, 1 => filename)
                            source = parts(0).Substring(parts(0).LastIndexOf("/") + 1) 'serverroot/ + hash
                            target = Root & parts(0).Substring(0, parts(0).LastIndexOf("/") + 1).Replace("/", "\") + parts(1) 'Root + path + filename
                        Else
                            source = sInputLine
                            target = Root & sInputLine.Replace("/", "\")
                        End If
                    Case 3 'FV algorithm
                        parts = sInputLine.Split(CChar(":")) 'Splited string (0 = path/target, 1 = web path/source)
                        source = parts(0) & "." & ext 'serverroot/ + Hashcode + . + ext
                        target = Root & parts(0).Replace("/", "\") 'Root + path/target
                    Case 8 'FV2 algorithm (simple urls)
                        Dim valid As Boolean = False
                        For Each fv2_url As String In fv2_urls
                            If sInputLine.StartsWith(fv2_url) Then
                                valid = True
                                Exit For
                            End If
                        Next
                        If Not valid Then
                            Counter2 += 1
                            sInputLine = srFileReader.ReadLine()
                            Continue Do
                        End If

                        source = sInputLine
                        target = Root & sInputLine.Substring(sInputLine.IndexOf("/farm2/") + 7).Replace("/", "\")
                    Case Else
                        Phase = 4
                        e.Cancel = True
                        Exit Sub
                End Select

                'Check for a valid url
                Dim found As Boolean = False
                For Each url As String In sel_urls
                    Dim uri As New System.Uri(url & source)
                    Dim req As System.Net.WebRequest
                    req = System.Net.WebRequest.Create(uri)
                    Dim resp As System.Net.WebResponse
                    Try
                        resp = req.GetResponse()
                        resp.Close()
                        req = Nothing
                        Found = True
                        source = url & source
                        Exit For
                    Catch ex As Exception
                        Continue For
                    End Try
                Next

                If Not found Then
                    Counter4 += 1 'Count as error
                    sInputLine = srFileReader.ReadLine()
                    Continue Do
                End If

                If Not File.Exists(target) Then
                    Dim dir As String = target.Substring(0, target.LastIndexOf("\")) 'Directory
                    If Not Directory.Exists(dir) Then  'If directory does not exist,
                        Directory.CreateDirectory(dir) 'it will be created.
                    End If

                    Dim WC As New WebClient
                    AddHandler WC.DownloadFileCompleted, AddressOf WC_DownloadComplete
                    WC.DownloadFileAsync(New System.Uri(source), target)
                Else
                    'MsgBox("Skipping, file exists.")
                    Counter2 += 1 'Count as skipped download
                End If
            Else
                'MsgBox("Skipping (" + ext.ToUpper + " file).")
                Counter2 += 1 'Count as skipped download
            End If

            If BackgroundWorker1.CancellationPending = True Then
                'MsgBox("CancellationPending was set True.")
                Phase = 2
                Timer1.Stop()
                If Not objWriter Is Nothing Then
                    objWriter.Close()
                End If
                e.Cancel = True
                GC.Collect()
                Exit Sub
            End If

            sInputLine = srFileReader.ReadLine()
        Loop
        Phase = 5
    End Sub

    Private Sub WC_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

    End Sub

    Private Sub WC_DownloadComplete(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If e.Error IsNot Nothing Then
            Counter4 += 1 'Count as error download
            If objWriter Is Nothing Then
                objWriter = New System.IO.StreamWriter(errorlog)
            End If
            If Not objWriter.BaseStream Is Nothing Then
                objWriter.Write(e.Error.Message & vbNewLine)
            End If
        Else
            Counter1 += 1 'Count as successful download
        End If
        GC.Collect()
    End Sub

    Private Sub UpdateStats(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RichTextBox1.Clear()
        RichTextBox1.SelectionColor = Color.LimeGreen
        RichTextBox1.AppendText(CStr(Counter1))
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.AppendText(" / ")
        RichTextBox1.SelectionColor = Color.Gold
        RichTextBox1.AppendText(CStr(Counter2))
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.AppendText(" / ")
        RichTextBox1.SelectionColor = Color.Crimson
        RichTextBox1.AppendText(CStr(Counter4))

        Dim progress As Integer = Counter1 + Counter2 + Counter4
        Dim total As Integer = CInt(Label12.Text)
        Dim pct As Integer = CInt(progress * 100 / total)
        Label10.Text = progress & " (" & pct.ToString & "%)"

        If Phase = 5 Then
            Timer1.Stop()
            If Not objWriter Is Nothing Then
                objWriter.Close()
            End If
            Phase = 3
            Finish()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://cityville.wikia.com/wiki/User:Mihapro")
    End Sub

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCV.Click, mFV.Click, mCaV.Click, mHC.Click, mFV2.Click
        Dim obj As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Select Case obj.Name
            Case "mCV"
                ToggleGame(0)
            Case "mEA"
                ToggleGame(1)
            Case "mTI"
                ToggleGame(2)
            Case "mFV"
                ToggleGame(3)
            Case "mAW"
                ToggleGame(4)
            Case "mMW2"
                ToggleGame(5)
            Case "mCaV"
                ToggleGame(6)
            Case "mHC"
                ToggleGame(7)
            Case "mFV2"
                ToggleGame(8)
        End Select
    End Sub

    Private Sub ToggleGame(ByVal gameIndex As Integer)
        'Remember selected game
        My.Settings.GameIndex = gameIndex
        My.Settings.Save()
        ResetStats()
        'Default Colors
        Dim color1 As Color = Color.CornflowerBlue
        Dim color2 As Color = Color.RoyalBlue
        ColorMenu(gameIndex)
        Select Case gameIndex
            Case 0 'CityVille
                color1 = Color.DodgerBlue
                color2 = Color.Gold
                btnHash.Text = "HashCV.txt"
                tbHash.Text = My.Settings.HashCV
                tbDest.Text = My.Settings.DestCV
            Case 3 'FarmVille
                color1 = Color.SeaGreen
                color2 = Color.Peru
                btnHash.Text = "HashFV.txt"
                tbHash.Text = My.Settings.HashFV
                tbDest.Text = My.Settings.DestFV
            Case 6 'CastleVille
                color1 = Color.BlueViolet
                color2 = Color.Orange
                btnHash.Text = "HashCaV.txt"
                tbHash.Text = My.Settings.HashCaV
                tbDest.Text = My.Settings.DestCaV
            Case 7 'Hidden Chronicles
                color1 = Color.Chocolate
                color2 = Color.Gold
                btnHash.Text = "HashHC.txt"
                tbHash.Text = My.Settings.HashHC
                tbDest.Text = My.Settings.DestHC
            Case 8 'FarmVille 2
                color1 = Color.LightGreen
                color2 = Color.Orange
                btnHash.Text = "HashFV2.txt"
                tbHash.Text = My.Settings.HashFV2
                tbDest.Text = My.Settings.DestFV2
        End Select

        GameMenu.BackColor = color2
        btnHash.BackColor = color2
        btnDest.BackColor = color2
        btnStart.BackColor = color2
        Me.BackColor = color1
        RichTextBox1.BackColor = color1
    End Sub

    Private Sub ColorMenu(ByVal i As Integer)
        mCV.ForeColor = Color.Black
        mFV.ForeColor = Color.Black
        mCaV.ForeColor = Color.Black
        mHC.ForeColor = Color.Black
        mFV2.ForeColor = Color.Black
        Select Case i
            Case 0
                mCV.ForeColor = Color.White
            Case 3
                mFV.ForeColor = Color.White
            Case 6
                mCaV.ForeColor = Color.White
            Case 7
                mHC.ForeColor = Color.White
            Case 8
                mFV2.ForeColor = Color.White
        End Select
    End Sub

    Friend Sub EnableUI(ByVal bl As Boolean)
        GameMenu.Enabled = bl
        tbHash.Enabled = bl
        tbDest.Enabled = bl
        btnHash.Enabled = bl
        btnDest.Enabled = bl
        cbImages.Enabled = bl
    End Sub

    Private Sub Toggler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toggler.Click
        If Toggler.Text = "Show" Then
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            Toggler.Text = "Hide"
        ElseIf Toggler.Text = "Hide" Then
            Me.Hide()
            Toggler.Text = "Show"
        End If
    End Sub

    Friend Sub HandleExit()
        If BackgroundWorker1.IsBusy And BackgroundWorker1.CancellationPending Then
            NI.Visible = False
            End
        ElseIf BackgroundWorker1.IsBusy Then
            If MsgBox("Image download is in progress, but you can continue anytime you want. Do you want to exit?", MsgBoxStyle.YesNo, "MPRO Image Downloader") = MsgBoxResult.Yes Then
                BackgroundWorker1.CancelAsync()
                NI.Visible = False
                End
            End If
        Else
            NI.Visible = False
            End
        End If
    End Sub

    Private Sub NI_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles NI.BalloonTipClicked
        If Phase = 0 Then
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        HandleExit()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            Phase = 1
            NI.ShowBalloonTip(5000, "MPRO ID running in the background!", "MPRO Image Downloader is running in the background. Right-click the icon in the system tray and select 'Exit' to end the program.", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub NI_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NI.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ResetStats()
        RichTextBox1.Clear()
        RichTextBox1.SelectionColor = Color.LimeGreen
        RichTextBox1.AppendText("0")
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.AppendText(" / ")
        RichTextBox1.SelectionColor = Color.Gold
        RichTextBox1.AppendText("0")
        RichTextBox1.SelectionColor = Color.Black
        RichTextBox1.AppendText(" / ")
        RichTextBox1.SelectionColor = Color.Crimson
        RichTextBox1.AppendText("0")
        Label12.Text = "0"
        Label10.Text = "0 (0%)"
    End Sub

    Private Sub cbImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbImages.CheckedChanged
        My.Settings.OnlyImages = cbImages.Checked
        My.Settings.Save()
    End Sub

    Friend Sub Finish()
        btnStart.Text = "START"
        EnableUI(True)
        btnStart.Image = My.Resources.Flag_Green
        Timer1.Enabled = False

        '3 = completed, 2 = cancelled
        If Phase = 3 Then
            NI.ShowBalloonTip(4000, "Downloading finished", "Click here to see results.", ToolTipIcon.Info)
        ElseIf Phase = 4 Then
            NI.ShowBalloonTip(4000, "Downloading aborted", "Game not selected.", ToolTipIcon.Info)
        ElseIf Phase = 2 Then
            NI.ShowBalloonTip(4000, "Downloading cancelled", "You have cancelled downloading.", ToolTipIcon.Info)
        Else
            NI.ShowBalloonTip(4000, "Downloading stopped", "Downloading has stopped for unknown reason.", ToolTipIcon.Info)
        End If
        Phase = 0
    End Sub
End Class
