using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab
	public GameObject coinPoof;

    public void OnCoinClicked() {
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically

		// I rotated the coin so I had to rotate the coinPoof as well
		Instantiate(coinPoof, this.transform.position, this.transform.rotation * Quaternion.Euler(-90, 0, 0));

        // Destroy this coin. Check the Unity documentation on how to use Destroy
		Destroy(this.gameObject);

		// Keep collected coins count
		GameObject.Find ("Coins").GetComponent<CoinCounter> ().IncrementCoinCollected ();
    }

}
