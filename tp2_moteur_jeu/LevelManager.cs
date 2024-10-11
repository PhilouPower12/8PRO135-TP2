using Godot;
using System;

public partial class LevelManager : Node
{
	private Sprite2D sprite2D;

	public override void _Ready()
	{
		base._Ready();
		sprite2D = GetNode<Sprite2D>("CharacterBody2D/Sprite2D");
	}
	
	public void LoadLevel(string scenePath)
	{
		var error = GetTree().ChangeSceneToFile(scenePath);
		if (error == Error.Ok)
		{
			GD.Print("Loaded level: " + scenePath);
		}
		else
		{
			GD.PrintErr("Failed to load level: " + scenePath);
		}		
	}
}
