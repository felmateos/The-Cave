using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public bool certo = false;
    public GameObject botao;
    public GameObject botant;
    Sequencia seq;
    playerController pc;

    // Start is called before the first frame update
    void Start()
    {
        seq = GameObject.Find("Sequencia").GetComponent<Sequencia>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pc.inRange == true && this.certo && seq.endSeq)
        {
            seq.guessStart = true;
            seq.erro = false;

            Desaparece();
            botao.transform.GetChild(0).gameObject.SetActive(true);
            Confere(seq);
            botant = botao;

            if (seq.k<8)
            {
                seq.Verifica();
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && seq.endSeq)
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
    void Desaparece()
    {
        GameObject.Find("Botao1").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Botao2").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Botao3").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Botao4").transform.GetChild(0).gameObject.SetActive(false);

    }

}
