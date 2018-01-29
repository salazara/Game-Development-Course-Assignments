using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {
	
	enum Weapon{Dagger, Rod, Sword, Bow};

	public int startingHealth = 100;

	public int memories = 100;
	
	public int hpPots = 0;	

	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public Text memText, durText;

	bool damaged;
	bool isDead;

	GameObject GODagger;
	GameObject GORod;
	GameObject GOSword;
	GameObject GOBow;
	GameObject crosshair;

	public AudioClip shootSound1, shootSound2;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	//GameObject currWeapon;

	public int minDmg = 1;
	public int maxDmg = 15;

	public int rodDur = 100;
	public int swordDur = 100;
	public int bowDur = 100;

	//bool playerHit = false;

	float attRange;

	void Awake(){

		source = GetComponent<AudioSource>();
		currentHealth = startingHealth;

		GODagger = GameObject.Find("Dagger");
		GORod = GameObject.Find ("Rod");
		GOSword = GameObject.Find ("Sword");
		GOBow = GameObject.Find ("Bow");
		crosshair = GameObject.Find ("Cross Hair");

		WieldWeapon (Weapon.Dagger);
	
	}

	void Update () {

		PlayerHUD ();
		CheckDurability ();
		CheckBuy ();
		WeaponSwitch ();
		PrepareAttack ();

		if(Input.GetKeyDown (KeyCode.H)){
			hpPots--;
			currentHealth += 10;
			healthSlider.value = currentHealth;
		}

		if(Input.GetButtonDown ("Fire1")){

			GOSword.GetComponent<Animator>().Play("SwordSwing", -1, 0f);
			GORod.GetComponent<Animator>().Play("RodSwing", -1, 0f);
			GODagger.GetComponent<Animator>().Play("DaggerSwing", -1, 0f);

			float vol = Random.Range (volLowRange, volHighRange);

			if (GOBow.GetComponent<Renderer>().enabled){
				bowDur -=5;
				source.PlayOneShot(shootSound1,vol);
			}
			else
				source.PlayOneShot(shootSound2,vol);

		}

	}

	void WeaponSwitch(){
	
		if (Input.GetKeyDown ("1")) { 
			Debug.Log ("1 Pressed");
			WieldWeapon (Weapon.Dagger);
		} else if (Input.GetKeyDown ("2")) { 
			Debug.Log ("2 Pressed");
			WieldWeapon (Weapon.Rod);
		} else if (Input.GetKeyDown ("3")) {
			Debug.Log ("3 Pressed");
			WieldWeapon(Weapon.Sword);
		} else if (Input.GetKeyDown ("4")) {
			Debug.Log ("4 Pressed");
			WieldWeapon(Weapon.Bow);
		}

	}

	void WieldWeapon(Weapon weapon){

		GODagger.GetComponent<Renderer>().enabled = false;
		GORod.GetComponent<Renderer>().enabled = false;
		GOSword.GetComponent<Renderer>().enabled = false;
		GOBow.GetComponent<Renderer>().enabled = false;

		if(weapon == Weapon.Rod && rodDur > 0){
			Debug.Log ("Rod Selected");
			attRange = 4.5f;
			GORod.GetComponent<Renderer>().enabled = true;
		} else if(weapon == Weapon.Sword && swordDur > 0){
			Debug.Log ("Sword Selected");
			attRange = 4.5f;
			GOSword.GetComponent<Renderer>().enabled = true;
		} else if(weapon == Weapon.Bow && bowDur > 0){
			Debug.Log ("Bow Selected");
			attRange = 40f;
			GOBow.GetComponent<Renderer>().enabled = true;
		} else{
			Debug.Log ("Dagger Selected");
			attRange = 3f;
			GODagger.GetComponent<Renderer>().enabled = true;
		}
	}

	void PrepareAttack(){
	
		RaycastHit hit;

		if (Physics.Raycast (crosshair.transform.position, crosshair.transform.forward, out hit, attRange)) {
			GameObject target = hit.collider.gameObject;

			if(target.tag == "Enemy"){

				//Debug.Log (target.name + " is targeted");

				if(Input.GetButtonDown ("Fire1")){

					if (GORod.GetComponent<Renderer>().enabled)
						rodDur -= 5;
					else if (GOSword.GetComponent<Renderer>().enabled)
						swordDur -= 5;

					if(GODagger.GetComponent<Renderer>().enabled)
						target.SendMessage ("Hit", 1);
					else
						target.SendMessage ("Hit", 3);
					
				}

			}
		
		}
	
	}
	

	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "Enemy") {
			GetComponent<Rigidbody> ().velocity = other.gameObject.transform.forward * 15f;
			Debug.Log (other.gameObject.name + " in contact with Player");
			damaged = true;
			currentHealth -= 10;
			healthSlider.value = currentHealth;
			/*if(currentHealth <= 0 && !isDead){
				Death (); // Not implemented yet, called when you die
			}*/
		} else if (other.gameObject.tag == "Teleport") {
			Debug.Log (transform.position);
			if (memories > 300){
				transform.position = new Vector3(100f,100f,-200f);
			}
			else{
				if (other.gameObject.name == "Teleporter 1"){
					transform.position = new Vector3(0f,100f,200f);
				}
				else if (other.gameObject.name == "Teleporter 2"){
					transform.position = new Vector3(0f,0f,0f);
				}
			}
			Debug.Log (other.gameObject.name + " teleports Player!");

		} /*else if(other.gameObject.tag == "Non-Enemy"){
			Debug.Log ("Player touching " + other.gameObject.name);
		}*/
		
	}

	void PlayerHUD(){
		//Set text field UI
		memText.text = "Memories: " + memories;
		durText.text = "Weapon Durabilities\nDagger : N / A  \nRod : "+rodDur+" % (Press Z to Repair)\nSword : "+swordDur+" % (Press X to Repair)\nBow: "+bowDur+" % (Press C to Repair)";
		durText.text += "\n\nHP POTIONS : " + hpPots + "\n(Press H to Use)\n(Press B to Buy)"; 

		//Flash screen red if damaged
		if(damaged)
			damageImage.color = flashColour;
		else
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		
		damaged = false;
	
	}

	void CheckDurability(){
		//Check if current weapon is empty, if so then switch to dagger
		if (GOSword.GetComponent<Renderer>().enabled == true && swordDur <= 0)
			WieldWeapon (Weapon.Dagger);
		else if (GORod.GetComponent<Renderer>().enabled == true && rodDur <= 0)
			WieldWeapon (Weapon.Dagger);
		else if (GOBow.GetComponent<Renderer>().enabled == true && bowDur <= 0)
			WieldWeapon (Weapon.Dagger);
	}

	void CheckBuy(){
		if(Input.GetKeyDown (KeyCode.Z) && rodDur < 100){
			memories -= 100;
			rodDur = 100;
			Debug.Log ("Repaired Rod");
		}
		if(Input.GetKeyDown (KeyCode.X) && swordDur < 100){
			memories -= 100;
			swordDur = 100;
			Debug.Log ("Repaired Sword");
		}
		if(Input.GetKeyDown (KeyCode.C) && bowDur < 100){
			memories -= 100;
			bowDur = 100;
			Debug.Log ("Repaired Bow");
		}
		if(Input.GetKeyDown (KeyCode.B)){
			memories -= 50;
			hpPots++;
			Debug.Log ("Bought HP Potion");
		}
	}

}
