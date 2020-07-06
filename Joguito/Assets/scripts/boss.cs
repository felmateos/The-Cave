using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public float maxHealth = 100;
	public float currentHealth;

	public RegenBar regenBar;
	public float maxRegen = 4;
	public float currentRegen;

	public GameObject Pillar1;
	public GameObject Pillar2;
	public GameObject Pillar3;
	public GameObject Pillar4;
	public int PillarCount = 4;
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

		currentRegen = maxRegen;
		regenBar.SetMaxRegen(maxRegen);
	}

	//public void ChangeS()
   //{
   //    SceneManager.LoadScene("Vitoria");
   //}

	// Update is called once per frame
	void Update()
	{
		CheckIfTimeToFire();

		healthBar.SetHealth(currentHealth);
		currentRegen = regenBar.GetRegen();

		if (currentHealth < 1)
		{
			Destroy(gameObject);
			SceneManager.LoadScene("Vitoria");
		}
		//if (Pillar1 == null) PillarCount--;
		//if (Pillar2 == null) PillarCount--;
		//if (Pillar3 == null) PillarCount--;
		//if (Pillar4 == null) PillarCount--;

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
		if (currentHealth < 100) currentHealth += (regen * currentRegen);
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
