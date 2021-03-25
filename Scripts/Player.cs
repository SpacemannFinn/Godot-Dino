using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	public const int GRAVITY = 50;
	public int JUMP_SPEED = -1000;
	private Vector2 velocity = new Vector2(0,0);
	private AnimatedSprite player_Animation;
	private AudioStreamPlayer audio;
	private AudioStreamPlayer audio2;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public async void EndGame()
	{
		audio2 = GetNode<AudioStreamPlayer>("Sound2");
		audio2.Play();
		await ToSignal(audio2, "finished");
		GetTree().ChangeScene("res://Scenes/TitleScreen.tscn");
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  	public override void _Process(float delta)
  	{
		//velocity = new Vector2(0, GRAVITY);
		velocity.y += GRAVITY;
		player_Animation = GetNode<AnimatedSprite>("Sprite");
		audio = GetNode<AudioStreamPlayer>("Sound");
		
		if (Input.IsActionPressed("Jump") && IsOnFloor()){
			velocity.y = JUMP_SPEED;
			audio.Play();
		}
		
		if (IsOnFloor())
		{
			player_Animation.Play("run");
		} else {
			player_Animation.Play("jump");
		}
		
		
		MoveAndSlide(velocity, new Vector2(0,-1));
  	}
	
	
}
