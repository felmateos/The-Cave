using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public bool certo = false;
    public GameObject botao;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        Sequencia seq = GameObject.Find("Sequencia").GetComponent<Sequencia>();
        if (Input.GetKeyDown(KeyCode.E) && pc.inRange == true && this.certo && seq.endSeq)
        {
            seq.guessStart = true;
            seq.erro = false;
            Confere(seq);
            if (seq.k<4)
            {
                seq.Verifica();
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
    void Confere(Sequencia seq)
    {

        if (botao.name == "Botao1")
        {
            seq.clickedButton = 0;
        }
        else if (botao.name == "Botao2")
        {
            seq.clickedButton = 1;
        }
        else if (botao.name == "Botao3")
        {
            seq.clickedButton = 2;
        }
        else if (botao.name == "Botao4")
        {
            seq.clickedButton = 3;
        }
        else
        {
            print("Complicou");
        }
    }
}
