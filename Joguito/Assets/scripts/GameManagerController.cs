using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    
   public GameObject PainelCompleto;

    public bool isPaused = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        Pause();
        GetComponent<AudioSource>().Play();

    }

    public void Pause()
    {
        if (isPaused)
        {
            PainelCompleto.SetActive(false);  
            isPaused = false;
            Time.timeScale = 1;
		}
        else
        {
            PainelCompleto.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
		}
        
	}
}
