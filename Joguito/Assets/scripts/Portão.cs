using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portão : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

   public string nomeDaCena;
 
   public void ChangeS()
   {
       SceneManager.LoadScene(nomeDaCena);
   }

    void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("Player")) 
         {
            ChangeS();
		 }
	}
}
