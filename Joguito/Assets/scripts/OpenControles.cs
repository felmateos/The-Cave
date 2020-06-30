using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControles : MonoBehaviour
{
    public GameObject ControlesScreen;

    public bool controles = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
     
    }

    public void OControles()
    {
        if (controles)
        {
            ControlesScreen.SetActive(false);  
            controles = false;
           
		}
        else
        {
            ControlesScreen.SetActive(true);
            controles = true;
           
		}
        
	}
}
