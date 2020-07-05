using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

	[SerializeField]
	public GameObject bullet;
	public Transform FirePoint;
	public int hitCount = 0;
	public float dirX, moveSpeed = 3f;

	public bool isMovingForward;
	public bool isMovingBackward;
	public Vector2 LastPOS;
	public Vector2 NextPOS;
	public bool facingRight = true;

	public HealthBar healthBar;
	public int maxHealth = 100;
	public int currentHealth;

	public GameObject Pillar;
	public int regen = 1;

	bool moveUp = true;

	public Rigidbody2D rb;

	float fireRate;
	float nextFire;

	float DmgRate;
	float nextDmg;


	private Transform targets;
	// Use this for initialization
	void Start()
	{
		fireRate = 2f;
		nextFire = Time.time;

		DmgRate = 2f;
		nextDmg = Time.time;

		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

		targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update()
	{
		CheckIfTimeToFire();

		healthBar.SetHealth(currentHealth);

		if (currentHealth < 1)
		{
			Destroy(gameObject);
		}
		if (Pillar == null)
		{
			regen = 0;
		}

		transform.position = Vector2.MoveTowards(transform.position, targets.position, moveSpeed * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Space))
		{
		}

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
	void TakeDamage(int damage)
	{
		currentHealth -= damage;

	}
	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Shoot();
			regenaration();
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
	void regenaration()
	{
		currentHealth += regen;
	}
	void Shoot()
	{
		Instantiate(bullet, FirePoint.position, FirePoint.rotation);
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Impact") && Time.time > nextDmg)
		{
			TakeDamage(20);
			nextDmg = Time.time + fireRate;
		}
	}
}
