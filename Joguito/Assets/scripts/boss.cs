using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

	[SerializeField]
	GameObject bullet;

	float dirX, moveSpeed = 3f;
	bool moveUp = true;

	float fireRate;
	float nextFire;

	// Use this for initialization
	void Start()
	{
		fireRate = 2f;
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		CheckIfTimeToFire();

		if (transform.position.y > 1f)
			moveUp = false;
		if (transform.position.y < -1f)
			moveUp = true;

		if (moveUp)
			transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
		else
			transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}

	}

}
