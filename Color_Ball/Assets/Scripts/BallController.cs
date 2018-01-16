using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public string CircleColour="";
	public string[] colourList={"Red","Green","Blue"};
	public string[] ballPositions={"Left","Mid","Right"};
	public string currentBallPosition="";
	Vector3 leftPosition;//the left position to be sisgned by the leftposition game object
	Vector3 rightPosition;// the right position to be assigned by the right position game object
	Vector3 centerPosition;
	Vector3 startPos;//start position of the touch
	Vector3 endPos;//end position of the touch
	Vector2 distance;//actually menat to be part of the swie() function
	public GameObject leftPositionIndicator;
	public GameObject rightpositionIndicator;
	public float maxTime;
	public float minSwipeDistance;
	float swipeDistance;
	float startTime;
	float endTime;
	float swipeTime;
	Color32 red=new Color32(237,28,36,255);
	Color32 green=new Color32(0,146,69,255);
	Color32 blue=new Color32(0,113,188,255);




	// Use this for initialization
	void Start () 
	{	
		
		currentBallPosition = "Center";//set ball position to middle
		leftPosition=leftPositionIndicator.transform.position;
		rightPosition = rightpositionIndicator.transform.position;
		centerPosition = transform.position;
	
		if(CircleColour=="")
		{
			CircleColour = colourList[Random.Range (0, colourList.Length)];

		}
			
		if(CircleColour=="Green")
		{
			gameObject.GetComponent<Renderer> ().material.color=green;
			gameObject.tag = CircleColour;
		}
		if(CircleColour=="Red")
		{
			gameObject.GetComponent<Renderer> ().material.color=red;
			gameObject.tag = CircleColour;
		}
		if(CircleColour=="Blue")
		{
			gameObject.GetComponent<Renderer> ().material.color=blue;
			gameObject.tag = CircleColour;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.touchCount>0)
		{	
			Touch userTouch = Input.GetTouch (0);
			if(userTouch.phase==TouchPhase.Began)
			{					
				startTime = Time.time;
				startPos = userTouch.position;
			}
			else if(userTouch.phase==TouchPhase.Ended)
			{
				endTime = Time.time;
				endPos = userTouch.position;
				swipeDistance = (endPos - startPos).magnitude;
				swipeTime = endTime - startTime;
				if(swipeTime<maxTime&&swipeDistance>minSwipeDistance)
				{	
					distance = endPos - startPos;
					if(Mathf.Abs(distance.x)>Mathf.Abs(distance.y))
					{
						if(distance.x>0)
						{
							//RIGHT SWIPE

							if(currentBallPosition=="Center")
							{
								transform.position = Vector3.Lerp (centerPosition,rightPosition,100*Time.deltaTime);
								currentBallPosition="Right";
							}
							else if(currentBallPosition=="Right")
							{
								currentBallPosition="Right";
							}
							else if(currentBallPosition=="Left")
							{	
								transform.position = Vector3.Lerp (leftPosition,centerPosition,100*Time.deltaTime);
								currentBallPosition="Center";
							}
						}
						else if(distance.x<0)
						{
							//LEFT SWIPE
							if(currentBallPosition=="Center")
							{
								transform.position = Vector3.Lerp (centerPosition,leftPosition,100*Time.deltaTime);
								currentBallPosition="Left";
							}
							else if(currentBallPosition=="Left")
							{
								currentBallPosition="Left";
							}
							else if(currentBallPosition=="Right")
							{	
								transform.position = Vector3.Lerp (rightPosition,centerPosition,100*Time.deltaTime);
								currentBallPosition="Center";
							}
						}
					}

				}
				else
				{
					if(swipeDistance<=minSwipeDistance)
					{
						ChangeColour ();
					}

				}
			}
		}
	}

public void ChangeColour()
	{

		if(CircleColour=="Red")
		{	
			//gameObject.GetComponent<Renderer> ().material.color=Color.green;
			gameObject.GetComponent<Renderer> ().material.color=green;
			CircleColour="Green";
			gameObject.tag = CircleColour;
		}
		else
		if(CircleColour=="Green")
		{
			//gameObject.GetComponent<Renderer> ().material.color=Color.blue;
			gameObject.GetComponent<Renderer> ().material.color=blue;
			CircleColour="Blue";
			gameObject.tag = CircleColour;
		}
		else
		if(CircleColour=="Blue")
		{
			//gameObject.GetComponent<Renderer> ().material.color=Color.red;
			gameObject.GetComponent<Renderer> ().material.color=red;
			CircleColour="Red";
			gameObject.tag = CircleColour;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		
		if (col.gameObject.tag !=gameObject.tag )
		{	
			Debug.Log ("Ayy lmao");
		}
	}
}
