using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

	[SerializeField]
	public GameObject bullet;

	public float dirX, moveSpeed = 3f;

	public bool isMovingForward;
	public bool isMovingBackward;
	public Vector2 LastPOS;
	public Vector2 NextPOS;
	public bool facingRight = true;

	bool moveUp = true;

	public Rigidbody2D rb;

	float fireRate;
	float nextFire;

	private Transform targets;
	// Use this for initialization
	void Start()
	{
		fireRate = 2f;
		nextFire = Time.time;

		targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		CheckIfTimeToFire();

		transform.position = Vector2.MoveTowards(transform.position, targets.position, moveSpeed * Time.deltaTime);

		/*if (transform.position.y > 1f)
			moveUp = false;
		if (transform.position.y < -1f)
			moveUp = true;

		if (moveUp)
			transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
		else
			transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);*/
	}
	void LateUpdate()
	{

		NextPOS.x = transform.position.x;



		if (LastPOS.x < NextPOS.x)
		{
			isMovingForward = true;
			isMovingBackward = false;
			FlipLeft();
		}
		if (LastPOS.x > NextPOS.x)
		{
			isMovingBackward = true;
			isMovingForward = false;
			FlipRight();
		}
		else if (LastPOS.x == NextPOS.x)
		{
			isMovingForward = false;
			isMovingBackward = false;
		}

		LastPOS.x = NextPOS.x;
	}
	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}

	}
	void FlipRight()
	{
		if (facingRight == true)
		{
			transform.Rotate(0f, 180f, 0f);
			facingRight = false;
		}
	}
	void FlipLeft()
	{
		if (facingRight == false)
		{
			transform.Rotate(0f, 180f, 0f);
			facingRight = true;
		}
	}

}
