using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
	public GameObject keyPoof;
	public GameObject door;

    //Create a variable to store whether or not the key has been collected or not
	private bool keyCollected = false;

	void Update()
	{
		//Not required, but for fun why not try adding a Key Animation here :)

		// Sure, why not =)
		// (inspired by the coconut)
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + (Mathf.Sin (Time.time * 5.0f) / 50f), this.transform.position.z);
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
		// Make sure the poof animates vertically
		Instantiate(keyPoof, this.transform.position, this.transform.rotation);

        // Call the Unlock() method on the Door
		this.door.GetComponent<Door>().Unlock();

        // Set the Key Collected Variable to true
		this.keyCollected = true;

        // Destroy the key. Check the Unity documentation on how to use Destroy
		Destroy(this.gameObject);
    }

}
