using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencia : MonoBehaviour
{
    public float startTime;
    public float startTimeEl;
    float currentTime;
    float antcont;
    float discont;
    GameObject sequencia;
    GameObject r1;
    GameObject r2;
    GameObject r3;
    GameObject r4;
    int[] seq = new int[4];
    int i = 0;
    public bool ativo = false;
    Altar alt;


    void Start()
    {
        alt = GameObject.FindGameObjectWithTag("Altar").GetComponent<Altar>();
        sequencia = GameObject.Find("Sequencia");
        r1 = GameObject.Find("r1");
        r2 = GameObject.Find("r2");
        r3 = GameObject.Find("r3");
        r4 = GameObject.Find("r4");
    }

    // Update is called once per frame
    void Update()
    {
        if (ativo)
        {
            currentTime = Time.time - startTime;
            discont = Time.time - startTimeEl;
            float cont = Mathf.Floor(currentTime / 3);

            if (i < 4)
            {
                if (cont > antcont)
                {
                    startTimeEl = Time.time;
                    discont = 0;


                    antcont = cont;
                    Randomizar();

                    i++;
                }
            }
            if (discont > 2)
            {
                Desabilita();
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int j = 0; j < seq.Length; j++)
            {
                Debug.Log("Numero" + j + "=" + seq[j]);
            }
        }
    }
    public void Randomizar(){

        int ran = Random.Range(0, 4);
        switch (ran)
        {
            case 0:
                // Desabilita();
                r1.GetComponent<Renderer>().enabled = true;
                //print("0");
                seq[i] = 0;
                return;
            case 1:
                //Desabilita();
                r2.GetComponent<Renderer>().enabled = true;
                //print("1");
                seq[i] = 1;
                return;
            case 2:
                // Desabilita();
                r3.GetComponent<Renderer>().enabled = true;
                //print("2");
                seq[i] = 2;
                return;
            case 3:
                // Desabilita();
                r4.GetComponent<Renderer>().enabled = true;
                //print("3");
                seq[i] = 3;
                return;
            default:
                print("Complico");
                break;

        }
       
    }
    public void Desabilita(){
        r1.GetComponent<Renderer>().enabled = false;
        r2.GetComponent<Renderer>().enabled = false;
        r3.GetComponent<Renderer>().enabled = false;
        r4.GetComponent<Renderer>().enabled = false;
    }
}
