using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerVelocity;
	private Vector3 playerPosition;
	public float boundary;

	private int playerLives;
	private int playerPoints;

	// Use this for initialization
	void Start () {
		// get the initial position of the game object
		playerPosition = gameObject.transform.position;

		playerLives = 3;
		playerPoints = 0;

		//onGUI ();
	}
	
	// Update is called once per frame
	void Update () {
		// horizontal movement
		playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

		// leave the game
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		// update the game object transform
		transform.position = playerPosition;

		// boundaries
		if (playerPosition.x < -boundary) {
						transform.position = new Vector3 (-boundary, playerPosition.y, playerPosition.z);		
				} 
		if (playerPosition.x > boundary) {
			transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);		
		}

	}

	void addPoints(int points){
		playerPoints += points;
	}

	void OnGUI(){
		GUI.Label (new Rect(5.0f,3.0f,200.0f,200.0f),"Live's: " + playerLives + "  Score: " + playerPoints);
	}

	void TakeLife(){
		playerLives--;
	}
}
