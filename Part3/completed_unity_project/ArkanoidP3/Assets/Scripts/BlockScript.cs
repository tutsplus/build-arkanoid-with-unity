using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	public int hitsToKill;
	public int points;
	private int numberOfHits;

	// Use this for initialization
	void Start () {
		numberOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "Ball"){
			numberOfHits++;

			if (numberOfHits == hitsToKill){

				// get reference of player object
				GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

				// send message
				player.SendMessage("addPoints", points);

				// destroy the object
				Destroy(this.gameObject);
			}
		}
	}

}
