Imports System.IO
Imports System.Net

Public Class Form1
    Dim Phase As Integer = 0
    Dim Counter1 As Integer = 0 'Successfully downloaded images
    Dim Counter2 As Integer = 0 'Skipped downloads (same name or already exists)
    Dim Counter4 As Integer = 0 'Error

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
                    Label12.Text = count

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
            Case 1 'Empires & Allies
                My.Settings.HashEA = tbHash.Text
                My.Settings.DestEA = tbDest.Text
            Case 2 'Treasure Isle
                My.Settings.HashTI = tbHash.Text
                My.Settings.DestTI = tbDest.Text
            Case 3 'FarmVille
                My.Settings.HashFV = tbHash.Text
                My.Settings.DestFV = tbDest.Text
            Case 4 'Adventure World
                My.Settings.HashAW = tbHash.Text
                My.Settings.DestAW = tbDest.Text
            Case 5 'Mafia Wars 2
                My.Settings.HashMW2 = tbHash.Text
                My.Settings.DestMW2 = tbDest.Text
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

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'CityVille
        Dim cv_url As String = "http://assets.cityville.zynga.com/hashed/"
        Dim cv_url2 As String = "https://zynga1-a.akamaihd.net/city/static/"
        Dim cv_destprefix As String = "CityVille\"
        'Empires & Allies       old: http://assets.empire.zynga.com/assets/hashed/ 
        Dim ea_url As String = "http://empire-zc.static.zgncdn.com/assets/hashed/"
        Dim ea_destprefix As String = "Empire & Allies\"
        'Treasure Isle
        Dim ti_url As String = "http://assets.treasure.zynga.com/prod/hashed/"
        Dim ti_destprefix As String = "Treasure Isle\"
        'FarmVille              old: http://static-0.farmville.com/admin-beta/hashed/")
        Dim fv_url As String = "http://static-0.farmville.zgncdn.com/assets/hashed/"
        Dim fv_destprefix As String = "FarmVille\"
        'Adventure World (new game)
        Dim aw_url As String = "http://assets.adventure-zc.zgncdn.com/hashed/"
        Dim aw_destprefix As String = "Adventure World\"
        'Mafia Wars 2
        Dim mw2_url As String = "http://mw2.static.zgncdn.com/hashed/"
        Dim mw2_destprefix As String = "Mafia Wars 2\"
        'CastleVille
        Dim cav_url As String = "http://assets.castle.zgncdn.com/hashed/"
        Dim cav_destprefix As String = "CastleVille\"
        'Hidden Chronicles
        Dim hc_url As String = "http://hog.assets1.zgncdn.com/hashed/"
        Dim hc_destprefix As String = "Hidden Chronicles\"
        'FarmVille 2
        Dim fv2_urls() As String = {"https://zynga1-a.akamaihd.net/farm2/", "http://zynga1-a.akamaihd.net/farm2/", "http://zynga2-a.akamaihd.net/farm2/",
                                    "http://zynga3-a.akamaihd.net/farm2/", "http://zynga4-a.akamaihd.net/farm2/"}
        Dim fv2_destprefix As String = "FarmVille 2\"

        Dim sel_url As String = ""
        Dim sel_destprefix As String = ""
        Select Case My.Settings.GameIndex
            Case 0 'CityVille
                sel_url = cv_url
                sel_destprefix = cv_destprefix
            Case 1 'Empires & Allies
                sel_url = ea_url
                sel_destprefix = ea_destprefix
            Case 2 'Treasure Isle
                sel_url = ti_url
                sel_destprefix = ti_destprefix
            Case 3 'FarmVille
                sel_url = fv_url
                sel_destprefix = fv_destprefix
            Case 4 'Adventure World
                sel_url = aw_url
                sel_destprefix = aw_destprefix
            Case 5 'Mafia Wars 2
                sel_url = mw2_url
                sel_destprefix = mw2_destprefix
            Case 6 'CastleVille
                sel_url = cav_url
                sel_destprefix = cav_destprefix
            Case 7 'Hidden Chronicles
                sel_url = hc_url
                sel_destprefix = hc_destprefix
            Case 8 'FarmVille 2
                sel_destprefix = fv2_destprefix
        End Select

        Dim Root As String = tbDest.Text & "\" & sel_destprefix

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

            Dim ext As String = sInputLine.Split(".").Last
            If image_extensions.Contains(ext) Or Not My.Settings.OnlyImages Then
                Dim parts As String()
                Dim target As String
                Dim source As String
                Select Case My.Settings.GameIndex
                    Case 0 To 2, 4 To 7 'CV, EA, TI, AW, MW2, CaV, HC algorithm
                        If sInputLine.Contains(":") Then
                            parts = sInputLine.Split(":") 'Splited string (0 = hash code, 1 = path/target)
                            source = sel_url & parts(0) & "." & ext 'serverroot/ + Hashcode + . + ext
                            target = Root & parts(1).Replace("/", "\") 'Root + path/target
                        Else
                            source = cv_url2 & sInputLine
                            target = Root & sInputLine.Replace("/", "\")
                        End If
                    Case 3 'FV algorithm
                        parts = sInputLine.Split(":") 'Splited string (0 = path/target, 1 = web path/source)
                        source = sel_url & parts(0) & "." & ext 'serverroot/ + Hashcode + . + ext
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
                        Phase = "5"
                        e.Cancel = True
                        Exit Sub
                End Select

                If Not File.Exists(target) Then
                    Dim dir As String = target.Substring(0, target.LastIndexOf("\")) 'Directory
                    If Not Directory.Exists(dir) Then  'If directory does not exist,
                        Directory.CreateDirectory(dir) 'it will be created.
                    End If

                    Try 'WEBCLIENT
                        Dim wc As New WebClient
                        wc.Credentials = New NetworkCredential(username, pwd)
                        wc.DownloadFile(source, target)
                    Catch ex As Exception
                        MsgBox(ex.Message & vbNewLine & source)
                    End Try

                    If File.Exists(target) Then
                        Counter1 += 1 'Count as successful download
                    Else
                        Counter4 += 1 'Count as error download
                    End If
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
                Phase = "2"
                e.Cancel = True
                Exit Sub
            End If

            sInputLine = srFileReader.ReadLine()
        Loop
        Phase = "3"
    End Sub
 
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label8.Text = Counter1
        Label7.Text = Counter2
        Label11.Text = Counter4
        Dim sum As Integer = Counter1 + Counter2 + Counter4
        Dim num As Integer = sum * 100 / CInt(Label12.Text)
        Label10.Text = num.ToString & "% (" & sum & ")"
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://cityville.wikia.com/wiki/User:Mihapro")
    End Sub

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCV.Click, mEA.Click, mTI.Click, mFV.Click, mAW.Click, mMW2.Click, mMW2.Click, mCaV.Click, mHC.Click, mFV2.Click
        Dim obj As ToolStripMenuItem = sender
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
            Case 1 'Empires & Allies
                color1 = Color.DodgerBlue
                color2 = Color.Orange
                btnHash.Text = "HashEA.txt"
                tbHash.Text = My.Settings.HashEA
                tbDest.Text = My.Settings.DestEA
            Case 2 'Treasure Isle
                color1 = Color.DodgerBlue
                color2 = Color.LimeGreen
                btnHash.Text = "HashTI.txt"
                tbHash.Text = My.Settings.HashTI
                tbDest.Text = My.Settings.DestTI
            Case 3 'FarmVille
                color1 = Color.SeaGreen
                color2 = Color.Peru
                btnHash.Text = "HashFV.txt"
                tbHash.Text = My.Settings.HashFV
                tbDest.Text = My.Settings.DestFV
            Case 4 'Adventure World
                color1 = Color.Peru
                color2 = Color.Chocolate
                btnHash.Text = "HashAW.txt"
                tbHash.Text = My.Settings.HashAW
                tbDest.Text = My.Settings.DestAW
            Case 5 'Mafia Wars 2
                color1 = Color.DodgerBlue
                color2 = Color.DarkGray
                btnHash.Text = "HashMW2.txt"
                tbHash.Text = My.Settings.HashAW
                tbDest.Text = My.Settings.DestAW
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
    End Sub

    Private Sub ColorMenu(ByVal i As Integer)
        mCV.ForeColor = Color.Black
        mEA.ForeColor = Color.Black
        mTI.ForeColor = Color.Black
        mFV.ForeColor = Color.Black
        mAW.ForeColor = Color.Black
        mMW2.ForeColor = Color.Black
        mCaV.ForeColor = Color.Black
        mHC.ForeColor = Color.Black
        mFV2.ForeColor = Color.Black
        Select Case i
            Case 0
                mCV.ForeColor = Color.White
            Case 1
                mEA.ForeColor = Color.White
            Case 2
                mTI.ForeColor = Color.White
            Case 3
                mFV.ForeColor = Color.White
            Case 4
                mAW.ForeColor = Color.White
            Case 5
                mMW2.ForeColor = Color.White
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
        If Phase = "0" Then
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
            Phase = "1"
            NI.ShowBalloonTip(5000, "MPRO ID running in the background!", "MPRO Image Downloader is running in the background. Right-click the icon in the system tray and select 'Exit' to end the program.", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub NI_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NI.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ResetStats()
        Label8.Text = "0"
        Label7.Text = "0"
        Label11.Text = "0"
        Label12.Text = "0"
        Label10.Text = "0% (0)"
    End Sub

    Private Sub cbImages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbImages.CheckedChanged
        My.Settings.OnlyImages = cbImages.Checked
        My.Settings.Save()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        btnStart.Text = "START"
        EnableUI(True)
        btnStart.Image = My.Resources.Flag_Green
        Timer1.Enabled = False

        '3 = completed, 2 = cancelled
        If Phase = "3" Then
            NI.ShowBalloonTip(4000, "Downloading finished", "Click here to see results.", ToolTipIcon.Info)
        ElseIf Phase = "4" Then
            NI.ShowBalloonTip(4000, "Downloading aborted", "Game not selected.", ToolTipIcon.Info)
        ElseIf Phase = "2" Then
            NI.ShowBalloonTip(4000, "Downloading cancelled", "You have cancelled downloading.", ToolTipIcon.Info)
        Else
            NI.ShowBalloonTip(4000, "Downloading stopped", "Downloading has stopped for unknown reason.", ToolTipIcon.Info)
        End If
        Phase = "0"
    End Sub
End Class
