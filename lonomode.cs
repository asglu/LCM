using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lonomode : MonoBehaviour
{	
	public Animator anim;
	public static float high;

	void start ()
	{
		anim = GetComponent<Animator> ();
	}//start

	void Update ()
	{
		if (high <= 10){
			anim.SetBool("sober", true);
		}//
		if (high >= 10){
			anim.SetBool("buzzed", true);
		}//
		if (high >= 20){
			anim.SetBool("high", true);
		}//
		if (high >= 30){
			anim.SetBool("faded", true);
		}//
		if (high >= 40){
			anim.SetBool("lono", true);
		}//
		}//if
	}//update
