using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveDown : MonoBehaviour {

	public float speed=5.0f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, -speed * Time.deltaTime, 0);
	}
}
