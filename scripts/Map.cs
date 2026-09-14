using Godot;
using System;

public partial class Map : Sprite2D
{
	private bool _isLeftClickHeld = false;
	private Vector2 _clickedMouse;
	private Vector2 _clickedCamera;

	Camera2D camera;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		camera = GetNode<Camera2d>("../Camera2D");
		var area = GetNode<Area2D>("Area2D");
		area.InputEvent += OnMapClicked;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnMapClicked(Node viewport, InputEvent @event, long shapeIdx)
	{
		if(@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
		{
			_isLeftClickHeld = true;
			_clickedMouse = GetViewport().GetMousePosition();
			_clickedCamera = GlobalPosition; // pozycja mapy, nie kamery
		}
	}

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.ButtonIndex == MouseButton.Left && !mouseButton.Pressed)
		{
			_isLeftClickHeld = false;
		}
		if(@event is InputEventMouseMotion mouseMotion && _isLeftClickHeld)
		{
			GD.Print($"clickedMouse: {_clickedMouse}, clickedCamera: {_clickedCamera}, mousePos: {mouseMotion.Position}");
			var currentMouse = GetViewport().GetMousePosition();
			GlobalPosition = _clickedCamera + (currentMouse - _clickedMouse);
		}
    }

}
