using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	public AudioClip lockedSound;
	public AudioClip unlockedSound;

	// Create a boolean value called "locked" that can be checked in Update() 
	private bool locked = true;
	private bool animateOpening = false;

	// For the door opening animation
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	private Vector3 closedPosition;
	private Vector3 openPosition;

	void Start() {
		this.closedPosition = this.transform.position;
		this.openPosition = new Vector3 (this.transform.position.x, this.transform.position.y + 7f, this.transform.position.z);

		this.journeyLength = Vector3.Distance(this.closedPosition, this.openPosition);
	}

    void Update() {
        // If the door is unlocked and it is not fully raised
            // Animate the door raising up

		// I made some changes to the proposed solution, to make the player click on the door to open it (after getting the key).
		// I think it's more interesting if the player interacts with the door and sees it opening in front of him
		// instead of opening the door as soon as the key is collected (the key is far from the door and the player
		// may not see the door opening).
		if (!this.locked && this.animateOpening) {
			float distCovered = (Time.time - this.startTime) * this.speed;
			float fracJourney = distCovered / this.journeyLength;
			this.transform.position = Vector3.Lerp(this.closedPosition, this.openPosition, fracJourney);
		}
    }

    public void Unlock() {
        // You'll need to set "locked" to false here
		this.locked = false;
    }

	public void OnClick() {
		AudioSource audioSource = this.GetComponent<AudioSource> ();
		if (!this.locked) {
			audioSource.PlayOneShot (unlockedSound);

			this.animateOpening = true;
			this.GetComponent<BoxCollider> ().enabled = false;
			this.startTime = Time.time;
		} else {
			audioSource.PlayOneShot (lockedSound);
		}
	}

}
