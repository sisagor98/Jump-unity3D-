using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public static Player p{ set; get; }

	private CharacterController controller;
	private float verticalVelocity;
	private float gravity = 30.0f;
	public float speed = 5.0f;
	private float jumpForced = 10.0f;
	private bool secondJumpAvail = false;
	private float inputDirection;
	private Vector3 moveVector;
	private Vector3 lastMotion;
	public GameObject sound;


	public void Start () {
		controller = GetComponent<CharacterController> (); 
	}

	void Update () {
		moveVector = Vector3.zero;
		inputDirection = Input.GetAxis ("Horizontal") * speed;
	
		if (isCharacterGrounded()) 
		{
			verticalVelocity = 0;

			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				verticalVelocity = jumpForced;
				secondJumpAvail = true;
			}
			moveVector.x = inputDirection;
		} 
		else
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				if (secondJumpAvail) 
				{
					verticalVelocity = jumpForced;
					secondJumpAvail = false;
				}
			}
			moveVector.x = lastMotion.x;
			verticalVelocity -= gravity*Time.deltaTime; 
		}
		moveVector.y = verticalVelocity;
		//moveVector = new Vector3 (inputDirection, verticalVelocity, 0);
		controller.Move (moveVector*Time.deltaTime);
		lastMotion = moveVector;
	}

	private bool isCharacterGrounded()
	{
		Vector3 leftStart;
		Vector3 rightStart;
		leftStart = controller.bounds.center;
		rightStart = controller.bounds.center;
		leftStart.x -= controller.bounds.extents.x;
		rightStart.x += controller.bounds.extents.x;
		Debug.DrawRay (leftStart, Vector3.down, Color.red);

		if (Physics.Raycast (leftStart, Vector3.down, (controller.height / 2) + 0.1f))
			return true;
		if (Physics.Raycast (rightStart, Vector3.down, (controller.height / 2) + 0.1f))
			return true;
		return false;
	}
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (controller.collisionFlags == CollisionFlags.Sides) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				moveVector = hit.normal * speed;
				verticalVelocity = jumpForced;
				secondJumpAvail = true;
			}
		}
		switch (hit.gameObject.tag) 
		{
		case "Coin":
			LevelManager.Instance.collector ();
			sound.SetActive (true);
			Destroy (hit.gameObject);
			break;
		case "Jump Pad":
			verticalVelocity = jumpForced * 2.5f;
			break;
		case "Teleport":
			transform.position = hit.transform.GetChild (0).position;
			break;
		case "win":
			LevelManager.Instance.Win ();
			break;
		default:
			sound.SetActive (false);
			break;
		}
	}
}
