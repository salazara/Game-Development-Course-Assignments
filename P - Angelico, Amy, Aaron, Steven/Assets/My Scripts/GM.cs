using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	GameObject player;
	Player pscript;

	public GameObject gameOver;
	public GameObject youWon;
	public GameObject hyah;

	bool gameover;
	bool win;

	public bool bossDefeated;

	public static GM instance = null;

	public GameObject Merchant;

	bool gotriggered;

	void Awake(){

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		player = GameObject.FindWithTag ("Player");
		pscript = player.GetComponent<Player> ();

		gotriggered = false;
		bossDefeated = false;
		gameover = false;
		win = false;
	}
	

	void Update(){
		CheckGameOver ();
		CheckWin ();
	}

	void CheckGameOver(){
		if ((pscript.currentHealth <= 0 || pscript.memories <= 0) && win == false && gotriggered == false) {
			gotriggered = true;
			GameOver ();
		}
	}

	public void GameOver(){
		gameover = true;
		gameOver.SetActive (true);
		hyah.SetActive (true);
		Instantiate(Merchant, player.transform.position + player.transform.forward -  (1.5f * player.transform.up), Quaternion.identity);
		Time.timeScale = .25f;
		Invoke ("Reset", 1f);
	}

	void CheckWin()
	{
		if (bossDefeated == true && gameover == false) {
			Win ();
		}
	}


	void Win(){
		win = true;
		youWon.SetActive (true);
		Time.timeScale = .25f;
		Invoke("Reset", 1f);
	}

	void Reset()
	{
		win = false;
		gameover = false;
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	void TriggerWin(){
		Debug.Log ("YOU WIN");
	}
}