using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{

	public float speed = 12f;
	public int damage = 20;
	public Rigidbody2D rbb;
	public GameObject impactEffect;


	// Use this for initialization
	void Start()
	{
		rbb.velocity = transform.right * speed;

	}
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Impact") || !collision.gameObject.CompareTag("FireBall"))
		{
			Instantiate(impactEffect, transform.position, transform.rotation);

			Destroy(gameObject);
		}
	}

}