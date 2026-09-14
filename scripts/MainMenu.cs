using Godot;
using Godot.NativeInterop;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var exit = GetNode<Button>("VBoxContainer/ButtonExit");
		exit.Pressed += onExitPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onExitPressed()
	{
		GetTree().Quit();
	}
}
