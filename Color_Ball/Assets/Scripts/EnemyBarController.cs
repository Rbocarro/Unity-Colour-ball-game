using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarController : MonoBehaviour {


	public float speed=5.0f;
	public float timer;
	public float delayTimer=0.5f;



	//spawns the bars.and provies a postion reference point. only the middlebar for now
	public GameObject[] Bar;
	private GameObject SpawnedMiddleBar;
	// Use this for initialization
	void Start () {
		timer = delayTimer;

	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer<=0)
		{	
			SpawnedMiddleBar=Instantiate(Bar[Random.Range(0,Bar.Length)],transform.position,Quaternion.Euler(0,0,0)) as GameObject;


			timer = delayTimer;
		}
		//SpawnedMiddleBar.gameObject.transform.Translate(new Vector3 (0, -speed * Time.deltaTime, 0));
			
		

	}


}
