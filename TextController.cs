using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States 
	{
	goalkeeper, center_defender, center_midfielder, left_defender, left_midfielder, right_defender, 
	right_midfielder, left_forward, right_forward, left_wing , right_wing, attacker_0, 
	attacker_1, goal_0, goal_1, goal_2
	};
	private States myState;

	// Initialization Only
	void Start () 
	{
		myState = States.goalkeeper;
	}
	
	// Every Frame
	void Update () 
	{
		print 		(myState);
		if 			(myState == States.goalkeeper) 				{goalkeeper();}
		else if 	(myState == States.center_defender)			{center_defender();}
		else if 	(myState == States.center_midfielder)		{center_midfielder();}
		else if 	(myState == States.left_defender)			{left_defender();}
		else if 	(myState == States.left_midfielder)			{left_midfielder ();}
		else if 	(myState == States.right_defender)			{right_defender();}
		else if 	(myState == States.right_midfielder)		{right_midfielder();}
		else if 	(myState == States.left_forward)			{left_forward();}
		else if 	(myState == States.right_forward)			{right_forward();}
		else if 	(myState == States.left_wing)				{left_wing();}
		else if 	(myState == States.right_wing)				{right_wing();}
		else if 	(myState == States.attacker_0)				{attacker_0();}
		else if 	(myState == States.attacker_1)				{attacker_1();}
		else if 	(myState == States.goal_0)					{goal_0();}
		else if 	(myState == States.goal_1)					{goal_1();}
		else if 	(myState == States.goal_2)					{goal_2();}			
	}

	#region Ball Possession Methods
	void goalkeeper ()
	{
		text.text = "Your goalkeeper has the ball, and it is a goal kick. There are only " +
					"3 players who currently look open however, which one has an opening?\n\n" +
					"Press L to pass to left defender, Space to pass to center defender " +
					"and R to pass to right defender.";		
		if 			(Input.GetKeyDown(KeyCode.L))				{myState = States.left_defender;}
		else if 	(Input.GetKeyDown(KeyCode.Space))			{myState = States.center_defender;}
		else if 	(Input.GetKeyDown(KeyCode.R))				{myState = States.right_defender;}
	}
	void left_defender ()
	{
		text.text = "Throwing the ball over to your left defender was too slow. " +
					"Now there is no one open. The only way forward, is back to the keeper.\n\n" +
					"Press B to pass the ball back to your keeper." ;
		if 			(Input.GetKeyDown(KeyCode.B))				{myState = States.goalkeeper;}
	}
	void center_defender ()
	{
		text.text = "Center defender has an opening to the center midfielder.\n\n" +
					"Press B to go back or Space to go forward.";
		if 			(Input.GetKeyDown(KeyCode.B))				{myState = States.goalkeeper;}
		else if 	(Input.GetKeyDown(KeyCode.Space))			{myState = States.center_midfielder;}
	}
	void right_defender ()
	{
		text.text = "The pass found the right defender, but he is double teamed " +
					"by the attacker and forward and is only left with one option.\n\n" +
					"Press B to return the ball to your goalkeeper." ;
		if 			(Input.GetKeyDown(KeyCode.B))				{myState = States.goalkeeper;}
	}
	void left_midfielder ()
	{
		text.text = "The left midfielder looks like his shoes are untied. " +
					"He must get the ball to one of the other midfielders.\n\n" +
					"Press B to quickly shuttle the ball back to the center midfielder " +
					"or R to boot the ball over to the right midfielder who has an opening";
		if 			(Input.GetKeyDown(KeyCode.B))				{myState = States.center_midfielder;}
		else if 	(Input.GetKeyDown(KeyCode.R))				{myState = States.right_midfielder;}
	}
	void center_midfielder ()
	{
		text.text = "Your center midfielder has 2 options to move the ball forward, " +
					"however only one looks promising.\n\n" +
					"Press L to pass to left midfielder, B to pass to back, " +
					"and R to pass to right midfielder.";
		if 			(Input.GetKeyDown(KeyCode.B))				{myState = States.center_defender;}
		else if 	(Input.GetKeyDown(KeyCode.L))				{myState = States.left_midfielder;}
		else if 	(Input.GetKeyDown(KeyCode.R))				{myState = States.right_midfielder;}
	}
	void right_midfielder ()
	{
		text.text = "The right midfielder is in top form today and sees the left " +
					"forward wide open.\n\n" +
					"Press B to return the ball to the center midfielder, Space to " +
					"pass to the open left forward";
		if 			(Input.GetKeyDown(KeyCode.B))				{myState = States.center_defender;}
		else if 	(Input.GetKeyDown(KeyCode.Space))			{myState = States.left_forward;}
	}
	void left_forward ()
	{
		text.text = "The left forward has set himself in a good position and there " +
					"are 3 players who are available.\n\n" +
					"Press L to pass to the left wing, R to pass to the right wing, and Space " +
					"to pass to the attacker.";
		if 			(Input.GetKeyDown(KeyCode.L))				{myState = States.left_wing;}
		else if 	(Input.GetKeyDown(KeyCode.Space))			{myState = States.attacker_0;}
		else if 	(Input.GetKeyDown(KeyCode.R))				{myState = States.right_wing;}
	}
	void left_wing ()
	{
		text.text = "The left wing has 2 players immediately closing in and must " +
			"give the ball directly back to the left forward. \n\n" +
			"Press B to pass the ball back to the left forward.";
		if 			(Input.GetKeyDown (KeyCode.B)) 				{myState = States.left_forward;}
	}
	void attacker_0 ()
	{
		text.text = "The attacker's keen eye sees that a pass to the right forward " +
					"may fool their defenders.\n\n" +
					"Press R to pass to the right forward.";
		if 			(Input.GetKeyDown(KeyCode.R))				{myState = States.right_forward;}
	}
	void right_wing ()
	{
		text.text = "Their defenders are right on top of you and you must " +
					"give the ball directly back to the left forward. \n\n" +
					"Press B to pass the ball back to the left forward.";
		if 			(Input.GetKeyDown (KeyCode.B)) 				{myState = States.left_forward;}
	}
	void right_forward ()
	{
		text.text = "The pass to the right forward has opened up some " +
					"space in their defense! Pass back to the attacker " +
					"to continue the attack. \n\n" +
					"Press C to cross the ball over to the attacker.";
		if 			(Input.GetKeyDown (KeyCode.C)) 				{myState = States.attacker_1;}
	}
	void attacker_1 ()
	{
		text.text = "It is just you and the goalkeeper! Where will you kick it?!\n\n" +
					"L to use shoot left, Space to shoot straight, R to shoot right";
		if 			(Input.GetKeyDown(KeyCode.L))				{myState = States.goal_0;}
		else if 	(Input.GetKeyDown(KeyCode.Space))			{myState = States.goal_1;}
		else if 	(Input.GetKeyDown(KeyCode.R))				{myState = States.goal_2;}
	}
	void goal_0 ()
	{
		text.text = "GOOOOOOAAAAALL!! A lucky deflection off of the defender and under " +
					"the goalkeeper's legs!\n\n" +
					"Press the return key to play again.";
		if 			(Input.GetKeyDown(KeyCode.Return))			{myState = States.goalkeeper;}
}	
	void goal_1 ()
	{
		text.text = "GOOOOOOAAAAALL!! Right off the crossbar!\n\n" +
					"Press the return key to play again.";
		if 			(Input.GetKeyDown(KeyCode.Return))			{myState = States.goalkeeper;}
	}
	void goal_2 ()
	{
		text.text = "GOOOOOOAAAAALL!! Play of the game! You curved the ball right around " +
					"2 defenders, and well out of reach of the goalkeeper!\n\n" +
					"Press the return key to play again.";
		if 			(Input.GetKeyDown(KeyCode.Return))			{myState = States.goalkeeper;}
	}
	#endregion
}
