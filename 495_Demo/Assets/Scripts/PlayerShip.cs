using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	public float health;
	private float speed;

	public GameObject bullet_Prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Get input from keyboard to move player ship forward
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 
		{
			speed = 10;
			transform.Translate (Vector3.up * (Time.deltaTime * speed));
		} else 
		{
			speed = 0;
		}

		//Get input from keyboard to move player ship backward
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) 
		{
			speed = 10;
			transform.Translate (Vector3.down * (Time.deltaTime * speed));
		} else 
		{
			speed = 0;
		}

		//Get input from keyboard to move player ship right
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
		{
			speed = 10;
			transform.Translate (Vector3.right * (Time.deltaTime * speed));
		} else 
		{
			speed = 0;
		}

		//Get input from keyboard to move player ship left
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
		{
			speed = 10;
			transform.Translate (Vector3.left * (Time.deltaTime * speed));
		} else 
		{
			speed = 0;
		}
		//Get input and start Fire method
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Fire ();
		}
	}//End Update

	//Creates an instance of a bullet at the ships location
	void Fire()
	{
		GameObject go;
		go = (GameObject)Instantiate(bullet_Prefab, this.transform.position, transform.rotation);
	}
}
