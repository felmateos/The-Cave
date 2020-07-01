using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public string dialg;
    public GameObject bau;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        
        if (Input.GetKeyDown(KeyCode.E) && pc.inRange == true)
        {
            dialg = bau.GetComponent<chest>().dialg;
            Interacion();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Player"))
        {
            bau = this.gameObject;
            playerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
            pc.IBUTTON.GetComponent<Renderer>().enabled = true;
            pc.inRange = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Player"))
        {
            bau = null;
            playerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
            pc.IBUTTON.GetComponent<Renderer>().enabled = false;
            pc.inRange = false;
        }
    }

    public void Interacion()
    {
       
        DialogBox dial = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogBox>();
       
        dial.Dialog(dialg);
    }
}
