using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{

	private CoinCounter coinCounter;

	void Start() {
		this.coinCounter = GameObject.Find ("Coins").GetComponent<CoinCounter> ();
		this.UpdateCoinCollected ();
	}

	public void UpdateCoinCollected() {
		Text signText = this.GetComponent<Text> ();
		signText.text = "YOU WIN\n" + this.coinCounter.GetCollectedCoinCount () + "/" + this.coinCounter.GetTotalCoinCount () + " coins";
	}

	public void ResetScene() 
	{
        // Reset the scene when the user clicks the sign post
		SceneManager.LoadScene("Maze");
	}
}