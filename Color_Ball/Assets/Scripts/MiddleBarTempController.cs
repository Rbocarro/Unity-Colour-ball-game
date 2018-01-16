using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBarTempController : MonoBehaviour {
	

	public string[] colour={"Red","Green","Blue"};
	public string boxcol="";
	// Use this for initialization
	void Start () {
		
		if(boxcol=="")
		{
			boxcol = colour[Random.Range (0, colour.Length)];
		}
		if(boxcol=="Red")
		{
			gameObject.GetComponentInChildren<Renderer> ().material.color=Color.red;
			gameObject.tag = "Red";

		}
		if(boxcol=="Green")
		{
			gameObject.GetComponentInChildren<Renderer> ().material.color=Color.green;
			gameObject.tag = "Green";
		}
		if(boxcol=="Blue")
		{
			gameObject.GetComponentInChildren<Renderer> ().material.color=Color.blue;
			gameObject.tag = "Blue";
		}
		//Debug.Log ("I am the block. My name is:" + boxcol);

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, -1* Time.deltaTime, 0)) ;
	}


	/*void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag!="Bafsdfsdfdfll")
		{
			Debug.Log ("it works on my side");
		}
	}
	*/
}
