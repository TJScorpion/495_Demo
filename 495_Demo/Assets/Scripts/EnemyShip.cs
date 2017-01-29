/*Shoot to Live
 * Created by Thaddeus Thompson
 * Last Edited by Thaddeus Thompson
 * Modified 1/28/2017
 * */

using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	private GameObject target;
	private float speed = 5f;

	// Update is called once per frame
	void FixedUpdate () 
	{
		//finds player ship and assigns it to target
		target = GameObject.Find("Ship");
		//Gets player position and constantly moves towards it
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, (Time.deltaTime * speed));
	}

	void OnTriggerEnter(Collider col)
	{
		//when the enemy collides with a bullet both are destroyed and kills increase by one
		if(col.gameObject.tag == "Bullet")
		{
			PlayerShip.S.kills++;
			Destroy(col.gameObject);
			Destroy(this.gameObject);
		}
	}
}
