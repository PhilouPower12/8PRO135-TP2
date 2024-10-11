using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;
	
	public Vector2 ScreenSize;
	
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		if (Input.IsActionPressed("Right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("Left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("Down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("Up"))
		{
			velocity.Y -= 1;;
		}
		
		if (Input.IsActionPressed("Save"))
		{
			Save();
			GD.Print("Position saved");
		}

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}
		
		Position += velocity * (float)delta;
		Position = new Vector2(x: Mathf.Clamp(Position.X, 0, ScreenSize.X),y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y));
	}
	
	public Godot.Collections.Dictionary<string, Variant> Save()
	{
		return new Godot.Collections.Dictionary<string, Variant>()
		{
			{ "PosX", Position.X },
			{ "PosY", Position.Y },
		};
	}
}
