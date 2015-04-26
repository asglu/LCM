using UnityEngine;
using System.Collections;

public class lonomode : MonoBehaviour 
{
	GameObject hunter;
	//metric to gauge Hunter's highness
	public static int high = 100;

	//metric for player score
	public static int points;

	// Use this for initialization
	void Start () 
	{
		hunter = GameObject.Find ("hunter");
	}//start
	
	// Update is called once per frame
	void Update () 
	{	
		//high decrements everyframe
		high = high - 5;

		if (high == 100)
		{
			//change Hunter's appearance to Lono
			// by switching through animations
			//attach both animations to Hunter
			//and turn on and off according to 
			//high level, also can be used for 
			//health to switch on and off alive
			//and dead/game over modes
			//hunter.
			//

		}//if
	}//update

	void morph()
	{
		//hunter.
	}//morph

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("runner"))
		{
			other.gameObject.SetActive(false);
			points = points + 1;
		}//if
	}//OnTriggerEnter
}//lonomode
