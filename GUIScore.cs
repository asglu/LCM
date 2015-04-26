using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScore : MonoBehaviour {
	Text txt;
	public static int high;

	void Start () 
	{
		txt = gameObject.GetComponent<Text>(); 
		txt.text = "" + high;
	}//Start
		
	// Update is called once per frame
	void Update () 
	{
		txt.text = " "+high;
	}//Update
}//GUIScore
