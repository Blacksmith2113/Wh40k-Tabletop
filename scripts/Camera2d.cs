using Godot;
using System;

public partial class Camera2d : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AnchorMode = AnchorModeEnum.DragCenter;
		Zoom = new Vector2(1.15f, 1.15f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.WheelUp)
			{
				Zoom += new Vector2(0.2f, 0.2f);
			}
			if (mouseButton.ButtonIndex == MouseButton.WheelDown)
			{
				Zoom -= new Vector2(0.2f, 0.2f);
			}
			float zoomLimit = Math.Clamp(Zoom.X, 0.5f, 1.1f);
			Zoom = new Vector2(zoomLimit, zoomLimit);
		}
	}
}