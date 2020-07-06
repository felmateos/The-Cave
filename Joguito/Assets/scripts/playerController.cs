using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rb;
    
    public bool facingRight = true;
    public bool isGrounded = true;
    public bool inRange = false;

    public int coinCount = 0;
    public int lifes = 3;
    // public GameObject l1;
    // public GameObject l2;
    // public GameObject l3;

    public HealthBar healthBar;
    public float maxHealth = 100;
    public float currentHealth;

    public GameObject bullet;
    public GameObject IBUTTON;
    private Animator anim;
    public float forcaPulo;
    public float velocidadeMaxima;
    public GameObject Player;
    public GameObject LastCheckpoint;
    public Animator animator;
    public int hitCount = 0;
    private BoxCollider2D boxCollider2d;
    [SerializeField] public LayerMask groundLayerMask;
    public string sceneName;


    void Start()
    {
              
        anim = gameObject.GetComponent<Animator>();
        print("eae jogo bosta");
        rb = GetComponent<Rigidbody2D>();
        //IBUTTON.GetComponent<Renderer>().enabled = false;
         boxCollider2d = transform.GetComponent<BoxCollider2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        anim.speed = 0.5f;

        //Movimentação lateral do personagem

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        float movimento = 0;
   

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            movimento = Input.GetAxis("Horizontal");
        }



        rigidbody.velocity = new Vector2(movimento * velocidadeMaxima, rigidbody.velocity.y);

        if (movimento > 0)
        {
            FlipLeft();
        }
        else if (movimento < 0)
        {
            FlipRight();
        }


       rigidbody.velocity = new Vector2(movimento*velocidadeMaxima, rigidbody.velocity.y);

       if(movimento > 0)
       {
           FlipLeft();
        } 
        else if (movimento < 0)
        {
          FlipRight();
        }
        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));

        //Movimentação vertical do personagem

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())      //move pra cima (pula)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.S) && isGrounded == false)         //move pra baixo quando estiver no ar
        {
            rb.velocity = new Vector2(rb.velocity.x, -10f);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.position = LastCheckpoint.transform.position;
        }

       
    }

    private void FixedUpdate()
    {
    
	}
    //MÉTODO DE ISGROUNDED COM RAYCAST
     
     bool IsGrounded()
    {
    float extraHeightText = 1f;
    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask);
    Color rayColor;
        if (raycastHit.collider != null) {    
            rayColor = Color.green;
	    } else {
            rayColor = Color.red;
	    }
    Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText));
    Debug.Log(raycastHit.collider);
    return raycastHit.collider != null;
	}
    

    // Pulo
    void Jump()                         
    {
        rb.AddForce(new Vector2(rb.velocity.x,forcaPulo));      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            transform.position = LastCheckpoint.transform.position;
            currentHealth = 6;
            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("Chest")      //quando bate em algo
            || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Plataforma") )
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            print("qtd de coins: " + coinCount);
        }
        if (collision.gameObject.CompareTag("Plataforma"))
           Player.transform.parent = collision.gameObject.transform;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("Chest")       //quando bate em algo
            || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Plataforma"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Plataforma"))
             Player.transform.parent = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Altar"))
        {
            Altar alt = GameObject.FindGameObjectWithTag("Altar").GetComponent<Altar>();
            alt.certo = true;
            
        }

        if (collision.gameObject.CompareTag("Botao"))
        {
            Botao bot = GameObject.FindGameObjectWithTag("Botao").GetComponent<Botao>();
            bot.certo = true;
            bot.botao = collision.gameObject;

        }

        if (collision.gameObject.CompareTag("Gate"))
        {
            Gate gat = GameObject.FindGameObjectWithTag("Gate").GetComponent<Gate>();
            gat.certo = true;
        }

        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Impact"))
        {
            TakeDamage(1);
        }

        //checkpoint

        if (collision.gameObject.CompareTag("Checkpoint"))         
        {
            cameraController cc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraController>();
            Debug.Log("Colidiu com checkpoint: "+ collision.gameObject.name);
            LastCheckpoint = collision.gameObject;
		}   

        //barreira invisível que mata

        if (collision.gameObject.CompareTag("Kill"))                
        {
            //transform.position = LastCheckpoint.transform.position;  
		}
        
        //controle de vidas (no momento está sendo ignorado)

        if (collision.gameObject.CompareTag("Impact") || collision.gameObject.CompareTag("Bullet"))
        {
            //lifes--;
            print("-1 de vida, vidas restantes: " + lifes);
            //if (lifes == 0)
            //{
            //    Destroy(gameObject);
            //}
            /*switch (lifes)
            {
                case 2:
                    Destroy(l3);
                    break;
                case 1:
                    Destroy(l2);
                    break;
                case 0:
                    Destroy(l1);
                    break;
                default:
                    print("");
                    break;
            }
            */
        //hitCount++;
        //print("Hit " + hitCount);
        }
        if (collision.gameObject.CompareTag("Plataforma") && isGrounded )
        {
         isGrounded = false;  
         Player.transform.parent = collision.gameObject.transform;
		}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Altar"))
        {
            Altar alt = GameObject.FindGameObjectWithTag("Altar").GetComponent<Altar>();
            alt.certo = false;

        }

        if (collision.gameObject.CompareTag("Botao"))
        {
            Botao bot = GameObject.FindGameObjectWithTag("Botao").GetComponent<Botao>();
            bot.certo = false;


        }

        if (collision.gameObject.CompareTag("Gate"))
        {
            Gate gat = GameObject.FindGameObjectWithTag("Gate").GetComponent<Gate>();
            gat.certo = false;
        }


        // Player.transform.parent = null;       //conferir se isso nao caga nada

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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            transform.position = LastCheckpoint.transform.position;
            currentHealth = 6;
            healthBar.SetHealth(currentHealth);
        }
    }
    /*public void PerdeVida() {
        lifes--;
        
        if (lifes == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName);

        }
        switch (lifes)
        {
            case 0:
                Destroy(l1);
                break;
            case 1:
                Destroy(l2);
                break;
            case 2:
                Destroy(l3);
                break;
            default:
                print("");
                break;
        }
    }*/

}  