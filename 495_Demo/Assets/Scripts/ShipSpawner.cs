/*Shoot to Live
 * Created by Thaddeus Thompson
 * Last Edited by Thaddeus Thompson
 * Modified 1/28/2017
 * */

using UnityEngine;
using System.Collections;

public class ShipSpawner : MonoBehaviour {

	public GameObject enemy_prefab;
	private float timer = 5f;
	private float timer_reset = 5f;

	//Function that creates an enemy object when called
	void SpawnEnemy()
	{
		//creates gameobject from enemy_prefab and resets timer
		GameObject go;
		go = Instantiate(enemy_prefab, transform.position, transform.rotation) as GameObject;
		timer = timer_reset;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//decreases spawn timer if a certain kill value is met
		if(PlayerShip.S.kills > 10)
		{
			timer_reset = 3f;
		}

		if(PlayerShip.S.kills > 25)
		{
			timer_reset = 2f;
		}

		if(PlayerShip.S.kills > 50)
		{
			timer_reset = 1f;
		}

		//calls SpawnEnemy method if timer equals 0 else timer will countdown
		if(timer <= 0)
		{
			SpawnEnemy();
		}else
		{
			timer -= Time.deltaTime;	
		}
	}
}
