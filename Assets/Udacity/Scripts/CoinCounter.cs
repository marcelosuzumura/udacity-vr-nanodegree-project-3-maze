using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour {

	private int totalCoins;
	private int collectedCoins = 0;

	// Use this for initialization
	void Start () {
		this.totalCoins = GameObject.Find ("Coins").transform.childCount;
		Debug.Log ("Total coins: " + this.totalCoins);
	}
	
	public void IncrementCoinCollected () {
		this.collectedCoins += 1;
		Debug.Log ("Collected coins: " + this.collectedCoins);
		GameObject.Find ("SignPost").GetComponent<SignPost> ().UpdateCoinCollected ();
	}

	public int GetTotalCoinCount() {
		return this.totalCoins;
	}

	public int GetCollectedCoinCount() {
		return this.collectedCoins;
	}

}
