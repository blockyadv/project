' Blocky Adventure
' 5/1/23
' Alfred
' Period 1
' 1213 x 569
Imports System.Drawing.Imaging

Public Class Form1
    Dim score As Integer
    Dim gamestart As Integer
    Dim dy As Integer
    Dim jump As Integer
    Dim model As Integer
    Dim gravity As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()

        ' Disabling timers on form load, and setting score to 0 to essentially reset the game mechanics and score.

        scoretimer.Enabled = False
        scorelabel.Visible = False
        scoretext.Visible = False
        platform1.Visible = False
        player1.Visible = False
        score = 0
        gamestart = 0
        spike1.Visible = False
        gametimer.Enabled = False
        jump = 0
        dy = 0
        jumptimer.Enabled = False
        skintimer.Enabled = False
        movingtimer.Enabled = False
        gravity = -5

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles scoretimer.Tick

        ' Score count label counts in game counter

        score = score + 1
        scorelabel.Text = score
        scoretext.Visible = True


        ' Setting the max score of the level and turning off timer so no infinite glitch happens and ending level.

        If score = 1000 Then
            scoretimer.Enabled = False
            MsgBox("You beat the level! Congrats")
            End
        End If


    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        ' To exit the game/level then press Q/Escape Key.

        If e.KeyCode = Keys.Q Or e.KeyCode = Keys.Escape Then End

        ' Once a jump key is pressed, the jumptimer goes off

        If e.KeyCode = Keys.Up Then
            jump = 1
            jumptimer.Enabled = True
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles gametimer.Tick

        ' Animates the background to be moving, rather than the player.

        platform1.Left = platform1.Left - 2.5
        platform2.Left = platform2.Left - 2.5
        spike1.Left = spike1.Left - 2.5


    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If jump = 1 Then
            jump = 0
        End If
    End Sub

    ' Title Screen Phase of Game
    Private Sub howtoplaylabel_Click(sender As Object, e As EventArgs) Handles howtoplaylabel.Click
        ' Msgboxing because it makes it so they have to click out and does not cause any problems.
        MsgBox("Up Arrow Key to jump, avoid spikes and jump on platforms and perfectly time your way around and over these obstacles to reach the end of the level! The end of the each level is when you get 1000 for your score!")
    End Sub

    Private Sub creditslabel_Click(sender As Object, e As EventArgs) Handles creditslabel.Click
        MsgBox("Credits to me, Carti, and SZA for making all the code of the project, credits to all of the supporters, such as New York Times, Bonton, and more for the motivation to push forward, and thanks to the critics who complimented our game, Hails, Luke Sherry, and Ethan.")
    End Sub

    Private Sub startgamelabel_Click(sender As Object, e As EventArgs) Handles startgamelabel.Click

        ' Hides all the interface from the loading screen to basically start the game and create an empty canvas
        titlepic.Visible = False
        titlepic2.Visible = False
        titlepic3.Visible = False
        titlepic5.Visible = False
        titlepic6.Visible = False
        titlepic7.Visible = False
        titlepic8.Visible = False
        titlepic9.Visible = False
        titlepic10.Visible = False
        titlepic11.Visible = False
        titlelabel.Visible = False

        ' Made these labels so that I can use keyup and kewdown commands.
        startgamelabel.Visible = False
        howtoplaylabel.Visible = False
        creditslabel.Visible = False

        ' Starting in game timer and revealing in game stuff.

        scorelabel.Visible = True
        scoretimer.Enabled = True
        platform1.Visible = True
        player1.Visible = True
        spike1.Visible = True
        gametimer.Enabled = True
        movingtimer.Enabled = True
        gamestart = 1
    End Sub

    ' Next Section is just going to be coloring Labels when mouse enters/leaves to make it look nicer.

    Private Sub startgamelabel_MouseEnter(sender As Object, e As EventArgs) Handles startgamelabel.MouseEnter
        startgamelabel.BackColor = Color.Pink
    End Sub

    Private Sub startgamelabel_MouseLeave(sender As Object, e As EventArgs) Handles startgamelabel.MouseLeave
        startgamelabel.BackColor = Color.White
    End Sub

    Private Sub howtoplaylabel_MouseEnter(sender As Object, e As EventArgs) Handles howtoplaylabel.MouseEnter
        howtoplaylabel.BackColor = Color.Pink
    End Sub

    Private Sub howtoplaylabel_MouseLeave(sender As Object, e As EventArgs) Handles howtoplaylabel.MouseLeave
        howtoplaylabel.BackColor = Color.White
    End Sub

    Private Sub creditslabel_MouseEnter(sender As Object, e As EventArgs) Handles creditslabel.MouseEnter
        creditslabel.BackColor = Color.Pink
    End Sub

    Private Sub creditslabel_MouseLeave(sender As Object, e As EventArgs) Handles creditslabel.MouseLeave
        creditslabel.BackColor = Color.White
    End Sub

    Private Sub jumptimer_Tick(sender As Object, e As EventArgs) Handles jumptimer.Tick

        '  As long as they are jumping gravity is added

        If jump = 1 Then
            player1.Top = player1.Top - gravity
            gravity = -2
            player1.Top = player1.Top - 6
        End If

        ' As long as they are on the ground then jumping is disabled.

        If player1.Top - player1.Height <= platform1.Top Then
            jump = 0
        End If

        ' As long as they are jumping the skins will change direction

        If jumptimer.Enabled = True Then
            skintimer.Enabled = True
        Else
            skintimer.Enabled = False
        End If

    End Sub

    Private Sub skintimer_Tick(sender As Object, e As EventArgs) Handles skintimer.Tick

        ' while jumping the skin will change direction randomly so it's not bland

        model = Int(Rnd() * 4)

        If model = 1 Then
            player1.Image = My.Resources.player1
        ElseIf model = 2 Then
            player1.Image = My.Resources.player2
        ElseIf model = 3 Then
            player1.Image = My.Resources.player3
        ElseIf model = 4 Then
            player1.Image = My.Resources.player4
        End If

    End Sub
End Class