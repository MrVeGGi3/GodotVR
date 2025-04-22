using Godot;
using System;

public partial class SortingArrow : RayCast2D
{
	public static int sortNumber;
	private float velocity = 100.0f;
	public static Marker2D targetMarker;
	private RoletaCategoria subjectType;
	private bool canSpin = false;
	private float targetRotation;
	private GameManager gm;

	public override void _Ready() 
	{
		base._Ready();

		subjectType = GetNode<RoletaCategoria>(".");
		gm = GetNode<GameManager>("/root/GameManager");

		canSpin = true;
		SortMarkerNumber();
		lookAtMarker(sortNumber);
		GD.Print("O número Sorteado é:" + sortNumber);
	}

	private void lookAtMarker(int markerNumber)
	{
		gm.questionNumber = markerNumber;
		targetMarker = subjectType.markers[markerNumber];
	}

	private void SortMarkerNumber()
	{
		sortNumber = GD.RandRange(0, 7);
	}
	
   public override void _Process(double delta) 
	{
		base._Process(delta);
		if(canSpin)
		{  
			Vector2 MarkerDistance = targetMarker.GlobalPosition - GlobalPosition;
			targetRotation = MarkerDistance.Angle();

			Rotation = Mathf.LerpAngle(Rotation, targetRotation, (float)delta * velocity);

			if(Mathf.Abs(Mathf.AngleDifference(Rotation, targetRotation)) < 0.01f)
			{
				Rotation = targetRotation;
				canSpin = false;
			}
		}
	}

}
