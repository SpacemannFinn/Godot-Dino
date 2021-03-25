using Godot;
using System;

public class Level : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Label scoreLabel;
	private Label hiscoreLabel;
	private Timer timer;
	public PackedScene OBSTACLE;
	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
		var score = (Score)GetNode("/root/Score");
		
		score.score = 0;
		
		scoreLabel = GetNode<Label>("score");
		hiscoreLabel = GetNode<Label>("hiscore");
		timer = GetNode<Timer>("Timer");
		
		hiscoreLabel.Text = "HISCORE: " + score.hiscore;
		//Timer timer = this.GetNode<Timer>("Timer");
		//timer.WaitTime = 3;
		//timer.Connect("timeout", this, "_on_Timer_timeout");
	}
	
	void _on_Timer_timeout()
	{
		Random rand = new Random();
		OBSTACLE = (PackedScene)ResourceLoader.Load("res://Scenes/Obstacle.tscn");
		var obstacle  = OBSTACLE.Instance();
		AddChild(obstacle);
		timer.WaitTime = rand.Next(1,3);
	}
	
	void _on_ScoreTimer_timeout() 
	{
		var score = (Score)GetNode("/root/Score");
		score.score += 1;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var score = (Score)GetNode("/root/Score");
		scoreLabel.Text = "SCORE: " + score.score;
	}
}
