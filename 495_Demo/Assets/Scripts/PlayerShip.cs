/*Shoot to Live
 * Created by Thaddeus Thompson
 * Last Edited by Thaddeus Thompson
 * Modified 1/28/2017
 * */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour {

	private float health;
	private float speed;
	private float bullet_speed = 35f;

	public GameObject bullet_prefab;
	[HideInInspector] public int kills;
	static public PlayerShip S;
	private GameObject bullet;

	// Use this for initialization
	void Start () 
	{
		//makes PlayerShip a singleton to be used by other scripts and sets health value
		S = this;
		health = 5;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Get input from keyboard to move player ship forward
		if(transform.position.y < 10)
		{
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 
			{
				speed = 10;
				transform.Translate (Vector3.up * (Time.deltaTime * speed));
			} else 
			{
				speed = 0;
			}
		}
		//Get input from keyboard to move player ship backward
		if(transform.position.y > -9)
		{
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) 
			{
				speed = 10;
				transform.Translate (Vector3.down * (Time.deltaTime * speed));
			} else 
			{
				speed = 0;
			}
		}
		//Get input from keyboard to move player ship right
		if(transform.position.x < 18)
		{
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) 
			{
				speed = 10;
				transform.Translate (Vector3.right * (Time.deltaTime * speed));
			} else 
			{
				speed = 0;
			}
		}
		//Get input from keyboard to move player ship left
		if(transform.position.x > -18)
		{
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) 
			{
				speed = 10;
				transform.Translate (Vector3.left * (Time.deltaTime * speed));
			} else 
			{
				speed = 0;
			}
		}
		//Get input and start Fire function
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Fire ();
		}

		//moves the bullet along in a line and destroys it if it goes out of bounds
		if(bullet != null)
		{
		bullet.transform.Translate(Vector3.up * (Time.deltaTime * bullet_speed));
		if(bullet.transform.position.y > 15)
		{
			Destroy(bullet);
		}
		}

		//when health reaches 0 the scene reloads
		if(health <= 0)
		{
			SceneManager.LoadScene("Scene1");
		}
	}//End Update

	//detects for trigger collisions
	void OnTriggerEnter(Collider col)
	{
		//when the player collides with an enemy the player loses one health and the enemy is destroyed
		if(col.gameObject.tag == "Enemy")
		{
			health --;
			Destroy(col.gameObject);
		}
	}

	//Creates an instance of a bullet at the ships location
	void Fire()
	{
		//checks if bullet Gameobject is null and creates a new one if true
		if(bullet == null)
		{
		bullet = (GameObject)Instantiate(bullet_prefab, this.transform.position, transform.rotation);
		}
	}
}
