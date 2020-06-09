using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed = 7f;
	public int damage = 40;
	public int hitCount;
	public Rigidbody2D rbb;
	public GameObject platform;
	public GameObject BulletPrefab;
	public GameObject impactEffect;
	playerController target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
		rbb.velocity = transform.right * speed;
		target = GameObject.FindObjectOfType<playerController>();
		moveDirection = (target.transform.position - transform.position).normalized * speed;
		rbb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 3f);
	}
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.gameObject.CompareTag("Impact") || !col.gameObject.CompareTag("Bullet"))
		{
			Instantiate(impactEffect, transform.position, transform.rotation);

			Destroy(gameObject);
		}
		if (col.gameObject.name.Equals("Player"))
		{
			hitCount++;
			Instantiate(impactEffect, transform.position, transform.rotation);
			Debug.Log("Hit " + hitCount);
			Destroy(gameObject);
		}
	}

}