using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float speed = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(Vector3.up * (Time.deltaTime*speed));
	}
}
