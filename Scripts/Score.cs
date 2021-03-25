using Godot;
using System;

public class Score : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public int score = 0;
	public int hiscore = 0;
	private AudioStreamPlayer audio;
	private int oldScore = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer>("Sound");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		audio = GetNode<AudioStreamPlayer>("Sound");
		
		
		if((score - oldScore) == 100){
			oldScore = score;
			audio.Play();
		}
	}
}
