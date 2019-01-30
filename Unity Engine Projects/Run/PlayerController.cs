using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script will control all of the functions attached to the player character
public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier; //We want to add a feature that will ioncrease the movement speed of the player as they reach certain milestones in the game
	//In order to do this we are going to create an if statement that will constantly create milestones and change speed accordingly. 

	public float speedIncreaseMilestone; //This is going to be used to decide when to increase the speed of the player
	private float speedIncreaseMilestoneStore; 

	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;

	public float jumpTime; //This is used to allow the jump button to be help and achieve longer jumps
	private float jumpTimeCounter;

	private bool stoppedJumping; //This is used to prevent a player from falling off the side of a cliff and still be able to jump
	private bool canDoubleJump;

	private Rigidbody2D myRigidbody;

	//One issue created after adding the jump feature is that the player was able to jump infinetely. 
	//To remedy this, we will add a bool (true/false) statement that will only let the player jump if in contact with the ground - tracked with the public bool: grounded.
	public bool grounded;

	//By assigning the tag Ground and assigning it to What is Ground, we are able to tell the game what the ground is.
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	//private Collider2D myCollider;

	private Animator myAnimator; //So despite creating animations for the player, we still have to assign them to interact with them properly.

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> (); //This code will tell the game to look for the component of Rigidbody2D (Attached to the player) and allows it to be interacted with.	

		//myCollider = GetComponent<Collider2D> (); //Again, this will search the game for a 2D Collider on the player, we can use this to see when the player is on the ground.

		myAnimator = GetComponent<Animator> (); //Used to find the Animator function assigned earlier.

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone; //This will prevent the first speed milestone from being at 0

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

		//This next line of code will check if the myCollider layer on the player is touching any layer with the ground tag.
		//If this statement is found to be true, it will activate the grounded bool statement from earlier, and make the player able to jump until the statement is found to be false again.
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		//This is our if loop for the milestone/movespeed multiplier.
		if (transform.position.x > speedMilestoneCount) 
		{
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; //This line multiplies the milestone by the speed multiplier, making the multiplier move further back every time
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);  

		//Because this is a 2D scroller, we use Vector2 to apply the velocity on only 2 planes(x and y). By adding myRigidbody.velocity.y, we are telling the game to keep the default value of y. 
		//While moveSpeed will assign a float value (whole number) to the x axis of the player.
		//Next we add an "if" statement. These statements will check if something is true or not and execute a command based on the answer found.
		//Here I am assigning keypresses to the jump value, meaning any of these keypresses will activate the if statement.
		//We can tell the game to use one OR multiple values by using the ||.

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetMouseButtonDown (0)) 
		{
			if (grounded) //This small line of code will make it so the jump feature will only work if grounded is found to be true IE: on the ground
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				//The above line of code will keep the x value consistent while applying the jumpForce public float we created earlier.
				stoppedJumping = false;
				jumpSound.Play ();
			}
			if (!grounded && canDoubleJump) 
			{ //The following code will allow the player to both doulbe jump and still get the extended jump afterwards.
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play ();
			}
		}

		if ((Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.UpArrow) || Input.GetMouseButton (0)) && !stoppedJumping)
		{
			if(jumpTimeCounter > 0) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp (KeyCode.UpArrow) || Input.GetMouseButtonUp (0)) 
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) 
		{
			jumpTimeCounter = jumpTime;
			canDoubleJump = true; //This will tell theg ame that the player can double jump while groundfed
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		//This code will allow the speed of the player on the x plane to be used as a variable in the animator tool.
		myAnimator.SetBool ("Grounded", grounded);
		//This code will allow the grounded value to be used as a variable in the animator tool.
		

	}

	void OnCollisionEnter2D (Collision2D other) //When one object with collision touches another with collision this will execute a command
	{
		if (other.gameObject.tag == "killbox") //This will check if the player touches an object tagged as a "killbox"
		{ //In these brackets we want the game to call the restart code that we made earlier, but in order for this script to understand what we are looking for we need to add the game manager it in the top
			theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
		}
	}
}
