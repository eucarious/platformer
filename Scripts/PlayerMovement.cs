using Godot;
using System;

public partial class PlayerMovement : CharacterBody2D
{
	[Export]
	public int movementSpeed = 10;
	
	[Export]
	public int jumpStrength = 5;
	
	[Export]
	public int acceleration = 2;
	
	[Export]
	public int deceleration = 6;
	
	[Export]
	public int decelerationInAir = 3;
	
	public override void _Ready() 
	{
		// set animation to idle
		
	}
	 
	public override void _PhysicsProcess(double delta)
	{
		if (!IsOnFloor())
		{
			Velocity.y += gravity * delta;
		} 
		float dir = Input.GetAxis("Left", "Right");
		GetInput(dir);
		SetAnimation(dir);
		
		
	}
	
	public void GetInput(float direction) {
		if (Input.IsActionJustPressed("Jump") && IsOnFloor()) 
		{
			Velocity.y = jumpStrength;
		}
		
		
		if (direction == 0) 
		{
			Velocity.x = MoveToward(Velocity.x, direction * movementSpeed, acceleration);
		} 
		else 
		{
			if (IsOnFloor()) 
			{
				Velocity.x = MoveToward(Velocity.x, 0, deceleration);
			}
			else 
			{
				Velocity.x = MoveToward(Velocity.x, 0, decelerationInAir);
			}
		}
		
		
	}
	
	public void SetAnimation(float direction) 
	{
		// flip sprite direction
		if (direction > 0)
		{
			
		} 
		else if (direction < 0) 
		{
			
		}
		
		// set correct animation
//		switch (GetMode<Animator>("AnimationNode")) {}
	}
}
