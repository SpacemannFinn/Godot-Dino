using Godot;
using System;

public class Obstacle : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	// Called when the node enters the scene tree for the first time.
	private AnimatedSprite player_Animation;
	private CollisionShape2D collider;
	string[] obstacle_list = {"cactus_10", "cactus_20", "cactus_30", "cactus_1",
								"cactus_2", "cactus_3", "burd"};
	
	public override void _Ready()
	{
		player_Animation = GetNode<AnimatedSprite>("Sprite");
		
		Random random = new Random();
		var current_obstacle = obstacle_list[random.Next(obstacle_list.Length)];
		GD.Print(current_obstacle);
		collider = GetNode<CollisionShape2D>(current_obstacle);
		collider.Disabled = false;
		collider.Visible = true;
		player_Animation.Animation = current_obstacle;
	}
	
	private void _on_VisibilityNotifier2D_screen_exited()
	{
		collider.Disabled = true;
		collider.Visible = false;
		QueueFree();
	// Replace with function body.
	}
	
	public void _on_Obstacle_body_entered(Node body)
	{
		body.Call("EndGame");
		
	// Replace with function body.
	}

  	public override void _Process(float delta)
  	{
		Random rand = new Random();
		int obstacle_speed = rand.Next(450, 550);
		float AMOUNT = obstacle_speed * delta;
		this.Position -= new Vector2(AMOUNT, 0);
	}
}

