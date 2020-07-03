using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencia : MonoBehaviour
{
    float startTime;
    float currentTime;
    float antcont;
    GameObject sequencia;
    GameObject r1;
    GameObject r2;
    GameObject r3;
    GameObject r4;
    int[] seq = new int[4];
    int i = 0;

    void Start()
    {
        startTime = Time.time;
        sequencia = GameObject.Find("Sequencia");
        r1 = GameObject.Find("r1");
        r2 = GameObject.Find("r2");
        r3 = GameObject.Find("r3");
        r4 = GameObject.Find("r4");
    }

    // Update is called once per frame
    void Update()
    {
       
        currentTime = Time.time - startTime;
        float cont = Mathf.Floor(currentTime / 3);
        if (i < 4) {
            if (cont > antcont)
            {

                antcont = cont;
                Randomizar();

                i++;
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
        switch (ran){
            case 0:
                Desabilita();
                r1.GetComponent<Renderer>().enabled = true;
                
                seq[i] = 0;
                return;
            case 1:
                Desabilita();
                r2.GetComponent<Renderer>().enabled = true;
                seq[i] = 1;
                return;
            case 2:
                Desabilita();
                r3.GetComponent<Renderer>().enabled = true;
                seq[i] = 2;
                return;
            case 3:
                Desabilita();
                r4.GetComponent<Renderer>().enabled = true;
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
