using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lonomode : MonoBehaviour
{
	GameObject hunter;
	//GameObject Lono;
	//metric to gauge Hunter's highness
	public static int high;

	//metric for player score
	public static int points;

	// Use this for initialization
	void Start ()
	{
		//anim = GetComponent<Animation> ();
		hunter = GameObject.Find ("hunter");
		//Lono = GameObject.Find ("Lono");
	}//start
	
	// Update is called once per frame
	void Update ()
	{	
		if (high >= 100) {
			//change Hunter's appearance to Lono
			// by switching through animations
			//attach both animations to Hunter
			//and turn on and off according to 
			//high level, also can be used for 
			//health to switch on and off alive
			//and dead/game over modes
			//hunter.
			//anim.CrossFade ("GodMode_Anim_test_Sprite_1");
		}//if
		//else {
			//anim.CrossFade ("sprite sheet hunter");
		//s}//else
	}//update

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.SetActive (false);
			points = points + 1;
		}//if
	}//OnTriggerEnter
}//lonomode
