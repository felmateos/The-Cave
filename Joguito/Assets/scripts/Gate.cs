using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public bool certo = false;
    Sequencia seq;
    playerController pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        seq = GameObject.Find("Sequencia").GetComponent<Sequencia>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.E) && pc.inRange && seq.acertou )
        {
            SceneManager.LoadScene("Fase3");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && seq.acertou)
        {
            pc.IBUTTON.GetComponent<Renderer>().enabled = true;
            pc.inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            pc.IBUTTON.GetComponent<Renderer>().enabled = false;
            pc.inRange = false;
        }
    }
}
