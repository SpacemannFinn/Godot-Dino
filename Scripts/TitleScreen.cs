using Godot;
using System;

public class TitleScreen : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Label label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		label = GetNode<Label>("hiscore");
		var score = (Score)GetNode("/root/Score");
		
		if (score.score > score.hiscore){
			score.hiscore = score.score;
		}
		
		label.Text = "HISCORE: " + score.hiscore;
	}
	  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (Input.IsActionJustPressed("Jump")){
			GetTree().ChangeScene("res://Scenes/Level.tscn");
		}
	}
}
