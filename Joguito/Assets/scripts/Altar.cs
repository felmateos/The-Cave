using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject altar;
    public bool certo = false;
    public bool ativeseq = true;
    void Start()
    {
        altar = GameObject.Find("Altar");
    }

    // Update is called once per frame
    void Update()
    {
        playerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        if (Input.GetKeyDown(KeyCode.E) && pc.inRange == true && certo)
        {
            Sequencia seq = GameObject.Find("Sequencia").GetComponent<Sequencia>();
            if (ativeseq)
            {
                seq.ativo = true;
                seq.startTime = Time.time;
                ativeseq = false;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            playerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
            pc.IBUTTON.GetComponent<Renderer>().enabled = true;
            pc.inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
            pc.IBUTTON.GetComponent<Renderer>().enabled = false;
            pc.inRange = false;
        }
    }
}
