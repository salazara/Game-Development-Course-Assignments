using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	public int lives = 5;
	public int bricks = 24;
	public int threat = 0;

	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;

	bool gameover = false;
	bool win = false;

    //public GameObject BGM;
	
	// Use this for initialization
	void Awake () 
	{
        gameObject.GetComponent<AudioSource>().enabled = true;
        GetComponent<AudioSource>().Play();
        //AudioSource.PlayClipAtPoint(GetComponent<AudioSource>(), transform.position);
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		Setup();
		
	}
	
	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}

	public void CheckWin()
	{
		if (threat < 1 && gameover == false) {
			win = true;
			youWon.SetActive (true);
            GetComponent<AudioSource>().Stop();
            youWon.GetComponent<AudioSource>().Play();
			Time.timeScale = .25f;
			Invoke("Reset", 1f);
		}
	}

	public void CheckGameOver(){
		if (lives < 1 && win == false) {
			gameover = true;
			gameOver.SetActive (true);
			GetComponent<AudioSource> ().Stop ();
			gameOver.GetComponent<AudioSource> ().Play ();
			Time.timeScale = .25f;
			Invoke ("Reset", 1f);
		}
		
	}
	
	void Reset()
	{
		win = false;
		gameover = false;
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void LoseLife()
	{
		if (clonePaddle != null) {
			lives--;
			livesText.text = " LIVES : ";

			for (int i = 0; i < lives; i++)
				livesText.text += "*";

			livesText.GetComponent<AudioSource> ().Play ();
			Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
			Destroy (clonePaddle);
			Invoke ("SetupPaddle", 1f);
			CheckGameOver ();
		}
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyThreat(){
		threat--;
		CheckWin();
	}
}