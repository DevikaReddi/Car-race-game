﻿Public Class Form1
    Dim speed As Integer
    Dim road(7) As PictureBox
    Dim score As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.racing, AudioPlayMode.BackgroundLoop)

        speed = 7
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8
    End Sub

    Private Sub RoadMover_Tick(sender As Object, e As EventArgs) Handles RoadMover.Tick
        For x As Integer = 0 To 7
            road(x).Top += speed
            If road(x).Top >= Me.Height Then
                road(x).Top = -road(x).Height
            End If
        Next

        If score > 5 Then
            speed = ((score / 5) * 2) + 7
        End If

        Label1.Text = "SPEED " & speed
        If (car.Bounds.IntersectsWith(race1.Bounds)) Then
            endgame()
        End If
        If (car.Bounds.IntersectsWith(race2.Bounds)) Then
            endgame()
        End If
        If (car.Bounds.IntersectsWith(race3.Bounds)) Then
            endgame()
        End If

    End Sub

    Private Sub endgame()
        Button1.Visible = True
        Label3.Visible = True
        My.Computer.Audio.Play(My.Resources._error, AudioPlayMode.WaitToComplete)
        My.Computer.Audio.Stop()

        RoadMover.Stop()
        RacerMover1.Stop()
        RacerMover2.Stop()
        RacerMover3.Stop()
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Then
            RightSide.Start()
        End If
        If e.KeyCode = Keys.Left Then
            LeftSide.Start()
        End If
    End Sub

    Private Sub RightSide_Tick(sender As Object, e As EventArgs) Handles RightSide.Tick
        If (car.Location.X < 410) Then
            car.Left += 3
        End If
    End Sub

    Private Sub LeftSide_Tick(sender As Object, e As EventArgs) Handles LeftSide.Tick
        If (car.Location.X > 0) Then
            car.Left -= 3
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        RightSide.Stop()
        LeftSide.Stop()
    End Sub

    Private Sub RacerMover1_Tick(sender As Object, e As EventArgs) Handles RacerMover1.Tick
        race1.Top += speed / 2
        If race1.Top >= Me.Height Then
            score += 1
            Label2.Text = "SCORE " & score

            race1.Top = -(CInt(Math.Ceiling(Rnd() * 200)) + race1.Height)
            race1.Left = CInt(Math.Ceiling(Rnd() * 105)) + 0
        End If
    End Sub

    Private Sub RacerMover2_Tick(sender As Object, e As EventArgs) Handles RacerMover2.Tick
        race2.Top += speed / 3
        If race2.Top >= Me.Height Then
            score += 1
            Label2.Text = "SCORE " & score

            race2.Top = -(CInt(Math.Ceiling(Rnd() * 200)) + race2.Height)
            race2.Left = CInt(Math.Ceiling(Rnd() * 105)) + 332
        End If
    End Sub

    Private Sub RacerMover3_Tick(sender As Object, e As EventArgs) Handles RacerMover3.Tick
        race3.Top += speed * 1 / 2
        If race3.Top >= Me.Height Then
            score += 1
            Label2.Text = "SCORE " & score

            race3.Top = -(CInt(Math.Ceiling(Rnd() * 200)) + race3.Height)
            race3.Left = CInt(Math.Ceiling(Rnd() * 105)) + 166
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        score = 0
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
    End Sub
End Class
