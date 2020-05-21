using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed = 7f;
	public int damage = 40;
	public Rigidbody2D rbb;
	public GameObject platform;
	public GameObject BulletPrefab;
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
	void OnTriggerEnter2D(Collider2D hitInfo)
	{

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}

}