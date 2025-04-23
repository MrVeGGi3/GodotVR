using Godot;
using System;

public partial class TimeCounter : Node
{
    private int timeRemaining = 30;
    private bool timerRunning = false;
    private Label timeCounter;

    public override void _Ready() 
    {
        base._Ready();
        timeCounter = GetNode<Label>("Label");

    }

    public override void _Process(double delta) 
    {
        base._Process(delta);
        timeCounter.Text = timeRemaining.ToString();

        if(timerRunning)
        {
            timeRemaining = timeRemaining - (int)delta * 1;
        }
        if(timeRemaining < 0)
        {
            timerRunning = false;
            timeRemaining = 0;
        }
    }

    public void runTimerCount(bool state)
    {
        timerRunning = state;
    }
    public void restartTimer()
    {
        timeRemaining = 30;
    }

}
