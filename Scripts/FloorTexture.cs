using Godot;
using System;

public class FloorTexture : TextureRect
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
   		float AMOUNT = 500 * delta;
		this.RectPosition -=  new Vector2(AMOUNT, 0);
		this.RectSize += new Vector2(AMOUNT, 0);
	}
}
